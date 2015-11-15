<%@ Page Title="Registration" Language="C#" MasterPageFile="~/UI.Master" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="UI.Users.Registration" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container container-forms">
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
                    </div>
                </div>

                <div class="control-group">
                    <label class="control-label" for="lastname">Last name</label>
                    <div class="controls">
                        <asp:TextBox runat="server" ID="lastname" CssClass="form-control input-lg" />
                    </div>
                </div>

                <div class="control-group">
                    <label class="control-label" for="email">E-mail</label>
                    <div class="controls">
                        <asp:TextBox runat="server" ID="email" CssClass="form-control input-lg" />
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
                        <p class="help-block">Please confirm password</p>
                    </div>
                </div>

                <div class="control-group">

                    <label class="control-label" for="birthdate">Birthdate</label>
                    <asp:TextBox ID="txt_date" runat="server" type="date" CssClass='m-wrap span12 date form_datetime' placeholder="YYYY-MM-DD" ClientIDMode="Static"></asp:TextBox>



                 </div>

                    <div class="control-group">
                        <label class="control-label" for="languages">Language</label>
                        <div class="input-append">
                            <asp:DropDownList ID="languageList" runat="server" CssClass="form-control input-lg">
                                <asp:ListItem Text="Denmark" Value="0"></asp:ListItem>
                            </asp:DropDownList>
                            <button id="add-item" class="btn btn-list">Add <i class="icon-plus"></i></button>
                            <p class="help-block">Please add the languages you speak</p>
                        </div>
                        <ul id="items">
                        </ul>
                    </div>

                    <label class="control-label">Interests</label>
                    <asp:DataList ID="DataList1" runat="server" DataKeyField="Id" RepeatColumns="3" CellPadding="5" CellSpacing="5" DataSourceID="SqlDataSource1">
                        <ItemTemplate>
                            <table cellpadding="2" cellspacing="2">
                                <tr>
                                    <td class="checkbox-inline">
                                        <asp:CheckBox ID="CheckBox1" runat="server" Style="padding-left: 10px;" />
                                        <%# Eval("Name") %></td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </asp:DataList>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ShowMeAroundContext %>" SelectCommand="SELECT * FROM [Interests]"></asp:SqlDataSource>
                    <br />

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
