<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/PaginaMaestra.Master" CodeBehind="cerrar.aspx.vb" Inherits="MatriculaWeb.Formulario_web18" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Login ID="Login1" runat="server" OnAuthenticate="Login1_Authenticate">
        <LayoutTemplate>
            <main class="mainLogin">
                <h1>Bienvenido al sistema de matrícula</h1>
                <p>Inicia sesión</p>

                <div class="data-form">
                    <label for="input_idFuncioanrio" class="labelLogin">ID Funcionario</label>
                    <input type="text" placeholder="123456789" runat="server" id="input_idFuncioanrio" class="idFuncionario-form form-login" required="required" />
                </div>

                <div class="data-form">
                    <label for="input_nombre" class="labelLogin">Nombre</label>
                    <input type="text" id="input_nombre" runat="server" class="nombre-form form-login" required="required" />
                </div>

                <div class="data-form">
                    <label for="input_pApellido" class="labelLogin">Primer Apellido</label>
                    <input type="text" id="input_pApellido" runat="server" class="pApellido-form form-login" required="required" />
                </div>

                <div class="data-form">
                    <label for="input_sApellido" class="labelLogin">Segundo Apellido</label>
                    <input type="text" id="input_sApellido" runat="server" class="sApellido-form form-login" required="required" />
                </div>

                <div class="data-form">
                    <label for="input_correo" class="labelLogin">Email</label>
                    <input type="text" placeholder="example@email" id="input_correo" runat="server" class="form-email form-login" required="required" />
                </div>

                <div class="data-form">
                    <label for="input_usuario" class="labelLogin">Usuario</label>
                    <input type="text" id="input_usuario" runat="server" class="usuario-form form-login" required="required" />
                </div>

                <div class="data-form">
                    <label for="input_contrasena" class="labelLogin">Contraseña</label>
                    <input type="password" runat="server" id="input_contrasena" class="usuario-form form-login" required="required" />
                </div>
               <asp:Button runat="server" CommandName="Login" Text="Inicio de sesi&#243;n" ValidationGroup="Login1" ID="LoginButton"></asp:Button>
            </main>
  
        </LayoutTemplate>
    </asp:Login>
</asp:Content>
