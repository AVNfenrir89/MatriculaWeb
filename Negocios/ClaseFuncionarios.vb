
Imports System.Security.AccessControl
Imports System.Text.RegularExpressions
Imports Datos

Public Class ClaseFuncionarios

    Dim datosFuncionario As New DataTable
    Dim obj_FuncionariosBD As New SQL
    Public _identificacion As String
    Shared _nombre As String
    Public _pApellido As String
    Public _sApellido As String
    Public _correo As String
    Public _usuario As String
    Public _clave As String
    Public _estado As String
    Private _mensaje As String

#Region "propiedades"
    Sub New()
        Estado = "inactivo"
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

    Sub SelecionarFuncionario()
        obj_FuncionariosBD.SelecionarFuncionario(_identificacion)
    End Sub
    Sub LoginFuncionarios()
        obj_FuncionariosBD.LoginFuncionario(_usuario)
    End Sub
    Sub leerTablaFuncionarios()
        obj_FuncionariosBD.LeerTablaFuncionarios()
    End Sub
    Sub AgregarFuncionarios()
        obj_FuncionariosBD.InsertarFuncionarios(_identificacion, _nombre, _pApellido, sApellido, _correo, _usuario, _clave, _estado)
    End Sub
    Sub borrarFuncionario()
        obj_FuncionariosBD.BorrarFuncionarioBD(_identificacion)
    End Sub
    Sub ModificarFuncionario()
        obj_FuncionariosBD.ModificarFuncionarioBD(_identificacion, _nombre, _pApellido, sApellido, _correo, _usuario, _clave, _estado)
    End Sub
    Sub ValidaDatosFuncionario()
        If TablaFuncionarios.Rows.Count = 0 Then
            Mensaje = "El Usuario o contraseña incorrecto no exite"
        End If
        For Each fila As DataRow In TablaFuncionarios.Rows

            If Not _clave = fila("Contrasena").trim Then
                Mensaje = "El Usuario o contraseña incorrecto o no exite"
                Exit For
            End If

            If "inactivo" = fila("Estado").trim Then
                Mensaje = "El Usuario está inactivo"
                Exit For
            End If
            Estado = fila("Estado").trim
        Next
    End Sub

    Public Function ValidaContasena(_clave) As Boolean
        Dim exprecion As String = "^(?=.*\d)(?=.*[\u0021-\u002b\u003c-\u0040])(?=.*[A-Z])(?=.*[a-z])\S{8,16}$"
        Dim regex As New Regex(exprecion)
        Return regex.IsMatch(_clave)
    End Function

    Public Function ValidaCorreo(correo) As Boolean
        Dim exprecion As String = "^(([^<>()\[\]\\.,;:\s@"” " & "]+(\.[^<>()\[\]\\.,;:\s@"” " & "]+)*)|("“" & ".+" & "”"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$"
        Dim regex As New Regex(exprecion)
        Return regex.IsMatch(correo)
    End Function
#End Region
End Class
