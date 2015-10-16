<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Settingsvb
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
        Me.GamePathTextBox = New System.Windows.Forms.TextBox()
        Me.ModspathTextBox = New System.Windows.Forms.TextBox()
        Me.ModsPathButton = New System.Windows.Forms.Button()
        Me.GameExeButton = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.FBD = New System.Windows.Forms.FolderBrowserDialog()
        Me.OK = New System.Windows.Forms.Button()
        Me.CANCEL = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'GamePathTextBox
        '
        Me.GamePathTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GamePathTextBox.Location = New System.Drawing.Point(77, 12)
        Me.GamePathTextBox.Name = "GamePathTextBox"
        Me.GamePathTextBox.Size = New System.Drawing.Size(265, 20)
        Me.GamePathTextBox.TabIndex = 0
        '
        'ModspathTextBox
        '
        Me.ModspathTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ModspathTextBox.Location = New System.Drawing.Point(77, 60)
        Me.ModspathTextBox.Name = "ModspathTextBox"
        Me.ModspathTextBox.Size = New System.Drawing.Size(265, 20)
        Me.ModspathTextBox.TabIndex = 1
        '
        'ModsPathButton
        '
        Me.ModsPathButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ModsPathButton.Location = New System.Drawing.Point(348, 57)
        Me.ModsPathButton.Name = "ModsPathButton"
        Me.ModsPathButton.Size = New System.Drawing.Size(75, 23)
        Me.ModsPathButton.TabIndex = 2
        Me.ModsPathButton.Text = "Browse"
        Me.ModsPathButton.UseVisualStyleBackColor = True
        '
        'GameExeButton
        '
        Me.GameExeButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GameExeButton.Location = New System.Drawing.Point(348, 12)
        Me.GameExeButton.Name = "GameExeButton"
        Me.GameExeButton.Size = New System.Drawing.Size(75, 23)
        Me.GameExeButton.TabIndex = 3
        Me.GameExeButton.Text = "Browse"
        Me.GameExeButton.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Game Exe:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 62)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Mods Path:"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        Me.OpenFileDialog1.Filter = "Windows Executable|*.exe"
        '
        'FBD
        '
        Me.FBD.SelectedPath = "C:\Users\Sturle\Documents\Paradox Interactive\Europa Universalis IV\mod"
        Me.FBD.ShowNewFolderButton = False
        '
        'OK
        '
        Me.OK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.OK.Location = New System.Drawing.Point(12, 106)
        Me.OK.Name = "OK"
        Me.OK.Size = New System.Drawing.Size(171, 39)
        Me.OK.TabIndex = 6
        Me.OK.Text = "OK"
        Me.OK.UseVisualStyleBackColor = True
        '
        'CANCEL
        '
        Me.CANCEL.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CANCEL.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.CANCEL.Location = New System.Drawing.Point(263, 106)
        Me.CANCEL.Name = "CANCEL"
        Me.CANCEL.Size = New System.Drawing.Size(160, 39)
        Me.CANCEL.TabIndex = 7
        Me.CANCEL.Text = "Cancel"
        Me.CANCEL.UseVisualStyleBackColor = True
        '
        'Settingsvb
        '
        Me.AcceptButton = Me.OK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.CANCEL
        Me.ClientSize = New System.Drawing.Size(435, 157)
        Me.Controls.Add(Me.CANCEL)
        Me.Controls.Add(Me.OK)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GameExeButton)
        Me.Controls.Add(Me.ModsPathButton)
        Me.Controls.Add(Me.ModspathTextBox)
        Me.Controls.Add(Me.GamePathTextBox)
        Me.Name = "Settingsvb"
        Me.Text = "Settings"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GamePathTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ModspathTextBox As System.Windows.Forms.TextBox
    Friend WithEvents GameExeButton As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents FBD As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents OK As System.Windows.Forms.Button
    Friend WithEvents CANCEL As System.Windows.Forms.Button
    Friend WithEvents ModsPathButton As System.Windows.Forms.Button
End Class
