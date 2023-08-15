
Imports Datos 'importe datos
Public Class ClaseCursos

    Dim _idCurso As String
    Dim _idCarrera As String
    Dim _nombre As String
    Dim _creditos As Integer
    Dim _notaMinima As Integer
    Dim _cantMin As Integer
    Dim _cantMax As Integer
    Dim _grado As String
    Dim _estado As String
    Dim _costo As Integer
    Dim _cuatri As String
    'obj para referenciar de que tipo es el objeto
    Dim obj_CursosBD As New SQL
    Dim mensaje As String = obj_CursosBD.Mensaje
#Region "Propiedades"
    Public Property IdCurso As String
        Get
            Return _idCurso
        End Get
        Set(value As String)
            _idCurso = value
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

    Public Property Creditos As Integer
        Get
            Return _creditos
        End Get
        Set(value As Integer)
            _creditos = value
        End Set
    End Property

    Public Property CantMin As Integer
        Get
            Return _cantMin
        End Get
        Set(value As Integer)
            _cantMin = value
        End Set
    End Property

    Public Property CantMax As Integer
        Get
            Return _cantMax
        End Get
        Set(value As Integer)
            _cantMax = value
        End Set
    End Property

    Public Property Grado As String
        Get
            Return _grado
        End Get
        Set(value As String)
            _grado = value
        End Set
    End Property

    Public Property Estado As String
        Get
            Return _estado
        End Get
        Set(value As String)
            _estado = value
        End Set
    End Property

    Public Property Costo As Integer
        Get
            Return _costo
        End Get
        Set(value As Integer)
            _costo = value
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

    Public Property NotaMinima As Integer
        Get
            Return _notaMinima
        End Get
        Set(value As Integer)
            _notaMinima = value
        End Set
    End Property
    'agregue tabla
    Public Property TablaCursos As DataTable
        Get
            Return obj_CursosBD.TablaCursos
        End Get
        Set(value As DataTable)

        End Set
    End Property

    Public Property Cuatri As String
        Get
            Return _cuatri
        End Get
        Set(value As String)
            _cuatri = value
        End Set
    End Property




#End Region

#Region "Métodos"
    Function Costo_curso(creditos)
        Dim Resultado As Integer
        _creditos = Int(creditos)
        Resultado = 10000 * _creditos
        Return Str(Resultado)
    End Function
    Sub validar()
        'validar cantidad de estudiantes minima y maxima ?
    End Sub

    'agruegue metodo para leer la info de la tabla BD al dgv
    Sub LeeDatosCursos()
        obj_CursosBD.leerTablaCursos()
    End Sub
    Sub AgregarDatosCursos()
        obj_CursosBD.InsertarCursosBD(_idCurso, _idCarrera, _nombre, _creditos, _notaMinima, _cantMin, _cantMax, _grado, _estado, _costo, _cuatri)
    End Sub
    Sub borrarCurso()
        obj_CursosBD.BorrarCursoBD(_idCurso)
    End Sub
    Sub modificarCurso()
        obj_CursosBD.ModificarCursoBD(_idCurso, _idCarrera, _nombre, _creditos, _notaMinima, _cantMin, _cantMax, _grado, _estado, _costo, _cuatri)
    End Sub

    Sub SeleccionarPorIDcurso()
        obj_CursosBD.SelecionarCurso(IdCurso)
    End Sub
    Sub BuscarIDPorNombre()
        obj_CursosBD.ConsultaIdPorNombre(_nombre)
    End Sub
#End Region

End Class

