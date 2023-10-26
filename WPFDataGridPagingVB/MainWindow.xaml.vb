Option Infer On

Class MainWindow
    Private ReadOnly _cview As PageCollectionView
    Private PagingData As Object

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        InitializeDataContextView()
        Me._cview = CType(PagingData, PageCollectionView)
        Me.DataContext = Me._cview
    End Sub

    Private Sub InitializeDataContextView()

        PagingData = New PageCollectionView(
            New List(Of Record)() _
            From {
                New Record() With {.Animal = "Lion", .Eats = "Tiger"},
                New Record() With {.Animal = "Bird", .Eats = "Worm"},
                New Record() With {.Animal = "Rat", .Eats = "Cheese"},
                New Record() With {.Animal = "Tiger", .Eats = "Bear"},
                New Record() With {.Animal = "Bear", .Eats = "Oh my"},
                New Record() With {.Animal = "Fish", .Eats = "Shrimps"},
                New Record() With {.Animal = "Goat", .Eats = "Grass"},
                New Record() With {.Animal = "Wait", .Eats = "Oh my isn't an animal"},
                New Record() With {.Animal = "Oh well", .Eats = "Who is counting anyway"},
                New Record() With {.Animal = "Need better content", .Eats = "For posting on stackoverflow"}}, 3) '3 is items per page
    End Sub

    Private Sub OnFirstClicked(ByVal sender As Object, ByVal e As EventArgs)
        Me._cview.MoveToFirstPage()
    End Sub

    Private Sub OnPreviousClicked(ByVal sender As Object, ByVal e As EventArgs)
        Me._cview.MoveToPreviousPage()
    End Sub

    Private Sub OnNextClicked(ByVal sender As Object, ByVal e As EventArgs)
        Me._cview.MoveToNextPage()
    End Sub

    Private Sub OnLastClicked(ByVal sender As Object, ByVal e As EventArgs)
        Me._cview.MoveToLastPage()
    End Sub
End Class
