Imports System.Text.RegularExpressions
Imports Newtonsoft.Json.Linq
Public Class frmLoadJSON
    'Dim rgx As New Regex("^\s*\{")
    Dim rgx As New Regex("^\s*[\{\[]{1}")
    Dim matches As MatchCollection
    'form controls
    Private Sub btnAdd_Click(sender As System.Object, e As System.EventArgs) Handles btnAdd.Click
        'check if there is text to parse
        If txtJSON_string.Text.Length = 0 Then Exit Sub
        'get name/text of JSON array or object.
        Dim JSON_name As String = ""
        Dim JSON_text As String = ""
        Dim JSON_type As String = returnJSON_type(txtJSON_string.Text)
        'this is selected for twice to give the option of canceling the process.
        Select Case JSON_type
            Case "array"
                'get name/text of array
                JSON_text = Form1.RequestNameForAddArray()
                'check name
                If JSON_text = "" Then Exit Sub
                'amend name
                JSON_name = "[array][array]" & JSON_text
                'try to parse this json object to see if it is possible before continuing
                Try
                    Dim jsonArray As JArray = JArray.Parse(txtJSON_string.Text)
                    'add this json array to the array of json arrays in form1
                    Form1.addLoadedJSON_array(jsonArray)
                    'add json name to array of json array names.
                    Form1.addElementToJSON_arrayNameList(JSON_text)
                Catch ex As Exception

                    MsgBox(ex.ToString)
                    MsgBox("There has been an error with your JSON data.." & vbNewLine & "Please double check it.")
                    Exit Sub
                End Try
            Case "object"
                'get name/text of object
                JSON_text = Form1.RequestNameForAddObject()
                'check name
                If JSON_text = "" Then Exit Sub
                'amend name
                JSON_name = "[object][object]" & JSON_text
                'try to parse this json object to see if it is possible before continuing
                Try
                    Dim jsonObject As JObject = JObject.Parse(txtJSON_string.Text)
                    Form1.addLoadedJSON_object(jsonObject)
                    Form1.addElementToJSON_objectNameList(JSON_text)
                Catch ex As Exception

                    MsgBox(ex.ToString)
                    MsgBox("There has been an error with your JSON data.." & vbNewLine & "Please double check it.")
                    Exit Sub
                End Try
            Case Else
                MsgBox("There has been an error with your JSON data.." & vbNewLine & "Please double check it.")
                Exit Sub
        End Select
        'process the JSON string from txtJSON_string.text into a treenode using the recursive function returnTreeNodeFromJSON_string()
        Dim node As TreeNode = returnTreeNodeFromJSON_string(txtJSON_string.Text, JSON_type, JSON_name, JSON_text)
        'add node to JSON tree view in form1
        Form1.addNodeToJSON_tree(node)
        'enabled value panel
        Form1.enableValuePanel()
        'enable menu items for saving and deleting :D (almost done)
        Form1.DeleteJSONToolStripMenuItem.Enabled = True
        Form1.SaveJSONToolStripMenuItem.Enabled = True
        'hide this window
        Me.Visible = False

    End Sub
    Private Sub frmLoadJSON_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.Visible = False
        e.Cancel = True
    End Sub
    'functions
    Function getNameOfJSON_object() As String
        Dim r As String = Form1.requestDefaultParentObjectName
        Return InputBox("Please name this JSON Object:", "Input JSON Object Name", r)
    End Function
    Function getNameOfJSON_array() As String
        Dim r As String = Form1.requestDefaultParentArrayName
        Return InputBox("Please name this JSON Array:")
    End Function
    Function returnJSON_type(ByRef JSON_string As String) As String
        'search input string for "{" or "["
        matches = rgx.Matches(JSON_string)
        'if for some reason the variable matches is not initiated, return the string "-1".
        If IsNothing(matches) Then Return "-1"
        'check if there are matches by assuming a count of the matches should be greater than zero if there are in fact matches.
        Dim s As String = ""
        If matches.Count > 0 Then
            'success, there are matches! 
            s = matches(0).ToString.Replace(" ", "").Replace(vbNewLine, "").Substring(0, 1)
            Select Case s
                Case "["
                    Return "array"
                Case "{"
                    Return "object"
            End Select

        End If
        Return "undefined"
    End Function
    Function returnTreeNodeFromJSON_string(ByVal JSON_string As String, ByVal JSON_type As String, ByVal JSON_name As String, ByVal JSON_text As String) As TreeNode
        'create tree node that will be passed back from the function
        Dim node As New TreeNode
        'this is the parent treenode, apply name and text.
        node.Name = JSON_name
        node.Text = JSON_text
        'check json type
        Select Case JSON_type
            Case "array"
                'add first node
                node.Nodes.Add("[")
                'process json array
                Dim JSON_array As JArray = JArray.Parse(JSON_string)
                'check count of JSON_array
                If JSON_array.Count > 0 Then
                    'create array of treeview nodes.
                    Dim nodes(0 To JSON_array.Count - 1) As TreeNode
                    'process the JSON array into an array of tree nodes.
                    nodes = processJSON_array(JSON_array)
                    'add this range of treenodes.
                    node.Nodes.AddRange(nodes)
                End If
                'add last nodes
                node.Nodes.Add("add element..")
                node.Nodes.Add("]")
            Case "object"
                'add first node
                node.Nodes.Add("{")
                'process object
                Dim JSON_object As JObject = JObject.Parse(JSON_string)
                'check count of JSON_array
                If JSON_object.Count > 0 Then
                    'create array of treeview nodes.
                    Dim nodes(0 To JSON_object.Count - 1) As TreeNode
                    'process the JSON array into an array of tree nodes.
                    nodes = processJSON_object(JSON_object)
                    'add this range of treenodes.
                    node.Nodes.AddRange(nodes)
                End If
                'add last nodes
                node.Nodes.Add("add member..")
                node.Nodes.Add("}")
        End Select

        Return node
    End Function
    Function processJSON_object(ByRef jsonObject As JObject) As TreeNode()
        'create an array of treeview nodes
        Dim nodes(0 To jsonObject.Count - 1) As TreeNode
        'keep track of which jsonObject child by counting from 0.
        Dim count As Integer = 0
        'go through each item in the JSON object, extract a name and a value.
        Dim siblings As List(Of JToken) = jsonObject.Children.ToList
        'build an array of json key names
        Dim JSON_keyArray(0 To jsonObject.Count - 1) As String
        For Each child As JProperty In siblings
            'create a reader (not sure why, but it's probably needed.. again don't know why)
            child.CreateReader()
            'add this key to the array of json key names
            JSON_keyArray(count) = child.Name
            'increment count integer
            count += 1
        Next
        'reset count
        count = 0
        Dim childTreeNodes() As TreeNode
        Dim tempNode As New TreeNode
        'go through each key in this json object.
        For Each JSON_key As String In JSON_keyArray
            Select Case jsonObject(JSON_key).Type
                Case JTokenType.Array
                    'case for a nested json array
                    'declare new treenode for the array element at position "count".
                    nodes(count) = New TreeNode
                    'name this node in relation to it's parent node type and it's own type
                    nodes(count).Name = "[object][array]" & JSON_key
                    'give this node some text
                    nodes(count).Text = JSON_key
                    'produce a child node for this json child, which is an array.
                    nodes(count).Nodes.Add("[")
                    'get all of the sub nodes using a recursive function
                    childTreeNodes = processJSON_array(jsonObject(JSON_key))
                    'add a range of nodes to this child node
                    nodes(count).Nodes.AddRange(childTreeNodes)
                    'finish off the child node with an end brace and "add element.." nodes.
                    nodes(count).Nodes.Add("add element..").Name = "[object][undefined]"
                    nodes(count).Nodes.Add("]")
                Case JTokenType.Object
                    'basically the same as above but for a nested json object.
                    nodes(count) = New TreeNode
                    nodes(count).Name = "[object][object]" & JSON_key
                    nodes(count).Text = JSON_key
                    nodes(count).Nodes.Add("{")
                    childTreeNodes = processJSON_object(jsonObject(JSON_key))
                    nodes(count).Nodes.AddRange(childTreeNodes)
                    nodes(count).Nodes.Add("add member..").Name = "[object][undefined]"
                    nodes(count).Nodes.Add("}")
                Case JTokenType.Boolean
                    nodes(count) = New TreeNode
                    nodes(count).Name = "[object][boolean]" & JSON_key
                    nodes(count).Text = JSON_key & ": " & jsonObject(JSON_key).ToString
                Case JTokenType.String
                    nodes(count) = New TreeNode
                    nodes(count).Name = "[object][string]" & JSON_key
                    nodes(count).Text = JSON_key & ": " & jsonObject(JSON_key).ToString
                Case JTokenType.Integer
                    nodes(count) = New TreeNode
                    nodes(count).Name = "[object][number]" & JSON_key
                    nodes(count).Text = JSON_key & ": " & jsonObject(JSON_key).ToString
                Case JTokenType.Float
                    nodes(count) = New TreeNode
                    nodes(count).Name = "[object][number]" & JSON_key
                    nodes(count).Text = JSON_key & ": " & jsonObject(JSON_key).ToString
                Case JTokenType.Null
                    nodes(count) = New TreeNode
                    nodes(count).Name = "[object][null]" & JSON_key
                    nodes(count).Text = JSON_key & ": null"
                Case Else
                    nodes(count) = New TreeNode
                    nodes(count).Name = "[object][unknown]" & JSON_key
                    nodes(count).Text = JSON_key & ": " & jsonObject(JSON_key).ToString
            End Select
            'increment count
            count += 1
        Next


        Return nodes

    End Function
    Function processJSON_array(ByRef jsonArray As JArray) As TreeNode()
        'create an array of treeview nodes
        Dim nodes(0 To jsonArray.Count - 1) As TreeNode
        'keep track of which jsonObject child by counting from 0.
        Dim count As Integer = 0
        'we need an array to obtain any nested nodes (such as for a nested array or object)
        Dim childTreeNodes() As TreeNode
        'go through each item in the JSON object, extract a name and a value.
        For count = 0 To jsonArray.Count - 1
            'select case for the json element type at position "count"
            Select Case jsonArray(count).Type
                Case JTokenType.Array
                    'case for a nested json array
                    'declare new treenode for the array element at position "count".
                    nodes(count) = New TreeNode
                    'name this node in relation to it's parent node type and it's own type
                    nodes(count).Name = "[array][array]" & count
                    'give this node some text
                    nodes(count).Text = "[" & count & "]"
                    'produce a child node for this json child, which is an array.
                    nodes(count).Nodes.Add("[")
                    'get all of the sub nodes using a recursive function
                    childTreeNodes = processJSON_array(jsonArray(count))
                    'add a range of nodes to this child node
                    nodes(count).Nodes.AddRange(childTreeNodes)
                    'finish off the child node with an end brace and "add element.." nodes.
                    nodes(count).Nodes.Add("add element..").Name = "[object][undefined]"
                    nodes(count).Nodes.Add("]")
                Case JTokenType.Object
                    'basically the same as above but for a nested json object.
                    nodes(count) = New TreeNode
                    nodes(count).Name = "[array][object]" & count
                    nodes(count).Text = "[" & count & "]"
                    nodes(count).Nodes.Add("{")
                    childTreeNodes = processJSON_object(jsonArray(count))
                    nodes(count).Nodes.AddRange(childTreeNodes)
                    nodes(count).Nodes.Add("add member..").Name = "[object][undefined]"
                    nodes(count).Nodes.Add("}")
                Case JTokenType.Boolean
                    nodes(count) = New TreeNode
                    nodes(count).Name = "[array][boolean]" & count
                    nodes(count).Text = "(" & count & "): " & jsonArray(count).ToString
                Case JTokenType.String
                    nodes(count) = New TreeNode
                    nodes(count).Name = "[array][string]" & count
                    nodes(count).Text = "(" & count & "): " & jsonArray(count).ToString
                Case JTokenType.Integer
                    nodes(count) = New TreeNode
                    nodes(count).Name = "[array][number]" & count
                    nodes(count).Text = "(" & count & "): " & jsonArray(count).ToString
                Case JTokenType.Float
                    nodes(count) = New TreeNode
                    nodes(count).Name = "[array][number]" & count
                    nodes(count).Text = "(" & count & "): " & jsonArray(count).ToString
                Case JTokenType.Null
                    nodes(count) = New TreeNode
                    nodes(count).Name = "[array][null]" & count
                    nodes(count).Text = "(" & count & "): null"
                Case Else
                    nodes(count) = New TreeNode
                    nodes(count).Name = "[array][unknown]" & count
                    nodes(count).Text = "(" & count & "): " & jsonArray(count).ToString
            End Select
        Next
        Return nodes
    End Function
End Class
