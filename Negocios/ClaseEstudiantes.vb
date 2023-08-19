Imports System.Text.RegularExpressions
Imports Datos 'mportar
Public Class ClaseEstudiantes

    Dim _idEstudiantes As Integer
    Dim _idCarrera As String
    Dim _nombre As String
    Dim _apellidos As String
    Dim _beca As Integer
    Dim _telefono As String
    Dim _fechaNacimiento As Date
    Dim _correo As String
    Dim _direccion As String
    Dim mensajeBeca As String = "Total a pagar: "
    'objeto
    Dim obj_EstudiantesBD As New SQL
#Region "propiedades"
    Public Property TablaEstudiantes As DataTable
        Get
            Return obj_EstudiantesBD.TablaEstudiantes
        End Get
        Set(value As DataTable)

        End Set
    End Property

    Public Property IdEstudiantes As Integer
        Get
            Return _idEstudiantes
        End Get
        Set(value As Integer)
            _idEstudiantes = value
        End Set
    End Property

    Public Property IdCarrera As String
        Get
            Return _idCarrera
        End Get
        Set(value As String)
            _idCarrera = value
        End Set
    End Property

    Public Property Nombre As String
        Get
            Return _nombre
        End Get
        Set(value As String)
            _nombre = value
        End Set
    End Property

    Public Property Apellidos As String
        Get
            Return _apellidos
        End Get
        Set(value As String)
            _apellidos = value
        End Set
    End Property

    Public Property Beca As Integer
        Get
            Return _beca
        End Get
        Set(value As Integer)
            _beca = value
        End Set
    End Property

    Public Property Telefono As String
        Get
            Return _telefono
        End Get
        Set(value As String)
            _telefono = value
        End Set
    End Property

    Public Property FechaNacimiento As Date
        Get
            Return _fechaNacimiento
        End Get
        Set(value As Date)
            _fechaNacimiento = value
        End Set
    End Property

    Public Property Correo As String
        Get
            Return _correo
        End Get
        Set(value As String)
            _correo = value
        End Set
    End Property

    Public Property Direccion As String
        Get
            Return _direccion.Trim
        End Get
        Set(value As String)
            _direccion = value
        End Set
    End Property
#End Region

#Region "Metodos"

#Region "Consultas SQL"

    'agruegue metodo para leer la info de la tabla BD al dgv
    Sub LeeDatosEstudiantes()
        obj_EstudiantesBD.leerTablaEstudiantes()
    End Sub
    'aguegué metodo para ag
    Sub AgregarDatosEstudiantes()

        obj_EstudiantesBD.InsertarEstudianteBD(_idEstudiantes, _idCarrera, _nombre, _apellidos, _beca, _telefono, _fechaNacimiento, _correo, _direccion)

    End Sub
    Sub borrarEstudiante()
        obj_EstudiantesBD.BorrarEstudianteBD(_idEstudiantes)
    End Sub

    Sub SelecionarEstudiante()
        obj_EstudiantesBD.SelecionarEstudiante(IdEstudiantes)
    End Sub

    Sub ModificarEstudiante()
        obj_EstudiantesBD.ModificarEstudiante(_idEstudiantes, _idCarrera, _nombre, _apellidos, _beca, _telefono, _fechaNacimiento, _correo, _direccion)
    End Sub

    Sub SelecionarBeca()
        obj_EstudiantesBD.SelecionarBeca(_idEstudiantes)
    End Sub
#End Region

#Region "Validaciones"

    Sub validaciones()

        If IsNumeric(_nombre) Or _nombre.Length = 0 Then
            Throw New System.Exception("EL nombre no pude estar en números o quedar vacio")
        End If

        If IsNumeric(_apellidos) Or _nombre.Length = 0 Then
            Throw New System.Exception("Los apellidos no pude estar en números o quedar vacio")
        End If

        If Not IsNumeric(_telefono) Or _telefono.Length = 0 Then
            Throw New System.Exception("El teléfono no pude estar en letras o quedar vacio")
        End If

        If IsNumeric(_direccion) Or _direccion.Length = 0 Then
            Throw New System.Exception("La dirección no pude estar en números o quedar vacio")
        End If
    End Sub

    Public Function ValidaCorreo(correo) As Boolean
        Dim exprecion As String = "^(([^<>()\[\]\\.,;:\s@"” " & "]+(\.[^<>()\[\]\\.,;:\s@"” " & "]+)*)|("“" & ".+" & "”"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$"
        Dim regex As New Regex(exprecion)
        Return regex.IsMatch(correo)
    End Function

#End Region

#End Region
End Class
