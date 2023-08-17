<%@ Page Title="Acerca de" Language="vb" AutoEventWireup="false" MasterPageFile="~/PaginaMaestra.Master" CodeBehind="acerca_de.aspx.vb" Inherits="MatriculaWeb.Formulario_web14" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <main class="main-acercade">
        <h2 class ="titulo">Elaborado por:</h2>
        <section class ="seccion_foto_perfil">

            <div class ="divicion_foto_perfil">
               <img class="fotoPerfil" src="../images/tamara.jpg"/>
            </div>

            <div class ="seccion_info">
                <h3 class ="titulo">Tamara Chávez Monje</h3>
                 <h4 class ="titulo">Contacto: tamara33chavez@gmail.com </h4>
            </div>
        </section>

        <section class ="seccion_foto_perfil">
            <div class ="divicion_foto_perfil">
                 <img class="fotoPerfil" src="../images/andrey.jpg"/>
            </div>
            <div class ="seccion_info">
                <h3 class ="titulo">Andrey Villalobos Navarro</h3>
                <h4 class ="titulo">Contacto: anvillalobosna@hotmail.com </h4>
            </div>

        </section>

        <section class=" seccion_cuc">
            <img class="foto_cuc" src="../images/cuc.png"/>
            <p class ="titulo">Tecnologías de Informacíon</p>
            <p class ="titulo">Programación II</p>
            <p class ="titulo">II Cuatrimestre 2023</p>
        </section>


    </main>

</asp:Content>
