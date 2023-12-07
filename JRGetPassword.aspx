<%@ Page Title="" Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="JRGetPassword.aspx.vb" Inherits="JRGetPassword" %>
<%@ Register Src="UserControl/Breadcrumb.ascx" TagPrefix="Bc" TagName="Bread" %>
<%@ Register Src="UserControl/ShowPassword.ascx" TagPrefix="Sp" TagName="ShowPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
<style type ="text/css">  
     .ButtonRightAlign
    {
        float:right;
    }        
         
    th, td {
        white-space: nowrap;
    }  
    
    .dataTables_empty {
        padding-left:84px !important;
    }
	
	div.dataTables_wrapper {
		margin: 0 auto;
	}	
	

    .dataTables_scroll
    {
        overflow:auto;
    } 
    
    .userpass
    {
        display:none;
        } 
        
   
  
        input[type=text]:focus, input[type=password]:focus
    {
        background-color:lightyellow;
        border: 1px solid #ccc;
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
   
    .buttonF
    {
        font-size:12px;
        font-family: "Calibri";       
    } 
	
	.dataTables_info
	{
		padding-left: 14px;
	}
	
	    .LabelAlign
    {
        text-align:right;
    }
     
    .TextAlign
    {
        text-align:left;
    }
    
    .note-editable
    {
        height: 250px;
    }
    
    .capitalLetter
    {
        text-transform:capitalize;
    }

 </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div class="row">
        <div class="col-md-12">
            <div class="card card-primary" style="margin-bottom: 5px;">
                <div class="card-header">
                    <h3 class="card-title">JR Password Recovery</h3>
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
                                    <input type="text" class="form-control-plaintext TextAlign" id="txtTime"  />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="card card-primary" style="margin-bottom: 5px;">
                <div class="card-header">
                    <div class="row">
                        <div class="col-sm-12 col-md-4">
                            <h3 class="card-title" id="H1">Search </h3>
                        </div>
                        <div class="col-sm-12 col-md-8">
                            <div class="from-group" style="height: 27px;margin-top: -8px;">
                                <div class="col-sm-12" data-toggle="buttons">
                                    <label class="btn btn-primary active"><input type="radio" name="getPass" value="D" checked/>Department Wise</label>
                                    <label class="btn btn-primary"><input type="radio" name="getPass" value="E"/>Employee Wise</label>
                                </div>
                            </div> 
                        </div>
                    </div>                   
                </div>
                <div class="card-body" style="padding: 0;">
                    <div class="row">
                        <div class="col-sm-12 col-md-10"></div>
                        <div class="col-sm-12 col-md-2">
                            <div class="form-group row" id="departmentDisplay">
                                <label for="staticEmail" class="col-sm-6 col-form-label LabelAlign">Deptartment Code</label>
                                <div class="input-group col-md-6">                                    
                                    <input type="text"  class="form-control TextAlign" id="txtDeptcd" placeholder="Department Code" maxlength="4" value="0"  aria-label="Item Code"  onkeypress="return isNumberfloatKey(event,this,0);" aria-describedby="basic-addon2"/>
                                    <div class="input-group-append">  
                                        <div class ="row"> 
                                            <div class ="col-12">                               
                                                <button type="button" id="btnSearchDepartmentEmployee"  class="btn btn-primary" onclick="getList_click();"><i class="fas fa-search"></i></button>
                                            </div> 
                                        </div> 
                                    </div>
                                </div>
                            </div>

                            <div class="form-group row" id="employeedisplay">
                                <label for="staticEmail" class="col-sm-6 col-form-label LabelAlign">Employee Code</label>
                                <div class="input-group col-md-6">                                    
                                    <input type="text"  class="form-control TextAlign capitalLetter" id="txtEmpcd" placeholder="Emp. Code" maxlength="7"  aria-label="Item Code"  aria-describedby="basic-addon2"/>
                                    <div class="input-group-append">  
                                        <div class ="row"> 
                                            <div class ="col-12">                               
                                                <button type="button" id="btnSearchEmployee"  class="btn btn-primary" onclick="getList_click();"><i class="fas fa-search"></i></button>
                                            </div> 
                                        </div> 
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="card card-primary" style="margin-bottom: 5px;">
                <div class="card-body" style="padding: 0;">
                    <div class="row">
                        <div class="col-sm-12">
                            <div class="form-group row">
								<div class="table table-bordered table-striped  dt-responsive" id="jrDetailDIV" style="width: 100%;"></div>
                            </div>
                        </div>
                    </div>
					<div class="row">
						<div class="col-12">
							<div style="float: right;">
								<button type="button" class="btn btn-primary" id="btnExit" onclick="btnexit_click();">Exit</button>
							</div>
						</div>
					</div>
					<div class="row">
						<div class="col"></div>
					</div>				
				</div>
			</div>
		</div>
</div>

<Sp:ShowPassword ID="showPass1" runat="server" />




<div class="row">
    <div class="col">
        <asp:HiddenField ID="hdfUserID" runat="server" />
        <asp:Label ID="lblMessage" runat="server" Style="color: #ff0000; font-weight: bold;" />
    </div>
</div>




<!-- Loader -->
<div class="loader">
</div>
<script src="Scripts/JQuery/jquery.min.js" type="text/javascript"></script>
<script src="Scripts/JQuery/jquery-ui.min.js" type="text/javascript"></script>
<script src="Scripts/JRGetPassword.js" type="text/javascript"></script>
<script src="Scripts/common-script.js" type="text/javascript"></script
</asp:Content>

