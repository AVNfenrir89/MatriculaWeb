<%@ Page Title="Funcionarios" Language="vb" AutoEventWireup="false" MasterPageFile="~/PaginaMaestra.Master" CodeBehind="funcionarios.aspx.vb" Inherits="MatriculaWeb.Formulario_web13" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section id="datos_estudiante">
         <h1>Ingresa todos los datos del funcionario</h1>
        <section class="funcionarios_uno">
            
            <div>
                <label for="id_funcionario">Cédula</label>
                <input type="text" id="id_funcionario" runat="server" />
            </div>

            <div>
                <label for="nombre_funcionario">Nombre</label>
                <input type="text" id="nombre_funcionario" runat="server" />
            </div>

            <div>
                <label for="pApellido_funcionario">Primer Apelido</label>
                <input type="text" id="pApellido_funcionario" runat="server" />
            </div>

            <div>
                <label for="sApellido_funcionario">Segundo Apellido</label>
                <input type="text" id="sApellido_funcionario" runat="server" />
            </div>

        </section>

        <section class="funcionarios_dos">

            <div>
                <label for="correo_funcionario">Correo</label>
                <input type="email" id="correo_funcionario" runat="server" />
            </div>

            <div>
                <label for="usuario_funcionario">Usuario</label>
                <input type="text" id="usuario_funcionario" runat="server" />
            </div>

            <div>
                <label for="pass_funcionario">Contraseña</label>
                <input type="password" id="pass_funcionario" runat="server" />
            </div>

            <div>
                <label for="estado_funcionario">Estado</label>
                <select type="text" id="estado_funcionario" runat="server">
                    <option value="activo">Activo</option>
                    <option value="inactivo">Inactivo</option>
                </select>
            </div>

        </section>

        <asp:Button ID="btn_agregar" class="btn_matricular btn_funcionario" runat="server" Text="Agregar" OnClick="btn_agregar_Click" />

    </section>

    <section>
        <asp:GridView ID="gv_funcionario" class="gvtab" runat="server" AutoGenerateColumns="True" >
        </asp:GridView>
    </section>

</asp:Content>
