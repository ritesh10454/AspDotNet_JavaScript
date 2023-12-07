var PRP_Department_List;
var table;
Timer();

var $ = jQuery.noConflict();

$(document).ready(function () {
    ChangeBreadCrumb("Report", "JR List", "Report");
    $("#issueBody").addClass("sidebar-collapse");
    changeDate();
    $(".loader").fadeOut();
    $(this).find("#txtDeptcd").focus();
    $("[id*=departmentDisplay]").show();
    $("[id*=employeedisplay]").hide();
//    userDetail();
   // BindGrid();
});

function Timer() {
    var currdt = new Date();
    $("#txtTime").val(formatAMPM1(currdt));
    setTimeout(Timer, 500);
}

function changeDate() {
    var currdt = new Date();
    var mth = (currdt.getMonth()+1);
    var dy = currdt.getDate();
    var yr =Math.abs(currdt.getFullYear());
    if (mth < 10) {   mth = '0' + mth; }
    if (dy < 10) {   dy = '0' + dy; }
    var dt =mth + '/' + dy + '/' + yr;
    $("#txtDate").val(dy + '/' + mth + '/' + yr);
    $("[id*=hdfDate]").val(ChangeDateFormat(dt));
    $("#txtFroDat").val(dy + '/' + mth + '/' + yr);
    $("#txtToDat").val(dy + '/' + mth + '/' + yr);
}

function getQueryVariable(variable) {

    var query =window.location.search.substring(1);
    var vars = query.split("&");
    for (var i = 0; i < vars.length; i++) {
        var pair = vars[i].split("=");
        if (pair[0] == variable) { return pair[1]; }
    }
    return (false);
}



function formatAMPM(date) {
    var hours = date.getHours();
    var minutes = date.getMinutes();
    var ampm = hours >= 12 ? 'pm' : 'am';
    hours = hours % 12;
    hours = hours ? hours : 12; // the hour '0' should be '12'
    minutes = minutes < 10 ? '0' + minutes : minutes;
    var strTime = hours + ':' + minutes + ' ' + ampm;
    return strTime;
}

function formatAMPM1(date) {
    var hours = date.getHours();
    var minutes = date.getMinutes();
    var seconds = date.getSeconds();
    hours = hours < 10 ? '0' + hours : hours;
    minutes = minutes < 10 ? '0' + minutes : minutes;
    seconds = seconds < 10 ? '0' + seconds : seconds;
    var strTime = hours + ':' + minutes + ':' + seconds 
    return strTime;
}




function ChangeDateFormat(dt) {
    var formatted_date = "";
    if (dt == null || dt == "") return formatted_date;
    var d = new Date(dt);
    var month = d.getMonth();
    var date = d.getDate();
    var year =Math.abs(d.getFullYear());
    if (month < 10) {   month = '0' + month; }
    if (date < 10) {   date = '0' + date; }
    var months = ["JAN", "FEB", "MAR", "APR", "MAY", "JUN", "JUL", "AUG", "SEP", "OCT", "NOV", "DEC"];
    // let current_datetime = new Date()
    var formatted_date = date + "-" + months[parseInt(month)] + "-" + year;
    return formatted_date;
}

String.format = function () {
    // The string containing the format items (e.g. "{0}")
    // will and always has to be the first argument.
    var theString = arguments[0];
    // start with the second argument (i = 1)
    for (var i = 1; i < arguments.length; i++) {
        // "gm" = RegEx options for Global search (more than one instance)
        // and for Multiline search
        var regEx = new RegExp("\\{" + (i - 1) + "\\}", "gm");
        theString = theString.replace(regEx, arguments[i]);
    }
    return theString;
}


 $(".datepicker").datepicker({
    dateFormat: "dd-mm-yy",     // SET THE FORMAT.
    changeMonth: true,
    changeYear: true,
    yearRange: '1950:2100',
    inline: true,
    showAnim: 'fadeIn',
    showButtonPanel: true,
    closeText: 'Clear',
    beforeShow: function (input) 
	{
        setTimeout(function () 
		{
            var clearButton = $(input)
            .datepicker("widget")
            .find(".ui-datepicker-close");
            clearButton.unbind("click").bind("click", function () { $.datepicker._clearDate(input); });
        }, 1);
    },
    onClose: function (e) 
	{
		var ev = window.event;
		if (ev.srcElement.innerHTML == 'Clear')
		{
			this.value = "";
		}
    },
    closeText: 'Clear',
});


function DateInYYYYMMDD(date) 
{
    var dateOut = date.split(/[/,-]/); //  (/[!,?,/,-,.]/);  //    .toString().split("/").split("-");
    var resultDate = new Date(dateOut[2] + "/" + dateOut[1] + "/" + dateOut[0]);
    return resultDate; 
}

$("[id*=txtDeptcd]").keydown(async function(e){
    if(e.which==13)
    {
        getList_click();
    }
});


$("[id*=txtEmpcd]").keydown(async function(e){
    if(e.which==13)
    {
        getList_click();
    }
});


$("input[type=radio]").on('change',function() {
   if($(this).val()=="D")
   {
        $("[id*=txtDeptcd]").val(0);
        $("[id*=departmentDisplay]").show();
        $("[id*=employeedisplay]").hide();
        $("[id*=departmentDisplay]").val(0);
   }
   else if($(this).val()=="E")
   {
        $("[id*=txtEmpcd]").val("");
        $("[id*=departmentDisplay]").hide();
        $("[id*=employeedisplay]").show();
        $("[id*=employeedisplay]").val("");
   }
});


async function getList_click()
{
 var par=null; var ErrMsg=null; var st=""; var tval=0;
    try 
    {
        $(".loader").fadeIn();
        var txtDeptcd = $("[id*=txtDeptcd]");
        var txtEmpcd=$("[id*=txtEmpcd]");
        var objPrpUsrLogDtl= [];
        var row={};
//        var deptcd = txtDeptcd.val();
//        res= await GetJRDetailforEditing(deptcd);
        var res=null;
        if($("[id*=departmentDisplay]").is(":visible"))
        {
            res= await GetJRDetailforEditingDepartmentWise(txtDeptcd.val());
        }
        else
        {
           res= await GetJRDetailforEditingEmployeeWise(txtEmpcd.val());
        }
        if (res.response == -1) 
		{
            $('#JRDetailTable').dataTable().fnClearTable();
            $(".dataTables_length").hide();       //  -----Hide Show Number of Entry 
            $(".dataTables_filter").hide();   //--HIde Search label and textbox         });
            setTimeout(function(){$.fn.dataTable.tables( { visible: false, api: true } ).columns.adjust().fixedColumns().relayout();}, 100);
			ErrMsg= res.responseMsg;
			throw ErrMsg;
        }

        var myData = res.responseObjectList;
        var res = await createDataTable(myData);
        if (res != "OK") 
        {
            ErrMsg = "Error found during Populate Grid";
            $(".loader").fadeOut();
            throw ErrMsg;
        }    
         MakeDataTable();
         $(".loader").fadeOut();
    } 
    catch (err) 
    {
         $("[id*=lblMessage]").text(err).css('color', '#ff0000'); // Red color
    }
    finally
    {
     $(".loader").fadeOut();
    }
    
}

function MakeDataTable()
{
 table=  $("#JRDetailTable").removeAttr("width").DataTable({
        "JQueryUI" : false,
        "paging": false,
        "processing": true,
        "deferRender" : true,
        "destroy": true,  
        "language": {
            "emptyTable": "No Data Found"
        },
        "fixedColumns": {
            "leftColumns": "2"
        },
        "scrollY": "400",
        "scrollX": "true",
        'order':[],
        'columnDefs': [{
            "targets": 0,
            "orderable": false
        }]
    });

    $(".dataTables_length").hide();       //  -----Hide Show Number of Entry 
    $(".dataTables_filter").hide();   //--HIde Search label and textbox         });
    table.order( [ 0, 'desc' ] ).draw();
    setTimeout(function(){$.fn.dataTable.tables( { visible: false, api: true } ).columns.adjust().fixedColumns().relayout();}, 1000);
}




function createDataTable(myData)
{
  return new Promise(function (resolve, reject) 
  {
        var newRows = "";
        var tot=0;
        var tableHeading='<table id="JRDetailTable" border="0" cellpadding="0" cellspacing="0" class="table table-bordered table-striped dt-responsive" style="width: 100%;"><thead><tr><th>JR ID</th><th>Employee Code</th><th>Employee Name</th><th>Department Code</th><th>Department Name</th><th>Designation Name</th><th>Revision_No</th><th>Select</th><th class="userpass">Password</th><th class="show">Login</th></tr></thead>';
        newRows += tableHeading;
        for (var i = 0; i < myData.length; i++) 
        {
              newRows +=    '<tr><td class="id">' + myData[i].Id  + 
                            '</td><td class="emp_cd">' + myData[i].emp_cd + 
                            '</td><td class="emp_nm">' + myData[i].emp_nm   +  
                            '</td><td class="dept_cd">' + myData[i].dept_cd   +  
                            '</td><td class="dept_nm">' + myData[i].dept_nm   +  
                            '</td><td class="desig_nm">' + myData[i].desig_nm   +  
                            '</td><td class="revision_no">' + myData[i].revision_no + 
                            '</td><td class="print"><input type="button" id="btnSelect" class="btn btn-primary buttonF" value="Select"  onclick ="btnSelect_Click(this);" />' +
                            '</td><td class="userpass">' + myData[i].userpass + 
                            '</td><td class="show"><input type="button" id="btnShow" class="btn btn-primary buttonF" value="Show Password"  onclick ="btnShow_Click(this);" /></tr>';
        }
        newRows +='</tbody>';
        newRows +='</table>';
        document.getElementById("jrDetailDIV").innerHTML = newRows;
        $("[id*=lblMessage]").text("");
            resolve("OK");
    });
}


function btnShow_Click(ctl)
{
    var mytag = 30; var mytag1 = 7;
    var row=$(ctl).closest("tr"); 
    var rowIndex= row[0].sectionRowIndex; 
    var cols= row.find('td');
    var lblJrId = parseInt($(cols[0]).text());
    var lblempcd = $(cols[1]).text();    
    var lblpass=$(cols[8]).text();  

    $("[id*=txtPas]").val("");
    $("[id*=lblMessage]").text("");
    $("[id*=lblPassword]").text(""); 
    $("[id*=txtPas]").focus();
    $("#ShowPasswordModal").modal("toggle");

    $("[id*=btnShowPassword]").click(async function(e){
        $(this).unbind('click');
        if ($("[id*=txtPas]").val().trim()=="HRM") {
            var getPass=await decryptQueryString(lblpass.toString().trim());
            $("[id*=lblPassword]").text(getPass);
        }   
    });

}



async function btnSelect_Click(ctl)
{
    $('#txtjobdesc').summernote();
    $("#EditJRPopup").modal("toggle");

    $(".loader").fadeIn();
    var ErrMsg=null;
    var mytag = 30; var mytag1 = 7;
    var row=$(ctl).closest("tr"); 
    var rowIndex= row[0].sectionRowIndex; 
    var cols= row.find('td');
    var lblJrId = parseInt($(cols[0]).text());
    var lblempcd = $(cols[1]).text();
    var lblempnm = $(cols[2]).text();
    var lbldeptcd = $(cols[3]).text();
    var lbldeptnm = $(cols[4]).text();
    var lbldesignnm =  $(cols[5]).text();
    var lblrevisionno = parseInt($(cols[6]).text());
    try 
    {
        var usercd= await  getSessionVariables();
        if (usercd.length ==0)
        {
            $("[id*=lblMessage]").text("Session Expired").css('color', '#ff0000'); // Red color
            toastr.error("Session Expired", {timeOut: 200});
            setTimeout(window.location.href = "Account/Login.aspx", 10000);
            return;
        }
        if(usercd.length > 0)
        {
            ControlBlank();
            $("[id*=hdfUserID]").val(usercd.toString());
            var empcd = lblempcd.toString().trim();
            var jrId = parseInt(lblJrId.toString().trim()); 
            if(jrId!=0)
            {
                obj = await getDepartmentList(empcd.toString().trim());
            }
            else {
                obj = await getDepartmentListtoFirstAuthority(empcd.toString().trim());
            }
             
            if (obj.response ==-1) {
                ErrMsg=  obj.responseMsg;
			    throw ErrMsg;
            }
            var myObj = obj.responseObjectList;   

            PRP_Department_List = myObj;   

            $("[id*=btnSave]").text("Save");
            Department=null; Department ='<option value="0">--Select--</option>'
            $.each(PRP_Department_List,function(){
                Department += '<option value="'+this["dept_cd"]+'">'+this["dept_nm"]+' </option>';
            });
            $("[id*=drpDepartment]").empty();
            $("[id*=drpDepartment]").append(Department);
            $("[id*=txtRevisionNo]").attr("disabled","disabled");
            $("[id*=txtsupersedeno]").attr("disabled","disabled");

            var currdt= new Date();
            $("[id*=txteffectivedate]").val(Convert_DateInStringFormat(currdt));
            var deptcd =parseInt(lbldeptcd.toString()); 
            if(jrId!=0)
            {
                $("[id*=btnSave]").text("Update");    
                $("[id*=drpDepartment] option:selected").removeAttr("selected");
                $("[id*=drpDepartment] option[value='" + deptcd +"']").attr('selected', 'selected');
                $("[id*=drpDepartment]").attr("disabled", "disabled");

                res =await GetEmployeeDetail(empcd.toString().trim());
                if (res.response == -1) {
                    ErrMsg =(res.responseMsg);
                    throw ErrMsg;
                }
                var objprpemployeedetail= res.responseObject;
                $("[id*=txtDesignation]").val(objprpemployeedetail.desig_nm);
                $("[id*=txtemployeename]").val(objprpemployeedetail.emp_nm);
                $("[id*=txtemployeecode]").val(objprpemployeedetail.emp_cd);
                $("[id*=txtdateofjoining]").val(objprpemployeedetail.dt_join);
                $("[id*=lbldeptcd]").text(objprpemployeedetail.dept_cd)
                $("[id*=lbldesigcd]").text(objprpemployeedetail.desig_cd)
                $("[id*=lblcatgcd]").text(objprpemployeedetail.catg_cd)
                $("[id*=lblcatgnm]").text(objprpemployeedetail.catg_nm)

                if ($("[id*=drpDepartment] option:Selected").val() != "0" )
                {            
                    var res =await getEmployee(drpDepartment.value);
                    if (res.response == -1) {
                        ErrMsg =(res.responseMsg);
                        throw ErrMsg;
                    }
                    var objprpemployee= res.responseObjectList;

                    var Employee=null; Employee ='<option value="0">--Select--</option>'
                    $.each(objprpemployee,function(){
                        Employee += '<option value="'+this["emp_cd"]+'">'+this["emp_nm"]+' </option>';
                    });
                    $("[id*=drpEmployee]").empty();
                    $("[id*=drpEmployee]").append(Employee);

                    $("[id*=drpEmployee] option:selected").removeAttr("selected");
                    $("[id*=drpEmployee] option[value='" + empcd +"']").attr('selected', 'selected');
                    $("[id*=drpEmployee]").attr("disabled", "disabled");  
                    $(".note-editable").attr("contenteditable","true");
                    var res_jr=null;
                   // var jrId =(getQueryVariable("jrId")==false) ? 0 : parseInt(getQueryVariable("jrId").toString()); 
                    if(jrId!=0)
                    {
                        var res_jr= await GetJRHdr($("[id*=txtemployeecode]").val(),$("[id*=lbldeptcd]").text(),$("[id*=lbldesigcd]").text(),jrId);
			            if (res_jr.response == -1) {
				            //ControlBlank()
				            ControlBlank_Part();
				            ErrMsg =(res_jr.responseMsg);
				            throw ErrMsg;
			            }
			            var objprpjrhdr = res_jr.responseObject;
			            var entryexists = objprpjrhdr.EntryExists;
			            $("#txtjobdesc").summernote('code',objprpjrhdr.jr_detail);
			            $("[id*=txtRevisionNo]").val(objprpjrhdr.revision_no);
			            $("[id*=txteffectivedate]").val(objprpjrhdr.revision_date);
			            $("[id*=txtsupersedeno]").val(objprpjrhdr.supersede_no);
			            $("[id*=txtreason]").val(objprpjrhdr.reason);
			            $("[id*=lblf_hdr_id]").text(objprpjrhdr.f_hdr_id)

			            $("[id*=lblMessage]").text("");
			            //19-05-2022----->

			            var res= await  getJRRevision(objprpemployeedetail.emp_cd);
			            if (res.response ==-1) 
			            {
                            $('#JRRevisionTable').dataTable().fnClearTable();
               	            $(".dataTables_length").hide();       //  -----Hide Show Number of Entry 
                            $(".dataTables_filter").hide();   //--HIde Search label and textbox         });
                            setTimeout(function(){$.fn.dataTable.tables( { visible: false, api: true } ).columns.adjust().fixedColumns().relayout();}, 100);
				            ErrMsg= res.responseMsg;
				            throw ErrMsg;
			            }
			            var myData = res.responseObjectList;
			            $(".loader").fadeOut();
			            populateGrid(myData).catch(function(reason) {ErrMsg="An Error found during populate the Grid";  throw ErrMsg;});
					}
				}
			}
        }            
    } 
    catch (err) 
    {
            $("[id*=lblMessage]").text(error).css('color', '#ff0000'); // Red color
        toastr.error( error, {timeOut: 200});
    }
}


function check_validation() 
{
    return new Promise(async function (resolve, reject) {
        var result="";
        $("[id*=lblMessage]").text("");
        if ($("[id*=txteffectivedate]").val() == "" ) 
        {
            $("[id*=txteffectivedate]").addClass('tabcolor');
            result="Select Effective Date";
            reject("Select Effective Date"); 
        }
        if ($("[id*=txtRevisionNo]").val() == "" ) 
        {
            $("[id*=txtRevisionNo]").addClass('tabcolor');
            result="Enter Revision No.";
            reject("Enter Revision No."); 
        }
        if ($("[id*=txtreason]").val() == "" ) 
        {
            $("[id*=txtreason]").addClass('tabcolor');
            result="Enter Reason";
            reject("Enter Reason"); 
        }
        if($('#txtjobdesc').summernote('code')=="")
        {
            $('#txtjobdesc').summernote('code').addClass('tabcolor');
            result="Enter JR Detail";
            reject("Enter JR Detail"); 
        }

        var getDoj =   Convert_StringInDateFormat($("[id*=txtdateofjoining]").val());
        var getEffectivedt = Convert_StringInDateFormat($("[id*=txteffectivedate]").val());

        if (result=="") {
            resolve("VALID");
        }
    });
}



function ControlBlank()
{
    $("input[id*=txtemployeename]").val("");
    $("input[id*=txtemployeecode]").val("");
    $("input[id*=txtDesignation]").val("");
    $("input[id*=txtdateofjoining]").val(""); 
    $("input[id*=txtjobdesc]").val(""); //Summer note
    $("input[id*=txtRevisionNo]").val("");
    $("input[id*=txteffectivedate]").val("");
    $("input[id*=txtsupersedeno]").val("");
    $("input[id*=txtreason]").val("");    
    $("[id*=btnSave]").removeAttr("disabled");
    $("#txtjobdesc").summernote("code",""); //Summer note
}



async function btnSave_Click()
{
    var btnSave =$("[id*=btnSave]");
    var btnCheck =$("[id*=btnCheck]");
    var btnaction =$("[id*=btnaction]");
    var btncancel =$("[id*=btncancel]");
    var lblempname =$("[id*=txtemployeename]");
    var arrayempname = lblempname.val();
    var lblonlyempname = arrayempname;
    var lblempcd =$("[id*=txtemployeecode]");
    var lblempdesig =$("[id*=txtDesignation]");
    var arrayempdesigname = lblempdesig.val().split('/');
    var lblempdesigname = arrayempdesigname[0];
    var lblempdoj =$("[id*=txtdateofjoining]");
    var lblemprevisionno =$("[id*=txtRevisionNo]");
    var lblemprevisiondate =$("[id*=txteffectivedate]");    
    var lblempsupersedeno =$("[id*=txtsupersedeno]");
    var lblempreason =$("[id*=txtreason]");

   
    //Sushil 05-10-2021
    var get_jrdetail = $('#txtjobdesc').summernote('code');  
    
    ////////current date////////////
    var currdt= new Date();
    currdt = (currdt.getMonth()+1) + '/' + currdt.getDate() + '/' + Math.abs(currdt.getFullYear());
    ///////////end/////////////////
    var res =null;
    var ErrMsg=null;
    var objPrpJREmphdr = new Object();
    try {

    var res = await check_validation(); 
	if (res != "VALID") 
	{
		ErrMsg= res;
		throw ErrMsg; 
	}
    else
    {
        $(".loader").fadeIn();
	    var usercd= await  getSessionVariables();
	    if (usercd.length ==0)
	    {
		    $("[id*=lblMessage]").text("Session Expired").css('color', '#ff0000'); // Red color
		    toastr.error("Session Expired", {timeOut: 200});
		    setTimeout(window.location.href = "Account/Login.aspx", 10000);
		    return;
	    }
        if (btnSave.text().trim() == "Update") 
        {
            res=null;
            if ($("[id*=drpEmployee] option:Selected").val() != "" )
            {
                //Employee Detail            
                var res =await GetEmployeeDetail($("[id*=drpEmployee] option:Selected").val());
                if (res.response == -1) 
                {
                    ErrMsg =(res.responseMsg);
                    throw ErrMsg;
                }
                var objprpemployeedetail= res.responseObject;

                objPrpJREmphdr = new Object();

                objPrpJREmphdr.emp_cd =  lblempcd.val();
                objPrpJREmphdr.emp_nm = lblonlyempname;  
                objPrpJREmphdr.doj = Convert_StringInDateFormat(lblempdoj.val());  
                objPrpJREmphdr.dept_cd =$("[id*=drpDepartment] option:Selected").val();    
                objPrpJREmphdr.dept_nm =$("[id*=drpDepartment] option:Selected").text();   
                objPrpJREmphdr.desig_cd = objprpemployeedetail.desig_cd; 
                objPrpJREmphdr.desig_nm =lblempdesigname;  
                objPrpJREmphdr.catg_cd =objprpemployeedetail.catg_cd;  
                objPrpJREmphdr.catg_nm =objprpemployeedetail.catg_nm; 
                objPrpJREmphdr.revision_no = lblemprevisionno.val(); 
                objPrpJREmphdr.revision_date =Convert_StringInDateFormat(lblemprevisiondate.val()); 
                objPrpJREmphdr.supersede_no = (lblempsupersedeno.val()=='Nil') ? "-1": lblempsupersedeno.val(); 
                objPrpJREmphdr.reason = lblempreason.val();  
                objPrpJREmphdr.luserId =usercd.toString().toUpperCase();  
                objPrpJREmphdr.JR_Detail=get_jrdetail;
                objPrpJREmphdr.f_hdr_id=$("[id*=lblf_hdr_id]").text();
                 objPrpJREmphdr.btnsave="Update";
                var res1=null; 
                //Update JR
                res1=await UPdateJREntry_EditMode(objPrpJREmphdr);
                if (res1.response == -1) 
                {
                    ErrMsg =res1.responseMsg;
                    throw ErrMsg;
                }
                $("[id*=lblMessage]").text(res1.responseMsg).css('color', '#008000'); // Green color
                toastr.success(res1.responseMsg, {timeOut: 200});

                btnSave.attr("disabled","disabled");
                $("[id*=drpEmployee] option:Selected").attr("disabled","disabled");
                $(".loader").fadeOut();


                $("[id*=lblMessage]").text("");

            }
        }
        }//02-12
    } 
    catch (err) 
    {
          $("[id*=lblMessage]").text(err).css('color', '#ff0000'); // Red color
          toastr.error(err, {timeOut: 200});
           $(".loader").fadeOut();
    }
    finally
    {
     $(".loader").fadeOut();
    }
}


function UPdateJREntry_EditMode(com)
{
    return new Promise(function (resolve, reject) {
        $.ajax({
            type: "POST",
            url: "WebService.asmx/UPdateJREntry_EditMode",
            data:  JSON.stringify({'p': com}),
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            async: false,
            timeout: 5000,
            success: function (response) {
                var myData = response.d;
                resolve(myData);
            },
            error: function (jqXHR, exception) {
                reject(jqXHR.responseJSON.Message);
            },
            failure: function (jqXHR, exception) {
                reject(jqXHR.responseJSON.Message);
            }
        });
    });
}

function getJRRevision(usercd) {
    return new Promise(function (resolve, reject) {
        $.ajax({
            type: "POST",
            url: "WebService.asmx/getJRRevision",
            data: "{'varempcd' : '" + usercd + "'}",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            async: false,
            timeout: 5000,
            success: function (mData) {
                var myData = mData.d;
                resolve(myData);
            },
            error: function (jqXHR, exception) {
                reject(jqXHR.responseJSON.Message);
            },
            failure: function (jqXHR, exception) {
                reject(jqXHR.responseJSON.Message);
            }
        });
    });
}



function btnexit_click()
{
    var strUrl = 'Default.aspx';  
    setTimeout(window.location.href = strUrl, 1000);
}




function ShowEmptyTable()
{
    $('#JRDetailTable').removeAttr("width").DataTable({
	    "processing": true,
	    "language": 
        {
		    "emptyTable": "No Data Found"
	    },
    });
	$(".dataTables_length").hide();       //  -----Hide Show Number of Entry 
	$(".dataTables_filter").hide();   //--HIde Search label and textbox         });
    setTimeout(function(){$.fn.dataTable.tables( { visible: false, api: true } ).columns.adjust().fixedColumns().relayout();}, 1000);
}


function isEmpty(val) {

// test results
//---------------
// [] true, empty array
// {} true, empty object
// null true
// undefined true
// "" true, empty string
// '' true, empty string
// 0 false, number
// true false, boolean
// false false, boolean
// Date false
// function false

if (val === undefined)
return true;

if (typeof (val) == 'function' || typeof (val) == 'number' || typeof (val) == 'boolean' || Object.prototype.toString.call(val) === '[object Date]')
return false;

if (val == null || val.length === 0) // null or 0 length array
return true;

if (typeof (val) == "object") {
// empty object

var r = true;

for (var f in val)
r = false;

return r;
}

return false;
}


function populateGrid(myData)
{
    return new Promise(function(resolve,reject)
    {
        var table = $('#JRRevisionTable').removeAttr("width").DataTable({
            "JQueryUI" : false,
            "paging": false,
            "processing": true,
            "deferRender" : true,
            "destroy": true,  
			"language": 
            {
				"emptyTable": "No Data Found"
			},
            data: myData,
            columns:
            [
                { 'data': 'catg_cd' },
                { 'data': 'revision_no' },
                { 'data': 'revision_date','visible': false},
                { 'data': 'supersede_no' },
                { 'data': 'reason' },
            ],
            "language": {
                "emptyTable": "No Data Found"
            },
            "fixedColumns": {
                "leftColumns": "2"
            },
          //  "scrollY": "400",
            "scrollX": "true",
            'order':[],
            'columnDefs': [{
                "targets": 0,
                "orderable": false
            }]
        });
        $(".dataTables_length").hide();       //  -----Hide Show Number of Entry 
        $(".dataTables_filter").hide();   //--HIde Search label and textbox         });
      //  table.order( [ 4, 'desc' ] ).draw();
        setTimeout(function(){$.fn.dataTable.tables( { visible: false, api: true } ).columns.adjust().fixedColumns().relayout();}, 1000);                   
    
    });
}


function Convert_StringInDateFormat(dt) {
    var formatted_date = "";
    if (dt == null || dt == "") return formatted_date;
    var d = dt.split("/");
    var month = parseInt(d[1]);
    var date = parseInt(d[0]);
    var year =Math.abs(d[2]);
    if (month < 10) {   month = '0' + month; }
    if (date < 10) {   date = '0' + date; }
    var formatted_date = month + "/" + date + "/" + year;
    return formatted_date;
}

function Convert_DateInStringFormat(dt)
{
    var formatted_date = "";
    if (dt == null || dt == "") return formatted_date;
    var d = new Date(dt);
    var date = d.getDate();
    var month = parseInt(d.getMonth())+1;
    var year = Math.abs(d.getFullYear());
    if (month < 10) {   month = '0' + month; }
    if (date < 10) {   date = '0' + date; }
    // let current_datetime = new Date()
    var formatted_date = date + "/" + month + "/" + year;
    return formatted_date;
}

function GetJRHdr(empcd,deptcd,desigcd,jrID) {
    return new Promise(function (resolve, reject) {
        $.ajax({
            type: "POST",
            url: "WebService.asmx/GetJRHdr",
            data: "{'varempcd' : '" + empcd + "','vardeptcd' : '" + deptcd + "','vardesigcd' : '" + desigcd + "','jrID' : " + jrID + "}",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            async: false,
            timeout: 5000,
            success: function (mData) {
                var myData = mData.d;
                resolve(myData);
            },
            error: function (jqXHR, exception) {
                reject(jqXHR.responseJSON.Message);
            },
            failure: function (jqXHR, exception) {
                reject(jqXHR.responseJSON.Message);
            }
        });
    });
}


function getEmployee(deptcd) {
    return new Promise(function (resolve, reject) {
        $.ajax({
            type: "POST",
            url: "WebService.asmx/getEmployee",
            data: "{'vardeptcd' : '" + deptcd + "' }",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            async: false,
            timeout: 5000,
            success: function (mData) {
                var myData = mData.d;
                resolve(myData);
            },
            error: function (jqXHR, exception) {
                reject(jqXHR.responseJSON.Message);
            },
            failure: function (jqXHR, exception) {
                reject(jqXHR.responseJSON.Message);
            }
        });
    });
}


function GetEmployeeDetail(empcd) {
    return new Promise(function (resolve, reject) {
        $.ajax({
            type: "POST",
            url: "WebService.asmx/GetEmployeeDetail",
            data: "{'varempcd' : '" + empcd + "' }",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            async: false,
            timeout: 5000,
            success: function (mData) {
                var myData = mData.d;
                resolve(myData);
            },
            error: function (jqXHR, exception) {
                reject(jqXHR.responseJSON.Message);
            },
            failure: function (jqXHR, exception) {
                reject(jqXHR.responseJSON.Message);
            }
        });
    });
}


function GetJRDetailforEditingDepartmentWise(deptcd) {
    return new Promise(function (resolve, reject) {
        $.ajax({
            type: "POST",
            url: "WebService.asmx/GetJRDetailforEditingDepartmentWise",
            data: "{'vardeptcd' : '" + deptcd + "'}",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            async: false,
            timeout: 5000,
            success: function (mData) {
                var myData = mData.d;
                resolve(myData);
            },
            error: function (jqXHR, exception) {
                reject(jqXHR.responseJSON.Message);
            },
            failure: function (jqXHR, exception) {
                reject(jqXHR.responseJSON.Message);
            }
        });
    });
}


function GetJRDetailforEditingEmployeeWise(empcd) {
    return new Promise(function (resolve, reject) {
        $.ajax({
            type: "POST",
            url: "WebService.asmx/GetJRDetailforEditingEmployeeWise",
            data: "{'varempcd' : '" + empcd + "'}",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            async: false,
            timeout: 5000,
            success: function (mData) {
                var myData = mData.d;
                resolve(myData);
            },
            error: function (jqXHR, exception) {
                reject(jqXHR.responseJSON.Message);
            },
            failure: function (jqXHR, exception) {
                reject(jqXHR.responseJSON.Message);
            }
        });
    });
}



function encryptQueryString(str) {
    return new Promise(function (resolve, reject) {
        $.ajax({
            type: "POST",
            url: "WebService.asmx/encryptQueryString",
            data: "{'str' : '" + str + "'}",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            async: false,
            timeout: 5000,
            success: function (mData) {
                var myData = mData.d;
                resolve(myData);
            },
            error: function (jqXHR, exception) {
                reject(jqXHR.responseJSON.Message);
            },
            failure: function (jqXHR, exception) {
                reject(jqXHR.responseJSON.Message);
            }
        });
    });
}

function decryptQueryString(str) {
    return new Promise(function (resolve, reject) {
        $.ajax({
            type: "POST",
            url: "WebService.asmx/decryptQueryString",
            data: "{'str' : '" + str + "'}",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            async: false,
            timeout: 5000,
            success: function (mData) {
                var myData = mData.d;
                resolve(myData);
            },
            error: function (jqXHR, exception) {
                reject(jqXHR.responseJSON.Message);
            },
            failure: function (jqXHR, exception) {
                reject(jqXHR.responseJSON.Message);
            }
        });
    });
}


function getDepartmentListtoFirstAuthority(empcd) {
    return new Promise(function (resolve, reject) {
        $.ajax({
            type: "POST",
            url: "WebService.asmx/getDepartmentListtoFirstAuthority",
            data: "{'empcd' : '" + empcd + "'}",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            async: false,
            timeout: 5000,
            success: function (mData) {
                var myData = mData.d;
                resolve(myData);
            },
            error: function (jqXHR, exception) {
                reject(jqXHR.responseJSON.Message);
            },
            failure: function (jqXHR, exception) {
                reject(jqXHR.responseJSON.Message);
            }
        });
    });
}

function getDepartmentList(empcd) {
    return new Promise(function (resolve, reject) {
        $.ajax({
            type: "POST",
            url: "WebService.asmx/getDepartmentList",
            data: "{'empcd' : '" + empcd + "'}",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            async: false,
            timeout: 5000,
            success: function (mData) {
                var myData = mData.d;
                resolve(myData);
            },
            error: function (jqXHR, exception) {
                reject(jqXHR.responseJSON.Message);
            },
            failure: function (jqXHR, exception) {
                reject(jqXHR.responseJSON.Message);
            }
        });
    });
}