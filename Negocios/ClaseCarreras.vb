Imports Datos
Public Class ClaseCarreras
    Dim obj_CarrerasBD As New SQL
    Dim _idCarrera As String
    Dim _nombre As String
    Dim _estado As String
    Dim _grados As String
#Region "propiedades"
    Public Property TablaCarreras As DataTable
        Get
            Return obj_CarrerasBD.TablaCarreras
        End Get
        Set(value As DataTable)

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

    Public Property Estado As String
        Get
            Return _estado
        End Get
        Set(value As String)
            _estado = value
        End Set
    End Property

    Public Property Grados As String
        Get
            Return _grados
        End Get
        Set(value As String)
            _grados = value
        End Set
    End Property
#End Region

    Sub LeeDatosCarrera()
        obj_CarrerasBD.leerTablaCarreras()
    End Sub
    Sub AgregarDatosCarrera()
        obj_CarrerasBD.InsertarCarrerasBD(_idCarrera, _nombre, _grados, _estado)
    End Sub
    Sub BorrarDatosCarrera()
        obj_CarrerasBD.BorrarCarreraBD(_idCarrera)
    End Sub
    Sub ModificarCarrera()
        obj_CarrerasBD.ModificarCarreraBD(_idCarrera, _nombre, _grados, _estado)
    End Sub
    Sub SeleccionarCarrera()
        obj_CarrerasBD.SelecionarCarrera(_idCarrera)
    End Sub

End Class
