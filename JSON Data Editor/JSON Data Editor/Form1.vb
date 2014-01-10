Imports Newtonsoft.Json
Imports System.Text.RegularExpressions
Imports Newtonsoft.Json.Linq
Public Class Form1
    'needed variables
    Dim JSON_parentObject(0 To 0) As Newtonsoft.Json.Linq.JObject
    Dim JSON_parentArray(0 To 0) As Newtonsoft.Json.Linq.JArray
    Dim JSON_objectNameList(0 To 0) As String 'store all names of json objects added, index corrolates with the actual object index in the json object array
    Dim JSON_arrayNameList(0 To 0) As String  'store all names of json array added, index corrolates with the actual array index in the json array array
    Dim selectedJSON_topParentName As String = "" 'very top parent of this selected node
    Dim selectedJSON_topParentType As String = "" 'very top parent of this selected node
    Dim selectedJSON_directParentName As String = ""  'the direct parent of this selected node
    Dim selectedJSON_directParentType As String = ""  'the direct parent of this selected node
    Dim selectedJSON_valueType As String = ""
    Dim selectedJSON_treeNamePath As String = ""
    'handle form load
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
    'open dropdownmenu and select first item "add JSON" -> "object"
    Private Sub timerShowAddJSON_menu_Tick(sender As System.Object, e As System.EventArgs) Handles timerShowAddJSON_menu.Tick
        NewJSONToolStripMenuItem.ShowDropDown()
        ObjectToolStripMenuItem.Select()
        timerShowAddJSON_menu.Enabled = False
    End Sub
    'add new JSON object to the project
    Private Sub ObjectToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ObjectToolStripMenuItem.Click
        'request a name for this new JSON Object
        Dim r As String = RequestNameForAddObject()
        'if a name is not provided then stop
        If r = "" Then Exit Sub
        'add name to object name list
        addElementToJSON_objectNameList(r)

        'this name is fine, add this new object to the json tree
        AddNewJSON_object(r)
        'enabled value panel
        enableValuePanel()
        DeleteJSONToolStripMenuItem.Enabled = True
        SaveJSONToolStripMenuItem.Enabled = True
        jsonTree.Focus()
    End Sub
    Private Sub ArrayToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ArrayToolStripMenuItem.Click
        'request a name for this new JSON Object
        Dim r As String = RequestNameForAddArray()
        'if a name is not provided then stop
        If r = "" Then Exit Sub
        'add this array name to the array  name list
        addElementToJSON_arrayNameList(r)
        'this name is fine, add this new object to the json tree
        AddNewJSON_array(r)
        'enabled value panel
        enableValuePanel()
        DeleteJSONToolStripMenuItem.Enabled = True
        SaveJSONToolStripMenuItem.Enabled = True
        jsonTree.Focus()
    End Sub
    Public Sub addElementToJSON_objectNameList(ByVal r As String)
        ReDim Preserve JSON_objectNameList(JSON_objectNameList.Length)
        JSON_objectNameList(JSON_objectNameList.Length - 2) = r
    End Sub
    Public Sub addElementToJSON_arrayNameList(ByVal r As String)
        ReDim Preserve JSON_arrayNameList(JSON_arrayNameList.Length)
        JSON_arrayNameList(JSON_arrayNameList.Length - 2) = r
    End Sub
    'ask the user what to name their new object or array.
    Public Function RequestNameForAddObject() As String

        'declare r and use it to determine if the input was canceled.
        Dim r As String = "stuff"
        Dim inputName As String = requestDefaultParentObjectName()
        'If inputName = "" then inputName = "JSON object 0"
        While r <> ""
            'produce message box with an input
            r = InputBox("Please name this JSON object:", "JSON Object Name? (cannot use: '\')", inputName)

            'return if canceled.
            If r = "" Then Return ""

            'check if r contains '\'
            If r.IndexOf("\") > -1 Then
                inputName = r
                MsgBox("cannot use the backslash ('\') character")
                Continue While
            End If


            'check if this name is already used
            'loop through each name stored
            For Each n In JSON_objectNameList
                'if found then try again
                If r = n Then
                    'skip the rest of this while loop
                    inputName = r
                    MsgBox("This name is in use, please pick another one.")
                    Continue While
                End If
            Next
            For Each n In JSON_arrayNameList
                'if found then try again
                If r = n Then
                    'skip the rest of this while loop
                    inputName = r
                    MsgBox("This name is in use, please pick another one.")
                    Continue While
                End If
            Next
            'this name is fine, return it.
            Return r
        End While

        Return ""
    End Function
    Public Function RequestNameForAddArray() As String
        'declare r and use it to determine if the input was canceled.
        Dim r As String = "stuff"
        Dim inputName As String = requestDefaultParentArrayName()
        While r <> ""
            'produce message box with an input
            r = InputBox("Please name this JSON array:", "JSON Array Name? (cannot use: '\')", inputName)

            'return if canceled.
            If r = "" Then Return ""

            'check if r contains '\'
            If r.IndexOf("\") > -1 Then
                inputName = r
                MsgBox("cannot use the backslash ('\') character")
                Continue While
            End If


            'check if this name is already used
            'loop through each name stored
            For Each n In JSON_objectNameList
                'if found then try again
                If r = n Then
                    'skip the rest of this while loop
                    inputName = r
                    MsgBox("This name is in use, please pick another one.")
                    Continue While
                End If
            Next
            For Each n In JSON_arrayNameList
                'if found then try again
                If r = n Then
                    'skip the rest of this while loop
                    inputName = r
                    MsgBox("This name is in use, please pick another one.")
                    Continue While
                End If
            Next
            'this name is fine, return it.
            Return r
        End While

        Return ""
    End Function
    'create a new json object or array and add it to the json data tree.
    Private Sub AddNewJSON_object(ByVal r As String)
        'redim length of this object to be one more element long.
        ReDim Preserve JSON_parentObject(JSON_parentObject.Length)

        'add to json object array: JSON_parentObject(JSON_parentObject.length - 2)
        JSON_parentObject(JSON_parentObject.Length - 2) = New Newtonsoft.Json.Linq.JObject

        'add to tree
        Dim jsonTreeNode As TreeNode
        Dim jsonTreeNodeChild As TreeNode
        Dim nodeKey As String = "[object][object]" & r
        jsonTreeNode = jsonTree.Nodes.Add(nodeKey, r)
        jsonTreeNode.Nodes.Add("{")
        nodeKey = "[object][undefined]"
        jsonTreeNodeChild = jsonTreeNode.Nodes.Add(nodeKey, "add member..")
        jsonTreeNode.Nodes.Add("}")
        jsonTreeNode.Expand()
        jsonTree.SelectedNode = jsonTreeNodeChild




    End Sub
    Private Sub AddNewJSON_array(ByVal r As String)

        'redim length of this object to be one more element long.
        ReDim Preserve JSON_parentArray(JSON_parentArray.Length)

        'add to json object array: JSON_parentObject(JSON_parentObject.length - 2)
        JSON_parentArray(JSON_parentArray.Length - 2) = New Newtonsoft.Json.Linq.JArray

        Dim jsonTreeNode As TreeNode
        Dim jsonTreeNodeChild As TreeNode
        Dim nodeKey As String = "[array][array]" & r
        jsonTreeNode = jsonTree.Nodes.Add(nodeKey, r)
        jsonTreeNode.Nodes.Add("[")
        nodeKey = "[array][undefined]"
        jsonTreeNodeChild = jsonTreeNode.Nodes.Add(nodeKey, "add element..")
        jsonTreeNode.Nodes.Add("]")
        jsonTreeNode.Expand()
        jsonTree.SelectedNode = jsonTreeNodeChild


    End Sub
    Public Sub addLoadedJSON_object(ByRef JSON_object As JObject)
        'redim length of this object to be one more element long.
        ReDim Preserve JSON_parentObject(JSON_parentObject.Length)

        'add to json object array: JSON_parentObject(JSON_parentObject.length - 2)
        JSON_parentObject(JSON_parentObject.Length - 2) = New Newtonsoft.Json.Linq.JObject
        JSON_parentObject(JSON_parentObject.Length - 2) = JSON_object.DeepClone

    End Sub
    Public Sub addLoadedJSON_array(ByRef JSON_array As JArray)
        'redim length of this object to be one more element long.
        ReDim Preserve JSON_parentArray(JSON_parentArray.Length)

        'add to json object array: JSON_parentObject(JSON_parentObject.length - 2)
        JSON_parentArray(JSON_parentArray.Length - 2) = New Newtonsoft.Json.Linq.JArray
        JSON_parentArray(JSON_parentArray.Length - 2) = JSON_array.DeepClone
    End Sub
    Sub addNodeToJSON_tree(ByRef node As TreeNode)
        Dim tempNode As TreeNode = jsonTree.Nodes(jsonTree.Nodes.Add(node))
        tempNode.ExpandAll()
        jsonTree.SelectedNode = tempNode

    End Sub
    'enable the value panel
    Public Sub enableValuePanel()
        valuePanel.Enabled = True
    End Sub
    'disable the value panel
    Private Sub disableValuePanel()
        valuePanel.Enabled = False
    End Sub
    'handle json data tree being selected / clicked
    Private Sub jsonTree_AfterSelect(sender As System.Object, e As System.Windows.Forms.TreeViewEventArgs) Handles jsonTree.AfterSelect
        Dim oldSelectedJSON_topParentName As String = selectedJSON_topParentName


        'update type and name of top parent and direct parent.
        updateSelectedJSON_topParentName()
        updateSelectedJSON_topParentType()
        updateSelectedJSON_directParentName()
        updateSelectedJSON_directParentType()
        updateSelectedJSON_valueType()
        updateSelectedJSON_treeNamePath()
        updateTextboxJSON_keyset()
        updateTextboxJSON_string()

        Select Case selectedJSON_directParentType
            Case "object"
                txtValueName.Enabled = True
            Case "array"
                txtValueName.Enabled = False
        End Select



        'txtJSON_stringNoLinebreaks.Text = "top parent type: " & selectedJSON_directParentType & vbNewLine
        'txtJSON_stringNoLinebreaks.Text &= "top parent name: " & selectedJSON_directParentType & vbNewLine & vbNewLine
        'txtJSON_stringNoLinebreaks.Text &= "direct parent type: " & selectedJSON_directParentType & vbNewLine
        'txtJSON_stringNoLinebreaks.Text &= "direct parent name: " & selectedJSON_directParentName & vbNewLine
        'txtJSON_stringNoLinebreaks.Text &= "selected type: " & selectedJSON_valueType




    End Sub
    'get the parent type of this json structure
    Sub updateSelectedJSON_topParentName()
        selectedJSON_topParentName = jsonTree.SelectedNode.FullPath.Split("\")(0)
    End Sub
    Sub updateSelectedJSON_topParentType()
        updateSelectedJSON_treeNamePath()
        Dim s = selectedJSON_treeNamePath
        Dim rgx As New Regex("\[[^\]]*\]") 'match [anything]
        Dim matches As MatchCollection = rgx.Matches(s)
        If matches.Count < 1 Then
            MsgBox("some type of error in sub updateSelectedJSON_topParentType()")
            Exit Sub
        End If
        Select Case matches(0).ToString
            Case "[object]"
                selectedJSON_topParentType = "object"
            Case "[array]"
                selectedJSON_topParentType = "array"
        End Select

    End Sub
    Sub updateSelectedJSON_directParentName()
        'check depth
        Dim d As Integer = jsonTree.SelectedNode.Level

        'if depth is less than 2 than use TopParentName
        If d < 2 Then
            updateSelectedJSON_topParentName()
            selectedJSON_directParentName = selectedJSON_topParentName
            Exit Sub
        End If
        selectedJSON_directParentName = jsonTree.SelectedNode.Parent.Name

    End Sub
    Sub updateSelectedJSON_directParentType()
        'check depth
        Dim d As Integer = jsonTree.SelectedNode.Level

        'if depth is less than 2 than use TopParentType
        If d < 2 Then
            updateSelectedJSON_topParentType()
            selectedJSON_directParentType = selectedJSON_topParentType
            Exit Sub
        End If
        If jsonTree.SelectedNode.Parent.Nodes(0).Text = "{" Then
            selectedJSON_directParentType = "object"
        ElseIf jsonTree.SelectedNode.Parent.Nodes(0).Text = "[" Then
            selectedJSON_directParentType = "array"
        End If

    End Sub
    Sub updateSelectedJSON_valueType()
        If radioValueArray.Checked = True Then
            selectedJSON_valueType = "array"
        ElseIf radioValueFalse.Checked = True Then
            selectedJSON_valueType = "false"
        ElseIf radioValueNull.Checked = True Then
            selectedJSON_valueType = "null"
        ElseIf radioValueNumber.Checked = True Then
            selectedJSON_valueType = "number"
        ElseIf radioValueObject.Checked = True Then
            selectedJSON_valueType = "object"
        ElseIf radioValueString.Checked = True Then
            selectedJSON_valueType = "string"
        ElseIf radioValueTrue.Checked = True Then
            selectedJSON_valueType = "true"
        End If
        'txtJSON_stringNoLinebreaks.Text = "top parent type: " & selectedJSON_directParentType & vbNewLine
        'txtJSON_stringNoLinebreaks.Text &= "top parent name: " & selectedJSON_directParentType & vbNewLine & vbNewLine
        'txtJSON_stringNoLinebreaks.Text &= "direct parent type: " & selectedJSON_directParentType & vbNewLine
        'txtJSON_stringNoLinebreaks.Text &= "direct parent name: " & selectedJSON_directParentName & vbNewLine & vbNewLine
        'txtJSON_stringNoLinebreaks.Text &= "selected type (radio buttons): " & selectedJSON_valueType & vbNewLine
        'If Not IsNothing(jsonTree.SelectedNode) Then
        '    txtJSON_stringNoLinebreaks.Text &= "selected tree node name: " & jsonTree.SelectedNode.Name
        'End If
    End Sub
    Sub updateSelectedJSON_treeNamePath()
        selectedJSON_treeNamePath = returnSelectedJSON_treeNamePath()
        'Dim s As String = selectedJSON_treeNamePath

        txtJSON_keyset.Text = selectedJSON_treeNamePath.Replace("\", "\" & vbNewLine)

    End Sub
    Sub updateTextboxJSON_keyset()
        updateSelectedJSON_treeNamePath()
        If IsNothing(jsonTree.SelectedNode) Then
            txtJSON_keyset.Text = ""
            Exit Sub
        End If
        Dim namePath() As String = selectedJSON_treeNamePath.Split("\")
        Dim rgx As New Regex("\[[^\]]*\]")
        Dim matches As MatchCollection
        Dim a As String = ""
        Dim b As String = ""
        Dim L As Integer = -1
        Dim key As String = ""
        'remove first element from string array
        If namePath.Length < 2 Then
            txtJSON_keyset.Text = ""
            Exit Sub
        End If
        removeElementFromStringArrayByIndex(namePath, 0)
        Dim keySet As String = ""
        For Each n In namePath
            matches = rgx.Matches(n)
            If matches.Count < 1 Then Continue For
            a = matches(0).ToString
            b = matches(1).ToString
            L = a.Length + b.Length
            key = n.Substring(L, n.Length - L)
            Select Case a
                Case "[object]"
                    If b <> "[undefined]" Then
                        keySet &= "(""" & key & """)"
                    End If
                Case "[array]"
                    If b <> "[undefined]" Then
                        keySet &= "(" & key & ")"
                    End If

            End Select
        Next
        txtJSON_keyset.Text = keySet
    End Sub
    Sub updateTextboxJSON_string()
        If selectedJSON_topParentType = "" Then Exit Sub
        Dim i As Integer
        If selectedJSON_topParentType = "object" Then
            i = returnIndexOfParentObject()
            If i < 0 Then
                Exit Sub
            End If
            Dim jsonObject As Newtonsoft.Json.Linq.JObject = JSON_parentObject(i)

            txtJSON_string.Text = jsonObject.ToString
            txtJSON_stringNoLinebreaks.Text = txtJSON_string.Text.Replace(vbNewLine, "")
            Exit Sub
        End If
        i = returnIndexOfParentArray()
        If i < 0 Then
            Exit Sub
        End If
        Dim jsonArray As Newtonsoft.Json.Linq.JArray = JSON_parentArray(i)

        txtJSON_string.Text = jsonArray.ToString
        txtJSON_stringNoLinebreaks.Text = txtJSON_string.Text.Replace(vbNewLine, "")
    End Sub
    'return the name path of this selected value: format is [parent type][value type]name\[direct parent type][value type]name\..
    '                                                   ie [object][object]JSON object 0\[object][string]keyname 0
    Function returnSelectedJSON_treeNamePath() As String
        'find the path of value names (in objects) or indexes (in arrays) that lead up to the selected treenode on jsonTree
        'will include the top most parent name, which is the name of this parent object or parent array.
        'get depth
        If IsNothing(jsonTree.SelectedNode) Then Return ""
        Dim d As Integer = jsonTree.SelectedNode.Level
        'make sure the TopParentName is updated
        updateSelectedJSON_topParentName()

        'check depth, if it is 0 then use the selectedTopParentName value
        If d < 1 Then
            Return jsonTree.SelectedNode.Name

        End If
        'this must be at least the first node of an actual json object or json array.
        'create an array of strings to hold the names we are going to extract from the treeview control
        Dim s(0 To d) As String
        'create a counter
        Dim c As UInteger = 0
        'insert first value, which is the name of this selected node
        s(c) = jsonTree.SelectedNode.Name
        'increment c
        c += 1
        'get the parent of this selected node as a nodeCollection
        Dim nodeCollection As TreeNodeCollection = jsonTree.SelectedNode.Parent.Nodes
        'go through node collection until we reach a parent that has no parent.. should equal topParentName
        Dim node As TreeNode = nodeCollection.Item(0).Parent
        'add this name to the array of strings
        s(c) = node.Name
        'increment c
        c += 1

        'start a while loop to check if the parent of this node is real or nothing
        While Not IsNothing(nodeCollection.Item(0).Parent.Parent)
            'reassign the node collection to the parent of the last node of this node collection
            nodeCollection = nodeCollection.Item(0).Parent.Parent.Nodes
            node = nodeCollection.Item(0).Parent
            'add name of this node to the string array at postion c
            s(c) = node.Name
            c += 1
        End While
        Array.Reverse(s)


        Return Join(s, "\")


    End Function
    'handle adding value to object or array
    Private Sub btnAdd_Click(sender As System.Object, e As System.EventArgs) Handles btnAdd.Click
        'is a valid node selected
        If isInvalidNodeSelected() Then
            jsonTree.Focus()
            Exit Sub
        End If


        'check depth
        Dim d As Integer = jsonTree.SelectedNode.Level

        'if depth is lower than 1 exit sub because the first level is for the 
        If d < 1 Then
            jsonTree.Focus()
            Exit Sub
        End If
        
        'check if this value is being added to an object or an array (direct, not parent)
        If selectedJSON_directParentType = "object" Then
            'objects must have unique keys for each pair in a member... member->pair->(string:value)
            If isPairNameUnique() = False Then
                Exit Sub
            End If
        End If

        'insert this json value into a member or an element that is selected
        'is the top parent an array or object?
        Select Case selectedJSON_topParentType
            Case "object"
                'top parent is an object
                'is the direct parent an array or an object?
                Select Case selectedJSON_directParentType
                    Case "object"
                        'direct parent is an object
                        'add a value to an object within this (top) parent object.
                        Select Case selectedJSON_valueType
                            Case "array"
                                addArrayToObjectInObject()
                            Case "false"
                                addFalseToObjectInObject()
                            Case "number"
                                addNumberToObjectInObject()
                            Case "null"
                                addNullToObjectInObject()
                            Case "object"
                                addObjectToObjectInObject()
                            Case "string"
                                addStringToObjectInObject()
                            Case "true"
                                addTrueToObjectInObject()
                        End Select
                    Case "array"
                        'direct parrent is an array
                        'add a value to an array within this (top) parent object.
                        Select Case selectedJSON_valueType
                            Case "array"
                                addArrayToArrayInObject()
                            Case "false"
                                addFalseToArrayInObject()
                            Case "number"
                                addNumberToArrayInObject()
                            Case "null"
                                addNullToArrayInObject()
                            Case "object"
                                addObjectToArrayInObject()
                            Case "string"
                                addStringToArrayInObject()
                            Case "true"
                                addTrueToArrayInObject()

                        End Select
                End Select
            Case "array"
                'is the direct parent an array or an object?
                Select Case selectedJSON_directParentType
                    Case "object"
                        'add a value to an object within this (top) parent array.
                        Select Case selectedJSON_valueType
                            Case "array"
                                addArrayToObjectInArray()
                            Case "false"
                                addFalseToObjectInArray()
                            Case "number"
                                addNumberToObjectInArray()
                            Case "null"
                                addNullToObjectInArray()
                            Case "object"
                                addObjectToObjectInArray()
                            Case "string"
                                addStringToObjectInArray()
                            Case "true"
                                addTrueToObjectInArray()

                        End Select
                    Case "array"
                        'add a value to an array within this (top) parent array.
                        Select Case selectedJSON_valueType
                            Case "array"
                                addArrayToArrayInArray()
                            Case "false"
                                addFalseToArrayInArray()
                            Case "number"
                                addNumberToArrayInArray()
                            Case "null"
                                addNullToArrayInArray()
                            Case "object"
                                addObjectToArrayInArray()
                            Case "string"
                                addStringToArrayInArray()
                            Case "true"
                                addTrueToArrayInArray()

                        End Select
                End Select
        End Select
        jsonTree.Focus()
    End Sub
    Private Sub btnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemove.Click
        'is a valid node selected
        If isInvalidNodeSelected() Then
            jsonTree.Focus()
            Exit Sub
        End If

        Select Case jsonTree.SelectedNode.Text
            Case "add member.."
                jsonTree.Focus()
                Exit Sub
            Case "add element.."
                jsonTree.Focus()
                Exit Sub
        End Select

        'check depth
        Dim d As Integer = jsonTree.SelectedNode.Level

        'if depth is lower than 1 exit sub because the first level is for the 
        If d < 1 Then
            jsonTree.Focus()
            Exit Sub
        End If



        'remove this json value from the parent member or parent element of the selected node.
        'is the top parent an array or object?
        Select Case selectedJSON_topParentType
            Case "object"
                'top parent is an object
                'is the direct parent an array or an object?
                Select Case selectedJSON_directParentType
                    Case "object"
                        'direct parent is an object
                        'remove a value from an object within this (top) parent object.
                        removeValueFromObjectInObject()

                    Case "array"
                        'direct parrent is an array
                        'remove a value from an array within this (top) parent object.
                        removeValueFromArrayInObject()

                End Select
            Case "array"
                'is the direct parent an array or an object?
                Select Case selectedJSON_directParentType
                    Case "object"
                        'remove a value from an object within this (top) parent array.
                        removeValueFromObjectInArray()

                    Case "array"
                        'remove a value from an array within this (top) parent array.
                        removeValueFromArrayInArray()

                End Select
        End Select
        jsonTree.Focus()

    End Sub
    'remove json object
    Sub removeValueFromObjectInObject()
        Dim jsonObject As JObject = returnJSONObjectFromParentObject(returnIndexOfParentObject())
        Dim s As String = jsonTree.SelectedNode.Name
        Dim rgx As New Regex("\[[^\]]*\]")
        Dim matches As MatchCollection
        Dim a As String = ""
        Dim b As String = ""
        Dim L As Integer = -1
        Dim key As String = ""
        matches = rgx.Matches(s)
        If matches.Count > 0 Then
            a = matches(0).ToString
            b = matches(1).ToString
            L = a.Length + b.Length
            key = s.Substring(L, s.Length - L)
            jsonObject.Remove(key)
        Else
            MsgBox("problem removing value")
        End If

        Me.jsonTree.SelectedNode.Remove()
    End Sub
    Sub removeValueFromArrayInObject()
        Dim jsonArray As JArray = returnJSONArrayFromParentObject(returnIndexOfParentObject())
        Dim i As Integer = jsonTree.SelectedNode.Index - 1
        jsonArray.RemoveAt(i)
        Me.jsonTree.SelectedNode.Remove()
        reNumberArrayInJSON_tree()
    End Sub
    Sub removeValueFromObjectInArray()
        Dim jsonObject As JObject = returnJSONObjectFromParentArray(returnIndexOfParentArray())
        Dim s As String = jsonTree.SelectedNode.Name
        Dim rgx As New Regex("\[[^\]]*\]")
        Dim matches As MatchCollection
        Dim a As String = ""
        Dim b As String = ""
        Dim L As Integer = -1
        Dim key As String = ""
        matches = rgx.Matches(s)
        If matches.Count > 0 Then
            a = matches(0).ToString
            b = matches(1).ToString
            L = a.Length + b.Length
            key = s.Substring(L, s.Length - L)
            jsonObject.Remove(key)
        Else
            MsgBox("problem removing value")
        End If
        Me.jsonTree.SelectedNode.Remove()

    End Sub
    Sub removeValueFromArrayInArray()
        Dim jsonArray As JArray = returnJSONArrayFromParentArray(returnIndexOfParentArray())
        Dim i As Integer = jsonTree.SelectedNode.Index - 1
        jsonArray.RemoveAt(i)
        Me.jsonTree.SelectedNode.Remove()
        reNumberArrayInJSON_tree()
    End Sub
    'object in parent object
    Sub addArrayToObjectInObject()
        'add to json object
        addArrayToObjectInJSON_object() 'must be done first
        'add array value to this object in the json tree
        addArrayToObjectInJSON_tree()

    End Sub
    Sub addFalseToObjectInObject()
        addFalseToObjectInJSON_object()
        'add false value to this object in the json tree
        addFalseToObjectInJSON_tree()

    End Sub
    Sub addNumberToObjectInObject()
        addNumberToObjectInJSON_object()
        addNumberToObjectInJSON_tree()
    End Sub
    Sub addNullToObjectInObject()
        addNullToObjectInJSON_object()
        addNullToObjectInJSON_tree()
    End Sub
    Sub addObjectToObjectInObject()
        addObjectToObjectInJSON_object()
        addObjectToObjectInJSON_tree()
    End Sub
    Sub addStringToObjectInObject()
        addStringToObjectInJSON_object()
        addStringToObjectInJSON_tree()
    End Sub
    Sub addTrueToObjectInObject()
        addTrueToObjectInJSON_object()
        addTrueToObjectInJSON_tree()
    End Sub
    'array in parent object
    Sub addArrayToArrayInObject()
        'add to json object
        addArrayToArrayInJSON_object() 'must be done first
        'add array value to this object in the json tree
        addArrayToArrayInJSON_tree()
        'renumber array incase of insert
        reNumberArrayInJSON_tree()


    End Sub
    Sub addFalseToArrayInObject()
        'add to json object
        addFalseToArrayInJSON_object() 'must be done first
        'add array value to this object in the json tree
        addFalseToArrayInJSON_tree()
        'renumber array incase of insert
        reNumberArrayInJSON_tree()
    End Sub
    Sub addNumberToArrayInObject()
        'add to json object
        addNumberToArrayInJSON_object() 'must be done first
        'add array value to this object in the json tree
        addNumberToArrayInJSON_tree()
        'renumber array incase of insert
        reNumberArrayInJSON_tree()
    End Sub
    Sub addNullToArrayInObject()
        'add to json object
        addNullToArrayInJSON_object() 'must be done first
        'add array value to this object in the json tree
        addNullToArrayInJSON_tree()
        'renumber array incase of insert
        reNumberArrayInJSON_tree()
    End Sub
    Sub addObjectToArrayInObject()
        'add to json object
        addObjectToArrayInJSON_object() 'must be done first
        'add array value to this object in the json tree
        addObjectToArrayInJSON_tree()
        'renumber array incase of insert
        reNumberArrayInJSON_tree()
    End Sub
    Sub addStringToArrayInObject()
        'add to json object
        addStringToArrayInJSON_object() 'must be done first
        'add array value to this object in the json tree
        addStringToArrayInJSON_tree()
        'renumber array incase of insert
        reNumberArrayInJSON_tree()
    End Sub
    Sub addTrueToArrayInObject()
        'add to json object
        addTrueToArrayInJSON_object() 'must be done first
        'add array value to this object in the json tree
        addTrueToArrayInJSON_tree()
        'renumber array incase of insert
        reNumberArrayInJSON_tree()
    End Sub
    'object in parent array
    Sub addArrayToObjectInArray()
        'add to json object
        addArrayToObjectInJSON_array() 'must be done first
        'add array value to this object in the json tree
        addArrayToObjectInJSON_tree()

    End Sub
    Sub addFalseToObjectInArray()
        addFalseToObjectInJSON_array()
        'add false value to this object in the json tree
        addFalseToObjectInJSON_tree()

    End Sub
    Sub addNumberToObjectInArray()
        addNumberToObjectInJSON_array()
        addNumberToObjectInJSON_tree()
    End Sub
    Sub addNullToObjectInArray()
        addNullToObjectInJSON_array()
        addNullToObjectInJSON_tree()
    End Sub
    Sub addObjectToObjectInArray()
        addObjectToObjectInJSON_array()
        addObjectToObjectInJSON_tree()
    End Sub
    Sub addStringToObjectInArray()
        addStringToObjectInJSON_array()
        addStringToObjectInJSON_tree()
    End Sub
    Sub addTrueToObjectInArray()
        addTrueToObjectInJSON_array()
        addTrueToObjectInJSON_tree()
    End Sub
    'array in parent array
    Sub addArrayToArrayInArray()
        'add to json object
        addArrayToArrayInJSON_array() 'must be done first
        'add array value to this object in the json tree
        addArrayToArrayInJSON_tree()

    End Sub
    Sub addFalseToArrayInArray()
        'add to json object
        addFalseToArrayInJSON_array() 'must be done first
        'add array value to this object in the json tree
        addFalseToArrayInJSON_tree()
        'renumber array incase of insert
        reNumberArrayInJSON_tree()
    End Sub
    Sub addNumberToArrayInArray()
        'add to json object
        addNumberToArrayInJSON_array() 'must be done first
        'add array value to this object in the json tree
        addNumberToArrayInJSON_tree()
        'renumber array incase of insert
        reNumberArrayInJSON_tree()
    End Sub
    Sub addNullToArrayInArray()
        'add to json object
        addNullToArrayInJSON_array() 'must be done first
        'add array value to this object in the json tree
        addNullToArrayInJSON_tree()
        'renumber array incase of insert
        reNumberArrayInJSON_tree()
    End Sub
    Sub addObjectToArrayInArray()
        'add to json object
        addObjectToArrayInJSON_array() 'must be done first
        'add array value to this object in the json tree
        addObjectToArrayInJSON_tree()

    End Sub
    Sub addStringToArrayInArray()
        'add to json object
        addStringToArrayInJSON_array() 'must be done first
        'add array value to this object in the json tree
        addStringToArrayInJSON_tree()
        'renumber array incase of insert
        reNumberArrayInJSON_tree()
    End Sub
    Sub addTrueToArrayInArray()
        'add to json object
        addTrueToArrayInJSON_array() 'must be done first
        'add array value to this object in the json tree
        addTrueToArrayInJSON_tree()
        'renumber array incase of insert
        reNumberArrayInJSON_tree()
    End Sub
    'add value to object in parent json object
    Sub addArrayToObjectInJSON_object()
        Dim i As Integer = returnIndexOfParentObject()
        If i < 0 Then
            Exit Sub
        End If

        Dim jsonObject As Newtonsoft.Json.Linq.JObject
        jsonObject = returnJSONObjectFromParentObject(i)
        Dim jsonValue As New Newtonsoft.Json.Linq.JObject
        jsonValue.Add(txtValueName.Text, New Newtonsoft.Json.Linq.JArray)
        addJSON_valueToJSON_object(jsonObject, jsonValue, jsonTree.SelectedNode.Index - 1)
        updateTextboxJSON_string()

    End Sub
    Sub addFalseToObjectInJSON_object()
        Dim i As Integer = returnIndexOfParentObject()
        If i < 0 Then
            Exit Sub
        End If

        Dim jsonObject As Newtonsoft.Json.Linq.JObject
        jsonObject = returnJSONObjectFromParentObject(i)
        Dim jsonValue As New Newtonsoft.Json.Linq.JObject
        jsonValue.Add(txtValueName.Text, False)
        addJSON_valueToJSON_object(jsonObject, jsonValue, jsonTree.SelectedNode.Index - 1)


        updateTextboxJSON_string()

    End Sub
    Sub addNumberToObjectInJSON_object()
        Dim i As Integer = returnIndexOfParentObject()
        If i < 0 Then
            Exit Sub
        End If

        Dim jsonObject As Newtonsoft.Json.Linq.JObject
        jsonObject = returnJSONObjectFromParentObject(i)
        'use a work around to build a json object with a number
        Dim s As String = "{""temp"":" & txtValueNumber.Text & "}"
        Dim jsonTemp As Newtonsoft.Json.Linq.JObject = Newtonsoft.Json.Linq.JObject.Parse(s)
        Dim jsonValue As New Newtonsoft.Json.Linq.JObject
        jsonValue.Add(txtValueName.Text, jsonTemp("temp"))
        addJSON_valueToJSON_object(jsonObject, jsonValue, jsonTree.SelectedNode.Index - 1)

        'update some textboxes such as the json string / json string with no line breaks / key set
        updateTextboxJSON_string()

    End Sub
    Sub addNullToObjectInJSON_object()
        Dim i As Integer = returnIndexOfParentObject()
        If i < 0 Then
            Exit Sub
        End If

        Dim jsonObject As Newtonsoft.Json.Linq.JObject
        jsonObject = returnJSONObjectFromParentObject(i)
        Dim jsonValue As New Newtonsoft.Json.Linq.JObject
        jsonValue.Add(txtValueName.Text, Nothing)
        addJSON_valueToJSON_object(jsonObject, jsonValue, jsonTree.SelectedNode.Index - 1)


        updateTextboxJSON_string()

    End Sub
    Sub addObjectToObjectInJSON_object()
        Dim i As Integer = returnIndexOfParentObject()
        If i < 0 Then
            Exit Sub
        End If

        Dim jsonObject As Newtonsoft.Json.Linq.JObject
        jsonObject = returnJSONObjectFromParentObject(i)
        Dim jsonValue As New Newtonsoft.Json.Linq.JObject
        jsonValue.Add(txtValueName.Text, New Newtonsoft.Json.Linq.JObject)
        addJSON_valueToJSON_object(jsonObject, jsonValue, jsonTree.SelectedNode.Index - 1)

        updateTextboxJSON_string()

    End Sub
    Sub addStringToObjectInJSON_object()
        Dim i As Integer = returnIndexOfParentObject()
        If i < 0 Then
            Exit Sub
        End If

        Dim jsonObject As Newtonsoft.Json.Linq.JObject
        jsonObject = returnJSONObjectFromParentObject(i)
        Dim jsonValue As New Newtonsoft.Json.Linq.JObject
        jsonValue.Add(txtValueName.Text, txtValueString.Text)
        addJSON_valueToJSON_object(jsonObject, jsonValue, jsonTree.SelectedNode.Index - 1)
        updateTextboxJSON_string()

    End Sub
    Sub addTrueToObjectInJSON_object()
        Dim i As Integer = returnIndexOfParentObject()
        If i < 0 Then
            Exit Sub
        End If
        'get child object
        Dim jsonObject As Newtonsoft.Json.Linq.JObject
        jsonObject = returnJSONObjectFromParentObject(i)
        'build json object that contains the pair name and value
        Dim jsonValue As New Newtonsoft.Json.Linq.JObject
        jsonValue.Add(txtValueName.Text, True)
        'add/insert into json object
        'jsonObject.Add(txtValueName.Text, True)
        addJSON_valueToJSON_object(jsonObject, jsonValue, jsonTree.SelectedNode.Index - 1)

        updateTextboxJSON_string()
    End Sub
    'add value to array in parent json object
    Sub addArrayToArrayInJSON_object()
        Dim i As Integer = returnIndexOfParentObject()
        If i < 0 Then
            Exit Sub
        End If

        Dim jsonArray As Newtonsoft.Json.Linq.JArray
        jsonArray = returnJSONArrayFromParentObject(i)
        Dim jsonValue As New Newtonsoft.Json.Linq.JArray
        jsonValue.Add(New Newtonsoft.Json.Linq.JArray)
        addJSON_valueToJSON_array(jsonArray, jsonValue, jsonTree.SelectedNode.Index - 1)

        updateTextboxJSON_string()

    End Sub
    Sub addFalseToArrayInJSON_object()
        Dim i As Integer = returnIndexOfParentObject()
        If i < 0 Then
            Exit Sub
        End If

        Dim jsonArray As Newtonsoft.Json.Linq.JArray
        jsonArray = returnJSONArrayFromParentObject(i)
        Dim jsonValue As New Newtonsoft.Json.Linq.JArray
        jsonValue.Add(False)
        addJSON_valueToJSON_array(jsonArray, jsonValue, jsonTree.SelectedNode.Index - 1)

        updateTextboxJSON_string()

    End Sub
    Sub addNumberToArrayInJSON_object()
        Dim i As Integer = returnIndexOfParentObject()
        If i < 0 Then
            Exit Sub
        End If

        Dim jsonArray As Newtonsoft.Json.Linq.JArray
        'use a work around to build a json object with a number
        Dim s As String = "{""temp"":" & txtValueNumber.Text & "}"
        Dim jsonTemp As Newtonsoft.Json.Linq.JObject = Newtonsoft.Json.Linq.JObject.Parse(s)

        'get the child json array for the selected node
        jsonArray = returnJSONArrayFromParentObject(i)

        'add value to child json array
        Dim jsonValue As New Newtonsoft.Json.Linq.JArray
        jsonValue.Add(jsonTemp("temp"))
        addJSON_valueToJSON_array(jsonArray, jsonValue, jsonTree.SelectedNode.Index - 1)

        updateTextboxJSON_string()

    End Sub
    Sub addNullToArrayInJSON_object()
        Dim i As Integer = returnIndexOfParentObject()
        If i < 0 Then
            Exit Sub
        End If

        Dim jsonArray As Newtonsoft.Json.Linq.JArray
        jsonArray = returnJSONArrayFromParentObject(i)
        Dim jsonValue As New Newtonsoft.Json.Linq.JArray
        jsonValue.Add(Nothing)
        addJSON_valueToJSON_array(jsonArray, jsonValue, jsonTree.SelectedNode.Index - 1)

        updateTextboxJSON_string()

    End Sub
    Sub addObjectToArrayInJSON_object()
        Dim i As Integer = returnIndexOfParentObject()
        If i < 0 Then
            Exit Sub
        End If

        Dim jsonArray As Newtonsoft.Json.Linq.JArray
        jsonArray = returnJSONArrayFromParentObject(i)
        Dim jsonValue As New Newtonsoft.Json.Linq.JArray
        jsonValue.Add(New Newtonsoft.Json.Linq.JObject)
        addJSON_valueToJSON_array(jsonArray, jsonValue, jsonTree.SelectedNode.Index - 1)

        updateTextboxJSON_string()

    End Sub
    Sub addStringToArrayInJSON_object()
        Dim i As Integer = returnIndexOfParentObject()
        If i < 0 Then
            Exit Sub
        End If

        Dim jsonArray As Newtonsoft.Json.Linq.JArray
        jsonArray = returnJSONArrayFromParentObject(i)
        Dim jsonValue As New Newtonsoft.Json.Linq.JArray
        jsonValue.Add(txtValueString.Text)
        addJSON_valueToJSON_array(jsonArray, jsonValue, jsonTree.SelectedNode.Index - 1)

        updateTextboxJSON_string()

    End Sub
    Sub addTrueToArrayInJSON_object()
        Dim i As Integer = returnIndexOfParentObject()
        If i < 0 Then
            Exit Sub
        End If

        Dim jsonArray As Newtonsoft.Json.Linq.JArray
        jsonArray = returnJSONArrayFromParentObject(i)
        Dim jsonValue As New Newtonsoft.Json.Linq.JArray
        jsonValue.Add(True)
        addJSON_valueToJSON_array(jsonArray, jsonValue, jsonTree.SelectedNode.Index - 1)

        updateTextboxJSON_string()

    End Sub
    'add value to object in parent json array
    Sub addArrayToObjectInJSON_array()
        Dim i As Integer = returnIndexOfParentArray()
        If i < 0 Then
            Exit Sub
        End If

        Dim jsonObject As Newtonsoft.Json.Linq.JObject
        jsonObject = returnJSONObjectFromParentArray(i)
        Dim jsonValue As New Newtonsoft.Json.Linq.JObject
        jsonValue.Add(txtValueName.Text, New Newtonsoft.Json.Linq.JArray)
        addJSON_valueToJSON_object(jsonObject, jsonValue, jsonTree.SelectedNode.Index - 1)

        updateTextboxJSON_string()

    End Sub
    Sub addFalseToObjectInJSON_array()
        Dim i As Integer = returnIndexOfParentArray()
        If i < 0 Then
            Exit Sub
        End If

        Dim jsonObject As Newtonsoft.Json.Linq.JObject
        jsonObject = returnJSONObjectFromParentArray(i)
        Dim jsonValue As New Newtonsoft.Json.Linq.JObject
        jsonValue.Add(txtValueName.Text, False)
        addJSON_valueToJSON_object(jsonObject, jsonValue, jsonTree.SelectedNode.Index - 1)

        updateTextboxJSON_string()

    End Sub
    Sub addNumberToObjectInJSON_array()
        Dim i As Integer = returnIndexOfParentArray()
        If i < 0 Then
            Exit Sub
        End If

        Dim jsonObject As Newtonsoft.Json.Linq.JObject
        jsonObject = returnJSONObjectFromParentArray(i)
        'use a work around to build a json object with a number
        Dim s As String = "{""temp"":" & txtValueNumber.Text & "}"
        Dim jsonTemp As Newtonsoft.Json.Linq.JObject = Newtonsoft.Json.Linq.JObject.Parse(s)
        Dim jsonValue As New Newtonsoft.Json.Linq.JObject
        jsonValue.Add(txtValueName.Text, jsonTemp("temp"))
        addJSON_valueToJSON_object(jsonObject, jsonValue, jsonTree.SelectedNode.Index - 1)

        'update some textboxes such as the json string / json string with no line breaks / key set
        updateTextboxJSON_string()

    End Sub
    Sub addNullToObjectInJSON_array()
        Dim i As Integer = returnIndexOfParentArray()
        If i < 0 Then
            Exit Sub
        End If

        Dim jsonObject As Newtonsoft.Json.Linq.JObject
        jsonObject = returnJSONObjectFromParentArray(i)
        Dim jsonValue As New Newtonsoft.Json.Linq.JObject
        jsonValue.Add(txtValueName.Text, Nothing)
        addJSON_valueToJSON_object(jsonObject, jsonValue, jsonTree.SelectedNode.Index - 1)


        updateTextboxJSON_string()

    End Sub
    Sub addObjectToObjectInJSON_array()
        Dim i As Integer = returnIndexOfParentArray()
        If i < 0 Then
            Exit Sub
        End If

        Dim jsonObject As Newtonsoft.Json.Linq.JObject
        jsonObject = returnJSONObjectFromParentArray(i)
        Dim jsonValue As New Newtonsoft.Json.Linq.JObject
        jsonValue.Add(txtValueName.Text, New Newtonsoft.Json.Linq.JObject)
        addJSON_valueToJSON_object(jsonObject, jsonValue, jsonTree.SelectedNode.Index - 1)

        updateTextboxJSON_string()

    End Sub
    Sub addStringToObjectInJSON_array()
        Dim i As Integer = returnIndexOfParentArray()
        If i < 0 Then
            Exit Sub
        End If

        Dim jsonObject As Newtonsoft.Json.Linq.JObject
        jsonObject = returnJSONObjectFromParentArray(i)
        Dim jsonValue As New Newtonsoft.Json.Linq.JObject
        jsonValue.Add(txtValueName.Text, txtValueString.Text)
        addJSON_valueToJSON_object(jsonObject, jsonValue, jsonTree.SelectedNode.Index - 1)

        updateTextboxJSON_string()

    End Sub
    Sub addTrueToObjectInJSON_array()
        Dim i As Integer = returnIndexOfParentArray()
        If i < 0 Then
            Exit Sub
        End If

        Dim jsonObject As Newtonsoft.Json.Linq.JObject
        jsonObject = returnJSONObjectFromParentArray(i)
        'build json object that contains the pair name and value
        Dim jsonValue As New Newtonsoft.Json.Linq.JObject
        jsonValue.Add(txtValueName.Text, True)
        'add/insert into json object
        'jsonObject.Add(txtValueName.Text, True)
        addJSON_valueToJSON_object(jsonObject, jsonValue, jsonTree.SelectedNode.Index - 1)

        updateTextboxJSON_string()
    End Sub
    'add value to array in parent json array
    Sub addArrayToArrayInJSON_array()
        Dim i As Integer = returnIndexOfParentArray()
        If i < 0 Then
            Exit Sub
        End If

        Dim jsonArray As Newtonsoft.Json.Linq.JArray
        jsonArray = returnJSONArrayFromParentArray(i)
        Dim jsonValue As New Newtonsoft.Json.Linq.JArray
        jsonValue.Add(New Newtonsoft.Json.Linq.JArray)
        addJSON_valueToJSON_array(jsonArray, jsonValue, jsonTree.SelectedNode.Index - 1)

        updateTextboxJSON_string()

    End Sub
    Sub addFalseToArrayInJSON_array()
        Dim i As Integer = returnIndexOfParentArray()
        If i < 0 Then
            Exit Sub
        End If

        Dim jsonArray As Newtonsoft.Json.Linq.JArray
        jsonArray = returnJSONArrayFromParentArray(i)
        Dim jsonValue As New Newtonsoft.Json.Linq.JArray
        jsonValue.Add(False)
        addJSON_valueToJSON_array(jsonArray, jsonValue, jsonTree.SelectedNode.Index - 1)

        updateTextboxJSON_string()

    End Sub
    Sub addNumberToArrayInJSON_array()
        Dim i As Integer = returnIndexOfParentArray()
        If i < 0 Then
            Exit Sub
        End If

        Dim jsonArray As Newtonsoft.Json.Linq.JArray
        'use a work around to build a json object with a number
        Dim s As String = "{""temp"":" & txtValueNumber.Text & "}"
        Dim jsonTemp As Newtonsoft.Json.Linq.JObject = Newtonsoft.Json.Linq.JObject.Parse(s)

        'get the child json array for the selected node
        jsonArray = returnJSONArrayFromParentArray(i)

        'add value to child json array
        Dim jsonValue As New Newtonsoft.Json.Linq.JArray
        jsonValue.Add(jsonTemp("temp"))
        addJSON_valueToJSON_array(jsonArray, jsonValue, jsonTree.SelectedNode.Index - 1)

        updateTextboxJSON_string()

    End Sub
    Sub addNullToArrayInJSON_array()
        Dim i As Integer = returnIndexOfParentArray()
        If i < 0 Then
            Exit Sub
        End If

        Dim jsonArray As Newtonsoft.Json.Linq.JArray
        jsonArray = returnJSONArrayFromParentArray(i)
        Dim jsonValue As New Newtonsoft.Json.Linq.JArray
        jsonValue.Add(Nothing)
        addJSON_valueToJSON_array(jsonArray, jsonValue, jsonTree.SelectedNode.Index - 1)

        updateTextboxJSON_string()

    End Sub
    Sub addObjectToArrayInJSON_array()
        Dim i As Integer = returnIndexOfParentArray()
        If i < 0 Then
            Exit Sub
        End If

        Dim jsonArray As Newtonsoft.Json.Linq.JArray
        jsonArray = returnJSONArrayFromParentArray(i)
        Dim jsonValue As New Newtonsoft.Json.Linq.JArray
        jsonValue.Add(New Newtonsoft.Json.Linq.JObject)
        addJSON_valueToJSON_array(jsonArray, jsonValue, jsonTree.SelectedNode.Index - 1)

        updateTextboxJSON_string()

    End Sub
    Sub addStringToArrayInJSON_array()
        Dim i As Integer = returnIndexOfParentArray()
        If i < 0 Then
            Exit Sub
        End If

        Dim jsonArray As Newtonsoft.Json.Linq.JArray
        jsonArray = returnJSONArrayFromParentArray(i)
        Dim jsonValue As New Newtonsoft.Json.Linq.JArray
        jsonValue.Add(txtValueString.Text)
        addJSON_valueToJSON_array(jsonArray, jsonValue, jsonTree.SelectedNode.Index - 1)

        updateTextboxJSON_string()

    End Sub
    Sub addTrueToArrayInJSON_array()
        Dim i As Integer = returnIndexOfParentArray()
        If i < 0 Then
            Exit Sub
        End If

        Dim jsonArray As Newtonsoft.Json.Linq.JArray
        jsonArray = returnJSONArrayFromParentArray(i)
        Dim jsonValue As New Newtonsoft.Json.Linq.JArray
        jsonValue.Add(True)

        addJSON_valueToJSON_array(jsonArray, jsonValue, jsonTree.SelectedNode.Index - 1)


        updateTextboxJSON_string()

    End Sub
    'find and return the selected child json object of this parent json object.
    Function returnJSONObjectFromParentObject(ByVal i As Integer) As Newtonsoft.Json.Linq.JObject
        Dim jsonObject As Newtonsoft.Json.Linq.JObject = JSON_parentObject(i)

        'get array of types
        Dim s() As String = selectedJSON_treeNamePath.Split("\")
        Dim t(0 To s.Length - 1) As String

        If s.Length < 3 Then Return jsonObject

        Dim rgx As New Regex("\[[^\]]*\]")
        Dim matches As MatchCollection
        Dim c As Integer = 0
        Dim l As Integer = 0 'length of matches(0) + matches(1) = start of actual key name.. ie. [object][array]keyname 0
        Dim a As String = ""
        Dim b As String = ""
        For Each n In s
            matches = rgx.Matches(n)
            a = matches(0).ToString
            b = matches(1).ToString
            l = a.Length + b.Length

            t(c) = s(c).Substring(l, s(c).Length - l)
            s(c) = matches(1).ToString

            c += 1
        Next
        'remove first item in the array, it is referring to the json parent object we already have
        removeElementFromStringArrayByIndex(s, 0)
        removeElementFromStringArrayByIndex(t, 0)
        'remove last item in the array too, it is referring to the json object we have selected
        removeElementFromStringArrayByIndex(s, s.Length - 1)
        removeElementFromStringArrayByIndex(t, t.Length - 1)

        'go through each item in the list of json types
        Dim jsonArray As Newtonsoft.Json.Linq.JArray = Nothing

        'reset counter
        c = 0
        Dim lastType As String = "[object]"
        For Each n In s
            Select Case n
                Case "[object]"
                    Select Case lastType
                        Case "[object]"
                            jsonObject = jsonObject(t(c))
                        Case "[array]"
                            jsonObject = jsonArray(CInt(t(c)))
                    End Select
                    lastType = "[object]"
                Case "[array]"
                    Select Case lastType
                        Case "[object]"
                            jsonArray = jsonObject(t(c))
                        Case "[array]"
                            jsonArray = jsonArray(CInt(t(c)))
                    End Select
                    lastType = "[array]"
            End Select

            'increment counter
            c += 1

        Next
        Return jsonObject
    End Function
    Function returnJSONArrayFromParentObject(ByVal i As Integer) As Newtonsoft.Json.Linq.JArray
        Dim jsonObject As Newtonsoft.Json.Linq.JObject = JSON_parentObject(i)

        'get array of types
        Dim s() As String = selectedJSON_treeNamePath.Split("\")
        Dim t(0 To s.Length - 1) As String

        'If s.Length < 3 Then Return Nothing

        Dim rgx As New Regex("\[[^\]]*\]")
        Dim matches As MatchCollection
        Dim c As Integer = 0
        Dim l As Integer = 0 'length of matches(0) + matches(1) = start of actual key name.. ie. [object][array]keyname 0
        Dim a As String = ""
        Dim b As String = ""
        For Each n In s
            matches = rgx.Matches(n)
            a = matches(0).ToString
            b = matches(1).ToString
            l = a.Length + b.Length

            t(c) = s(c).Substring(l, s(c).Length - l)
            s(c) = matches(1).ToString

            c += 1
        Next
        'remove first item in the array, it is referring to the json parent object we already have
        removeElementFromStringArrayByIndex(s, 0)
        removeElementFromStringArrayByIndex(t, 0)
        ''remove last item in the array too, it is referring to the json object we have selected
        removeElementFromStringArrayByIndex(s, s.Length - 1)
        removeElementFromStringArrayByIndex(t, t.Length - 1)

        'go through each item in the list of json types
        Dim jsonArray As Newtonsoft.Json.Linq.JArray = Nothing

        'reset counter
        c = 0
        Dim lastType As String = "[object]" 'because the parent is an object (not an array)
        For Each n In s
            Select Case n
                Case "[object]"
                    Select Case lastType
                        Case "[object]"
                            jsonObject = jsonObject(t(c))
                        Case "[array]"
                            jsonObject = jsonArray(CInt(t(c)))
                    End Select
                    lastType = "[object]"
                Case "[array]"
                    Select Case lastType
                        Case "[object]"
                            jsonArray = jsonObject(t(c))
                        Case "[array]"
                            jsonArray = jsonArray(CInt(t(c)))
                    End Select
                    lastType = "[array]"
            End Select

            'increment counter
            c += 1

        Next
        Return jsonArray

    End Function
    Function returnJSONObjectFromParentArray(ByVal i As Integer) As Newtonsoft.Json.Linq.JObject
        Dim jsonArray As Newtonsoft.Json.Linq.JArray = JSON_parentArray(i)

        'get array of types
        Dim s() As String = selectedJSON_treeNamePath.Split("\")
        Dim t(0 To s.Length - 1) As String

        'If s.Length < 3 Then Return jsonArray 'not needed in this function because it can't be an s.length of less than 3.

        Dim rgx As New Regex("\[[^\]]*\]")
        Dim matches As MatchCollection
        Dim c As Integer = 0
        Dim l As Integer = 0 'length of matches(0) + matches(1) = start of actual key name.. ie. [object][array]keyname 0
        Dim a As String = ""
        Dim b As String = ""
        For Each n In s
            matches = rgx.Matches(n)
            a = matches(0).ToString
            b = matches(1).ToString
            l = a.Length + b.Length

            t(c) = s(c).Substring(l, s(c).Length - l)
            s(c) = matches(1).ToString

            c += 1
        Next
        'remove first item in the array, it is referring to the json parent object we already have
        removeElementFromStringArrayByIndex(s, 0)
        removeElementFromStringArrayByIndex(t, 0)
        'remove last item in the array too, it is referring to the json object we have selected
        removeElementFromStringArrayByIndex(s, s.Length - 1)
        removeElementFromStringArrayByIndex(t, t.Length - 1)

        'go through each item in the list of json types
        Dim jsonObject As Newtonsoft.Json.Linq.JObject = Nothing

        'reset counter
        c = 0
        Dim lastType As String = "[array]"
        For Each n In s
            Select Case n
                Case "[object]"
                    Select Case lastType
                        Case "[object]"
                            jsonObject = jsonObject(t(c))
                        Case "[array]"
                            jsonObject = jsonArray(CInt(t(c)))
                    End Select
                    lastType = "[object]"
                Case "[array]"
                    Select Case lastType
                        Case "[object]"
                            jsonArray = jsonObject(t(c))
                        Case "[array]"
                            jsonArray = jsonArray(CInt(t(c)))
                    End Select
                    lastType = "[array]"
            End Select

            'increment counter
            c += 1

        Next
        Return jsonObject
    End Function
    Function returnJSONArrayFromParentArray(ByVal i As Integer) As Newtonsoft.Json.Linq.JArray
        Dim jsonArray As Newtonsoft.Json.Linq.JArray = JSON_parentArray(i)

        'get array of types
        Dim s() As String = selectedJSON_treeNamePath.Split("\")
        Dim t(0 To s.Length - 1) As String

        If s.Length < 3 Then Return jsonArray

        Dim rgx As New Regex("\[[^\]]*\]")
        Dim matches As MatchCollection
        Dim c As Integer = 0
        Dim l As Integer = 0 'length of matches(0) + matches(1) = start of actual key name.. ie. [object][array]keyname 0
        Dim a As String = ""
        Dim b As String = ""
        For Each n In s
            matches = rgx.Matches(n)
            a = matches(0).ToString
            b = matches(1).ToString
            l = a.Length + b.Length

            t(c) = s(c).Substring(l, s(c).Length - l)
            s(c) = matches(1).ToString

            c += 1
        Next
        'remove first item in the array, it is referring to the json parent object we already have
        removeElementFromStringArrayByIndex(s, 0)
        removeElementFromStringArrayByIndex(t, 0)
        ''remove last item in the array too, it is referring to the json object we have selected
        removeElementFromStringArrayByIndex(s, s.Length - 1)
        removeElementFromStringArrayByIndex(t, t.Length - 1)

        'go through each item in the list of json types
        Dim jsonObject As Newtonsoft.Json.Linq.JObject = Nothing

        'reset counter
        c = 0
        Dim lastType As String = "[array]" 'because the parent is an object (not an array)
        For Each n In s
            Select Case n
                Case "[object]"
                    Select Case lastType
                        Case "[object]"
                            jsonObject = jsonObject(t(c))
                        Case "[array]"
                            jsonObject = jsonArray(CInt(t(c)))
                    End Select
                    lastType = "[object]"
                Case "[array]"
                    Select Case lastType
                        Case "[object]"
                            jsonArray = jsonObject(t(c))
                        Case "[array]"
                            jsonArray = jsonArray(CInt(t(c)))
                    End Select
                    lastType = "[array]"
            End Select

            'increment counter
            c += 1

        Next
        Return jsonArray

    End Function
    'insert json value (as a json object) into a json object
    Sub addJSON_valueToJSON_object(ByRef jsonObject As Newtonsoft.Json.Linq.JObject, ByRef jsonValue As Newtonsoft.Json.Linq.JObject, ByRef i As Integer)
        'MsgBox(jsonObject.Count & "," & jsonValue.ToString & "," & i)
        Dim results As List(Of JToken) = jsonValue.Children().ToList
        Dim name As String = ""
        Dim value As New JObject
        For Each item As JProperty In results
            item.CreateReader()
            name = item.Name
            value.Add("temp", item.Value)
            Exit For
        Next
        If name = "" Then
            MsgBox("error in addJSON_valueToJSON_object()")
        End If
        Dim count As Integer = jsonObject.Count

        If count = i Then
            jsonObject.Add(name, value("temp"))
            Exit Sub
        End If
        'must be inserted, so move everything down one that is at this position "i" and below.
        'lets build an array, one unit longer than jsonObject..
        Dim jsonChildrenNames(0 To jsonObject.Count) As String
        Dim jsonChildrenValues(0 To jsonObject.Count) As JObject
        Dim jsonTemp As New JObject

        results = jsonObject.Children().ToList
        count = 0 'reuse count
        For Each item As JProperty In results
            item.CreateReader()
            'check if this is the index of the item we want to insert
            If count = i Then
                'this is the correct index, insert our new item
                jsonChildrenNames(i) = name
                jsonTemp.RemoveAll()
                jsonTemp.Add("temp", value("temp"))
                count += 1
                jsonChildrenValues(i) = jsonTemp.DeepClone

                'now add the item that was in this position.
            End If
            jsonChildrenNames(count) = item.Name
            jsonTemp.RemoveAll()
            jsonTemp.Add("temp", item.Value)
            jsonChildrenValues(count) = jsonTemp.DeepClone
            count += 1
        Next

        jsonObject.RemoveAll()
        count = 0
        For Each s As String In jsonChildrenNames
            jsonObject.Add(s, jsonChildrenValues(count).Item("temp"))
            count += 1
        Next

        'MsgBox(jsonObject)

    End Sub
    Sub addJSON_valueToJSON_array(ByRef jsonArray As Newtonsoft.Json.Linq.JArray, ByRef jsonValue As Newtonsoft.Json.Linq.JArray, ByRef i As Integer)
        Dim count As Integer = jsonArray.Count
        If count = i Then
            jsonArray.Add(jsonValue(0))
            Exit Sub
        End If
        'insert into json array
        jsonArray.Insert(i, jsonValue(0))

    End Sub
    Sub reNumberArrayInJSON_tree()
        Dim nodeCollection As TreeNodeCollection = jsonTree.SelectedNode.Parent.Nodes
        Dim count As Integer = -1
        Dim rgx As New Regex("^(\([0-9]*\))")
        Dim rgxb As New Regex("^(\[[0-9]*\])")
        Dim rgxc As New Regex("(\d+)$")


        For Each node As TreeNode In nodeCollection
            If rgx.Matches(node.Text).Count > 0 Then
                node.Text = rgx.Replace(node.Text, "(" & count & ")")
            Else
                node.Text = rgxb.Replace(node.Text, "[" & count & "]")
            End If
            node.Name = rgxc.Replace(node.Name, count)

            count += 1
        Next
    End Sub
    'add value to an object (direct, not parent) in the json treeview
    Sub addArrayToObjectInJSON_tree()
        Dim node As TreeNode = jsonTree.SelectedNode
        Dim i As Integer = jsonTree.SelectedNode.Index
        Dim s As String = txtValueName.Text
        Dim keyName As String = "[object][array]" & txtValueName.Text
        node = node.Parent.Nodes.Insert(i, keyName, s)
        node.Nodes.Add("[")
        keyName = "[array][undefined]"
        Dim childnode As TreeNode = node.Nodes.Add(keyName, "add element..")
        node.Nodes.Add("]")
        jsonTree.SelectedNode.Expand()
        jsonTree.SelectedNode = childnode
        If isDefaultValueName(txtValueName.Text) = True Then
            txtValueName.Text = requestDefaultValueName()
        End If
    End Sub
    Sub addFalseToObjectInJSON_tree()
        Dim node As TreeNode = jsonTree.SelectedNode
        Dim i As Integer = jsonTree.SelectedNode.Index
        Dim s As String = txtValueName.Text & ": false"
        Dim keyName As String = "[object][boolean]" & txtValueName.Text
        node = node.Parent.Nodes.Insert(i, keyName, s)
        jsonTree.SelectedNode = node.NextNode
        If isDefaultValueName(txtValueName.Text) = True Then
            txtValueName.Text = requestDefaultValueName()
        End If
    End Sub
    Sub addNumberToObjectInJSON_tree()
        Dim node As TreeNode = jsonTree.SelectedNode
        Dim i As Integer = jsonTree.SelectedNode.Index
        Dim s As String = txtValueName.Text & ": " & txtValueNumber.Text
        Dim keyName As String = "[object][number]" & txtValueName.Text
        node = node.Parent.Nodes.Insert(i, keyName, s)

        jsonTree.SelectedNode = node.NextNode
        If isDefaultValueName(txtValueName.Text) = True Then
            txtValueName.Text = requestDefaultValueName()
        End If
    End Sub
    Sub addNullToObjectInJSON_tree()
        Dim node As TreeNode = jsonTree.SelectedNode
        Dim i As Integer = jsonTree.SelectedNode.Index
        Dim s As String = txtValueName.Text & ": null"
        Dim keyName As String = "[object][null]" & txtValueName.Text
        node = node.Parent.Nodes.Insert(i, keyName, s)
        jsonTree.SelectedNode = node.NextNode
        If isDefaultValueName(txtValueName.Text) = True Then
            txtValueName.Text = requestDefaultValueName()
        End If
    End Sub
    Sub addObjectToObjectInJSON_tree()
        Dim node As TreeNode = jsonTree.SelectedNode
        Dim i As Integer = jsonTree.SelectedNode.Index
        Dim s As String = txtValueName.Text
        Dim keyName As String = "[object][object]" & txtValueName.Text
        node = node.Parent.Nodes.Insert(i, keyName, s)
        node.Nodes.Add("{")
        keyName = "[object][undefined]"
        Dim childnode As TreeNode = node.Nodes.Add(keyName, "add member..")
        node.Nodes.Add("}")
        jsonTree.SelectedNode.Expand()
        jsonTree.SelectedNode = childnode

        If isDefaultValueName(txtValueName.Text) = True Then
            txtValueName.Text = requestDefaultValueName()
        End If
    End Sub
    Sub addStringToObjectInJSON_tree()
        Dim node As TreeNode = jsonTree.SelectedNode
        Dim i As Integer = jsonTree.SelectedNode.Index
        Dim s As String = txtValueName.Text & ": " & txtValueString.Text
        Dim keyName As String = "[object][string]" & txtValueName.Text
        node = node.Parent.Nodes.Insert(i, keyName, s)

        jsonTree.SelectedNode = node.NextNode
        If isDefaultValueName(txtValueName.Text) = True Then
            txtValueName.Text = requestDefaultValueName()
        End If
    End Sub
    Sub addTrueToObjectInJSON_tree()
        Dim node As TreeNode = jsonTree.SelectedNode
        Dim i As Integer = jsonTree.SelectedNode.Index
        Dim s As String = txtValueName.Text & ": true"
        Dim keyName As String = "[object][boolean]" & txtValueName.Text
        node = node.Parent.Nodes.Insert(i, keyName, s)
        jsonTree.SelectedNode = node.NextNode
        If isDefaultValueName(txtValueName.Text) = True Then
            txtValueName.Text = requestDefaultValueName()
        End If
    End Sub
    'add value to an array (direct, not parent) in the json treeview
    Sub addArrayToArrayInJSON_tree()
        Dim node As TreeNode = jsonTree.SelectedNode
        Dim i As Integer = jsonTree.SelectedNode.Index
        Dim s As String = "[" & (i - 1) & "]"
        Dim keyName As String = "[array][array]" & (i - 1)
        node = node.Parent.Nodes.Insert(i, keyName, s)
        node.Nodes.Add("[")
        keyName = "[array][undefined]"
        Dim childnode As TreeNode = node.Nodes.Add(keyName, "add element..")
        node.Nodes.Add("]")
        jsonTree.SelectedNode.Expand()
        'renumber array incase of insert
        reNumberArrayInJSON_tree()
        jsonTree.SelectedNode = childnode
    End Sub
    Sub addFalseToArrayInJSON_tree()
        Dim node As TreeNode = jsonTree.SelectedNode
        Dim i As Integer = jsonTree.SelectedNode.Index
        Dim s As String = "(" & (i - 1) & "): false"
        Dim keyName As String = "[array][boolean]" & (i - 1)
        node = node.Parent.Nodes.Insert(i, keyName, s)
    End Sub
    Sub addNumberToArrayInJSON_tree()
        Dim node As TreeNode = jsonTree.SelectedNode
        Dim i As Integer = jsonTree.SelectedNode.Index
        Dim s As String = "(" & (i - 1) & "): " & txtValueNumber.Text
        Dim keyName As String = "[array][number]" & (i - 1)
        node = node.Parent.Nodes.Insert(i, keyName, s)
        jsonTree.SelectedNode = node.NextNode

    End Sub
    Sub addNullToArrayInJSON_tree()
        Dim node As TreeNode = jsonTree.SelectedNode
        Dim i As Integer = jsonTree.SelectedNode.Index
        Dim s As String = "(" & (i - 1) & "): null"
        Dim keyName As String = "[array][null]" & (i - 1)
        node = node.Parent.Nodes.Insert(i, keyName, s)
        jsonTree.SelectedNode = node.NextNode
    End Sub
    Sub addObjectToArrayInJSON_tree()
        Dim node As TreeNode = jsonTree.SelectedNode
        Dim i As Integer = jsonTree.SelectedNode.Index
        Dim s As String = "[" & (i - 1) & "]"
        Dim keyName As String = "[array][object]" & (i - 1)
        node = node.Parent.Nodes.Insert(i, keyName, s)
        node.Nodes.Add("{")
        keyName = "[array][undefined]"
        Dim childnode As TreeNode = node.Nodes.Add(keyName, "add member..")
        node.Nodes.Add("}")
        jsonTree.SelectedNode.Expand()
        'renumber array incase of insert
        reNumberArrayInJSON_tree()
        jsonTree.SelectedNode = childnode

    End Sub
    Sub addStringToArrayInJSON_tree()
        Dim node As TreeNode = jsonTree.SelectedNode
        Dim i As Integer = jsonTree.SelectedNode.Index
        Dim s As String = "(" & (i - 1) & "): " & txtValueString.Text
        Dim keyName As String = "[array][string]" & (i - 1)
        node = node.Parent.Nodes.Insert(i, keyName, s)
    End Sub
    Sub addTrueToArrayInJSON_tree()
        Dim node As TreeNode = jsonTree.SelectedNode
        Dim i As Integer = jsonTree.SelectedNode.Index
        Dim s As String = "(" & (i - 1) & "): true"
        Dim keyName As String = "[array][boolean]" & (i - 1)
        node = node.Parent.Nodes.Insert(i, keyName, s)
    End Sub

    Function returnIndexOfParentObject() As Integer
        Dim s As String = selectedJSON_topParentName
        Dim c As Integer = -1
        For Each n In JSON_objectNameList
            c += 1
            If n = s Then Return c
        Next
        Return -1
    End Function
    Function returnIndexOfParentArray() As Integer
        Dim s As String = selectedJSON_topParentName
        Dim c As Integer = -1
        For Each n In JSON_arrayNameList
            c += 1
            If n = s Then Return c
        Next
        Return -1
    End Function
    
    'check if this pair name is unique
    Function isPairNameUnique() As Boolean
        'check depth
        Dim d As Integer = jsonTree.SelectedNode.Level

        'if depth is lower than 1 exit sub because the first level is for the 
        If d < 1 Then Return False

        'get input name
        Dim t As String = txtValueName.Text

        'get an array of names already used on this level
        Dim node As New TreeNode

        node = jsonTree.SelectedNode.Parent.Clone
        Dim nodeCollection As TreeNodeCollection = node.Nodes

        nodeCollection.Item(0).Remove()
        nodeCollection.Item(nodeCollection.Count - 1).Remove()
        nodeCollection.Item(nodeCollection.Count - 1).Remove()

        Dim n As String = ""
        Dim rgx As New Regex("\[[^\]]*\]\[[^\]]*\]") 'match [anything][anything]
        Dim matches As MatchCollection

        For Each node In nodeCollection
            matches = rgx.Matches(node.Name)
            n = matches(0).ToString & t
            If node.Name = n Then
                flashValueName()
                Return False
            End If
        Next
        Return True
    End Function
    Function isInvalidNodeSelected() As Boolean
        If IsNothing(jsonTree.SelectedNode) Then
            Return True
        End If
        Select Case jsonTree.SelectedNode.Text
            Case "["
                Return True
            Case "{"
                Return True
            Case "]"
                Return True
            Case "}"
                Return True
        End Select
        Return False
    End Function
    'handle radio selects
    Private Sub radioValueNumber_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radioValueNumber.CheckedChanged
        txtValueNumber.Visible = True
        txtValueString.Visible = False
        updateSelectedJSON_valueType()
    End Sub
    Private Sub radioValueString_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radioValueString.CheckedChanged
        txtValueNumber.Visible = False
        txtValueString.Visible = True
        updateSelectedJSON_valueType()
    End Sub
    Private Sub radioValueNull_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles radioValueNull.CheckedChanged
        txtValueNumber.Visible = False
        txtValueString.Visible = False
        updateSelectedJSON_valueType()
    End Sub
    Private Sub radioValueTrue_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles radioValueTrue.CheckedChanged
        txtValueNumber.Visible = False
        txtValueString.Visible = False
        updateSelectedJSON_valueType()
    End Sub
    Private Sub radioValueFalse_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles radioValueFalse.CheckedChanged
        txtValueNumber.Visible = False
        txtValueString.Visible = False
        updateSelectedJSON_valueType()
    End Sub
    Private Sub radioValueArray_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles radioValueArray.CheckedChanged
        txtValueNumber.Visible = False
        txtValueString.Visible = False
        updateSelectedJSON_valueType()
    End Sub
    Private Sub radioValueObject_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles radioValueObject.CheckedChanged
        txtValueNumber.Visible = False
        txtValueString.Visible = False
        updateSelectedJSON_valueType()
    End Sub
    'handle number input validation
    'remember old value
    Dim oldValueNumber As String = "1234e-3"
    Dim validKey As Boolean = False
    Dim isKeyPressedABackspace = False
    Private Sub txtValueNumber_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtValueNumber.KeyDown
        oldValueNumber = txtValueNumber.Text

    End Sub
    Private Sub txtValueNumber_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtValueNumber.KeyPress
        'check if the keypress is valid.. must be either 0-9, e, E, +, -, vbBack, or '.'
        Select Case e.KeyChar
            Case "e"
                validKey = True
                Exit Sub
            Case "E"
                validKey = True
                Exit Sub
            Case "-"
                validKey = True
                Exit Sub
            Case "+"
                validKey = True
                Exit Sub
            Case vbBack
                isKeyPressedABackspace = True
                Exit Sub
            Case "."
                validKey = True
                Exit Sub
        End Select
        Dim rgx As New Regex("[0-9]")
        Dim matches As Boolean = rgx.IsMatch(e.KeyChar)
        If matches = True Then
            validKey = True
            Exit Sub
        End If

        e.KeyChar = ""

    End Sub
    Private Sub txtValueNumber_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtValueNumber.TextChanged
        Dim p As Integer = txtValueNumber.SelectionStart
        Dim t As String = txtValueNumber.Text
        'check format for "1234"
        Dim rgx As New Regex("[0-9]*")
        Dim matches As MatchCollection = rgx.Matches(t)
        If matches.Count > 0 Then
            If matches.Item(0).ToString = t Then
                Exit Sub
            End If
        End If
        'check format for "-1234"
        rgx = New Regex("-[0-9]*")
        matches = rgx.Matches(t)
        If matches.Count > 0 Then
            If matches.Item(0).ToString = t Then
                Exit Sub
            End If
        End If
        'check format for "1234e"
        rgx = New Regex("[0-9]*e", RegexOptions.IgnoreCase)
        matches = rgx.Matches(t)
        If matches.Count > 0 Then
            If matches.Item(0).ToString = t Then
                Exit Sub
            End If
        End If
        'check format for "-1234e"
        rgx = New Regex("-[0-9]*e", RegexOptions.IgnoreCase)
        matches = rgx.Matches(t)
        If matches.Count > 0 Then
            If matches.Item(0).ToString = t Then
                Exit Sub
            End If
        End If
        'check format for "1234e123"
        rgx = New Regex("[0-9]*e[0-9]*", RegexOptions.IgnoreCase)
        matches = rgx.Matches(t)
        If matches.Count > 0 Then
            If matches.Item(0).ToString = t Then
                Exit Sub
            End If
        End If
        'check format for "-1234e123"
        rgx = New Regex("-[0-9]*e[0-9]*", RegexOptions.IgnoreCase)
        matches = rgx.Matches(t)
        If matches.Count > 0 Then
            If matches.Item(0).ToString = t Then
                Exit Sub
            End If
        End If
        'check format for "1234e-123"
        rgx = New Regex("[0-9]*e-[0-9]*", RegexOptions.IgnoreCase)
        matches = rgx.Matches(t)
        If matches.Count > 0 Then
            If matches.Item(0).ToString = t Then
                Exit Sub
            End If
        End If
        'check format for "-1234e-123"
        rgx = New Regex("-[0-9]*e-[0-9]*", RegexOptions.IgnoreCase)
        matches = rgx.Matches(t)
        If matches.Count > 0 Then
            If matches.Item(0).ToString = t Then
                Exit Sub
            End If
        End If
        'return to last number
        If validKey = True Then
            p = p - 1
        End If
        If isKeyPressedABackspace = True Then
            p = p + 1
        End If
        txtValueNumber.Text = oldValueNumber
        txtValueNumber.SelectionStart = p
    End Sub
    'handle default value name
    Dim defaultValueName As String = "keyname"
    Dim defaultValueNameCount As Integer = 0
    Private Function requestDefaultValueName() As String
        'get depth
        Dim d As Integer = jsonTree.SelectedNode.Level
        'if this level is the first node of the treeview than it is not a valid node
        If d < 1 Then Return ""
        'get current node selection
        Dim node As TreeNode = jsonTree.SelectedNode.Parent.Clone
        Dim nodeCount As Integer = node.Nodes.Count
        Dim valueNameArray(0 To nodeCount) As String
        Dim counter As Integer = 0
        Dim nodeCollection As TreeNodeCollection = node.Nodes
        'build regex
        Dim s As String = "(" & defaultValueName & "\s[0-9]*)$"
        Dim rgx As New Regex(s)
        Dim matches As MatchCollection
        'find all of the default keys that exist on this selected node (they should match the pattern: "keyname 123"
        For Each node In nodeCollection
            matches = rgx.Matches(node.Name)
            If matches.Count > 0 Then
                'found a match add it to the array
                valueNameArray(counter) = matches(0).ToString
                counter += 1
            End If
        Next
        'there should be no duplicates.
        Dim found As Boolean = False
        For counter = 0 To nodeCount
            s = defaultValueName & " " & counter.ToString
            found = False
            For Each n In valueNameArray
                If n = s Then
                    found = True
                    Exit For
                End If
            Next
            If found = False Then
                'was not found, use this one
                'MsgBox(s)
                Return s
            End If
        Next

        Return ""
    End Function
    Public Function requestDefaultParentObjectName() As String
        Dim s As String = "^(JSON object [0-9]*)$"
        Dim rgx As New Regex(s)
        Dim matches As MatchCollection
        Dim nodeCollection As TreeNodeCollection = jsonTree.Nodes
        If nodeCollection.Count = 0 Then Return "JSON object 0"
        Dim defaultNamesFound(0 To nodeCollection.Count - 1) As String
        Dim count As Integer = 0
        For Each node As TreeNode In nodeCollection
            matches = rgx.Matches(node.Text)
            If matches.Count > 0 Then
                defaultNamesFound(count) = node.Text
                count += 1
            End If
        Next
        Dim found As Boolean = False
        For count = 0 To nodeCollection.Count - 1
            s = "JSON object " & count.ToString
            found = False
            For Each n In defaultNamesFound
                If n = s Then
                    found = True
                    Exit For
                End If
            Next
            If found = False Then
                'was not found, use this one
                'MsgBox(s)
                Return s
            End If
        Next
        s = "JSON object " & nodeCollection.Count.ToString
        Return s
    End Function
    Public Function requestDefaultParentArrayName() As String
        Dim s As String = "^(JSON array [0-9]*)$"
        Dim rgx As New Regex(s)
        Dim matches As MatchCollection
        Dim nodeCollection As TreeNodeCollection = jsonTree.Nodes
        If nodeCollection.Count = 0 Then Return "JSON array 0"
        Dim defaultNamesFound(0 To nodeCollection.Count - 1) As String
        Dim count As Integer = 0
        For Each node As TreeNode In nodeCollection
            matches = rgx.Matches(node.Text)
            If matches.Count > 0 Then
                defaultNamesFound(count) = node.Text
                count += 1
            End If
        Next
        Dim found As Boolean = False
        For count = 0 To nodeCollection.Count - 1
            s = "JSON array " & count.ToString
            found = False
            For Each n In defaultNamesFound
                If n = s Then
                    found = True
                    Exit For
                End If
            Next
            If found = False Then
                'was not found, use this one
                'MsgBox(s)
                Return s
            End If
        Next
        s = "JSON array " & nodeCollection.Count.ToString
        Return s
    End Function
    Private Function isDefaultValueName(ByVal s As String) As Boolean
        Dim r As String = "(" & defaultValueName & "\s[0-9]*)$"
        Dim rgx As New Regex(r)
        Dim matches As MatchCollection = rgx.Matches(s)
        If matches.Count > 0 Then Return True

        Return False
    End Function
    'handle name input validation.. do not allow colons or backslashes
    Dim oldValueName As String = defaultValueName & " " & defaultValueNameCount.ToString
    Dim lastValueNameSelectionPosition As Integer = 0
    Dim lastValueNameSelectionLength
    Private Sub txtValueName_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtValueName.KeyDown
        oldValueName = txtValueName.Text
    End Sub
    Private Sub txtValueName_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtValueName.KeyPress
        Dim t As String = e.KeyChar
        Select Case t
            Case ":"
                e.KeyChar = ""
            Case "\"
                e.KeyChar = ""
        End Select
        lastValueNameSelectionPosition = txtValueName.SelectionStart
        lastValueNameSelectionLength = txtValueName.SelectionLength

    End Sub
    Private Sub txtValueName_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles txtValueName.MouseDown
        lastValueNameSelectionPosition = txtValueName.SelectionStart
        lastValueNameSelectionLength = txtValueName.SelectionLength
    End Sub
    Private Sub txtValueName_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtValueName.TextChanged

        'get name
        Dim t As String = txtValueName.Text

        'build a reg ex for backslash
        Dim rgx As New Regex("\\")
        Dim matches As MatchCollection = rgx.Matches(t)
        'if a match is found, then return the textbox to its last value and try to put the caret position back too.
        If matches.Count > 0 Then
            txtValueName.Text = oldValueName
            txtValueName.SelectionStart = lastValueNameSelectionPosition
            txtValueName.SelectionLength = lastValueNameSelectionLength
        End If
        'repeat the above but for a colon.
        rgx = New Regex(":")
        matches = rgx.Matches(t)
        If matches.Count > 0 Then
            txtValueName.Text = oldValueName
            txtValueName.SelectionStart = lastValueNameSelectionPosition
            txtValueName.SelectionLength = lastValueNameSelectionLength

        End If

        oldValueName = txtValueName.Text
    End Sub
    'flash the value name text box when there is an invalid name used
    Sub flashValueName()
        txtValueName.BackColor = Color.Coral
        tmrFlashKeyTextbox.Enabled = True
    End Sub
    'remove item from string array by index
    Sub removeElementFromStringArrayByIndex(ByRef s() As String, ByVal i As UInteger)
        For i = i To s.Length - 2
            s(i) = s(i + 1)
        Next
        ReDim Preserve s(s.Length - 2)
    End Sub
    Sub removeElementFromJObjectArrayByIndex(ByRef j() As JObject, ByVal i As UInteger)
        For i = i To j.Length - 2
            j(i) = j(i + 1)
        Next
        ReDim Preserve j(j.Length - 2)
    End Sub
    Sub removeElementFromJArrayArrayByIndex(ByRef j() As JArray, ByVal i As UInteger)
        For i = i To j.Length - 2
            j(i) = j(i + 1)
        Next
        ReDim Preserve j(j.Length - 2)
    End Sub
    Private Sub DeleteJSONToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles DeleteJSONToolStripMenuItem.Click
        If IsNothing(jsonTree.SelectedNode) Then Exit Sub

        Dim i As Integer = 0
        Dim s As String = selectedJSON_topParentName
        Dim r As MsgBoxResult = MsgBox("Are you sure you want" & vbNewLine & "to delete " & s & "?", MsgBoxStyle.YesNo)

        Select Case r
            Case MsgBoxResult.No
                Exit Sub
        End Select

        Select Case selectedJSON_topParentType

            Case "object"
                i = returnIndexOfParentObject()
                removeElementFromJObjectArrayByIndex(JSON_parentObject, i)
                removeElementFromStringArrayByIndex(JSON_objectNameList, i)
            Case "array"
                i = returnIndexOfParentArray()
                removeElementFromJArrayArrayByIndex(JSON_parentArray, i)
                removeElementFromStringArrayByIndex(JSON_arrayNameList, i)
        End Select



        For i = 0 To jsonTree.Nodes.Count - 1
            If jsonTree.Nodes(i).Text = s Then
                Me.jsonTree.Nodes(i).Remove()
                Exit For
            End If
        Next

        If jsonTree.Nodes.Count = 0 Then
            SaveJSONToolStripMenuItem.Enabled = False
            DeleteJSONToolStripMenuItem.Enabled = False
            disableValuePanel()
            txtJSON_string.Text = ""
        End If
        updateTextboxJSON_keyset()
    End Sub
    Private Sub FromStringToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles FromStringToolStripMenuItem.Click
        frmLoadJSON.Show()

    End Sub
    Private Sub FromFileToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles FromFileToolStripMenuItem.Click

        Dim dialog As New OpenFileDialog()
        dialog.Title = "Open JSON data file.."
        dialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop
        'dialog.DereferenceLinks = True 'commented outdefault is already true.

        If DialogResult.OK = dialog.ShowDialog Then
            frmLoadJSON.Show()
            Dim sr As New IO.StreamReader(dialog.FileName)
            frmLoadJSON.txtJSON_string.Text = sr.ReadToEnd
            frmLoadJSON.btnAdd.PerformClick()
            sr.Close()
        End If


    End Sub
    Private Sub tmrFlashKeyTextbox_Tick(sender As System.Object, e As System.EventArgs) Handles tmrFlashKeyTextbox.Tick
        txtValueName.BackColor = System.Drawing.Color.White
        tmrFlashKeyTextbox.Enabled = False

    End Sub
    Private Sub SaveJSONToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SaveJSONToolStripMenuItem.Click
        Dim dialog As New SaveFileDialog
        dialog.Title = "Save JSON data as.."
        dialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop
        If DialogResult.OK = dialog.ShowDialog Then
            Try
                My.Computer.FileSystem.WriteAllText(dialog.FileName, txtJSON_string.Text, False)
            Catch ex As Exception
                MsgBox(ex.ToString)
                MsgBox("This file you are trying to save over might be open already")
            End Try

        End If
    End Sub
End Class

