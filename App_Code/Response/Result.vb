Imports Microsoft.VisualBasic
Imports System.Collections.Generic

<System.SerializableAttribute()> _
<System.Xml.Serialization.XmlRoot("return")> _
Public Class Result
    Inherits AbstractBaseResponse

    <System.Xml.Serialization.XmlAttribute()> _
    Public status As String

    Public Property Usuarios() As List(Of Usuario)
        Get
            Return m_usuarios
        End Get
        Set(ByVal value As List(Of Usuario))
            m_usuarios = value
        End Set
    End Property
    Private m_usuarios As List(Of Usuario)
End Class