Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports System.Xml.Serialization

Public Class ExceptionResponse
    Public message As String
    Public exceptions As List(Of ExceptionTO)

    Sub New()

    End Sub

    Public Sub addexception(ByVal exceptionErro As ExceptionTO)
        Dim listaErros As New List(Of ExceptionTO)
        listaErros.Add(exceptionErro)

        exceptions = listaErros
    End Sub

End Class
