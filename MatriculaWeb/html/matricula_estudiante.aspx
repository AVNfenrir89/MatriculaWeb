<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="matricula_estudiante.aspx.vb" Inherits="MatriculaWeb.matricula_estudiante" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
<link rel="stylesheet" href="~/CSS/styles.css"/>
</head>

<body>
   <nav id ="nav_principal">
      <ul id ="lista" >
            <li ><a href="Carreras.aspx"  >Registro Carrera</a></li>
            <li ><a href="matricula_cursos.aspx" >Registro cursos</a></li>
            <li ><a href="matricula_estudiante.aspx" >Registro Estudiante</a></li>
            <li ><a href="matricula.aspx" >Matricular</a></li>
            <li ><a href="consulta_cursos.aspx" >Consulatar Cursos</a></li>
            <li ><a href="consulta_matricula.aspx" >Consultar Matrículas</a></li>
            <li ><a href ="funcionarios.aspx">Funcionarios</a></li>
            <li><a  href="acerca_de.aspx" >Acerca De</a></li>
        </ul>
    </nav>

     <form id="form_estudiantes" runat="server" enableviewstate="False">

         
         <section id ="datos_estudiante">
             <h1>Ingresa todos los datos del estudiante</h1>

             <section id ="datos_estudiante_uno">  
                 <div>
                     <label for="input_id">ID del estudiante</label>
                     <input type="text" id="input_id" runat="server" />
                 </div>
                <div>
                    <label for ="input_nombre">Nombre</label>
                    <input  type="text" id="input_nombre" runat="server"/>
                </div>
                <div>
                    <label for ="input_apellidos">Apellidos</label>
                    <input  type="text" id="input_apellidos" runat="server"/>
                </div>
             </section>

             <section id ="datos_estudiante_dos">

                <div>
                    <label for="input_fecha">Fecha de Nacimiento</label>
                    <input  type="text" id="input_fecha" runat="server"/>
                </div>

                <div>
                    <label for ="input_direccion">Dirección</label>
                    <input  type="text" id="input_direccion" runat="server"/>
                </div>

                <div>
                    <label for ="input_telefono">Teléfono</label>
                    <input  type="text" runat="server" id="input_telefono" />
                </div>

             </section> 
             <section id="datos_estudiante_tres">
                  <div>
                    <label for ="input_correo" runat="server">Correo electronico</label>
                    <input  type="email" id="input_correo" runat="server" placeholder="email@example.com"/>
                  </div>

                  <div>
                    <label for ="select_carrera" >Carrera</label>
                        <select id ="select_carrera" runat="server">
                            <option value="carrera1">carrera1</option>
                        </select>
                   </div>
             </section>

             <section id ="datos_estudiante_cuatro">
                 </p>
                 <label for="beca_si">Beca Sí</label>
                 <input id="beca_si" runat="server" name="beca" type="radio" value="si" />

                 <label for="select_beca"></label>
                 <select id="select_beca" runat="server" enable="false" disabled="disabled">
                     <option value="25">25</option>
                     <option value="50">50</option>
                     <option value="75">75</option>
                 </select>

                 <label for="beca_no">No</label>
                 <input id="beca_no" runat="server" name="beca" type="radio" value="no" />
             </section>

         </section>
    </form>

</body>
</html>
