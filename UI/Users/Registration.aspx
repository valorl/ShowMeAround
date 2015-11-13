<%@ Page Title="Registration" Language="C#" MasterPageFile="~/UI.Master" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="UI.Users.Registration" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-6">
                <div class="form-horizontal">
                    <div id="legend">
                    </div>
                    <legend class="">Register</legend>
                </div>
                <div class="control-group">
                    <label class="control-label" for="firstname">First name</label>
                    <div class="controls">
                        <asp:TextBox runat="server" ID="firstname" CssClass="form-control input-lg" />
                        <asp:RequiredFieldValidator
                            ID="firstNameValidator"
                            runat="server"
                            ControlToValidate="firstname"
                            ErrorMessage="This field is required">
                        </asp:RequiredFieldValidator>
                    </div>
                </div>

                <div class="control-group">
                    <label class="control-label" for="lastname">Last name</label>
                    <div class="controls">
                        <asp:TextBox runat="server" ID="lastname" CssClass="form-control input-lg" />
                        <asp:RequiredFieldValidator
                            ID="lastNameValidator"
                            runat="server"
                            ControlToValidate="lastname"
                            ErrorMessage="This field is required">
                        </asp:RequiredFieldValidator>
                    </div>
                </div>

                <div class="control-group">
                    <label class="control-label" for="email">E-mail</label>
                    <div class="controls">
                        <asp:TextBox runat="server" ID="email" CssClass="form-control input-lg" />
                        <asp:RegularExpressionValidator
                            ID="emailValidator"
                            ControlToValidate="email"
                            Display="Static"
                            runat="server"
                            ErrorMessage="Please enter a valid email"
                            ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">
                        </asp:RegularExpressionValidator>
                    </div>
                </div>

                <div class="control-group">
                    <label class="control-label" for="password">Password</label>
                    <div class="controls">
                        <asp:TextBox runat="server" ID="password" CssClass="form-control input-lg" />
                        <asp:RegularExpressionValidator
                            ID="passwordValidator"
                            ControlToValidate="password"
                            Display="Static"
                            runat="server"
                            ErrorMessage="Please enter a valid password"
                            ValidationExpression="\d{3}-\d{3}-\d{4}">
                        </asp:RegularExpressionValidator>
                        <p class="help-block">Password must be at least 8 characters and contain at least one number and one uppercase character</p>
                    </div>
                </div>

                <div class="control-group">
                    <label class="control-label" for="password_confirm">Password (Confirm)</label>
                    <div class="controls">
                        <asp:TextBox runat="server" ID="passwordconfirm" CssClass="form-control input-lg" />
                        <asp:CompareValidator 
                            ID="confirmPasswordValidator"
                            ControlToValidate="password"
                            Display="Static"
                            runat="server" 
                            ErrorMessage="Passwords do not match">
                        </asp:CompareValidator>
                        <p class="help-block">Please confirm password</p>
                    </div>
                </div>

                <div class="control-group">
                    <label class="control-label" for="languages">Language</label>
                    <div class="input-append">
                        <input id="itemText" name="itemText" type="text" class="form-control input-lg" value="">
                        <button id="add-item" class="btn btn-list">Add <i class="icon-plus"></i></button>
                        <p class="help-block">Please add the languages you speak</p>
                    </div>
                    <ul id="items">
                    </ul>
                </div>

                <div class="control-group">
                    <!-- Button -->
                    <div class="controls">
                        <asp:Button ID="Button1" CssClass="btn btn-success" runat="server" OnClick="Button1_Click" Text="Register" />

                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
