<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddPayment.aspx.cs" Inherits="RPMS_Web.Pages.Payments.AddPayment"  MasterPageFile="~/Site.Master"%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="form-horizontal">
        <h2>Payment Management</h2>

        <asp:UpdatePanel runat="server" ID="upPaymentTypes">
            <ContentTemplate>
                <div class="row">
                    <div class="col-xs-4 col-sm-4 col-md-4 col-lg-4">
                        <div class="panel-group">
                            <div class="panel panel-default">
                                <div class="panel-heading">
                                    Payment Types
                                </div>
                                <asp:PlaceHolder runat="server" ID="phList">
                                    <div class="panel-body">
                                        <div class="row">
                                            <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
                                                <div>
                                                    <asp:HyperLink runat="server" ID="hlBackToList" NavigateUrl="AddPayment.aspx?new=1">Add Type</asp:HyperLink>                
                                                </div>
                                                <div class="table-responsive">
                                                    <asp:Repeater runat="server" id="repPaymentTypes">
                                                        <HeaderTemplate>
                                                            <table class="table table-striped w100">
                                                                <tr>
                                                                    <th class="table-headers tableHead w80">Name</th>
                                                                    <th class="w20 tar">&nbsp;</th>
                                                                </tr>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                                <tr>
                                                                    <td><asp:Literal runat="server" ID="litPaymentTypeName" /></td>
                                                                    <td class="f80 tar">
                                                                        <asp:Button CssClass="link btn-link" runat="server" ID="btnPaymentType" OnClick="btnPaymentType_Click" CommandArgument='<%# Eval("ID") %>'  Text="Edit"/>
                                                                    </td>
                                                                </tr>
                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                            </table>
                                                        </FooterTemplate>
                                                    </asp:Repeater>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </asp:PlaceHolder>
                                <asp:PlaceHolder runat="server" ID="phEdit">
                                    <div class="panel-body">
                                        <asp:HiddenField runat="server" ID="hdnID" />
                                        <div class="row">
                                            <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
                                                <div class="row">
                                                    <div class="col-xs-3 col-sm-3 col-md-3 col-lg-3">Name</div>
                                                     <div class="col-xs-9 col-sm-9 col-md-9 col-lg-9">
                                                        <asp:TextBox runat="server" CssClass="form-control" ID="txtEntryName" />
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">Description</div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
                                                        <asp:TextBox TextMode="MultiLine" runat="server" ID="txtDescription" CssClass="preferences" MaxLength="1000"/>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <br />
                                    <div class="form-group">
                                        <div class="col-xs-6 col-sm-6 col-md-6 col-lg-6">
                                        </div>
                                        <div class="col-xs-6 col-sm-6 col-md-6 col-lg-6 right">
                                            <asp:Button runat="server" ID="btnCreate" Text="Create" class="btn btn-success btn-sm"  OnClick="btnCreate_Click" />&nbsp;
                                            <asp:Button runat="server" ID="btnCancel" Text="Cancel" class="btn btn-default btn-sm"  OnClick="btnCancel_Click"/>
                                        </div>
                                    </div>
                                </asp:PlaceHolder>
                            </div>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
             <Triggers>
                <asp:PostBackTrigger  ControlID="btnCreate"/>
                <asp:PostBackTrigger  ControlID="btnCancel" />
            </Triggers>
        </asp:UpdatePanel>
        
    </div>
</asp:Content>
