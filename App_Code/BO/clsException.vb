Imports Microsoft.VisualBasic

Public Class clsException

    Public Shared Function CarregarErro(ByVal key As String, ByVal message As String, ByVal detail As String) As ExceptionResponse
        Dim erroTO As New ExceptionTO()
        Dim retornoErro As New ExceptionResponse

        erroTO.key = key
        erroTO.message = message
        erroTO.detail = detail
        retornoErro.addexception(erroTO)

        Return retornoErro
    End Function


End Class
