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

    $("#ShowPasswordModal").on('shown.bs.modal', function(){
        $(this).find('#txtPas').focus();
    });

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
        var res=null;
        if($("[id*=departmentDisplay]").is(":visible"))
        {
            res= await GetJRDetailDepartmentwise(txtDeptcd.val());
        }
        else
        {
           res= await GetJRDetailEmployeewise(txtEmpcd.val());
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
        var tableHeading='<table id="JRDetailTable" border="0" cellpadding="0" cellspacing="0" class="table table-bordered table-striped dt-responsive" style="width: 100%;"><thead><tr><th>JR ID</th><th>Employee Code</th><th>Employee Name</th><th>Department Code</th><th>Department Name</th><th>Designation Name</th><th>Revision_No</th><th class="show">Login</th></tr></thead>';
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
    var lblpass=$(cols[7]).text();  
    const ErrMsg=null;

    $("[id*=txtPas]").val("");
    $("[id*=lblMessage]").text("");
    $("[id*=lblPassword]").text(""); 
//    $("[id*=txtPas]").focus();
    $("#ShowPasswordModal").modal("toggle");  

    $("[id*=txtPas]").keydown(async function(e){
       if(e.which==13)
       {
            if ($("[id*=txtPas]").val().trim().toUpperCase()=="HRM") {
                var getPass= await getUserPassword(lblempcd.toString().trim());
                if (getPass.response==-1) {
                    ErrMsg= getPass.responseMsg;
                    throw ErrMsg;
                }
                var getPass=await decryptQueryString(getPass.responseObject.userpass.toString().trim());
                $("[id*=lblPassword]").text(getPass);
            } 
            if (ErrMsg!=null) {
                $("[id*=lblMessage]").text(err).css('color', '#ff0000'); // Red color
                toastr.error(err, {timeOut: 200});
            }        
       }       
    });

    $("[id*=btnShowPassword]").click(async function(e){
       // $(this).find('#txtPas').focus();
        $(this).unbind('click');
        $("[id*=lblMessage]").text("");
        $("[id*=lblPassword]").text(""); 
       // $("[id*=txtPas]").focus();
     

        if ($("[id*=txtPas]").val().trim().toUpperCase()=="HRM") {
            var getPass= await getUserPassword(lblempcd.toString().trim());
            if (getPass.response==-1) {
                ErrMsg= getPass.responseMsg;
                throw ErrMsg;
            }
            var getPass=await decryptQueryString(getPass.responseObject.userpass.toString().trim());
            $("[id*=lblPassword]").text(getPass);
        } 
        if (ErrMsg!=null) {
            $("[id*=lblMessage]").text(err).css('color', '#ff0000'); // Red color
            toastr.error(err, {timeOut: 200});
        }  
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
    setTimeout(function(){$.fn.dataTable.tables( { visible: false, api: true } ).columns.adjust().fixedColumns().relayout();}, 100);
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



function isNumberfloatKey(evt, element,afterDot) {
  var afterDot = afterDot+1;
  var charCode = (evt.which) ? evt.which : event.keyCode
  if (charCode > 31 && (charCode < 48 || charCode > 57) && !(charCode == 46 || charCode == 8))
    return false;
  else 
  {
    var len = $(element).val().length;
    var index = $(element).val().indexOf('.');
    if (index > 0 && charCode == 46) 
    {
      return false;
    }
    if (index > 0) 
    {
      var CharAfterdot = (len + 1) - index;
      if (CharAfterdot > afterDot) 
      {
        return false;
      }
    }
  }
  return true;
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
       // $.fn.dataTable.tables( { visible: false, api: true } ).order( [ 1, 'asc' ] ).draw();
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


function getUserPassword(empcd) {
    return new Promise(function (resolve, reject) {
        $.ajax({
            type: "POST",
            url: "WebService.asmx/getUserPassword",
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


function GetJRDetailDepartmentwise(deptcd) {
    return new Promise(function (resolve, reject) {
        $.ajax({
            type: "POST",
            url: "WebService.asmx/GetJRDetailDepartmentwise",
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


function GetJRDetailEmployeewise(empcd) {
    return new Promise(function (resolve, reject) {
        $.ajax({
            type: "POST",
            url: "WebService.asmx/GetJRDetailEmployeewise",
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