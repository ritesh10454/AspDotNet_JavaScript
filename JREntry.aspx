<%@ Page Title="" Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false"  ClientIDMode="Static" CodeFile="JREntry.aspx.vb" Inherits="JREntry" %>

<%@ Register Src="UserControl/Breadcrumb.ascx" TagPrefix="Bc" TagName="Bread" %>
<%@ Register Src="~/UserControl/Confirmationmodal.ascx" TagPrefix="cm" TagName="conMod" %>
<%@ Register Src="~/UserControl/Printmodal.ascx" TagPrefix="pm" TagName="printMod" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <!-- summernote -->
    <link rel="stylesheet" type="text/css" href="AdminLte/plugins/summernote/summernote-bs4.min.css" />
  <%--  <link  rel="stylesheet" type="text/css" href="Styles/printJR.css" media="print" />--%>
    <link href="Styles/PrintNew.css" rel="stylesheet" type="text/css" media="print" />
    <style type="text/css">
        .LabelAlign
        {
            text-align: right;
        }
        
        .TextAlign
        {
            text-align: left;
        }
        .loader
        {
            position: fixed;
            left: 0px;
            opacity: 0.9;
            top: 0px;
            width: 100%;
            height: 100%;
            z-index: 9999;
            background: rgb(201, 201, 201) url('AdminLte/dist/img/waiting.gif') no-repeat 50% 50%;
        }
        
        th, td
        {
            white-space: nowrap;
        }
        
          input[type=text]:focus, input[type=password]:focus
        {
            background-color:lightyellow;
            border: 1px solid #ccc;
        }   
        
        
        .wrapContent
        {
            white-space: normal !important;
        }
        
        .controlSize
        {
            padding-left: 3px !important;
            padding-right: 3px !important;
        }
        
        .dropDowntext
        {
            padding-top: 0;
        }
        
        .tabcolor
        {
            border-color: #C80000;
        }
        
        .tdPadding
        {
            padding-top: -0.625rem;
            margin-bottom: 0;
            font-size: 12px;
            font-family: "Calibri";
            margin-top: -5px !important;
            height: calc(2.25rem + 2px);
        }
        
        .note-editable
        {
            height: 250px;
        }
        
        .modal-full {
            min-width: 100%;
            margin: 0;
        }

        .modal-full .modal-content {
            min-height: 100%;
        }
        
        .modal-dialog {
            -webkit-transform: translate(0,-50%);
            -o-transform: translate(0,-50%);
            transform: translate(0,-50%);
            top: 40%;
            margin: 0 auto;
        }
        

        
        
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
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
                                <button type="button" class="btn btn-primary" id="btnSave" onclick="btnSave_Click();">Save</button>
                                <button type="button" class="btn btn-primary" id="btnaction" style="display: none;" disabled onclick="btnaction_Click();">Forward</button>
                                <button type="button" class="btn btn-primary" id="btnPrint" style="display: none;" disabled onclick="btnPrint_Click(this);">Print</button>
                                <button type="button" class="btn btn-primary" id="btncancel" style="display: none;" disabled onclick="btncancel_Click();">Back to Inbox</button>
                                <button type="button" class="btn btn-primary" id="Btnexit" onclick="btnexit_click();">Exit</button>
                                <asp:TextBox ID="TextBox1" runat="server" Visible="False"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="card-footer">
                </div>
                <div class="loader"></div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col">
            <asp:HiddenField ID="hdfUserID" runat="server" />
            <asp:Label ID="lblMessage" runat="server" Style="color: #ff0000; font-weight: bold;" />
            <%--<asp:Label ID="lblMessage2" runat="server" Style="color: #ff0000; font-weight: bold;" />--%>
            <asp:Label ID="lbldeptcd" runat="server" Hidden="true" Style="color: #ff0000; font-weight: bold;" />
            <asp:Label ID="lbldesigcd" runat="server" Hidden="true" Style="color: #ff0000; font-weight: bold;" />
            <asp:Label ID="lblcatgcd" runat="server" Hidden="true" Style="color: #ff0000; font-weight: bold;" />
            <asp:Label ID="lblcatgnm" runat="server" Hidden="true" Style="color: #ff0000; font-weight: bold;" />
            <asp:Label ID="lblf_hdr_id" runat="server" Hidden="true" Style="color: #ff0000; font-weight: bold;" />
        </div>
    </div>
    <!--Search Modal -->
    <div class="modal fade" id="ShowItemsModal" tabindex="-1" role="dialog" aria-labelledby="ModalTitle"
        aria-hidden="true" data-backdrop="static" data-keyboard="false">
        <div class="modal-dialog modal-xl" role="document">
            <div class="modal-content">
                <div class="modal-header bg-primary">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true" style="display: none">&times;</button>
                    <h4 class="modal-title" id="ModalTitle">
                        Search</h4>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-sm-12 col-md-12" id="Div1">
                            <div class="form-group row">
                                <label for="staticEmail" class="col-sm-3 col-form-label LabelAlign">
                                    Enter Text</label>
                                <div class="col-sm-6">
                                    <input type="text" class="form-control" id="txtItemCode" placeholder="Enter Item Code" />
                                </div>
                                <div class="col-sm-3">
                                    <button type="button" id="btnItemSearch" class="btn btn-primary" onclick="btnItemSearch_Click();">
                                        Search</button>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-12 col-md-12" id="Div2">
                            <div class="form-group row">
                                <label for="staticEmail" class="col-sm-3 col-form-label LabelAlign">
                                    Select Item</label>
                                <div class="col-sm-6">
                                    <select id="ddSubItem" class="form-control select2 myTab" tabindex="-1" onchange="ddSubItem_IndexChanged();">
                                        <option value="0">--Select--</option>
                                    </select>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <%--button type="button" id="btnItemSearch" class="btn btn-default" data-dismiss="modal" aria-hidden="true" onclick= >Search</button>--%>
                    <button type="button" id="btnClose" class="btn btn-primary" data-dismiss="modal"
                        aria-hidden="true">
                        Close</button>
                </div>
            </div>
        </div>
        <!-- Loader -->
        <div class="loader">
        </div>
    </div>

    <cm:conMod ID="confirmation1" runat="server" />

    <pm:printMod ID="PrintModal1" runat="server" />

    <!-- Lo -->
    <div class="loader"></div>
    <%--</div>--%>
    <script src="Scripts/JQuery/jquery.min.js" type="text/javascript"></script>
    <script src="Scripts/JQuery/jquery-ui.min.js" type="text/javascript"></script>
    <script src="Scripts/JREntry.js" type="text/javascript"></script>
    <script src="Scripts/PrintJR.js" type="text/javascript"></script>
    <script src="Scripts/common-script.js" type="text/javascript"></script>
    <%--<script src="AdminLte/plugins/summernote/summernote-bs4.min.js" type="text/javascript"></script>--%>
    <%--Page specific script--%>
    <script type="text/javascript">
        $(function () {
            // Summernote
            $('#txtjobdesc').summernote();

        })
    </script>
</asp:Content>
