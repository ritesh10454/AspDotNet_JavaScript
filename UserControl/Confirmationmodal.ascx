<%@ Control Language="VB" AutoEventWireup="false" CodeFile="Confirmationmodal.ascx.vb" Inherits="UserControl_Confirmationmodal" %>

    <!--  modal: custom confirmation  -->
    <div class="modal fade text-left" id="confirmation" tabindex="-1" role="dialog" aria-labelledby="modal-help-title" aria-hidden="true" data-backdrop="static" data-keyboard="false">
      <div class="modal-dialog" role="document">
        <div class="modal-content">
          <div class="modal-header btn-primary">
          <button type="button" class="close" data-dismiss="modal" aria-hidden="true" style="display: none">&times;</button>
            <strong class="modal-title" id="modal-help-title">Confirm</strong>
          </div><!--  /.modal-header  -->
          <div class="modal-body">
            <p id="modal-help-text"></p>
          </div><!--  /.modal-body  -->
          <div class="modal-footer">
            <button type="button" class="btn btn-primary btn-ok"  data-dismiss="modal">Yes</button>
            <button type="button" class="btn btn-danger btn-cancel"  data-dismiss="modal">No</button>
          </div><!--  /.modal-footer  -->
        </div><!--  /.modal-content  -->
      </div><!--  /.modal-dialog  -->
    </div><!--  /.modal  -->
