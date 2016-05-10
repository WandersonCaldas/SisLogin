Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Collections.Generic
Public Class UsuarioBO
    'Public Function Validar(ByVal cod As Integer) As Result
    '    Dim retorno As New Result()        

    '    If cod = 0 Then
    '        retorno.exception = clsException.CarregarErro("Validação Dados", Mensagem.MN001.TextoFormatado("Código do documento/processo"), Mensagem.MN002.TextoFormatado("Código do documento/processo"))
    '        retorno.status = ResponseStatus.FALHA.Texto
    '    Else
    '        Dim objUsuario As New UsuarioDAO()
    '        retorno = objUsuario.Teste()
    '        retorno.status = ResponseStatus.SUCESSO.Texto
    '    End If
    '    Return retorno
    'End Function

    Public Function CadastrarUsuario(ByVal objUsuario As Usuario) As Result
        Dim retorno As New Result()
        Dim usuarioDAO As New UsuarioDAO()

        retorno.status = ResponseStatus.SUCESSO.Texto

        If String.IsNullOrWhiteSpace(objUsuario.txt_nome) Then
            retorno.exception = clsException.CarregarErro("Validação Dados", Mensagem.MN002.TextoFormatado("NOME"), Mensagem.MN002.TextoFormatado("txt_nome"))
            retorno.status = ResponseStatus.FALHA.Texto
        ElseIf String.IsNullOrWhiteSpace(objUsuario.txt_email) Then
            retorno.exception = clsException.CarregarErro("Validação Dados", Mensagem.MN002.TextoFormatado("E-MAIL"), Mensagem.MN002.TextoFormatado("txt_email"))
            retorno.status = ResponseStatus.FALHA.Texto
        ElseIf String.IsNullOrWhiteSpace(objUsuario.txt_senha) Then
            retorno.exception = clsException.CarregarErro("Validação Dados", Mensagem.MN002.TextoFormatado("SENHA"), Mensagem.MN002.TextoFormatado("txt_senha"))
            retorno.status = ResponseStatus.FALHA.Texto
        ElseIf Not String.IsNullOrWhiteSpace(objUsuario.txt_nome) And Not String.IsNullOrWhiteSpace(objUsuario.txt_email) And Not String.IsNullOrWhiteSpace(objUsuario.txt_senha) Then
            If usuarioDAO.VerificaExistenciaUsuario(objUsuario) Then
                retorno.exception = clsException.CarregarErro("Validação Dados", Mensagem.MN003.TextoFormatado(objUsuario.txt_nome), Mensagem.MN003.TextoFormatado(objUsuario.txt_nome))
                retorno.status = ResponseStatus.FALHA.Texto
            End If
        End If

        If retorno.status.Equals(ResponseStatus.SUCESSO.Texto) Then
            retorno = usuarioDAO.CadastrarUsuario(objUsuario)
            retorno.status = ResponseStatus.SUCESSO.Texto
        End If

        Return retorno
    End Function
    Public Function AlterarSenha(ByVal objUsuario As Usuario) As Result
        Dim retorno As New Result()
        Dim usuarioDAO As New UsuarioDAO()


        If Not usuarioDAO.VerificaExistenciaUsuarioId(objUsuario) Then
            retorno.exception = clsException.CarregarErro("Validação Dados", Mensagem.MN004.Texto, Mensagem.MN004.Texto)
            retorno.status = ResponseStatus.FALHA.Texto
        ElseIf Not usuarioDAO.VerificaUsuarioAtivo(objUsuario) Then
            retorno.exception = clsException.CarregarErro("Validação Dados", Mensagem.MN005.Texto, Mensagem.MN005.Texto)
            retorno.status = ResponseStatus.FALHA.Texto
        ElseIf String.IsNullOrWhiteSpace(objUsuario.txt_senha) Then
            retorno.exception = clsException.CarregarErro("Validação Dados", Mensagem.MN002.TextoFormatado("SENHA ATUAL"), Mensagem.MN002.TextoFormatado("txt_senha_atual"))
            retorno.status = ResponseStatus.FALHA.Texto
        ElseIf String.IsNullOrWhiteSpace(objUsuario.txt_nova_senha) Then
            retorno.exception = clsException.CarregarErro("Validação Dados", Mensagem.MN002.TextoFormatado("NOVA SENHA"), Mensagem.MN002.TextoFormatado("txt_nova_senha"))
            retorno.status = ResponseStatus.FALHA.Texto
        ElseIf Not usuarioDAO.ValidaSenhaAtual(objUsuario) Then
            retorno.exception = clsException.CarregarErro("Validação Dados", Mensagem.MN006.Texto, Mensagem.MN006.Texto)
            retorno.status = ResponseStatus.FALHA.Texto
        Else
            retorno = usuarioDAO.AlterarSenha(objUsuario)
            retorno.status = ResponseStatus.SUCESSO.Texto
        End If

        Return retorno
    End Function
    Public Function ListarUsuario(ByVal objUsuario As Usuario) As Result
        Dim retorno As New Result()
        Dim usuarioDAO As New UsuarioDAO()

        retorno = usuarioDAO.ListarUsuario(objUsuario)        

        Return retorno
    End Function

    Public Function AlterarUsuario(ByVal objUsuario As Usuario) As Result
        Dim retorno As New Result()
        Dim usuarioDAO As New UsuarioDAO()

        If String.IsNullOrWhiteSpace(objUsuario.txt_nome) Then
            retorno.exception = clsException.CarregarErro("Validação Dados", Mensagem.MN002.TextoFormatado("NOME"), Mensagem.MN002.TextoFormatado("txt_nome"))
            retorno.status = ResponseStatus.FALHA.Texto
        ElseIf String.IsNullOrWhiteSpace(objUsuario.txt_email) Then
            retorno.exception = clsException.CarregarErro("Validação Dados", Mensagem.MN002.TextoFormatado("E-MAIL"), Mensagem.MN002.TextoFormatado("txt_email"))
            retorno.status = ResponseStatus.FALHA.Texto
        Else
            retorno.status = ResponseStatus.SUCESSO.Texto
        End If

        If retorno.status.Equals(ResponseStatus.SUCESSO.Texto) Then
            retorno = usuarioDAO.AlterarUsuario(objUsuario)
        End If

        Return retorno
    End Function

    Public Function CancelarUsuario(ByVal objUsuario As Usuario) As Result
        Dim retorno As New Result()
        Dim usuarioDAO As New UsuarioDAO()

        retorno = usuarioDAO.CancelarUsuario(objUsuario)        

        Return retorno
    End Function
End Class
