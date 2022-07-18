<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AdminMaster.Master" AutoEventWireup="true" CodeBehind="ConInstitute.aspx.cs" Inherits="SchoolManagementSystem.Setup.ConInstitute" %>

<%@ Register Src="~/ResponseMessage.ascx" TagPrefix="uc1" TagName="ResponseMessage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="content-wrapper">
        <div class="container">
            <!-- general form elements -->
            <div class="card card-primary">
                <div class="card-header">
                    <h3 class="card-title">Institute Info</h3>
                </div>
                <uc1:ResponseMessage runat="server" ID="rmIns" />
                <!-- /.card-header -->
                <!-- form start -->

                <div class="card-body">
                    <div class="row">
                        <div class="col-md-4">
                            <div class="form-group ">
                                <label class="form-label">EIIN/ RegistrationNo</label>
                                <asp:TextBox ID="txtEIIN" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-8">
                            <div class="form-group ">
                                <label class="form-label">Institute Name</label>
                                <asp:TextBox ID="txtInstituteName" runat="server" placeholder="Enter Institute Name" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group ">
                                <label class="form-label">Email</label>
                                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group ">
                                <label class="form-label">Phone</label>
                                <asp:TextBox ID="txtPhone" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group ">
                                <label class="form-label">Fax</label>
                                <asp:TextBox ID="txtFax" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>

                        <div class="col-md-4">
                            <div class="form-group ">
                                <label class="form-label">District</label>
                                <asp:DropDownList ID="ddlDistrict" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group ">
                                <label class="form-label">Upazila</label>
                                <asp:DropDownList ID="ddlUpazila" runat="server" CssClass="form-control"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group ">
                                <label class="form-label">Address</label>
                                <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>

                        <div class="col-md-4">
                            <div class="form-group ">
                                <label class="form-label">Institute Type</label>
                                <asp:DropDownList ID="ddlInstituteType" runat="server" CssClass="form-control">
                                    <asp:ListItem Value="0">Select</asp:ListItem>
                                    <asp:ListItem Value="1">Primary</asp:ListItem>
                                    <asp:ListItem Value="2">Secondary</asp:ListItem>
                                    <asp:ListItem Value="3">Higher-Secondary</asp:ListItem>
                                    <asp:ListItem Value="4">Graduation</asp:ListItem>
                                    <asp:ListItem Value="5">Masters</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>

                        <div class="col-md-2">
                            <div class="form-group ">
                                <label class="form-label">&nbsp;</label>
                                <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary form-control" Text="Save" OnClick="btnSave_Click" />
                            </div>

                        </div>
                    </div>


                </div>

                <div class="card-header ">
                    <h3 class="card-title text-center">Institute  List</h3>
                </div>
                <div class="card-body">
                    <div class="row">
                        <div class="col-md-12" style="overflow:scroll">
                            <div class="form-group ">
                                <asp:HiddenField ID="hdnUpdateInstituteId" runat="server" />
                                <asp:GridView ID="gvInstitute" runat="server" CssClass="table table-bordered table-striped" AutoGenerateColumns="true" Width="100%">
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!-- /.card -->
        </div>
    </div>

</asp:Content>
