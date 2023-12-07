<%@ Page Title="" Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" ClientIDMode="Static" CodeFile="Password.aspx.vb" Inherits="Password" %>
<%@ Register Src ="UserControl/Breadcrumb.ascx" TagPrefix ="Bc" TagName ="Bread" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
<style type="text/css" >
    .LabelAlign
    {
        text-align:right;
    }
     
    .TextAlign
    {
        text-align:left;
    }
    
    input[type=text]:focus, input[type=password]:focus
    {
        background-color:lightyellow;
        border: 1px solid #ccc;
    }    

    th, td {
        white-space: nowrap;
    }
    
    table.dataTable thead tr {
        background-color: #007bff;
        color:#fff;
    }   

    table.dataTable tfoot tr 
    {
        background-color: #007bff;
        color:#fff;
    }

    table.dataTable td input[type="text"]
    {
       display: ruby-base-container;          
    }
     .hideAll  
     {
        visibility:hidden;
     }
    .loader 
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
@media print {
  header,footer { 
    display: none; 
  }
}      
 </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<div class="row">
    <div class ="col-md-12">
        <div class="card card-primary" style="margin-bottom: 5px;">
            <div class="card-header">
                <h3 class="card-title">CHANGE PASSWORD.</h3>
            </div>
            <div class="card-body" style="padding:0;">
                <div class="row">
                    <div class="col-sm-12 col-md-8">
                    <asp:HiddenField ID ="hdfempcd" runat="server" />
                    <asp:HiddenField ID ="hdfempnam" runat="server" />
                    <asp:HiddenField ID ="hdfdept" runat="server" />
                    <asp:HiddenField ID ="hdfdesig" runat="server" />
                    </div>
                    <div class="col-sm-12 col-md-2">
                            <div class="form-group row">
                                <label for="staticEmail" class="col-sm-6 col-form-label LabelAlign">Date</label>
                                <div class="col-sm-6">
                                    <input type="text" class="form-control-plaintext TextAlign" id="txtDate" readonly/>
                                </div>
                            </div>
                    </div>
                    <div class="col-sm-12 col-md-2">
                            <div class="form-group row">
                                <label for="staticEmail" class="col-sm-6 col-form-label LabelAlign">Time</label>
                                <div class="col-sm-6">
                                    <input type="text"  class="form-control-plaintext TextAlign" id="txtTime"  readonly/>
                                </div>
                            </div>
                    </div>                
                </div>
            </div> 
        </div>    
        <div class="card card-primary" style="margin-bottom: 5px;">
                <div class="card-header">
                    <h3 class="card-title">Filter Criteria</h3>
                </div>
                <div class="card-body" style="padding:0;">
                    <div class="row">
                        <div class="col-sm-12">
                           &nbsp;
                        </div> 
                    </div> 
                    <div class="row">
                        <div class="col-sm-12 col-md-6">
                                <div class="form-group row">
                                    <label for="staticEmail" class="col-sm-6 col-form-label LabelAlign">Location</label>
                                    <div class="col-sm-6">
                                        <input type="text" class="form-control-plaintext TextAlign" id="txtcomloc"  value="Dhaula" disabled/>
                                        <asp:HiddenField ID="hdfRetNo" runat="server" />
                                    </div>
                                </div>
                        </div>
                        <div class="col-sm-12 col-md-6">
                                <div class="form-group row">
                                    <label for="staticEmail" class="col-sm-6 col-form-label LabelAlign">Company</label>
                                    <div class="col-sm-6">
                                        <input type="text"  class="form-control-plaintext TextAlign" id="txtcomNam" value="IOLCP"  disabled />
                                    </div>
                                </div>
                        </div>
                        <div class="col-sm-12 col-md-6">
                                <div class="form-group row">
                                    <label for="staticEmail" class="col-sm-6 col-form-label LabelAlign">Employee Code</label>
                                    <div class="col-sm-6">
                                        <input type="text"  class="form-control-plaintext TextAlign" id="txtempcd" placeholder ="Employee Code" disabled />

                                    </div>
                                </div>
                        </div>
                        <div class="col-sm-12 col-md-6">
                                <div class="form-group row">
                                    <label for="staticEmail" class="col-sm-6 col-form-label LabelAlign">Employee Name</label>
                                    <div class="col-sm-6">
                                        <input type="text"  class="form-control-plaintext TextAlign" id="txtempnm" placeholder ="Employee Name" disabled />
                                    </div>
                                </div>
                        </div>
                        <div class="col-sm-12 col-md-6">
                                <div class="form-group row">
                                    <label for="staticEmail" class="col-sm-6 col-form-label LabelAlign">Current Password</label>
                                    <div class="col-sm-6">
                                        <input type="password"  class="form-control TextAlign" id="txtCurPas"  maxlength="50" />
                                    </div>
                                </div>
                        </div>
                        <div class="col-sm-12 col-md-6">
                                <div class="form-group row">
                                    <label for="staticEmail" class="col-sm-6 col-form-label LabelAlign">Change Password</label>
                                    <div class="col-sm-6">
                                        <input type="password"  class="form-control TextAlign" id="txtChaPas"   maxlength="50" />
                                    </div>
                                </div>
                        </div>
                        <div class="col-sm-12 col-md-6">
                                <div class="form-group row">
                                    <label for="staticEmail" class="col-sm-6 col-form-label LabelAlign">Confirm Password</label>
                                    <div class="col-sm-6">
                                        <input type="password"  class="form-control TextAlign" id="txtConPas" maxlength="50"/>
                                    </div>
                                </div>
                        </div>
                    </div>     
                     <div class ="row">
                        <div class ="col-12">
                            <div style ="float:right;">
                                <button type ="button"  class="btn btn-primary" id="btnChange" onclick="btnChange_click();" >Change</button>
                                <button type ="button" class="btn btn-primary" id="btnExit"  onclick="btnexit_click();">Exit</button>
                            </div>
                        </div>
                     </div>                                       
                </div> 
<%--                <div class="card-footer"> 
                </div>
--%>            </div>
    </div> 
    <!-- Loader -->
<div class="loader"></div> 
</div>

<!--Print Modal -->
<div class="modal fade" id="ShowModalPrint" tabindex="-1" role="dialog" aria-labelledby="ModalTitle" aria-hidden="true" data-backdrop="static" data-keyboard="false">
    <div class="modal-dialog  modal-xl" role="document">
        <div class="modal-content">
            <div class="modal-header">
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
                                    <div class ="table table-striped  dt-responsive" id="DIV1">
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
                <button type="button" id="btnPrint" class="btn btn-default" onclick="printData();">Print</button>
                <button type="button" id="btnClose" class="btn btn-default" data-dismiss="modal" aria-hidden="true" >Close</button>
            </div>
        </div>
    </div>
</div>


<div class ="row">
    <div class ="col">
    <asp:HiddenField ID="hdfUserID" runat="server" />
        <asp:Label ID="lblMessage" runat="server" style="color:#ff0000; font-weight:bold;"/>
    </div>
</div>
<!-- Loader -->
<div class="loader"></div> 

<script src="Scripts/JQuery/jquery.min.js" type="text/javascript"></script>
<script src="Scripts/JQuery/jquery-ui.min.js" type="text/javascript"></script>
<script src="Scripts/Password.js" type="text/javascript"></script>
<script src="Scripts/common-script.js" type="text/javascript"></script>
</asp:Content>

