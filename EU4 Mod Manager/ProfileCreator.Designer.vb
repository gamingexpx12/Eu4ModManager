<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProfileCreator
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ProfileTextBox = New System.Windows.Forms.TextBox()
        Me.ModList = New System.Windows.Forms.CheckedListBox()
        Me.OkButton = New System.Windows.Forms.Button()
        Me.CancelProfileButton = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.ProfileTextBox)
        Me.Panel1.Controls.Add(Me.ModList)
        Me.Panel1.Location = New System.Drawing.Point(13, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(307, 356)
        Me.Panel1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(33, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Mods"
        '
        'ProfileTextBox
        '
        Me.ProfileTextBox.Location = New System.Drawing.Point(3, 3)
        Me.ProfileTextBox.Name = "ProfileTextBox"
        Me.ProfileTextBox.Size = New System.Drawing.Size(301, 20)
        Me.ProfileTextBox.TabIndex = 2
        Me.ProfileTextBox.Text = "Profile Name"
        '
        'ModList
        '
        Me.ModList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ModList.FormattingEnabled = True
        Me.ModList.Location = New System.Drawing.Point(3, 48)
        Me.ModList.Name = "ModList"
        Me.ModList.Size = New System.Drawing.Size(301, 304)
        Me.ModList.TabIndex = 1
        '
        'OkButton
        '
        Me.OkButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.OkButton.Location = New System.Drawing.Point(13, 375)
        Me.OkButton.Name = "OkButton"
        Me.OkButton.Size = New System.Drawing.Size(131, 34)
        Me.OkButton.TabIndex = 1
        Me.OkButton.Text = "OK"
        Me.OkButton.UseVisualStyleBackColor = True
        '
        'CancelProfileButton
        '
        Me.CancelProfileButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CancelProfileButton.Location = New System.Drawing.Point(186, 374)
        Me.CancelProfileButton.Name = "CancelProfileButton"
        Me.CancelProfileButton.Size = New System.Drawing.Size(131, 34)
        Me.CancelProfileButton.TabIndex = 2
        Me.CancelProfileButton.Text = "Cancel"
        Me.CancelProfileButton.UseVisualStyleBackColor = True
        '
        'ProfileCreator
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(332, 421)
        Me.Controls.Add(Me.CancelProfileButton)
        Me.Controls.Add(Me.OkButton)
        Me.Controls.Add(Me.Panel1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ProfileCreator"
        Me.Text = "Profile Creator"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ModList As System.Windows.Forms.CheckedListBox
    Friend WithEvents ProfileTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents OkButton As System.Windows.Forms.Button
    Friend WithEvents CancelProfileButton As System.Windows.Forms.Button
End Class
