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
            Return _direccion
        End Get
        Set(value As String)
            _direccion = value
        End Set
    End Property
#End Region

#Region "Metodos"
    Sub validar()

    End Sub

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


#End Region
End Class
