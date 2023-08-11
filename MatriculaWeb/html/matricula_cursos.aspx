<%@ Page Title="Matrícula Cursos" Language="vb" AutoEventWireup="false" MasterPageFile="~/PaginaMaestra.Master" CodeBehind="matricula_cursos.aspx.vb" Inherits="MatriculaWeb.Formulario_web1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     
    <section id="datos_estudiante">
        <h1>Ingresa todos los datos del curso</h1>

        <section id="datos_estudiante_uno">
            <div>
                <label class="lb_id_curso" for="input_id_curso">ID Curso</label>
                <input type="text" id="input_id_curso" runat="server" required="required" />
            </div>
            <div>
                <label for="input_nombre">Nombre</label>
                <input type="text" id="input_nombre" runat="server" required="required" />
            </div>
            <div>
                <label for="input_creditos">Créditos</label>
                <input type="text" id="input_creditos" runat="server" required="required" />
            </div>
        </section>

        <section id="cursos_dos" contenteditable="false" draggable="false">
            <div>
                <label for="input_nota">Nota mínima</label>
                <input type="text" id="input_nota" runat="server" required="required" />
            </div>

            <div>
                <label for="input_cant_min">Cantidad mínima</label>
                <input type="text" id="input_cant_min" runat="server" required="required" />
            </div>

            <div>
                <label for="input_cant_max">Cantidad máxima</label>
                <input type="text" runat="server" id="input_cant_max" required="required" />
            </div>

            <div>
                <label for="input_costo">Costo</label>
                <input type="text" runat="server" placeholder ="10000 colones por crédito" id="input_costo" enableviewstate="False"  />
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
                    
                   
                </select>
            </div>
            <div>
                <label for="select_cuatrimestre">Cuatrimestre</label>
                <select id="select_cuatrimestre" runat="server">
                    
                   
                </select>
            </div>
            <div>
                <label for="select_estado">Estado</label>
                <select id="select_estado" runat="server">
                    <option value="activo">Activo</option>
                    <option value="inactivo">Inactivo</option>
                </select>

            </div>
            <asp:Button ID="agrega_curso" runat="server" Text="Agregar" />
              <div>
                      <!--Cambios realizados-->
             <label for="input_Id_Borrar">Boton para eliminar fila </label>
                 <asp:Button ID="btn_Borrar" runat="server" Text="Borrar" />
                </div>
                  <div>
                      <!--Cambios realizados-->
             <label for="input_Id_Modificar">Boton para modifcar fila </label>
                 <asp:Button ID="btn_Modificar" runat="server" Text="Modifcar" />
                </div>
        </section>

    </section>

        <section id="taba_cursos">

<%--            <asp:Literal ID="LiteralTabla" runat="server"></asp:Literal>--%>
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
              <asp:GridView ID="gv_matricula_cursos"  class="gvtab" runat="server" AutoGenerateColumns="True" Enabled="True">
             </asp:GridView>
        </section>
      


</asp:Content>
