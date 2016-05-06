Imports Microsoft.VisualBasic
Public Class Usuario
    <System.Xml.Serialization.XmlAttribute()> _
     Public Property txt_nome() As String
        Get
            Return m_txt_nome
        End Get
        Set(ByVal value As String)
            m_txt_nome = value
        End Set
    End Property
    Private m_txt_nome As String
End Class
