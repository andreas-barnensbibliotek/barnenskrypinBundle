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


<Global.System.Data.Linq.Mapping.DatabaseAttribute(Name:="Database")>  _
Partial Public Class krypinBooklistLinqDataContext
	Inherits System.Data.Linq.DataContext
	
	Private Shared mappingSource As System.Data.Linq.Mapping.MappingSource = New AttributeMappingSource()
	
  #Region "Extensibility Method Definitions"
  Partial Private Sub OnCreated()
  End Sub
  Partial Private Sub InserttblAJBookListItem(instance As tblAJBookListItem)
    End Sub
  Partial Private Sub UpdatetblAJBookListItem(instance As tblAJBookListItem)
    End Sub
  Partial Private Sub DeletetblAJBookListItem(instance As tblAJBookListItem)
    End Sub
  Partial Private Sub InserttblAjKatalogMyBook(instance As tblAjKatalogMyBook)
    End Sub
  Partial Private Sub UpdatetblAjKatalogMyBook(instance As tblAjKatalogMyBook)
    End Sub
  Partial Private Sub DeletetblAjKatalogMyBook(instance As tblAjKatalogMyBook)
    End Sub
  Partial Private Sub InserttblAJBookList(instance As tblAJBookList)
    End Sub
  Partial Private Sub UpdatetblAJBookList(instance As tblAJBookList)
    End Sub
  Partial Private Sub DeletetblAJBookList(instance As tblAJBookList)
    End Sub
  #End Region
	
	Public Sub New()
		MyBase.New(Global.krypinBoklistor.My.MySettings.Default.DatabaseConnectionString, mappingSource)
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
	
	Public ReadOnly Property tblAJBookListItems() As System.Data.Linq.Table(Of tblAJBookListItem)
		Get
			Return Me.GetTable(Of tblAJBookListItem)
		End Get
	End Property
	
	Public ReadOnly Property tblAjKatalogMyBooks() As System.Data.Linq.Table(Of tblAjKatalogMyBook)
		Get
			Return Me.GetTable(Of tblAjKatalogMyBook)
		End Get
	End Property
	
	Public ReadOnly Property tblAJBookLists() As System.Data.Linq.Table(Of tblAJBookList)
		Get
			Return Me.GetTable(Of tblAJBookList)
		End Get
	End Property
	
	<Global.System.Data.Linq.Mapping.FunctionAttribute(Name:="dbo.AjBooklistExtended")>  _
	Public Function AjBooklistExtended(<Global.System.Data.Linq.Mapping.ParameterAttribute(DbType:="Int")> ByVal val As System.Nullable(Of Integer), <Global.System.Data.Linq.Mapping.ParameterAttribute(DbType:="Int")> ByVal valdboklistId As System.Nullable(Of Integer)) As ISingleResult(Of AjBooklistExtendedResult)
		Dim result As IExecuteResult = Me.ExecuteMethodCall(Me, CType(MethodInfo.GetCurrentMethod,MethodInfo), val, valdboklistId)
		Return CType(result.ReturnValue,ISingleResult(Of AjBooklistExtendedResult))
	End Function
	
	<Global.System.Data.Linq.Mapping.FunctionAttribute(Name:="dbo.AJKrypinGroupUserBooklist")>  _
	Public Function AJKrypinGroupUserBooklist(<Global.System.Data.Linq.Mapping.ParameterAttribute(DbType:="Int")> ByVal userid As System.Nullable(Of Integer)) As ISingleResult(Of AJKrypinGroupUserBooklistResult)
		Dim result As IExecuteResult = Me.ExecuteMethodCall(Me, CType(MethodInfo.GetCurrentMethod,MethodInfo), userid)
		Return CType(result.ReturnValue,ISingleResult(Of AJKrypinGroupUserBooklistResult))
	End Function
	
	<Global.System.Data.Linq.Mapping.FunctionAttribute(Name:="dbo.AjBooklist")>  _
	Public Function AjBooklist(<Global.System.Data.Linq.Mapping.ParameterAttribute(DbType:="Int")> ByVal val As System.Nullable(Of Integer), <Global.System.Data.Linq.Mapping.ParameterAttribute(DbType:="Int")> ByVal visaUserid As System.Nullable(Of Integer), <Global.System.Data.Linq.Mapping.ParameterAttribute(DbType:="Int")> ByVal valdboklistId As System.Nullable(Of Integer), <Global.System.Data.Linq.Mapping.ParameterAttribute(DbType:="NVarChar(100)")> ByVal boklistnamn As String) As ISingleResult(Of AjBooklistResult)
		Dim result As IExecuteResult = Me.ExecuteMethodCall(Me, CType(MethodInfo.GetCurrentMethod,MethodInfo), val, visaUserid, valdboklistId, boklistnamn)
		Return CType(result.ReturnValue,ISingleResult(Of AjBooklistResult))
	End Function
End Class

<Global.System.Data.Linq.Mapping.TableAttribute(Name:="dbo.tblAJBookListItem")>  _
Partial Public Class tblAJBookListItem
	Implements System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
	
	Private Shared emptyChangingEventArgs As PropertyChangingEventArgs = New PropertyChangingEventArgs(String.Empty)
	
	Private _id As Integer
	
	Private _blid As Integer
	
	Private _bookid As Integer
	
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
    Partial Private Sub OnblidChanging(value As Integer)
    End Sub
    Partial Private Sub OnblidChanged()
    End Sub
    Partial Private Sub OnbookidChanging(value As Integer)
    End Sub
    Partial Private Sub OnbookidChanged()
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
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_blid", DbType:="Int NOT NULL")>  _
	Public Property blid() As Integer
		Get
			Return Me._blid
		End Get
		Set
			If ((Me._blid = value)  _
						= false) Then
				Me.OnblidChanging(value)
				Me.SendPropertyChanging
				Me._blid = value
				Me.SendPropertyChanged("blid")
				Me.OnblidChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_bookid", DbType:="Int NOT NULL")>  _
	Public Property bookid() As Integer
		Get
			Return Me._bookid
		End Get
		Set
			If ((Me._bookid = value)  _
						= false) Then
				Me.OnbookidChanging(value)
				Me.SendPropertyChanging
				Me._bookid = value
				Me.SendPropertyChanged("bookid")
				Me.OnbookidChanged
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

<Global.System.Data.Linq.Mapping.TableAttribute(Name:="dbo.tblAjKatalogMyBooks")>  _
Partial Public Class tblAjKatalogMyBook
	Implements System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
	
	Private Shared emptyChangingEventArgs As PropertyChangingEventArgs = New PropertyChangingEventArgs(String.Empty)
	
	Private _ID As Integer
	
	Private _Userid As System.Nullable(Of Integer)
	
	Private _Bookid As System.Nullable(Of Integer)
	
    #Region "Extensibility Method Definitions"
    Partial Private Sub OnLoaded()
    End Sub
    Partial Private Sub OnValidate(action As System.Data.Linq.ChangeAction)
    End Sub
    Partial Private Sub OnCreated()
    End Sub
    Partial Private Sub OnIDChanging(value As Integer)
    End Sub
    Partial Private Sub OnIDChanged()
    End Sub
    Partial Private Sub OnUseridChanging(value As System.Nullable(Of Integer))
    End Sub
    Partial Private Sub OnUseridChanged()
    End Sub
    Partial Private Sub OnBookidChanging(value As System.Nullable(Of Integer))
    End Sub
    Partial Private Sub OnBookidChanged()
    End Sub
    #End Region
	
	Public Sub New()
		MyBase.New
		OnCreated
	End Sub
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_ID", AutoSync:=AutoSync.OnInsert, DbType:="Int NOT NULL IDENTITY", IsPrimaryKey:=true, IsDbGenerated:=true)>  _
	Public Property ID() As Integer
		Get
			Return Me._ID
		End Get
		Set
			If ((Me._ID = value)  _
						= false) Then
				Me.OnIDChanging(value)
				Me.SendPropertyChanging
				Me._ID = value
				Me.SendPropertyChanged("ID")
				Me.OnIDChanged
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
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_Bookid", DbType:="Int")>  _
	Public Property Bookid() As System.Nullable(Of Integer)
		Get
			Return Me._Bookid
		End Get
		Set
			If (Me._Bookid.Equals(value) = false) Then
				Me.OnBookidChanging(value)
				Me.SendPropertyChanging
				Me._Bookid = value
				Me.SendPropertyChanged("Bookid")
				Me.OnBookidChanged
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

<Global.System.Data.Linq.Mapping.TableAttribute(Name:="dbo.tblAJBookLists")>  _
Partial Public Class tblAJBookList
	Implements System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
	
	Private Shared emptyChangingEventArgs As PropertyChangingEventArgs = New PropertyChangingEventArgs(String.Empty)
	
	Private _id As Integer
	
	Private _boklistnamn As String
	
	Private _Userid As Integer
	
	Private _Dela As System.Nullable(Of Integer)
	
	Private _Datum As System.Nullable(Of Date)
	
	Private _gruppid As System.Nullable(Of Integer)
	
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
    Partial Private Sub OnboklistnamnChanging(value As String)
    End Sub
    Partial Private Sub OnboklistnamnChanged()
    End Sub
    Partial Private Sub OnUseridChanging(value As Integer)
    End Sub
    Partial Private Sub OnUseridChanged()
    End Sub
    Partial Private Sub OnDelaChanging(value As System.Nullable(Of Integer))
    End Sub
    Partial Private Sub OnDelaChanged()
    End Sub
    Partial Private Sub OnDatumChanging(value As System.Nullable(Of Date))
    End Sub
    Partial Private Sub OnDatumChanged()
    End Sub
    Partial Private Sub OngruppidChanging(value As System.Nullable(Of Integer))
    End Sub
    Partial Private Sub OngruppidChanged()
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
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_boklistnamn", DbType:="NVarChar(150) NOT NULL", CanBeNull:=false)>  _
	Public Property boklistnamn() As String
		Get
			Return Me._boklistnamn
		End Get
		Set
			If (String.Equals(Me._boklistnamn, value) = false) Then
				Me.OnboklistnamnChanging(value)
				Me.SendPropertyChanging
				Me._boklistnamn = value
				Me.SendPropertyChanged("boklistnamn")
				Me.OnboklistnamnChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_Userid", DbType:="Int NOT NULL")>  _
	Public Property Userid() As Integer
		Get
			Return Me._Userid
		End Get
		Set
			If ((Me._Userid = value)  _
						= false) Then
				Me.OnUseridChanging(value)
				Me.SendPropertyChanging
				Me._Userid = value
				Me.SendPropertyChanged("Userid")
				Me.OnUseridChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_Dela", DbType:="Int")>  _
	Public Property Dela() As System.Nullable(Of Integer)
		Get
			Return Me._Dela
		End Get
		Set
			If (Me._Dela.Equals(value) = false) Then
				Me.OnDelaChanging(value)
				Me.SendPropertyChanging
				Me._Dela = value
				Me.SendPropertyChanged("Dela")
				Me.OnDelaChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_Datum", DbType:="Date")>  _
	Public Property Datum() As System.Nullable(Of Date)
		Get
			Return Me._Datum
		End Get
		Set
			If (Me._Datum.Equals(value) = false) Then
				Me.OnDatumChanging(value)
				Me.SendPropertyChanging
				Me._Datum = value
				Me.SendPropertyChanged("Datum")
				Me.OnDatumChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_gruppid", DbType:="Int")>  _
	Public Property gruppid() As System.Nullable(Of Integer)
		Get
			Return Me._gruppid
		End Get
		Set
			If (Me._gruppid.Equals(value) = false) Then
				Me.OngruppidChanging(value)
				Me.SendPropertyChanging
				Me._gruppid = value
				Me.SendPropertyChanged("gruppid")
				Me.OngruppidChanged
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

Partial Public Class AjBooklistExtendedResult
	
	Private _bookid As Integer
	
	Private _blid As Integer
	
	Private _isbn As String
	
	Private _Title As String
	
	Private _namn As String
	
	Public Sub New()
		MyBase.New
	End Sub
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_bookid", DbType:="Int NOT NULL")>  _
	Public Property bookid() As Integer
		Get
			Return Me._bookid
		End Get
		Set
			If ((Me._bookid = value)  _
						= false) Then
				Me._bookid = value
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_blid", DbType:="Int NOT NULL")>  _
	Public Property blid() As Integer
		Get
			Return Me._blid
		End Get
		Set
			If ((Me._blid = value)  _
						= false) Then
				Me._blid = value
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_isbn", DbType:="NVarChar(255)")>  _
	Public Property isbn() As String
		Get
			Return Me._isbn
		End Get
		Set
			If (String.Equals(Me._isbn, value) = false) Then
				Me._isbn = value
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_Title", DbType:="NVarChar(255)")>  _
	Public Property Title() As String
		Get
			Return Me._Title
		End Get
		Set
			If (String.Equals(Me._Title, value) = false) Then
				Me._Title = value
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_namn", DbType:="NVarChar(60)")>  _
	Public Property namn() As String
		Get
			Return Me._namn
		End Get
		Set
			If (String.Equals(Me._namn, value) = false) Then
				Me._namn = value
			End If
		End Set
	End Property
End Class

Partial Public Class AJKrypinGroupUserBooklistResult
	
	Private _boklistnamn As String
	
	Private _gruppid As Integer
	
	Private _id As Integer
	
	Private _userid As Integer
	
	Public Sub New()
		MyBase.New
	End Sub
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_boklistnamn", DbType:="NVarChar(150) NOT NULL", CanBeNull:=false)>  _
	Public Property boklistnamn() As String
		Get
			Return Me._boklistnamn
		End Get
		Set
			If (String.Equals(Me._boklistnamn, value) = false) Then
				Me._boklistnamn = value
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_gruppid", DbType:="Int NOT NULL")>  _
	Public Property gruppid() As Integer
		Get
			Return Me._gruppid
		End Get
		Set
			If ((Me._gruppid = value)  _
						= false) Then
				Me._gruppid = value
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_id", DbType:="Int NOT NULL")>  _
	Public Property id() As Integer
		Get
			Return Me._id
		End Get
		Set
			If ((Me._id = value)  _
						= false) Then
				Me._id = value
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_userid", DbType:="Int NOT NULL")>  _
	Public Property userid() As Integer
		Get
			Return Me._userid
		End Get
		Set
			If ((Me._userid = value)  _
						= false) Then
				Me._userid = value
			End If
		End Set
	End Property
End Class

Partial Public Class AjBooklistResult
	
	Private _boklistnamn As String
	
	Private _Userid As Integer
	
	Private _id As Integer
	
	Private _gruppid As System.Nullable(Of Integer)
	
	Public Sub New()
		MyBase.New
	End Sub
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_boklistnamn", DbType:="NVarChar(150) NOT NULL", CanBeNull:=false)>  _
	Public Property boklistnamn() As String
		Get
			Return Me._boklistnamn
		End Get
		Set
			If (String.Equals(Me._boklistnamn, value) = false) Then
				Me._boklistnamn = value
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_Userid", DbType:="Int NOT NULL")>  _
	Public Property Userid() As Integer
		Get
			Return Me._Userid
		End Get
		Set
			If ((Me._Userid = value)  _
						= false) Then
				Me._Userid = value
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_id", DbType:="Int NOT NULL")>  _
	Public Property id() As Integer
		Get
			Return Me._id
		End Get
		Set
			If ((Me._id = value)  _
						= false) Then
				Me._id = value
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_gruppid", DbType:="Int")>  _
	Public Property gruppid() As System.Nullable(Of Integer)
		Get
			Return Me._gruppid
		End Get
		Set
			If (Me._gruppid.Equals(value) = false) Then
				Me._gruppid = value
			End If
		End Set
	End Property
End Class