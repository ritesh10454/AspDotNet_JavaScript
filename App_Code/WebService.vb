Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
' <System.Web.Script.Services.ScriptService()> _
<WebService(Namespace:="http://tempuri.org/")> _
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<System.Web.Script.Services.ScriptService()> _
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Public Class WebService
    Inherits System.Web.Services.WebService

    '<WebMethod()> _
    'Public Function HelloWorld() As String
    '    Return "Hello World"
    'End Function

    <WebMethod(EnableSession:=True)> _
    Public Function getJRMenus(ByVal roleID As Integer, ByVal parentID As Integer, ByVal usercd As String) As QueryResponse(Of PRP_JRMenu)
        Dim res As New QueryResponse(Of PRP_JRMenu)
        Dim p As New List(Of PRP_JRMenu)
        Dim objs As New CLS_JRMenu()
        res = objs.ShowJRMenus(roleID, parentID, usercd)
        Return res
    End Function

    '<WebMethod(EnableSession:=True)> _
    'Public Function getInboxData(ByVal par As Integer, ByVal emp_cd As String) As QueryResponse(Of PRP_PmivInbox)
    '    Dim res As New QueryResponse(Of PRP_PmivInbox)
    '    Dim p As New List(Of PRP_PmivInbox)
    '    Dim objs As New Cls_Pmivinbox()
    '    res = objs.Display_PmivInbox(par, emp_cd)
    '    Return res
    'End Function
    <WebMethod(EnableSession:=True)> _
    Public Function getHIT_Counter() As QueryResponse(Of PRP_Hit_Counter)
        Dim objs As New Cls_Hit_counter()
        Dim res As New QueryResponse(Of PRP_Hit_Counter)
        res = objs.View()
        Return res
    End Function
    <WebMethod(EnableSession:=True)> _
    Public Function save_LV_Emp_Detail(ByVal hit_cou As Int32) As QueryResponse(Of PRP_Hit_Counter)
        Dim objs As New Cls_Hit_counter()
        Dim res As New QueryResponse(Of PRP_Hit_Counter)
        res = objs.AddHitCounter(hit_cou)
        Return res
    End Function
    <WebMethod(EnableSession:=True)> _
    Public Function clearSession() As String
        Dim result As String = ""
        Dim objs As New CLS_User_Master()
        Dim res As New QueryResponse(Of PRP_JRAccess)
        res = objs.Add_JR_Audit_Trails_Entry("NA", "User successfully logged out", HttpContext.Current.Session("usrnam"))
        If res.response = 1 Then
            If Not IsNothing(HttpContext.Current.Session("usrnam")) Then
                Session.Clear()
                Session.Abandon()
                result = "OK"
            End If
        End If
        Return result
    End Function

    <WebMethod(EnableSession:=True)> _
    Public Function getSessionVariables() As String
        Dim emp_cd As String = ""
        If IsNothing(HttpContext.Current.Session("usrnam")) Then
            emp_cd = ""
        Else
            emp_cd = HttpContext.Current.Session("usrnam").ToString()
        End If

        Return emp_cd
    End Function

    <WebMethod(EnableSession:=True)> _
    Public Function GetJRRoles() As QueryResponse(Of PRP_JRRole)
        Dim objs As New CLS_JRRole()
        Dim res As New QueryResponse(Of PRP_JRRole)
        res = objs.Display_JRRoles()
        Return res
    End Function
    <WebMethod(EnableSession:=True)> _
    Public Function GetJRAccessRights() As QueryResponse(Of PRP_JRAccessRights)
        Dim objs As New CLS_JRAccessRights()
        Dim res As New QueryResponse(Of PRP_JRAccessRights)
        res = objs.View()
        Return res
    End Function



    <WebMethod(EnableSession:=True)> _
    Public Function encryptQueryString(ByVal str As String) As String
        Dim retStr As String = HttpUtility.UrlEncode(EncryptDecrypt.Encrypt(str.ToString().Trim()))
        Return retStr
    End Function
    <WebMethod(EnableSession:=True)> _
    Public Function decryptQueryString(ByVal str As String) As String
        Dim retStr As String = EncryptDecrypt.Decrypt(HttpUtility.UrlDecode(str.ToString().Trim()))
        Return retStr
    End Function
    <WebMethod(EnableSession:=True)> _
    Public Function getUserPassword(ByVal empcd As String) As QueryResponse(Of PRP_JRHdr)
        Dim objs As New CLS_JRHdr()
        Dim res As New QueryResponse(Of PRP_JRHdr)
        res = objs.getUserPassword(empcd)
        Return res
    End Function


    <WebMethod(EnableSession:=True)> _
    Public Function GetUserRole(ByVal usercd As String) As QueryResponse(Of PRP_JRRole)
        Dim objs As New CLS_JRRole()
        Dim res As New QueryResponse(Of PRP_JRRole)
        res = objs.UserRoleByUserCode(usercd)
        Return res
    End Function
    <WebMethod(EnableSession:=True)> _
    Public Function GetMenuRole(ByVal usercd As String) As QueryResponse(Of PRP_JRRole)
        Dim objs As New CLS_JRRole()
        Dim res As New QueryResponse(Of PRP_JRRole)
        res = objs.MenuRoleByUserCode(usercd)
        Return res
    End Function

    <WebMethod(EnableSession:=True)> _
    Public Function GetJRInbox(ByVal empcd As String) As QueryResponse(Of PRP_JRInbox)
        Dim objs As New CLS_JRInbox()
        Dim res As New QueryResponse(Of PRP_JRInbox)
        res = objs.Display_JRInbox(empcd)
        Return res
    End Function
    <WebMethod(EnableSession:=True)> _
    Public Function GetJRFinalApprovalInbox(ByVal empcd As String) As QueryResponse(Of PRP_JRInbox)
        Dim objs As New CLS_JRInbox()
        Dim res As New QueryResponse(Of PRP_JRInbox)
        res = objs.Display_JRFinalApprovalInbox(empcd)
        Return res
    End Function
    <WebMethod(EnableSession:=True)> _
    Public Function GetJRHODApprovalInbox(ByVal empcd As String) As QueryResponse(Of PRP_JRInbox)
        Dim objs As New CLS_JRInbox()
        Dim res As New QueryResponse(Of PRP_JRInbox)
        res = objs.Display_JRHODApprovalInbox(empcd)
        Return res
    End Function



    <WebMethod(EnableSession:=True)> _
    Public Function getJROutBox(ByVal empcd As String) As QueryResponse(Of PRP_JRInbox)
        Dim objs As New CLS_JRInbox()
        Dim res As New QueryResponse(Of PRP_JRInbox)
        res = objs.Display_JROutbox(empcd)
        Return res
    End Function

    <WebMethod(EnableSession:=True)> _
    Public Function Set_Welcome_Message(ByVal usercd As String) As QueryResponse(Of PRP_users)
        Dim objs As New CLS_User_Master()
        Dim res As New QueryResponse(Of PRP_users)
        res = objs.Display_User_Name(usercd.ToString().Trim())
        Return res
    End Function

    <WebMethod(EnableSession:=True)> _
    Public Function getEmployee(ByVal vardeptcd As String) As QueryResponse(Of PRP_Employee)
        Dim res As New QueryResponse(Of PRP_Employee)

        Dim objs As New cls_Employee()
        res = objs.View(vardeptcd)
        Return res
    End Function
    <WebMethod(EnableSession:=True)> _
    Public Function getEmployeeforJREntry(ByVal vardeptcd As String, ByVal varempcd As String) As QueryResponse(Of PRP_Employee)
        Dim res As New QueryResponse(Of PRP_Employee)

        Dim objs As New cls_Employee()
        res = objs.GetEmployeeListforJREntry(vardeptcd, varempcd)
        Return res
    End Function
    <WebMethod(EnableSession:=True)> _
    Public Function getJRAuditTrailsList(ByVal empcd As String) As QueryResponse(Of PRP_JR_Audit_Trails)
        Dim res As New QueryResponse(Of PRP_JR_Audit_Trails)
        Dim objs As New CLS_JR_Audit_Trails()
        res = objs.getJRAuditTrailsList(empcd)
        Return res
    End Function


    <WebMethod(EnableSession:=True)> _
    Public Function getAllEmployee_notExistinJRSys() As QueryResponse(Of PRP_Employee)
        Dim res As New QueryResponse(Of PRP_Employee)

        Dim objs As New cls_Employee()
        res = objs.AllEmployee_notExistinJRSys()
        Return res
    End Function
    <WebMethod(EnableSession:=True)> _
    Public Function getAllEmployee_ExistinJRSys() As QueryResponse(Of PRP_Employee)
        Dim res As New QueryResponse(Of PRP_Employee)

        Dim objs As New cls_Employee()
        res = objs.AllEmployee_ExistinJRSys()
        Return res
    End Function


    <WebMethod(EnableSession:=True)> _
    Public Function GetEmployeeDetails(ByVal emp_cd As String) As QueryResponse(Of PRP_JRAccess)
        Dim res As New QueryResponse(Of PRP_JRAccess)
        Dim objs As New CLS_JRAccess()
        res = objs.GetEmployeeDetails(emp_cd)
        Return res
    End Function
    <WebMethod(EnableSession:=True)> _
    Public Function GetSelectedEXisting_EmployeeDetails(ByVal emp_cd As String) As QueryResponse(Of PRP_JRAccess)
        Dim res As New QueryResponse(Of PRP_JRAccess)
        Dim objs As New CLS_JRAccess()
        res = objs.GetSelectedEXisting_EmployeeDetails(emp_cd)
        Return res
    End Function
    <WebMethod(EnableSession:=True)> _
    Public Function Save_JRAccessUser(ByVal p As PRP_JRAccess) As QueryResponse(Of PRP_JRAccess)
        Dim objs As New CLS_JRAccess()
        Dim res As New QueryResponse(Of PRP_JRAccess)
        res = objs.Insert(p)
        Return res
    End Function
    <WebMethod(EnableSession:=True)> _
    Public Function Update_JRAccessUser(ByVal p As PRP_JRAccess) As QueryResponse(Of PRP_JRAccess)
        Dim objs As New CLS_JRAccess()
        Dim res As New QueryResponse(Of PRP_JRAccess)
        res = objs.Update(p)
        Return res
    End Function
    <WebMethod(EnableSession:=True)> _
    Public Function UPdateJREntry_EditMode(ByVal p As PRP_JRHdr) As QueryResponse(Of PRP_JRHdr)
        Dim objHdr As New CLS_JRHdr()
        Dim res As New QueryResponse(Of PRP_JRHdr)
        res = objHdr.Update_JR_hdr_EditMode(p)
        Return res
    End Function
    <WebMethod(EnableSession:=True)> _
    Public Function SaveJREntry(ByVal p As PRP_JRHdr) As QueryResponse(Of PRP_JRHdr)
        Dim objHdr As New CLS_JRHdr()
        Dim res As New QueryResponse(Of PRP_JRHdr)
        res = objHdr.SaveJREntry(p)
        Return res
    End Function

    <WebMethod(EnableSession:=True)> _
    Public Function JR_Approval(ByVal p As PRP_JRHdr) As QueryResponse(Of PRP_JRHdr)
        Dim objs As New CLS_JRHdr()
        Dim res As New QueryResponse(Of PRP_JRHdr)
        res = objs.JR_Approval(p)
        Return res
    End Function
    <WebMethod(EnableSession:=True)> _
    Public Function JR_MovetoInbox(ByVal p As PRP_JRHdr) As QueryResponse(Of PRP_JRHdr)
        Dim objs As New CLS_JRHdr()
        Dim res As New QueryResponse(Of PRP_JRHdr)
        res = objs.JR_MovetoInbox(p)
        Return res
    End Function


    <WebMethod(EnableSession:=True)> _
    Public Function getJRContents(ByVal id As Integer) As QueryResponse(Of PRP_JRHdr)
        Dim objs As New CLS_JRHdr()
        Dim res As New QueryResponse(Of PRP_JRHdr)
        res = objs.getJRContents(id)
        Return res
    End Function


    'Sushil 21-09-2021
    <WebMethod(EnableSession:=True)> _
    Public Function GetEmployeeDetail(ByVal varempcd As String) As QueryResponse(Of PRP_EmployeeDetail)
        Dim objs As New cls_EmployeeDetail()
        Dim res As New QueryResponse(Of PRP_EmployeeDetail)
        ''Dim emp_cd As String = HttpContext.Current.Session("usrnam").ToString()
        res = objs.View(varempcd)
        Return res
    End Function

    <WebMethod(EnableSession:=True)> _
    Public Function GetDashboardTabs() As QueryResponse(Of PRP_JR_Dashboard)
        Dim objs As New CLS_JR_Dashboard()
        Dim res As New QueryResponse(Of PRP_JR_Dashboard)
        Dim emp_cd As String = HttpContext.Current.Session("usrnam").ToString()
        'Dim objss As New CLS_JRHdr()
        'Dim res1 As New QueryResponse(Of PRP_JRHdr)
        res = objs.View(emp_cd)
        'res1 = objss.getHRMAuthority(emp_cd)
        'If res1.response = -1 Then
        '    res = objs.View(emp_cd)
        'Else
        '    res = objs.View1(emp_cd)
        'End If
        Return res
    End Function


    <WebMethod(EnableSession:=True)> _
    Public Function GetJRHdr(ByVal varempcd As String, ByVal vardeptcd As String, ByVal vardesigcd As String, ByVal jrID As Integer) As QueryResponse(Of PRP_JRHdr)
        Dim objs As New cls_EmployeeDetail()
        Dim res As New QueryResponse(Of PRP_JRHdr)
        Dim objp As New CLS_JRHdr()
        ''Dim emp_cd As String = HttpContext.Current.Session("usrnam").ToString()
        If jrID > 0 Then
            res = objp.getJRContents(jrID)
        Else
            res = objs.View_JRHDR(varempcd, vardeptcd, vardesigcd)
        End If

        Return res
    End Function
    <WebMethod(EnableSession:=True)> _
    Public Function checkDuplicate(ByVal empcd As String) As QueryResponse(Of String)
        Dim objs As New CLS_JRHdr()
        Dim res As New QueryResponse(Of String)
        res = objs.CheckDuplicate(empcd)
        Return res
    End Function
    <WebMethod(EnableSession:=True)> _
    Public Function GetJRDetailDepartmentwise(ByVal vardeptcd As String) As QueryResponse(Of PRP_JRHdr)
        Dim objs As New cls_EmployeeDetail()
        Dim res As New QueryResponse(Of PRP_JRHdr)
        Dim res1 As New QueryResponse(Of PRP_JRHdr)
        ''Dim emp_cd As String = HttpContext.Current.Session("usrnam").ToString()
        res1 = objs.checkDepartmentCode(vardeptcd)
        If res1.response = -1 Then
            res.response = res1.response
            res.responseMsg = res1.responseMsg
        Else
            res = objs.View_JRDetailDepartmentwise(vardeptcd)
        End If
        Return res
    End Function

    <WebMethod(EnableSession:=True)> _
    Public Function GetJRDetailEmployeewise(ByVal varempcd As String) As QueryResponse(Of PRP_JRHdr)
        Dim objs As New cls_EmployeeDetail()
        Dim res As New QueryResponse(Of PRP_JRHdr)
        '   Dim res1 As New QueryResponse(Of PRP_JRHdr)
        ''Dim emp_cd As String = HttpContext.Current.Session("usrnam").ToString()
        'res1 = objs.checkDepartmentCode(varempcd)
        'If res1.response = -1 Then
        '    res.response = res1.response
        '    res.responseMsg = res1.responseMsg
        'Else
        '    res = objs.View_JRDetailDepartmentwise(varempcd)
        'End If
        res = objs.View_JRDetailEmployeewise(varempcd)
        Return res
    End Function

    <WebMethod(EnableSession:=True)> _
    Public Function GetJRDetailforEditingDepartmentWise(ByVal vardeptcd As String) As QueryResponse(Of PRP_JRHdr)
        Dim objs As New cls_EmployeeDetail()
        Dim res As New QueryResponse(Of PRP_JRHdr)
        Dim res1 As New QueryResponse(Of PRP_JRHdr)
        ''Dim emp_cd As String = HttpContext.Current.Session("usrnam").ToString()
        res1 = objs.checkDepartmentCode(vardeptcd)
        If res1.response = -1 Then
            res.response = res1.response
            res.responseMsg = res1.responseMsg
        Else
            res = objs.View_JRDetailforEditing(vardeptcd)
        End If
        Return res
    End Function

    <WebMethod(EnableSession:=True)> _
    Public Function GetJRDetailforEditingEmployeeWise(ByVal varempcd As String) As QueryResponse(Of PRP_JRHdr)
        Dim objs As New cls_EmployeeDetail()
        Dim res As New QueryResponse(Of PRP_JRHdr)
        res = objs.View_JRDetailforEditingEmployeewise(varempcd)
        Return res
    End Function



    <WebMethod(EnableSession:=True)> _
    Public Function GetJRReport(ByVal vardeptcd As String, ByVal vardatfro As String, ByVal vardatTo As String) As QueryResponse(Of PRP_JRHdr)
        Dim objs As New cls_EmployeeDetail()
        Dim res As New QueryResponse(Of PRP_JRHdr)
        ''Dim emp_cd As String = HttpContext.Current.Session("usrnam").ToString()
        res = objs.View_JRReport(vardeptcd, vardatfro, vardatTo) ''SUSHIL 16-11-2021
        Return res
    End Function
    <WebMethod(EnableSession:=True)> _
    Public Function GetJRReportPrint(ByVal varempcd As String, ByVal jrID As Integer) As QueryResponse(Of PRP_JRHdr)
        Dim objs As New cls_EmployeeDetail()
        Dim res As New QueryResponse(Of PRP_JRHdr)
        ''Dim emp_cd As String = HttpContext.Current.Session("usrnam").ToString()
        res = objs.Print_JR(varempcd, jrID) ''SUSHIL 23-11-2021
        Return res
    End Function
    '19-07-2022----->
    <WebMethod(EnableSession:=True)> _
    Public Function GetJRRevisionHistoryPrint(ByVal varempcd As String) As QueryResponse(Of PRP_JRHdr)
        Dim objs As New cls_EmployeeDetail()
        Dim res As New QueryResponse(Of PRP_JRHdr)
        ''Dim emp_cd As String = HttpContext.Current.Session("usrnam").ToString()
        res = objs.Print_JRRevision(varempcd)
        Return res
    End Function
    '19-07-2022-----<

    <WebMethod(EnableSession:=True)> _
    Public Function getPendingJR(ByVal varempcd As String) As QueryResponse(Of PRP_JRHdr)
        Dim objs As New cls_EmployeeDetail()
        Dim res As New QueryResponse(Of PRP_JRHdr)
        ''Dim emp_cd As String = HttpContext.Current.Session("usrnam").ToString()
        res = objs.View_PendingJR(varempcd) ''SUSHIL 07-02-2022
        Return res
    End Function
    <WebMethod(EnableSession:=True)> _
    Public Function getJRLists(ByVal empcd As String, ByVal tag As Int64) As QueryResponse(Of PRP_JRHdr)
        Dim objs As New cls_EmployeeDetail()
        Dim objss As New CLS_JRHdr()
        Dim res As New QueryResponse(Of PRP_JRHdr)
        ''Dim emp_cd As String = HttpContext.Current.Session("usrnam").ToString()
        Dim res1 As New QueryResponse(Of PRP_JRHdr)
        res1 = objss.getHRMAuthority(empcd.ToString().Trim())
        If res1.response = -1 Then
            res = objs.View_JRLists(empcd, tag)
        Else
            res = objs.View_JRLists1(empcd, tag)
        End If

        Return res
    End Function

    <WebMethod(EnableSession:=True)> _
    Public Function getJRRevision(ByVal varempcd As String) As QueryResponse(Of PRP_JRHdr)
        Dim objs As New cls_EmployeeDetail()
        Dim res As New QueryResponse(Of PRP_JRHdr)
        ''Dim emp_cd As String = HttpContext.Current.Session("usrnam").ToString()
        res = objs.View_JRRevision(varempcd) ''SUSHIL 19-05-2022
        Return res
    End Function

    <WebMethod(EnableSession:=True)> _
    Public Function getAllList() As QueryResponse(Of PRP_Lists)
        Dim res As New QueryResponse(Of PRP_Lists)
        Dim res_dept As New QueryResponse(Of PRP_Department)
        Dim res_users As New QueryResponse(Of PRP_hry)
        Dim res_employee As New QueryResponse(Of PRP_Employee)
        Try
            res.responseObject = New PRP_Lists()

            res_dept = getDepartment()
            If res_dept.response = -1 Then
                res.response = -1
                Throw New Exception(res_dept.responseMsg)
            End If
            res.responseObject.Department = res_dept.responseObjectList

            'res.responseObject.PRP_Department_List = res_dept.responseObjectList

            'res_employee = getEmployee()
            'If res_employee.response = -1 Then
            '    res.response = -1
            '    Throw New Exception(res_employee.responseMsg)
            'End If
            'res.responseObject.Employee = res_employee.responseObjectList

            'res_cons = getConsumptionCentre()
            'If res_cons.response = -1 Then
            '    res.response = -1
            '    Throw New Exception(res_cons.responseMsg)
            'End If
            'res.responseObject.ConsumptionCentre = res_cons.responseObjectList

            'res_cost = getCostCentre()
            'If res_cost.response = -1 Then
            '    res.response = -1
            '    Throw New Exception(res_cost.responseMsg)
            'End If
            'res.responseObject.CostCentre = res_cost.responseObjectList

            'res_users = GetUserRole()
            'If res_users.response = -1 Then
            '    res.response = -1
            '    Throw New Exception(res_users.responseMsg)
            'End If
            'res.responseObject.UserRole = res_users.responseObject

            'res_items = getItemList()
            'If res_items.response = -1 Then
            '    res.response = -1
            '    Throw New Exception(res_items.responseMsg)
            'End If
            'res.responseObject.ItemList = res_items.responseObjectList
            res.response = 1 : res.responseMsg = ""
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message
        End Try

        Return res
    End Function

    <WebMethod(EnableSession:=True)> _
    Public Function JR_MaxgetUserRole(ByVal emp_cd As String) As QueryResponse(Of PRP_JRRole)
        Dim res As New QueryResponse(Of PRP_JRRole)
        Dim objs As New CLS_JRRole()
        res = objs.JR_MaxgetUserRole(emp_cd)
        Return res
    End Function
    <WebMethod(EnableSession:=True)> _
    Public Function JR_getUserRole(ByVal emp_cd As String, ByVal auth_cd As String) As QueryResponse(Of PRP_JRRole)
        Dim res As New QueryResponse(Of PRP_JRRole)
        Dim objs As New CLS_JRRole()
        res = objs.JR_getUserRole(emp_cd, auth_cd)
        Return res
    End Function


    <WebMethod(EnableSession:=True)> _
    Public Function JR_MaxgetAuthRole(ByVal emp_cd As String, ByVal auth_cd As String) As QueryResponse(Of PRP_JRRole)
        Dim res As New QueryResponse(Of PRP_JRRole)
        Dim objs As New CLS_JRRole()
        res = objs.JR_MaxgetUserRole(emp_cd, auth_cd)
        Return res
    End Function

    <WebMethod(EnableSession:=True)> _
    Public Function getDepartment() As QueryResponse(Of PRP_Department)
        Dim res As New QueryResponse(Of PRP_Department)
        Dim objs As New cls_Department()
        res = objs.View()
        Return res
    End Function
    <WebMethod(EnableSession:=True)> _
    Public Function getJRUsersList(ByVal s As PRP_SearchwithPagination) As QueryResponse(Of PRP_JRHdr)
        Dim res As New QueryResponse(Of PRP_JRHdr)
        Dim objs As New cls_EmployeeDetail()
        res = objs.View_JRUsersList(s)
        Return res
    End Function
    <WebMethod(EnableSession:=True)> _
    Public Function CheckPasswordValidity(ByVal emp_cd As String) As QueryResponse(Of PRP_JR_CheckLoginValidity)
        Dim res As New QueryResponse(Of PRP_JR_CheckLoginValidity)
        Dim objs As New CLS_JR_Login()
        res = objs.CheckPasswordValidity(emp_cd)
        Return res
    End Function


    <WebMethod(EnableSession:=True)> _
    Public Function getDepartmentList(ByVal empcd As String) As QueryResponse(Of PRP_Department)
        Dim res As New QueryResponse(Of PRP_Department)
        Dim objs As New cls_Department()
        res = objs.getDepartmentList(empcd.ToString().Trim())
        Return res
    End Function
    <WebMethod(EnableSession:=True)> _
    Public Function getDepartmentListtoFirstAuthority(ByVal empcd As String) As QueryResponse(Of PRP_Department)
        Dim res As New QueryResponse(Of PRP_Department)
        Dim objs As New cls_Department()
        res = objs.getDepartmentListtoFirstAuthority(empcd.ToString().Trim())
        Return res
    End Function
    <WebMethod(EnableSession:=True)> _
    Public Function checkJRAuth(ByVal empcd As String) As QueryResponse(Of PRP_Employee)
        Dim res As New QueryResponse(Of PRP_Employee)
        Dim objs As New cls_Employee()
        res = objs.checkJRAuth(empcd.ToString().Trim())
        Return res
    End Function

    <WebMethod(EnableSession:=True)> _
    Public Function checkPassword(ByVal varempcd As String, ByVal varoldpwd As String) As QueryResponse(Of PRP_users)
        Dim objs As New CLS_JR_Login()
        Dim k As New PRP_JRLogin()
        k.emp_cd = varempcd.ToString().Trim()
        k.userpass = EncryptDecrypt.Encrypt(varoldpwd.ToString().Trim())
        Dim res As New QueryResponse(Of PRP_users)
        res = objs.Check_Password(k)
        Return res
    End Function
    <WebMethod(EnableSession:=True)> _
    Public Function UpdatePassword(ByVal varempcd As String, ByVal varseccd As String) As QueryResponse(Of PRP_JRLogin)
        Dim objs As New CLS_JR_Login()
        Dim k As New PRP_JRLogin()
        k.emp_cd = varempcd.ToString().Trim()
        k.userpass = EncryptDecrypt.Encrypt(varseccd.ToString().Trim())
        Dim res As New QueryResponse(Of PRP_JRLogin)
        res = objs.Update(k)
        Return res
    End Function
    <WebMethod(EnableSession:=True)> _
    Public Function Check_Login(ByVal usernm As String, ByVal pwd As String) As QueryResponse(Of PRP_users)
        Dim objs As New PRP_EmployeeDetail()
        Dim res As New QueryResponse(Of PRP_users)
        Dim clsusr1 As New CLS_JR_Login()
        Dim Result As Integer = 0
        Dim strHostName As String = System.Net.Dns.GetHostName()
        Dim clientIPAddress As String = System.Net.Dns.GetHostAddresses(strHostName).GetValue(0).ToString
        Try
            res = clsusr1.Check_User_Login(usernm.Trim().ToUpper(), EncryptDecrypt.Encrypt(pwd))
            If res.responseObject.outres = -1 Then
                res.response = -1
                Throw New Exception(res.responseMsg)
            End If
            If res.response = 1 Then
                'this.session.
                Session("usrnam") = usernm.Trim().ToUpper()
            ElseIf res.response = -2 Then
                res.response = -2
                res.responseMsg = "Password is Wrong"
            ElseIf Result = 8 Then
                res.response = 8
                res.responseMsg = "You are not Authorized."
            Else
                res.response = -1
                res.responseMsg = "Error in Login, check sp: JR_Check_User"
                Throw New Exception(res.responseMsg)
            End If
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message
        End Try
        Return res
    End Function

End Class