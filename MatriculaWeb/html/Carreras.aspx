<%@ Page Title="Registro Carreras" Language="vb" AutoEventWireup="false" MasterPageFile="~/PaginaMaestra.Master" CodeBehind="Carreras.aspx.vb" Inherits="MatriculaWeb.Formulario_web15" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
         <asp:UpdatePanel ID="UpdatePanel1" runat="server">
         <ContentTemplate>

             <section id="datos_estudiante">
                 <h1>Ingresa todos los datos de la carrera</h1>
                 <section id="datos_estudiante_uno">
                     <div>
                         <label class="lb_id_estudiante" for="input_id_carrera">ID Carrera</label>
                         <input type="text" id="input_id_carrera" runat="server" />
                     </div>
                     <div>
                         <label for="input_nombre_carrera">Nombre de la carrera</label>
                         <input type="text" id="input_nombre_carrera" runat="server" />
                     </div>
                 </section>
                 <section id="datos_estudiante_uno">
                     <div>
                         <label for="select_grado">Grado</label>
                         <select id="select_grado" runat="server">
                             <option value="BACH">Bachillerato</option>
                             <option value="LIC">Licienciatura</option>
                         </select>
                     </div>
                     <div>
                         <label for="select_estado">Estado</label>
                         <select id="select_estado" runat="server">
                             <option value="activo">Activo</option>
                             <option value="inactivo">Inactivo</option>
                         </select>
                        
                     </div>

                      <asp:Button ID="agregar" runat="server" class="btn_matricular btn_funcionario" Text ="Agregar" />
                 </section>



             </section>

            <asp:GridView ID="gv_carreras" class="gvtab" runat="server" AutoGenerateColumns="True" Enabled="True"></asp:GridView>


             <h1 class="titulo_dos">Sección para editar o modificar una carrera</h1>
             <section id="datos_estudiante">
                 <section id="datos_estudiante_uno" class="seccion-uno">
                     >
                     <h1>Ingresa el ID de la carrera</h1>
                     <div>
                         </label>
                         <input type="text" id="input_id_carrera2" runat="server" />
                         <asp:Button ID="btn_buscar" class="btn_matricular btn_funcionario" runat="server" Text="Buscar" OnClick="btn_buscar_Click" />
                     </div>

                 </section>
                 <section id="datos_estudiante_uno">
                     <div>
                         <label for="input_nombre_carrera2">Nombre de la carrera</label>
                         <input type="text" id="input_nombre_carrera2" runat="server" />
                     </div>

                     <div>
                         <label for="select_grado">Grado</label>
                         <select id="select1" runat="server">
                             <option value="BACH">Bachillerato</option>
                             <option value="LIC">Licienciatura</option>
                         </select>
                     </div>
                     <div>
                         <label for="select_estado">Estado</label>
                         <select id="select2" runat="server">
                             <option value="activo">Activo</option>
                             <option value="inactivo">Inactivo</option>
                         </select>

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
                         <asp:Button ID="btn_Modificar" class="btn_matricular btn_funcionario" runat="server" Text="Modifcar" />
                     </div>
                 </section>

             </section>
               
        </ContentTemplate>
         </asp:UpdatePanel>    
</asp:Content>
