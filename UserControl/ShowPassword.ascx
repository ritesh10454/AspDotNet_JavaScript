<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ShowPassword.ascx.vb" Inherits="UserControl_ShowPassword" %>

    <!--Search Modal -->
    <div class="modal fade" id="ShowPasswordModal" tabindex="-1" role="dialog" aria-labelledby="ModalTitle" aria-hidden="true" data-backdrop="static" data-keyboard="false">
        <div class="modal-dialog modal-dialog-centered" role="document">
            <div class="modal-content">
                <div class="modal-header bg-primary">
                <h3 class="modal-title" id="ModalTitle" style="color:White;">Authentication</h3>
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                </div>
                <div class="modal-body" style="padding-bottom:0;">
                    <div class="row">
                        <div class="col-sm-12 col-md-12"  id="userRow" style="display:none;" >
                            <div class="form-group row">
                                <label for="staticEmail" class="col-sm-3 col-form-label LabelAlign">User Name</label>
                                <div class="col-sm-9">                                    
                                    <input type="text"  class="form-control" id="txtUsrName" placeholder="User Name" />
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-12 col-md-12">
                            <div class="form-group row">
                                <label for="staticEmail" class="col-sm-3 col-form-label LabelAlign">Password</label>
                                <div class="col-sm-9">                                    
                                    <input type="password"  class="password form-control" id="txtPas"  ondrop="return false;" onpaste="return false;" onkeydown="return (event.keyCode!=13);" />
                                </div>
                            </div>
                        </div>                        
                    </div>
                    <div class="row">
                        <div class="col-sm-12 col-md-12">
                            <label id="lblPassword" class="form-control" style="text-align:center;color:Green;font-size:large;"></label>
                        </div>
                    </div>

                </div>
                <div class="modal-footer" style="padding:0;">
                    <button type="button" id="btnShowPassword" class="btn btn-primary"  aria-hidden="true" >Show</button>
                    <%--<button type="button" id="btnClose" class="btn btn-primary" data-dismiss="modal" aria-hidden="true" >Close</button--%>
                </div>
            </div>
        </div>
    <!-- Loader -->
        <div class="loader"></div> 
    </div>
