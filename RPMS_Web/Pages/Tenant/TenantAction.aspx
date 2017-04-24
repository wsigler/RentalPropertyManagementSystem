<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TenantAction.aspx.cs" Inherits="RPMS_Web.Pages.Tenant.TenantAction" MasterPageFile="~/Site.Master"%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <asp:UpdatePanel runat="server" ID="upAddEdit">
        <ContentTemplate>
            <div class="form-horizontal">
                <h2><asp:Literal runat="server" ID="litHeader" /></h2>
                <hr />
                <div>
                    <asp:HyperLink runat="server" ID="hlBackToList" NavigateUrl="~/Pages/Tenant/TenantList.aspx">Back To List</asp:HyperLink>                
                </div>
                <div class="panel-group">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            Address
                        </div>
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">Property</div>
                            </div>
                            <div class="row">
                                <div class="col-xs-8 col-sm-8 col-md-8 col-lg-8">
                                    <asp:DropDownList runat="server" CssClass="form-control" ID="ddlProperty" AutoPostBack="true"  OnSelectedIndexChanged="ddlProperty_SelectedIndexChanged" />
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="panel panel-default">
                        <div class="panel-heading">
                            Personal Info
                        </div>
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-xs-3 col-sm-3 col-md-3 col-lg-3">First</div>
                                <div class="col-xs-3 col-sm-3 col-md-3 col-lg-3">Middle</div>
                                <div class="col-xs-3 col-sm-3 col-md-3 col-lg-3">Last</div>
                                <div class="col-xs-3 col-sm-3 col-md-3 col-lg-3">Perferred Name</div>
                            </div>
                            <div class="row">
                                <div class="col-xs-3 col-sm-3 col-md-3 col-lg-3">
                                    <asp:TextBox runat="server" CssClass="form-control" ID="txtFirstName" />
                                </div>
                                <div class="col-xs-3 col-sm-3 col-md-3 col-lg-3">
                                    <asp:TextBox runat="server" CssClass="form-control" ID="txtMiddleName" />
                                </div>
                                <div class="col-xs-3 col-sm-3 col-md-3 col-lg-3">
                                    <asp:TextBox runat="server" CssClass="form-control" ID="txtLastName" />
                                </div>
                                <div class="col-xs-3 col-sm-3 col-md-3 col-lg-3">
                                    <asp:TextBox runat="server" CssClass="form-control" ID="txtFullName" />
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-xs-3 col-sm-3 col-md-3 col-lg-3">Phone #</div>
                                <div class="col-xs-3 col-sm-3 col-md-3 col-lg-3">SSN</div>
                                <div class="col-xs-6 col-sm-6 col-md-6 col-lg-6">Email</div>
                            </div>
                            <div class="row">
                                <div class="col-xs-3 col-sm-3 col-md-3 col-lg-3">
                                    <asp:TextBox runat="server" CssClass="form-control" ID="txtPhone" />
                                </div>
                                <div class="col-xs-3 col-sm-3 col-md-3 col-lg-3">
                                    <asp:TextBox runat="server" CssClass="form-control" ID="txtSSN" />
                                </div>
                                <div class="col-xs-6 col-sm-6 col-md-6 col-lg-6">
                                    <asp:TextBox runat="server" CssClass="form-control" ID="txtEmail" />
                                </div>

                            </div>
                            <div class="row">
                                <div class="col-xs-3 col-sm-3 col-md-3 col-lg-3">DL #</div>
                                <div class="col-xs-3 col-sm-3 col-md-3 col-lg-3">DL State</div>
                                <div class="col-xs-6 col-sm-6 col-md-6 col-lg-6">Primary Tenant</div>
                            </div>
                            <div class="row">
                                <div class="col-xs-3 col-sm-3 col-md-3 col-lg-3">
                                    <asp:TextBox runat="server" CssClass="form-control" ID="txtDriversLicense" />
                                </div>
                                <div class="col-xs-3 col-sm-3 col-md-3 col-lg-3">
                                    <asp:DropDownList runat="server" CssClass="form-control" ID="ddlDriversLicenseStateID" />
                                </div>
                                <div class="col-xs-6 col-sm-6 col-md-6 col-lg-6">
                                    <asp:DropDownList runat="server" CssClass="form-control" ID="ddlParentID" />
                                </div>
                            </div>
                            <div class="row">
                            <div class="col-xs-4 col-sm-4 col-md-4 col-lg-4">
                                <asp:CheckBox runat="server" ID="cbIsActive" Text="Active" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <br />
            <br />
            <div class="form-group">
                <div class="col-xs-10 col-sm-10 col-md-10 col-lg-10">
                </div>
                <div class="col-xs-2 col-sm-2 col-md-2 col-lg-2 right">
                    <asp:Button runat="server" ID="btnCreate" Text="Create" class="btn btn-success"  OnClick="btnCreate_Click"/>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    
</asp:Content>
