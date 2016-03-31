Imports SQLite.Net.Attributes

Public Class Stockvb
    <PrimaryKey, AutoIncrement>
    Public Property Id() As Integer
        Get
            Return m_Id
        End Get
        Set
            m_Id = Value
        End Set
    End Property
    Private m_Id As Integer

    <MaxLength(8)>
    Public Property Symbol() As String
        Get
            Return m_Symbol
        End Get
        Set
            m_Symbol = Value
        End Set
    End Property
    Private m_Symbol As String
End Class