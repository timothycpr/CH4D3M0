Public Class FFECANBUSGUI
    Dim SOCdisplayed, SOCactual, RPM, hvac, VAC, AAC, Hz, Ampacity, maxcell, mincell, throttle, acc, pwrt, brake, MPH, ChaTime, Bmode, Torque, HBattCoolIn, HBattCurr, HBattVolt, mcon, ETE, HBattTemp, power, seq, chacurrent As Decimal
    Dim dataArray() As String
    Dim TorqueInt As Integer
    Dim countup As Integer

    Private WithEvents objSerial As New System.IO.Ports.SerialPort("COM6")


    Private Sub OpenSerialButton_Click(sender As System.Object, e As System.EventArgs) Handles OpenSerialButton.Click
        objSerial.BaudRate = 115200
        objSerial.RtsEnable = True
        objSerial.Open()
        Me.Update.Enabled = True
    End Sub

    Private Sub objSerial_DataReceived(sender As Object, e As System.IO.Ports.SerialDataReceivedEventArgs) Handles objSerial.DataReceived

        dataArray = Split(objSerial.ReadLine, ";")

        SOCdisplayed = dataArray(0)
        SOCactual = dataArray(1)
        HBattCoolIn = dataArray(2)
        mcon = dataArray(3)
        HBattCurr = dataArray(4)
        HBattVolt = dataArray(5)
        ETE = dataArray(6)
        HBattTemp = dataArray(7)
        seq = dataArray(8)
        chacurrent = dataArray(9)
        Torque = dataArray(10)
        Bmode = dataArray(11)
        ChaTime = dataArray(12)
        RPM = dataArray(13)
        MPH = dataArray(14)
        throttle = dataArray(15)
        brake = dataArray(16)
        pwrt = dataArray(17)
        acc = dataArray(18)
        hvac = dataArray(19)
        VAC = dataArray(20)
        AAC = dataArray(21)
        Ampacity = dataArray(22)
        Hz = dataArray(23)
        mincell = dataArray(24)
        maxcell = dataArray(25)

    End Sub

    Private Sub CloseSerialButton_Click(sender As System.Object, e As System.EventArgs) Handles CloseSerialButton.Click
        objSerial.Close()
        Me.Update.Enabled = False
        Me.Close()


    End Sub

    Private Sub Update_Tick(sender As System.Object, e As System.EventArgs) Handles Update.Tick


        Me.SOCDisplayedCircularProgress.Value = SOCdisplayed * 10
        Me.SOCDisplayedCircularProgress.ProgressText = FormatNumber(SOCdisplayed, 1)

        If SOCdisplayed <= 10 Then
            SOCDisplayedCircularProgress.ProgressColor = Color.Red
        ElseIf SOCdisplayed > 10 And SOCdisplayed <= 25 Then
            SOCDisplayedCircularProgress.ProgressColor = Color.Yellow
        ElseIf SOCdisplayed > 25 Then
            SOCDisplayedCircularProgress.ProgressColor = Color.Green
        End If

        If VAC > 0 Or AAC > 0 Or Ampacity > 0 Or Hz > 0 Then
            Me.EVSEGroupBox.Visible = True
            Me.VACout.Text = VAC & " V"
            Me.AACout.Text = FormatNumber(AAC, 0) & " A"
            Me.AmpacityOut.Text = Math.Round(Ampacity, 0) & " A"
            Me.FrequencyOut.Text = FormatNumber(Hz, 1) & " Hz"
        Else
            Me.EVSEGroupBox.Visible = False
        End If

        If mincell > 0 And maxcell > 0 Then
            Me.MinCellOutLabel.Text = mincell
            Me.MaxCellOutLabel.Text = maxcell
            Me.MinCellOutLabel.Visible = True
            Me.MaxCellOutLabel.Visible = True
        Else
            Me.MinCellOutLabel.Visible = False
            Me.MaxCellOutLabel.Visible = False
        End If




        If ChaTime > 0 Then
            ChaTimeRemLabel.Visible = True
            ChaTimeRemOut.Visible = True
            If ChaTime = 1 Then
                ChaTimeRemOut.Text = "1 minute"
            ElseIf ChaTime > 1 Then
                ChaTimeRemOut.Text = FormatNumber(ChaTime, 0) & " minutes"
            End If
        ElseIf ChaTime = 0 Then
            ChaTimeRemLabel.Visible = False
            ChaTimeRemOut.Visible = False
        End If

        Me.MPHCircularProgress.Value = Math.Round(MPH, 0)
        Me.MPHCircularProgress.ProgressText = Math.Round(MPH, 0)

        Me.ThrottleCircularProgress.Value = throttle * 10
        Me.ThrottleCircularProgress.ProgressText = Math.Round(throttle, 0)
        If brake > 99 Then
            Me.BrakeCircularProgress.Value = 1000
            Me.BrakeCircularProgress.ProgressText = "100"
        Else
            Me.BrakeCircularProgress.Value = brake * 10
            Me.BrakeCircularProgress.ProgressText = Math.Round(brake, 0)
        End If
        

        Me.AccCircularProgress.Value = acc * 1000
        Me.AccCircularProgress.ProgressText = Math.Round(acc, 1)

        If hvac = 5 Then
            Me.HVACCircularProgress.Value = 5000
            Me.HVACCircularProgress.ProgressText = "5+"
        Else
            Me.HVACCircularProgress.Value = hvac * 1000
            If hvac < 0.1 Then
                Me.HVACCircularProgress.ProgressText = "0"
            Else
                Me.HVACCircularProgress.ProgressText = FormatNumber(hvac, 1)
            End If
        End If



        Me.SOCActualCircularProgress.Value = SOCactual * 10
        Me.SOCActualCircularProgress.ProgressText = FormatNumber(SOCactual, 1)
        Me.BattCoolInOutLabel.Text = FormatNumber(HBattCoolIn, 1) & " °F"
        If mcon = 1 Then
            Me.MConOutLabel.Text = "Closed"
        ElseIf mcon = 0 Then
            Me.MConOutLabel.Text = "Open"
        End If
        Me.CurrentOutLabel.Text = HBattCurr & " A"
        If HBattCurr < 0 Then
            If HBattCurr < -200 Then
                Me.NegCurrentProgressBar.Value = 200
            Else
                Me.NegCurrentProgressBar.Value = (HBattCurr * -1)
            End If
            Me.PosCurrentProgressBar.Value = 0
        ElseIf HBattCurr >= 0 Then
            If HBattCurr > 380 Then
                Me.PosCurrentProgressBar.Value = 380
            Else
                Me.PosCurrentProgressBar.Value = HBattCurr
            End If
            Me.NegCurrentProgressBar.Value = 0
        End If

        Me.VoltageCircularProgress.Value = (HBattVolt - 260) * 10
        Me.VoltageCircularProgress.ProgressText = FormatNumber(HBattVolt, 1)

        If pwrt >= 0 Then
            Me.PowertrainCircularProgress.Value = pwrt
            Me.PowertrainCircularProgress.ProgressText = FormatNumber(pwrt, 0)
            Me.PowertrainCircularProgress.ProgressColor = Color.FromArgb(255, 128, 0)


        ElseIf pwrt < 0 Then
            Me.PowertrainCircularProgress.Value = -pwrt
            Me.PowertrainCircularProgress.ProgressText = FormatNumber(-pwrt, 0)
            Me.PowertrainCircularProgress.ProgressColor = Color.Lime
        End If


        Me.ETECircularProgress.Value = ETE * 10
        Me.ETECircularProgress.ProgressText = FormatNumber(ETE, 1)


        Me.BattTempOutLabel.Text = FormatNumber(HBattTemp, 1) & " °F"
        power = Math.Round(HBattCurr * HBattVolt / 1000, 2)
        Me.PowerOutLabel.Text = power & " kW"



        If power > 0 Then
            Me.RegenProgressBar.Value = 0
            If power > 110 Then
                Me.PowerProgressBar.Value = 110
            Else
                Me.PowerProgressBar.Value = power
            End If
        ElseIf power = 0 Then
            Me.RegenProgressBar.Value = 0
            Me.PowerProgressBar.Value = 0
        ElseIf power < 0 Then
            If power < -60 Then
                Me.RegenProgressBar.Value = 60
            Else
                Me.RegenProgressBar.Value = -power
            End If
            Me.PowerProgressBar.Value = 0

        End If
        If seq = 0 Then
            Me.Seq0Button.Enabled = False
            Me.Seq1Button.Enabled = True
            Me.Seq2Button.Enabled = True
            Me.Seq3Button.Enabled = True
            Me.Seq4Button.Enabled = True
            Me.Seq5Button.Enabled = True
            Me.MPHCircularProgress.Visible = True
            Me.MPHLabel.Visible = True
            Me.RPMCircularProgress.Visible = True
            Me.RPMLabel.Visible = True
            Me.ChaCurrentCircularProgress.Visible = False
            Me.ChacurrentLabel.Visible = False
            Me.TorqueLabel.Visible = True
            Me.TorqueOutLabel.Visible = True
            Me.PosTorqueProgressBar.Visible = True
            Me.NegTorqueProgressBar.Visible = True
            Me.ThrottleLabel.Visible = True
            Me.ThrottleCircularProgress.Visible = True
            Me.BrakeLabel.Visible = True
            Me.BrakeCircularProgress.Visible = True
        ElseIf seq = 1 Then
            Me.Seq0Button.Enabled = True
            Me.Seq1Button.Enabled = False
            Me.Seq2Button.Enabled = True
            Me.Seq3Button.Enabled = True
            Me.Seq4Button.Enabled = True
            Me.Seq5Button.Enabled = True
            Me.MPHCircularProgress.Visible = False
            Me.MPHLabel.Visible = False
            Me.RPMCircularProgress.Visible = False
            Me.RPMLabel.Visible = False
            Me.ChaCurrentCircularProgress.Visible = True
            Me.ChacurrentLabel.Visible = True
            Me.TorqueLabel.Visible = False
            Me.TorqueOutLabel.Visible = False
            Me.PosTorqueProgressBar.Visible = False
            Me.NegTorqueProgressBar.Visible = False
            Me.ThrottleLabel.Visible = False
            Me.ThrottleCircularProgress.Visible = False
            Me.BrakeLabel.Visible = False
            Me.BrakeCircularProgress.Visible = False
        ElseIf seq = 2 Then
            Me.Seq0Button.Enabled = True
            Me.Seq1Button.Enabled = True
            Me.Seq2Button.Enabled = False
            Me.Seq3Button.Enabled = True
            Me.Seq4Button.Enabled = True
            Me.Seq5Button.Enabled = True
            Me.MPHCircularProgress.Visible = False
            Me.MPHLabel.Visible = False
            Me.RPMCircularProgress.Visible = False
            Me.RPMLabel.Visible = False
            Me.ChaCurrentCircularProgress.Visible = True
            Me.ChacurrentLabel.Visible = True
            Me.TorqueLabel.Visible = False
            Me.TorqueOutLabel.Visible = False
            Me.PosTorqueProgressBar.Visible = False
            Me.NegTorqueProgressBar.Visible = False
            Me.ThrottleLabel.Visible = False
            Me.ThrottleCircularProgress.Visible = False
            Me.BrakeLabel.Visible = False
            Me.BrakeCircularProgress.Visible = False
        ElseIf seq = 3 Then
            Me.Seq0Button.Enabled = True
            Me.Seq1Button.Enabled = True
            Me.Seq2Button.Enabled = True
            Me.Seq3Button.Enabled = False
            Me.Seq4Button.Enabled = True
            Me.Seq5Button.Enabled = True
            Me.MPHCircularProgress.Visible = False
            Me.MPHLabel.Visible = False
            Me.RPMCircularProgress.Visible = False
            Me.RPMLabel.Visible = False
            Me.ChaCurrentCircularProgress.Visible = True
            Me.ChacurrentLabel.Visible = True
            Me.TorqueLabel.Visible = False
            Me.TorqueOutLabel.Visible = False
            Me.PosTorqueProgressBar.Visible = False
            Me.NegTorqueProgressBar.Visible = False
            Me.ThrottleLabel.Visible = False
            Me.ThrottleCircularProgress.Visible = False
            Me.BrakeLabel.Visible = False
            Me.BrakeCircularProgress.Visible = False
        ElseIf seq = 4 Then
            Me.Seq0Button.Enabled = True
            Me.Seq1Button.Enabled = True
            Me.Seq2Button.Enabled = True
            Me.Seq3Button.Enabled = True
            Me.Seq4Button.Enabled = False
            Me.Seq5Button.Enabled = True
            Me.MPHCircularProgress.Visible = False
            Me.MPHLabel.Visible = False
            Me.RPMCircularProgress.Visible = False
            Me.RPMLabel.Visible = False
            Me.ChaCurrentCircularProgress.Visible = True
            Me.ChacurrentLabel.Visible = True
            Me.TorqueLabel.Visible = False
            Me.TorqueOutLabel.Visible = False
            Me.PosTorqueProgressBar.Visible = False
            Me.NegTorqueProgressBar.Visible = False
            Me.ThrottleLabel.Visible = False
            Me.ThrottleCircularProgress.Visible = False
            Me.BrakeLabel.Visible = False
            Me.BrakeCircularProgress.Visible = False
        ElseIf seq = 5 Then
            Me.Seq0Button.Enabled = True
            Me.Seq1Button.Enabled = True
            Me.Seq2Button.Enabled = True
            Me.Seq3Button.Enabled = True
            Me.Seq4Button.Enabled = True
            Me.Seq5Button.Enabled = False
            Me.MPHCircularProgress.Visible = False
            Me.MPHLabel.Visible = False
            Me.RPMCircularProgress.Visible = False
            Me.RPMLabel.Visible = False
            Me.ChaCurrentCircularProgress.Visible = True
            Me.ChacurrentLabel.Visible = True
            Me.TorqueLabel.Visible = False
            Me.TorqueOutLabel.Visible = False
            Me.PosTorqueProgressBar.Visible = False
            Me.NegTorqueProgressBar.Visible = False
            Me.ThrottleLabel.Visible = False
            Me.ThrottleCircularProgress.Visible = False
            Me.BrakeLabel.Visible = False
            Me.BrakeCircularProgress.Visible = False
        End If
        Me.ChaCurrentCircularProgress.ProgressText = FormatNumber(chacurrent, 0)
        Me.ChaCurrentCircularProgress.Value = chacurrent
        TorqueInt = Math.Round(Torque, 0)

        Me.RPMCircularProgress.Value = Math.Abs(Math.Round(RPM, 0))
        Me.RPMCircularProgress.ProgressText = Math.Round(RPM, 0)


        If TorqueInt >= 0 Then
            Me.PosTorqueProgressBar.Value = TorqueInt
            Me.NegTorqueProgressBar.Value = 0
        ElseIf TorqueInt < 0 Then
            Me.PosTorqueProgressBar.Value = 0
            Me.NegTorqueProgressBar.Value = (TorqueInt * -1)
        End If

        Me.TorqueOutLabel.Text = Format(Torque, 0) & " lb•ft"
        If Bmode = 0 Then
            Me.BmodeOutLabel.Text = " "
            Me.BmodeOutLabel.BackColor = Color.Transparent
        ElseIf Bmode = 1 Then
            Me.BmodeOutLabel.Text = "Regen"
            Me.BmodeOutLabel.BackColor = Color.Green
        ElseIf Bmode = 2 Then
            Me.BmodeOutLabel.Text = "Blended"
            Me.BmodeOutLabel.BackColor = Color.Orange
        ElseIf Bmode = 3 Then
            Me.BmodeOutLabel.Text = "Friction"
            Me.BmodeOutLabel.BackColor = Color.Red
        End If
    End Sub


    Private Sub Seq0Button_Click(sender As System.Object, e As System.EventArgs) Handles Seq0Button.Click
        objSerial.WriteLine("0")
    End Sub

    Private Sub Seq1Button_Click(sender As System.Object, e As System.EventArgs) Handles Seq1Button.Click
        objSerial.WriteLine("1")
    End Sub

    Private Sub Seq2Button_Click(sender As System.Object, e As System.EventArgs) Handles Seq2Button.Click
        objSerial.WriteLine("2")
    End Sub

    Private Sub Seq3Button_Click(sender As System.Object, e As System.EventArgs) Handles Seq3Button.Click
        objSerial.WriteLine("3")
    End Sub

    Private Sub Seq4Button_Click(sender As System.Object, e As System.EventArgs) Handles Seq4Button.Click
        objSerial.WriteLine("4")
    End Sub

    Private Sub Seq5Button_Click(sender As System.Object, e As System.EventArgs) Handles Seq5Button.Click
        objSerial.WriteLine("5")
    End Sub

    Private Sub UpButton_Click(sender As System.Object, e As System.EventArgs) Handles UpButton.Click
        If chacurrent < 125 Then
            objSerial.WriteLine("xxxx=" & (chacurrent + 1))
        End If
    End Sub

    Private Sub DownButton_Click(sender As System.Object, e As System.EventArgs) Handles DownButton.Click
        If chacurrent > 0 Then
            objSerial.WriteLine("xxxx=" & (chacurrent - 1))
        End If
    End Sub

    Private Sub EStopButton_Click(sender As System.Object, e As System.EventArgs) Handles EStopButton.Click
        objSerial.WriteLine("0")
        objSerial.WriteLine("xxxx=" & 0)
    End Sub

    Private Sub TenUpButton_Click(sender As System.Object, e As System.EventArgs) Handles TenUpButton.Click
        If chacurrent <= 115 Then
            objSerial.WriteLine("xxxx=" & (chacurrent + 10))
        End If
    End Sub

    Private Sub TenDownButton_Click(sender As System.Object, e As System.EventArgs) Handles TenDownButton.Click
        If chacurrent >= 10 Then
            objSerial.WriteLine("xxxx=" & (chacurrent - 10))
        End If
    End Sub




    Private Sub Startup_Tick(sender As System.Object, e As System.EventArgs) Handles Startup.Tick
        objSerial.BaudRate = 115200
        objSerial.RtsEnable = True
        objSerial.Open()

        Me.Update.Enabled = True
        Me.Startup.Enabled = False

        Cursor.Hide()
    End Sub



    Private Sub StopButton_Click(sender As System.Object, e As System.EventArgs) Handles StopButton.Click
        objSerial.WriteLine("9")
    End Sub




    Private Sub SixButton_Click(sender As System.Object, e As System.EventArgs) Handles SixButton.Click
        objSerial.WriteLine("6")
    End Sub

    Private Sub SevenButton_Click(sender As System.Object, e As System.EventArgs) Handles SevenButton.Click
        objSerial.WriteLine("7")
    End Sub

 
End Class

Public Class VerticalProgressBar
    Inherits ProgressBar
    Protected Overloads Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Dim cp As CreateParams = MyBase.CreateParams
            cp.Style = cp.Style Or &H4
            Return cp
        End Get
    End Property
End Class