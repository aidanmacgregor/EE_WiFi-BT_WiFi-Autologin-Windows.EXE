<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.LinkLabelMap = New System.Windows.Forms.LinkLabel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ButtonRunningStatus = New System.Windows.Forms.Button()
        Me.ButtonInternetStatus = New System.Windows.Forms.Button()
        Me.ButtonResetLogincount = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.CheckBoxAutorun = New System.Windows.Forms.CheckBox()
        Me.LinkLabelAidanMacgregor = New System.Windows.Forms.LinkLabel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ButtonStartStop = New System.Windows.Forms.Button()
        Me.contextExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.contextOpen = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.ComboBoxAcctype = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ButtonAbout = New System.Windows.Forms.Button()
        Me.RichTextBoxHTTPresponse = New System.Windows.Forms.RichTextBox()
        Me.PictureBoxBanner = New System.Windows.Forms.PictureBox()
        Me.ButtonHotspot = New System.Windows.Forms.Button()
        Me.TextBoxLoginCount = New System.Windows.Forms.TextBox()
        Me.TextBoxPassword = New System.Windows.Forms.TextBox()
        Me.TextBoxEmail = New System.Windows.Forms.TextBox()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.PictureBoxBanner, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LinkLabelMap
        '
        Me.LinkLabelMap.AutoSize = True
        Me.LinkLabelMap.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.LinkLabelMap.Location = New System.Drawing.Point(349, 3)
        Me.LinkLabelMap.Name = "LinkLabelMap"
        Me.LinkLabelMap.Size = New System.Drawing.Size(34, 16)
        Me.LinkLabelMap.TabIndex = 64
        Me.LinkLabelMap.TabStop = True
        Me.LinkLabelMap.Text = "Map"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label8.Location = New System.Drawing.Point(268, 124)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(58, 13)
        Me.Label8.TabIndex = 63
        Me.Label8.Text = "Internet:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label6.Location = New System.Drawing.Point(268, 101)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(58, 13)
        Me.Label6.TabIndex = 62
        Me.Label6.Text = "Running:"
        '
        'ButtonRunningStatus
        '
        Me.ButtonRunningStatus.Enabled = False
        Me.ButtonRunningStatus.Location = New System.Drawing.Point(332, 97)
        Me.ButtonRunningStatus.Name = "ButtonRunningStatus"
        Me.ButtonRunningStatus.Size = New System.Drawing.Size(47, 21)
        Me.ButtonRunningStatus.TabIndex = 60
        Me.ButtonRunningStatus.UseVisualStyleBackColor = True
        '
        'ButtonInternetStatus
        '
        Me.ButtonInternetStatus.Enabled = False
        Me.ButtonInternetStatus.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ButtonInternetStatus.Location = New System.Drawing.Point(332, 120)
        Me.ButtonInternetStatus.Name = "ButtonInternetStatus"
        Me.ButtonInternetStatus.Size = New System.Drawing.Size(47, 21)
        Me.ButtonInternetStatus.TabIndex = 59
        Me.ButtonInternetStatus.UseVisualStyleBackColor = True
        '
        'ButtonResetLogincount
        '
        Me.ButtonResetLogincount.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.ButtonResetLogincount.ForeColor = System.Drawing.Color.Firebrick
        Me.ButtonResetLogincount.Location = New System.Drawing.Point(292, 210)
        Me.ButtonResetLogincount.Name = "ButtonResetLogincount"
        Me.ButtonResetLogincount.Size = New System.Drawing.Size(87, 24)
        Me.ButtonResetLogincount.TabIndex = 58
        Me.ButtonResetLogincount.Text = "Reset Count"
        Me.ButtonResetLogincount.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label7.Location = New System.Drawing.Point(289, 166)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(80, 13)
        Me.Label7.TabIndex = 57
        Me.Label7.Text = "Login Count:"
        '
        'CheckBoxAutorun
        '
        Me.CheckBoxAutorun.AutoSize = True
        Me.CheckBoxAutorun.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.CheckBoxAutorun.Location = New System.Drawing.Point(292, 147)
        Me.CheckBoxAutorun.Name = "CheckBoxAutorun"
        Me.CheckBoxAutorun.Size = New System.Drawing.Size(72, 17)
        Me.CheckBoxAutorun.TabIndex = 56
        Me.CheckBoxAutorun.Text = "On Boot"
        Me.CheckBoxAutorun.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CheckBoxAutorun.UseVisualStyleBackColor = True
        '
        'LinkLabelAidanMacgregor
        '
        Me.LinkLabelAidanMacgregor.AutoSize = True
        Me.LinkLabelAidanMacgregor.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.LinkLabelAidanMacgregor.Location = New System.Drawing.Point(239, 27)
        Me.LinkLabelAidanMacgregor.Name = "LinkLabelAidanMacgregor"
        Me.LinkLabelAidanMacgregor.Size = New System.Drawing.Size(144, 16)
        Me.LinkLabelAidanMacgregor.TabIndex = 54
        Me.LinkLabelAidanMacgregor.TabStop = True
        Me.LinkLabelAidanMacgregor.Tag = ""
        Me.LinkLabelAidanMacgregor.Text = "By: Aidan Macgregor"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label4.Location = New System.Drawing.Point(12, 276)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 13)
        Me.Label4.TabIndex = 53
        Me.Label4.Text = "HTTP Response:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 229)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 13)
        Me.Label2.TabIndex = 52
        Me.Label2.Text = "Password:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 188)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 13)
        Me.Label1.TabIndex = 51
        Me.Label1.Text = "Email:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 146)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 13)
        Me.Label3.TabIndex = 50
        Me.Label3.Text = "Account Type:"
        '
        'ButtonStartStop
        '
        Me.ButtonStartStop.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.ButtonStartStop.Location = New System.Drawing.Point(185, 161)
        Me.ButtonStartStop.Name = "ButtonStartStop"
        Me.ButtonStartStop.Size = New System.Drawing.Size(101, 40)
        Me.ButtonStartStop.TabIndex = 47
        Me.ButtonStartStop.Text = "Loading..."
        Me.ButtonStartStop.UseVisualStyleBackColor = True
        '
        'contextExit
        '
        Me.contextExit.Name = "contextExit"
        Me.contextExit.Size = New System.Drawing.Size(103, 22)
        Me.contextExit.Text = "Exit"
        '
        'contextOpen
        '
        Me.contextOpen.Name = "contextOpen"
        Me.contextOpen.Size = New System.Drawing.Size(103, 22)
        Me.contextOpen.Text = "Open"
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.contextOpen, Me.contextExit})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(104, 48)
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.NotifyIcon1.Icon = CType(resources.GetObject("NotifyIcon1.Icon"), System.Drawing.Icon)
        Me.NotifyIcon1.Text = "EE WiFi Autologin Service"
        '
        'ComboBoxAcctype
        '
        Me.ComboBoxAcctype.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.ComboBoxAcctype.FormattingEnabled = True
        Me.ComboBoxAcctype.Location = New System.Drawing.Point(12, 163)
        Me.ComboBoxAcctype.Name = "ComboBoxAcctype"
        Me.ComboBoxAcctype.Size = New System.Drawing.Size(167, 21)
        Me.ComboBoxAcctype.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(85, 9)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(258, 18)
        Me.Label5.TabIndex = 49
        Me.Label5.Text = " EE WiFi Autologin Service v7"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ButtonAbout
        '
        Me.ButtonAbout.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.ButtonAbout.ForeColor = System.Drawing.Color.DarkGreen
        Me.ButtonAbout.Location = New System.Drawing.Point(292, 270)
        Me.ButtonAbout.Name = "ButtonAbout"
        Me.ButtonAbout.Size = New System.Drawing.Size(87, 23)
        Me.ButtonAbout.TabIndex = 65
        Me.ButtonAbout.Text = "About"
        Me.ButtonAbout.UseVisualStyleBackColor = True
        '
        'RichTextBoxHTTPresponse
        '
        Me.RichTextBoxHTTPresponse.BackColor = System.Drawing.Color.White
        Me.RichTextBoxHTTPresponse.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.RichTextBoxHTTPresponse.Location = New System.Drawing.Point(118, 273)
        Me.RichTextBoxHTTPresponse.Name = "RichTextBoxHTTPresponse"
        Me.RichTextBoxHTTPresponse.ReadOnly = True
        Me.RichTextBoxHTTPresponse.Size = New System.Drawing.Size(168, 20)
        Me.RichTextBoxHTTPresponse.TabIndex = 48
        Me.RichTextBoxHTTPresponse.Text = ""
        '
        'PictureBoxBanner
        '
        Me.PictureBoxBanner.Image = Global.EE_WiFi_Autologin.My.Resources.Resources.eewin1
        Me.PictureBoxBanner.Location = New System.Drawing.Point(-4, 3)
        Me.PictureBoxBanner.Name = "PictureBoxBanner"
        Me.PictureBoxBanner.Size = New System.Drawing.Size(406, 152)
        Me.PictureBoxBanner.TabIndex = 55
        Me.PictureBoxBanner.TabStop = False
        '
        'ButtonHotspot
        '
        Me.ButtonHotspot.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonHotspot.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.ButtonHotspot.Location = New System.Drawing.Point(292, 240)
        Me.ButtonHotspot.Name = "ButtonHotspot"
        Me.ButtonHotspot.Size = New System.Drawing.Size(87, 24)
        Me.ButtonHotspot.TabIndex = 66
        Me.ButtonHotspot.Text = "WiFi Hotspot"
        Me.ButtonHotspot.UseVisualStyleBackColor = True
        '
        'TextBoxLoginCount
        '
        Me.TextBoxLoginCount.BackColor = System.Drawing.Color.White
        Me.TextBoxLoginCount.Cursor = System.Windows.Forms.Cursors.Default
        Me.TextBoxLoginCount.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.EE_WiFi_Autologin.My.MySettings.Default, "SaveLoginCount", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.TextBoxLoginCount.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.TextBoxLoginCount.Location = New System.Drawing.Point(292, 183)
        Me.TextBoxLoginCount.Name = "TextBoxLoginCount"
        Me.TextBoxLoginCount.ReadOnly = True
        Me.TextBoxLoginCount.Size = New System.Drawing.Size(87, 21)
        Me.TextBoxLoginCount.TabIndex = 61
        Me.TextBoxLoginCount.Text = Global.EE_WiFi_Autologin.My.MySettings.Default.SaveLoginCount
        '
        'TextBoxPassword
        '
        Me.TextBoxPassword.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.EE_WiFi_Autologin.My.MySettings.Default, "savePassword", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.TextBoxPassword.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.TextBoxPassword.Location = New System.Drawing.Point(12, 246)
        Me.TextBoxPassword.Name = "TextBoxPassword"
        Me.TextBoxPassword.Size = New System.Drawing.Size(274, 21)
        Me.TextBoxPassword.TabIndex = 46
        Me.TextBoxPassword.Text = Global.EE_WiFi_Autologin.My.MySettings.Default.savePassword
        Me.TextBoxPassword.UseSystemPasswordChar = True
        '
        'TextBoxEmail
        '
        Me.TextBoxEmail.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.EE_WiFi_Autologin.My.MySettings.Default, "saveEmail", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.TextBoxEmail.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.TextBoxEmail.Location = New System.Drawing.Point(12, 205)
        Me.TextBoxEmail.Name = "TextBoxEmail"
        Me.TextBoxEmail.Size = New System.Drawing.Size(274, 21)
        Me.TextBoxEmail.TabIndex = 45
        Me.TextBoxEmail.Text = Global.EE_WiFi_Autologin.My.MySettings.Default.saveEmail
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(391, 300)
        Me.Controls.Add(Me.ButtonHotspot)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.LinkLabelAidanMacgregor)
        Me.Controls.Add(Me.ComboBoxAcctype)
        Me.Controls.Add(Me.ButtonAbout)
        Me.Controls.Add(Me.LinkLabelMap)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TextBoxLoginCount)
        Me.Controls.Add(Me.ButtonRunningStatus)
        Me.Controls.Add(Me.ButtonInternetStatus)
        Me.Controls.Add(Me.ButtonResetLogincount)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.CheckBoxAutorun)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.RichTextBoxHTTPresponse)
        Me.Controls.Add(Me.ButtonStartStop)
        Me.Controls.Add(Me.TextBoxPassword)
        Me.Controls.Add(Me.TextBoxEmail)
        Me.Controls.Add(Me.PictureBoxBanner)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form1"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "EE WiFi Autologin Service"
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.PictureBoxBanner, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LinkLabelMap As LinkLabel
    Friend WithEvents Label8 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents TextBoxLoginCount As TextBox
    Friend WithEvents ButtonRunningStatus As Button
    Friend WithEvents ButtonInternetStatus As Button
    Friend WithEvents ButtonResetLogincount As Button
    Friend WithEvents Label7 As Label
    Friend WithEvents CheckBoxAutorun As CheckBox
    Friend WithEvents LinkLabelAidanMacgregor As LinkLabel
    Friend WithEvents Label4 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents ButtonStartStop As Button
    Friend WithEvents TextBoxPassword As TextBox
    Friend WithEvents TextBoxEmail As TextBox
    Friend WithEvents contextExit As ToolStripMenuItem
    Friend WithEvents PictureBoxBanner As PictureBox
    Friend WithEvents contextOpen As ToolStripMenuItem
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents NotifyIcon1 As NotifyIcon
    Friend WithEvents ComboBoxAcctype As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents ButtonAbout As Button
    Friend WithEvents RichTextBoxHTTPresponse As RichTextBox
    Friend WithEvents ButtonHotspot As Button
End Class
