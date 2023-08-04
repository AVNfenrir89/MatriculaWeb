<%@ Page Title="Matrícula Estudiante" Language="vb" AutoEventWireup="false" MasterPageFile="~/PaginaMaestra.Master" CodeBehind="matricula_estudiante.aspx.vb" Inherits="MatriculaWeb.Formulario_web11" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
          
    <section id="datos_estudiante">
        <h1>Ingresa todos los datos del estudiante</h1>

        <section id="datos_estudiante_uno">
            <div>
                <label class="lb_id_estudiante" for="input_id_estudiante">ID del estudiante</label>
                <input type="text" id="input_id_estudiante" runat="server" />
            </div>
            <div>
                <label for="input_nombre_est">Nombre</label>
                <input type="text" id="input_nombre_est" runat="server" />
            </div>
            <div>
                <label for="input_apellidos">Apellidos</label>
                <input type="text" id="input_apellidos" runat="server" />
            </div>
        </section>

        <section id="datos_estudiante_dos">

            <div>
                <label for="input_fecha">Fecha de Nacimiento</label>
                <input type="text" id="input_fecha" runat="server" />
            </div>

            <div>
                <label for="input_direccion">Dirección</label>
                <input type="text" id="input_direccion" runat="server" />
            </div>

            <div>
                <label for="input_telefono">Teléfono</label>
                <input type="text" runat="server" id="input_telefono" />
            </div>

        </section>

        <section id="datos_estudiante_tres">
            <div>
                <label for="input_correo" runat="server">Correo electronico</label>
                <input type="email" id="input_correo" runat="server" placeholder="email@example.com" />
            </div>

            <div>
                <label for="select_carrera">Carrera</label>
                <select id="select_carrera" runat="server">

                </select>
            </div>
        </section>

        <section id="datos_estudiante_cuatro">
            <p>Beca</p>
            <label for="beca_si">Sí</label>
            <input id="beca_si" runat="server" name="beca" type="radio" value="si" />
            <label for="select_beca"></label>

            <select id="select_beca" runat="server" enable="false" disabled="disabled">
                <option value="25">25</option>
                <option value="50">50</option>
                <option value="75">75</option>
            </select>

            <label for="beca_no">No</label>
            <input id="beca_no" runat="server" name="beca" type="radio" value="no" />
        </section>

        <asp:Button ID="btn_Agregar_estudiante" runat="server" Text="Agregar" />

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
        <asp:GridView ID="gv_matricula_estudiantes" class="gvtab" runat="server" AutoGenerateColumns="True" Enabled="True" AutoGenerateEditButton="True" AutoGenerateSelectButton="True">
        </asp:GridView>
    </section>

</asp:Content>
