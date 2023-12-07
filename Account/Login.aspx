<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Login.aspx.vb"  Inherits="Account_Login" ClientIDMode="Static" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <!-- Font Awesome -->
    <link href="../AdminLte/plugins/fontawesome-free/css/all.min.css" rel="stylesheet"
        type="text/css" />
    <!-- Tempusdominus Bootstrap 4 -->
    <link rel="stylesheet" href="../AdminLte/plugins/tempusdominus-bootstrap-4/css/tempusdominus-bootstrap-4.min.css"
        type="text/css" />
    <!-- iCheck -->
    <link rel="stylesheet" href="../AdminLte/plugins/icheck-bootstrap/icheck-bootstrap.min.css"
        type="text/css" />
    <!-- JQVMap -->
    <link rel="stylesheet" href="../AdminLte/plugins/jqvmap/jqvmap.min.css" type="text/css" />
    <!-- Theme style -->
    <link rel="stylesheet" href="../AdminLte/dist/css/adminlte.min.css" type="text/css" />
    <!-- overlayScrollbars -->
    <link rel="stylesheet" href="../AdminLte/plugins/overlayScrollbars/css/OverlayScrollbars.min.css"
        type="text/css" />
    <!-- Daterange picker -->
    <link rel="stylesheet" href="../AdminLte/plugins/daterangepicker/daterangepicker.css"
        type="text/css" />
    <!-- summernote -->
    <link rel="stylesheet" href="../AdminLte/plugins/summernote/summernote-bs4.min.css"
        type="text/css" />
    <link rel="stylesheet" href="../AdminLte/plugins/datatables-bs4/css/dataTables.bootstrap4.min.css"
        type="text/css" />
    <link rel="stylesheet" href="../AdminLte/plugins/datatables-responsive/css/responsive.bootstrap4.min.css"
        type="text/css" />
    <link rel="stylesheet" href="../AdminLte/plugins/datatables-buttons/css/buttons.bootstrap4.min.css"
        type="text/css" />
    <link rel="stylesheet" href="../AdminLte/dist/css/adminlte.min.css" type="text/css" />
    <link href="../Styles/nwlogn.css" rel="stylesheet" type="text/css" />

    <style type="text/css">
        input[type=text]:focus, input[type=password]:focus
        {
            background-color:lightyellow;
            border: 1px solid #ccc;
        }
    </style>

</head>
<body>
<div class="row">
    <div class ="col-12">
        <h2 align="center" style="color: #FFFFFF;text-decoration: underline;padding-bottom: 10px;font-weight: 900;letter-spacing: 0.162em;line-height: 1;font-size: 2.5rem;">ONLINE JOB RESPONSIBILITY MODULE</h2>
    </div>

</div>
<div class ="row">
    <div class ="col-12">
        <span style="font-family: Verdana; font-size: x-large; text-align: left; height: 3%; color: #fff; font-weight: 700; border-bottom-style: solid; border-bottom-color: #fff;border-bottom-width: 1px;"></span>
    </div>
</div>
<div class ="row">
    <div class ="col-12">
    <asp:Label ID="lblSts" runat="server" Width="200px" Style="font-family: 'Century Gothic';font-size: small; font-weight: 700"></asp:Label>
    </div>
</div>

<div class ="row">
    <div class="col-8">
        <div class ="form-group">
            <p>
                Job Responsibility Module takes the fuss and time-consuming paperwork out of applying for, and
                authorising, any of Job Responsibility. It gives in your company access to a fast, efficient, 
                online system, which they can use no matter where they are, so booking and approving time off couldn’t be easier.</p>
            <p style="font-family: calibri; font-size: x-large; margin-left: 3%;">
                <img src="../Images/people.png" alt="IOLCP" style="height:55px;margin-right: 10px;" />Simple and Easy to use for Employees
            </p>   
        </div>
        <div class ="form-group">
                <ul>
                    <li>Request for job responsibility  lieu quickly and easily online.</li>
                    <li>Find out who’s already booked time off for your Issuing Item.</li>
                    <%--<li>Obtain confirmation of job responsibility via email.</li>--%>
                    <li>View the current status of your request and easily update or cancel job responsibility.</li>
                    <li>Carry untaken days over to the following year (if part of your company policy.)</li>
                </ul>        
        </div>
        <div class ="form-group">
                <p style="font-family: calibri; font-size: x-large; margin-left: 3%;">
                    <img src="../Images/people.png" alt="IOLCP" style="height:55px;margin-right: 10px;"/>Powerful Monitoring Tool for Managers.
                </p>
                <ul>
                    <li>Record and monitor all of job responsibility departmentwise<span style="font-size:12.0pt;line-height:115%;font-family:&quot;Times New Roman&quot;,&quot;serif&quot;;mso-fareast-font-family:&quot;Times New Roman&quot;mso-ansi-language:EN-US;mso-fareast-language:EN-US;mso-bidi-language:AR-SA"></span></li>
                    <li>Keep accurate, up-to-date records of job responsibilities for every employee.</li>
                    <%--<li>Approve or reject Voucher requests at the click of a button.</li>--%>
                    <li>Cut down on wasted time, effort and paperwork and eliminate admin errors.</li>
                    <li>Set a maximum number of days that can be carried job responsibility detail in a Year , according
                        to your company policy.</li>
                    <li>Establish a single, consistent system for applying for job responsibility across your
                        company. </li>
                </ul>
                <p style="font-family: calibri; font-size: x-large; margin-left: 3%;">
                    <img src="../Images/people.png" alt="IOLCP" style="height:55px;margin-right: 10px;"/>See for Yourself
                    <ul>
                        <li>Why not experience Job Responsibility for yourself and see how effortless it makes the
                            process of managing and monitoring employee.</li>
                        <li>Instant update of job responsibility </li>

                    </ul>
                    </p>                 
        </div>

    </div>
    <div class ="col-4">
        <div class="container">
            <div class="card card-container">            
                <!-- <img class="profile-img-card" src="//lh3.googleusercontent.com/-6V8xOA6M7BA/AAAAAAAAAAI/AAAAAAAAAAA/rzlHcD0KYwo/photo.jpg?sz=120" alt="" /> -->
                <img id="profile-img" alt ="" class="profile-img-card" src="../Images/avatar_2x.png" />
                <p id="profile-name" class="profile-name-card"></p>
                <form id="Form1" class="form-signin" runat="server">
                    <span id="reauth-email" class="reauth-email"></span>
                    <%--<input type="email" id="inputEmail" class="form-control" placeholder="User Name" required autofocus/>--%>
                     <asp:TextBox ID="txtusrnam" runat="server" CssClass ="form-control" placeholder="User Name" required TabIndex ="1" ></asp:TextBox>
                    <%--<input type="password" id="inputPassword" class="form-control" placeholder="Password" required/>--%>
                    <asp:TextBox ID="txtusrpwd" runat="server" CssClass ="form-control" placeholder="Password" TextMode="Password" TabIndex ="2" required>r</asp:TextBox>
<%--                    <div id="remember" class="checkbox">
                        <label>
                            <input type="checkbox" value="remember-me"/> Remember me
                        </label>
                    </div>--%>
                   <%-- <button class="btn btn-lg btn-primary btn-block btn-signin" type="submit">Sign in</button>--%>
                   <%--<asp:Button ID="btnsignin" CssClass="btn btn-lg btn-primary btn-block btn-signin" runat="server" Text="Sign in" />--%>
                   <button type="button" id="btnSignIn" class="btn btn-lg btn-primary btn-block btn-signin" tabindex ="3" onclick="btnsignin_click();">Sign In</button>
                   <asp:Label ID="lblMessage" runat="server" style="color:Red;font-weight:bold;"></asp:Label>
                </form><!-- /form -->
               <%-- <a href="#" class="forgot-password">
                    Forgot the password?
                </a>--%>
            </div><!-- /card-container -->
        </div><!-- /container -->    
     </div>

</div>
<div class ="row">
    <div class="col-12">
        <div class="form-group">
<center style="font-family: calibri;  color: #fff;">
                        <strong>This site has visited
                            <asp:Label runat="server" ID="lblhitcou" Style="font-style: italic"></asp:Label>
                           times.</strong></center>
                    <marquee behavior="Alternate" scrolldelay="5" direction="right" scrollamount="2" onmouseover="this.stop();" onmouseout="this.start();" >
 <p style="font-weight: 400; font-family: verdana; ">  
    For More Details, please Contact IT Department at 1807,1808,1809.
</p></marquee>                          
        </div>
    </div>
</div>
<div class ="row">
    <div class ="col-12">
<div id="footer">
        <center style="padding: 0px; margin: 0px; color: #ffff; font-family: verdana; font-size: small;
            font-weight: bold;">
           <%-- Best view in Internet Explorer 6.0 or latest at resolution 1024 x 768 pixels--%>
            <br />
            Copyright (C) Commercial 2022 IOLCP DHAULA, BARNALA. All rights reserved.
        </center>
    </div>
    </div>
</div>



    <!-- jQuery -->
    <script src="../AdminLte/plugins/jquery/jquery.min.js" type="text/javascript"></script>
    <script src="../AdminLte/plugins/jquery-ui/jquery-ui.min.js" type="text/javascript"></script>
    <!-- Resolve conflict in jQuery UI tooltip with Bootstrap tooltip -->
    <!-- Bootstrap 4 -->
    <script src="../AdminLte/plugins/bootstrap/js/bootstrap.bundle.min.js" type="text/javascript"></script>
    <!-- ChartJS -->
    <script src="../AdminLte/plugins/chart.js/Chart.min.js" type="text/javascript"></script>
    <!-- Sparkline -->
    <script src="../AdminLte/plugins/sparklines/sparkline.js" type="text/javascript"></script>
    <!-- JQVMap -->
    <script src="../AdminLte/plugins/jqvmap/jquery.vmap.min.js" type="text/javascript"></script>
    <script src="../AdminLte/plugins/jqvmap/maps/jquery.vmap.usa.js" type="text/javascript"></script>
    <!-- jQuery Knob Chart -->
    <script src="../AdminLte/plugins/jquery-knob/jquery.knob.min.js" type="text/javascript"></script>
    <!-- daterangepicker -->
    <script src="../AdminLte/plugins/moment/moment.min.js" type="text/javascript"></script>
    <script src="../AdminLte/plugins/daterangepicker/daterangepicker.js" type="text/javascript"></script>
    <!-- Tempusdominus Bootstrap 4 -->
    <script src="../AdminLte/plugins/tempusdominus-bootstrap-4/js/tempusdominus-bootstrap-4.min.js"
        type="text/javascript"></script>
    <!-- Summernote -->
    <script src="../AdminLte/plugins/summernote/summernote-bs4.min.js" type="text/javascript"></script>
    <!-- overlayScrollbars -->
    <script src="../AdminLte/plugins/overlayScrollbars/js/jquery.overlayScrollbars.min.js"
        type="text/javascript"></script>
    <!-- AdminLTE App -->
    <script src="../AdminLte/dist/js/adminlte.js" type="text/javascript"></script>
    <!-- AdminLTE for demo purposes -->
    <script src="../AdminLte/dist/js/demo.js" type="text/javascript"></script>
    <!-- AdminLTE dashboard demo (This is only for demo purposes) -->
    <script src="../AdminLte/dist/js/pages/dashboard.js" type="text/javascript"></script>
    <script src="../AdminLte/build/js/PushMenu.js" type="text/javascript"></script>
    <script src="../AdminLte/build/js/Treeview.js" type="text/javascript"></script>
    <script src="../AdminLte/build/js/Layout.js" type="text/javascript"></script>
    <script src="../Scripts/common-script.js" type="text/javascript"></script>
    <script src="../Scripts/Login.js" type="text/javascript"></script>
</body>
</html>
