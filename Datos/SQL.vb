Imports System.Data
Imports System.Data.SqlClient
Public Class SQL
    Dim conexion As SqlConnection
    Dim _string_conexion As String = "Data Source=tiusr11pl.cuc-carrera-ti.ac.cr.\MSSQLSERVER2019; Initial Catalog=tiusr4pl_BDMatricula; User ID=admin2T; Password=_pE7m64o7;"
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

    Sub AbrirConexion()
        Try
            conexion = New SqlConnection(_string_conexion)
            conexion.Open()
        Catch ex As Exception
            Throw New System.Exception(ex.Message)
        End Try

    End Sub
    Sub CerrarConexion()
        Try
            conexion.Close()
        Catch ex As Exception
            Throw New System.Exception("Error al cerrar la conexion a BD:" + ex.Message)
        End Try
    End Sub
    'creacion de regiones respectivas

#Region "Procedimientos cursos"
    'leer tabla correctamente 
    Sub leerTablaCursos()
        Dim instruccionSQL As SqlClient.SqlCommand 'agrego de comando sqlClient
        Dim DataAdapter As SqlClient.SqlDataAdapter 'agrego de comando sqlClient
        AbrirConexion()
        'instrucción select
        instruccionSQL = New SqlClient.SqlCommand("Select * from Cursos", conexion) 'agrego de comando sqlClient
        If dsCursos.Tables().Count > 0 Then
            If dsCursos.Tables(0).Rows.Count > 1 Then
                dsCursos.Tables(0).Clear()
            End If
        End If

        Try
            DataAdapter = New SqlClient.SqlDataAdapter(instruccionSQL) 'agrego de comando sqlClient
            DataAdapter.Fill(dsCursos)
        Catch ex As Exception
            Throw New System.Exception(ex.Message)
        End Try
        CerrarConexion()
    End Sub
    'metodo de insertar
    Sub InsertarCursosBD(idCurso As String, idCarrera As String, nombre As String, creditos As Integer, notaMinima As Integer, cantMin As Integer, cantMax As Integer, grado As String, estado As String, costo As Integer)
        'variable para la instruccion
        Dim sqlInstruccion As SqlClient.SqlCommand

        'Abra la conexion
        AbrirConexion()

        'Se prepara la instruccion SQL 
        sqlInstruccion = New SqlClient.SqlCommand("insert into Cursos(ID_Cursos, ID_Carrera, Nombre, Creditos, Nota_Min, Min_Estudiantes, Max_Estudiantes, Grado, Estado, Costo) values (@ID_Cursos, @ID_Carrera, @Nombre, @Creditos, @Nota_Min, @Min_Estudiantes, @Max_Estudiantes, @Grado, @Estado, @Costo)", conexion)

        'envio de parametros y sus respectivos valores
        sqlInstruccion.Parameters.AddWithValue("@ID_Cursos", idCurso)
        sqlInstruccion.Parameters.AddWithValue("@ID_Carrera", idCarrera)
        sqlInstruccion.Parameters.AddWithValue("@Nombre", nombre)
        sqlInstruccion.Parameters.AddWithValue("@Creditos", creditos)
        sqlInstruccion.Parameters.AddWithValue("@Nota_Min", notaMinima)
        sqlInstruccion.Parameters.AddWithValue("@Min_Estudiantes", cantMin)
        sqlInstruccion.Parameters.AddWithValue("@Max_Estudiantes", cantMax)
        sqlInstruccion.Parameters.AddWithValue("@Grado", grado)
        sqlInstruccion.Parameters.AddWithValue("@Estado", estado)
        sqlInstruccion.Parameters.AddWithValue("@Costo", costo)

        Try
            'ejecucion de la instruccion
            sqlInstruccion.ExecuteNonQuery()

        Catch ex As Exception
            Throw New System.Exception("Error al ejecutar el insert:" + ex.Message)
        End Try

        'cerramos la conexion
        CerrarConexion()
    End Sub
#End Region

#Region "Procedimientos Estudiantes"
    'creacion de la tabla respetiva
    Sub leerTablaEstudiantes()
        Dim instruccionSQL As SqlClient.SqlCommand
        Dim DataAdapter As SqlClient.SqlDataAdapter
        AbrirConexion()
        'instrucción select
        instruccionSQL = New SqlClient.SqlCommand("Select * from Estudiantes", conexion)
        If dsEstudiantes.Tables().Count > 0 Then
            If dsEstudiantes.Tables(0).Rows.Count > 1 Then
                dsEstudiantes.Tables(0).Clear()
            End If
        End If

        Try
            DataAdapter = New SqlClient.SqlDataAdapter(instruccionSQL)
            DataAdapter.Fill(dsEstudiantes)
        Catch ex As Exception
            Throw New System.Exception(ex.Message)
        End Try
        CerrarConexion()
    End Sub

    Sub InsertarEstudianteBD(idEstudiante As Integer, idCarrera As String, nombre As String, apellidos As String, beca As Integer, telefono As String, cantMax As Integer, grado As String, estado As String, costo As Integer)
        'variable para la instruccion
        Dim sqlInstruccion As SqlClient.SqlCommand

        'Abra la conexion
        AbrirConexion()

        'Se prepara la instruccion SQL 
        sqlInstruccion = New SqlClient.SqlCommand("insert into Cursos(ID_Cursos, ID_Carrera, Nombre, Creditos, Nota_Min, Min_Estudiantes, Max_Estudiantes, Grado, Estado, Costo) values (@ID_Cursos, @ID_Carrera, @Nombre, @Creditos, @Nota_Min, @Min_Estudiantes, @Max_Estudiantes, @Grado, @Estado, @Costo)", conexion)

        'envio de parametros y sus respectivos valores
        sqlInstruccion.Parameters.AddWithValue("@ID_Cursos", idCurso)
        sqlInstruccion.Parameters.AddWithValue("@ID_Carrera", idCarrera)
        sqlInstruccion.Parameters.AddWithValue("@Nombre", nombre)
        sqlInstruccion.Parameters.AddWithValue("@Creditos", creditos)
        sqlInstruccion.Parameters.AddWithValue("@Nota_Min", notaMinima)
        sqlInstruccion.Parameters.AddWithValue("@Min_Estudiantes", cantMin)
        sqlInstruccion.Parameters.AddWithValue("@Max_Estudiantes", cantMax)
        sqlInstruccion.Parameters.AddWithValue("@Grado", grado)
        sqlInstruccion.Parameters.AddWithValue("@Estado", estado)
        sqlInstruccion.Parameters.AddWithValue("@Costo", costo)

        Try
            'ejecucion de la instruccion
            sqlInstruccion.ExecuteNonQuery()

        Catch ex As Exception
            Throw New System.Exception("Error al ejecutar el insert:" + ex.Message)
        End Try

        'cerramos la conexion
        CerrarConexion()
    End Sub

#End Region


#End Region
End Class

