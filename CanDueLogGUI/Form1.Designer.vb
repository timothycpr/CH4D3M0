<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FFECANBUSGUI
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FFECANBUSGUI))
        Me.SOCDisplayedLabel = New System.Windows.Forms.Label()
        Me.OpenSerialButton = New System.Windows.Forms.Button()
        Me.CloseSerialButton = New System.Windows.Forms.Button()
        Me.Update = New System.Windows.Forms.Timer(Me.components)
        Me.SOCActualLabel = New System.Windows.Forms.Label()
        Me.RegenProgressBar = New System.Windows.Forms.ProgressBar()
        Me.PowerOutLabel = New System.Windows.Forms.Label()
        Me.PowerLabel = New System.Windows.Forms.Label()
        Me.CurrentLabel = New System.Windows.Forms.Label()
        Me.VoltageLabel = New System.Windows.Forms.Label()
        Me.BattCoolInOutLabel = New System.Windows.Forms.Label()
        Me.BattCoolInLabel = New System.Windows.Forms.Label()
        Me.MConOutLabel = New System.Windows.Forms.Label()
        Me.MConLabel = New System.Windows.Forms.Label()
        Me.ETELabel = New System.Windows.Forms.Label()
        Me.BattTempOutLabel = New System.Windows.Forms.Label()
        Me.BattTempLabel = New System.Windows.Forms.Label()
        Me.PowerProgressBar = New System.Windows.Forms.ProgressBar()
        Me.Seq0Button = New System.Windows.Forms.Button()
        Me.Seq1Button = New System.Windows.Forms.Button()
        Me.Seq2Button = New System.Windows.Forms.Button()
        Me.Seq3Button = New System.Windows.Forms.Button()
        Me.Seq4Button = New System.Windows.Forms.Button()
        Me.Seq5Button = New System.Windows.Forms.Button()
        Me.ChacurrentLabel = New System.Windows.Forms.Label()
        Me.DownButton = New System.Windows.Forms.Button()
        Me.UpButton = New System.Windows.Forms.Button()
        Me.EStopButton = New System.Windows.Forms.Button()
        Me.TenUpButton = New System.Windows.Forms.Button()
        Me.TenDownButton = New System.Windows.Forms.Button()
        Me.BmodeOutLabel = New System.Windows.Forms.Label()
        Me.BmodeLabel = New System.Windows.Forms.Label()
        Me.TorqueOutLabel = New System.Windows.Forms.Label()
        Me.TorqueLabel = New System.Windows.Forms.Label()
        Me.Startup = New System.Windows.Forms.Timer(Me.components)
        Me.SOCDisplayedCircularProgress = New DevComponents.DotNetBar.Controls.CircularProgress()
        Me.SOCActualCircularProgress = New DevComponents.DotNetBar.Controls.CircularProgress()
        Me.ETECircularProgress = New DevComponents.DotNetBar.Controls.CircularProgress()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ChaCurrentCircularProgress = New DevComponents.DotNetBar.Controls.CircularProgress()
        Me.VoltageCircularProgress = New DevComponents.DotNetBar.Controls.CircularProgress()
        Me.CurrentOutLabel = New System.Windows.Forms.Label()
        Me.PosCurrentProgressBar = New System.Windows.Forms.ProgressBar()
        Me.NegCurrentProgressBar = New System.Windows.Forms.ProgressBar()
        Me.PosTorqueProgressBar = New System.Windows.Forms.ProgressBar()
        Me.NegTorqueProgressBar = New System.Windows.Forms.ProgressBar()
        Me.StopButton = New System.Windows.Forms.Button()
        Me.ChaTimeRemLabel = New System.Windows.Forms.Label()
        Me.ChaTimeRemOut = New System.Windows.Forms.Label()
        Me.MPHLabel = New System.Windows.Forms.Label()
        Me.MPHCircularProgress = New DevComponents.DotNetBar.Controls.CircularProgress()
        Me.RPMLabel = New System.Windows.Forms.Label()
        Me.RPMCircularProgress = New DevComponents.DotNetBar.Controls.CircularProgress()
        Me.ThrottleCircularProgress = New DevComponents.DotNetBar.Controls.CircularProgress()
        Me.ThrottleLabel = New System.Windows.Forms.Label()
        Me.BrakeLabel = New System.Windows.Forms.Label()
        Me.BrakeCircularProgress = New DevComponents.DotNetBar.Controls.CircularProgress()
        Me.PowertrainLabel = New System.Windows.Forms.Label()
        Me.HVACLabel = New System.Windows.Forms.Label()
        Me.HVACCircularProgress = New DevComponents.DotNetBar.Controls.CircularProgress()
        Me.AccLabel = New System.Windows.Forms.Label()
        Me.AccCircularProgress = New DevComponents.DotNetBar.Controls.CircularProgress()
        Me.PowertrainCircularProgress = New DevComponents.DotNetBar.Controls.CircularProgress()
        Me.EVSEGroupBox = New System.Windows.Forms.GroupBox()
        Me.FrequencyOut = New System.Windows.Forms.Label()
        Me.FrequencyLabel = New System.Windows.Forms.Label()
        Me.AmpacityOut = New System.Windows.Forms.Label()
        Me.AmpacityLabel = New System.Windows.Forms.Label()
        Me.AACout = New System.Windows.Forms.Label()
        Me.AACLabel = New System.Windows.Forms.Label()
        Me.VACout = New System.Windows.Forms.Label()
        Me.VACLabel = New System.Windows.Forms.Label()
        Me.SixButton = New System.Windows.Forms.Button()
        Me.MaxCellOutLabel = New System.Windows.Forms.Label()
        Me.MinCellOutLabel = New System.Windows.Forms.Label()
        Me.SevenButton = New System.Windows.Forms.Button()
        Me.EVSEGroupBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'SOCDisplayedLabel
        '
        Me.SOCDisplayedLabel.AutoSize = True
        Me.SOCDisplayedLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SOCDisplayedLabel.Location = New System.Drawing.Point(25, 255)
        Me.SOCDisplayedLabel.Name = "SOCDisplayedLabel"
        Me.SOCDisplayedLabel.Size = New System.Drawing.Size(146, 50)
        Me.SOCDisplayedLabel.TabIndex = 1
        Me.SOCDisplayedLabel.Text = "SOC" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Displayed (%)"
        Me.SOCDisplayedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'OpenSerialButton
        '
        Me.OpenSerialButton.Location = New System.Drawing.Point(319, 28)
        Me.OpenSerialButton.Name = "OpenSerialButton"
        Me.OpenSerialButton.Size = New System.Drawing.Size(72, 34)
        Me.OpenSerialButton.TabIndex = 2
        Me.OpenSerialButton.Text = "&Open Serial"
        Me.OpenSerialButton.UseVisualStyleBackColor = True
        '
        'CloseSerialButton
        '
        Me.CloseSerialButton.Location = New System.Drawing.Point(457, 28)
        Me.CloseSerialButton.Name = "CloseSerialButton"
        Me.CloseSerialButton.Size = New System.Drawing.Size(72, 34)
        Me.CloseSerialButton.TabIndex = 3
        Me.CloseSerialButton.Text = "&Close Serial"
        Me.CloseSerialButton.UseVisualStyleBackColor = True
        '
        'Update
        '
        '
        'SOCActualLabel
        '
        Me.SOCActualLabel.AutoSize = True
        Me.SOCActualLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SOCActualLabel.Location = New System.Drawing.Point(157, 364)
        Me.SOCActualLabel.Name = "SOCActualLabel"
        Me.SOCActualLabel.Size = New System.Drawing.Size(111, 50)
        Me.SOCActualLabel.TabIndex = 7
        Me.SOCActualLabel.Text = "SOC" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Actual (%)"
        Me.SOCActualLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'RegenProgressBar
        '
        Me.RegenProgressBar.ForeColor = System.Drawing.Color.Lime
        Me.RegenProgressBar.Location = New System.Drawing.Point(13, 71)
        Me.RegenProgressBar.Maximum = 60
        Me.RegenProgressBar.Name = "RegenProgressBar"
        Me.RegenProgressBar.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RegenProgressBar.RightToLeftLayout = True
        Me.RegenProgressBar.Size = New System.Drawing.Size(268, 18)
        Me.RegenProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.RegenProgressBar.TabIndex = 0
        Me.RegenProgressBar.Value = 20
        '
        'PowerOutLabel
        '
        Me.PowerOutLabel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PowerOutLabel.AutoSize = True
        Me.PowerOutLabel.BackColor = System.Drawing.Color.Transparent
        Me.PowerOutLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PowerOutLabel.Location = New System.Drawing.Point(622, 31)
        Me.PowerOutLabel.Name = "PowerOutLabel"
        Me.PowerOutLabel.Size = New System.Drawing.Size(150, 39)
        Me.PowerOutLabel.TabIndex = 10
        Me.PowerOutLabel.Text = "XX.XX%"
        Me.PowerOutLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PowerLabel
        '
        Me.PowerLabel.AutoSize = True
        Me.PowerLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PowerLabel.Location = New System.Drawing.Point(96, 31)
        Me.PowerLabel.Name = "PowerLabel"
        Me.PowerLabel.Size = New System.Drawing.Size(115, 39)
        Me.PowerLabel.TabIndex = 9
        Me.PowerLabel.Text = "Power"
        '
        'CurrentLabel
        '
        Me.CurrentLabel.AutoSize = True
        Me.CurrentLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CurrentLabel.Location = New System.Drawing.Point(322, 102)
        Me.CurrentLabel.Name = "CurrentLabel"
        Me.CurrentLabel.Size = New System.Drawing.Size(133, 39)
        Me.CurrentLabel.TabIndex = 13
        Me.CurrentLabel.Text = "Current"
        '
        'VoltageLabel
        '
        Me.VoltageLabel.AutoSize = True
        Me.VoltageLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.VoltageLabel.Location = New System.Drawing.Point(184, 93)
        Me.VoltageLabel.Name = "VoltageLabel"
        Me.VoltageLabel.Size = New System.Drawing.Size(132, 29)
        Me.VoltageLabel.TabIndex = 11
        Me.VoltageLabel.Text = "Voltage (V)"
        '
        'BattCoolInOutLabel
        '
        Me.BattCoolInOutLabel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BattCoolInOutLabel.AutoSize = True
        Me.BattCoolInOutLabel.BackColor = System.Drawing.Color.Transparent
        Me.BattCoolInOutLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BattCoolInOutLabel.Location = New System.Drawing.Point(646, 531)
        Me.BattCoolInOutLabel.Name = "BattCoolInOutLabel"
        Me.BattCoolInOutLabel.Size = New System.Drawing.Size(118, 31)
        Me.BattCoolInOutLabel.TabIndex = 16
        Me.BattCoolInOutLabel.Text = "XX.XX%"
        Me.BattCoolInOutLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'BattCoolInLabel
        '
        Me.BattCoolInLabel.AutoSize = True
        Me.BattCoolInLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BattCoolInLabel.Location = New System.Drawing.Point(519, 531)
        Me.BattCoolInLabel.Name = "BattCoolInLabel"
        Me.BattCoolInLabel.Size = New System.Drawing.Size(136, 31)
        Me.BattCoolInLabel.TabIndex = 15
        Me.BattCoolInLabel.Text = "BC Temp:"
        '
        'MConOutLabel
        '
        Me.MConOutLabel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.MConOutLabel.AutoSize = True
        Me.MConOutLabel.BackColor = System.Drawing.Color.Transparent
        Me.MConOutLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MConOutLabel.Location = New System.Drawing.Point(124, 531)
        Me.MConOutLabel.Name = "MConOutLabel"
        Me.MConOutLabel.Size = New System.Drawing.Size(118, 31)
        Me.MConOutLabel.TabIndex = 18
        Me.MConOutLabel.Text = "XX.XX%"
        Me.MConOutLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'MConLabel
        '
        Me.MConLabel.AutoSize = True
        Me.MConLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MConLabel.Location = New System.Drawing.Point(42, 531)
        Me.MConLabel.Name = "MConLabel"
        Me.MConLabel.Size = New System.Drawing.Size(88, 31)
        Me.MConLabel.TabIndex = 17
        Me.MConLabel.Text = "Mcon:"
        '
        'ETELabel
        '
        Me.ETELabel.AutoSize = True
        Me.ETELabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ETELabel.Location = New System.Drawing.Point(292, 255)
        Me.ETELabel.Name = "ETELabel"
        Me.ETELabel.Size = New System.Drawing.Size(69, 50)
        Me.ETELabel.TabIndex = 19
        Me.ETELabel.Text = "ETE" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(kWh)"
        Me.ETELabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BattTempOutLabel
        '
        Me.BattTempOutLabel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BattTempOutLabel.AutoSize = True
        Me.BattTempOutLabel.BackColor = System.Drawing.Color.Transparent
        Me.BattTempOutLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BattTempOutLabel.Location = New System.Drawing.Point(384, 531)
        Me.BattTempOutLabel.Name = "BattTempOutLabel"
        Me.BattTempOutLabel.Size = New System.Drawing.Size(118, 31)
        Me.BattTempOutLabel.TabIndex = 22
        Me.BattTempOutLabel.Text = "XX.XX%"
        Me.BattTempOutLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'BattTempLabel
        '
        Me.BattTempLabel.AutoSize = True
        Me.BattTempLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BattTempLabel.Location = New System.Drawing.Point(275, 531)
        Me.BattTempLabel.Name = "BattTempLabel"
        Me.BattTempLabel.Size = New System.Drawing.Size(116, 31)
        Me.BattTempLabel.TabIndex = 21
        Me.BattTempLabel.Text = "B Temp:"
        '
        'PowerProgressBar
        '
        Me.PowerProgressBar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.PowerProgressBar.Location = New System.Drawing.Point(281, 71)
        Me.PowerProgressBar.MarqueeAnimationSpeed = 10
        Me.PowerProgressBar.Maximum = 110
        Me.PowerProgressBar.Name = "PowerProgressBar"
        Me.PowerProgressBar.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.PowerProgressBar.Size = New System.Drawing.Size(491, 18)
        Me.PowerProgressBar.Step = 0
        Me.PowerProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.PowerProgressBar.TabIndex = 23
        Me.PowerProgressBar.Value = 20
        '
        'Seq0Button
        '
        Me.Seq0Button.Location = New System.Drawing.Point(265, 26)
        Me.Seq0Button.Name = "Seq0Button"
        Me.Seq0Button.Size = New System.Drawing.Size(48, 34)
        Me.Seq0Button.TabIndex = 28
        Me.Seq0Button.Text = "Seq &0"
        Me.Seq0Button.UseVisualStyleBackColor = True
        '
        'Seq1Button
        '
        Me.Seq1Button.Location = New System.Drawing.Point(319, 26)
        Me.Seq1Button.Name = "Seq1Button"
        Me.Seq1Button.Size = New System.Drawing.Size(48, 34)
        Me.Seq1Button.TabIndex = 29
        Me.Seq1Button.Text = "Seq &1"
        Me.Seq1Button.UseVisualStyleBackColor = True
        '
        'Seq2Button
        '
        Me.Seq2Button.Location = New System.Drawing.Point(373, 26)
        Me.Seq2Button.Name = "Seq2Button"
        Me.Seq2Button.Size = New System.Drawing.Size(48, 34)
        Me.Seq2Button.TabIndex = 30
        Me.Seq2Button.Text = "Seq &2"
        Me.Seq2Button.UseVisualStyleBackColor = True
        '
        'Seq3Button
        '
        Me.Seq3Button.Location = New System.Drawing.Point(418, 26)
        Me.Seq3Button.Name = "Seq3Button"
        Me.Seq3Button.Size = New System.Drawing.Size(48, 34)
        Me.Seq3Button.TabIndex = 31
        Me.Seq3Button.Text = "Seq &3"
        Me.Seq3Button.UseVisualStyleBackColor = True
        '
        'Seq4Button
        '
        Me.Seq4Button.Location = New System.Drawing.Point(481, 26)
        Me.Seq4Button.Name = "Seq4Button"
        Me.Seq4Button.Size = New System.Drawing.Size(48, 34)
        Me.Seq4Button.TabIndex = 32
        Me.Seq4Button.Text = "Seq &4"
        Me.Seq4Button.UseVisualStyleBackColor = True
        '
        'Seq5Button
        '
        Me.Seq5Button.Location = New System.Drawing.Point(535, 26)
        Me.Seq5Button.Name = "Seq5Button"
        Me.Seq5Button.Size = New System.Drawing.Size(48, 34)
        Me.Seq5Button.TabIndex = 33
        Me.Seq5Button.Text = "Seq &5"
        Me.Seq5Button.UseVisualStyleBackColor = True
        '
        'ChacurrentLabel
        '
        Me.ChacurrentLabel.AutoSize = True
        Me.ChacurrentLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChacurrentLabel.Location = New System.Drawing.Point(489, 284)
        Me.ChacurrentLabel.Name = "ChacurrentLabel"
        Me.ChacurrentLabel.Size = New System.Drawing.Size(129, 58)
        Me.ChacurrentLabel.TabIndex = 34
        Me.ChacurrentLabel.Text = "Chademo" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Current (A)"
        Me.ChacurrentLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'DownButton
        '
        Me.DownButton.Location = New System.Drawing.Point(376, 0)
        Me.DownButton.Name = "DownButton"
        Me.DownButton.Size = New System.Drawing.Size(64, 29)
        Me.DownButton.TabIndex = 38
        Me.DownButton.Text = "&Down"
        Me.DownButton.UseVisualStyleBackColor = True
        '
        'UpButton
        '
        Me.UpButton.Location = New System.Drawing.Point(319, 0)
        Me.UpButton.Name = "UpButton"
        Me.UpButton.Size = New System.Drawing.Size(64, 29)
        Me.UpButton.TabIndex = 37
        Me.UpButton.Text = "&Up"
        Me.UpButton.UseVisualStyleBackColor = True
        '
        'EStopButton
        '
        Me.EStopButton.BackColor = System.Drawing.Color.Red
        Me.EStopButton.Location = New System.Drawing.Point(493, -2)
        Me.EStopButton.Name = "EStopButton"
        Me.EStopButton.Size = New System.Drawing.Size(64, 32)
        Me.EStopButton.TabIndex = 39
        Me.EStopButton.Text = "&E STOP"
        Me.EStopButton.UseVisualStyleBackColor = False
        '
        'TenUpButton
        '
        Me.TenUpButton.Location = New System.Drawing.Point(265, 0)
        Me.TenUpButton.Name = "TenUpButton"
        Me.TenUpButton.Size = New System.Drawing.Size(64, 29)
        Me.TenUpButton.TabIndex = 40
        Me.TenUpButton.Text = "10 U&p"
        Me.TenUpButton.UseVisualStyleBackColor = True
        '
        'TenDownButton
        '
        Me.TenDownButton.Location = New System.Drawing.Point(436, 0)
        Me.TenDownButton.Name = "TenDownButton"
        Me.TenDownButton.Size = New System.Drawing.Size(64, 29)
        Me.TenDownButton.TabIndex = 41
        Me.TenDownButton.Text = "10 Dow&n"
        Me.TenDownButton.UseVisualStyleBackColor = True
        '
        'BmodeOutLabel
        '
        Me.BmodeOutLabel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BmodeOutLabel.AutoSize = True
        Me.BmodeOutLabel.BackColor = System.Drawing.Color.Transparent
        Me.BmodeOutLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BmodeOutLabel.Location = New System.Drawing.Point(29, 184)
        Me.BmodeOutLabel.Name = "BmodeOutLabel"
        Me.BmodeOutLabel.Size = New System.Drawing.Size(132, 39)
        Me.BmodeOutLabel.TabIndex = 43
        Me.BmodeOutLabel.Text = "Friction"
        Me.BmodeOutLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'BmodeLabel
        '
        Me.BmodeLabel.AutoSize = True
        Me.BmodeLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BmodeLabel.Location = New System.Drawing.Point(28, 93)
        Me.BmodeLabel.Name = "BmodeLabel"
        Me.BmodeLabel.Size = New System.Drawing.Size(135, 78)
        Me.BmodeLabel.TabIndex = 42
        Me.BmodeLabel.Text = "Braking" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Mode"
        Me.BmodeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TorqueOutLabel
        '
        Me.TorqueOutLabel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TorqueOutLabel.AutoSize = True
        Me.TorqueOutLabel.BackColor = System.Drawing.Color.Transparent
        Me.TorqueOutLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TorqueOutLabel.Location = New System.Drawing.Point(622, 187)
        Me.TorqueOutLabel.Name = "TorqueOutLabel"
        Me.TorqueOutLabel.Size = New System.Drawing.Size(150, 39)
        Me.TorqueOutLabel.TabIndex = 45
        Me.TorqueOutLabel.Text = "XX.XX%"
        Me.TorqueOutLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TorqueLabel
        '
        Me.TorqueLabel.AutoSize = True
        Me.TorqueLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TorqueLabel.Location = New System.Drawing.Point(322, 187)
        Me.TorqueLabel.Name = "TorqueLabel"
        Me.TorqueLabel.Size = New System.Drawing.Size(126, 39)
        Me.TorqueLabel.TabIndex = 44
        Me.TorqueLabel.Text = "Torque"
        '
        'Startup
        '
        Me.Startup.Enabled = True
        Me.Startup.Interval = 2000
        '
        'SOCDisplayedCircularProgress
        '
        Me.SOCDisplayedCircularProgress.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.SOCDisplayedCircularProgress.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.SOCDisplayedCircularProgress.Location = New System.Drawing.Point(43, 306)
        Me.SOCDisplayedCircularProgress.Maximum = 1000
        Me.SOCDisplayedCircularProgress.Name = "SOCDisplayedCircularProgress"
        Me.SOCDisplayedCircularProgress.ProgressBarType = DevComponents.DotNetBar.eCircularProgressType.Donut
        Me.SOCDisplayedCircularProgress.ProgressText = "XX.X"
        Me.SOCDisplayedCircularProgress.ProgressTextColor = System.Drawing.Color.White
        Me.SOCDisplayedCircularProgress.ProgressTextFormat = ""
        Me.SOCDisplayedCircularProgress.ProgressTextVisible = True
        Me.SOCDisplayedCircularProgress.Size = New System.Drawing.Size(110, 113)
        Me.SOCDisplayedCircularProgress.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP
        Me.SOCDisplayedCircularProgress.TabIndex = 49
        Me.SOCDisplayedCircularProgress.Value = 1000
        '
        'SOCActualCircularProgress
        '
        Me.SOCActualCircularProgress.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.SOCActualCircularProgress.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.SOCActualCircularProgress.Location = New System.Drawing.Point(157, 415)
        Me.SOCActualCircularProgress.Maximum = 1000
        Me.SOCActualCircularProgress.Name = "SOCActualCircularProgress"
        Me.SOCActualCircularProgress.ProgressBarType = DevComponents.DotNetBar.eCircularProgressType.Donut
        Me.SOCActualCircularProgress.ProgressColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.SOCActualCircularProgress.ProgressText = "XX.X"
        Me.SOCActualCircularProgress.ProgressTextColor = System.Drawing.Color.White
        Me.SOCActualCircularProgress.ProgressTextFormat = ""
        Me.SOCActualCircularProgress.ProgressTextVisible = True
        Me.SOCActualCircularProgress.Size = New System.Drawing.Size(110, 113)
        Me.SOCActualCircularProgress.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP
        Me.SOCActualCircularProgress.TabIndex = 50
        Me.SOCActualCircularProgress.Value = 1000
        '
        'ETECircularProgress
        '
        Me.ETECircularProgress.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.ETECircularProgress.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ETECircularProgress.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ETECircularProgress.Location = New System.Drawing.Point(271, 306)
        Me.ETECircularProgress.Maximum = 200
        Me.ETECircularProgress.Name = "ETECircularProgress"
        Me.ETECircularProgress.ProgressBarType = DevComponents.DotNetBar.eCircularProgressType.Donut
        Me.ETECircularProgress.ProgressColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ETECircularProgress.ProgressText = "19.1"
        Me.ETECircularProgress.ProgressTextColor = System.Drawing.Color.White
        Me.ETECircularProgress.ProgressTextFormat = ""
        Me.ETECircularProgress.ProgressTextVisible = True
        Me.ETECircularProgress.Size = New System.Drawing.Size(110, 113)
        Me.ETECircularProgress.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP
        Me.ETECircularProgress.TabIndex = 51
        Me.ETECircularProgress.Value = 200
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(258, -1)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(343, 68)
        Me.Label1.TabIndex = 52
        '
        'ChaCurrentCircularProgress
        '
        Me.ChaCurrentCircularProgress.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.ChaCurrentCircularProgress.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ChaCurrentCircularProgress.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChaCurrentCircularProgress.Location = New System.Drawing.Point(457, 345)
        Me.ChaCurrentCircularProgress.Maximum = 125
        Me.ChaCurrentCircularProgress.Name = "ChaCurrentCircularProgress"
        Me.ChaCurrentCircularProgress.ProgressBarType = DevComponents.DotNetBar.eCircularProgressType.Donut
        Me.ChaCurrentCircularProgress.ProgressColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ChaCurrentCircularProgress.ProgressText = "125"
        Me.ChaCurrentCircularProgress.ProgressTextColor = System.Drawing.Color.White
        Me.ChaCurrentCircularProgress.ProgressTextFormat = ""
        Me.ChaCurrentCircularProgress.ProgressTextVisible = True
        Me.ChaCurrentCircularProgress.Size = New System.Drawing.Size(198, 145)
        Me.ChaCurrentCircularProgress.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP
        Me.ChaCurrentCircularProgress.TabIndex = 53
        Me.ChaCurrentCircularProgress.Value = 125
        '
        'VoltageCircularProgress
        '
        Me.VoltageCircularProgress.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.VoltageCircularProgress.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.VoltageCircularProgress.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.VoltageCircularProgress.Location = New System.Drawing.Point(151, 125)
        Me.VoltageCircularProgress.Maximum = 1000
        Me.VoltageCircularProgress.Name = "VoltageCircularProgress"
        Me.VoltageCircularProgress.ProgressBarType = DevComponents.DotNetBar.eCircularProgressType.Donut
        Me.VoltageCircularProgress.ProgressColor = System.Drawing.Color.CornflowerBlue
        Me.VoltageCircularProgress.ProgressText = "345.5"
        Me.VoltageCircularProgress.ProgressTextColor = System.Drawing.Color.White
        Me.VoltageCircularProgress.ProgressTextFormat = ""
        Me.VoltageCircularProgress.ProgressTextVisible = True
        Me.VoltageCircularProgress.Size = New System.Drawing.Size(198, 145)
        Me.VoltageCircularProgress.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP
        Me.VoltageCircularProgress.TabIndex = 54
        Me.VoltageCircularProgress.Value = 900
        '
        'CurrentOutLabel
        '
        Me.CurrentOutLabel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CurrentOutLabel.AutoSize = True
        Me.CurrentOutLabel.BackColor = System.Drawing.Color.Transparent
        Me.CurrentOutLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CurrentOutLabel.Location = New System.Drawing.Point(622, 102)
        Me.CurrentOutLabel.Name = "CurrentOutLabel"
        Me.CurrentOutLabel.Size = New System.Drawing.Size(150, 39)
        Me.CurrentOutLabel.TabIndex = 14
        Me.CurrentOutLabel.Text = "XX.XX%"
        Me.CurrentOutLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PosCurrentProgressBar
        '
        Me.PosCurrentProgressBar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.PosCurrentProgressBar.Location = New System.Drawing.Point(481, 144)
        Me.PosCurrentProgressBar.MarqueeAnimationSpeed = 10
        Me.PosCurrentProgressBar.Maximum = 380
        Me.PosCurrentProgressBar.Name = "PosCurrentProgressBar"
        Me.PosCurrentProgressBar.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.PosCurrentProgressBar.Size = New System.Drawing.Size(291, 18)
        Me.PosCurrentProgressBar.Step = 0
        Me.PosCurrentProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.PosCurrentProgressBar.TabIndex = 56
        Me.PosCurrentProgressBar.Value = 20
        '
        'NegCurrentProgressBar
        '
        Me.NegCurrentProgressBar.ForeColor = System.Drawing.Color.Lime
        Me.NegCurrentProgressBar.Location = New System.Drawing.Point(329, 144)
        Me.NegCurrentProgressBar.Maximum = 200
        Me.NegCurrentProgressBar.Name = "NegCurrentProgressBar"
        Me.NegCurrentProgressBar.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.NegCurrentProgressBar.RightToLeftLayout = True
        Me.NegCurrentProgressBar.Size = New System.Drawing.Size(152, 18)
        Me.NegCurrentProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.NegCurrentProgressBar.TabIndex = 55
        Me.NegCurrentProgressBar.Value = 20
        '
        'PosTorqueProgressBar
        '
        Me.PosTorqueProgressBar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.PosTorqueProgressBar.Location = New System.Drawing.Point(550, 229)
        Me.PosTorqueProgressBar.MarqueeAnimationSpeed = 10
        Me.PosTorqueProgressBar.Maximum = 190
        Me.PosTorqueProgressBar.Name = "PosTorqueProgressBar"
        Me.PosTorqueProgressBar.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.PosTorqueProgressBar.Size = New System.Drawing.Size(222, 18)
        Me.PosTorqueProgressBar.Step = 0
        Me.PosTorqueProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.PosTorqueProgressBar.TabIndex = 58
        Me.PosTorqueProgressBar.Value = 20
        '
        'NegTorqueProgressBar
        '
        Me.NegTorqueProgressBar.ForeColor = System.Drawing.Color.Lime
        Me.NegTorqueProgressBar.Location = New System.Drawing.Point(329, 229)
        Me.NegTorqueProgressBar.Maximum = 190
        Me.NegTorqueProgressBar.Name = "NegTorqueProgressBar"
        Me.NegTorqueProgressBar.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.NegTorqueProgressBar.RightToLeftLayout = True
        Me.NegTorqueProgressBar.Size = New System.Drawing.Size(221, 18)
        Me.NegTorqueProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.NegTorqueProgressBar.TabIndex = 57
        Me.NegTorqueProgressBar.Value = 20
        '
        'StopButton
        '
        Me.StopButton.BackColor = System.Drawing.Color.Red
        Me.StopButton.Location = New System.Drawing.Point(391, 28)
        Me.StopButton.Name = "StopButton"
        Me.StopButton.Size = New System.Drawing.Size(64, 32)
        Me.StopButton.TabIndex = 59
        Me.StopButton.Text = "&Stop"
        Me.StopButton.UseVisualStyleBackColor = False
        '
        'ChaTimeRemLabel
        '
        Me.ChaTimeRemLabel.AutoSize = True
        Me.ChaTimeRemLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChaTimeRemLabel.Location = New System.Drawing.Point(335, 184)
        Me.ChaTimeRemLabel.Name = "ChaTimeRemLabel"
        Me.ChaTimeRemLabel.Size = New System.Drawing.Size(429, 39)
        Me.ChaTimeRemLabel.TabIndex = 60
        Me.ChaTimeRemLabel.Text = "Chademo Time Remaining"
        Me.ChaTimeRemLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ChaTimeRemOut
        '
        Me.ChaTimeRemOut.AutoSize = True
        Me.ChaTimeRemOut.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChaTimeRemOut.Location = New System.Drawing.Point(468, 231)
        Me.ChaTimeRemOut.Name = "ChaTimeRemOut"
        Me.ChaTimeRemOut.Size = New System.Drawing.Size(187, 39)
        Me.ChaTimeRemOut.TabIndex = 61
        Me.ChaTimeRemOut.Text = "10 minutes"
        Me.ChaTimeRemOut.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'MPHLabel
        '
        Me.MPHLabel.AutoSize = True
        Me.MPHLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MPHLabel.Location = New System.Drawing.Point(448, 300)
        Me.MPHLabel.Name = "MPHLabel"
        Me.MPHLabel.Size = New System.Drawing.Size(66, 29)
        Me.MPHLabel.TabIndex = 62
        Me.MPHLabel.Text = "MPH"
        '
        'MPHCircularProgress
        '
        Me.MPHCircularProgress.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.MPHCircularProgress.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.MPHCircularProgress.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MPHCircularProgress.Location = New System.Drawing.Point(382, 332)
        Me.MPHCircularProgress.Maximum = 90
        Me.MPHCircularProgress.Name = "MPHCircularProgress"
        Me.MPHCircularProgress.ProgressBarType = DevComponents.DotNetBar.eCircularProgressType.Donut
        Me.MPHCircularProgress.ProgressColor = System.Drawing.Color.Red
        Me.MPHCircularProgress.ProgressText = "345.5"
        Me.MPHCircularProgress.ProgressTextColor = System.Drawing.Color.White
        Me.MPHCircularProgress.ProgressTextFormat = ""
        Me.MPHCircularProgress.ProgressTextVisible = True
        Me.MPHCircularProgress.Size = New System.Drawing.Size(198, 145)
        Me.MPHCircularProgress.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP
        Me.MPHCircularProgress.TabIndex = 63
        Me.MPHCircularProgress.Value = 90
        '
        'RPMLabel
        '
        Me.RPMLabel.AutoSize = True
        Me.RPMLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RPMLabel.Location = New System.Drawing.Point(652, 300)
        Me.RPMLabel.Name = "RPMLabel"
        Me.RPMLabel.Size = New System.Drawing.Size(66, 29)
        Me.RPMLabel.TabIndex = 64
        Me.RPMLabel.Text = "RPM"
        '
        'RPMCircularProgress
        '
        Me.RPMCircularProgress.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.RPMCircularProgress.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RPMCircularProgress.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RPMCircularProgress.Location = New System.Drawing.Point(586, 332)
        Me.RPMCircularProgress.Maximum = 10000
        Me.RPMCircularProgress.Name = "RPMCircularProgress"
        Me.RPMCircularProgress.ProgressBarType = DevComponents.DotNetBar.eCircularProgressType.Donut
        Me.RPMCircularProgress.ProgressColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.RPMCircularProgress.ProgressText = "4000"
        Me.RPMCircularProgress.ProgressTextColor = System.Drawing.Color.White
        Me.RPMCircularProgress.ProgressTextFormat = ""
        Me.RPMCircularProgress.ProgressTextVisible = True
        Me.RPMCircularProgress.Size = New System.Drawing.Size(198, 145)
        Me.RPMCircularProgress.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP
        Me.RPMCircularProgress.TabIndex = 65
        Me.RPMCircularProgress.Value = 8000
        '
        'ThrottleCircularProgress
        '
        Me.ThrottleCircularProgress.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.ThrottleCircularProgress.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ThrottleCircularProgress.Location = New System.Drawing.Point(546, 284)
        Me.ThrottleCircularProgress.Maximum = 1000
        Me.ThrottleCircularProgress.Name = "ThrottleCircularProgress"
        Me.ThrottleCircularProgress.ProgressBarType = DevComponents.DotNetBar.eCircularProgressType.Donut
        Me.ThrottleCircularProgress.ProgressColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ThrottleCircularProgress.ProgressText = "XXX"
        Me.ThrottleCircularProgress.ProgressTextColor = System.Drawing.Color.White
        Me.ThrottleCircularProgress.ProgressTextFormat = ""
        Me.ThrottleCircularProgress.ProgressTextVisible = True
        Me.ThrottleCircularProgress.Size = New System.Drawing.Size(72, 75)
        Me.ThrottleCircularProgress.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP
        Me.ThrottleCircularProgress.TabIndex = 66
        Me.ThrottleCircularProgress.Value = 1000
        '
        'ThrottleLabel
        '
        Me.ThrottleLabel.AutoSize = True
        Me.ThrottleLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ThrottleLabel.Location = New System.Drawing.Point(552, 270)
        Me.ThrottleLabel.Name = "ThrottleLabel"
        Me.ThrottleLabel.Size = New System.Drawing.Size(60, 13)
        Me.ThrottleLabel.TabIndex = 67
        Me.ThrottleLabel.Text = "Throttle (%)"
        Me.ThrottleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BrakeLabel
        '
        Me.BrakeLabel.AutoSize = True
        Me.BrakeLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BrakeLabel.Location = New System.Drawing.Point(556, 419)
        Me.BrakeLabel.Name = "BrakeLabel"
        Me.BrakeLabel.Size = New System.Drawing.Size(52, 13)
        Me.BrakeLabel.TabIndex = 69
        Me.BrakeLabel.Text = "Brake (%)"
        Me.BrakeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BrakeCircularProgress
        '
        Me.BrakeCircularProgress.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.BrakeCircularProgress.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.BrakeCircularProgress.Location = New System.Drawing.Point(546, 433)
        Me.BrakeCircularProgress.Maximum = 1000
        Me.BrakeCircularProgress.Name = "BrakeCircularProgress"
        Me.BrakeCircularProgress.ProgressBarType = DevComponents.DotNetBar.eCircularProgressType.Donut
        Me.BrakeCircularProgress.ProgressColor = System.Drawing.Color.Lime
        Me.BrakeCircularProgress.ProgressText = "XXX"
        Me.BrakeCircularProgress.ProgressTextColor = System.Drawing.Color.White
        Me.BrakeCircularProgress.ProgressTextFormat = ""
        Me.BrakeCircularProgress.ProgressTextVisible = True
        Me.BrakeCircularProgress.Size = New System.Drawing.Size(72, 75)
        Me.BrakeCircularProgress.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP
        Me.BrakeCircularProgress.TabIndex = 68
        Me.BrakeCircularProgress.Value = 100
        '
        'PowertrainLabel
        '
        Me.PowertrainLabel.AutoSize = True
        Me.PowertrainLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PowertrainLabel.Location = New System.Drawing.Point(180, 272)
        Me.PowertrainLabel.Name = "PowertrainLabel"
        Me.PowertrainLabel.Size = New System.Drawing.Size(66, 13)
        Me.PowertrainLabel.TabIndex = 71
        Me.PowertrainLabel.Text = "PWRT (kW)"
        Me.PowertrainLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'HVACLabel
        '
        Me.HVACLabel.AutoSize = True
        Me.HVACLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HVACLabel.Location = New System.Drawing.Point(48, 439)
        Me.HVACLabel.Name = "HVACLabel"
        Me.HVACLabel.Size = New System.Drawing.Size(62, 13)
        Me.HVACLabel.TabIndex = 73
        Me.HVACLabel.Text = "HVAC (kW)"
        Me.HVACLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'HVACCircularProgress
        '
        Me.HVACCircularProgress.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.HVACCircularProgress.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.HVACCircularProgress.Location = New System.Drawing.Point(43, 453)
        Me.HVACCircularProgress.Maximum = 5000
        Me.HVACCircularProgress.Name = "HVACCircularProgress"
        Me.HVACCircularProgress.ProgressBarType = DevComponents.DotNetBar.eCircularProgressType.Donut
        Me.HVACCircularProgress.ProgressColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.HVACCircularProgress.ProgressText = "XXX"
        Me.HVACCircularProgress.ProgressTextColor = System.Drawing.Color.White
        Me.HVACCircularProgress.ProgressTextFormat = ""
        Me.HVACCircularProgress.ProgressTextVisible = True
        Me.HVACCircularProgress.Size = New System.Drawing.Size(72, 75)
        Me.HVACCircularProgress.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP
        Me.HVACCircularProgress.TabIndex = 72
        Me.HVACCircularProgress.Value = 100
        '
        'AccLabel
        '
        Me.AccLabel.AutoSize = True
        Me.AccLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AccLabel.Location = New System.Drawing.Point(318, 439)
        Me.AccLabel.Name = "AccLabel"
        Me.AccLabel.Size = New System.Drawing.Size(54, 13)
        Me.AccLabel.TabIndex = 75
        Me.AccLabel.Text = "ACC (kW)"
        Me.AccLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'AccCircularProgress
        '
        Me.AccCircularProgress.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.AccCircularProgress.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.AccCircularProgress.Location = New System.Drawing.Point(309, 453)
        Me.AccCircularProgress.Maximum = 2000
        Me.AccCircularProgress.Name = "AccCircularProgress"
        Me.AccCircularProgress.ProgressBarType = DevComponents.DotNetBar.eCircularProgressType.Donut
        Me.AccCircularProgress.ProgressColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.AccCircularProgress.ProgressText = "XXX"
        Me.AccCircularProgress.ProgressTextColor = System.Drawing.Color.White
        Me.AccCircularProgress.ProgressTextFormat = ""
        Me.AccCircularProgress.ProgressTextVisible = True
        Me.AccCircularProgress.Size = New System.Drawing.Size(72, 75)
        Me.AccCircularProgress.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP
        Me.AccCircularProgress.TabIndex = 74
        Me.AccCircularProgress.Value = 100
        '
        'PowertrainCircularProgress
        '
        Me.PowertrainCircularProgress.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.PowertrainCircularProgress.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.PowertrainCircularProgress.Location = New System.Drawing.Point(177, 286)
        Me.PowertrainCircularProgress.Maximum = 110
        Me.PowertrainCircularProgress.Name = "PowertrainCircularProgress"
        Me.PowertrainCircularProgress.ProgressBarType = DevComponents.DotNetBar.eCircularProgressType.Donut
        Me.PowertrainCircularProgress.ProgressColor = System.Drawing.Color.DarkGoldenrod
        Me.PowertrainCircularProgress.ProgressText = "XXX"
        Me.PowertrainCircularProgress.ProgressTextColor = System.Drawing.Color.White
        Me.PowertrainCircularProgress.ProgressTextFormat = ""
        Me.PowertrainCircularProgress.ProgressTextVisible = True
        Me.PowertrainCircularProgress.Size = New System.Drawing.Size(72, 75)
        Me.PowertrainCircularProgress.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP
        Me.PowertrainCircularProgress.TabIndex = 70
        Me.PowertrainCircularProgress.Value = 50
        '
        'EVSEGroupBox
        '
        Me.EVSEGroupBox.Controls.Add(Me.FrequencyOut)
        Me.EVSEGroupBox.Controls.Add(Me.FrequencyLabel)
        Me.EVSEGroupBox.Controls.Add(Me.AmpacityOut)
        Me.EVSEGroupBox.Controls.Add(Me.AmpacityLabel)
        Me.EVSEGroupBox.Controls.Add(Me.AACout)
        Me.EVSEGroupBox.Controls.Add(Me.AACLabel)
        Me.EVSEGroupBox.Controls.Add(Me.VACout)
        Me.EVSEGroupBox.Controls.Add(Me.VACLabel)
        Me.EVSEGroupBox.Location = New System.Drawing.Point(393, 270)
        Me.EVSEGroupBox.Name = "EVSEGroupBox"
        Me.EVSEGroupBox.Size = New System.Drawing.Size(379, 249)
        Me.EVSEGroupBox.TabIndex = 76
        Me.EVSEGroupBox.TabStop = False
        Me.EVSEGroupBox.Visible = False
        '
        'FrequencyOut
        '
        Me.FrequencyOut.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FrequencyOut.AutoSize = True
        Me.FrequencyOut.BackColor = System.Drawing.Color.Transparent
        Me.FrequencyOut.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FrequencyOut.Location = New System.Drawing.Point(245, 189)
        Me.FrequencyOut.Name = "FrequencyOut"
        Me.FrequencyOut.Size = New System.Drawing.Size(108, 31)
        Me.FrequencyOut.TabIndex = 26
        Me.FrequencyOut.Text = "60.0 Hz"
        Me.FrequencyOut.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'FrequencyLabel
        '
        Me.FrequencyLabel.AutoSize = True
        Me.FrequencyLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FrequencyLabel.Location = New System.Drawing.Point(29, 189)
        Me.FrequencyLabel.Name = "FrequencyLabel"
        Me.FrequencyLabel.Size = New System.Drawing.Size(151, 31)
        Me.FrequencyLabel.TabIndex = 25
        Me.FrequencyLabel.Text = "Frequency:"
        '
        'AmpacityOut
        '
        Me.AmpacityOut.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.AmpacityOut.AutoSize = True
        Me.AmpacityOut.BackColor = System.Drawing.Color.Transparent
        Me.AmpacityOut.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AmpacityOut.Location = New System.Drawing.Point(284, 138)
        Me.AmpacityOut.Name = "AmpacityOut"
        Me.AmpacityOut.Size = New System.Drawing.Size(69, 31)
        Me.AmpacityOut.TabIndex = 24
        Me.AmpacityOut.Text = "28 A"
        Me.AmpacityOut.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'AmpacityLabel
        '
        Me.AmpacityLabel.AutoSize = True
        Me.AmpacityLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AmpacityLabel.Location = New System.Drawing.Point(29, 138)
        Me.AmpacityLabel.Name = "AmpacityLabel"
        Me.AmpacityLabel.Size = New System.Drawing.Size(230, 31)
        Me.AmpacityLabel.TabIndex = 23
        Me.AmpacityLabel.Text = "Available Current:"
        '
        'AACout
        '
        Me.AACout.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.AACout.AutoSize = True
        Me.AACout.BackColor = System.Drawing.Color.Transparent
        Me.AACout.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AACout.Location = New System.Drawing.Point(284, 87)
        Me.AACout.Name = "AACout"
        Me.AACout.Size = New System.Drawing.Size(69, 31)
        Me.AACout.TabIndex = 22
        Me.AACout.Text = "28 A"
        Me.AACout.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'AACLabel
        '
        Me.AACLabel.AutoSize = True
        Me.AACLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AACLabel.Location = New System.Drawing.Point(29, 87)
        Me.AACLabel.Name = "AACLabel"
        Me.AACLabel.Size = New System.Drawing.Size(176, 31)
        Me.AACLabel.TabIndex = 21
        Me.AACLabel.Text = "Current (AC):"
        '
        'VACout
        '
        Me.VACout.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.VACout.AutoSize = True
        Me.VACout.BackColor = System.Drawing.Color.Transparent
        Me.VACout.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.VACout.Location = New System.Drawing.Point(231, 36)
        Me.VACout.Name = "VACout"
        Me.VACout.Size = New System.Drawing.Size(122, 31)
        Me.VACout.TabIndex = 20
        Me.VACout.Text = "240.00 V"
        Me.VACout.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'VACLabel
        '
        Me.VACLabel.AutoSize = True
        Me.VACLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.VACLabel.Location = New System.Drawing.Point(29, 36)
        Me.VACLabel.Name = "VACLabel"
        Me.VACLabel.Size = New System.Drawing.Size(177, 31)
        Me.VACLabel.TabIndex = 19
        Me.VACLabel.Text = "Voltage (AC):"
        '
        'SixButton
        '
        Me.SixButton.Location = New System.Drawing.Point(427, 12)
        Me.SixButton.Name = "SixButton"
        Me.SixButton.Size = New System.Drawing.Size(48, 34)
        Me.SixButton.TabIndex = 77
        Me.SixButton.Text = "&6"
        Me.SixButton.UseVisualStyleBackColor = True
        '
        'MaxCellOutLabel
        '
        Me.MaxCellOutLabel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.MaxCellOutLabel.AutoSize = True
        Me.MaxCellOutLabel.BackColor = System.Drawing.Color.Transparent
        Me.MaxCellOutLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaxCellOutLabel.Location = New System.Drawing.Point(228, 161)
        Me.MaxCellOutLabel.Name = "MaxCellOutLabel"
        Me.MaxCellOutLabel.Size = New System.Drawing.Size(45, 22)
        Me.MaxCellOutLabel.TabIndex = 78
        Me.MaxCellOutLabel.Text = "4.17"
        Me.MaxCellOutLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'MinCellOutLabel
        '
        Me.MinCellOutLabel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.MinCellOutLabel.AutoSize = True
        Me.MinCellOutLabel.BackColor = System.Drawing.Color.Transparent
        Me.MinCellOutLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MinCellOutLabel.Location = New System.Drawing.Point(228, 212)
        Me.MinCellOutLabel.Name = "MinCellOutLabel"
        Me.MinCellOutLabel.Size = New System.Drawing.Size(45, 22)
        Me.MinCellOutLabel.TabIndex = 79
        Me.MinCellOutLabel.Text = "4.17"
        Me.MinCellOutLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'SevenButton
        '
        Me.SevenButton.Location = New System.Drawing.Point(364, 12)
        Me.SevenButton.Name = "SevenButton"
        Me.SevenButton.Size = New System.Drawing.Size(48, 34)
        Me.SevenButton.TabIndex = 80
        Me.SevenButton.Text = "&7"
        Me.SevenButton.UseVisualStyleBackColor = True
        '
        'FFECANBUSGUI
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(784, 562)
        Me.Controls.Add(Me.MinCellOutLabel)
        Me.Controls.Add(Me.MaxCellOutLabel)
        Me.Controls.Add(Me.EVSEGroupBox)
        Me.Controls.Add(Me.AccLabel)
        Me.Controls.Add(Me.AccCircularProgress)
        Me.Controls.Add(Me.HVACLabel)
        Me.Controls.Add(Me.HVACCircularProgress)
        Me.Controls.Add(Me.BrakeLabel)
        Me.Controls.Add(Me.BrakeCircularProgress)
        Me.Controls.Add(Me.ThrottleLabel)
        Me.Controls.Add(Me.ThrottleCircularProgress)
        Me.Controls.Add(Me.ETELabel)
        Me.Controls.Add(Me.RPMLabel)
        Me.Controls.Add(Me.RPMCircularProgress)
        Me.Controls.Add(Me.MPHLabel)
        Me.Controls.Add(Me.ChaTimeRemOut)
        Me.Controls.Add(Me.ChaTimeRemLabel)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.StopButton)
        Me.Controls.Add(Me.BmodeOutLabel)
        Me.Controls.Add(Me.PosTorqueProgressBar)
        Me.Controls.Add(Me.NegTorqueProgressBar)
        Me.Controls.Add(Me.PosCurrentProgressBar)
        Me.Controls.Add(Me.NegCurrentProgressBar)
        Me.Controls.Add(Me.TorqueOutLabel)
        Me.Controls.Add(Me.TorqueLabel)
        Me.Controls.Add(Me.BmodeLabel)
        Me.Controls.Add(Me.TenDownButton)
        Me.Controls.Add(Me.TenUpButton)
        Me.Controls.Add(Me.EStopButton)
        Me.Controls.Add(Me.DownButton)
        Me.Controls.Add(Me.UpButton)
        Me.Controls.Add(Me.Seq5Button)
        Me.Controls.Add(Me.Seq4Button)
        Me.Controls.Add(Me.Seq3Button)
        Me.Controls.Add(Me.Seq2Button)
        Me.Controls.Add(Me.Seq1Button)
        Me.Controls.Add(Me.Seq0Button)
        Me.Controls.Add(Me.PowerProgressBar)
        Me.Controls.Add(Me.BattTempOutLabel)
        Me.Controls.Add(Me.BattTempLabel)
        Me.Controls.Add(Me.MConOutLabel)
        Me.Controls.Add(Me.MConLabel)
        Me.Controls.Add(Me.BattCoolInOutLabel)
        Me.Controls.Add(Me.BattCoolInLabel)
        Me.Controls.Add(Me.CurrentOutLabel)
        Me.Controls.Add(Me.CurrentLabel)
        Me.Controls.Add(Me.VoltageLabel)
        Me.Controls.Add(Me.PowerOutLabel)
        Me.Controls.Add(Me.PowerLabel)
        Me.Controls.Add(Me.CloseSerialButton)
        Me.Controls.Add(Me.OpenSerialButton)
        Me.Controls.Add(Me.RegenProgressBar)
        Me.Controls.Add(Me.SOCActualCircularProgress)
        Me.Controls.Add(Me.SOCDisplayedCircularProgress)
        Me.Controls.Add(Me.SOCActualLabel)
        Me.Controls.Add(Me.SOCDisplayedLabel)
        Me.Controls.Add(Me.VoltageCircularProgress)
        Me.Controls.Add(Me.MPHCircularProgress)
        Me.Controls.Add(Me.ETECircularProgress)
        Me.Controls.Add(Me.ChaCurrentCircularProgress)
        Me.Controls.Add(Me.ChacurrentLabel)
        Me.Controls.Add(Me.PowertrainCircularProgress)
        Me.Controls.Add(Me.PowertrainLabel)
        Me.Controls.Add(Me.SixButton)
        Me.Controls.Add(Me.SevenButton)
        Me.ForeColor = System.Drawing.Color.White
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FFECANBUSGUI"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "g"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.EVSEGroupBox.ResumeLayout(False)
        Me.EVSEGroupBox.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents SOCDisplayedLabel As System.Windows.Forms.Label
    Friend WithEvents OpenSerialButton As System.Windows.Forms.Button
    Friend WithEvents CloseSerialButton As System.Windows.Forms.Button
    Friend WithEvents Update As System.Windows.Forms.Timer
    Friend WithEvents SOCActualLabel As System.Windows.Forms.Label
    Friend WithEvents RegenProgressBar As System.Windows.Forms.ProgressBar
    Friend WithEvents PowerOutLabel As System.Windows.Forms.Label
    Friend WithEvents PowerLabel As System.Windows.Forms.Label
    Friend WithEvents CurrentLabel As System.Windows.Forms.Label
    Friend WithEvents VoltageLabel As System.Windows.Forms.Label
    Friend WithEvents BattCoolInOutLabel As System.Windows.Forms.Label
    Friend WithEvents BattCoolInLabel As System.Windows.Forms.Label
    Friend WithEvents MConOutLabel As System.Windows.Forms.Label
    Friend WithEvents MConLabel As System.Windows.Forms.Label
    Friend WithEvents ETELabel As System.Windows.Forms.Label
    Friend WithEvents BattTempOutLabel As System.Windows.Forms.Label
    Friend WithEvents BattTempLabel As System.Windows.Forms.Label
    Friend WithEvents PowerProgressBar As System.Windows.Forms.ProgressBar
    Friend WithEvents Seq0Button As System.Windows.Forms.Button
    Friend WithEvents Seq1Button As System.Windows.Forms.Button
    Friend WithEvents Seq2Button As System.Windows.Forms.Button
    Friend WithEvents Seq3Button As System.Windows.Forms.Button
    Friend WithEvents Seq4Button As System.Windows.Forms.Button
    Friend WithEvents Seq5Button As System.Windows.Forms.Button
    Friend WithEvents ChacurrentLabel As System.Windows.Forms.Label
    Friend WithEvents DownButton As System.Windows.Forms.Button
    Friend WithEvents UpButton As System.Windows.Forms.Button
    Friend WithEvents EStopButton As System.Windows.Forms.Button
    Friend WithEvents TenUpButton As System.Windows.Forms.Button
    Friend WithEvents TenDownButton As System.Windows.Forms.Button
    Friend WithEvents BmodeOutLabel As System.Windows.Forms.Label
    Friend WithEvents BmodeLabel As System.Windows.Forms.Label
    Friend WithEvents TorqueOutLabel As System.Windows.Forms.Label
    Friend WithEvents TorqueLabel As System.Windows.Forms.Label
    Friend WithEvents Startup As System.Windows.Forms.Timer
    Friend WithEvents SOCDisplayedCircularProgress As DevComponents.DotNetBar.Controls.CircularProgress
    Friend WithEvents SOCActualCircularProgress As DevComponents.DotNetBar.Controls.CircularProgress
    Friend WithEvents ETECircularProgress As DevComponents.DotNetBar.Controls.CircularProgress
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ChaCurrentCircularProgress As DevComponents.DotNetBar.Controls.CircularProgress
    Friend WithEvents VoltageCircularProgress As DevComponents.DotNetBar.Controls.CircularProgress
    Friend WithEvents CurrentOutLabel As System.Windows.Forms.Label
    Friend WithEvents PosCurrentProgressBar As System.Windows.Forms.ProgressBar
    Friend WithEvents NegCurrentProgressBar As System.Windows.Forms.ProgressBar
    Friend WithEvents PosTorqueProgressBar As System.Windows.Forms.ProgressBar
    Friend WithEvents NegTorqueProgressBar As System.Windows.Forms.ProgressBar
    Friend WithEvents StopButton As System.Windows.Forms.Button
    Friend WithEvents ChaTimeRemLabel As System.Windows.Forms.Label
    Friend WithEvents ChaTimeRemOut As System.Windows.Forms.Label
    Friend WithEvents MPHLabel As System.Windows.Forms.Label
    Friend WithEvents MPHCircularProgress As DevComponents.DotNetBar.Controls.CircularProgress
    Friend WithEvents RPMLabel As System.Windows.Forms.Label
    Friend WithEvents RPMCircularProgress As DevComponents.DotNetBar.Controls.CircularProgress
    Friend WithEvents ThrottleCircularProgress As DevComponents.DotNetBar.Controls.CircularProgress
    Friend WithEvents ThrottleLabel As System.Windows.Forms.Label
    Friend WithEvents BrakeLabel As System.Windows.Forms.Label
    Friend WithEvents BrakeCircularProgress As DevComponents.DotNetBar.Controls.CircularProgress
    Friend WithEvents PowertrainLabel As System.Windows.Forms.Label
    Friend WithEvents HVACLabel As System.Windows.Forms.Label
    Friend WithEvents HVACCircularProgress As DevComponents.DotNetBar.Controls.CircularProgress
    Friend WithEvents AccLabel As System.Windows.Forms.Label
    Friend WithEvents AccCircularProgress As DevComponents.DotNetBar.Controls.CircularProgress
    Friend WithEvents PowertrainCircularProgress As DevComponents.DotNetBar.Controls.CircularProgress
    Friend WithEvents EVSEGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents FrequencyOut As System.Windows.Forms.Label
    Friend WithEvents FrequencyLabel As System.Windows.Forms.Label
    Friend WithEvents AmpacityOut As System.Windows.Forms.Label
    Friend WithEvents AmpacityLabel As System.Windows.Forms.Label
    Friend WithEvents AACout As System.Windows.Forms.Label
    Friend WithEvents AACLabel As System.Windows.Forms.Label
    Friend WithEvents VACout As System.Windows.Forms.Label
    Friend WithEvents VACLabel As System.Windows.Forms.Label
    Friend WithEvents SixButton As System.Windows.Forms.Button
    Friend WithEvents MaxCellOutLabel As System.Windows.Forms.Label
    Friend WithEvents MinCellOutLabel As System.Windows.Forms.Label
    Friend WithEvents SevenButton As System.Windows.Forms.Button

End Class
