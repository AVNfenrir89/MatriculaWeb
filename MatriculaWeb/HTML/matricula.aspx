<%@ Page Title="Matrícula" Language="vb" AutoEventWireup="false" MasterPageFile="~/PaginaMaestra.Master" CodeBehind="matricula.aspx.vb" Inherits="MatriculaWeb.Formulario_web12" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section id="datos_estudiante">
        <h1>Ingresa todos los datos de la matrícula</h1>

        <section class="matricula-uno">

            <div>
                <label for="select_estudiante">Selecionar ID del estudiante</label>
                <select id="select_estudiante" runat="server">
                </select>
            </div>

            <div>
                <label for="select_carrera">Selecionar carrera</label>
                <%--<select id="select_carrera" runat="server">
                </select>--%>
                <asp:DropDownList ID="select_carrera" runat="server" AutoPostBack="True"></asp:DropDownList>
            </div>

            <div>
                <label for="select_cuatrimestre">Selecionar cuatrimestre</label>
                <%--<select id="select_cuatrimestre" runat="server">
                    <option value="I">I</option>
                    <option value="II">II</option>
                    <option value="II">II</option>
                    <option value="IV">IV</option>
                </select>--%>
                <asp:DropDownList ID="select_cuatrimestre" runat="server" AutoPostBack="True">
                    <asp:ListItem>I</asp:ListItem>
                    <asp:ListItem>II</asp:ListItem>
                    <asp:ListItem>III</asp:ListItem>
                    <asp:ListItem>IV</asp:ListItem>
                </asp:DropDownList>

            </div>

        </section>

        <section class="matricula-dos">

            <section>
                <div>
                    <input type="checkbox" id="curso_uno" value="Curso" runat="server" />
                    <label id="lb_curso_uno" runat="server" for="curso_uno" text="">Curso</label>
                </div>

                <div>
                    <input type="checkbox" id="curso_dos" value="Curso" runat="server" />
                    <label id="lb_curso_dos" runat="server" for="curso_dos">Curso</label>
                </div>

                <div>
                    <input type="checkbox" id="curso_tres" value="Curso" runat="server" />
                    <label id="lb_curso_tres" runat="server" for="curso_tres">Curso</label>
                </div>
            </section>

            <section>

            </section>

        </section>

        <section class="matricula-tres">
            <asp:Button ID="btn_total" class="btn_matricular" runat="server" Text="Total" OnClick="btn_total_Click" />
            <label id ="lb_beca" runat="server"></label>
            <label id="lb_total" runat="server"></label>
            <asp:Button ID="btn_matricular" class="btn_matricular" runat="server" Text="Matricular" />
        </section>

    </section>



    <section>
        <asp:GridView ID="gv_matricular" class="gvtab" runat="server" AutoGenerateColumns="True" >
        </asp:GridView>
    </section>

    <h1 class="titulo_dos">Sección para editar o borrar una matrícula</h1>
    <section id="datos_estudiante">

        <section id="datos_estudiante_uno" class="seccion-uno">
            <h1>Ingresa el ID de la Matrícula</h1>
            <input type="text" id="input_buscar" runat="server" />
            <asp:Button ID="btn_buscar" class="btn_matricular btn_funcionario" runat="server" Text="Buscar" />
        </section>

        <section class="matricula-uno">
            <div>
                <label for="select_carrera2">Selecionar carrera</label>
                <select id="select_carrera2" runat="server">
                </select>
            </div>

            <div>
                <label for="label_cuatrimestre2">Selecionar cuatrimestre</label>
                <select id="label_cuatrimestre2" runat="server">
                    <option value="I">I</option>
                    <option value="II">II</option>
                    <option value="II">II</option>
                    <option value="IV">IV</option>
                </select>
            </div>
        </section>


        <section class="matricula-dos">

            <section>
                <div>
                    <input type="checkbox" id="curso_uno2" value="Curso" runat="server" />
                    <label id="lb_curso_uno2" runat="server" for="curso_uno2" text="">Curso</label>
                </div>

                <div>
                    <input type="checkbox" id="curso_dos2" value="Curso" runat="server" />
                    <label id="lb_curso_dos2" runat="server" for="curso_dos2">Curso</label>
                </div>

                <div>
                    <input type="checkbox" id="curso_tres2" value="Curso" runat="server" />
                    <label id="lb_curso_tres2" runat="server" for="curso_tres2">Curso</label>
                </div>
            </section>

            <section>
            </section>

        </section>

        <section id="datos_estudiante_cinco" class="botones_borrar_editar">
            <div>
                <!--Cambios realizados-->
                <label for="input_Id_Borrar">Boton para eliminar fila </label>
                <asp:Button ID="btn_Borrar" class="btn_matricular btn_funcionario btn_Borrar" runat="server" Text="Borrar" />
            </div>

            <div>
                <!--Cambios realizados-->
                <label for="input_Id_Modificar">Boton para modifcar fila </label>
                <asp:Button ID="btn_Modificar" class="btn_matricular btn_funcionario" runat="server" Text="Modifcar" />
            </div>
        </section>

    </section>

</asp:Content>
