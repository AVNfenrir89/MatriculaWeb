﻿Imports System.Collections.ObjectModel
Imports System.Data
Imports System.Data.Common
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
    Sub InsertarCursosBD(idCurso As String, idCarrera As String, nombre As String, creditos As Integer, notaMinima As Integer, cantMin As Integer, cantMax As Integer, grado As String, estado As String, costo As Integer, cuatri As String)
        'variable para la instruccion
        Dim sqlInstruccion As SqlClient.SqlCommand

        'Abra la conexion
        AbrirConexion()

        'Se prepara la instruccion SQL 
        sqlInstruccion = New SqlClient.SqlCommand("insert into Cursos(ID_Cursos, ID_Carrera, Nombre, Creditos, Nota_Min, Min_Estudiantes, Max_Estudiantes, Grado, Estado, Costo, cuatrimestre) values (@ID_Cursos, @ID_Carrera, @Nombre, @Creditos, @Nota_Min, @Min_Estudiantes, @Max_Estudiantes, @Grado, @Estado, @Costo, @Cuatrimestre)", conexion)
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
        sqlInstruccion.Parameters.AddWithValue("@Cuatrimestre", cuatri)

        Try
            'ejecucion de la instruccion
            sqlInstruccion.ExecuteNonQuery()

        Catch ex As Exception
            Throw New System.Exception("Error al ejecutar el insert:" + ex.Message)
        End Try

        'cerramos la conexion
        CerrarConexion()
    End Sub

    Sub BorrarCursoBD(idCurso As String)
        Dim sqlInstruccion As SqlClient.SqlCommand

        AbrirConexion()
        sqlInstruccion = New SqlClient.SqlCommand("DELETE FROM Cursos WHERE ID_Cursos = @ID_Cursos", conexion)
        sqlInstruccion.Parameters.AddWithValue("@ID_Cursos", idCurso)
        Try
            sqlInstruccion.ExecuteNonQuery()
        Catch ex As Exception
            Throw New System.Exception("Error al ejecutar el DELETE: " + ex.Message)
        End Try

        ' Cerramos la conexión
        CerrarConexion()
    End Sub

    ' Método para modificar una carrera en la base de datos
    Sub ModificarCursoBD(idCurso As String, idCarrera As String, nombre As String, creditos As Integer, notaMinima As Integer, cantMin As Integer, cantMax As Integer, grado As String, estado As String, costo As Integer, cuatri As String)
        Dim sqlInstruccion As SqlClient.SqlCommand

        AbrirConexion()

        ' Utilizamos un comando SQL para actualizar la carrera con el ID_Carrera específico
        sqlInstruccion = New SqlClient.SqlCommand("UPDATE Cursos SET ID_Carrera=@ID_Carrera, Nombre = @Nombre, Creditos = @Creditos, Nota_Min = @Nota_Min, Min_Estudiantes = @Min_Estudiantes, Max_Estudiantes=@Max_Estudiantes, Grado = @Grado, Estado = @Estado, Costo=@Costo, Cuatrimestre = @Cuatrimestre WHERE ID_Cursos = @ID_Cursos", conexion)
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
        sqlInstruccion.Parameters.AddWithValue("@Cuatrimestre", cuatri)
        Try
            ' Ejecución de la instrucción UPDATE
            sqlInstruccion.ExecuteNonQuery()
        Catch ex As Exception
            Throw New System.Exception("Error al ejecutar el UPDATE: " + ex.Message)
        End Try

        ' Cerramos la conexión
        CerrarConexion()
    End Sub

    Sub SelecionarCurso(idCurso)

        Dim instruccionSQL As SqlClient.SqlCommand
        Dim DataAdapter As SqlClient.SqlDataAdapter
        AbrirConexion()
        'instrucción select
        instruccionSQL = New SqlClient.SqlCommand("SELECT * FROM Cursos WHERE ID_Cursos =" & idCurso, conexion)

        If dsCursos.Tables().Count > 0 Then
            If dsCursos.Tables(0).Rows.Count > 1 Then
                dsCursos.Tables(0).Clear()
            End If
        End If
        Try
            DataAdapter = New SqlClient.SqlDataAdapter(instruccionSQL)
            DataAdapter.Fill(dsCursos)
        Catch ex As Exception
            Throw New System.Exception(ex.Message)
        End Try
        CerrarConexion()
    End Sub
    Sub ConsultaIdPorNombre(nombre As String)

        Dim instruccionSQL As SqlClient.SqlCommand
        Dim DataAdapter As SqlClient.SqlDataAdapter
        AbrirConexion()
        'instrucción select
        instruccionSQL = New SqlClient.SqlCommand("SELECT * FROM Cursos WHERE Nombre =" & nombre, conexion)
        If dsCursos.Tables().Count > 0 Then
            If dsCursos.Tables(0).Rows.Count > 1 Then
                dsCursos.Tables(0).Clear()
            End If
        End If
        Try
            DataAdapter = New SqlClient.SqlDataAdapter(instruccionSQL)
            DataAdapter.Fill(dsCursos)
        Catch ex As Exception
            Throw New System.Exception(ex.Message)
        End Try
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
    'método insertar
    Sub InsertarEstudianteBD(idEstudiante As Integer, idCarrera As String, nombre As String, apellidos As String, beca As Integer, telefono As String, fecha As Date, correo As String, direccion As String)
        Dim sqlInstruccion As SqlClient.SqlCommand

        AbrirConexion()

        sqlInstruccion = New SqlClient.SqlCommand("insert into Estudiantes(ID_Estudiantes, ID_Carrera, Nombre, Apellidos, Beca, Telefono, Fecha_Nacimiento, Correo, Direccion) values (@ID_Estudiantes, @ID_Carrera, @Nombre, @Apellidos, @Beca, @Telefono, @Fecha_Nacimiento, @Correo, @Direccion)", conexion)
        sqlInstruccion.Parameters.AddWithValue("@ID_Estudiantes", idEstudiante)
        sqlInstruccion.Parameters.AddWithValue("@ID_Carrera", idCarrera)
        sqlInstruccion.Parameters.AddWithValue("@Nombre", nombre)
        sqlInstruccion.Parameters.AddWithValue("@Apellidos", apellidos)
        sqlInstruccion.Parameters.AddWithValue("@Beca", beca)
        sqlInstruccion.Parameters.AddWithValue("@Telefono", telefono)
        sqlInstruccion.Parameters.AddWithValue("@Fecha_Nacimiento", fecha)
        sqlInstruccion.Parameters.AddWithValue("@Correo", correo)
        sqlInstruccion.Parameters.AddWithValue("@Direccion", direccion)
        Try
            sqlInstruccion.ExecuteNonQuery()
        Catch ex As Exception
            Throw New System.Exception("Error al ejecutar el insert:" + ex.Message)
        End Try
        CerrarConexion()
    End Sub
    Sub BorrarEstudianteBD(idEstudiante As String)
        Dim sqlInstruccion As SqlClient.SqlCommand

        AbrirConexion()
        sqlInstruccion = New SqlClient.SqlCommand("DELETE FROM Estudiantes WHERE ID_Estudiantes = @ID_Estudiantes", conexion)
        sqlInstruccion.Parameters.AddWithValue("@ID_Estudiantes", idEstudiante)
        Try
            sqlInstruccion.ExecuteNonQuery()
        Catch ex As Exception
            Throw New System.Exception("Error al ejecutar el DELETE: " + ex.Message)
        End Try
        ' Cerramos la conexión
        CerrarConexion()
    End Sub


    Sub ModificarEstudiante(idEstudiante As Integer, idCarrera As String, nombre As String, apellidos As String, beca As Integer, telefono As String, fecha As Date, correo As String, direccion As String)
        Dim sqlInstruccion As SqlClient.SqlCommand
        AbrirConexion()
        sqlInstruccion = New SqlClient.SqlCommand("UPDATE Estudiantes SET ID_Carrera = @ID_Carrera, Nombre=@Nombre, Apellidos=@Apellidos, Beca=@Beca, Telefono= @Telefono, Fecha_Nacimiento=@Fecha_Nacimiento, Correo=@Correo, Direccion=@Direccion WHERE ID_Estudiantes=@ID_Estudiantes", conexion)
        sqlInstruccion.Parameters.AddWithValue("@ID_Estudiantes", idEstudiante)
        sqlInstruccion.Parameters.AddWithValue("@ID_Carrera", idCarrera)
        sqlInstruccion.Parameters.AddWithValue("@Nombre", nombre)
        sqlInstruccion.Parameters.AddWithValue("@Apellidos", apellidos)
        sqlInstruccion.Parameters.AddWithValue("@Beca", beca)
        sqlInstruccion.Parameters.AddWithValue("@Telefono", telefono)
        sqlInstruccion.Parameters.AddWithValue("@Fecha_Nacimiento", fecha)
        sqlInstruccion.Parameters.AddWithValue("@Correo", correo)
        sqlInstruccion.Parameters.AddWithValue("@Direccion", direccion)
        Try
            sqlInstruccion.ExecuteNonQuery()
        Catch ex As Exception
            Throw New System.Exception("Error al ejecutar el insert:" + ex.Message)
        End Try
        CerrarConexion()
    End Sub

    Sub SelecionarEstudiante(idEstudiante)

        Dim instruccionSQL As SqlClient.SqlCommand
        Dim DataAdapter As SqlClient.SqlDataAdapter
        AbrirConexion()
        'instrucción select
        instruccionSQL = New SqlClient.SqlCommand("SELECT * FROM Estudiantes WHERE ID_Estudiantes =" & idEstudiante, conexion)

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


#End Region

#Region "Procedimientos carreras"
    Sub leerTablaCarreras()
        Dim instruccionSQL As SqlClient.SqlCommand
        Dim DataAdapter As SqlClient.SqlDataAdapter
        AbrirConexion()

        instruccionSQL = New SqlClient.SqlCommand("Select * from Carreras", conexion)
        If dsCarreras.Tables().Count > 0 Then
            If dsCarreras.Tables(0).Rows.Count > 1 Then
                dsCarreras.Tables(0).Clear()
            End If
        End If

        Try
            DataAdapter = New SqlClient.SqlDataAdapter(instruccionSQL)
            DataAdapter.Fill(dsCarreras)
        Catch ex As Exception
            Throw New System.Exception(ex.Message)
        End Try
        CerrarConexion()
    End Sub
    'metodo de insertar
    Sub InsertarCarrerasBD(idCarrera As String, Nombre As String, Grado As String, Estado As String)

        Dim sqlInstruccion As SqlClient.SqlCommand

        AbrirConexion()

        sqlInstruccion = New SqlClient.SqlCommand("insert into Carreras(ID_Carrera, Nombre, Grado, Estado) values (@ID_Carrera, @Nombre, @Grado, @Estado)", conexion)
        sqlInstruccion.Parameters.AddWithValue("@ID_Carrera", idCarrera)
        sqlInstruccion.Parameters.AddWithValue("@Nombre", Nombre)
        sqlInstruccion.Parameters.AddWithValue("@Grado", Grado)
        sqlInstruccion.Parameters.AddWithValue("@Estado", Estado)

        Try
            'ejecucion de la instruccion
            sqlInstruccion.ExecuteNonQuery()

        Catch ex As Exception
            Throw New System.Exception("Error al ejecutar el insert:" + ex.Message)
        End Try

        'cerramos la conexion
        CerrarConexion()
    End Sub

    ' Método para borrar una carrera de la base de datos
    Sub BorrarCarreraBD(idCarrera As String)
        Dim sqlInstruccion As SqlClient.SqlCommand

        AbrirConexion()
        sqlInstruccion = New SqlClient.SqlCommand("DELETE FROM Carreras WHERE ID_Carrera = @ID_Carrera", conexion)
        sqlInstruccion.Parameters.AddWithValue("@ID_Carrera", idCarrera)

        Try
            sqlInstruccion.ExecuteNonQuery()
        Catch ex As Exception
            Throw New System.Exception("Error al ejecutar el DELETE: " + ex.Message)
        End Try

        ' Cerramos la conexión
        CerrarConexion()
    End Sub


    ' Método para modificar una carrera en la base de datos
    Sub ModificarCarreraBD(idCarrera As String, Nombre As String, Grado As String, Estado As String)
        Dim sqlInstruccion As SqlClient.SqlCommand

        AbrirConexion()

        ' Utilizamos un comando SQL para actualizar la carrera con el ID_Carrera específico
        sqlInstruccion = New SqlClient.SqlCommand("UPDATE Carreras SET Nombre = @Nombre, Grado = @Grado, Estado = @Estado WHERE ID_Carrera = @ID_Carrera", conexion)
        sqlInstruccion.Parameters.AddWithValue("@ID_Carrera", idCarrera)
        sqlInstruccion.Parameters.AddWithValue("@Nombre", Nombre)
        sqlInstruccion.Parameters.AddWithValue("@Grado", Grado)
        sqlInstruccion.Parameters.AddWithValue("@Estado", Estado)

        Try
            ' Ejecución de la instrucción UPDATE
            sqlInstruccion.ExecuteNonQuery()
        Catch ex As Exception
            Throw New System.Exception("Error al ejecutar el UPDATE: " + ex.Message)
        End Try

        ' Cerramos la conexión
        CerrarConexion()
    End Sub
    Sub SelecionarCarrera(idCarrera)
        Dim instruccionSQL As SqlClient.SqlCommand
        Dim DataAdapter As SqlClient.SqlDataAdapter
        AbrirConexion()
        instruccionSQL = New SqlClient.SqlCommand("SELECT * FROM Carreras WHERE ID_Carrera = " & idCarrera, conexion)
        If dsCarreras.Tables().Count > 0 Then
            If dsCarreras.Tables(0).Rows.Count > 1 Then
                dsCarreras.Tables(0).Clear()
            End If
        End If
        Try
            DataAdapter = New SqlClient.SqlDataAdapter(instruccionSQL)
            DataAdapter.Fill(dsCarreras)
        Catch ex As Exception
            Throw New System.Exception(ex.Message)
        End Try
        CerrarConexion()
    End Sub

#End Region

#Region "Procedimientos funcionarios"

    Sub LeerTablaFuncionarios()
        Dim sqlInstruccion As SqlClient.SqlCommand
        Dim DataAdapter As SqlClient.SqlDataAdapter
        AbrirConexion()
        sqlInstruccion = New SqlClient.SqlCommand("Select * from Funcionarios", conexion)
        If dsFuncionarios.Tables().Count > 0 Then
            If dsFuncionarios.Tables(0).Rows.Count > 1 Then
                dsFuncionarios.Tables(0).Clear()

            End If
        End If
        Try
            DataAdapter = New SqlClient.SqlDataAdapter(sqlInstruccion)
            DataAdapter.Fill(dsFuncionarios)
        Catch ex As Exception
            Throw New System.Exception(ex.Message)
        End Try
    End Sub

    Sub InsertarFuncionarios(idFuncionarios As String, nombre As String, apellido1 As String, apellido2 As String, correo As String, usuario As String, contraseña As String, estado As String)
        Dim sqlInstruccion As SqlClient.SqlCommand
        AbrirConexion()
        sqlInstruccion = New SqlClient.SqlCommand("insert into Funcionarios(ID_Funcionarios, Nombre, P_Apellido, S_Apellido, Correo, Usuario, Contrasena, Estado)", conexion)
        sqlInstruccion.Parameters.AddWithValue("@ID_Funcionarios", idFuncionarios)
        sqlInstruccion.Parameters.AddWithValue("@Nombre", nombre)
        sqlInstruccion.Parameters.AddWithValue("@P_Apellido", apellido1)
        sqlInstruccion.Parameters.AddWithValue("@S_Apellido", apellido2)
        sqlInstruccion.Parameters.AddWithValue("@Correo", correo)
        sqlInstruccion.Parameters.AddWithValue("@Usuario", usuario)
        sqlInstruccion.Parameters.AddWithValue("@Contrasena", contraseña)
        sqlInstruccion.Parameters.AddWithValue("@Estado", estado)
        Try
            sqlInstruccion.ExecuteNonQuery()

        Catch ex As Exception
            Throw New System.Exception("Error al ejecutar el insert:" + ex.Message)
        End Try
        CerrarConexion()
    End Sub

    Sub BorrarFuncionarioBD(idFuncionario As String)
        Dim sqlInstruccion As SqlClient.SqlCommand

        AbrirConexion()
        sqlInstruccion = New SqlClient.SqlCommand("DELETE FROM Funcionarios WHERE ID_Funcionarios= @ID_Funcionarios", conexion)
        sqlInstruccion.Parameters.AddWithValue("@ID_Funcionarios", idFuncionario)

        Try
            sqlInstruccion.ExecuteNonQuery()
        Catch ex As Exception
            Throw New System.Exception("Error al ejecutar el DELETE: " + ex.Message)
        End Try

        ' Cerramos la conexión
        CerrarConexion()
    End Sub

    Sub ModificarFuncionarioBD(idFuncionarios As String, nombre As String, apellido1 As String, apellido2 As String, correo As String, usuario As String, contraseña As String, estado As String)
        Dim sqlInstruccion As SqlClient.SqlCommand

        AbrirConexion()
        sqlInstruccion = New SqlClient.SqlCommand("UPDATE Funcionarios SET Nombre = @Nombre, P_Apellido= @P_Apellido, S_Apellido= @S_Apellido, Correo= @Correo, Usuario=@Usuario, Contrasena=@Contrasena, Estado = @Estado WHERE ID_Funcionarios = @ID_Funcionarios", conexion)
        sqlInstruccion.Parameters.AddWithValue("@ID_Funcionarios", idFuncionarios)
        sqlInstruccion.Parameters.AddWithValue("@Nombre", nombre)
        sqlInstruccion.Parameters.AddWithValue("@P_Apellido", apellido1)
        sqlInstruccion.Parameters.AddWithValue("@S_Apellido", apellido2)
        sqlInstruccion.Parameters.AddWithValue("@Correo", correo)
        sqlInstruccion.Parameters.AddWithValue("@Usuario", usuario)
        sqlInstruccion.Parameters.AddWithValue("@Contrasena", contraseña)
        sqlInstruccion.Parameters.AddWithValue("@Estado", estado)
        Try
            sqlInstruccion.ExecuteNonQuery()
        Catch ex As Exception
            Throw New System.Exception("Error al ejecutar el UPDATE: " + ex.Message)
        End Try
        CerrarConexion()
    End Sub

    Sub SelecionarFuncionario(idFuncionario)
        Dim instruccionSQL As SqlClient.SqlCommand
        Dim DataAdapter As SqlClient.SqlDataAdapter
        AbrirConexion()
        instruccionSQL = New SqlClient.SqlCommand("SELECT * FROM Funcionarios WHERE ID_Funcionarios =" & idFuncionario, conexion)

        If dsFuncionarios.Tables().Count > 0 Then
            If dsFuncionarios.Tables(0).Rows.Count > 1 Then
                dsFuncionarios.Tables(0).Clear()
            End If
        End If

        Try
            DataAdapter = New SqlClient.SqlDataAdapter(instruccionSQL)
            DataAdapter.Fill(dsFuncionarios)
        Catch ex As Exception
            Throw New System.Exception(ex.Message)
        End Try
        CerrarConexion()
    End Sub

#End Region

#Region "Procedimientos matrícula"

    Sub LeerTablaMatriculaBD()
        Dim instruccionSQL As SqlClient.SqlCommand
        Dim DataAdapter As SqlClient.SqlDataAdapter
        AbrirConexion()
        instruccionSQL = New SqlClient.SqlCommand("Select * from Matricula", conexion)
        If dsCursos.Tables().Count > 0 Then
            If dsMatricula.Tables(0).Rows.Count > 1 Then
                dsMatricula.Tables(0).Clear()
            End If
        End If
        Try
            DataAdapter = New SqlClient.SqlDataAdapter(instruccionSQL)
            DataAdapter.Fill(dsCursos)
        Catch ex As Exception
            Throw New System.Exception(ex.Message)
        End Try
        CerrarConexion()
    End Sub
    Sub InsertarMatricula(idMatricula As Integer, idEstudiante As Integer, idCarrera As String, costo As Integer, cuatrimestre As String, periodo As String)
        Dim sqlInstruccion As SqlClient.SqlCommand
        AbrirConexion()
        sqlInstruccion = New SqlClient.SqlCommand("insert into Matricula(ID_Matricula, ID_Estudiante, ID_Carrera, Costo, Cuatrimestre, Periodo) values (@ID_Matricula, @ID_Estudiante, @ID_Carrera, @Costo, @Cuatrimestre, @Periodo)", conexion)
        sqlInstruccion.Parameters.AddWithValue("@ID_Matricula", idMatricula)
        sqlInstruccion.Parameters.AddWithValue("@ID_Estudiante", idEstudiante)
        sqlInstruccion.Parameters.AddWithValue("@ID_Carrera", idCarrera)
        sqlInstruccion.Parameters.AddWithValue("@Costo", costo)
        sqlInstruccion.Parameters.AddWithValue("@Cuatrimestre", cuatrimestre)
        sqlInstruccion.Parameters.AddWithValue("@Periodo", periodo)
        Try
            sqlInstruccion.ExecuteNonQuery()
        Catch ex As Exception
            Throw New System.Exception("Error al ejecutar el insert:" + ex.Message)
        End Try
        CerrarConexion()
    End Sub

    Sub ConsultarIdMatricula(idCarrera As String, idEstudiante As String, cuatrimestre As String)
        Dim instruccionSQL As SqlClient.SqlCommand
        Dim DataAdapter As SqlClient.SqlDataAdapter
        AbrirConexion()
        'instrucción select
        instruccionSQL = New SqlClient.SqlCommand("SELECT * FROM Matricula WHERE ID_Estudiantes =" & idEstudiante & " AND ID_Carrera= " & idCarrera & " AND Cuatrimestre =" & cuatrimestre, conexion)

        If dsMatricula.Tables().Count > 0 Then
            If dsMatricula.Tables(0).Rows.Count > 1 Then
                dsMatricula.Tables(0).Clear()
            End If
        End If
        Try
            DataAdapter = New SqlClient.SqlDataAdapter(instruccionSQL)
            DataAdapter.Fill(dsMatricula)
        Catch ex As Exception
            Throw New System.Exception(ex.Message)
        End Try
        CerrarConexion()
    End Sub
    ''hiciste esto, no entiendo
    Sub SelecionarIDestudisntes(idcarrera As String, cuatrimestre As String)
        Dim instruccionSQL As SqlClient.SqlCommand
        Dim DataAdapter As SqlClient.SqlDataAdapter
        AbrirConexion()
        instruccionSQL = New SqlClient.SqlCommand("SELECT @ID_Estudiante FROM Matricula WHERE ID_Carrera =" & idcarrera & "  ", conexion)

        If dsFuncionarios.Tables().Count > 0 Then
            If dsFuncionarios.Tables(0).Rows.Count > 1 Then
                dsFuncionarios.Tables(0).Clear()
            End If
        End If

        Try
            DataAdapter = New SqlClient.SqlDataAdapter(instruccionSQL)
            DataAdapter.Fill(dsFuncionarios)
        Catch ex As Exception
            Throw New System.Exception(ex.Message)
        End Try
        CerrarConexion()
    End Sub '''''''''''''

    Sub UpdateBD(idMatricula As Integer, idEstudiante As Integer, idCarrera As String, Costo As Integer, cuatrimestre As String, periodo As String)
        Dim sqlInstruccion As SqlClient.SqlCommand

        AbrirConexion()
        sqlInstruccion = New SqlClient.SqlCommand("UPDATE Matricula SET ID_Estudiante= @ID_Estudiante, ID_Carrera= @ID_Carrera, Costo= @Costo, Cuatrimestre= @Cuatrimestre, Periodo= @Periodo WHERE ID_Matricula = @ID_Matricula", conexion)
        sqlInstruccion.Parameters.AddWithValue("@ID_Matricula", idMatricula)
        sqlInstruccion.Parameters.AddWithValue("@ID_Estudiante", idEstudiante)
        sqlInstruccion.Parameters.AddWithValue("@ID_Carrera", idCarrera)
        sqlInstruccion.Parameters.AddWithValue("@Costo", Costo)
        sqlInstruccion.Parameters.AddWithValue("@Cuatrimestre", cuatrimestre)
        sqlInstruccion.Parameters.AddWithValue("@Periodo", periodo)
        Try
            sqlInstruccion.ExecuteNonQuery()
        Catch ex As Exception
            Throw New System.Exception("Error al ejecutar el UPDATE: " + ex.Message)
        End Try
        CerrarConexion()
    End Sub

#Region "Procedimiento tabla Intermedia"
    Sub LeerTablaCursosxMatricula()
        Dim instruccionSQL As SqlClient.SqlCommand
        Dim DataAdapter As SqlClient.SqlDataAdapter
        AbrirConexion()
        instruccionSQL = New SqlClient.SqlCommand("Select * from CursoPorMatricula", conexion)
        If dsMatricula.Tables().Count > 0 Then
            If dsMatricula.Tables(0).Rows.Count > 1 Then
                dsMatricula.Tables(0).Clear()
            End If
        End If

        Try
            DataAdapter = New SqlClient.SqlDataAdapter(instruccionSQL)
            DataAdapter.Fill(dsMatricula)
        Catch ex As Exception
            Throw New System.Exception(ex.Message)
        End Try
        CerrarConexion()
    End Sub
    Sub InsertarCursosxMatricula(idCurso As String, idMatricula As Integer)
        Dim sqlInstruccion As SqlClient.SqlCommand
        AbrirConexion()
        sqlInstruccion = New SqlClient.SqlCommand("insert into CursoPorMatricula(idCursoPorMatricula, idCurso, idMatricula) values (@idCursoPorMatricula, @idCurso, @idMatricula)", conexion)
        sqlInstruccion.Parameters.AddWithValue("@idCursoPorMatricula", 0)
        sqlInstruccion.Parameters.AddWithValue("@idCurso", idCurso)
        sqlInstruccion.Parameters.AddWithValue("@idMatricula", idMatricula)
        Try
            sqlInstruccion.ExecuteNonQuery()
        Catch ex As Exception
            Throw New System.Exception("Error al ejecutar el insert:" + ex.Message)
        End Try
        CerrarConexion()

    End Sub

    Sub consultarCursosPormatricula(idMatricula As Integer)

        Dim instruccionSQL As SqlClient.SqlCommand
        Dim DataAdapter As SqlClient.SqlDataAdapter
        AbrirConexion()
        instruccionSQL = New SqlClient.SqlCommand()
        instruccionSQL = New SqlClient.SqlCommand("SELECT * FROM CursosPorMatricula WHERE idMatricula =" & idMatricula, conexion)
        If dsMatricula.Tables().Count > 0 Then
            If dsMatricula.Tables(0).Rows.Count > 1 Then
                dsMatricula.Tables(0).Clear()
            End If
        End If

        Try
            DataAdapter = New SqlClient.SqlDataAdapter(instruccionSQL)
            DataAdapter.Fill(dsFuncionarios)
        Catch ex As Exception
            Throw New System.Exception(ex.Message)
        End Try
        CerrarConexion()
    End Sub

    Sub EliminarCursosPorMatricula(idCurso As String, idMatricula As Integer)
        Dim sqlInstruccion As SqlClient.SqlCommand
        AbrirConexion()
        sqlInstruccion = New SqlClient.SqlCommand("DELETE FROM CursoPorMatricula WHERE idCurso= @idCurso AND idMatricula = @idMatricula", conexion)
        sqlInstruccion.Parameters.AddWithValue("@idCurso", idCurso)
        sqlInstruccion.Parameters.AddWithValue("@idMatricula", idMatricula)
        Try
            sqlInstruccion.ExecuteNonQuery()
        Catch ex As Exception
            Throw New System.Exception("Error al ejecutar el DELETE: " + ex.Message)
        End Try
        CerrarConexion()
    End Sub
#End Region

#End Region
#End Region

End Class

