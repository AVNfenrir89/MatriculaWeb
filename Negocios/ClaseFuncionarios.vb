Imports Datos
Public Class ClaseFuncionarios
    Dim obj_FuncionariosBD As New SQL
    Public _nombre As String
    Public _apellidos As String
    Public _identificacion As String
    Private _usuario As String
    Private _clave As String

#Region "propiedades"
    Public Property TablaFuncionarios As DataTable
        Get
            Return obj_FuncionariosBD.TablaFuncionarios
        End Get
        Set(value As DataTable)

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
    Public Property Identificacion As String
        Get
            Return _identificacion
        End Get
        Set(value As String)
            _identificacion = value
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

    Public Property Usuario As String
        Get
            Return _usuario
        End Get
        Set(value As String)
            _usuario = value
        End Set
    End Property

    Public Property Clave As String
        Get
            Return _clave
        End Get
        Set(value As String)
            _clave = value
        End Set
    End Property
#End Region
End Class
