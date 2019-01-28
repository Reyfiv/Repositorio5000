
<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="rUsuarios.aspx.cs" Inherits="Registro5000.Registro.rUsuarios" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="panel" style="background-color: cornflowerblue">
        <div class="panel-heading" style="font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; font-size: x-large; color: aliceblue">Registro de Usuarios</div>

    </div>

    <div class="panel-body">
        <div class="form-horizontal col-md-12" role="form">

            <%--UsuarioId--%>
            <div class="form-group">
                <label for="UsuarioIdTextBox" class="col-md-3 control-label input-sm" style="font-size: medium">UsuarioId</label>
                <div class="col-md-1 col-sm-2 col-xs-4">
                    <asp:TextBox ID="UsuarioIdTextBox" runat="server" placeholder="0" class="form-control input-sm" Style="font-size: medium" TextMode="Number"></asp:TextBox>                  
                </div>
                 <asp:RegularExpressionValidator ID="ValidaID" runat="server" ErrorMessage='Campo "UsuarioId" solo acepta numeros' ControlToValidate="UsuarioIdTextBox" ValidationExpression="^[0-9]*" Text="*" ForeColor="Red" Display="Dynamic" ToolTip="Entrada no valida" ValidationGroup="Guardar"></asp:RegularExpressionValidator>
                <div class="col-md-1 col-sm-2 col-xs-4">
                    <asp:Button ID="BuscarButton" runat="server" Text="Buscar" class="btn btn-info btn-md" OnClick="BuscarButton_Click1" />
                </div>
            </div>
            <%--hasta aqui--%>
            <%--Nombres--%>
            <div class="form-group">
                <label for="NombresTextBox" class="col-md-3 control-label input-sm" style="font-size: medium">Nombres</label>
                <div class="col-md-8">
                    <asp:TextBox ID="NombresTextBox" runat="server" class="form-control input-sm" Style="font-size: medium"></asp:TextBox>               
                </div>
                <asp:RequiredFieldValidator ID="Validanombre" runat="server" ErrorMessage="El campo &quot;Nombres&quot; esta vacio" ControlToValidate="NombresTextBox" ForeColor="Red" Display="Dynamic" ToolTip="Campo Nombres obligatorio" ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
            </div>
            <%--hasta aqui
            <%--Nombre de usuario--%>     
            <div class="form-group">
                <label for="NombreUsuarioTextBox" class="col-md-3 control-label input-sm" style="font-size: medium">Nombre de usuario</label>
                <div class="col-md-8">
                    <asp:TextBox ID="NombreUsuarioTextBox" runat="server" class="form-control input-sm" Style="font-size: medium"></asp:TextBox>                  
                </div>
                <asp:RequiredFieldValidator ID="ValidaNombreUsuario" runat="server" ErrorMessage="El campo &quot;Nombre de usuario&quot; esta vacio" ControlToValidate="NombreUsuarioTextBox" ForeColor="Red" Display="Dynamic" ToolTip="Campo Nombre de usuario obligatorio" ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
            </div>
            <%--hasta aqui--%>
            <%--Contraseña--%>
            <div class="form-group">
                <label for="ContraseñaTextBox" class="col-md-3 control-label input-sm" style="font-size: medium">Contraseña</label>
                <div class="col-md-8">
                    <asp:TextBox type="password" ID="ContraseñaTextBox" runat="server" class="form-control input-sm" Style="font-size: medium"></asp:TextBox>            
                </div>
                 <asp:RequiredFieldValidator ID="ValidaContraseña" runat="server" ErrorMessage="El campo &quot;Contraseña&quot; esta vacio" ControlToValidate="ContraseñaTextBox" ForeColor="Red" Display="Dynamic" ToolTip="Campo Contraseña obligatorio" ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
            </div>
            <%--hasta aqui--%>
            <%--Confirmar Contraseña--%>
            <div class="form-group">
                <label for="ConfirmarContraseñaTextBox" class="col-md-3 control-label input-sm" style="font-size: medium">Confirmar Contraseña</label>
                <div class="col-md-8">
                    <asp:TextBox type="password" ID="ConfirmarContraseñaTextBox" runat="server" class="form-control input-sm" Style="font-size: medium"></asp:TextBox>                  
                </div>
                <asp:CompareValidator ID="ComparaContraseñas" runat="server" ErrorMessage="Las Contraseñas no son iguales" ControlToValidate="ConfirmarContraseñaTextBox" ControlToCompare="ContraseñaTextBox" ForeColor="Red" Display="Dynamic" ToolTip="Las Contraseñas no son iguales" ValidationGroup="Guardar">*</asp:CompareValidator>
              <asp:RequiredFieldValidator ID="ValidaConfirmarContraseña" runat="server" ErrorMessage="El campo &quot;Nombres&quot; estas vacio" ControlToValidate="ConfirmarContraseñaTextBox" ForeColor="Red" Display="Dynamic" ToolTip="Campo Confirmar Contraseña obligatorio" ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
            </div>
            <%--hasta aqui--%>
            <%--Email--%>
            <div class="form-group">
                <label for="EmailTextBox" class="col-md-3 control-label input-sm" style="font-size: medium">Email</label>
                <div class="col-md-8">
                    <asp:TextBox ID="EmailTextBox" TextMode="Email" runat="server" class="form-control input-sm" Style="font-size: medium"></asp:TextBox>                  
                </div>            
            </div>
            <%--Hasta aqui--%>        
            <%--Telefono y celular--%>
            <div class="form-group">
                <label for="TelefonoTextBox" class="col-md-3 control-label input-sm" style="font-size: medium">Telefono</label>
                <div class="col-md-3">
                    <asp:TextBox  ID="TelefonoTextBox" runat="server" class="form-control input-sm" Style="font-size: medium" TextMode="Phone"></asp:TextBox>   
                    <asp:RegularExpressionValidator ID="ValidaTelefono" runat="server" ErrorMessage='Campo "Telefono" solo acepta numeros' ControlToValidate="TelefonoTextBox" ValidationExpression="^[0-9]*" Text="*" ForeColor="Red" Display="Dynamic" ToolTip="Solo acepta numeros" ValidationGroup="Guardar"></asp:RegularExpressionValidator>
                    <%--<asp:RangeValidator ID="RangeTelefono" runat="server" ErrorMessage="Ingrese un Telefono valido" ForeColor="Red" MaximumValue="12" MinimumValue="10" ControlToValidate="TelefonoTextBox">*</asp:RangeValidator> --%>
                    <asp:RequiredFieldValidator ID="ValidaVacioTelefono" runat="server" ErrorMessage="El campo &quot;Telefono&quot; esta vacio" ControlToValidate="TelefonoTextBox" ForeColor="Red" Display="Dynamic" ToolTip="Campo Telefono es obligatorio" ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
                </div>

                <label for="CelularTextBox" class="col-md-1 control-label input-sm" style="font-size: medium">Celular</label>
                <div class="col-md-3">
                    <asp:TextBox  ID="CelularTextBox" runat="server" class="form-control input-sm" Style="font-size: medium"></asp:TextBox>                  
                </div>
                <asp:RegularExpressionValidator ID="ValidaCelular" runat="server" ErrorMessage='Campo "Celular" solo acepta numeros' ControlToValidate="CelularTextBox" ValidationExpression="^[0-9]*" Text="*" ForeColor="Red" Display="Dynamic" ToolTip="Solo acepta numeros" ValidationGroup="Guardar"></asp:RegularExpressionValidator> 
                <%--<asp:RangeValidator ID="RangeCelular" runat="server" ErrorMessage="Ingrese un Celular valido" ForeColor="Red" MaximumValue="12" MinimumValue="10" ControlToValidate="CelularTextBox" Display="Dynamic">*</asp:RangeValidator>--%>
                <asp:RequiredFieldValidator ID="ValidaVacioCelular" runat="server" ErrorMessage="El campo &quot;Celular&quot; esta vacio" ControlToValidate="CelularTextBox" ForeColor="Red" Display="Dynamic" ToolTip="Campo Celular obligatorio" ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
            </div>
            <%--hasta aqui--%>
            <%--Fecha--%>
            <div class="form-group">
                <div class="col-md-8">
                    <asp:TextBox ID="FechaTextBox" TextMode="Date" runat="server" class="form-control input-sm" Style="font-size: medium" Visible="False"></asp:TextBox>
                </div>
            </div>

            <br />
            <%--Botones--%>
            <div class="panel">
                <div class="text-center">
                    <div class="form-group">
                        <asp:Button ID="NuevoButton" runat="server" Text="Nuevo" class="btn btn-primary btn-lg" OnClick="NuevoButton_Click1" />
                        <asp:Button ID="GuardarButton" runat="server" Text="Guardar" class="btn btn-success btn-lg" OnClick="GuardarButton_Click1" ValidationGroup="Guardar" />
                        <asp:Button ID="EliminarButton" runat="server" Text="Eliminar" class="btn btn-danger btn-lg" OnClick="EliminarButton_Click1" />
                    </div>
                </div>
            </div>

            <div class="col-lg-12">
                <asp:Label ID="ErrorLabel" runat="server" Text=""></asp:Label>
            </div>

        </div>
    </div>


</asp:Content>

