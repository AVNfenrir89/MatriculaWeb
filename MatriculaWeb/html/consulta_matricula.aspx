<%@ Page Title="Consulta Matrícula" Language="vb" AutoEventWireup="false" MasterPageFile="~/PaginaMaestra.Master" CodeBehind="consulta_matricula.aspx.vb" Inherits="MatriculaWeb.Formulario_web17" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="titulo_dos">Datos de las todas las matrículas</h1>
    <asp:GridView ID="gv_matricula" class="gvtab" runat="server" AutoGenerateColumns="True" Enabled="True"></asp:GridView>
</asp:Content>
