<%@ Page Title="Matrícula" Language="vb" AutoEventWireup="false" MasterPageFile="~/PaginaMaestra.Master" CodeBehind="matricula.aspx.vb" Inherits="MatriculaWeb.Formulario_web12" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section id="datos_estudiante">
        <h1>Ingresa todos los datos de la matrícula</h1>

        <section class="matricula-uno">

            <div>
                <label for="select_estudiante">Selecionar ID del estudiante</label>
                <select id="select_estudiante">
                    <asp:Literal ID="lt_estudiante" runat="server"></asp:Literal>
                </select>
            </div>

            <div>
                <label for="select-carrera">Selecionar carrera</label>
                <select id="select-carrera">
                    <asp:Literal ID="lt_carrera" runat="server"></asp:Literal>
                </select>
            </div>

            <div>
                <label for="label_cuatrimestre">Selecionar cuatrimestre</label>
                <select id="label_cuatrimestre" runat="server">
                    <option value="I">I</option>
                    <option value="II">II</option>
                    <option value="II">II</option>
                    <option value="IV">IV</option>
                </select>
            </div>

            <asp:Button ID="btn_mostrar" class="btn_mostrar" runat="server" Text="Mostrar Cursos" OnClick="btn_mostrar_Click" />

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

                <div>                   
                    <input type="checkbox" id="curso_cuatro" value="Curso" runat="server" />
                    <label id="lb_curso_cuatro" runat="server" for="curso_cuatro" text="">Curso</label>
                </div>

                <div>                  
                    <input type="checkbox" id="curso_cinco" value="Curso" runat="server" />
                    <label id="lb_curso_cinco" runat="server" for="curso_cinco">Curso</label>
                </div>

                <div>                 
                    <input type="checkbox" id="curso_seis" value="Curso" runat="server" />
                    <label id="lb_curso_seis" runat="server" for="curso_seis">Curso</label>
                </div>
            </section>


        </section>

        <section class ="matricula-tres">
            <label id="lb_total" runat="server">Total: </label>
            <asp:Button ID="btn_matricular" class="btn_matricular"  runat="server" Text="Matricular" OnClick="btn_matricular_Click" />
        </section>

    </section>



    <section>
        <asp:GridView ID="gv_matricula_estudiantes" class="gvtab" runat="server" AutoGenerateColumns="True" Enabled="True" AutoGenerateEditButton="True" AutoGenerateSelectButton="True">
        </asp:GridView>
    </section>

</asp:Content>
