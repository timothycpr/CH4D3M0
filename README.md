# Focus_CHAdeMO

The software and information provided here relates to hazardous and potentially deadly uses. EV batteries and DC chargers can produce hundreds of Amps of current at more than 1000 Volts, which can literally vaporise body parts. As wiser man said "Not only will this kill you, it will hurt the whole time you're dying"

Anyone that utiizes this infomration/code must assume full responsibility for their actions and ensure prudent & safe operation. While good faith effort has been made to implement safety checks and fail-safes in code and hardware, I can in no way guarantee that using this is safe.

Similarly, modification of an EV to add after-market fast charging creates the same risks to people and property. Anyone implemeting any of these methods must assume full responsibility for their actions.

I will not be held liable for the actions of others relating to any use of this code, information or hardware.

With great power comes great responsibility - and 30-50kW is a *lot* of power.

-----------

Software and hardware specs to implement CHAdeMO fast charging on early model Ford Focus EVs

This hardware and software was originally developed and implemented by "Sefs" of the MyFocusElectic forums - building a home fast charger and a means to interface it with his vehicle.

After moving on to a Model 3 with much better range, the hardware was stripped from his 2012 Focus and eventually ended up in my 2012 Focus.

This project has two primary systems - the vehicle CHAdeMO interface and the charger-side management system.

In the vehicle CHAdeMO interface, an EVTV Due is spliced into the vehicle CANBus to send/receive/process CAN data frames. The data pins from the CHAdeMO plug are routed through a separate CANBus transceiver that converts them to a TTL data stream that is fed into the EVTV Due.

Data from these two systems is then used to control a CHAdeMO charging session, ultimately connecting the vehicle HVDC bus to that of the charger.

In total, the connection requires the following physical hardware:

  1 EVTV Due (http://store.evtv.me/proddetail.php?prod=EVTVDue2) ARM-based microcontroller with CAN Tranceiver

  1 EVAL-ADM3052EBZ (https://www.digikey.com/en/products/detail/analog-devices-inc/EVAL-ADM3052EBZ/2709315) Isolated CAN Transceiver

  1 HL-52S (https://www.newegg.com/p/285-0018-000E9?item=9SIA4W246U6059) Inverting Optocoupled 5V relays

  1 PST-DC2012 (https://www.powerstream.com/DC3611.htm) or similarly capable, Fully Isolated DC/DC Converter with 12V output. (Original supply board was marked with a 5V model number - PST-DC2405 - but tested as 12V out)

  1 12V SPDT relay and socket/harness (https://www.summitracing.com/parts/via-80237)

  2 3.3V optoisolators with breakouts (https://www.sparkfun.com/products/9118)

  2 Gigavac GX14BA Sealed Contactors (350A) (https://octopart.com/gx14ba-gigavac-24213166) 12V HVDC Normally open contactors

  1 CHAdeMO inlet (https://shop.quickchargepower.com/CHAdeMO-Inlets-YazInlet.htm) with harness

  1 Optional USB passthrough connector and USB A (host) to USB B (client)

  Resistors: +/-5%; 100 Ohm, 200 Ohm, 1 KOhm, two 15 KOhm.

After validating operation, all components have been consolidated onto a single shield, minus the HVDC contactors themselves. Components for re-inverting f/g/d1/d2 have been omitted and negated in code.

In addition to those signal path components, the following physical components are utilized

  1 plastic project box with grid insert

  1 replacement TCM cover (passthrough for HVDC wiring)

  6 crimp fit ring terminals ("Cable lugs"), 6 weatherproof passthroughs

  2 8-position terminal blocks

  1 7-wire weatherproof passthrough for CHAdeMO signal wiring

  1 4-wire or 2 2-wire weatherproof passthroughs for 12V/Ground/CANH/CANL

  ~30 crimp on fork terminals
