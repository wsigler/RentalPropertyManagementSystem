<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TenantDetail.aspx.cs" Inherits="RPMS_Web.Pages.Tenant.TenantDetail" MasterPageFile="~/Site.Master" %>
<%@ Register Assembly="IZ.WebFileManager" Namespace="IZ.WebFileManager" TagPrefix="iz" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div>
        <h4>Tenant Detail</h4>
        <hr />
        <div>
            <a href="TenantList.aspx">Back To List</a> |
            <asp:HyperLink runat="server" ID="hlEditTenant">Edit</asp:HyperLink> |
            <asp:HyperLink runat="server" ID="hlCreateLeaseInfo" />
        </div>
        <fieldset class="form-group" style="margin-right: 0px; margin-left:0px">
            <legend>Personal Info</legend>
            <div class="row">
                <div class="col-xs-6 col-sm-6 col-md-6 col-lg-6">
                    Name: <asp:Literal runat="server" ID="litName" /> 
                </div>
                <div class="col-xs-6 col-sm-6 col-md-6 col-lg-6">
                    Email: <asp:Literal runat="server" ID="litEmail" />
                </div>
            </div>
            <div class="row">
                <div class="col-xs-6 col-sm-6 col-md-6 col-lg-6">
                    Phone #: <asp:Literal runat="server" ID="litPhoneNumber" />
                </div>
                <div class="col-xs-6 col-sm-6 col-md-6 col-lg-6">
                    DL #: <asp:Literal runat="server" ID="litDriversLicense" />
                </div>
            </div>
            <div class="row">
                <div class="col-xs-6 col-sm-6 col-md-6 col-lg-6">
                    SSN:<asp:Literal runat="server" ID="litSSN" />
                </div>
                <div class="col-xs-6 col-sm-6 col-md-6 col-lg-6">
                    <asp:Literal runat="server" ID="litPrimary" Text="Primary Tenant: " /><asp:HyperLink runat="server" ID="hlPrimaryFullName" />
                </div>
            </div>
        </fieldset>

        <fieldset class="form-group" style="margin-right: 0px; margin-left:0px">
            <legend>Address</legend>
            <address>
                <asp:Hyperlink runat="server" ID="hlAddress" />
            </address>
        </fieldset>

        <div id="dragandrophandler">
            <iz:FileManager ID="fmCustomers" runat="server" Height="400" Width="600">
                <RootDirectories>
                    <iz:RootDirectory DirectoryPath="/Files/Tenants/" Text="Tenant Files" ShowRootIndex="false" />
                </RootDirectories>
                <FileTypes>
                    <iz:FileType Extensions="zip, rar, iso" Name="Archive" SmallImageUrl="/images/16x16/compressed.gif" LargeImageUrl="/images/32x32/compressed.gif"></iz:FileType>
                    <iz:FileType Extensions="doc, rtf" Name="Microsoft Word Document" SmallImageUrl="/images/16x16/word.gif" LargeImageUrl="/images/32x32/word.gif"></iz:FileType>
                    <iz:FileType Extensions="xls, csv" Name="Microsoft Excel Worksheet" SmallImageUrl="/images/16x16/excel.gif" LargeImageUrl="/images/32x32/excel.gif"></iz:FileType>
                    <iz:FileType Extensions="ppt, pps" Name="Microsoft PowerPoint Presentation" SmallImageUrl="/images/16x16/PowerPoint.gif" LargeImageUrl="/images/32x32/PowerPoint.gif"></iz:FileType>
                    <iz:FileType Extensions="pdf" Name="Adobe PDF" SmallImageUrl="/images/16x16/pdf.png" LargeImageUrl="/images/32x32/pdf.png"></iz:FileType>                    
                    <iz:FileType Extensions="gif, jpg, png" Name="Image" SmallImageUrl="/images/16x16/image.gif" LargeImageUrl="/images/32x32/image.gif"></iz:FileType>
                    <iz:FileType SmallImageUrl="/images/16x16/media.gif" Name="Windows Media File" Extensions="mp3,wma,vmv,avi,divx" LargeImageUrl="/images/32x32/media.gif"></iz:FileType>
                    <iz:FileType Extensions="txt" Name="Text Document">
                        <Commands>
                            <iz:FileManagerCommand Name="Edit" CommandName="EditText" SmallImageUrl="/images/16x16/edit.gif" />
                        </Commands>
                    </iz:FileType>
                    <iz:FileType Extensions="xml, xsl, xsd" Name="XML Document" LargeImageUrl="/images/32x32/xml.gif" SmallImageUrl="/images/16x16/xml.gif">
                        <Commands>
                            <iz:FileManagerCommand Name="Edit" CommandName="EditText" SmallImageUrl="/images/16x16/edit.gif" />
                        </Commands>
                    </iz:FileType>
                    <iz:FileType Extensions="css" Name="Cascading Style Sheet" LargeImageUrl="/images/32x32/styleSheet.gif" SmallImageUrl="/images/16x16/styleSheet.gif">
                        <Commands>
                            <iz:FileManagerCommand Name="Edit" CommandName="EditText" SmallImageUrl="/images/16x16/edit.gif" />
                        </Commands>
                    </iz:FileType>
                    <iz:FileType Extensions="js, vbs" Name="Script File" LargeImageUrl="/images/32x32/script.gif" SmallImageUrl="/images/16x16/script.gif">
                        <Commands>
                            <iz:FileManagerCommand Name="Edit" CommandName="EditText" SmallImageUrl="/images/16x16/edit.gif" />
                        </Commands>
                    </iz:FileType>
                    <iz:FileType Extensions="htm, html" Name="HTML Document" LargeImageUrl="/images/32x32/html.gif" SmallImageUrl="/images/16x16/html.gif">
                        <Commands>
                            <iz:FileManagerCommand Name="Edit with WYSWYG editor" CommandName="WYSWYG" />
                            <iz:FileManagerCommand Name="Edit" CommandName="EditText" SmallImageUrl="/images/16x16/edit.gif" />
                        </Commands>
                    </iz:FileType>
                </FileTypes>
            </iz:FileManager>
        </div>

        <fieldset class="form-group" style="margin-right: 0px; margin-left:0px">
            <legend>Auditing</legend>
            <div class="row">
                <div class="col-xs-8 col-sm-8 col-md-8 col-lg-8">
                    <asp:Literal runat="server" ID="litCreateAudit" />
                </div>
            </div>
            <div class="row">
                <div class="col-xs-8 col-sm-8 col-md-8 col-lg-8">
                    <asp:Literal runat="server" ID="litModifyAudit" />                        
                </div>
            </div>
        </fieldset>
    </div>


</asp:Content>
