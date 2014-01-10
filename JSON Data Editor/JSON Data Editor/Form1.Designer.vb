<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.jsonTree = New System.Windows.Forms.TreeView()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.txtJSON_stringNoLinebreaks = New System.Windows.Forms.TextBox()
        Me.btnRemove = New System.Windows.Forms.Button()
        Me.valuePanel = New System.Windows.Forms.Panel()
        Me.radioValueFalse = New System.Windows.Forms.RadioButton()
        Me.radioValueTrue = New System.Windows.Forms.RadioButton()
        Me.radioValueNull = New System.Windows.Forms.RadioButton()
        Me.lblValue = New System.Windows.Forms.Label()
        Me.lblName = New System.Windows.Forms.Label()
        Me.txtValueName = New System.Windows.Forms.TextBox()
        Me.radioValueArray = New System.Windows.Forms.RadioButton()
        Me.txtValueString = New System.Windows.Forms.TextBox()
        Me.txtValueNumber = New System.Windows.Forms.TextBox()
        Me.radioValueObject = New System.Windows.Forms.RadioButton()
        Me.radioValueNumber = New System.Windows.Forms.RadioButton()
        Me.radioValueString = New System.Windows.Forms.RadioButton()
        Me.txtJSON_keyset = New System.Windows.Forms.TextBox()
        Me.tmrFlashKeyTextbox = New System.Windows.Forms.Timer(Me.components)
        Me.txtJSON_string = New System.Windows.Forms.TextBox()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.NewJSONToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ObjectToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ArrayToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LoadJSONToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FromStringToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FromFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveJSONToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteJSONToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.tabcontrolJSONhierarchy = New System.Windows.Forms.TabControl()
        Me.tabJSON_hierarchy = New System.Windows.Forms.TabPage()
        Me.tabJSON_text = New System.Windows.Forms.TabPage()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.timerShowAddJSON_menu = New System.Windows.Forms.Timer(Me.components)
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.LineShape1 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.valuePanel.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.tabcontrolJSONhierarchy.SuspendLayout()
        Me.tabJSON_hierarchy.SuspendLayout()
        Me.tabJSON_text.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.SuspendLayout()
        '
        'jsonTree
        '
        Me.jsonTree.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.jsonTree.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.jsonTree.FullRowSelect = True
        Me.jsonTree.HideSelection = False
        Me.jsonTree.Location = New System.Drawing.Point(3, 3)
        Me.jsonTree.Name = "jsonTree"
        Me.jsonTree.Size = New System.Drawing.Size(355, 462)
        Me.jsonTree.TabIndex = 1
        Me.jsonTree.TabStop = False
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(16, 210)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(90, 23)
        Me.btnAdd.TabIndex = 3
        Me.btnAdd.Text = "Add / Insert"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'txtJSON_stringNoLinebreaks
        '
        Me.txtJSON_stringNoLinebreaks.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtJSON_stringNoLinebreaks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtJSON_stringNoLinebreaks.Location = New System.Drawing.Point(3, 3)
        Me.txtJSON_stringNoLinebreaks.Multiline = True
        Me.txtJSON_stringNoLinebreaks.Name = "txtJSON_stringNoLinebreaks"
        Me.txtJSON_stringNoLinebreaks.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtJSON_stringNoLinebreaks.Size = New System.Drawing.Size(266, 115)
        Me.txtJSON_stringNoLinebreaks.TabIndex = 5
        Me.txtJSON_stringNoLinebreaks.TabStop = False
        '
        'btnRemove
        '
        Me.btnRemove.Location = New System.Drawing.Point(160, 210)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Size = New System.Drawing.Size(91, 23)
        Me.btnRemove.TabIndex = 4
        Me.btnRemove.Text = "Remove"
        Me.btnRemove.UseVisualStyleBackColor = True
        '
        'valuePanel
        '
        Me.valuePanel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.valuePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.valuePanel.Controls.Add(Me.radioValueFalse)
        Me.valuePanel.Controls.Add(Me.radioValueTrue)
        Me.valuePanel.Controls.Add(Me.btnAdd)
        Me.valuePanel.Controls.Add(Me.radioValueNull)
        Me.valuePanel.Controls.Add(Me.btnRemove)
        Me.valuePanel.Controls.Add(Me.lblValue)
        Me.valuePanel.Controls.Add(Me.lblName)
        Me.valuePanel.Controls.Add(Me.txtValueName)
        Me.valuePanel.Controls.Add(Me.radioValueArray)
        Me.valuePanel.Controls.Add(Me.txtValueString)
        Me.valuePanel.Controls.Add(Me.txtValueNumber)
        Me.valuePanel.Controls.Add(Me.radioValueObject)
        Me.valuePanel.Controls.Add(Me.radioValueNumber)
        Me.valuePanel.Controls.Add(Me.radioValueString)
        Me.valuePanel.Enabled = False
        Me.valuePanel.Location = New System.Drawing.Point(3, 3)
        Me.valuePanel.Name = "valuePanel"
        Me.valuePanel.Size = New System.Drawing.Size(276, 245)
        Me.valuePanel.TabIndex = 10
        '
        'radioValueFalse
        '
        Me.radioValueFalse.AutoSize = True
        Me.radioValueFalse.Location = New System.Drawing.Point(16, 141)
        Me.radioValueFalse.Name = "radioValueFalse"
        Me.radioValueFalse.Size = New System.Drawing.Size(50, 17)
        Me.radioValueFalse.TabIndex = 5
        Me.radioValueFalse.TabStop = True
        Me.radioValueFalse.Text = "False"
        Me.radioValueFalse.UseVisualStyleBackColor = True
        '
        'radioValueTrue
        '
        Me.radioValueTrue.AutoSize = True
        Me.radioValueTrue.Location = New System.Drawing.Point(16, 118)
        Me.radioValueTrue.Name = "radioValueTrue"
        Me.radioValueTrue.Size = New System.Drawing.Size(47, 17)
        Me.radioValueTrue.TabIndex = 4
        Me.radioValueTrue.TabStop = True
        Me.radioValueTrue.Text = "True"
        Me.radioValueTrue.UseVisualStyleBackColor = True
        '
        'radioValueNull
        '
        Me.radioValueNull.AutoSize = True
        Me.radioValueNull.Location = New System.Drawing.Point(16, 96)
        Me.radioValueNull.Name = "radioValueNull"
        Me.radioValueNull.Size = New System.Drawing.Size(43, 17)
        Me.radioValueNull.TabIndex = 3
        Me.radioValueNull.TabStop = True
        Me.radioValueNull.Text = "Null"
        Me.radioValueNull.UseVisualStyleBackColor = True
        '
        'lblValue
        '
        Me.lblValue.AutoSize = True
        Me.lblValue.Location = New System.Drawing.Point(3, 34)
        Me.lblValue.Name = "lblValue"
        Me.lblValue.Size = New System.Drawing.Size(54, 13)
        Me.lblValue.TabIndex = 9
        Me.lblValue.Text = "Pair value"
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.Location = New System.Drawing.Point(3, 10)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(113, 13)
        Me.lblName.TabIndex = 8
        Me.lblName.Text = "Pair Name/Key (string)"
        '
        'txtValueName
        '
        Me.txtValueName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtValueName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtValueName.Location = New System.Drawing.Point(125, 7)
        Me.txtValueName.Name = "txtValueName"
        Me.txtValueName.Size = New System.Drawing.Size(126, 20)
        Me.txtValueName.TabIndex = 0
        Me.txtValueName.Text = "keyname 0"
        '
        'radioValueArray
        '
        Me.radioValueArray.AutoSize = True
        Me.radioValueArray.Location = New System.Drawing.Point(16, 164)
        Me.radioValueArray.Name = "radioValueArray"
        Me.radioValueArray.Size = New System.Drawing.Size(49, 17)
        Me.radioValueArray.TabIndex = 6
        Me.radioValueArray.Text = "Array"
        Me.radioValueArray.UseVisualStyleBackColor = True
        '
        'txtValueString
        '
        Me.txtValueString.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtValueString.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtValueString.Location = New System.Drawing.Point(84, 73)
        Me.txtValueString.Multiline = True
        Me.txtValueString.Name = "txtValueString"
        Me.txtValueString.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtValueString.Size = New System.Drawing.Size(182, 128)
        Me.txtValueString.TabIndex = 2
        Me.txtValueString.Text = "this is a string."
        '
        'txtValueNumber
        '
        Me.txtValueNumber.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtValueNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtValueNumber.Location = New System.Drawing.Point(84, 49)
        Me.txtValueNumber.Name = "txtValueNumber"
        Me.txtValueNumber.Size = New System.Drawing.Size(167, 20)
        Me.txtValueNumber.TabIndex = 1
        Me.txtValueNumber.Text = "1234e-3"
        Me.txtValueNumber.Visible = False
        '
        'radioValueObject
        '
        Me.radioValueObject.AutoSize = True
        Me.radioValueObject.Location = New System.Drawing.Point(16, 187)
        Me.radioValueObject.Name = "radioValueObject"
        Me.radioValueObject.Size = New System.Drawing.Size(56, 17)
        Me.radioValueObject.TabIndex = 7
        Me.radioValueObject.Text = "Object"
        Me.radioValueObject.UseVisualStyleBackColor = True
        '
        'radioValueNumber
        '
        Me.radioValueNumber.AutoSize = True
        Me.radioValueNumber.Location = New System.Drawing.Point(16, 50)
        Me.radioValueNumber.Name = "radioValueNumber"
        Me.radioValueNumber.Size = New System.Drawing.Size(62, 17)
        Me.radioValueNumber.TabIndex = 1
        Me.radioValueNumber.Text = "Number"
        Me.radioValueNumber.UseVisualStyleBackColor = True
        '
        'radioValueString
        '
        Me.radioValueString.AutoSize = True
        Me.radioValueString.Checked = True
        Me.radioValueString.Location = New System.Drawing.Point(16, 73)
        Me.radioValueString.Name = "radioValueString"
        Me.radioValueString.Size = New System.Drawing.Size(52, 17)
        Me.radioValueString.TabIndex = 2
        Me.radioValueString.TabStop = True
        Me.radioValueString.Text = "String"
        Me.radioValueString.UseVisualStyleBackColor = True
        '
        'txtJSON_keyset
        '
        Me.txtJSON_keyset.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtJSON_keyset.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtJSON_keyset.Location = New System.Drawing.Point(3, 19)
        Me.txtJSON_keyset.Multiline = True
        Me.txtJSON_keyset.Name = "txtJSON_keyset"
        Me.txtJSON_keyset.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtJSON_keyset.Size = New System.Drawing.Size(270, 38)
        Me.txtJSON_keyset.TabIndex = 11
        Me.txtJSON_keyset.TabStop = False
        '
        'tmrFlashKeyTextbox
        '
        Me.tmrFlashKeyTextbox.Interval = 500
        '
        'txtJSON_string
        '
        Me.txtJSON_string.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtJSON_string.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtJSON_string.Location = New System.Drawing.Point(3, 3)
        Me.txtJSON_string.Multiline = True
        Me.txtJSON_string.Name = "txtJSON_string"
        Me.txtJSON_string.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtJSON_string.Size = New System.Drawing.Size(266, 115)
        Me.txtJSON_string.TabIndex = 14
        Me.txtJSON_string.TabStop = False
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewJSONToolStripMenuItem, Me.LoadJSONToolStripMenuItem, Me.SaveJSONToolStripMenuItem, Me.ToolStripMenuItem1, Me.DeleteJSONToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(651, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.TabStop = True
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'NewJSONToolStripMenuItem
        '
        Me.NewJSONToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ObjectToolStripMenuItem, Me.ArrayToolStripMenuItem})
        Me.NewJSONToolStripMenuItem.Name = "NewJSONToolStripMenuItem"
        Me.NewJSONToolStripMenuItem.Size = New System.Drawing.Size(74, 20)
        Me.NewJSONToolStripMenuItem.Text = "New JSON"
        '
        'ObjectToolStripMenuItem
        '
        Me.ObjectToolStripMenuItem.Name = "ObjectToolStripMenuItem"
        Me.ObjectToolStripMenuItem.Size = New System.Drawing.Size(109, 22)
        Me.ObjectToolStripMenuItem.Text = "Object"
        '
        'ArrayToolStripMenuItem
        '
        Me.ArrayToolStripMenuItem.Name = "ArrayToolStripMenuItem"
        Me.ArrayToolStripMenuItem.Size = New System.Drawing.Size(109, 22)
        Me.ArrayToolStripMenuItem.Text = "Array"
        '
        'LoadJSONToolStripMenuItem
        '
        Me.LoadJSONToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FromStringToolStripMenuItem, Me.FromFileToolStripMenuItem})
        Me.LoadJSONToolStripMenuItem.Name = "LoadJSONToolStripMenuItem"
        Me.LoadJSONToolStripMenuItem.Size = New System.Drawing.Size(76, 20)
        Me.LoadJSONToolStripMenuItem.Text = "Load JSON"
        '
        'FromStringToolStripMenuItem
        '
        Me.FromStringToolStripMenuItem.Name = "FromStringToolStripMenuItem"
        Me.FromStringToolStripMenuItem.Size = New System.Drawing.Size(142, 22)
        Me.FromStringToolStripMenuItem.Text = "From String.."
        '
        'FromFileToolStripMenuItem
        '
        Me.FromFileToolStripMenuItem.Name = "FromFileToolStripMenuItem"
        Me.FromFileToolStripMenuItem.Size = New System.Drawing.Size(142, 22)
        Me.FromFileToolStripMenuItem.Text = "From File.."
        '
        'SaveJSONToolStripMenuItem
        '
        Me.SaveJSONToolStripMenuItem.Enabled = False
        Me.SaveJSONToolStripMenuItem.Name = "SaveJSONToolStripMenuItem"
        Me.SaveJSONToolStripMenuItem.Size = New System.Drawing.Size(74, 20)
        Me.SaveJSONToolStripMenuItem.Text = "Save JSON"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Enabled = False
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(106, 20)
        Me.ToolStripMenuItem1.Text = "                             "
        '
        'DeleteJSONToolStripMenuItem
        '
        Me.DeleteJSONToolStripMenuItem.Enabled = False
        Me.DeleteJSONToolStripMenuItem.Name = "DeleteJSONToolStripMenuItem"
        Me.DeleteJSONToolStripMenuItem.Size = New System.Drawing.Size(83, 20)
        Me.DeleteJSONToolStripMenuItem.Text = "Delete JSON"
        '
        'tabcontrolJSONhierarchy
        '
        Me.tabcontrolJSONhierarchy.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabcontrolJSONhierarchy.Controls.Add(Me.tabJSON_hierarchy)
        Me.tabcontrolJSONhierarchy.Controls.Add(Me.tabJSON_text)
        Me.tabcontrolJSONhierarchy.Location = New System.Drawing.Point(3, 3)
        Me.tabcontrolJSONhierarchy.Name = "tabcontrolJSONhierarchy"
        Me.tabcontrolJSONhierarchy.SelectedIndex = 0
        Me.tabcontrolJSONhierarchy.Size = New System.Drawing.Size(279, 147)
        Me.tabcontrolJSONhierarchy.TabIndex = 16
        '
        'tabJSON_hierarchy
        '
        Me.tabJSON_hierarchy.Controls.Add(Me.txtJSON_string)
        Me.tabJSON_hierarchy.Location = New System.Drawing.Point(4, 22)
        Me.tabJSON_hierarchy.Name = "tabJSON_hierarchy"
        Me.tabJSON_hierarchy.Padding = New System.Windows.Forms.Padding(3)
        Me.tabJSON_hierarchy.Size = New System.Drawing.Size(271, 121)
        Me.tabJSON_hierarchy.TabIndex = 0
        Me.tabJSON_hierarchy.Text = "JSON Hierarchy"
        Me.tabJSON_hierarchy.UseVisualStyleBackColor = True
        '
        'tabJSON_text
        '
        Me.tabJSON_text.Controls.Add(Me.txtJSON_stringNoLinebreaks)
        Me.tabJSON_text.Location = New System.Drawing.Point(4, 22)
        Me.tabJSON_text.Name = "tabJSON_text"
        Me.tabJSON_text.Padding = New System.Windows.Forms.Padding(3)
        Me.tabJSON_text.Size = New System.Drawing.Size(271, 121)
        Me.tabJSON_text.TabIndex = 1
        Me.tabJSON_text.Text = "JSON Text (no linebreaks)"
        Me.tabJSON_text.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 3)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(167, 13)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "JSON Keyset for Selected Object:"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.BackColor = System.Drawing.Color.Maroon
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 30)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.BackColor = System.Drawing.SystemColors.Control
        Me.SplitContainer1.Panel1.Controls.Add(Me.jsonTree)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.BackColor = System.Drawing.SystemColors.Control
        Me.SplitContainer1.Panel2.Controls.Add(Me.SplitContainer2)
        Me.SplitContainer1.Panel2.Controls.Add(Me.valuePanel)
        Me.SplitContainer1.Size = New System.Drawing.Size(651, 472)
        Me.SplitContainer1.SplitterDistance = 361
        Me.SplitContainer1.TabIndex = 18
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer2.BackColor = System.Drawing.Color.Maroon
        Me.SplitContainer2.Location = New System.Drawing.Point(3, 254)
        Me.SplitContainer2.Name = "SplitContainer2"
        Me.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.BackColor = System.Drawing.SystemColors.Control
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label2)
        Me.SplitContainer2.Panel1.Controls.Add(Me.txtJSON_keyset)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.BackColor = System.Drawing.SystemColors.Control
        Me.SplitContainer2.Panel2.Controls.Add(Me.tabcontrolJSONhierarchy)
        Me.SplitContainer2.Size = New System.Drawing.Size(276, 220)
        Me.SplitContainer2.SplitterDistance = 63
        Me.SplitContainer2.TabIndex = 18
        '
        'timerShowAddJSON_menu
        '
        Me.timerShowAddJSON_menu.Enabled = True
        Me.timerShowAddJSON_menu.Interval = 10
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.LineShape1})
        Me.ShapeContainer1.Size = New System.Drawing.Size(651, 506)
        Me.ShapeContainer1.TabIndex = 19
        Me.ShapeContainer1.TabStop = False
        '
        'LineShape1
        '
        Me.LineShape1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LineShape1.BorderColor = System.Drawing.Color.Maroon
        Me.LineShape1.BorderWidth = 4
        Me.LineShape1.Name = "LineShape1"
        Me.LineShape1.X1 = 3
        Me.LineShape1.X2 = 643
        Me.LineShape1.Y1 = 25
        Me.LineShape1.Y2 = 25
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(651, 506)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.ShapeContainer1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Form1"
        Me.Text = "JSON Data Editor"
        Me.valuePanel.ResumeLayout(False)
        Me.valuePanel.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.tabcontrolJSONhierarchy.ResumeLayout(False)
        Me.tabJSON_hierarchy.ResumeLayout(False)
        Me.tabJSON_hierarchy.PerformLayout()
        Me.tabJSON_text.ResumeLayout(False)
        Me.tabJSON_text.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.PerformLayout()
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents jsonTree As System.Windows.Forms.TreeView
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents txtJSON_stringNoLinebreaks As System.Windows.Forms.TextBox
    Friend WithEvents btnRemove As System.Windows.Forms.Button
    Friend WithEvents valuePanel As System.Windows.Forms.Panel
    Friend WithEvents radioValueFalse As System.Windows.Forms.RadioButton
    Friend WithEvents radioValueTrue As System.Windows.Forms.RadioButton
    Friend WithEvents radioValueNull As System.Windows.Forms.RadioButton
    Friend WithEvents lblValue As System.Windows.Forms.Label
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents txtValueName As System.Windows.Forms.TextBox
    Friend WithEvents radioValueArray As System.Windows.Forms.RadioButton
    Friend WithEvents txtValueString As System.Windows.Forms.TextBox
    Friend WithEvents txtValueNumber As System.Windows.Forms.TextBox
    Friend WithEvents radioValueObject As System.Windows.Forms.RadioButton
    Friend WithEvents radioValueNumber As System.Windows.Forms.RadioButton
    Friend WithEvents radioValueString As System.Windows.Forms.RadioButton
    Friend WithEvents txtJSON_keyset As System.Windows.Forms.TextBox
    Friend WithEvents tmrFlashKeyTextbox As System.Windows.Forms.Timer
    Friend WithEvents txtJSON_string As System.Windows.Forms.TextBox
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents NewJSONToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ObjectToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ArrayToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LoadJSONToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FromStringToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FromFileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveJSONToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteJSONToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tabcontrolJSONhierarchy As System.Windows.Forms.TabControl
    Friend WithEvents tabJSON_hierarchy As System.Windows.Forms.TabPage
    Friend WithEvents tabJSON_text As System.Windows.Forms.TabPage
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents timerShowAddJSON_menu As System.Windows.Forms.Timer
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents LineShape1 As Microsoft.VisualBasic.PowerPacks.LineShape

End Class
