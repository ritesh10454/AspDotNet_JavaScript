<%@ Page Title="" Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="JRRole.aspx.vb" Inherits="JRRole" %>
<%@ Register Src ="UserControl/Breadcrumb.ascx" TagPrefix ="Bc" TagName ="Bread" %>

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
    

    #loader2 
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
	
 </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<div class="row">
        <div class="col-md-12">
            <div class="card card-primary" style="margin-bottom: 5px;">
                <div class="card-header">
                    <h3 class="card-title" id="jrListID">JR Roles</h3>
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
                <div class="card-body" style="padding: 0;">
                    <div class="row">
                        <div class="col-sm-12">
                            <div class="form-group row">
								<div class="table table-bordered table-striped  dt-responsive" id="PendingJRDIV" style="width: 100%;">
									<table id="JRRoleTable" border="0" cellpadding="0" cellspacing="0" class="table table-bordered table-striped dt-responsive" style="width: 100%;">
										<thead>
											<tr>
												<th>ID</th>
												<th>Roles</th>
											</tr>
										</thead>
									</table>
								</div>
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

<!-- Loader -->
<div id="loader2">
</div>
<script src="Scripts/JQuery/jquery.min.js" type="text/javascript"></script>
<script src="Scripts/JQuery/jquery-ui.min.js" type="text/javascript"></script>
<script src="Scripts/JRRole.js" type="text/javascript"></script>
<script src="Scripts/common-script.js" type="text/javascript"></script>
</asp:Content>

