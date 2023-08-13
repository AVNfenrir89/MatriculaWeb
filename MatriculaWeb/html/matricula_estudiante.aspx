<%@ Page Title="Matrícula Estudiante" Language="vb" AutoEventWireup="false" MasterPageFile="~/PaginaMaestra.Master" CodeBehind="matricula_estudiante.aspx.vb" Inherits="MatriculaWeb.Formulario_web11" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

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
                    <%--       <input id="beca_si" runat="server" name="beca" type="radio" value="si" />--%>
                    <asp:RadioButton ID="beca_si" runat="server" value="si" name="beca" OnCheckedChanged="beca_si_CheckedChanged" AutoPostBack="True" />
                    <label for="select_beca"></label>
                    <select id="select_beca" runat="server">
                        <option value="25">25</option>
                        <option value="50">50</option>
                        <option value="75">75</option>
                    </select>

                    <label for="beca_no">No</label>
                    <asp:RadioButton ID="beca_no" runat="server" value="no" name="beca" AutoPostBack="True" OnCheckedChanged="beca_no_CheckedChanged" />
                    <%--   <input id="beca_no" runat="server" name="beca" type="radio" value="no" />--%>
                </section>

                <section id="datos_estudiante_cinco">

                    <asp:Button ID="btn_Agregar_estudiante" class="btn_matricular btn_funcionario" runat="server" Text="Agregar" />

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
                <asp:GridView ID="gv_matricula_estudiantes" class="gvtab" runat="server" AutoGenerateColumns="True" Enabled="True">
                </asp:GridView>
            </section>

            <h1 class="titulo_dos">Sección para editar o modificar un estudiante</h1>

            <section id="datos_estudiante">

                <section id="datos_estudiante_uno" class="seccion-uno">
                    <h1>Ingresa el ID de estudiante</h1>
                    <input type="text" id="input_buscar" runat="server" />
                    <asp:Button ID="btn_buscar" class="btn_matricular btn_funcionario" runat="server" Text="Buscar" OnClick="btn_buscar_Click" />
                </section>

                <section id="datos_estudiante_uno">

                    <div>
                        <label for="input_nombre_est2">Nombre</label>
                        <input type="text" id="input_nombre_est2" runat="server" />
                    </div>
                    <div>
                        <label for="input_apellidos2">Apellidos</label>
                        <input type="text" id="input_apellidos2" runat="server" />
                    </div>

                    <div>
                        <label for="input_fecha2">Fecha de Nacimiento</label>
                        <input type="text" id="input_fecha2" runat="server" />
                    </div>

                </section>

                <section id="datos_estudiante_dos">
                    <div>
                        <label for="input_direccion2">Dirección</label>
                        <input type="text" id="input_direccion2" runat="server" />
                    </div>

                    <div>
                        <label for="input_telefono2">Teléfono</label>
                        <input type="text" runat="server" id="input_telefono2" />
                    </div>
                    <div>
                        <label for="input_correo2" runat="server">Correo electronico</label>
                        <input type="email" id="input_correo2" runat="server" placeholder="email@example.com" />
                    </div>
                </section>

                <section id="datos_estudiante_tres" class="seccion-uno">
                    <div>
                        <label for="select_carrera2">Carrera</label>
                        <select id="select_carrera2" class="select-carrera" runat="server">
                        </select>
                    </div>

                    <div id="datos_estudiante_cuatro" class="seccion-uno">
                        <p>Beca</p>
                        <label for="beca_si2">Sí</label>
                        <asp:RadioButton ID="beca_si2" runat="server" value="si" name="beca" AutoPostBack="True" OnCheckedChanged="beca_si2_CheckedChanged"  />

                        <select id="select_beca2" runat="server" enable="false" disabled="disabled">
                            <option value="25">25</option>
                            <option value="50">50</option>
                            <option value="75">75</option>
                        </select>

                        <label for="beca_no2">No</label>
                        <asp:RadioButton ID="beca_no2" runat="server" value="no" name="beca" AutoPostBack="True" OnCheckedChanged="beca_no2_CheckedChanged" />
                    </div>
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
                        <asp:Button ID="btn_Modificar" class="btn_matricular btn_funcionario" runat="server" Text="Modifcar"  />
                    </div>
                </section>

            </section>

        </ContentTemplate>

    </asp:UpdatePanel> 


</asp:Content>
