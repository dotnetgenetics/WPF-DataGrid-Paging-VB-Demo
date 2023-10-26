Option Infer On
Imports System.ComponentModel

Public Class PageCollectionView
    Inherits CollectionView

    Private ReadOnly _innerList As IList
    Private ReadOnly _itemsPerPage As Integer
    Private _currentPage As Integer = 1

    Public Sub New(ByVal innerList As IList, ByVal itemsPerPage As Integer)

        MyBase.New(innerList)

        Me._innerList = innerList
        Me._itemsPerPage = itemsPerPage

    End Sub

    Public Overrides ReadOnly Property Count() As Integer
        Get
            Return Me._itemsPerPage
        End Get
    End Property

    Public Property CurrentPage() As Integer
        Get
            Return _currentPage
        End Get
        Set(ByVal value As Integer)
            _currentPage = value
            Me.OnPropertyChanged(New PropertyChangedEventArgs("CurrentPage"))
        End Set
    End Property

    Public ReadOnly Property ItemsPerPage() As Integer
        Get
            Return Me._itemsPerPage
        End Get
    End Property

    Public ReadOnly Property PageCount() As Integer
        Get
            Return (Me._innerList.Count + Me._itemsPerPage - 1) _
                    / Me._itemsPerPage
        End Get
    End Property

    Private ReadOnly Property EndIndex() As Integer
        Get
            Dim _end = Me._currentPage * Me._itemsPerPage - 1
            Return If(_end > Me._innerList.Count, Me._innerList.Count, _end)
        End Get
    End Property

    Private ReadOnly Property StartIndex() As Integer
        Get
            Return (Me._currentPage - 1) * Me._itemsPerPage
        End Get
    End Property

    Public Overrides Function GetItemAt(ByVal index As Integer) As Object

        Dim offset = index Mod (Me._itemsPerPage)

        If (((Me.StartIndex + offset) >= Me._innerList.Count)) Then
            Return New Object
        Else
            Dim temp = Me._innerList(Me.StartIndex + offset)
            Return Me._innerList(Me.StartIndex + offset)
        End If

    End Function

    Public Sub MoveToFirstPage()

        If Me._currentPage >= 1 Then
            Me.CurrentPage = 1
        End If

        Me.Refresh()

    End Sub

    Public Sub MoveToPreviousPage()

        If Me._currentPage > 1 Then
            Me.CurrentPage -= 1
        End If

        Me.Refresh()
    End Sub

    Public Sub MoveToNextPage()

        If Me._currentPage < Me.PageCount Then
            Me.CurrentPage += 1
        End If

        Me.Refresh()
    End Sub

    Public Sub MoveToLastPage()

        If Me._currentPage < Me.PageCount Then
            Me.CurrentPage = Me.PageCount
        End If

        Me.Refresh()
    End Sub

End Class
