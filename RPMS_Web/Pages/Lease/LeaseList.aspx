<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LeaseList.aspx.cs" Inherits="RPMS_Web.Pages.Lease.LeaseList" MasterPageFile="~/Site.Master"%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Current Lease List</h2>
    <hr />
    <div class="table-responsive">
        <asp:Repeater runat="server" id="repLeases">
            <HeaderTemplate>
                <table class="table table-striped w100">
                    <tr>
                        <th class="table-headers tableHead w5">Rented</th>
                        <th class="table-headers tableHead w35">Address</th>
                        <th class="table-headers tableHead w20">Tenant</th>
                        <th class="table-headers tableHead w10">Start Date</th>
                        <th class="table-headers tableHead w10">End Date</th>
                        <th class="w20">&nbsp;</th>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                    <tr>
                        <td class="tac"><asp:CheckBox runat="server" ID="cbIsRented" /></td>
                        <td><asp:HyperLink runat="server" ID="hlStreetAddress" /></td>
                        <td><asp:HyperLink runat="server" ID="hlTenantName" /></td>
                        <td><asp:Literal runat="server" ID="litStartDate" /></td>
                        <td><asp:Literal runat="server" ID="litEndDate" /></td>
                        <td class="f80 tar">
                            <asp:HyperLink runat="server" ID="hlLease" Text="Renew Lease"/>
                        </td>
                    </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
