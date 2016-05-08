Imports Microsoft.VisualBasic
Public Class Usuario
    <System.Xml.Serialization.XmlAttribute()> _
    Public Property id() As Integer
        Get
            Return m_id
        End Get
        Set(ByVal value As Integer)
            m_id = value
        End Set
    End Property
    Private m_id As Integer

    Public Property txt_nome() As String
        Get
            Return m_txt_nome
        End Get
        Set(ByVal value As String)
            m_txt_nome = value
        End Set
    End Property
    Private m_txt_nome As String

    Public Property txt_senha() As String
        Get
            Return m_txt_senha
        End Get
        Set(ByVal value As String)
            m_txt_senha = value
        End Set
    End Property
    Private m_txt_senha As String

    Public Property txt_email() As String
        Get
            Return m_txt_email
        End Get
        Set(ByVal value As String)
            m_txt_email = value
        End Set
    End Property
    Private m_txt_email As String

    Public Property cod_ativo() As Integer
        Get
            Return m_cod_ativo
        End Get
        Set(ByVal value As Integer)
            m_cod_ativo = value
        End Set
    End Property
    Private m_cod_ativo As Integer
End Class
