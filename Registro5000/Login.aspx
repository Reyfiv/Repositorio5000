<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Registro5000.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="panel" style="background-color:cornflowerblue">
        <div class="panel-heading" style="font-family:'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; font-size: x-large; color:aliceblue">Inicio de sesion</div>
    </div>

    <div class="panel-body">
        <div class="col-lg-12" style="text-align:right">
                <asp:Label ID="ErrorLabel" runat="server" Text=""></asp:Label>
            </div>
        <div class="row">
            <div class="col-lg-12" style="text-align:center; font-size:xx-large">
                <span class="glyphicon glyphicon-user"></span>
            </div>

            <div class="col-lg-12">
                <%--Usuario--%>
                <div class="form-group">
                    <asp:TextBox ID="UsuarioTextBox" placeholder="Usuario" TabIndex="1" class="form-control" runat="server"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="valida1" runat="server" ErrorMessage="*" ValidationGroup="Login" ControlToValidate="UsuarioTextBox" Display="Dynamic" ForeColor="Red"></asp:RegularExpressionValidator>
                </div>
                <%--Contraseña--%>
                <div class="form-group">
                    <asp:TextBox type="password" ID="ContraseñaTextBox" placeholder="Contraseña" TabIndex="2" class="form-control" runat="server"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="Valida2" runat="server" ErrorMessage="*" ValidationGroup="Login" ControlToValidate="ContraseñaTextBox" Display="Dynamic" ForeColor="Red"></asp:RegularExpressionValidator>
                </div>
                <hr />
                <%--Botones--%>
                <div class="form-group">
                    <div class="row">
                        <div class="col-md-12">
                            <asp:Button ID="LoginButton" runat="server" Text="Login"  class="btn btn-info btn-lg" Width="1112px" OnClick="LoginButton_Click" ValidationGroup="Login"/>
                        </div>
                    </div>
                </div>
            </div>
        </div>

         

    </div>
</asp:Content>

