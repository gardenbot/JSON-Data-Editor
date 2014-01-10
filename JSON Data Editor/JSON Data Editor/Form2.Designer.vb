<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLoadJSON
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
        Me.txtJSON_string = New System.Windows.Forms.TextBox()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'txtJSON_string
        '
        Me.txtJSON_string.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtJSON_string.Location = New System.Drawing.Point(2, 4)
        Me.txtJSON_string.Multiline = True
        Me.txtJSON_string.Name = "txtJSON_string"
        Me.txtJSON_string.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtJSON_string.Size = New System.Drawing.Size(550, 288)
        Me.txtJSON_string.TabIndex = 0
        '
        'btnAdd
        '
        Me.btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnAdd.Location = New System.Drawing.Point(174, 295)
        Me.btnAdd.MaximumSize = New System.Drawing.Size(205, 29)
        Me.btnAdd.MinimumSize = New System.Drawing.Size(205, 29)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(205, 29)
        Me.btnAdd.TabIndex = 1
        Me.btnAdd.Text = "Add JSON Object or Array"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'frmLoadJSON
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(552, 329)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.txtJSON_string)
        Me.Name = "frmLoadJSON"
        Me.Text = "Add JSON Object or Array"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtJSON_string As System.Windows.Forms.TextBox
    Friend WithEvents btnAdd As System.Windows.Forms.Button
End Class
