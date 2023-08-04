Imports Negocios
Public Class Formulario_web12
    Inherits System.Web.UI.Page
    Dim obj_Carreras As New Negocios.ClaseCarreras
    Dim obj_Estudiantes As New Negocios.ClaseEstudiantes
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim estudiante As New DataTable
        Dim Carreras As New DataTable
        Dim nombre As String
        Dim id As String
        obj_Carreras.LeeDatosCarrera()
        Carreras = obj_Carreras.TablaCarreras
        obj_Estudiantes.LeeDatosEstudiantes()
        estudiante = obj_Estudiantes.TablaEstudiantes

        'se itera cada fila de la tabla carreras y se agrega items al select_carrera
        For Each fila As DataRow In Carreras.Rows
            nombre = fila("Nombre")
            id = fila("ID_Carrera")
            Dim opcion As New ListItem(nombre, id)
            select_carrera.Items.Add(opcion)
        Next
        'se itera cada fila de la tabla carreras y se agrega items al select_estudiante
        For Each fila As DataRow In estudiante.Rows
            nombre = fila("Nombre")
            id = fila("ID_Estudiantes")
            Dim opcion As New ListItem(id, id)
            select_estudiante.Items.Add(opcion)
        Next
    End Sub




    Protected Sub btn_mostrar_Click(sender As Object, e As EventArgs)

        lb_curso_uno.InnerText = ""
        curso_uno.Value = ""

        lb_curso_dos.InnerText = ""
        curso_dos.Value = ""


    End Sub

    Protected Sub btn_matricular_Click(sender As Object, e As EventArgs)

    End Sub

    Protected Sub btn_total_Click(sender As Object, e As EventArgs)

    End Sub
End Class