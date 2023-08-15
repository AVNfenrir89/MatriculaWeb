<%@ Page Title="Matrícula Cursos" Language="vb" AutoEventWireup="false" MasterPageFile="~/PaginaMaestra.Master" CodeBehind="matricula_cursos.aspx.vb" Inherits="MatriculaWeb.Formulario_web1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

            <section id="datos_estudiante">

                <h1>Ingresa todos los datos del curso</h1>

                <section id="datos_estudiante_uno">

                    <div>
                        <label class="lb_id_curso" for="input_id_curso">ID Curso</label>
                        <input type="text" id="input_id_curso" runat="server" />
                    </div>

                    <div>
                        <label for="input_nombre">Nombre</label>
                        <input type="text" id="input_nombre" runat="server"  />
                    </div>

                    <div>
                        <label for="input_creditos">Créditos</label>
                        <input type="text" id="input_creditos" runat="server"  />
                    </div>

                    <div>
                        <label for="label_cuatrimestre">Selecionar cuatrimestre</label>
                        <select id="label_cuatrimestre" runat="server">
                            <option value="I">I</option>
                            <option value="II">II</option>
                            <option value="III">III</option>
                            <option value="IV">IV</option>
                        </select>
                    </div>

                </section>

                <section id="cursos_dos" contenteditable="false" draggable="false">

                    <div>
                        <label for="input_nota">Nota mínima</label>
                        <input type="text" id="input_nota" runat="server" />
                    </div>

                    <div>
                        <label for="input_cant_min">Cantidad mínima</label>
                        <input type="text" id="input_cant_min" runat="server"  />
                    </div>

                    <div>
                        <label for="input_cant_max">Cantidad máxima</label>
                        <input type="text" runat="server" id="input_cant_max"  />
                    </div>

                    <div>
                        <label for="input_costo">Costo</label>
                        <input type="text" runat="server" placeholder="10000 colones por crédito" id="input_costo" enableviewstate="False" />
                    </div>

                </section>

                <section id="datos_cursos_tres">
                    <%--select grado--%>
                    <div>
                        <label for="select_grado">Grado</label>
                        <select id="select_grado" runat="server">
                            <option value="BACH">Bachillerato</option>
                            <option value="LIC">Licienciatura</option>
                        </select>
                    </div>

                    <%-- select carrera--%>
                    <div>
                        <label for="select_carrera">Carrera</label>
                        <select id="select_carrera" runat="server">
                        </select>
                    </div>

                    <%--select estado--%>
                    <div>
                        <label for="select_estado">Estado</label>
                        <select id="select_estado" runat="server">
                            <option value="activo">Activo</option>
                            <option value="inactivo">Inactivo</option>
                        </select>

                    </div>

                    <asp:Button ID="agrega_curso" class="btn_matricular btn_funcionario" runat="server" Text="Agregar" />

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
                <asp:GridView ID="gv_matricula_cursos" class="gvtab" runat="server" AutoGenerateColumns="True" Enabled="True">
                </asp:GridView>
            </section>

            <h1 class="titulo_dos">Sección para editar o modificar un Curso</h1>

            <section id="datos_estudiante">

                    <section id="datos_estudiante_uno" class="seccion-uno">
                        <h1>Ingresa el ID del Curso</h1>
                        <input type="text" id="input_buscar" runat="server" />
                        <asp:Button ID="btn_buscar" class="btn_matricular btn_funcionario" runat="server" Text="Buscar" OnClick="btn_buscar_Click" />
                    </section>

                    <section id="datos_estudiante_uno">

                        <div>
                            <label for="input_nombre2">Nombre</label>
                            <input type="text" id="input_nombre2" runat="server" />
                        </div>

                        <div>
                            <label for="input_creditos2">Créditos</label>
                            <input type="text" id="input_creditos2" runat="server" />
                        </div>

              

                        <div id="select_cuatrimestre2">
                            <label for="select_cuatrimestre_2">Selecionar cuatrimestre</label>
                            <select id="select_cuatrimestre_2" runat="server">
                                <option value="I">I</option>
                                <option value="II">II</option>
                                <option value="III">III</option>
                                <option value="IV">IV</option>
                            </select>
                            </div>

                    </section>

                    <section id="cursos_dos" contenteditable="false" draggable="false">
                    <div>
                        <label for="input_nota2">Nota mínima</label>
                        <input type="text" id="input_nota2" runat="server" />
                    </div>

                    <div>
                        <label for="input_cant_min2">Cantidad mínima</label>
                        <input type="text" id="input_cant_min2" runat="server" />
                    </div>

                    <div>
                        <label for="input_cant_max2">Cantidad máxima</label>
                        <input type="text" runat="server" id="input_cant_max2" />
                    </div>
                </section>    
                
                    <section id="datos_estudiante_tres" class="cursos_selects" >

                       <%-- selects--%>
                        <div>
                            <label for="select_grado2">Grado</label>
                            <select id="select_grado2" runat="server">
                                <option value="BACH">Bachillerato</option>
                                <option value="LIC">Licienciatura</option>
                            </select>
                        </div>

                        <div>
                            <label for="select_carrera2">Carrera</label>
                            <select id="select_carrera2" runat="server">
                            </select>
                        </div>

                        <div>

                            <label for="select_estado2">Estado</label>
                            <select id="select_estado2" runat="server">
                                <option value="activo">Activo</option>
                                <option value="inactivo">Inactivo</option>
                            </select >

                        </div>

                    </section>

                    <section id="datos_estudiante_cinco" class="botones_borrar_editar">

                       <%-- botón eliminar--%>
                        <div>
                            <!--Cambios realizados-->
                            <label for="input_Id_Borrar">Boton para eliminar fila </label>
                            <asp:Button ID="btn_Borrar" class="btn_matricular btn_funcionario btn_Borrar" runat="server" Text="Borrar" />
                        </div>

                       <%-- botón modificar--%>
                        <div>
                            <!--Cambios realizados-->
                            <label for="input_Id_Modificar">Boton para modifcar fila </label>
                            <asp:Button ID="btn_Modificar" class="btn_matricular btn_funcionario" runat="server" Text="Modifcar" />
                        </div>

                    </section>
                      
            </section>

        </ContentTemplate>
    </asp:UpdatePanel> 

</asp:Content>
