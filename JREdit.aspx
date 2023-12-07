<%@ Page Title="" Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="JREdit.aspx.vb" Inherits="JREdit" %>
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
        
    .show
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
                    <h3 class="card-title">JR Editing</h3>
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
<%--                    <div class="row">
                        <div class="col-sm-12 col-md-10"></div>
                        <div class="col-sm-12 col-md-2">
                            <div class="form-group row">
                                <label for="staticEmail" class="col-sm-6 col-form-label LabelAlign">Deptartment Name</label>
                                <div class="input-group col-md-6">                                    
                                    <input type="text"  class="form-control TextAlign" id="txtDeptcd" placeholder="Department Code" maxlength="4" value="0"  aria-label="Item Code" aria-describedby="basic-addon2"/>
                                    <div class="input-group-append">  
                                        <div class ="row"> 
                                            <div class ="col-12">                               
                                                <button type="button" id="btnSearch"  class="btn btn-primary" onclick="getList_click();"><i class="fas fa-search"></i></button>
                                            </div> 
                                        </div> 
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>--%>
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


    <!--  modal: custom confirmation  -->
    <div class="modal fade text-left" id="EditJRPopup" tabindex="-1" role="dialog" aria-labelledby="modal-help-title" aria-hidden="true" data-backdrop="static" data-keyboard="false">
      <div class="modal-dialog modal-dialog-centered" role="document" style="min-width: 80% !important;">
        <div class="modal-content">
          <div class="modal-header btn-primary">
            <button type="button" class="close" data-dismiss="modal" aria-hidden="true" style="display: none">&times;</button>
            <strong class="modal-title" id="modal-help-title">Edit JR</strong>
          </div><!--  /.modal-header  -->
          <div class="modal-body">
            <%--<p id="modal-help-text"></p>--%>
             <div class="row" id="JREntryDetail">
                    <div class="col-md-12">
                        <div class="card card-primary" style="margin-bottom: 5px;">
                            <div class="card-header">
                                <h3 class="card-title">
                                    Job Description</h3>
                            </div>
                            <div class="card-body" style="padding: 0;">
                                <div class="row" id="pnlctrl">
                                    <div class="col-sm-12 col-md-6">
                                        <div class="form-group row">
                                            <label for="staticEmail" class="col-sm-6 col-form-label LabelAlign">
                                                Select Department</label>
                                            <div class="col-sm-6">
                                                <select id="drpDepartment" class="form-control select2 myTab" tabindex="-1" onchange="drpDepartment_IndexChange();">
                                                    <option value="0">--Select--</option>
                                                </select>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-sm-12 col-md-6">
                                        <div class="form-group row">
                                            <label for="staticEmail" class="col-sm-6 col-form-label LabelAlign">
                                                Select Employee</label>
                                            <div class="col-sm-6">
                                                <select id="drpEmployee" class="form-control select2 myTab" tabindex="-1" onchange="drpEmployee_IndexChange();">
                                                    <option value="0">--Select--</option>
                                                </select>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-sm-12 col-md-6">
                                        <div class="form-group row">
                                            <label for="staticEmail" class="col-sm-6 col-form-label LabelAlign">
                                                Employee Name</label>
                                            <div class="col-sm-6">
                                                <input type="text" readonly class="form-control-plaintext TextAlign myTab" id="txtemployeename"
                                                    placeholder="Status" disabled required value="OPEN" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-sm-12 col-md-6">
                                        <div class="form-group row">
                                            <label for="staticEmail" class="col-sm-6 col-form-label LabelAlign">
                                                Employee Code</label>
                                            <div class="col-sm-6">
                                                <input type="text" readonly class="form-control-plaintext TextAlign myTab" id="txtemployeecode"
                                                    placeholder="Status" disabled required value="OPEN" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-sm-12 col-md-6">
                                        <div class="form-group row">
                                            <label for="staticEmail" class="col-sm-6 col-form-label LabelAlign">
                                                Designation / Grade</label>
                                            <div class="col-sm-6">
                                                <input type="text" readonly class="form-control-plaintext TextAlign myTab" id="txtDesignation"
                                                    placeholder="Status" disabled required value="OPEN" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-sm-12 col-md-6">
                                        <div class="form-group row">
                                            <label for="staticEmail" class="col-sm-6 col-form-label LabelAlign">
                                                Date of Joining</label>
                                            <div class="col-sm-6">
                                                <input type="text" readonly class="form-control-plaintext TextAlign myTab" id="txtdateofjoining"
                                                    placeholder="Status" disabled required value="OPEN" />
                                            </div>
                                        </div>
                                    </div>
                                    <%----------------------------------Editor----------------------------------%>
                                </div>
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="card card-outline card-info">
                                            <div class="card-header">
                                                <h3 class="card-title">
                                                    JR Detail
                                                </h3>
                                            </div>
                                            <!-- /.card-header -->
                                            <div class="card-body">
                                                <textarea class="col-md-12" id="txtjobdesc">Place <em>your</em> <u>text</u> <strong>here</strong> </textarea>
                                            </div>
                                            <div class="card-footer">
                                            </div>
                                        </div>
                                    </div>
                                    <!-- /.col-->
                                </div>
                                <%----------------------------------Editor----------------------------------%>
                                <%--------------Revision Section----------------%>
                                <div class="row" id="revision_no">
                                    <div class="col-6">
                                        <div class="col-sm-12 col-md-12">
                                            <div class="form-group row">
                                                <label for="staticEmail" class="col-sm-6 col-form-label LabelAlign">
                                                    Revision No</label>
                                                <div class="col-sm-6">
                                                    <input type="text" class="form-control myTab" id="txtRevisionNo" placeholder="Revision No"
                                                        ondrop="return false;" onpaste="return false;" onkeydown="return (event.keyCode!=13);"
                                                        onkeypress="return isNumberfloatKey(event,this,0);" onchange="txtRevisionNo_Change()" />
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-sm-12 col-md-12">
                                            <div class="form-group row">
                                                <label for="staticEmail" class="col-sm-6 col-form-label LabelAlign">
                                                    Supersede No</label>
                                                <div class="col-sm-6">
                                                    <input type="text" class="form-control" id="txtsupersedeno" placeholder="Supersede No"
                                                        ondrop="return false;" onpaste="return false;" onkeydown="return (event.keyCode!=13);"
                                                        onkeypress="return isNumberfloatKey(event,this,0);" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-6">
                                        <div class="col-sm-12 col-md-12" id="effectiveDt" style="display:none;">
                                            <div class="form-group row">
                                                <label for="staticEmail" class="col-sm-6 col-form-label LabelAlign">
                                                    Effective Date</label>
                                                <div class="col-sm-6">
                                                    <input type="text" class="form-control TextAlign datepicker myTab" id="txteffectivedate" required
                                                        placeholder="Effective Date"/>
                                                </div>
                                            </div>
                                        </div>  
                                        <div class="col-sm-12 col-md-12">
                                            <div class="form-group row">
                                                <label for="staticEmail" class="col-sm-6 col-form-label LabelAlign">
                                                    Revision</label>
                                                <div class="col-sm-6">
                                                    <textarea class="form-control myTab" id="txtreason" required placeholder="Reason For Revision"> </textarea>
                                                </div>
                                            </div>
                                        </div>                                                  
                                    </div>
                                </div>
                                <%--------------Revision Section----------------%>
                                <%--------------Revision History----------------%>
                                <div class="row">
                                    <div class="col-sm-12">
                                        <div class="card-header">
                                            <h3 class="card-title">
                                                JR Revision History</h3>
                                        </div>
                                        <div class="form-group row">
                                            <div class="table table-bordered table-striped  dt-responsive" id="JRRevisionDIV"
                                                style="width: 100%;">
                                                <!--style="overflow:scroll;"-->
                                                <table id="JRRevisionTable" border="0" cellpadding="0" cellspacing="0" class="table table-striped"
                                                    style="width: 100%;">
                                                    <thead>
                                                        <tr>
                                                            <th>
                                                                Sr No
                                                            </th>
                                                            <th>
                                                                Revision No
                                                            </th>
                                                            <th style="display:none;">
                                                                Effective Date
                                                            </th>
                                                            <th>
                                                                Supersede No
                                                            </th>
                                                            <th>
                                                                Reason
                                                            </th>
                                                        </tr>
                                                    </thead>
                                                </table>
                                            </div>
                                            <asp:Label ID="Label1" runat="server" Style="text-align: center; color: Red; font-weight: bold;"></asp:Label>
                                            <%--<asp:HiddenField ID="hdfempcd" runat="server" />--%>
                                        </div>
                                    </div>
                                </div>
                                <%--------------Revision History----------------%>
                                <div class="row" style="margin-top: 10px;">
                                    <div class="col-sm-12 col-md-6">
                                        <div style="float: right;">
                                            <%-- <button class="btn-primary" id="btnCheck" onclick="btnCheck_Click(this);"><i class="fa fa-home"></i>Validate</button>--%>
                                            <button type="button" class="btn btn-primary" id="btnCheck" style="display: none;" disabled onclick="btnCheck_Click();">Validate</button>
                                            <%--<button type="button" class="btn btn-primary" id="btnSave" onclick="btnSave_Click();">Save</button>--%>
                                            <button type="button" class="btn btn-primary" id="btnaction" style="display: none;" disabled onclick="btnaction_Click();">Forward</button>
                                            <button type="button" class="btn btn-primary" id="btnPrint" style="display: none;" disabled onclick="btnPrint_Click(this);">Print</button>
                                            <button type="button" class="btn btn-primary" id="btncancel" style="display: none;" disabled onclick="btncancel_Click();">Back to Inbox</button>
                                            <%--<button type="button" class="btn btn-primary" id="Button1" onclick="btnexit_click();">Exit</button>--%>
                                            <asp:TextBox ID="TextBox1" runat="server" Visible="False"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="card-footer">
                            </div>
                            <div class="loader">
                            </div>
                        </div>
                    </div>
                </div>





          </div><!--  /.modal-body  -->
          <div class="modal-footer">
            <button type="button" class="btn btn-primary" id="btnSave" onclick="btnSave_Click();">Update</button>
            <button type="button" class="btn btn-danger btn-cancel"  data-dismiss="modal">Close</button>
          </div><!--  /.modal-footer  -->
        </div><!--  /.modal-content  -->
      </div><!--  /.modal-dialog  -->
    </div><!--  /.modal  -->





<Sp:ShowPassword ID="showPass1" runat="server" />




<div class="row">
    <div class="col">
        <asp:HiddenField ID="hdfUserID" runat="server" />
        <asp:Label ID="lblMessage" runat="server" Style="color: #ff0000; font-weight: bold;" />
        <asp:Label ID="lbldeptcd" runat="server" Hidden="true" Style="color: #ff0000; font-weight: bold;" />
        <asp:Label ID="lbldesigcd" runat="server" Hidden="true" Style="color: #ff0000; font-weight: bold;" />
        <asp:Label ID="lblcatgcd" runat="server" Hidden="true" Style="color: #ff0000; font-weight: bold;" />
        <asp:Label ID="lblcatgnm" runat="server" Hidden="true" Style="color: #ff0000; font-weight: bold;" />
        <asp:Label ID="lblf_hdr_id" runat="server" Hidden="true" Style="color: #ff0000; font-weight: bold;" />
    </div>
</div>




<!-- Loader -->
<div class="loader">
</div>
<script src="Scripts/JQuery/jquery.min.js" type="text/javascript"></script>
<script src="Scripts/JQuery/jquery-ui.min.js" type="text/javascript"></script>
<script src="Scripts/JREdit.js" type="text/javascript"></script>
<script src="Scripts/common-script.js" type="text/javascript"></script>
</asp:Content>

