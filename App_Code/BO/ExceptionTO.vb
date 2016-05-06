Imports Microsoft.VisualBasic

Public Class ExceptionTO
    <System.Xml.Serialization.XmlAttribute()> _
    Public Property key() As String
        Get
            Return m_ExceptionKey
        End Get
        Set(ByVal value As String)
            m_ExceptionKey = value
        End Set
    End Property
    Private m_ExceptionKey As String

    Public Property message() As String
        Get
            Return m_Message
        End Get
        Set(ByVal value As String)
            m_Message = value
        End Set
    End Property
    Private m_Message As String

    Public Property detail() As String
        Get
            Return m_Details
        End Get
        Set(ByVal value As String)
            m_Details = value
        End Set
    End Property
    Private m_Details As String

End Class
