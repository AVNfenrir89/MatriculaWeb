<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="matricula_cursos.aspx.vb" Inherits="MatriculaWeb.matricula" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="~/CSS/styles.css" />
    <title></title>
</head>

<body>
    <nav id="nav_principal">
        <ul id="lista">
            <li><a href="Carreras.aspx">Registro Carrera</a></li>
            <li><a href="matricula_cursos.aspx">Registro cursos</a></li>
            <li><a href="matricula_estudiante.aspx">Registro Estudiante</a></li>
            <li><a href="matricula.aspx">Matricular</a></li>
            <li><a href="consulta_cursos.aspx">Consulatar Cursos</a></li>
            <li><a href="consulta_matricula.aspx">Consultar Matrículas</a></li>
            <li><a href="funcionarios.aspx">Funcionarios</a></li>
            <li><a href="acerca_de.aspx">Acerca De</a></li>
        </ul>
    </nav>
    <form id="form_cursos" runat="server">
        <section id="datos_estudiante">
            <h1>Ingresa todos los datos del curso</h1>

            <section id="datos_estudiante_uno">
                <div>
                    <label class="lb_id_curso" for="input_id_curso">ID Curso</label>
                    <input type="text" id="input_id_curso" runat="server" />
                </div>
                <div>
                    <label for="input_nombre">Nombre</label>
                    <input type="text" id="input_nombre" runat="server" />
                </div>
                <div>
                    <label for="input_creditos">Créditos</label>
                    <input type="text" id="input_creditos" runat="server" />
                </div>
            </section>

            <section id="cursos_dos">
                <div>
                    <label for="input_nota">Nota mínima</label>
                    <input type="text" id="input_nota" runat="server" />
                </div>

                <div>
                    <label for="input_cant_min">Cantidad mínima</label>
                    <input type="text" id="input_cant_min" runat="server" />
                </div>

                <div>
                    <label for="input_cant_max">Cantidad máxima</label>
                    <input type="text" runat="server" id="input_cant_max" />
                </div>

                <div>
                    <label for="input_costo">Costo</label>
                    <input type="text" runat="server" id="input_costo" />
                </div>
            </section>

            <section id="datos_cursos_tres">
                <div>
                    <label for="select_grado">Grado</label>
                    <select id="select_grado" runat="server">
                        <option value="BACH">Bachillerato</option>
                        <option value="LIC">Licienciatura</option>
                    </select>
                </div>

                <div>
                    <label for="select_carrera">Carrera</label>
                    <select id="select_carrera" runat="server">
                        <option value="TID">carrera1</option>
                    </select>
                </div>

                <div>
                    <label for="select_estado">Estado</label>
                    <select id="select_estado" runat="server">
                        <option value="activo">Activo</option>
                        <option value="inactivo">Inactivo</option>
                    </select>
                </div>


            </section>
            <asp:Button ID="agregar_curso" runat="server" Text="Agregar" OnClick="agregar_curso_Click" />
        </section>

        <section id="taba_cursos">
            <asp:Literal ID="LiteralTabla" runat="server"></asp:Literal>
<%--             <table id ="datos_tabla_cursos" runat="server">       
                    <tr>
                        <th>ID del curso</th>
                        <th>Nombre</th>
                        <th>Créditos</th>
                        <th>Nota mínima</th>
                        <th>Cantidad mínima</th>
                        <th>Cantidad máxima</th>
                        <th>Costo</th>
                        <th>Grado</th>
                        <th>Carrera</th>
                        <th>Estado</th>
                    </tr>
            </table>--%>
        </section>
    </form>
</body>
</html>

