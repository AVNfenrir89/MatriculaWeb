Imports Datos
Public Class ClaseFuncionarios
    Dim obj_FuncionariosBD As New SQL
    Dim _nombre As String
    Dim _apellido1 As String
    Dim _apellido2 As String
    Dim _correo As String
    Dim _identificacion As String
    Dim _usuario As String
    Dim _clave As String
    Dim _estado As String

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

    Public Property Apellido1 As String
        Get
            Return _apellido1
        End Get
        Set(value As String)
            _apellido1 = value
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

    Public Property Estado As String
        Get
            Return _estado
        End Get
        Set(value As String)
            _estado = value
        End Set
    End Property

    Public Property Apellido2 As String
        Get
            Return _apellido2
        End Get
        Set(value As String)
            _apellido2 = value
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
#End Region
End Class
