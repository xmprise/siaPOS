﻿'------------------------------------------------------------------------------
' <auto-generated>
'     이 코드는 도구를 사용하여 생성되었습니다.
'     런타임 버전:4.0.30319.235
'
'     파일 내용을 변경하면 잘못된 동작이 발생할 수 있으며, 코드를 다시 생성하면
'     이러한 변경 내용이 손실됩니다.
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


<Global.System.Data.Linq.Mapping.DatabaseAttribute(Name:="SibalChk2011")>  _
Partial Public Class ShopStockDataContext
	Inherits System.Data.Linq.DataContext
	
	Private Shared mappingSource As System.Data.Linq.Mapping.MappingSource = New AttributeMappingSource()
	
  #Region "확장성 메서드 정의"
  Partial Private Sub OnCreated()
  End Sub
  Partial Private Sub InsertShopStock(instance As ShopStock)
    End Sub
  Partial Private Sub UpdateShopStock(instance As ShopStock)
    End Sub
  Partial Private Sub DeleteShopStock(instance As ShopStock)
    End Sub
  #End Region
	
	Public Sub New()
		MyBase.New(Global.System.Configuration.ConfigurationManager.ConnectionStrings("SibalChk2011ConnectionString").ConnectionString, mappingSource)
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
	
	Public ReadOnly Property ShopStock() As System.Data.Linq.Table(Of ShopStock)
		Get
			Return Me.GetTable(Of ShopStock)
		End Get
	End Property
End Class

<Global.System.Data.Linq.Mapping.TableAttribute(Name:="Shop.ShopStock")>  _
Partial Public Class ShopStock
	Implements System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
	
	Private Shared emptyChangingEventArgs As PropertyChangingEventArgs = New PropertyChangingEventArgs(String.Empty)
	
	Private _ShopStockID As Integer
	
	Private _ShopID As String
	
	Private _MenuName As String
	
	Private _Stock As System.Nullable(Of Integer)
	
	Private _StockDate As System.Nullable(Of Date)
	
    #Region "확장성 메서드 정의"
    Partial Private Sub OnLoaded()
    End Sub
    Partial Private Sub OnValidate(action As System.Data.Linq.ChangeAction)
    End Sub
    Partial Private Sub OnCreated()
    End Sub
    Partial Private Sub OnShopStockIDChanging(value As Integer)
    End Sub
    Partial Private Sub OnShopStockIDChanged()
    End Sub
    Partial Private Sub OnShopIDChanging(value As String)
    End Sub
    Partial Private Sub OnShopIDChanged()
    End Sub
    Partial Private Sub OnMenuNameChanging(value As String)
    End Sub
    Partial Private Sub OnMenuNameChanged()
    End Sub
    Partial Private Sub OnStockChanging(value As System.Nullable(Of Integer))
    End Sub
    Partial Private Sub OnStockChanged()
    End Sub
    Partial Private Sub OnStockDateChanging(value As System.Nullable(Of Date))
    End Sub
    Partial Private Sub OnStockDateChanged()
    End Sub
    #End Region
	
	Public Sub New()
		MyBase.New
		OnCreated
	End Sub
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_ShopStockID", DbType:="Int NOT NULL", IsPrimaryKey:=true)>  _
	Public Property ShopStockID() As Integer
		Get
			Return Me._ShopStockID
		End Get
		Set
			If ((Me._ShopStockID = value)  _
						= false) Then
				Me.OnShopStockIDChanging(value)
				Me.SendPropertyChanging
				Me._ShopStockID = value
				Me.SendPropertyChanged("ShopStockID")
				Me.OnShopStockIDChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_ShopID", DbType:="VarChar(50) NOT NULL", CanBeNull:=false)>  _
	Public Property ShopID() As String
		Get
			Return Me._ShopID
		End Get
		Set
			If (String.Equals(Me._ShopID, value) = false) Then
				Me.OnShopIDChanging(value)
				Me.SendPropertyChanging
				Me._ShopID = value
				Me.SendPropertyChanged("ShopID")
				Me.OnShopIDChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_MenuName", DbType:="VarChar(50) NOT NULL", CanBeNull:=false)>  _
	Public Property MenuName() As String
		Get
			Return Me._MenuName
		End Get
		Set
			If (String.Equals(Me._MenuName, value) = false) Then
				Me.OnMenuNameChanging(value)
				Me.SendPropertyChanging
				Me._MenuName = value
				Me.SendPropertyChanged("MenuName")
				Me.OnMenuNameChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_Stock", DbType:="Int")>  _
	Public Property Stock() As System.Nullable(Of Integer)
		Get
			Return Me._Stock
		End Get
		Set
			If (Me._Stock.Equals(value) = false) Then
				Me.OnStockChanging(value)
				Me.SendPropertyChanging
				Me._Stock = value
				Me.SendPropertyChanged("Stock")
				Me.OnStockChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_StockDate", DbType:="DateTime")>  _
	Public Property StockDate() As System.Nullable(Of Date)
		Get
			Return Me._StockDate
		End Get
		Set
			If (Me._StockDate.Equals(value) = false) Then
				Me.OnStockDateChanging(value)
				Me.SendPropertyChanging
				Me._StockDate = value
				Me.SendPropertyChanged("StockDate")
				Me.OnStockDateChanged
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
