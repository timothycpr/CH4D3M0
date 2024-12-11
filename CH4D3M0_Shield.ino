/*
This code is forked from a private project from Sefs on the MyFocusElectric.com forum.

It is a work in progress and is provided with no warranty of any kind, under the licensing specified at https://github.com/timothycpr/CH4D3M0

It targets an Arduino Due with a SAM3X8E processor to operate CANBus monitoring on a separate thread.

It originally paired to active low isolated relays and has been modified in parallel with prototyping of the CH4D3M0 shield

Depending on the topography of the circuit selected, it may require inputs or outputs to be inverted from the current defaults.
*/

#include <SPI.h>
#include <Arduino.h>
#include <due_can.h>
#include <due_wire.h>
#include "variant.h"
#include <Wire_EEPROM.h>
#include <Scheduler.h>

#define Serial SerialUSB

// TODO: Add proximity monitor, "Kicker" control, CANBus power monitor and CANBus power indicator

/*
Define classes and templates for future use
*/
template<class T> inline Print &operator <<(Print &obj, T arg) {  //Sets up Serial streaming in the format "Serial<<String;"
  obj.print(arg);
  return obj;
}

class Field {
  public:
    uint16_t msb;
    uint16_t bits;
    uint32_t data;
    char* fieldName;
};

class Msg {
  public:
    char* moduleName;
    uint16_t msgID;
    uint64_t msg;
    Field fields[16];
    uint8_t field_count;
};

class StringTable {
  public:
    Msg messages[32];
};

class EEPROMvariables {
  public:
    uint8_t CANdo; // Use Serial port if 2 (Default), CAN0 if 0 or CAN1 if 1
    char logfile[80];
    uint16_t transmitime = 0;
    boolean logger;
    uint32_t datarate = 125000; // lowest officially supported datarate for CANBus is 40kbit/sec
    uint8_t goodEEPROM;
    CAN_FRAME outFrame;
};

/*
Initialize variables
*/
StringTable stringTable;
EEPROMvariables myVars;
uint16_t page = 475;
uint16_t dummy;
char cmdBuffer[100];
char logstring[200];
char logstring2[300] = "";
char logstringt[200];
char logstringt1[200];
char logstringc1[200];
char logstringts[200];
char msgBuff[100];
float Version = 1.10;
int ptrBuffer;
short logcycle = 0;
boolean handlingEvent, debug;
int seq = 0;
unsigned long lastrx = 0;
unsigned long lastactiverx = 0;
unsigned long howlongagorx = 0;
unsigned long howlonglastactiverx = 0;
int chacurrent = 0;
int chargestatus = 0;
float chacurrentf = 0;
float estchatimef = 0;
float seqf = 0;
float mincell = 0;
float maxcell = 0;
float deltacell = 0;
float batchadspl = 0;
float brakemode = 0;
float frictionbrake = 0;
float torquedelivered = 0;
int torquedeliveredint = 0;
float motorRPM = 0;
float MPH = 0;
float hbattchar = 0;
float brake = 0;
float acc = 0;
float pilot = 0;
float ampacity = 0;
float VAC = 0;
float AAC = 0;
float Hz = 0;
int sobdmdiagcycle = 0;
int sobdmtoggle = 0;
int becmdiagcycle = 0;
int becmtoggle = 1;
int socint = 0;
int maxchacurrent = 0;
int maxchatime = 0;
int zerocurrentwait = 0;
int estchatime = 0;
int maxchavoltage = 0;
int chastatusfault = 0;
int chastop = 0;
int vehstop = 0;
int brakeon = 0;
int chaenable = 0;
int compat = 0;
int incra = 0;
int wayup = 0;
int seq1start = 0;
int seq2start = 0;
// e, f, g & k pin assignments can likely be changed to almost any unused digital data pin on the Arduino Due, should they be in a more desirable location for shield layout.
int k = 25; // "Vehicle Ready" signal to charger (consider moving to 38)
int e = 27; // EV Contactor Relay e (consider moving to 40)
int f = 29; // Optoisolator to monitor for d1
int g = 31; // Optoisolator to monitor for d2
int d1 = 0; // d1 is monitored by the optoisolator for signal f
int d2 = 0; // d2 is monitored by the optoisolator for signal g
float hbattcoolin = 0;
float mcon = 0;
float hbattcurr = 0;
float currentandmcon = 0;
float ETE = 0;
float hbatttemp = 0;
float hbattvolt = 0;
float throttle = 0;
float pwrt = 0;
float hvac = 0;
CAN_FRAME inFrame;

void setup() { // Code to run as the initial configuration of the system

  Wire.begin(); // Initialize the wire library and join the I2C bus
  Serial.begin(115200); // opens serial port, sets serial data rate to 115200

  EEPROM.setWPPin(19); // Can't find good info on what WPPin is
  EEPROM.read(page, myVars); // Read the variable page from flash and into EEPROM variables
  if (myVars.goodEEPROM != 200)defaults(); // If the data isn't good, pull defaults from defaults function
  myVars.logger = false;

  initializeCAN(); // Yeah, that

//  Input and output values may need to be inverted depending on the hardware implementation utilized.
//  Optocouplers invert inputs by default, though some include an additional transistor that can invert the output back.
//  This code was written for relays with optocouplers and did not re-invert the signal, making them active-low control (activate when a control pin is tied to ground)
//  This code was written for re-inverting optocouplers monitoring inputs f and g and uses active high logic (d1 or d2 going "high" will create an output that is also "high")
//  Should circuit modifications be made, digital reads may need to be inverted by applying the NOT modifier (variable = !digitalRead(pin_num)) and writes should be replaced with their complementary value
  pinMode(k, OUTPUT); // 25 Relay control is active low
  pinMode(e, OUTPUT); // 27 Relay control is active low
  pinMode(f, INPUT);  // 29 2V+ (pullup to 3.3V) will read as 0/Low/False/Inactive with digital read (inverted)
  pinMode(g, INPUT);  // 31 2V+ (pullup to 3.3V) will read as 0/Low/False/Inactive with digital read (inverted)

  Scheduler.startLoop(ActiveDiagLoop); // Starts the ActiveDiagLoop in the background
}

void loop() { // The "main" loop of code to iterate indefinitely
  while (SerialUSB.available()) { // Start by checking serial
    serialEvent();
  }

//  Minimal parts config inverts these signals
  d1 = !digitalRead(f);  // Check for the state of pin 29
  d2 = !digitalRead(g);  // Check for the state of pin 31

  /* Tell me about them */
//  Serial<<"d1 = ";
//  Serial<<d1;
//  Serial<<"\n";
//  Serial<<"d2 = ";
//  Serial<<d2;
//  Serial<<"\n";

  if (d1 == 0 && d2 == 0) { // CHAdeMO pin 2 (f, pin 29) is floating and CHAdeMO pin 10 (g, pin 31) is floating
    seq = 0; // Charging sequence has not started at all yet
    seq1start = 0;  // All
    seq2start = 0;  // Variables
    chacurrent = 0; // Zero'd
    digitalWrite(k, HIGH); // True, relay open
    digitalWrite(e, HIGH); // True, relay open
  }
  else if (d1 == 1 && d2 == 0 && seq1start == 0) { // CHAdeMO pin 2 (f, pin 29) is has been connected to 12V and CHAdeMO pin 10 (g, pin 31) is floating
    seq = 1; // This signals state one of the charging sequence
    seq1start = 1; // Separate variables to be touched by different branches
  } // This triggers data collection on the car side CAN bus to be shared on the charger side CAN bus
  else if (d1 == 1 && d2 == 1 && seq2start == 0) { // CHAdeMO pin 2 (f, pin 29) is has been connected to 12V and CHAdeMO pin 10 (g, pin 31) is grounded
    seq = 3;
    seq2start = 1;
    digitalWrite(e, LOW); // False - Main Contactor On
  }
  else if (d1 == 0 && d2 == 1) { //Can be reduced to just the first d1/d2 == 0 being changed to d1 == 0 and deleting this block
    seq = 0;
    seq1start = 0;
    seq2start = 0;
    digitalWrite(k, HIGH); // True, relay open
    digitalWrite(e, HIGH); // True, relay open
    chacurrent = 0;
  }

  if (mcon == 0) {
    seq = 0;
//  Serial<<"mcon = ";
//  Serial<<mcon;
//  Serial<<"\n";
  }

  if (seq == 2 || seq == 3 || seq == 4) {
    estchatime = float (((-0.4 * maxchacurrent) + 77)) * (100 - socint) / 100 + 1; // Update estimated charge time with data captured from the active diag loop
  }
  if (seq == 0) {
    incra = 0;
//  Can1.disable();
    digitalWrite(k, HIGH); // True, relay open
    digitalWrite(e, HIGH); // True, relay open
    chacurrent = 0;
    maxchacurrent = 0;
    vehstop = 0;
    maxchatime = 60;
    estchatime = 0;
  }

  if (seq == 1) { // Transmit battery parameters, charging disabled
//  Can1.enable();
//  Compatibility Checks performed on data received on CAN1 through the handleFrame1

    myVars.outFrame.id = 0x100;
    myVars.outFrame.data.bytes[0] = 0x00;
    myVars.outFrame.data.bytes[1] = 0x00;
    myVars.outFrame.data.bytes[2] = 0x00;
    myVars.outFrame.data.bytes[3] = 0x00;
    myVars.outFrame.data.bytes[4] = 0x6C; //max battery voltage
    myVars.outFrame.data.bytes[5] = 0x01; //max battery voltage
    myVars.outFrame.data.bytes[6] = 0x64; //constant for SOC indication
    myVars.outFrame.data.bytes[7] = 0x00;
    sendCAN(myVars.CANdo);
    delay(1);

    myVars.outFrame.id = 0x101;
    myVars.outFrame.data.bytes[0] = 0x00;
    myVars.outFrame.data.bytes[1] = 0xFF; //max charging time by 10s
    myVars.outFrame.data.bytes[2] = maxchatime; //max charging time by 1 min
    myVars.outFrame.data.bytes[3] = estchatime; //estimated charging time
    myVars.outFrame.data.bytes[4] = 0x00;
    myVars.outFrame.data.bytes[5] = 0x00;
    myVars.outFrame.data.bytes[6] = 0x00;
    myVars.outFrame.data.bytes[7] = 0x00;
    sendCAN(myVars.CANdo);
    delay(1);

//  Vehicle permission not yet given, EV contactor still open
    myVars.outFrame.id = 0x102;
    myVars.outFrame.data.bytes[0] = 0x01; //version number
    myVars.outFrame.data.bytes[1] = 0x68; //target battery voltage
    myVars.outFrame.data.bytes[2] = 0x01; //target battery voltage
    myVars.outFrame.data.bytes[3] = 0x00; //requested current
    myVars.outFrame.data.bytes[4] = 0x00; //fault flag
    myVars.outFrame.data.bytes[5] = 0x08; //status flag (charging disabled, contact open)
    myVars.outFrame.data.bytes[6] = socint; //displayed SOC
    myVars.outFrame.data.bytes[7] = 0x00;
    sendCAN(myVars.CANdo);
    delay(1);

//  Compatability Checker

    if (compat == 1) {
      incra++;
    }
    else if (compat == 2) {
      seq = 0;
    }

    if (incra > 5 && incra < 10) {
      digitalWrite(k, LOW); // False - Vehicle grounds pin 4
    }
    else if (incra > 15) {
      seq = 2;
      incra = 0;
    }
  }
  else if (seq == 2) { // Transmit battery parameters, charging enabled, Vehicle permission given
  
    myVars.outFrame.id = 0x100;
    myVars.outFrame.data.bytes[0] = 0x00;
    myVars.outFrame.data.bytes[1] = 0x00;
    myVars.outFrame.data.bytes[2] = 0x00;
    myVars.outFrame.data.bytes[3] = 0x00;
    myVars.outFrame.data.bytes[4] = 0x6C; //max battery voltage
    myVars.outFrame.data.bytes[5] = 0x01; //max battery voltage
    myVars.outFrame.data.bytes[6] = 0x64; //constant for SOC indication
    myVars.outFrame.data.bytes[7] = 0x00;
    sendCAN(myVars.CANdo);
    delay(1);

    myVars.outFrame.id = 0x101;
    myVars.outFrame.data.bytes[0] = 0x00;
    myVars.outFrame.data.bytes[1] = 0xFF; //max charging time by 10s
    myVars.outFrame.data.bytes[2] = maxchatime; //max charging time by 1 min
    myVars.outFrame.data.bytes[3] = estchatime; //estimated charging time
    myVars.outFrame.data.bytes[4] = 0x00;
    myVars.outFrame.data.bytes[5] = 0x00;
    myVars.outFrame.data.bytes[6] = 0x00;
    myVars.outFrame.data.bytes[7] = 0x00;
    sendCAN(myVars.CANdo);
    delay(1);

//  Vehicle permission given, start isolation checks, EV contactor open still
    myVars.outFrame.id = 0x102;
    myVars.outFrame.data.bytes[0] = 0x01; //version number
    myVars.outFrame.data.bytes[1] = 0x68; //target battery voltage
    myVars.outFrame.data.bytes[2] = 0x01; //target battery voltage
    myVars.outFrame.data.bytes[3] = 0x00; //requested current
    myVars.outFrame.data.bytes[4] = 0x00; //fault flag
    myVars.outFrame.data.bytes[5] = 0x09; //status flag (charging enabled, contact open)
    myVars.outFrame.data.bytes[6] = socint; //displayed SOC
    myVars.outFrame.data.bytes[7] = 0x00;
    sendCAN(myVars.CANdo);
    delay(1);
    incra = 0;
  }

  else if (seq == 3) {  //Vehicle permission given, EV contactor has closed, wait to request current until 0x109.5.1 and indicate closed relay
    myVars.outFrame.id = 0x100;
    myVars.outFrame.data.bytes[0] = 0x00;
    myVars.outFrame.data.bytes[1] = 0x00;
    myVars.outFrame.data.bytes[2] = 0x00;
    myVars.outFrame.data.bytes[3] = 0x00;
    myVars.outFrame.data.bytes[4] = 0x6C; //max battery voltage
    myVars.outFrame.data.bytes[5] = 0x01; //max battery voltage
    myVars.outFrame.data.bytes[6] = 0x64; //constat for SOC indication
    myVars.outFrame.data.bytes[7] = 0x00;
    sendCAN(myVars.CANdo);
    delay(1);

    myVars.outFrame.id = 0x101;
    myVars.outFrame.data.bytes[0] = 0x00;
    myVars.outFrame.data.bytes[1] = 0xFF; //max charging time by 10s
    myVars.outFrame.data.bytes[2] = maxchatime; //max charging time by 1 min
    myVars.outFrame.data.bytes[3] = estchatime; //estimated charging time
    myVars.outFrame.data.bytes[4] = 0x00;
    myVars.outFrame.data.bytes[5] = 0x00;
    myVars.outFrame.data.bytes[6] = 0x00;
    myVars.outFrame.data.bytes[7] = 0x00;
    sendCAN(myVars.CANdo);
    delay(1);

    myVars.outFrame.id = 0x102;
    myVars.outFrame.data.bytes[0] = 0x01; //version number
    myVars.outFrame.data.bytes[1] = 0x68; //target battery voltage
    myVars.outFrame.data.bytes[2] = 0x01; //target battery voltage
    myVars.outFrame.data.bytes[3] = 0x00; //requested current
    myVars.outFrame.data.bytes[4] = 0x00; //fault flag
    myVars.outFrame.data.bytes[5] = 0x01; //status flag (charging enabled, contact closed)
    myVars.outFrame.data.bytes[6] = socint; //displayed SOC
    myVars.outFrame.data.bytes[7] = 0x00;
    sendCAN(myVars.CANdo);
    delay(1);
    incra++;
    if (incra > 10) {
      seq = 4;
      incra = 0;
      chacurrent = 1;
      wayup = 0;
      zerocurrentwait = 0;
    }
  }

  else if (seq == 4) {
    if (batchadspl > 99.5) { // Battery is full
      vehstop = 1;
    }
    myVars.outFrame.id = 0x100;
    myVars.outFrame.data.bytes[0] = 0x00;
    myVars.outFrame.data.bytes[1] = 0x00;
    myVars.outFrame.data.bytes[2] = 0x00;
    myVars.outFrame.data.bytes[3] = 0x00;
    myVars.outFrame.data.bytes[4] = 0x6C; //max battery voltage
    myVars.outFrame.data.bytes[5] = 0x01; //max battery voltage
    myVars.outFrame.data.bytes[6] = 0x64; //constat for SOC indication
    myVars.outFrame.data.bytes[7] = 0x00;
    sendCAN(myVars.CANdo);
    delay(1);

    myVars.outFrame.id = 0x101;
    myVars.outFrame.data.bytes[0] = 0x00;
    myVars.outFrame.data.bytes[1] = 0xFF; //max charging time by 10s
    myVars.outFrame.data.bytes[2] = maxchatime; //max charging time by 1 min
    myVars.outFrame.data.bytes[3] = estchatime; //estimated charging time
    myVars.outFrame.data.bytes[4] = 0x00;
    myVars.outFrame.data.bytes[5] = 0x00;
    myVars.outFrame.data.bytes[6] = 0x00;
    myVars.outFrame.data.bytes[7] = 0x00;
    sendCAN(myVars.CANdo);
    delay(1);

//  Vehicle permission given, EV contactor has closed, start requesting and indicate closed relay
    myVars.outFrame.id = 0x102;
    myVars.outFrame.data.bytes[0] = 0x01; //version number
    myVars.outFrame.data.bytes[1] = 0x68; //target battery voltage
    myVars.outFrame.data.bytes[2] = 0x01; //target battery voltage
    myVars.outFrame.data.bytes[3] = chacurrent; //requested current
    myVars.outFrame.data.bytes[4] = 0x00; //fault flag
    if ((chastop == 1 && incra > 20) || vehstop == 1) {
      myVars.outFrame.data.bytes[5] = 0x00; //status flag (charging enabled, contact closed)
      zerocurrentwait++;
    }
    else {
      myVars.outFrame.data.bytes[5] = 0x01; //status flag (charging enabled, contact closed)
      zerocurrentwait = 0;
    }
    myVars.outFrame.data.bytes[6] = socint; //displayed SOC
    myVars.outFrame.data.bytes[7] = 0x00;
    sendCAN(myVars.CANdo);
    delay(1);
    incra++;
    if (wayup == 0 && chaenable == 1) {
      if (chacurrent < maxchacurrent) {
        chacurrent = chacurrent + 2;
        if (chacurrent > maxchacurrent) {
          chacurrent = maxchacurrent;
        }
      }
      else {
        wayup = 1;
      }
    }

    if ((chastop == 1 && incra > 20) || vehstop == 1 ) {
      chacurrent = chacurrent - 20;
      if (chacurrent < 1) {
        chacurrent = 0;
      }
      wayup = 1;
      if (chacurrent == 0 && zerocurrentwait > 18) {
        seq = 5;
        chacurrent = 0;
        digitalWrite(k, HIGH); // True, relay open
//      digitalwrite(e,HIGH);
      }

    }
    if (hbattvolt >= 359 || maxcell > 4.15) {
      wayup = 1;
      if (chacurrent > 0) {
        chacurrent = chacurrent - 1;
      }
      /*else
      {
        chacurrent = 0;
        seq = 5;
        //digitalwrite(e,HIGH);
      }*/
    }
    incra = 0;
  }

  else if (seq == 5) {
    chacurrent = 0;
//  Permission Revoked, EV contactor has opened
    myVars.outFrame.id = 0x102;
    myVars.outFrame.data.bytes[0] = 0x01; //version number
    myVars.outFrame.data.bytes[1] = 0x68; //target battery voltage
    myVars.outFrame.data.bytes[2] = 0x01; //target battery voltage
    myVars.outFrame.data.bytes[3] = 0x00; //requested current
    myVars.outFrame.data.bytes[4] = 0x00; //fault flag
    if (chaenable == 0) {
      digitalWrite(e, LOW); // False, relay open
      myVars.outFrame.data.bytes[5] = 0x08; //status flag (charging enabled, contact closed)
      incra++;
    }
    else if (chaenable == 1) {
      myVars.outFrame.data.bytes[5] = 0x00; //status flag (charging enabled, contact closed)
    }
    myVars.outFrame.data.bytes[5] = 0x00; //status flag (charging enabled, contact closed)
    myVars.outFrame.data.bytes[6] = socint; //displayed SOC
    myVars.outFrame.data.bytes[7] = 0x00;
    sendCAN(myVars.CANdo);

    if (incra > 25) {
      seq = 0;
//    Can1.disable();
    }

  }
//  Brake mode
  if (frictionbrake > 0 && torquedelivered < -1) {
//  Blended
    brakemode = 2;
  }
  else if (frictionbrake > 0 && torquedelivered > -1) {
//  Friction
    brakemode = 3;
  }
  else if (frictionbrake == 0 && torquedelivered < -1) {
//  Regen
    brakemode = 1;
  }
  else if (frictionbrake == 0 && torquedelivered > -1) {
//  No Brake
    brakemode = 0;
  }

  chacurrentf = (float) chacurrent;
  seqf = (float) seq;

  estchatimef = (float) estchatime;
  sprintf(logstring2, "%.2f;%.2f;%.2f;%.2f;%.2f;%.2f;%.2f;%.2f;%.2f;%.2f;%.2f;%.2f;%.2f;%.2f;%.2f;%.2f;%.2f;%.2f;%.2f;%.2f;%.2f;%.2f;%.2f;%.2f;%.2f;%.2f;\n",
  batchadspl, hbattchar, hbattcoolin, mcon, hbattcurr, hbattvolt, ETE, hbatttemp, seqf, chacurrentf, torquedelivered,
  brakemode, estchatimef, motorRPM, MPH, throttle, brake, pwrt, acc, hvac, VAC, AAC, ampacity, Hz, mincell, maxcell);
//  Serial << logstring2;

  howlongagorx = (unsigned long) millis() - lastrx;
  howlonglastactiverx = (unsigned long) millis() - lastactiverx;

  if (howlongagorx > 500) {
    mincell = 0;
    maxcell = 0;
    deltacell = 0;
    batchadspl = 0;
    brakemode = 0;
    frictionbrake = 0;
    torquedelivered = 0;
    motorRPM = 0;
    MPH = 0;
    hbattchar = 0;
    becmtoggle = 0;
    hbattcoolin = 0;
    mcon = 0;
    hbattcurr = 0;
    currentandmcon = 0;
    ETE = 0;
    hbatttemp = 0;
    hbattvolt = 0;
    throttle = 0;
    pwrt = 0;
    hvac = 0;
  }
  if (howlonglastactiverx > 500) {
    mincell = 0;
    maxcell = 0;
    deltacell = 0;
    hbattvolt = 0;
  }
  if (seq == 1) {
    delay(97);
  }
  else {
    delay(100);
  }
}

void ActiveDiagLoop() { // Started in the background before loop() is kicked off

  if (MPH > 0) { // If the car is moving, clear all the charging variables
    sobdmtoggle = 0;
    pilot = 0;
    AAC = 0;
    VAC = 0;
    ampacity = 0;
    Hz = 0;
  }
  becmdiagcycle = becmdiagcycle * becmtoggle; // If becmtoggle is set to 0, it will clear any non-zero value from becmdiagcycle
  if (becmdiagcycle == 0) { // Send BECM Diagnostic Request for Delta Cell Voltage when becmdiagcycle == 0
    myVars.outFrame.id = 0x7E4;
    myVars.outFrame.data.bytes[0] = 0x03;
    myVars.outFrame.data.bytes[1] = 0x22;
    myVars.outFrame.data.bytes[2] = 0x48;
    myVars.outFrame.data.bytes[3] = 0x40;
    myVars.outFrame.data.bytes[4] = 0x00;
    myVars.outFrame.data.bytes[5] = 0x00;
    myVars.outFrame.data.bytes[6] = 0x00;
    myVars.outFrame.data.bytes[7] = 0x00;
    myVars.outFrame.length = 8;
    myVars.outFrame.fid = 0;
    myVars.outFrame.rtr = 1;
    myVars.outFrame.priority = 0;
    myVars.outFrame.extended = false;
    Can0.sendFrame(myVars.outFrame); // Sent to CAN0 (car side bus) 
  }
  else if (becmdiagcycle == 1) { // Send BECM Diagnostic Request for Min Cell Voltage when becmdiagcycle == 1
    myVars.outFrame.id = 0x7E4;
    myVars.outFrame.data.bytes[0] = 0x03;
    myVars.outFrame.data.bytes[1] = 0x22;
    myVars.outFrame.data.bytes[2] = 0x48;
    myVars.outFrame.data.bytes[3] = 0x3F;
    myVars.outFrame.data.bytes[4] = 0x00;
    myVars.outFrame.data.bytes[5] = 0x00;
    myVars.outFrame.data.bytes[6] = 0x00;
    myVars.outFrame.data.bytes[7] = 0x00;
    myVars.outFrame.length = 8;
    myVars.outFrame.fid = 0;
    myVars.outFrame.rtr = 1;
    myVars.outFrame.priority = 0;
    myVars.outFrame.extended = false;
    Can0.sendFrame(myVars.outFrame);
  }
  else if (becmdiagcycle == 2) { // Send BECM Diagnostic Request for Voltage when becmdiagcycle == 2
    myVars.outFrame.id = 0x7E4;
    myVars.outFrame.data.bytes[0] = 0x03;
    myVars.outFrame.data.bytes[1] = 0x22;
    myVars.outFrame.data.bytes[2] = 0x48;
    myVars.outFrame.data.bytes[3] = 0x0D;
    myVars.outFrame.data.bytes[4] = 0x00;
    myVars.outFrame.data.bytes[5] = 0x00;
    myVars.outFrame.data.bytes[6] = 0x00;
    myVars.outFrame.data.bytes[7] = 0x00;
    myVars.outFrame.length = 8;
    myVars.outFrame.fid = 0;
    myVars.outFrame.rtr = 1;
    myVars.outFrame.priority = 0;
    myVars.outFrame.extended = false;
    Can0.sendFrame(myVars.outFrame);
  }

  if (sobdmtoggle == 1) { // Delay 20ms
    delay(20);
  }
  
  sobdmdiagcycle = sobdmdiagcycle * sobdmtoggle; // If sobdmtoggle is set to 0, it will clear any non-zero value from sobdmdiagcycle

  if (sobdmdiagcycle == 1) { // Send SOBDM Diagnostic Request for AC Voltage when sobdmdiagcycle == 1
    myVars.outFrame.id = 0x7E2;
    myVars.outFrame.data.bytes[0] = 0x03;
    myVars.outFrame.data.bytes[1] = 0x22;
    myVars.outFrame.data.bytes[2] = 0x48;
    myVars.outFrame.data.bytes[3] = 0x5E;
    myVars.outFrame.data.bytes[4] = 0x00;
    myVars.outFrame.data.bytes[5] = 0x00;
    myVars.outFrame.data.bytes[6] = 0x00;
    myVars.outFrame.data.bytes[7] = 0x00;
    myVars.outFrame.length = 8;
    myVars.outFrame.fid = 0;
    myVars.outFrame.rtr = 1;
    myVars.outFrame.priority = 0;
    myVars.outFrame.extended = false;
    Can0.sendFrame(myVars.outFrame);
  }

  else if (sobdmdiagcycle == 2) { // Send SOBDM Diagnostic Request for AC Amps when sobdmdiagcycle == 2
    myVars.outFrame.id = 0x7E2;
    myVars.outFrame.data.bytes[0] = 0x03;
    myVars.outFrame.data.bytes[1] = 0x22;
    myVars.outFrame.data.bytes[2] = 0x48;
    myVars.outFrame.data.bytes[3] = 0x5F;
    myVars.outFrame.data.bytes[4] = 0x00;
    myVars.outFrame.data.bytes[5] = 0x00;
    myVars.outFrame.data.bytes[6] = 0x00;
    myVars.outFrame.data.bytes[7] = 0x00;
    myVars.outFrame.length = 8;
    myVars.outFrame.fid = 0;
    myVars.outFrame.rtr = 1;
    myVars.outFrame.priority = 0;
    myVars.outFrame.extended = false;
    Can0.sendFrame(myVars.outFrame);
  }

  else if (sobdmdiagcycle == 3) { // Send SOBDM Diagnostic Request for Pilot Signal when sobdmdiagcycle == 3
    myVars.outFrame.id = 0x7E2;
    myVars.outFrame.data.bytes[0] = 0x03;
    myVars.outFrame.data.bytes[1] = 0x22;
    myVars.outFrame.data.bytes[2] = 0x48;
    myVars.outFrame.data.bytes[3] = 0x61;
    myVars.outFrame.data.bytes[4] = 0x00;
    myVars.outFrame.data.bytes[5] = 0x00;
    myVars.outFrame.data.bytes[6] = 0x00;
    myVars.outFrame.data.bytes[7] = 0x00;
    myVars.outFrame.length = 8;
    myVars.outFrame.fid = 0;
    myVars.outFrame.rtr = 1;
    myVars.outFrame.priority = 0;
    myVars.outFrame.extended = false;
    Can0.sendFrame(myVars.outFrame);
  }

  else if (sobdmdiagcycle == 4) { // Send SOBDM Diagnostic Request for AC Hz when sobdmdiagcycle == 4
    myVars.outFrame.id = 0x7E2;
    myVars.outFrame.data.bytes[0] = 0x03;
    myVars.outFrame.data.bytes[1] = 0x22;
    myVars.outFrame.data.bytes[2] = 0x48;
    myVars.outFrame.data.bytes[3] = 0x60;
    myVars.outFrame.data.bytes[4] = 0x00;
    myVars.outFrame.data.bytes[5] = 0x00;
    myVars.outFrame.data.bytes[6] = 0x00;
    myVars.outFrame.data.bytes[7] = 0x00;
    myVars.outFrame.length = 8;
    myVars.outFrame.fid = 0;
    myVars.outFrame.rtr = 1;
    myVars.outFrame.priority = 0;
    myVars.outFrame.extended = false;
    Can0.sendFrame(myVars.outFrame);
  }
  delay(30); // Delay 30ms
}

void serialEventRun(void) {
  if (Serial.available())serialEvent();  //If Serial event interrupt is on USB port, go check for keyboard input
}

void serialEvent() {
  int incoming; 

  incoming = -1; //Serial.read();
  if (incoming == -1) { // false alarm....
    return; // Exit serialEvent() and continue
  }

  if (incoming == 10 || incoming == 13) { // If it's 10 or 13 chars long, it's a command.
    handleConsoleCmd(); //Parse it with handleConsoleCmd()
    ptrBuffer = 0; // Reset line counter once the line has been processed
  }
  else { // Put it in the command buffer array
    cmdBuffer[ptrBuffer++] = (unsigned char) incoming; 
    if (ptrBuffer > 79)
      ptrBuffer = 79; // Stop incrementing once 80 commands are in the buffer array
  }
}

void handleConsoleCmd() {
  handlingEvent = true; // Event handling interlock

  if (ptrBuffer < 5 ) { //command is a single ascii character
    handleShortCmd();
  }
  else { //if cmd over 1 char then assume (for now) that it is a config line
    handleConfigCmd();
  }

  handlingEvent = false;
}

void handleConfigCmd() {
  int i;
  int newValue;

  if (ptrBuffer < 6) return; /*4 digit command, =, value is at least 6 characters*/
  cmdBuffer[ptrBuffer] = 0;  //make sure to null terminate
  String cmdString = String();
  unsigned char whichEntry = '0';
  i = 0;

  while (cmdBuffer[i] != '=' && i < ptrBuffer) {
    cmdString.concat(String(cmdBuffer[i++]));
  }
  i++; //skip the =
  if (i >= ptrBuffer) {
//  Serial << ("Command needs a value..ie FILE=myfile.log");
    return;  // or, we could use this to display the parameter instead of setting
  }

//  strtol() is able to parse also hex values (e.g. a string "0xCAFE"), useful for enable/disable by device id
  newValue = strtol((char *) (cmdBuffer + i), NULL, 0);
  cmdString.toUpperCase();

  if (cmdString == String("XXXX")) {
    if (newValue > maxchacurrent && seq == 4) {
      wayup = 1;
      chacurrent = maxchacurrent;
    }
    else if (newValue < 0 && seq == 4) {
      wayup = 1;
      chacurrent = 0;
    }
    else if (newValue < maxchacurrent && newValue > 0 && seq == 4) {
      wayup = 1;
      chacurrent = newValue;
    }
  }
  else if (cmdString == String("xxxx") ) {
    if (newValue > maxchacurrent && seq == 4) {
      wayup = 1;
      chacurrent = maxchacurrent;
    }
    else if (newValue < 0 && seq == 4) {
      wayup = 1;
      chacurrent = 0;
    }
    else if (newValue < maxchacurrent && newValue > 0 && seq == 4) {
      wayup = 1;
      chacurrent = newValue;
    }
  }
}

void handleShortCmd(){
  uint8_t val;

  switch (cmdBuffer[0]) {
    case '1':
      seq = 1;
//    Can1.enable();  // Disable me
//    digitalWrite(k,LOW); // Disable me
//    Serial<<"Now in PRECHARGE PHASE SEQ=1\n"; // Disable me
      break;
    case '2':
      seq = 2;
//    digitalWrite(e,LOW);  // Disable me
//    Serial<<"Now in ISO CHECK MODE SEQ=2\n";  // Disable me
      break;
    case '3':
      seq = 3;
//    Serial<<"Now in CONTACT CLOSED MODE SEQ=3\n"; // Disable me
      break;
    case '4':
      seq = 4;
      chacurrent = 1;
//    Serial<<"Now in CHARGING MODE SEQ=4\n"; // Disable me
      break;
    case '5':
      seq = 5;
//    Serial<<"Now in ENDING CHARGE SEQ=5\n"; // Disable me
      break;
    case '6':

      if (sobdmtoggle == 0) {
        sobdmtoggle = 1;
        sobdmdiagcycle = 1;
      }
      else {
        sobdmtoggle = 0;
        pilot = 0;
        AAC = 0;
        VAC = 0;
        ampacity = 0;
        Hz = 0;
      }
      sobdmdiagcycle =  sobdmdiagcycle * sobdmtoggle;
      break;

    case '7':

      if (becmtoggle == 0) {
        becmtoggle = 1;
        becmdiagcycle = 0;
      }
      else {
        becmtoggle = 0;
        mincell = 0;
        maxcell = 0;
        becmdiagcycle = 0;
      }
      becmdiagcycle =  becmdiagcycle * becmtoggle;

      break;

    case '9':
      vehstop = 1;
      break;

    case '0':
      seq = 0;

//    initializeCAN();
//    Can1.disable();
//    digitalWrite(k,LOW);
//    digitalwrite(e,LOW);
//    Serial<<"Now in NO COMMS mode. OFF SEQ=0\n";
      break;
  }
  cmdBuffer[0] = 0;
}

void initializeCAN(){
  pinMode(48, OUTPUT);
  Can1.enable();
  if (Can1.begin(myVars.datarate, 48)) {
    Can1.setRXFilter(0x108, 0x7FF, false);
    Can1.setRXFilter(0x109, 0x7FF, false);
//  Can1.setRXFilter(1,0,0, false);
//  Can1.setRXFilter(2,0,0, true);
    Can1.setGeneralCallback(handleFrame1);
    Can1.disable_tx_repeat();

    Serial << "\n\nUsing CAN1 - initialization completed at " << myVars.datarate << " \n";
  }
  else Serial.println("\nCAN1 initialization (sync) ERROR\n");

  pinMode(50, OUTPUT);
  Can0.enable();
  if (Can0.begin(myVars.datarate, 50)) {
    Can0.setRXFilter(0x24C, 0x7B7, false);  // BAT_CHA_DSPL, H_BATT_CHAR, Battery Coolant Inlet Temperature
    Can0.setRXFilter(0x07A, 0x7F0, false);  // Current and Main Contactor, Voltage
    Can0.setRXFilter(0x1E4, 0x7FF, false);  // Energy-to-empty, Battery temp
//  Can0.setRXFilter(0x07D, 0x7F7, false);  // Friction Brake Check, Brake Pedal
//  Can0.setRXFilter(0x075, 0x7FF, false);  // Torque Delivered, RPM
    Can0.setRXFilter(0x160, 0x5F2, false);  // MPH
//  Can0.setRXFilter(0x165, 0x7FF, false);  // Brake on
//  Can0.setRXFilter(0x204, 0x7FF, false);  // Throttle
    Can0.setRXFilter(0x117, 0x7FF, false);  // PWRT kW
//  Can0.setRXFilter(0x368, 0x7F7, false);  // ACC kW, HVAC kW
    Can0.setRXFilter(0x7EA, 0x7F9, false);  // AC Voltage Input, AC Current Input, AC Hz Input
//  Can0.setRXFilter(0x7EC, 0x7F9, false);  // Min Cell Voltage, Cell Variation

    Can0.setGeneralCallback(handleFrame);
    Serial << "\n\nUsing CAN0 - initialization completed at " << myVars.datarate << " \n";
  }
  else Serial.println("\nCAN0 initialization (sync) ERROR\n");
}

void handleFrame(CAN_FRAME * frame){
  lastrx = millis();

  if (frame->id == 0x24C) {
//  BAT_CHA_DSPL
    sprintf(logstringt, "%02X", frame->data.bytes[6]);
    batchadspl = (float)strtol(logstringt, NULL, 16) / 2;
    socint = (int) batchadspl;

//  H_BATT_CHAR
    sprintf(logstringt, "%02X%02X", frame->data.bytes[3], frame->data.bytes[4]);
    hbattchar = (float)strtol(logstringt, NULL, 16) / 10;

//  Battery Coolant Inlet Temperature
    sprintf(logstringt, "%02X", frame->data.bytes[0]);
    hbattcoolin = (float)(strtol(logstringt, NULL, 16) - 50) * 9 / 5 + 32;
  }
  else if (frame->id == 0x07A) {
//  Current and Main Contactor
    sprintf(logstringt, "%02X%02X", frame->data.bytes[0], frame->data.bytes[1]);
    currentandmcon = (float)strtol(logstringt, NULL, 16);

    if (currentandmcon >= 32768) {
      mcon = 1;
      hbattcurr = (currentandmcon - 32768) * 0.0500000000029104 - 750.050000071525;
    }
    else if (currentandmcon < 32768) {
      mcon = 0;
      hbattcurr = currentandmcon * 0.0500000000029104 - 750.050000071525;
    }
//  Voltage
    
    sprintf(logstringt, "%02X%02X", frame->data.bytes[2], frame->data.bytes[3]);
    hbattvolt = (float)strtol(logstringt, NULL, 16) * 0.5;
  }
  else if (frame->id == 0x1E4) {
//  ETE
    sprintf(logstringt, "%02X%02X", frame->data.bytes[0], frame->data.bytes[1]);
    ETE = (float)strtol(logstringt, NULL, 16) / 20;

//  Battery Temperature
    sprintf(logstringt, "%02X", frame->data.bytes[6]);
    hbatttemp = (float)(strtol(logstringt, NULL, 16) / 2 - 10) * 9 / 5 + 32;
  }
  else if (frame->id == 0x07D) {
//  Friction Brake Checker
    sprintf(logstringt, "%02X%02X", frame->data.bytes[4], frame->data.bytes[5]);
    frictionbrake = (float)strtol(logstringt, NULL, 16) - 24576;

//  Brake Pedal
    sprintf(logstringt, "%02X%02X", frame->data.bytes[0], frame->data.bytes[1]);
    sprintf(logstringts, "%c%c%c", logstringt[1], logstringt[2], logstringt[3]);

    brake = (float)strtol(logstringts, NULL, 16) * 0.14792899408284;
  }
  else if (frame->id == 0x075) {
//  Torque Delivered
    sprintf(logstringt, "%02X%02X", frame->data.bytes[2], frame->data.bytes[3]);
    torquedeliveredint = (int)strtol(logstringt, NULL, 16);
    torquedeliveredint = (torquedeliveredint & 16383);
    torquedelivered = (0.1 * torquedeliveredint - 1000) * 0.737562149;

//  RPM
    sprintf(logstringt, "%02X%02X", frame->data.bytes[6], frame->data.bytes[7]);
    motorRPM = ((float)strtol(logstringt, NULL, 16) - 45268)*2;
  }
  else if (frame->id == 0x160) {
//  MPH
    sprintf(logstringt, "%02X%02X", frame->data.bytes[2], frame->data.bytes[3]);
    MPH = (float)strtol(logstringt, NULL, 16);
    MPH = (MPH / 100) * 0.621371;
  }
  else if (frame->id == 0x165) {
//  Brake On
    sprintf(logstringt, "%02X", frame->data.bytes[4]);
    brakeon = (int)strtol(logstringt, NULL, 16);
    if (brakeon == 16) {
      vehstop = 1;
    }
  }
  else if (frame->id == 0x0204) {
//  Throttle
    sprintf(logstringt, "%02X%02X", frame->data.bytes[0], frame->data.bytes[1]);
    sprintf(logstringts, "%c%c%c", logstringt[1], logstringt[2], logstringt[3]);
    throttle = (float)strtol(logstringts, NULL, 16) / 10;
  }

  else if (frame->id == 0x117) {
//  PWRT kW
    sprintf(logstringt, "%02X%02X", frame->data.bytes[4], frame->data.bytes[5]);
    pwrt = (float)strtol(logstringt, NULL, 16) - 41215;
  }

  else if (frame->id == 0x368) {
//  ACC kW
    sprintf(logstringt, "%02X%02X", frame->data.bytes[4], frame->data.bytes[5]);
    acc = (float)strtol(logstringt, NULL, 16) / 100;
    acc = acc * hbattvolt / 1000;

//  HVAC kW
    sprintf(logstringt, "%02X%02X", frame->data.bytes[0], frame->data.bytes[1]);
    sprintf(logstringts, "%c%c%c", logstringt[1], logstringt[2], logstringt[3]);
    hvac = (float)strtol(logstringts, NULL, 16) * 0.005;
  }

  else if (frame->id == 0x7EA) {
    if (sobdmdiagcycle == 1) {
//  AC Voltage Input
      sprintf(logstringt, "%02X%02X", frame->data.bytes[4], frame->data.bytes[5]);
      VAC = (float)strtol(logstringt, NULL, 16) / 100;
      sobdmdiagcycle = 2;
    }
    else if (sobdmdiagcycle == 2) {
//  AC Current Input
      sprintf(logstringt, "%02X", frame->data.bytes[4]);
      AAC = (float)strtol(logstringt, NULL, 16);
      sobdmdiagcycle = 3;
    }
    else if (sobdmdiagcycle == 3) {
//  AC Current Input
      sprintf(logstringt, "%02X", frame->data.bytes[4]);
      pilot = (float)strtol(logstringt, NULL, 16) / 2;
      if (pilot >= 10 && pilot <= 85) {
        ampacity = (float) pilot * 0.6;
      }
      else if (pilot > 85 && pilot <= 96) {
        ampacity = (float) ((pilot - 64) * 2.5);
      }
      sobdmdiagcycle = 4;
    }

    else if (sobdmdiagcycle == 4) {
//  AC Hz Input
      sprintf(logstringt, "%02X", frame->data.bytes[4]);
      Hz = (float)strtol(logstringt, NULL, 16) / 2;

      sobdmdiagcycle = 1;
    }
    sobdmdiagcycle = sobdmdiagcycle * sobdmtoggle;
  }
  else if (frame->id == 0x7EC) {
    lastactiverx = millis();
    if (becmdiagcycle == 0) {
//  Min Cell Voltage
      sprintf(logstringt, "%02X%02X", frame->data.bytes[4], frame->data.bytes[5]);
      mincell = (float)strtol(logstringt, NULL, 16) / 1000;
      becmdiagcycle = 1;
    }
    else if (becmdiagcycle == 1) {
//  Cell Variation
      sprintf(logstringt, "%02X", frame->data.bytes[4]);
      deltacell = (float)strtol(logstringt, NULL, 16) / 100;
      becmdiagcycle = 0;
      maxcell = (float) deltacell + mincell + 0.005;
    }
    /*
    else if (becmdiagcycle == 2)
    {
    sprintf(logstringt, "%02X%02X", frame->data.bytes[4], frame->data.bytes[5]);
    hbattvolt = (float)strtol(logstringt, NULL, 16) / 100;
    becmdiagcycle = 0;
    }*/
  }
}

void handleFrame1(CAN_FRAME * frame1) {
  if (frame1->id == 0x108) {
//  Max Charging Current Avaialable
    sprintf(logstringt1, "%02X", frame1->data.bytes[3]);
    maxchacurrent = (int)strtol(logstringt1, NULL, 16);
    compat = 1;

    if (seq == 1) {
      maxchatime = float (((-0.5385 * maxchacurrent) + 104)) * (100 - socint) / 100 + 6;

      estchatime = float (((-0.4 * maxchacurrent) + 77)) * (100 - socint) / 100 + 1;
    }
  }
  else if (frame1->id == 0x109) {
//  Status/Fault Flag
    sprintf(logstringt1, "%02X", frame1->data.bytes[5]);
    chastatusfault = (int)strtol(logstringt1, NULL, 16);

    if (chastatusfault >= 32) {
      chastop = 1;
    }
    else {
      chastop = 0;
    }
    if ((chastatusfault % 2) == 0) {
      chaenable = 0;
    }
    else {
      chaenable = 1;
    }
    /*
    Serial<<"cha enable = ";
    Serial<<chaenable;
    Serial<<"     chastop = ";
    Serial<<chastop;
    Serial<<"\n";
    */
  }

  /*
  sprintf(logstringc1,"Rcvd msgID %03X  %02X  %02X  %02X  %02X  %02X  %02X  %02X  %02X;\n", frame1->id, frame1->data.bytes[0],
     frame1->data.bytes[1],frame1->data.bytes[2], frame1->data.bytes[3], frame1->data.bytes[4], frame1->data.bytes[5], frame1->data.bytes[6],
     frame1->data.bytes[7]);
     Serial << logstringc1;*/
}

void sendCAN(int which) {
  /*
        char buffer[140];

        sprintf(buffer,"Sent msgID 0x%03X %02X  %02X  %02X  %02X  %02X  %02X  %02X  %02X;\n", myVars.outFrame.id,
        myVars.outFrame.data.bytes[0], myVars.outFrame.data.bytes[1], myVars.outFrame.data.bytes[2],
        myVars.outFrame.data.bytes[3], myVars.outFrame.data.bytes[4], myVars.outFrame.data.bytes[5],
        myVars.outFrame.data.bytes[6], myVars.outFrame.data.bytes[7]);
        Serial<<buffer;
        Serial<<"\n";
    */    
//  int time=millis();
//  Serial<<time;
//  Serial<<"\n";

  myVars.outFrame.length = 8;
  myVars.outFrame.fid = 0;
  myVars.outFrame.rtr = 1;
  myVars.outFrame.priority = 0;
  myVars.outFrame.extended = false;
//  int time=micros();
//  Serial<<time<<"\n"<<buffer<<"\n";

//  Serial<<"I'm running\n";

  Can1.sendFrame(myVars.outFrame); //Mail it
}

void defaults() {
  myVars.CANdo = 2;
  myVars.transmitime = 500;
  myVars.logger = false;
  myVars.outFrame.length = 8;  // Data payload 8 bytes
  myVars.outFrame.rtr = 0; // Data payload 8 bytes
  myVars.goodEEPROM = 200;
  myVars.datarate = 125000; // lowest officially supported datarate for CANBus is 40kbit/sec
}
