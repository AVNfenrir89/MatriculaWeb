Imports System.Data
Imports System.Data.SqlClient

Public Class SQL
    Dim conexion As SqlConnection
    Dim _string_conexion As String
    Sub AbrirConexion()

        'definir el string de conexion   'localhost
        _string_conexion = "Data Source=tiusr19pl.cuc-carrera-ti.ac.cr\MSSQLSERVER2019;"
        ' nombre de base de datos
        _string_conexion = _string_conexion + "Initial Catalog=tiurs4pl_BDMatricula;"
        ' validacion con usuario de windows
        _string_conexion = _string_conexion + "User ID=admin2t;"
        _string_conexion = _string_conexion + "Password=_pE7m64o7;"

        Try
            conexion = New SqlConnection(_string_conexion)
            conexion.Open()
        Catch ex As Exception
            Throw New System.Exception(ex.Message)
        End Try

    End Sub

End Class
