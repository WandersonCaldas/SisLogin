Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient

Public Class Conexao

    Public Shared Function AbrirConexao() As SqlConnection
        Dim SqlConn As New SqlConnection(ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString)
        SqlConn.Open()
        Return SqlConn
    End Function

    Public Shared Sub FecharConexao(ByRef SqlConn As SqlConnection)
        SqlConn.Close()
    End Sub

    Public Shared Function IniciarTransacao(ByRef SqlConn As SqlConnection) As SqlTransaction
        Dim SqlTrans As SqlTransaction
        SqlTrans = SqlConn.BeginTransaction(IsolationLevel.ReadCommitted)

        Return SqlTrans
    End Function

    Public Shared Sub CommitTransacao(ByRef transacao As SqlTransaction)
        transacao.Commit()
    End Sub

    Public Shared Sub RollBackTransacao(ByRef transacao As SqlTransaction)
        transacao.Rollback()
    End Sub
End Class
