Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient

Public Class UsuarioDAO
    'Public Function Teste() As Result
    '    Dim retorno As New Result()
    '    Dim listaUsuarios As New List(Of Usuario)
    '    Dim objUsuario As New Usuario

    '    Try
    '        objUsuario.txt_nome = "WANDERSON CALDAS"
    '        listaUsuarios.Add(objUsuario)
    '        retorno.status = ResponseStatus.SUCESSO.Texto
    '        retorno.Usuarios = listaUsuarios
    '    Catch ex As Exception
    '        retorno.status = ResponseStatus.FALHA.Texto
    '        retorno.exception = clsException.CarregarErro(ex.Source, ex.Message, ex.StackTrace)
    '    End Try

    '    Return retorno
    'End Function

#Region "MÉTODOS"
    Public Function CadastrarUsuario(ByVal objUsuario As Usuario) As Result
        Dim retorno As New Result()
        Try
            Using SqlConn As SqlConnection = Conexao.AbrirConexao()
                Using SqlComm As New SqlCommand()
                    SqlComm.Connection = SqlConn
                    SqlComm.CommandType = CommandType.Text
                    SqlComm.CommandText = "INSERT INTO tbl_usuario(txt_nome, txt_email, txt_senha) VALUES(@txt_nome, @txt_email, @txt_senha)"
                    SqlComm.Parameters.Clear()
                    SqlComm.Parameters.Add("txt_nome", SqlDbType.VarChar).Value = objUsuario.txt_nome
                    SqlComm.Parameters.Add("txt_email", SqlDbType.VarChar).Value = objUsuario.txt_email
                    SqlComm.Parameters.Add("txt_senha", SqlDbType.VarChar).Value = objUsuario.txt_senha
                    SqlComm.ExecuteNonQuery()

                    'Dim listaUsuarios As New List(Of Usuario)
                    'listaUsuarios.Add(objUsuario)
                    'retorno.Usuarios = listaUsuarios
                    retorno.status = ResponseStatus.SUCESSO.Texto

                End Using
            End Using
        Catch ex As Exception
            retorno.status = ResponseStatus.FALHA.Texto
            retorno.exception = clsException.CarregarErro(ex.Source, ex.Message, ex.StackTrace)
        End Try

        Return retorno
    End Function

    Public Function CancelarUsuario(ByVal objUsuario As Usuario) As Result
        Dim retorno As New Result()

        Try
            Using SqlConn As SqlConnection = Conexao.AbrirConexao()
                Using SqlComm As New SqlCommand()
                    SqlComm.Connection = SqlConn
                    SqlComm.CommandType = CommandType.Text
                    SqlComm.CommandText = "UPDATE tbl_usuario SET cod_ativo = 0 WHERE id = @id"
                    SqlComm.Parameters.Clear()
                    SqlComm.Parameters.Add("id", SqlDbType.Int).Value = objUsuario.id
                    SqlComm.ExecuteNonQuery()

                    retorno.status = ResponseStatus.SUCESSO.Texto
                End Using
            End Using
        Catch ex As Exception
            retorno.status = ResponseStatus.FALHA.Texto
            retorno.exception = clsException.CarregarErro(ex.Source, ex.Message, ex.StackTrace)
        End Try

        Return retorno
    End Function

    Public Function AlterarSenha(ByVal objUsuario As Usuario) As Result
        Dim retorno As New Result()

        Try
            Using SqlConn As SqlConnection = Conexao.AbrirConexao()
                Using SqlComm As New SqlCommand()
                    SqlComm.Connection = SqlConn
                    SqlComm.CommandType = CommandType.Text
                    SqlComm.CommandText = "UPDATE tbl_usuario SET txt_senha = @txt_senha WHERE id = @id"
                    SqlComm.Parameters.Clear()
                    SqlComm.Parameters.Add("txt_senha", SqlDbType.VarChar).Value = objUsuario.txt_nova_senha
                    SqlComm.Parameters.Add("id", SqlDbType.Int).Value = objUsuario.id
                    SqlComm.ExecuteNonQuery()

                    retorno.status = ResponseStatus.SUCESSO.Texto

                End Using
            End Using
        Catch ex As Exception
            retorno.status = ResponseStatus.FALHA.Texto
            retorno.exception = clsException.CarregarErro(ex.Source, ex.Message, ex.StackTrace)
        End Try

        Return retorno
    End Function

    Public Function AlterarUsuario(ByVal objUsuario As Usuario) As Result
        Dim retorno As New Result()

        Try
            Using SqlConn As SqlConnection = Conexao.AbrirConexao()
                Using SqlComm As New SqlCommand()
                    SqlComm.Connection = SqlConn
                    SqlComm.CommandType = CommandType.Text
                    SqlComm.CommandText = "UPDATE tbl_usuario SET txt_nome = @txt_nome, txt_email = @txt_email WHERE id = @id"
                    SqlComm.Parameters.Clear()
                    SqlComm.Parameters.Add("txt_nome", SqlDbType.VarChar).Value = objUsuario.txt_nome
                    SqlComm.Parameters.Add("txt_email", SqlDbType.VarChar).Value = objUsuario.txt_email
                    SqlComm.Parameters.Add("id", SqlDbType.Int).Value = objUsuario.id
                    SqlComm.ExecuteNonQuery()

                    retorno.status = ResponseStatus.SUCESSO.Texto
                End Using
            End Using
        Catch ex As Exception
            retorno.status = ResponseStatus.FALHA.Texto
            retorno.exception = clsException.CarregarErro(ex.Source, ex.Message, ex.StackTrace)
        End Try

        Return retorno
    End Function

    Public Function ListarUsuario(ByVal objUsuario As Usuario) As Result
        Dim retorno As New Result()
        Dim u As New Usuario()
        Dim listaUsuario As New List(Of Usuario)

        Try
            Using SqlConn As SqlConnection = Conexao.AbrirConexao()
                Using SqlComm As New SqlCommand()
                    SqlComm.Connection = SqlConn
                    SqlComm.CommandType = CommandType.Text
                    SqlComm.CommandText = "SELECT * FROM tbl_usuario WHERE 1 = 1 "

                    If objUsuario.id > 0 Then
                        SqlComm.CommandText &= " AND id = @id"
                        SqlComm.Parameters.Add("id", SqlDbType.Int).Value = objUsuario.id
                    End If

                    If Not String.IsNullOrWhiteSpace(objUsuario.txt_nome) Then
                        SqlComm.CommandText &= " AND txt_nome LIKE '%" & Trim(objUsuario.txt_nome) & "%'"
                    End If

                    If Not String.IsNullOrWhiteSpace(objUsuario.txt_email) Then
                        SqlComm.CommandText &= " AND txt_email LIKE '%" & Trim(objUsuario.txt_email) & "%'"
                    End If

                    Using da As New SqlDataAdapter(SqlComm)
                        Using ds As New DataSet()
                            da.Fill(ds, "Usuarios")
                            For Each table As DataTable In ds.Tables
                                For Each row As DataRow In table.Rows
                                    u = New Usuario()
                                    u.id = row("id")
                                    u.txt_nome = row("txt_nome")
                                    u.txt_email = row("txt_email")
                                    u.cod_ativo = row("cod_ativo")

                                    listaUsuario.Add(u)
                                Next
                            Next
                        End Using
                    End Using
                End Using
            End Using

            retorno.status = ResponseStatus.SUCESSO.Texto
            retorno.Usuarios = listaUsuario
        Catch ex As Exception
            retorno.status = ResponseStatus.FALHA.Texto
            retorno.exception = clsException.CarregarErro(ex.Source, ex.Message, ex.StackTrace)
        End Try

        Return retorno
    End Function
#End Region

#Region "VALIDAÇÕES DE USUÁRIO"
    Public Function VerificaExistenciaUsuario(ByVal objUsuario As Usuario) As Boolean
        Dim retorno As Boolean = False

        Using SqlConn As SqlConnection = Conexao.AbrirConexao()
            Using SqlComm As New SqlCommand()
                SqlComm.Connection = SqlConn
                SqlComm.CommandType = CommandType.Text
                SqlComm.CommandText = "SELECT * FROM tbl_usuario WHERE txt_nome = @txt_nome AND txt_email = @txt_email"
                SqlComm.Parameters.Clear()
                SqlComm.Parameters.Add("txt_nome", SqlDbType.VarChar).Value = objUsuario.txt_nome
                SqlComm.Parameters.Add("txt_email", SqlDbType.VarChar).Value = objUsuario.txt_email

                Using dr As SqlDataReader = SqlComm.ExecuteReader()
                    If dr.HasRows() Then
                        retorno = True
                    End If
                End Using
            End Using
        End Using

        Return retorno
    End Function

    Public Function VerificaExistenciaUsuarioId(ByVal objUsuario As Usuario) As Boolean
        Dim retorno As Boolean = False

        Using SqlConn As SqlConnection = Conexao.AbrirConexao()
            Using SqlComm As New SqlCommand()
                SqlComm.Connection = SqlConn
                SqlComm.CommandType = CommandType.Text
                SqlComm.CommandText = "SELECT * FROM tbl_usuario WHERE id = @id"
                SqlComm.Parameters.Clear()
                SqlComm.Parameters.Add("id", SqlDbType.Int).Value = objUsuario.id

                Using dr As SqlDataReader = SqlComm.ExecuteReader()
                    If dr.HasRows() Then
                        retorno = True
                    End If
                End Using
            End Using
        End Using

        Return retorno
    End Function

    Public Function VerificaUsuarioAtivo(ByVal objUsuario As Usuario) As Boolean
        Dim retorno As Boolean = False

        Using SqlConn As SqlConnection = Conexao.AbrirConexao()
            Using SqlComm As New SqlCommand()
                SqlComm.Connection = SqlConn
                SqlComm.CommandType = CommandType.Text
                SqlComm.CommandText = "SELECT * FROM tbl_usuario WHERE id = @id AND cod_ativo = 1"
                SqlComm.Parameters.Clear()
                SqlComm.Parameters.Add("id", SqlDbType.Int).Value = objUsuario.id

                Using dr As SqlDataReader = SqlComm.ExecuteReader()
                    If dr.HasRows() Then
                        retorno = True
                    End If
                End Using
            End Using
        End Using

        Return retorno
    End Function

    Public Function ValidaSenhaAtual(ByVal objUsuario As Usuario) As Boolean
        Dim retorno As Boolean = False

        Using SqlConn As SqlConnection = Conexao.AbrirConexao()
            Using SqlComm As New SqlCommand()
                SqlComm.Connection = SqlConn
                SqlComm.CommandType = CommandType.Text
                SqlComm.CommandText = "SELECT * FROM tbl_usuario WHERE id = @id AND txt_senha = @txt_senha"
                SqlComm.Parameters.Clear()
                SqlComm.Parameters.Add("id", SqlDbType.Int).Value = objUsuario.id
                SqlComm.Parameters.Add("txt_senha", SqlDbType.VarChar).Value = objUsuario.txt_senha

                Using dr As SqlDataReader = SqlComm.ExecuteReader()
                    If dr.HasRows() Then
                        retorno = True
                    End If
                End Using
            End Using
        End Using

        Return retorno
    End Function
#End Region


End Class
