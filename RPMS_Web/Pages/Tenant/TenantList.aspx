<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TenantList.aspx.cs" Inherits="RPMS_Web.Pages.Tenant.TenantList" MasterPageFile="~/Site.Master"%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
<h2>Tenant List</h2>
<hr />
<div>
    <a href="TenantAction.aspx">Create New</a>
</div>
<div class="table-responsive">
    
        <asp:Repeater runat="server" ID="repTenants">
            <HeaderTemplate>
                <table class="table table-striped w100">
                    <tr>
                        <th class="table-headers w15">Name</th>
                        <th class="table-headers w25">Address</th>
                        <th class="table-headers w15">Email</th>
                        <th class="table-headers w10">Phone</th>
                        <th class="table-headers w15">Primary Tenant</th>
                        <th class="w20">&nbsp;</th>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                    <tr>
                        <td><asp:Literal runat="server" ID="litFullName" /></td>
                        <td><asp:HyperLink runat="server" ID="hlStreetAddress1" /></td>
                        <td><asp:Literal runat="server" ID="litEmail" /></td>
                        <td><asp:Literal runat="server" ID="litPhone" /></td>
                        <td><asp:Literal runat="server" ID="litPrimaryFullName" /></td>
                        <td class="f80 tar">
                            <asp:HyperLink runat="server" ID="hlEdit" Text="Edit" /> |
                            <asp:HyperLink runat="server" ID="hlDetails" Text="Details" /> 
                            <asp:HyperLink runat="server" ID="hlLease" /> 
                            <asp:HyperLink runat="server" ID="hlPayment" />

                        </td>
                    </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>

    </div>

</asp:Content>
