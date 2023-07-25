Public Class matricula
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub



    Protected Sub agregar_curso_Click(sender As Object, e As EventArgs)



        'Dim tabla As HtmlGenericControl = DirectCast(FindControl("datos_tabla_cursos"), HtmlGenericControl)
        'Dim filaHtml As String = "<tr><td>" & input_nombre.Value & "</td></tr>"
        'tabla.InnerHtml &= filaHtml
        'Dim fila As New HtmlTableRow()
        'Dim id_curso As New HtmlTableCell
        'Dim nombre As New HtmlTableCell()
        'Dim creditos As New HtmlTableCell
        'Dim nota_min As New HtmlTableCell
        'Dim cant_min As New HtmlTableCell
        'Dim cant_max As New HtmlTableCell
        'Dim costo As New HtmlTableCell
        'Dim grado As New HtmlTableCell
        'Dim carrera As New HtmlTableCell
        'Dim estado As New HtmlTableCell

        'id_curso.InnerText = input_id_curso.Value
        'nombre.InnerText = input_nombre.Value
        'creditos.InnerText = input_creditos.Value
        'nota_min.InnerText = input_nota.Value
        'cant_min.InnerText = input_cant_min.Value
        'cant_max.InnerText = Input_cant_max.Value
        'costo.InnerText = input_costo.Value
        'grado.InnerText = select_grado.Value
        'carrera.InnerText = select_carrera.Value
        'estado.InnerText = select_estado.Value

        'fila.Cells.Add(id_curso)
        'fila.Cells.Add(nombre)
        'fila.Cells.Add(creditos)
        'fila.Cells.Add(nota_min)
        'fila.Cells.Add(cant_min)
        'fila.Cells.Add(cant_max)
        'fila.Cells.Add(costo)
        'fila.Cells.Add(grado)
        'fila.Cells.Add(carrera)
        'fila.Cells.Add(estado)
        'tabla.Rows.Add(fila)

        'Dim strLista As New System.Text.StringBuilder()
        'With strLista
        '    .Append("<td id=""txtCcuenta"" scope = ""row"" >")
        '    .Append("<tr>")
        '    .Append(input_nombre.Value)
        '    .Append("</td>")
        '    .Append("</tr>")
        'End With
        'Dim no As HtmlTableRow


        'datos_tabla_cursos.Rows.Add(no)
        Dim tablaHtml As String = CType(Session("TablaHtml"), String)
        Dim filaHtml As String = "<tr ><td>" & input_id_curso.Value & "</td> <td>" & input_nombre.Value & "</td>    <td>" & input_creditos.Value & "</td>  <td>" & input_nota.Value & "</td> <td>" & input_cant_min.Value & "</td> <td>" & input_cant_max.Value & "</td> <td>" & input_costo.Value & "</td> <td>" & select_grado.Value & "</td><td>" & select_carrera.Value & "</td> <td>" & select_estado.Value & "</td>   <td>  <button>Borrar</buttom> <button>Editar</buttom> </td>  <tr>"
        tablaHtml &= filaHtml

        Session("TablaHtml") = tablaHtml

        'LiteralTabla.Text = "<table class =""sub_datos_tabla_cursos"">" & tablaHtml & "</table>"
        LiteralTabla.Text = "<table id =""datos_tabla_cursos""> <tr><th>ID del curso</th><th>Nombre</th> <th>Créditos</th><th>Nota mínima</th><th>Cantidad mínima</th> <th>Cantidad máxima</th> <th>Costo</th> <th>Grado</th> <th>Carrera</th> <th>Estado</th> <th>Modificar</th>    </tr> " & tablaHtml & " </table>"

    End Sub
End Class