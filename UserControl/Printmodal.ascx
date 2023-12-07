<%@ Control Language="VB" AutoEventWireup="false" CodeFile="Printmodal.ascx.vb" Inherits="UserControl_Printmodal" %>

    <div class="modal fade" id="ShowModalPrint" tabindex="-1" role="dialog" aria-labelledby="ModalTitle" aria-hidden="true" data-backdrop="static" data-keyboard="false">
        <div class="modal-dialog  modal-xl" role="document">
            <div class="modal-content">
                <div class="modal-header btn-primary">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true" style="display: none">&times;</button>
                    <h4 class="modal-title" id="H1">INDIVIDUAL JOB RESPONSIBILITIES</h4>
                 </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-12">
                            <div id="OutputPrint" class="printfont">
                            </div> 
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                <%--<button type="button" id="Button2" class="btn btn-default" onclick="JRprintData();">Print</button>--%>
                    <button type="button" id="btnPrint" class="btn btn-default" onclick="printData();">Print</button>
                    <button type="button" id="Button1" class="btn btn-default" data-dismiss="modal" aria-hidden="true">Close</button>
                </div>
            </div>
        </div>
    </div>
