﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:4.0.30319.42000
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On

Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Data.Linq
Imports System.Data.Linq.Mapping
Imports System.Linq
Imports System.Linq.Expressions
Imports System.Reflection


<Global.System.Data.Linq.Mapping.DatabaseAttribute(Name:="AJDNNDatabase_v5")>  _
Partial Public Class QuestLinqDataContext
	Inherits System.Data.Linq.DataContext
	
	Private Shared mappingSource As System.Data.Linq.Mapping.MappingSource = New AttributeMappingSource()
	
  #Region "Extensibility Method Definitions"
  Partial Private Sub OnCreated()
  End Sub
  Partial Private Sub InserttblAjBokmarkelser(instance As tblAjBokmarkelser)
    End Sub
  Partial Private Sub UpdatetblAjBokmarkelser(instance As tblAjBokmarkelser)
    End Sub
  Partial Private Sub DeletetblAjBokmarkelser(instance As tblAjBokmarkelser)
    End Sub
  Partial Private Sub Inserttbl_aj_QuestUser(instance As tbl_aj_QuestUser)
    End Sub
  Partial Private Sub Updatetbl_aj_QuestUser(instance As tbl_aj_QuestUser)
    End Sub
  Partial Private Sub Deletetbl_aj_QuestUser(instance As tbl_aj_QuestUser)
    End Sub
  Partial Private Sub Inserttbl_aj_QuestUserToTrigger(instance As tbl_aj_QuestUserToTrigger)
    End Sub
  Partial Private Sub Updatetbl_aj_QuestUserToTrigger(instance As tbl_aj_QuestUserToTrigger)
    End Sub
  Partial Private Sub Deletetbl_aj_QuestUserToTrigger(instance As tbl_aj_QuestUserToTrigger)
    End Sub
  Partial Private Sub Inserttbl_aj_QuestTrigger(instance As tbl_aj_QuestTrigger)
    End Sub
  Partial Private Sub Updatetbl_aj_QuestTrigger(instance As tbl_aj_QuestTrigger)
    End Sub
  Partial Private Sub Deletetbl_aj_QuestTrigger(instance As tbl_aj_QuestTrigger)
    End Sub
  Partial Private Sub Inserttbl_aj_Quest(instance As tbl_aj_Quest)
    End Sub
  Partial Private Sub Updatetbl_aj_Quest(instance As tbl_aj_Quest)
    End Sub
  Partial Private Sub Deletetbl_aj_Quest(instance As tbl_aj_Quest)
    End Sub
  #End Region
	
	Public Sub New()
		MyBase.New(Global.QuestLibrary.My.MySettings.Default.AJDNNDatabase_v5ConnectionString1, mappingSource)
		OnCreated
	End Sub
	
	Public Sub New(ByVal connection As String)
		MyBase.New(connection, mappingSource)
		OnCreated
	End Sub
	
	Public Sub New(ByVal connection As System.Data.IDbConnection)
		MyBase.New(connection, mappingSource)
		OnCreated
	End Sub
	
	Public Sub New(ByVal connection As String, ByVal mappingSource As System.Data.Linq.Mapping.MappingSource)
		MyBase.New(connection, mappingSource)
		OnCreated
	End Sub
	
	Public Sub New(ByVal connection As System.Data.IDbConnection, ByVal mappingSource As System.Data.Linq.Mapping.MappingSource)
		MyBase.New(connection, mappingSource)
		OnCreated
	End Sub
	
	Public ReadOnly Property tblAjBokmarkelsers() As System.Data.Linq.Table(Of tblAjBokmarkelser)
		Get
			Return Me.GetTable(Of tblAjBokmarkelser)
		End Get
	End Property
	
	Public ReadOnly Property tbl_aj_QuestUsers() As System.Data.Linq.Table(Of tbl_aj_QuestUser)
		Get
			Return Me.GetTable(Of tbl_aj_QuestUser)
		End Get
	End Property
	
	Public ReadOnly Property tbl_aj_QuestUserToTriggers() As System.Data.Linq.Table(Of tbl_aj_QuestUserToTrigger)
		Get
			Return Me.GetTable(Of tbl_aj_QuestUserToTrigger)
		End Get
	End Property
	
	Public ReadOnly Property tbl_aj_QuestTriggers() As System.Data.Linq.Table(Of tbl_aj_QuestTrigger)
		Get
			Return Me.GetTable(Of tbl_aj_QuestTrigger)
		End Get
	End Property
	
	Public ReadOnly Property tbl_aj_Quests() As System.Data.Linq.Table(Of tbl_aj_Quest)
		Get
			Return Me.GetTable(Of tbl_aj_Quest)
		End Get
	End Property
	
	<Global.System.Data.Linq.Mapping.FunctionAttribute(Name:="dbo.aj_quest_isUserSubQuestCompleted")>  _
	Public Function aj_quest_isUserSubQuestCompleted(<Global.System.Data.Linq.Mapping.ParameterAttribute(DbType:="Int")> ByVal userid As System.Nullable(Of Integer), <Global.System.Data.Linq.Mapping.ParameterAttribute(DbType:="Int")> ByVal questid As System.Nullable(Of Integer), <Global.System.Data.Linq.Mapping.ParameterAttribute(DbType:="Int")> ByVal triggerid As System.Nullable(Of Integer)) As ISingleResult(Of aj_quest_isUserSubQuestCompletedResult)
		Dim result As IExecuteResult = Me.ExecuteMethodCall(Me, CType(MethodInfo.GetCurrentMethod,MethodInfo), userid, questid, triggerid)
		Return CType(result.ReturnValue,ISingleResult(Of aj_quest_isUserSubQuestCompletedResult))
	End Function
End Class

<Global.System.Data.Linq.Mapping.TableAttribute(Name:="dbo.tblAjBokmarkelser")>  _
Partial Public Class tblAjBokmarkelser
	Implements System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
	
	Private Shared emptyChangingEventArgs As PropertyChangingEventArgs = New PropertyChangingEventArgs(String.Empty)
	
	Private _Aid As Integer
	
	Private _Awardname As String
	
	Private _Levels As Integer
	
	Private _Beskrivning As String
	
	Private _Occurs As Integer
	
	Private _Badgesrc As String
	
	Private _Awardgroup As System.Nullable(Of Integer)
	
    #Region "Extensibility Method Definitions"
    Partial Private Sub OnLoaded()
    End Sub
    Partial Private Sub OnValidate(action As System.Data.Linq.ChangeAction)
    End Sub
    Partial Private Sub OnCreated()
    End Sub
    Partial Private Sub OnAidChanging(value As Integer)
    End Sub
    Partial Private Sub OnAidChanged()
    End Sub
    Partial Private Sub OnAwardnameChanging(value As String)
    End Sub
    Partial Private Sub OnAwardnameChanged()
    End Sub
    Partial Private Sub OnLevelsChanging(value As Integer)
    End Sub
    Partial Private Sub OnLevelsChanged()
    End Sub
    Partial Private Sub OnBeskrivningChanging(value As String)
    End Sub
    Partial Private Sub OnBeskrivningChanged()
    End Sub
    Partial Private Sub OnOccursChanging(value As Integer)
    End Sub
    Partial Private Sub OnOccursChanged()
    End Sub
    Partial Private Sub OnBadgesrcChanging(value As String)
    End Sub
    Partial Private Sub OnBadgesrcChanged()
    End Sub
    Partial Private Sub OnAwardgroupChanging(value As System.Nullable(Of Integer))
    End Sub
    Partial Private Sub OnAwardgroupChanged()
    End Sub
    #End Region
	
	Public Sub New()
		MyBase.New
		OnCreated
	End Sub
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_Aid", AutoSync:=AutoSync.OnInsert, DbType:="Int NOT NULL IDENTITY", IsPrimaryKey:=true, IsDbGenerated:=true)>  _
	Public Property Aid() As Integer
		Get
			Return Me._Aid
		End Get
		Set
			If ((Me._Aid = value)  _
						= false) Then
				Me.OnAidChanging(value)
				Me.SendPropertyChanging
				Me._Aid = value
				Me.SendPropertyChanged("Aid")
				Me.OnAidChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_Awardname", DbType:="NVarChar(100) NOT NULL", CanBeNull:=false)>  _
	Public Property Awardname() As String
		Get
			Return Me._Awardname
		End Get
		Set
			If (String.Equals(Me._Awardname, value) = false) Then
				Me.OnAwardnameChanging(value)
				Me.SendPropertyChanging
				Me._Awardname = value
				Me.SendPropertyChanged("Awardname")
				Me.OnAwardnameChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_Levels", DbType:="Int NOT NULL")>  _
	Public Property Levels() As Integer
		Get
			Return Me._Levels
		End Get
		Set
			If ((Me._Levels = value)  _
						= false) Then
				Me.OnLevelsChanging(value)
				Me.SendPropertyChanging
				Me._Levels = value
				Me.SendPropertyChanged("Levels")
				Me.OnLevelsChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_Beskrivning", DbType:="NVarChar(150)")>  _
	Public Property Beskrivning() As String
		Get
			Return Me._Beskrivning
		End Get
		Set
			If (String.Equals(Me._Beskrivning, value) = false) Then
				Me.OnBeskrivningChanging(value)
				Me.SendPropertyChanging
				Me._Beskrivning = value
				Me.SendPropertyChanged("Beskrivning")
				Me.OnBeskrivningChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_Occurs", DbType:="Int NOT NULL")>  _
	Public Property Occurs() As Integer
		Get
			Return Me._Occurs
		End Get
		Set
			If ((Me._Occurs = value)  _
						= false) Then
				Me.OnOccursChanging(value)
				Me.SendPropertyChanging
				Me._Occurs = value
				Me.SendPropertyChanged("Occurs")
				Me.OnOccursChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_Badgesrc", DbType:="NVarChar(150)")>  _
	Public Property Badgesrc() As String
		Get
			Return Me._Badgesrc
		End Get
		Set
			If (String.Equals(Me._Badgesrc, value) = false) Then
				Me.OnBadgesrcChanging(value)
				Me.SendPropertyChanging
				Me._Badgesrc = value
				Me.SendPropertyChanged("Badgesrc")
				Me.OnBadgesrcChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_Awardgroup", DbType:="Int")>  _
	Public Property Awardgroup() As System.Nullable(Of Integer)
		Get
			Return Me._Awardgroup
		End Get
		Set
			If (Me._Awardgroup.Equals(value) = false) Then
				Me.OnAwardgroupChanging(value)
				Me.SendPropertyChanging
				Me._Awardgroup = value
				Me.SendPropertyChanged("Awardgroup")
				Me.OnAwardgroupChanged
			End If
		End Set
	End Property
	
	Public Event PropertyChanging As PropertyChangingEventHandler Implements System.ComponentModel.INotifyPropertyChanging.PropertyChanging
	
	Public Event PropertyChanged As PropertyChangedEventHandler Implements System.ComponentModel.INotifyPropertyChanged.PropertyChanged
	
	Protected Overridable Sub SendPropertyChanging()
		If ((Me.PropertyChangingEvent Is Nothing)  _
					= false) Then
			RaiseEvent PropertyChanging(Me, emptyChangingEventArgs)
		End If
	End Sub
	
	Protected Overridable Sub SendPropertyChanged(ByVal propertyName As [String])
		If ((Me.PropertyChangedEvent Is Nothing)  _
					= false) Then
			RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
		End If
	End Sub
End Class

<Global.System.Data.Linq.Mapping.TableAttribute(Name:="dbo.tbl_aj_QuestUser")>  _
Partial Public Class tbl_aj_QuestUser
	Implements System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
	
	Private Shared emptyChangingEventArgs As PropertyChangingEventArgs = New PropertyChangingEventArgs(String.Empty)
	
	Private _UQuestID As Integer
	
	Private _Userid As System.Nullable(Of Integer)
	
	Private _Questid As System.Nullable(Of Integer)
	
	Private _Completed As System.Nullable(Of Integer)
	
	Private _datum As System.Nullable(Of Date)
	
	Private _tid As System.Nullable(Of Date)
	
    #Region "Extensibility Method Definitions"
    Partial Private Sub OnLoaded()
    End Sub
    Partial Private Sub OnValidate(action As System.Data.Linq.ChangeAction)
    End Sub
    Partial Private Sub OnCreated()
    End Sub
    Partial Private Sub OnUQuestIDChanging(value As Integer)
    End Sub
    Partial Private Sub OnUQuestIDChanged()
    End Sub
    Partial Private Sub OnUseridChanging(value As System.Nullable(Of Integer))
    End Sub
    Partial Private Sub OnUseridChanged()
    End Sub
    Partial Private Sub OnQuestidChanging(value As System.Nullable(Of Integer))
    End Sub
    Partial Private Sub OnQuestidChanged()
    End Sub
    Partial Private Sub OnCompletedChanging(value As System.Nullable(Of Integer))
    End Sub
    Partial Private Sub OnCompletedChanged()
    End Sub
    Partial Private Sub OndatumChanging(value As System.Nullable(Of Date))
    End Sub
    Partial Private Sub OndatumChanged()
    End Sub
    Partial Private Sub OntidChanging(value As System.Nullable(Of Date))
    End Sub
    Partial Private Sub OntidChanged()
    End Sub
    #End Region
	
	Public Sub New()
		MyBase.New
		OnCreated
	End Sub
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_UQuestID", AutoSync:=AutoSync.OnInsert, DbType:="Int NOT NULL IDENTITY", IsPrimaryKey:=true, IsDbGenerated:=true)>  _
	Public Property UQuestID() As Integer
		Get
			Return Me._UQuestID
		End Get
		Set
			If ((Me._UQuestID = value)  _
						= false) Then
				Me.OnUQuestIDChanging(value)
				Me.SendPropertyChanging
				Me._UQuestID = value
				Me.SendPropertyChanged("UQuestID")
				Me.OnUQuestIDChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_Userid", DbType:="Int")>  _
	Public Property Userid() As System.Nullable(Of Integer)
		Get
			Return Me._Userid
		End Get
		Set
			If (Me._Userid.Equals(value) = false) Then
				Me.OnUseridChanging(value)
				Me.SendPropertyChanging
				Me._Userid = value
				Me.SendPropertyChanged("Userid")
				Me.OnUseridChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_Questid", DbType:="Int")>  _
	Public Property Questid() As System.Nullable(Of Integer)
		Get
			Return Me._Questid
		End Get
		Set
			If (Me._Questid.Equals(value) = false) Then
				Me.OnQuestidChanging(value)
				Me.SendPropertyChanging
				Me._Questid = value
				Me.SendPropertyChanged("Questid")
				Me.OnQuestidChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_Completed", DbType:="Int")>  _
	Public Property Completed() As System.Nullable(Of Integer)
		Get
			Return Me._Completed
		End Get
		Set
			If (Me._Completed.Equals(value) = false) Then
				Me.OnCompletedChanging(value)
				Me.SendPropertyChanging
				Me._Completed = value
				Me.SendPropertyChanged("Completed")
				Me.OnCompletedChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_datum", DbType:="Date")>  _
	Public Property datum() As System.Nullable(Of Date)
		Get
			Return Me._datum
		End Get
		Set
			If (Me._datum.Equals(value) = false) Then
				Me.OndatumChanging(value)
				Me.SendPropertyChanging
				Me._datum = value
				Me.SendPropertyChanged("datum")
				Me.OndatumChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_tid", DbType:="DateTime")>  _
	Public Property tid() As System.Nullable(Of Date)
		Get
			Return Me._tid
		End Get
		Set
			If (Me._tid.Equals(value) = false) Then
				Me.OntidChanging(value)
				Me.SendPropertyChanging
				Me._tid = value
				Me.SendPropertyChanged("tid")
				Me.OntidChanged
			End If
		End Set
	End Property
	
	Public Event PropertyChanging As PropertyChangingEventHandler Implements System.ComponentModel.INotifyPropertyChanging.PropertyChanging
	
	Public Event PropertyChanged As PropertyChangedEventHandler Implements System.ComponentModel.INotifyPropertyChanged.PropertyChanged
	
	Protected Overridable Sub SendPropertyChanging()
		If ((Me.PropertyChangingEvent Is Nothing)  _
					= false) Then
			RaiseEvent PropertyChanging(Me, emptyChangingEventArgs)
		End If
	End Sub
	
	Protected Overridable Sub SendPropertyChanged(ByVal propertyName As [String])
		If ((Me.PropertyChangedEvent Is Nothing)  _
					= false) Then
			RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
		End If
	End Sub
End Class

<Global.System.Data.Linq.Mapping.TableAttribute(Name:="dbo.tbl_aj_QuestUserToTrigger")>  _
Partial Public Class tbl_aj_QuestUserToTrigger
	Implements System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
	
	Private Shared emptyChangingEventArgs As PropertyChangingEventArgs = New PropertyChangingEventArgs(String.Empty)
	
	Private _id As Integer
	
	Private _UserQuestID As System.Nullable(Of Integer)
	
	Private _QTriggerID As System.Nullable(Of Integer)
	
	Private _Completed As System.Nullable(Of Integer)
	
	Private _Time As System.Nullable(Of Date)
	
    #Region "Extensibility Method Definitions"
    Partial Private Sub OnLoaded()
    End Sub
    Partial Private Sub OnValidate(action As System.Data.Linq.ChangeAction)
    End Sub
    Partial Private Sub OnCreated()
    End Sub
    Partial Private Sub OnidChanging(value As Integer)
    End Sub
    Partial Private Sub OnidChanged()
    End Sub
    Partial Private Sub OnUserQuestIDChanging(value As System.Nullable(Of Integer))
    End Sub
    Partial Private Sub OnUserQuestIDChanged()
    End Sub
    Partial Private Sub OnQTriggerIDChanging(value As System.Nullable(Of Integer))
    End Sub
    Partial Private Sub OnQTriggerIDChanged()
    End Sub
    Partial Private Sub OnCompletedChanging(value As System.Nullable(Of Integer))
    End Sub
    Partial Private Sub OnCompletedChanged()
    End Sub
    Partial Private Sub OnTimeChanging(value As System.Nullable(Of Date))
    End Sub
    Partial Private Sub OnTimeChanged()
    End Sub
    #End Region
	
	Public Sub New()
		MyBase.New
		OnCreated
	End Sub
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_id", AutoSync:=AutoSync.OnInsert, DbType:="Int NOT NULL IDENTITY", IsPrimaryKey:=true, IsDbGenerated:=true)>  _
	Public Property id() As Integer
		Get
			Return Me._id
		End Get
		Set
			If ((Me._id = value)  _
						= false) Then
				Me.OnidChanging(value)
				Me.SendPropertyChanging
				Me._id = value
				Me.SendPropertyChanged("id")
				Me.OnidChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_UserQuestID", DbType:="Int")>  _
	Public Property UserQuestID() As System.Nullable(Of Integer)
		Get
			Return Me._UserQuestID
		End Get
		Set
			If (Me._UserQuestID.Equals(value) = false) Then
				Me.OnUserQuestIDChanging(value)
				Me.SendPropertyChanging
				Me._UserQuestID = value
				Me.SendPropertyChanged("UserQuestID")
				Me.OnUserQuestIDChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_QTriggerID", DbType:="Int")>  _
	Public Property QTriggerID() As System.Nullable(Of Integer)
		Get
			Return Me._QTriggerID
		End Get
		Set
			If (Me._QTriggerID.Equals(value) = false) Then
				Me.OnQTriggerIDChanging(value)
				Me.SendPropertyChanging
				Me._QTriggerID = value
				Me.SendPropertyChanged("QTriggerID")
				Me.OnQTriggerIDChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_Completed", DbType:="Int")>  _
	Public Property Completed() As System.Nullable(Of Integer)
		Get
			Return Me._Completed
		End Get
		Set
			If (Me._Completed.Equals(value) = false) Then
				Me.OnCompletedChanging(value)
				Me.SendPropertyChanging
				Me._Completed = value
				Me.SendPropertyChanged("Completed")
				Me.OnCompletedChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_Time", DbType:="DateTime")>  _
	Public Property Time() As System.Nullable(Of Date)
		Get
			Return Me._Time
		End Get
		Set
			If (Me._Time.Equals(value) = false) Then
				Me.OnTimeChanging(value)
				Me.SendPropertyChanging
				Me._Time = value
				Me.SendPropertyChanged("Time")
				Me.OnTimeChanged
			End If
		End Set
	End Property
	
	Public Event PropertyChanging As PropertyChangingEventHandler Implements System.ComponentModel.INotifyPropertyChanging.PropertyChanging
	
	Public Event PropertyChanged As PropertyChangedEventHandler Implements System.ComponentModel.INotifyPropertyChanged.PropertyChanged
	
	Protected Overridable Sub SendPropertyChanging()
		If ((Me.PropertyChangingEvent Is Nothing)  _
					= false) Then
			RaiseEvent PropertyChanging(Me, emptyChangingEventArgs)
		End If
	End Sub
	
	Protected Overridable Sub SendPropertyChanged(ByVal propertyName As [String])
		If ((Me.PropertyChangedEvent Is Nothing)  _
					= false) Then
			RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
		End If
	End Sub
End Class

<Global.System.Data.Linq.Mapping.TableAttribute(Name:="dbo.tbl_aj_QuestTrigger")>  _
Partial Public Class tbl_aj_QuestTrigger
	Implements System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
	
	Private Shared emptyChangingEventArgs As PropertyChangingEventArgs = New PropertyChangingEventArgs(String.Empty)
	
	Private _QtriggerID As Integer
	
	Private _QID As System.Nullable(Of Integer)
	
	Private _TName As String
	
	Private _TValue As String
	
    #Region "Extensibility Method Definitions"
    Partial Private Sub OnLoaded()
    End Sub
    Partial Private Sub OnValidate(action As System.Data.Linq.ChangeAction)
    End Sub
    Partial Private Sub OnCreated()
    End Sub
    Partial Private Sub OnQtriggerIDChanging(value As Integer)
    End Sub
    Partial Private Sub OnQtriggerIDChanged()
    End Sub
    Partial Private Sub OnQIDChanging(value As System.Nullable(Of Integer))
    End Sub
    Partial Private Sub OnQIDChanged()
    End Sub
    Partial Private Sub OnTNameChanging(value As String)
    End Sub
    Partial Private Sub OnTNameChanged()
    End Sub
    Partial Private Sub OnTValueChanging(value As String)
    End Sub
    Partial Private Sub OnTValueChanged()
    End Sub
    #End Region
	
	Public Sub New()
		MyBase.New
		OnCreated
	End Sub
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_QtriggerID", AutoSync:=AutoSync.OnInsert, DbType:="Int NOT NULL IDENTITY", IsPrimaryKey:=true, IsDbGenerated:=true)>  _
	Public Property QtriggerID() As Integer
		Get
			Return Me._QtriggerID
		End Get
		Set
			If ((Me._QtriggerID = value)  _
						= false) Then
				Me.OnQtriggerIDChanging(value)
				Me.SendPropertyChanging
				Me._QtriggerID = value
				Me.SendPropertyChanged("QtriggerID")
				Me.OnQtriggerIDChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_QID", DbType:="Int")>  _
	Public Property QID() As System.Nullable(Of Integer)
		Get
			Return Me._QID
		End Get
		Set
			If (Me._QID.Equals(value) = false) Then
				Me.OnQIDChanging(value)
				Me.SendPropertyChanging
				Me._QID = value
				Me.SendPropertyChanged("QID")
				Me.OnQIDChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_TName", DbType:="NVarChar(250)")>  _
	Public Property TName() As String
		Get
			Return Me._TName
		End Get
		Set
			If (String.Equals(Me._TName, value) = false) Then
				Me.OnTNameChanging(value)
				Me.SendPropertyChanging
				Me._TName = value
				Me.SendPropertyChanged("TName")
				Me.OnTNameChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_TValue", DbType:="NVarChar(150)")>  _
	Public Property TValue() As String
		Get
			Return Me._TValue
		End Get
		Set
			If (String.Equals(Me._TValue, value) = false) Then
				Me.OnTValueChanging(value)
				Me.SendPropertyChanging
				Me._TValue = value
				Me.SendPropertyChanged("TValue")
				Me.OnTValueChanged
			End If
		End Set
	End Property
	
	Public Event PropertyChanging As PropertyChangingEventHandler Implements System.ComponentModel.INotifyPropertyChanging.PropertyChanging
	
	Public Event PropertyChanged As PropertyChangedEventHandler Implements System.ComponentModel.INotifyPropertyChanged.PropertyChanged
	
	Protected Overridable Sub SendPropertyChanging()
		If ((Me.PropertyChangingEvent Is Nothing)  _
					= false) Then
			RaiseEvent PropertyChanging(Me, emptyChangingEventArgs)
		End If
	End Sub
	
	Protected Overridable Sub SendPropertyChanged(ByVal propertyName As [String])
		If ((Me.PropertyChangedEvent Is Nothing)  _
					= false) Then
			RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
		End If
	End Sub
End Class

<Global.System.Data.Linq.Mapping.TableAttribute(Name:="dbo.tbl_aj_Quest")>  _
Partial Public Class tbl_aj_Quest
	Implements System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
	
	Private Shared emptyChangingEventArgs As PropertyChangingEventArgs = New PropertyChangingEventArgs(String.Empty)
	
	Private _QuestId As Integer
	
	Private _Aid As System.Nullable(Of Integer)
	
	Private _Uppdrag As String
	
	Private _Beskrivning As String
	
	Private _Active As System.Nullable(Of Integer)
	
    #Region "Extensibility Method Definitions"
    Partial Private Sub OnLoaded()
    End Sub
    Partial Private Sub OnValidate(action As System.Data.Linq.ChangeAction)
    End Sub
    Partial Private Sub OnCreated()
    End Sub
    Partial Private Sub OnQuestIdChanging(value As Integer)
    End Sub
    Partial Private Sub OnQuestIdChanged()
    End Sub
    Partial Private Sub OnAidChanging(value As System.Nullable(Of Integer))
    End Sub
    Partial Private Sub OnAidChanged()
    End Sub
    Partial Private Sub OnUppdragChanging(value As String)
    End Sub
    Partial Private Sub OnUppdragChanged()
    End Sub
    Partial Private Sub OnBeskrivningChanging(value As String)
    End Sub
    Partial Private Sub OnBeskrivningChanged()
    End Sub
    Partial Private Sub OnActiveChanging(value As System.Nullable(Of Integer))
    End Sub
    Partial Private Sub OnActiveChanged()
    End Sub
    #End Region
	
	Public Sub New()
		MyBase.New
		OnCreated
	End Sub
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_QuestId", AutoSync:=AutoSync.OnInsert, DbType:="Int NOT NULL IDENTITY", IsPrimaryKey:=true, IsDbGenerated:=true)>  _
	Public Property QuestId() As Integer
		Get
			Return Me._QuestId
		End Get
		Set
			If ((Me._QuestId = value)  _
						= false) Then
				Me.OnQuestIdChanging(value)
				Me.SendPropertyChanging
				Me._QuestId = value
				Me.SendPropertyChanged("QuestId")
				Me.OnQuestIdChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_Aid", DbType:="Int")>  _
	Public Property Aid() As System.Nullable(Of Integer)
		Get
			Return Me._Aid
		End Get
		Set
			If (Me._Aid.Equals(value) = false) Then
				Me.OnAidChanging(value)
				Me.SendPropertyChanging
				Me._Aid = value
				Me.SendPropertyChanged("Aid")
				Me.OnAidChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_Uppdrag", DbType:="NVarChar(100)")>  _
	Public Property Uppdrag() As String
		Get
			Return Me._Uppdrag
		End Get
		Set
			If (String.Equals(Me._Uppdrag, value) = false) Then
				Me.OnUppdragChanging(value)
				Me.SendPropertyChanging
				Me._Uppdrag = value
				Me.SendPropertyChanged("Uppdrag")
				Me.OnUppdragChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_Beskrivning", DbType:="NVarChar(500)")>  _
	Public Property Beskrivning() As String
		Get
			Return Me._Beskrivning
		End Get
		Set
			If (String.Equals(Me._Beskrivning, value) = false) Then
				Me.OnBeskrivningChanging(value)
				Me.SendPropertyChanging
				Me._Beskrivning = value
				Me.SendPropertyChanged("Beskrivning")
				Me.OnBeskrivningChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_Active", DbType:="Int")>  _
	Public Property Active() As System.Nullable(Of Integer)
		Get
			Return Me._Active
		End Get
		Set
			If (Me._Active.Equals(value) = false) Then
				Me.OnActiveChanging(value)
				Me.SendPropertyChanging
				Me._Active = value
				Me.SendPropertyChanged("Active")
				Me.OnActiveChanged
			End If
		End Set
	End Property
	
	Public Event PropertyChanging As PropertyChangingEventHandler Implements System.ComponentModel.INotifyPropertyChanging.PropertyChanging
	
	Public Event PropertyChanged As PropertyChangedEventHandler Implements System.ComponentModel.INotifyPropertyChanged.PropertyChanged
	
	Protected Overridable Sub SendPropertyChanging()
		If ((Me.PropertyChangingEvent Is Nothing)  _
					= false) Then
			RaiseEvent PropertyChanging(Me, emptyChangingEventArgs)
		End If
	End Sub
	
	Protected Overridable Sub SendPropertyChanged(ByVal propertyName As [String])
		If ((Me.PropertyChangedEvent Is Nothing)  _
					= false) Then
			RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
		End If
	End Sub
End Class

Partial Public Class aj_quest_isUserSubQuestCompletedResult
	
	Private _Completed As System.Nullable(Of Integer)
	
	Public Sub New()
		MyBase.New
	End Sub
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_Completed", DbType:="Int")>  _
	Public Property Completed() As System.Nullable(Of Integer)
		Get
			Return Me._Completed
		End Get
		Set
			If (Me._Completed.Equals(value) = false) Then
				Me._Completed = value
			End If
		End Set
	End Property
End Class
