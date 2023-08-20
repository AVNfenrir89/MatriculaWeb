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

    <section class ="nota_funcionarios" >
        <div>
            <h3 class="titulo">Nota:  </h3>
            <p>Para la contraseña se debe de cumplir:</p>
            <p>La contraseña debe tener al entre 8 y 16 caracteres.</p>
            <p>Al menos un dígito.</p>
            <p>Al menos una minúscula.</p>
            <p>Al menos una mayúscula.</p>
            <p>Al menos un caracter no alfanumérico.</p>
            <p>Ejemplo: gbswq78410$Az</p>
        </div>

    </section>

    <section>
        <asp:GridView ID="gv_funcionario" class="gvtab" runat="server" AutoGenerateColumns="True" >
        </asp:GridView>
    </section>

    <h1 class="titulo_dos">Sección para editar o modificar un funcionario</h1>
    <section id="datos_estudiante">
        <section id="datos_estudiante_uno" class="seccion-uno">
            <h1>Ingresa el ID del Funcionario</h1>
            <input type="text" id="input_buscar" runat="server" />
            <asp:Button ID="btn_buscar" class="btn_matricular btn_funcionario" runat="server" Text="Buscar" OnClick="btn_buscar_Click" />
        </section>

        <section class="funcionarios_uno">

            <div>
                <label for="nombre_funcionario2">Nombre</label>
                <input type="text" id="nombre_funcionario2" runat="server" />
            </div>

            <div>
                <label for="pApellido_funcionario2">Primer Apelido</label>
                <input type="text" id="pApellido_funcionario2" runat="server" />
            </div>

            <div>
                <label for="sApellido_funcionario2">Segundo Apellido</label>
                <input type="text" id="sApellido_funcionario2" runat="server" />
            </div>

        </section>

        <section class="funcionarios_dos">

            <div>
                <label for="correo_funcionario2">Correo</label>
                <input type="email" id="correo_funcionario2" runat="server" />
            </div>

            <div>
                <label for="usuario_funcionario2">Usuario</label>
                <input type="text" id="usuario_funcionario2" runat="server" />
            </div>

            <div>
                <label for="pass_funcionario2">Contraseña</label>
                <input type="password" id="pass_funcionario2" runat="server" />
            </div>

            <div>
                <label for="estado_funcionario2">Estado</label>
                <select type="text" id="estado_funcionario2" runat="server">
                    <option value="activo">Activo</option>
                    <option value="inactivo">Inactivo</option>
                </select>
            </div>

        </section>

        <section id="datos_estudiante_cinco" class="botones_borrar_editar">

            <div>
                <!--Cambios realizados-->
                <label for="input_Id_Borrar">Boton para eliminar fila </label>
                <asp:Button ID="btn_Borrar" class="btn_matricular btn_funcionario btn_Borrar" runat="server" Text="Borrar" OnClick="btn_Borrar_Click" />
            </div>

            <div>
                <!--Cambios realizados-->
                <label for="input_Id_Modificar">Boton para modifcar fila </label>
                <asp:Button ID="btn_Modificar" class="btn_matricular btn_funcionario" runat="server" Text="Modifcar" OnClick="btn_Modificar_Click" />
            </div>

        </section>

    </section>

</asp:Content>
