<%@ Page Title="Registration" Language="C#" MasterPageFile="~/UI.Master" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="UI.Users.Registration" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Register</h2>
    <div class="container container-forms">

        <div class="form-group">
            <asp:Label CssClass="control-label" AssociatedControlID="firstname" runat="server">First name</asp:Label>
            <div class="controls">
                <asp:TextBox runat="server" ID="firstname" CssClass="form-control input-lg" />
            </div>
        </div>

        <div class="form-group">
            <asp:Label CssClass="control-label" AssociatedControlID="lastname" runat="server">Last name</asp:Label>
            <div class="controls">
                <asp:TextBox runat="server" ID="lastname" CssClass="form-control input-lg" />
            </div>
        </div>

        <div class="form-group">
            <asp:Label CssClass="control-label" AssociatedControlID="email" runat="server">E-mail</asp:Label>
            <div class="controls">
                <asp:TextBox runat="server" ID="email" CssClass="form-control input-lg" />
            </div>
        </div>

        <div class="form-group">
            <asp:Label CssClass="control-label" AssociatedControlID="password" runat="server">Password</asp:Label>
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

        <div class="form-group">
            <asp:Label CssClass="control-label" AssociatedControlID="passwordconfirm" runat="server">Password (Confirm)</asp:Label>
            <div class="controls">
                <asp:TextBox runat="server" ID="passwordconfirm" CssClass="form-control input-lg" />
                <p class="help-block">Please confirm password</p>
            </div>
        </div>

        <div class="form-group">
            <asp:Label CssClass="control-label" AssociatedControlID="birthdate" runat="server">Birthdate</asp:Label>
            <div class="controls">
                <asp:TextBox ID="birthdate" runat="server" type="date" CssClass='m-wrap span12 date form_datetime' placeholder="YYYY-MM-DD" ClientIDMode="Static"></asp:TextBox>
            </div>
        </div>

        <div class="form-group">
            <asp:UpdatePanel ID="ProgressUpdatePanel" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:Label CssClass="control-label" AssociatedControlID="DataList2" runat="server">Language</asp:Label>
                    <asp:DataList ID="DataList2" runat="server" DataKeyField="Name" DataSourceID="SqlDataSource2">
                    </asp:DataList>
                    <asp:DropDownList ID="DropDownList1" DataTextField="Name" runat="server" DataSourceID="SqlDataSource2">
                    </asp:DropDownList>
                    <asp:Button ID="Button2" runat="server" Text="Add" CssClass="btn btn-list" OnClick="Button2_Click" />
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ShowMeAroundContext %>" SelectCommand="SELECT [Name] FROM [Languages]"></asp:SqlDataSource>
                    <br />
                    <asp:Label CssClass="control-label" runat="server" ID="languageLabel" Text="" />
                </ContentTemplate>
            </asp:UpdatePanel>

            <script type="text/javascript">
                $(document).ready(function () {
                    bindButton();
                });
                function bindButton() {
                    $('#<%=Button2.ClientID%>').on('click', function () {
            $('#<%=languageLabel.ClientID%>').html('Please Wait...');
        });
    }
            </script>
        </div>

        <div class="form-group">
            <asp:Label CssClass="control-label" AssociatedControlID="DataList1" runat="server">Interests</asp:Label>
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
        </div>

        <div class="form-group">
            <!-- Button -->
            <div class="controls">
                <asp:Button ID="Button1" CssClass="btn btn-success" runat="server" OnClick="Button1_Click" Text="Register" />
            </div>
        </div>
    </div>
</asp:Content>
