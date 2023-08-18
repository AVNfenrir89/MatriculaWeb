<%@ Page Title="Consulta Cursos" Language="vb" AutoEventWireup="false" MasterPageFile="~/PaginaMaestra.Master" CodeBehind="consulta_cursos.aspx.vb" Inherits="MatriculaWeb.Formulario_web16" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <h1 class="titulo_dos">Datos de todos los cursos</h1>
    <asp:GridView ID="gv_matricula_cursos" class="gvtab" runat="server" AutoGenerateColumns="True" Enabled="True"></asp:GridView>
</asp:Content>
