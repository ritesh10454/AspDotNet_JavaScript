<%@ Page Title="" Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="JROutbox.aspx.vb" Inherits="JROutbox" %>
<%@ Register Src ="UserControl/Breadcrumb.ascx" TagPrefix ="Bc" TagName ="Bread" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
  <style type ="text/css">   
     .ButtonRightAlign
    {
        float:right;
    }
     
    .TextAlign
    {
        text-align:left;
    }         
        
    table.dataTable thead tr 
    {
        background-color: #007bff;
        font-size:12px;
        color:#fff;
    }   
    
     table.dataTable 
     {
        margin: 0 !important;
        font-family: "Calibri"; 
        font-size:12px;
    }    
    .gridButton
    {
        font-family: "Calibri"; 
        font-size:12px;
    }   
     

    #loader2 
    {  
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
                <h3 class="card-title">Outbox</h3>
            </div>
            <div class="card-body" style="padding:0;">
                <div class="row" id="batchtype"  style="display:none;" >
                    <div class="col-sm-12 col-md-6">
                        <div class="form-group row">
                            <label for="staticEmail" class="col-sm-6 col-form-label LabelAlign">Select Bacth Type</label>
                            <div class="col-sm-6">
                                <asp:DropDownList ID="drpLabReqTyp" runat="server" cssClass="form-control select2" TabIndex="-1"  >
                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                    <asp:ListItem Value="P">Captial</asp:ListItem>
                                    <asp:ListItem Value="C">Consumable</asp:ListItem>                                        
                                </asp:DropDownList>
                                <asp:HiddenField ID="hdfinf" runat="server" />
                            </div>
                        </div>
                    </div>
                </div> 
                 <div class="row">
                    <div class="col-sm-12">
                        <div class="form-group row">
                            <div class ="table table-bordered table-striped  dt-responsive" id="mivOutboxDIV">
                             <!--style="overflow:scroll;"-->
                                <table id="OutboxTable"  border="0" cellpadding="0" cellspacing="0"  class ="table table-striped" style="width:100%;">
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
                            <asp:HiddenField ID="hdfempcd" runat="server" />
                        </div>  
                    </div> 
                 </div> 
                 <div class="row">
                    <div class="col-sm-12">
                        <a href="Default.aspx" id="btnExit" class="btn btn-primary ButtonRightAlign">Exit</a>
                    </div>
                 </div>
            </div> 
            <div class="card-footer">                
            </div>        
        </div>  
    </div> 

<!--Print Modal -->
<div class="modal fade" id="ShowModalPrint" tabindex="-1" role="dialog" aria-labelledby="ModalTitle" aria-hidden="true" data-backdrop="static" data-keyboard="false">
    <div class="modal-dialog  modal-xl" role="document">
        <div class="modal-content">
            <div class="modal-header bg-primary">
            <button type="button" class="close" data-dismiss="modal" aria-hidden="true" style="display:none">
            &times;</button>
            <h4 class="modal-title" id="ModalTitle">Material Issue Voucher</h4>
            </div>
            <div class="modal-body">
                <div class="row">
                    <div class="col-12">
                        <div  id="OutputPrint">
                        <table cellpadding="0" cellspacing="0" width="100%">
                            <tr>
                                <td colspan="4"  style="text-align:center;"><span><img  src="Images/logo.JPG" style="height:57px;" alt=""/>IOL CHEMICALS AND PHARMACEUTICALES LIMITED</span></td>
                            </tr>
                            <tr>
                                <td colspan="4"  style="text-align:center;text-align:center;">MANSA ROAD, DHAULA, BARNALA (PUNJAB)</td>
                            </tr>
                            <tr>
                                <td colspan="4" style="text-align:center;font-weight:bold;">MATERIAL ISSUE VOUCHER</td> 
                            </tr>
                            <tr>
                                <td>Miv Type</td>
                                <td style="text-decoration: underline;" id="td_mivtype"></td>
                                <td>Miv No.</td>
                                <td style="text-decoration: underline;" id="td_Mivno"></td>
                            </tr>
                            <tr>
                                <td>Generate By</td>
                                <td style="text-decoration: underline;" id="td_generateby"></td>
                                <td>Miv Date</td>
                                <td style="text-decoration: underline;" id="td_mivdt"></td>
                            </tr>
                            <tr>
                                <td>Department</td>
                                <td style="text-decoration: underline;" id="td_dept_nm"></td>
                                <td>Approving Authority</td>
                                <td style="text-decoration: underline;" id="td_appauth"></td>
                            </tr>
                            <tr>
                                <td colspan="4">&nbsp;</td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    <div class ="table table-striped  dt-responsive" id="mivDetailDIV">
                                    </div>
                                </td>
                            </tr>

                        </table>
                        </div>
                    </div>
                </div>
            </div>
            <div class="modal-footer">
                <%--button type="button" id="btnItemSearch" class="btn btn-default" data-dismiss="modal" aria-hidden="true" onclick= >Search</button>--%>
                <button type="button" id="btnPrint" class="btn btn-primary" onclick="printData();">Print</button>
                <button type="button" id="btnClose" class="btn btn-primary" data-dismiss="modal" aria-hidden="true" >Close</button>
            </div>
        </div>
    </div>
</div>

<!-- Loader -->
<div id="loader2"></div> 
</div>

    <script src="Scripts/JQuery/jquery.min.js" type="text/javascript"></script>
    <script src="Scripts/JQuery/jquery-ui.min.js" type="text/javascript"></script>
    <script src="Scripts/JROutbox.js" type="text/javascript"></script>
    <script src="Scripts/common-script.js" type="text/javascript"></script>
</asp:Content>

