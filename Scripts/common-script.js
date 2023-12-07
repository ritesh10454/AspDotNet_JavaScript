var $ = jQuery.noConflict();
$(document).ready(function () {
    window.history.pushState(null, "", window.location.href);
    window.onpopstate = function () {
        window.history.pushState(null, "", window.location.href);
    };
});



async function ChangeBreadCrumb(menuHeading,mainMenu,menuLabel) {
    $("#headingcurrMenu").html(menuHeading);
    $("#lblmainMenu").html(mainMenu);
    $("#lblcurrMenu").html(menuLabel);
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
       // ShowNotification(usercd.toString().trim()); 
    }
}
        

async function ShowNotification(usercd)
{

    //------Add Notification in Top of header------//
    var chkvalid =await CheckPasswordValidity(usercd.toString().trim());
    if (chkvalid.response ==-1) {
        ErrMsg= res1.responseMsg;
        throw ErrMsg;                   
    }
    var myData1=chkvalid.responseObject;
    var notif = await display_notification(myData1.Message);
    if (notif!="SHOW") {
        ErrMsg= "Error while show Notification";
        throw ErrMsg;    
    }
    var url=(window.location.pathname).replace("/JRModule_1/","").replace(".aspx","").replace("/","").toUpperCase();
    if(url!="PASSWORD")
    {
        if(myData1.ExpiryDays<=0)
        {
            setTimeout(window.location.href = "Password.aspx", 10000);
            ErrMsg= myData1.Message;
            throw ErrMsg;        
        }
    } 
    //-------------------End-----------------------//   

}


function display_notification(message){
    return new Promise(function (resolve, reject) {
        var notif=null;
        var tottotif=null;
        tottotif =1;
        if(message !="")
        {
            var notifydropdown = $("[id*=notification]");
            notif = '<a class="nav-link" data-toggle="dropdown" href="#"><i class="far fa-bell"></i>';
            notif += String.format('<span class="badge badge-warning navbar-badge">{0}</span></a><div class="dropdown-menu dropdown-menu-lg dropdown-menu-right">',tottotif);
            notif += String.format('<span class="dropdown-item dropdown-header">{0} Notifications</span>',tottotif);
            notif += '<div class="dropdown-divider"></div>';
            notif += String.format('<a href="Password.aspx" class="dropdown-item" style="white-space: normal;"><i class="fas fa-envelope mr-2"></i><span>{0}</span></a>',message);
            notif += '</div>';
            notifydropdown.append(notif);
        }
        resolve("SHOW");
    });
}

function CheckPasswordValidity(emp_cd) {
    return new Promise(function (resolve, reject) {
        $.ajax({
            type: "POST",
            url: "WebService.asmx/CheckPasswordValidity",
            data: "{'emp_cd' : '" + emp_cd + "' }",
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

function getSessionVariables() {
    return new Promise(function (resolve, reject) {
        $.ajax({
            type: "POST",
            url: "WebService.asmx/getSessionVariables",
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



//$(function () {
//    $(".gridviewTable").DataTable(
//        {
////            "destroy": "true",
////            "language": { "emptyTale": "No Data Found" },
//////            fixedColumn: { leftColumns: 3 },
////            "scrollY": "300",
////            "scrollX": "true",
////            "ColumnDefs": [{
////                "width": "300",
////                "target": "0"
////            }]
//            destroy: true,
//            "language": {
//                "emptyTable": "No Data Found"
//            },
//            "fixedColumns": {
//                "leftColumns": "3"
//            },
//            "scrollY": "300",
//            "scrollX": "true",
//            "bFilter": false,
//            "bInfo": false,
//            "ColumnDefs": [{
//                "width": 300,
//                "target": 0
//            }]
//            , bLengthChange: true,
//            lengthMenu: [[5, 10, -1], [5, 10, "All"]],
//            bFilter: true,
//            bSort: true,
//            bPaginate: true

//        });
//    });




