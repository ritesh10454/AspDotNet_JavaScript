<%@ Page Title="" Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="AuditTrails.aspx.vb" Inherits="AuditTrails" %>
<%@ Register Src="UserControl/Breadcrumb.ascx" TagPrefix="Bc" TagName="Bread" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
 <style type ="text/css">  
     .ButtonRightAlign
    {
        float:right;
    }        
         
   th, td
    {
        white-space:normal !important;
    } 

    #loader 
    {  
        position: fixed;  
        opacity:0.9;
        left: 0px;  
        top: 0px;  
        width: 100%;  
        height: 100%;  
        z-index: 9999;  
        background: rgb(201, 201, 201) url('AdminLte/dist/img/waiting.gif') no-repeat 50% 50%;
    }
   
    .buttonF
    {
        font-size:12px;
        font-family: "Calibri";       
    }
    
    .modal-full {
        min-width: 100%;
        margin: 0;
    }

    .modal-full .modal-content {
        min-height: 100%;
    }
    
    .dataTables_empty {
        padding-left:84px !important;
    }
    
    .table thead th
    {
        vertical-align:top !important;
    }    
       
    .updatedby
    {
        width:120px !important;
    } 
           
    .updatedon 
    {
        width:200px !important;
    }

 </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div class="row">
        <div class="col-md-12">
            <div class="card card-primary" style="margin-bottom: 5px;">
                <div class="card-header">
                    <h3 class="card-title">Audit Trails Report</h3>
                </div>
                <div class="card-body" style="padding: 0;">
                    <div class="row">
                        <div class="col-sm-12 col-md-8">
                            <input type="hidden" id="hdfempcd" />
                            <input type="hidden" id="hdfempnam"/>
                            <input type="hidden" id="hdfdept" />
                            <input type="hidden" id="hdfdesig"/>
                            <input type="hidden" id="hdfDate"/>
                        </div>
                        <div class="col-sm-12 col-md-2">
                            <div class="form-group row">
                                <label for="staticEmail" class="col-sm-6 col-form-label LabelAlign">
                                    Date</label>
                                <div class="col-sm-6">
                                    <input type="text" class="form-control-plaintext TextAlign" id="txtDate" readonly />
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-12 col-md-2">
                            <div class="form-group row">
                                <label for="staticEmail" class="col-sm-6 col-form-label LabelAlign">
                                    Time</label>
                                <div class="col-sm-6">
                                    <input type="text" class="form-control-plaintext TextAlign" id="txtTime" readonly />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="card card-primary" style="margin-bottom: 5px;">
                <div class="card-header">
                    <h3 class="card-title">
                        Filter Criteria</h3>
                </div>
                <div class="card-body" style="padding: 0;">
                    <div class="row">
<%--                        <div class="col-sm-12 col-md-6">
                            <div class="form-group row">
                                <label for="staticEmail" class="col-sm-6 col-form-label LabelAlign">
                                    From Date</label>
                                <div class="col-sm-6">
                                    <input type="text" class="form-control TextAlign datepicker" id="txtFroDat" placeholder="From Date" readonly />
                                    <asp:HiddenField ID="hdfRetNo" runat="server" />
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-12 col-md-6">
                            <div class="form-group row">
                                <label for="staticEmail" class="col-sm-6 col-form-label LabelAlign">
                                    To Date</label>
                                <div class="col-sm-6">
                                    <input type="text" class="form-control TextAlign datepicker" id="txtToDat" placeholder="To Date" readonly />
                                </div>
                            </div>
                        </div>--%>
                        <div class="col-sm-12 col-md-6" id="cancel_reason">
                            <div class="form-group row">
                                <label for="staticEmail" class="col-sm-6 col-form-label LabelAlign">
                                    Select Department</label>
                                <div class="col-sm-6">
                                    <asp:DropDownList ID="drpdep" runat="server" CssClass="form-control select2" TabIndex="-1"  onchange="drpDepartment_IndexChange();">
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-12 col-md-6" id="Div1">
                            <div class="form-group row">
                                <label for="staticEmail" class="col-sm-6 col-form-label LabelAlign">
                                    Select Employee</label>
                                <div class="col-sm-6">
                                    <asp:DropDownList ID="drpEmp" runat="server" CssClass="form-control select2" TabIndex="-1">
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-12">
                            <div style="float: right;">
                                <button type="button" class="btn btn-primary" id="btnShow" onclick="btnShow_Click();">Show</button>
                                <button type="button" class="btn btn-primary" id="btnExit" onclick="btnexit_click();">Exit</button>
                            </div>
                        </div>
                    </div>
                    <div class="form-group row">
                        <div class="col-12">
                            <div class="table table-bordered table-striped  dt-responsive" id="jrDetailDIV" style="width: 100%;"></div>
                            <div class="table table-bordered table-striped  dt-responsive" id="DivExport" style="width: 100%;display: none;">
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- Loader -->
        <div class="loader">
        </div>
    </div>
    <div class="row">
        <div class="col">
            <asp:HiddenField ID="hdfUserID" runat="server" />
            <asp:Label ID="lblMessage" runat="server" Style="color: #ff0000; font-weight: bold;" />
            <asp:Label ID="lblMessage2" runat="server" Style="color: #ff0000; font-weight: bold;" />
        </div>
    </div>
    <!-- Loader -->
    <div class="loader">
    </div>
    <script src="Scripts/JQuery/jquery.min.js" type="text/javascript"></script>
    <script src="Scripts/JQuery/jquery-ui.min.js" type="text/javascript"></script>
    <script src="Scripts/AuditTrails.js" type="text/javascript"></script>
    <script src="Scripts/common-script.js" type="text/javascript"></script>
</asp:Content>

