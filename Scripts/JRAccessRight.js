var PRP_Department_List;
var table;
Timer();

var $ = jQuery.noConflict();

$(document).ready(function () {
    ChangeBreadCrumb("Main", "JR Access Rights", "Main");
     $("#issueBody").addClass("sidebar-collapse");
    changeDate();
//    userDetail();
    BindGrid();
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



 
async function BindGrid() 
{
    var ErrMsg=null;
    // Hide image container
    $("#loader2").fadeIn();
    var lblMessage = $("[id*=lblMessage]");
    try 
    {
        var usercd= await  getSessionVariables();
        if (usercd.length ==0)
        {
            $("[id*=lblMessage]");("Session Expired").css('color', '#ff0000'); // Red color
            toastr.error("Session Expired", {timeOut: 200});
            setTimeout(window.location.href = "Account/Login.aspx", 10000);
            return;
        }


        if(usercd.length > 0)
        {
            var res= await  getJRAccessRights();
            if (res.response ==-1) 
            {
                ShowEmptyTable();
                ErrMsg= res.responseMsg;
                throw ErrMsg;
            }
            var myData = res.responseObjectList;
            $("#loader2").fadeOut();
            var res = await populateGrid(myData);   //  .catch(function(reason) {ErrMsg="An Error found during populate the Grid";  throw ErrMsg;});
            if (res!= "OK") {
                ErrMsg="An Error found during populate the Grid";  
                throw ErrMsg;
            }
            MakeDataTable();
        }
                
        // Hide image container
        if(ErrMsg ==null)
        {
            lblMessage.text("");
        }
    
    } 
    catch (err) 
    {
        lblMessage.text(err).css('color', '#ff0000'); // Red color
        // Hide image container
        $("#loader2").fadeOut();
    }
    finally
    {
          //Hide image container
        $("#loader2").fadeOut();   
    }
}

function btnexit_click()
{
    var strUrl = 'Default.aspx';
    setTimeout(window.location.href = strUrl, 10000);
}


function populateGrid(myData)
{
    return new Promise(function(resolve,reject)
    {
        var newRows = "";
        var tot=0;
        var isAdmin=null;var isHR=null; var isFinalAuth=null; var isFirstAuth=null;var isUser=null;
        //var tableHeading ='<table id="MIVExportTable"  border="0" cellpadding="0" cellspacing="0"  class ="table table-striped" style="width:100%;"><thead><tr><th>EmpCd</th><th>Emp Name</th><th>Department</th><th>MIV No.</th><th>MIV Date</th><th>Type</th><th>Status</th><th>Tot. Value</th></tr></thead><tbody>';
        var tableHeading ='<table id="JRAccessRightTable" border="0" cellpadding="0" cellspacing="0" class="table table-bordered table-striped dt-responsive" style="width: 100%;">';
        tableHeading += '<thead><tr><th rowspan="2" colspan="1" style="text-align:center;vertical-align: top;">Access Rights</th><th rowspan="1" colspan="5" style="text-align:center;">Authorization Levels</th></tr>';
        tableHeading += '<tr><th>Admin</th><th>HR</th><th>Final Authority</th><th>First Authority</th><th>User</th></tr></thead><tbody>';
        newRows += tableHeading;
        for (var i = 0; i < myData.length; i++) 
        {
        
        isAdmin= (myData[i].isAdmin==true) ? '<img src="./Images/Chk.png" style="width: 29px;position: relative;margin-bottom: 0px;opacity: 0.4;margin-left: 61px;">' : '<img src="./Images/cross.png" style="width: 29px;position: relative;margin-bottom: 0px;opacity: 0.4;margin-left: 61px;">';
        isHR= (myData[i].isHR==true) ?       '<img src="./Images/Chk.png" style="width: 29px;position: relative;margin-bottom: 0px;opacity: 0.4;margin-left: 61px;">' : '<img src="./Images/cross.png" style="width: 29px;position: relative;margin-bottom: 0px;opacity: 0.4;margin-left: 61px;">';
        isFinalAuth= (myData[i].isFinalAuth==true) ? '<img src="./Images/Chk.png" style="width: 29px;position: relative;margin-bottom: 0px;opacity: 0.4;margin-left: 61px;">' : '<img src="./Images/cross.png" style="width: 29px;position: relative;margin-bottom: 0px;opacity: 0.4;margin-left: 61px;">';
        isFirstAuth= (myData[i].isFirstAuth==true) ? '<img src="./Images/Chk.png" style="width: 29px;position: relative;margin-bottom: 0px;opacity: 0.4;margin-left: 61px;">' : '<img src="./Images/cross.png" style="width: 29px;position: relative;margin-bottom: 0px;opacity: 0.4;margin-left: 61px;">';
        isUser= (myData[i].isUser==true) ? '<img src="./Images/Chk.png" style="width: 29px;position: relative;margin-bottom: 0px;opacity: 0.4;margin-left: 61px;">' : '<img src="./Images/cross.png" style="width: 29px;position: relative;margin-bottom: 0px;opacity: 0.4;margin-left: 61px;">';


            newRows +=  '<tr><td>' + myData[i].accessRights + 
                        '</td><td>' + isAdmin + 
                        '</td><td>' + isHR +  
                        '</td><td>' + isFinalAuth + 
                        '</td><td>' + isFirstAuth + 
                        '</td><td>' + isUser + 
                        '</td></tr>';
        }
        newRows +='</tbody>';
        newRows += '</table>';
        document.getElementById("PendingJRDIV").innerHTML = newRows;
        resolve("OK");
    });
}


function MakeDataTable()
{
 table=  $("#JRAccessRightTable").removeAttr("width").DataTable({
        "JQueryUI" : false,
        "paging": false,
        "processing": true,
        "deferRender" : true,
        "destroy": true,  
        "language": {
            "emptyTable": "No Data Found"
        },
//        "fixedColumns": {
//            "leftColumns": "3"
//        },
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
  //  table.order( [ 4, 'desc' ] ).draw();
    setTimeout(function(){$.fn.dataTable.tables( { visible: false, api: true } ).columns.adjust().fixedColumns().relayout();}, 500);
}






function ShowEmptyTable()
{
    $('#JRAccessRightTable').removeAttr("width").DataTable({
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



function getJRAccessRights() {
    return new Promise(function (resolve, reject) {
        $.ajax({
            type: "POST",
            url: "WebService.asmx/GetJRAccessRights",
            data: "{}",
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

