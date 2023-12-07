<%@ Page Title="" Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="HODApproval.aspx.vb" Inherits="HODApproval" %>
<%@ Register Src ="UserControl/Breadcrumb.ascx" TagPrefix ="Bc" TagName ="Bread" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
<style type="text/css" >
      .ButtonRightAlign
    {
        float:right;
    }
    
   
    table.dataTable thead tr 
    {
        background-color: #007bff;
        color:#fff;
        font-size:12px;
    } 
    .dataTables_scroll
    {
        overflow:auto;
    }   
    
    table.dataTable {
    margin: 0 !important;
    font-family: "Calibri"; 
    font-size:12px;
}    
    .gridButton {
        font-family: "Calibri"; 
        font-size:12px;
    }
   

    #loader1 {  
        position: fixed;  
        left: 0px;  
        top: 0px;  
        opacity:0.9;
        width: 100%;  
        height: 100%;  
        z-index: 9999;  
        background: rgb(201, 201, 201) url('AdminLte/dist/img/waiting.gif') no-repeat 50% 50%;
    }
    
    
    th, td {
        white-space: nowrap;
        font-size:12px;
    }
    
    .dataTables_empty {
        padding-left:84px !important;
    }       
    
 </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<div class="row">
    <div class ="col-md-12">
        <div class="card card-primary" style="margin-bottom: 5px;">
            <div class="card-header">
                <h3 class="card-title">Inbox (HOD Approval)</h3>                
            </div>
            <div class="card-body" style="padding:0;">
                <div class="row">
                    <div class="col-sm-12">
                          <div class="form-group row">
                              <div class ="table table-bordered table-striped" id="mivOutboxDIV">
                                    <table id="InboxTable"  border="0" cellpadding="0" cellspacing="0"  class ="table table-bordered table-striped" style="width:100%;">
                                        <thead>
                                            <tr>
                                                <th>Sr. No.</th>
                                                <th>Employee Code</th>
                                                <th>Employee Name</th>
                                                <th>Department Code</th>
                                                <th>Department Name</th>
                                                <th>Designation Name</th>
                                                <th>Final Authorizer's Status (Department)</th>
                                                <th>Final Authorizer's Status (HR)</th>
                                                <th>Select</th>
                                            </tr>
                                        </thead>                                
                                    </table> 
                                </div> 
                              <asp:Label ID="lblMessage" runat="server" style="text-align:center; color:Red; font-weight:bold;" ></asp:Label>
                          </div>  
                    </div>
                </div>                
            </div> 
            
            <div class="row">
                <div class="col-sm-12">
                    <a href="Default.aspx" id="btnExit" class="btn btn-primary ButtonRightAlign">Exit</a>
                </div>
            </div>            
            <div class="card-footer">
            </div>
        </div> 

    </div> 
    <!-- Loader -->
    <div id="loader1"></div> 
</div> 

<script src="Scripts/JQuery/jquery.min.js" type="text/javascript"></script>
<script src="Scripts/JQuery/jquery-ui.min.js" type="text/javascript"></script>
<script src="Scripts/HODApproval.js" type="text/javascript"></script>
<script src="Scripts/common-script.js" type="text/javascript"></script>
</asp:Content>

