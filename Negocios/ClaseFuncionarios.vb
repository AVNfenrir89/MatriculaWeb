
Imports System.Security.AccessControl
Imports Datos

Public Class ClaseFuncionarios

    Dim datosFuncionario As New DataTable
    Dim obj_FuncionariosBD As New SQL
    Shared _nombre As String
    Public _pApellido As String
    Public _sApellido As String
    Public _identificacion As String
    Public _correo As String
    Public _usuario As String
    Public _clave As String
    Public _estado As String
    Private _mensaje As String
#Region "propiedades"
    Sub New()
        _estado = "inactivo"
    End Sub
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


    Public Property pApellido As String
        Get
            Return _pApellido
        End Get
        Set(value As String)
            _pApellido = value
        End Set
    End Property

    Public Property sApellido As String
        Get
            Return _sApellido
        End Get
        Set(value As String)
            _sApellido = value
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


    Public Property Correo As String
        Get
            Return _correo
        End Get
        Set(value As String)
            _correo = value
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


    Public Property Mensaje As String
        Get
            Return _mensaje
        End Get
        Set(value As String)
            _mensaje = value
        End Set
    End Property


#End Region

#Region "metodos "
    Sub LoginFuncionarios()
        obj_FuncionariosBD.SelecionarFuncionario(_identificacion)
    End Sub
    Sub ValidaDatosFuncionario()

        For Each fila As DataRow In TablaFuncionarios.Rows


            If Not _clave = fila("Contrasena").trim Then
                Mensaje = "El Usuario no exite o está inactivo"
                Exit For
            End If

            If Not _usuario = fila("Usuario").trim Then
                Mensaje = "El Usuario no exite o está inactivo"
                Exit For
            End If

            If Not fila("Nombre").trim = _nombre Then
                Mensaje = "El Usuario no exite o está inactivo"
                Exit For
            End If

            If Not _pApellido = fila("P_Apellido").trim Then
                Mensaje = "El Usuario no exite o está inactivo"
                Exit For
            End If

            If Not _sApellido = fila("S_Apellido").trim Then
                Mensaje = "El Usuario no exite o está inactivo"
                Exit For
            End If

            If Not _correo = fila("Correo").trim Then
                Mensaje = "El Usuario no exite o está inactivo"
                Exit For
            End If




            Estado = fila("Estado").trim
        Next
    End Sub

#End Region
End Class
