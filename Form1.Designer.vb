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
        Me.LinkLabel2 = New System.Windows.Forms.LinkLabel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ButtonRunninStatus = New System.Windows.Forms.Button()
        Me.ButtonInternetStatus = New System.Windows.Forms.Button()
        Me.ButtonResetLogincount = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.checkboxAutorun = New System.Windows.Forms.CheckBox()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.RichTextBoxHTTPresponse = New System.Windows.Forms.RichTextBox()
        Me.ButtonStartStop = New System.Windows.Forms.Button()
        Me.TextBoxPassword = New System.Windows.Forms.TextBox()
        Me.TextBoxEmail = New System.Windows.Forms.TextBox()
        Me.contextExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.contextOpen = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.ComboBoxAcctype = New System.Windows.Forms.ComboBox()
        Me.TextBoxLoginCount = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ButtonAbout = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LinkLabel2
        '
        Me.LinkLabel2.AutoSize = True
        Me.LinkLabel2.Location = New System.Drawing.Point(9, 9)
        Me.LinkLabel2.Name = "LinkLabel2"
        Me.LinkLabel2.Size = New System.Drawing.Size(55, 13)
        Me.LinkLabel2.TabIndex = 64
        Me.LinkLabel2.TabStop = True
        Me.LinkLabel2.Text = "Wi-Fi Map"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(206, 243)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(46, 13)
        Me.Label8.TabIndex = 63
        Me.Label8.Text = "Internet:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(206, 220)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(50, 13)
        Me.Label6.TabIndex = 62
        Me.Label6.Text = "Running:"
        '
        'ButtonRunninStatus
        '
        Me.ButtonRunninStatus.Enabled = False
        Me.ButtonRunninStatus.Location = New System.Drawing.Point(258, 216)
        Me.ButtonRunninStatus.Name = "ButtonRunninStatus"
        Me.ButtonRunninStatus.Size = New System.Drawing.Size(29, 21)
        Me.ButtonRunninStatus.TabIndex = 60
        Me.ButtonRunninStatus.UseVisualStyleBackColor = True
        '
        'ButtonInternetStatus
        '
        Me.ButtonInternetStatus.Enabled = False
        Me.ButtonInternetStatus.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ButtonInternetStatus.Location = New System.Drawing.Point(258, 239)
        Me.ButtonInternetStatus.Name = "ButtonInternetStatus"
        Me.ButtonInternetStatus.Size = New System.Drawing.Size(29, 21)
        Me.ButtonInternetStatus.TabIndex = 59
        Me.ButtonInternetStatus.UseVisualStyleBackColor = True
        '
        'ButtonResetLogincount
        '
        Me.ButtonResetLogincount.Location = New System.Drawing.Point(289, 334)
        Me.ButtonResetLogincount.Name = "ButtonResetLogincount"
        Me.ButtonResetLogincount.Size = New System.Drawing.Size(93, 21)
        Me.ButtonResetLogincount.TabIndex = 58
        Me.ButtonResetLogincount.Text = "Reset Count"
        Me.ButtonResetLogincount.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(289, 292)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(67, 13)
        Me.Label7.TabIndex = 57
        Me.Label7.Text = "Login Count:"
        '
        'checkboxAutorun
        '
        Me.checkboxAutorun.AutoSize = True
        Me.checkboxAutorun.Location = New System.Drawing.Point(292, 266)
        Me.checkboxAutorun.Name = "checkboxAutorun"
        Me.checkboxAutorun.Size = New System.Drawing.Size(88, 17)
        Me.checkboxAutorun.TabIndex = 56
        Me.checkboxAutorun.Text = "Run On Boot"
        Me.checkboxAutorun.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.checkboxAutorun.UseVisualStyleBackColor = True
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Location = New System.Drawing.Point(276, 22)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(106, 13)
        Me.LinkLabel1.TabIndex = 54
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Tag = ""
        Me.LinkLabel1.Text = "By: Aidan Macgregor"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(9, 337)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(90, 13)
        Me.Label4.TabIndex = 53
        Me.Label4.Text = "HTTP Response:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 292)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 13)
        Me.Label2.TabIndex = 52
        Me.Label2.Text = "Password:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 253)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 13)
        Me.Label1.TabIndex = 51
        Me.Label1.Text = "Email:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(9, 213)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(77, 13)
        Me.Label3.TabIndex = 50
        Me.Label3.Text = "Account Type:"
        '
        'RichTextBoxHTTPresponse
        '
        Me.RichTextBoxHTTPresponse.Location = New System.Drawing.Point(105, 334)
        Me.RichTextBoxHTTPresponse.Name = "RichTextBoxHTTPresponse"
        Me.RichTextBoxHTTPresponse.ReadOnly = True
        Me.RichTextBoxHTTPresponse.Size = New System.Drawing.Size(178, 21)
        Me.RichTextBoxHTTPresponse.TabIndex = 48
        Me.RichTextBoxHTTPresponse.Text = ""
        '
        'ButtonStartStop
        '
        Me.ButtonStartStop.Enabled = False
        Me.ButtonStartStop.Location = New System.Drawing.Point(292, 216)
        Me.ButtonStartStop.Name = "ButtonStartStop"
        Me.ButtonStartStop.Size = New System.Drawing.Size(90, 44)
        Me.ButtonStartStop.TabIndex = 47
        Me.ButtonStartStop.Text = "Loading..."
        Me.ButtonStartStop.UseVisualStyleBackColor = True
        '
        'TextBoxPassword
        '
        Me.TextBoxPassword.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.BT_Wi_Fi_Autologin.My.MySettings.Default, "savePassword", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.TextBoxPassword.Location = New System.Drawing.Point(12, 308)
        Me.TextBoxPassword.Name = "TextBoxPassword"
        Me.TextBoxPassword.Size = New System.Drawing.Size(271, 20)
        Me.TextBoxPassword.TabIndex = 46
        Me.TextBoxPassword.Text = Global.BT_Wi_Fi_Autologin.My.MySettings.Default.savePassword
        Me.TextBoxPassword.UseSystemPasswordChar = True
        '
        'TextBoxEmail
        '
        Me.TextBoxEmail.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.BT_Wi_Fi_Autologin.My.MySettings.Default, "saveEmail", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.TextBoxEmail.Location = New System.Drawing.Point(12, 269)
        Me.TextBoxEmail.Name = "TextBoxEmail"
        Me.TextBoxEmail.Size = New System.Drawing.Size(271, 20)
        Me.TextBoxEmail.TabIndex = 45
        Me.TextBoxEmail.Text = Global.BT_Wi_Fi_Autologin.My.MySettings.Default.saveEmail
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
        Me.NotifyIcon1.Text = "BT Wi-Fi Autologin Service"
        '
        'ComboBoxAcctype
        '
        Me.ComboBoxAcctype.FormattingEnabled = True
        Me.ComboBoxAcctype.Location = New System.Drawing.Point(12, 229)
        Me.ComboBoxAcctype.Name = "ComboBoxAcctype"
        Me.ComboBoxAcctype.Size = New System.Drawing.Size(184, 21)
        Me.ComboBoxAcctype.TabIndex = 44
        '
        'TextBoxLoginCount
        '
        Me.TextBoxLoginCount.Cursor = System.Windows.Forms.Cursors.Default
        Me.TextBoxLoginCount.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.BT_Wi_Fi_Autologin.My.MySettings.Default, "SaveLoginCount", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.TextBoxLoginCount.Location = New System.Drawing.Point(289, 308)
        Me.TextBoxLoginCount.Name = "TextBoxLoginCount"
        Me.TextBoxLoginCount.ReadOnly = True
        Me.TextBoxLoginCount.Size = New System.Drawing.Size(92, 20)
        Me.TextBoxLoginCount.TabIndex = 61
        Me.TextBoxLoginCount.Text = Global.BT_Wi_Fi_Autologin.My.MySettings.Default.SaveLoginCount
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(233, 9)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(149, 13)
        Me.Label5.TabIndex = 49
        Me.Label5.Text = "BT Wi-Fi Autologin Service v4"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ButtonAbout
        '
        Me.ButtonAbout.Location = New System.Drawing.Point(338, 38)
        Me.ButtonAbout.Name = "ButtonAbout"
        Me.ButtonAbout.Size = New System.Drawing.Size(44, 23)
        Me.ButtonAbout.TabIndex = 65
        Me.ButtonAbout.Text = "About"
        Me.ButtonAbout.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(-8, 1)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(409, 209)
        Me.PictureBox1.TabIndex = 55
        Me.PictureBox1.TabStop = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(391, 365)
        Me.Controls.Add(Me.ButtonAbout)
        Me.Controls.Add(Me.LinkLabel2)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TextBoxLoginCount)
        Me.Controls.Add(Me.ButtonRunninStatus)
        Me.Controls.Add(Me.ButtonInternetStatus)
        Me.Controls.Add(Me.ButtonResetLogincount)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.checkboxAutorun)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.RichTextBoxHTTPresponse)
        Me.Controls.Add(Me.ButtonStartStop)
        Me.Controls.Add(Me.TextBoxPassword)
        Me.Controls.Add(Me.TextBoxEmail)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.ComboBoxAcctype)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form1"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.Text = "BT Wi-Fi Autologin Service"
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LinkLabel2 As LinkLabel
    Friend WithEvents Label8 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents TextBoxLoginCount As TextBox
    Friend WithEvents ButtonRunninStatus As Button
    Friend WithEvents ButtonInternetStatus As Button
    Friend WithEvents ButtonResetLogincount As Button
    Friend WithEvents Label7 As Label
    Friend WithEvents checkboxAutorun As CheckBox
    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents Label4 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents RichTextBoxHTTPresponse As RichTextBox
    Friend WithEvents ButtonStartStop As Button
    Friend WithEvents TextBoxPassword As TextBox
    Friend WithEvents TextBoxEmail As TextBox
    Friend WithEvents contextExit As ToolStripMenuItem
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents contextOpen As ToolStripMenuItem
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents NotifyIcon1 As NotifyIcon
    Friend WithEvents ComboBoxAcctype As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents ButtonAbout As Button
End Class
