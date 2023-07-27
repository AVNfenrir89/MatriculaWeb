Imports System.Data
Imports System.Data.SqlClient

Public Class SQL
    Dim conexion As SqlConnection
    Dim _string_conexion As String
    Dim dsEstudiantes As New DataSet
    Dim dsFuncionarios As New DataSet
    Dim dsCarreras As New DataSet
    Dim dsMatricula As New DataSet
    Dim dsCursos As New DataSet

#Region "Propiedades"
    Public Property TablaEstudiantes As DataTable
        Get
            Return dsEstudiantes.Tables(0)
        End Get
        Set(value As DataTable)
        End Set
    End Property

    Public Property TablaFuncionarios As DataTable
        Get
            Return dsFuncionarios.Tables(0)
        End Get
        Set(value As DataTable)

        End Set
    End Property
    Public Property TablaCarreras As DataTable
        Get
            Return dsCarreras.Tables(0)
        End Get
        Set(value As DataTable)

        End Set
    End Property
    Public Property TablaCursos As DataTable
        Get
            Return dsCursos.Tables(0)
        End Get
        Set(value As DataTable)

        End Set
    End Property
    Public Property TablaMatricula As DataTable
        Get
            Return dsMatricula.Tables(0)
        End Get
        Set(value As DataTable)

        End Set
    End Property
#End Region
#Region "Metodos"
    Sub leerEstudiantes()
        Dim instruccionSQL As SqlCommand
        Dim DataAdapter As SqlDataAdapter

        'instrucción select
        instruccionSQL = New SqlCommand("Select from Estudiantes", conexion)






    End Sub
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





















#End Region

End Class
