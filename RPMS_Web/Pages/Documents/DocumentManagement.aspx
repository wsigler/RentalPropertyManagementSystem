<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DocumentManagement.aspx.cs" Inherits="RPMS_Web.Pages.Documents.DocumentManagement" MasterPageFile="~/Site.Master" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
   <%--<script type = "text/javascript">
         function SetTarget() {
             document.forms[0].target = "_blank";
         }
    </script>--%>
     <h2>Document Management</h2>
    <hr />
        <div class="form-horizontal">
            <div class="panel-group">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        Document
                    </div>
                    <div class="panel-body">
                        <div class="row">
                            <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
                                <asp:RadioButton Checked="true" runat="server" ID="rbNonRenewal" GroupName="gnDocuments" CssClass="radio radio-inline" Text="Non Renewal" AutoPostBack="true" OnCheckedChanged="rbNonRenewal_CheckedChanged"/>
                                <asp:RadioButton runat="server" ID="rbNoticeOfEntry" GroupName="gnDocuments" CssClass="radio radio-inline" Text="Notice of Entry" AutoPostBack="true" OnCheckedChanged="rbNoticeOfEntry_CheckedChanged"/>
                                <asp:RadioButton runat="server" ID="rbEviction" GroupName="gnDocuments" CssClass="radio radio-inline" Text="Eviction" AutoPostBack="true" OnCheckedChanged="rbEviction_CheckedChanged"/>
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">Tenant</div>
                        </div>
                        <div class="row">
                            <div class="col-xs-4 col-sm-4 col-md-4 col-lg-4">
                                <asp:DropDownList runat="server" CssClass="form-control" ID="ddlTenants" />
                            </div>
                        </div>
                        <br />
                        <div runat="server" id="rowEntry" visible="false">
                            <div class="row">
                                <div class="col-xs-4 col-sm-4 col-md-4 col-lg-4">Reason for Entry</div>
                                <div class="col-xs-4 col-sm-4 col-md-4 col-lg-4">Date of Entry</div>
                                <div class="col-xs-4 col-sm-4 col-md-4 col-lg-4">Time of Entry</div>
                            </div>
                            <div class="row">
                                <div class="col-xs-4 col-sm-4 col-md-4 col-lg-4">
                                    <asp:TextBox runat="server" CssClass="form-control" TextMode="MultiLine"  ID="txtReasons"/>
                                </div>
                                <div class="col-xs-4 col-sm-4 col-md-4 col-lg-4">
                                    <asp:TextBox runat="server" CssClass="form-control datepicker" ID="txtDateOfEntry"/>
                                </div>
                                <div class="col-xs-4 col-sm-4 col-md-4 col-lg-4">
                                    <asp:TextBox runat="server" CssClass="form-control" ID="txtTimeOfEntry"/>
                                </div>
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
                    <%--<asp:Button runat="server" ID="btnCreate" Text="Create" class="btn btn-success"  OnClick="btnCreate_Click"  OnClientClick="SetTarget();"/>--%>
                    <asp:Button runat="server" ID="btnCreate" Text="Create" class="btn btn-success"  OnClick="btnCreate_Click"/>&nbsp;
                    <asp:Button runat="server" ID="btnCancel" Text="Cancel" class="btn btn-default"  OnClick="btnCancel_Click"/>
                </div>
            </div>
        </div>

</asp:Content>