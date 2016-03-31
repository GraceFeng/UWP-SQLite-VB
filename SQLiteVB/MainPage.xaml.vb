' The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

Imports SQLite.Net
Imports SQLite.Net.Interop
Imports SQLite.Net.Platform.WinRT
Imports Windows.Storage
''' <summary>
''' An empty page that can be used on its own or navigated to within a Frame.
''' </summary>
Public NotInheritable Class MainPage
    Inherits Page
    Private combolist As New ObservableCollection(Of Stockvb)()
    Private Sub showComboBoxItem()
        With cmbPaciente.Items
            Dim sConexao As String = Path.Combine(ApplicationData.Current.LocalFolder.Path, "Deal2.db")
            Dim aConexao As New SQLiteConnection(New SQLitePlatformWinRT(), sConexao)
            For Each item As Stockvb In aConexao.Table(Of Stockvb)()
                Dim newlist As New Stockvb()
                newlist.Id = item.Id
                newlist.Symbol = item.Symbol
                combolist.Add(newlist)
            Next
            cmbPaciente.ItemsSource = combolist
        End With
    End Sub

    Private Async Function CheckFileExists(fileName As String) As Task(Of Boolean)
        Try
            Dim store = Await Windows.Storage.ApplicationData.Current.LocalFolder.GetFileAsync(fileName)
            Return True
        Catch
        End Try
        Return False
    End Function

    Private Sub Button_Click(sender As Object, e As RoutedEventArgs)
        If Not CheckFileExists("Deal2.db").Result Then
            Dim spath As String = Path.Combine(ApplicationData.Current.LocalFolder.Path, "Deal2.db")
            Dim db As New SQLiteConnection(New SQLitePlatformWinRT(), spath)
            db.CreateTable(Of Stockvb)()

            For i As Integer = 0 To 5
                Dim stocklist As New Stockvb()
                stocklist.Id = i
                stocklist.Symbol = "Item" + i.ToString()
                db.Insert(stocklist)
            Next
        End If
    End Sub

    Private Sub Button_Click_1(sender As Object, e As RoutedEventArgs)
        showComboBoxItem()
    End Sub
End Class