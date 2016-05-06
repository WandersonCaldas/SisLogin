Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.OleDb
Public Class UsuarioDAO
    Public Function Teste() As Result
        Dim retorno As New Result()
        Dim listaUsuarios As New List(Of Usuario)
        Dim objUsuario As New Usuario

        Try
            objUsuario.txt_nome = "WANDERSON CALDAS"
            listaUsuarios.Add(objUsuario)
            retorno.status = ResponseStatus.SUCESSO.Texto
            retorno.Usuarios = listaUsuarios            
        Catch ex As Exception
            retorno.status = ResponseStatus.FALHA.Texto
            retorno.exception = clsException.CarregarErro(ex.Source, ex.Message, ex.StackTrace)
        End Try

        Return retorno
    End Function
End Class
