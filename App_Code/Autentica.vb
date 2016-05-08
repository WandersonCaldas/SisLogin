Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
' <System.Web.Script.Services.ScriptService()> _
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
Public Class Autentica
    Inherits System.Web.Services.WebService

    '<WebMethod()> _
    'Public Function HelloWorld() As String
    '    Return "Hello World"
    'End Function

    '<WebMethod(Description:="TESTE")> _
    'Public Function Teste() As Result
    '    Dim retorno As New Result()
    '    Dim objUsuarioBO As New UsuarioBO()

    '    retorno = objUsuarioBO.Validar(1)

    '    Return retorno
    'End Function

    <WebMethod(Description:="Cadastrar novo usuário")> _
    Public Function CadastrarUsuario(ByVal txt_nome As String, ByVal txt_senha As String, ByVal txt_email As String) As Result
        Dim retorno As New Result()
        Dim objUsuario As New Usuario()
        Dim objUsuarioBO As New UsuarioBO()

        objUsuario.txt_nome = txt_nome.ToString()
        objUsuario.txt_senha = txt_senha.ToString()
        objUsuario.txt_email = txt_email.ToString()

        retorno = objUsuarioBO.CadastrarUsuario(objUsuario)

        Return retorno
    End Function

    <WebMethod(Description:="Alterar novo usuário")> _
    Public Function AlterarUsuario(ByVal id As Integer, ByVal txt_nome As String, ByVal txt_email As String) As Result
        Dim retorno As New Result()
        Dim objUsuario As New Usuario()
        Dim objUsuarioBO As New UsuarioBO()

        objUsuario.id = id
        objUsuario.txt_nome = txt_nome.ToString()
        objUsuario.txt_email = txt_email.ToString()

        retorno = objUsuarioBO.AlterarUsuario(objUsuario)

        Return retorno
    End Function


    <WebMethod(Description:="Listar usuário")> _
    Public Function ListarUsuario(ByVal id As Integer, ByVal txt_nome As String, ByVal txt_senha As String) As Result
        Dim retorno As New Result()
        Dim objUsuario As New Usuario()
        Dim objUsuarioBO As New UsuarioBO()

        objUsuario.id = id
        objUsuario.txt_nome = txt_nome.ToString()
        objUsuario.txt_email = txt_senha.ToString()

        retorno = objUsuarioBO.ListarUsuario(objUsuario)

        Return retorno
    End Function

    <WebMethod(Description:="Cancelar usuário")> _
    Public Function CancelarUsuario(ByVal id As Integer) As Result
        Dim retorno As New Result()
        Dim objUsuario As New Usuario()
        Dim objUsuarioBO As New UsuarioBO()

        objUsuario.id = id

        retorno = objUsuarioBO.CancelarUsuario(objUsuario)

        Return retorno
    End Function
End Class