<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="login.aspx.vb" Inherits="MatriculaWeb.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
        <head runat="server">
            <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
            <link rel="stylesheet" href="~/CSS/styles.css" />
            <title>Inicia Sesión</title>
        </head>
        <body class ="bodyLogin">
                    <form id="formlogin" runat="server">
                                <h1>Bienvenido al Sistema de Matrícula</h1>
                                <main class="mainLogin">
                                            <h2>Inicia sesión</h2>
                                            <div class="data-form">
                                                <label for="input_usuario" class="labelLogin">Usuario</label>
                                                <input type="text" id="input_usuario" runat="server" class="usuario-form form-login" required="required" />
                                            </div>
                                            <div class="data-form">
                                                <label for="input_contrasena" class="labelLogin">Contraseña</label>
                                                <input type="password" runat="server" id="input_contrasena" class="usuario-form form-login" required="required" />
                                            </div>
                                            <asp:Button ID="btn_IniciarSesion" class="btn_login" runat="server" Text="Iniciar Sesión" OnClick="btn_IniciarSesion_Click" />
                                </main>
                    </form>
        </body>
</html>
