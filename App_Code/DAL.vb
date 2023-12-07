Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Security.Cryptography
Imports System.IO

#Region "Class Implementation"
Public Class CLS_JR_Login
    Inherits db_Connection
    Implements IJRModule(Of PRP_JRLogin)

    Public Sub New()
        MyBase.New("cnhrm1") 'Maintenance Development Database
    End Sub

    Public Sub PrintPDF()
        'Dim DivContent As HtmlControl
        ' HttpContext.Current.Response.ContentType = "Application/pdf";
        '    HttpContext.Current.Response.AddHeader("Content-Disposition", "Attachment; filename=Document.pdf");
        '    HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
        'Dim StringWriter As System.IO.StringWriter = New System.IO.StringWriter()
        'Dim hw As HtmlTextWriter = New HtmlTextWriter(StringWriter)
        'DivContent.RenderControl(hw)
        'Dim doc As Document = New Document(PageSize.A4, 50.0F, 50.0F, 100.0F, 30.0F)
        'Dim htw As HTMLWorker = New HTMLWorker(doc)
        '    PdfWriter.GetInstance(doc, Response.OutputStream);
        '    doc.Open();
        '    StringReader sr = new StringReader(StringWriter.ToString());
        '    htw.Parse(sr);
        '    doc.Close();Response.Write(doc);
        '    Response.End();
    End Sub


    Public Function Check_User_Login(ByVal varusrcod As String, ByVal varusrpwd As String) As QueryResponse(Of PRP_users)
        Dim res As New QueryResponse(Of PRP_users)
        openConnection()
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "JR_Check_User"
            cmd.Parameters.Add("@emp_cd", SqlDbType.NVarChar, 6).Value = varusrcod
            cmd.Parameters.Add("@sec_cd", SqlDbType.NVarChar, 400).Value = varusrpwd
            cmd.Parameters.Add("@empFound", SqlDbType.Int)
            cmd.Parameters("@empFound").Direction = ParameterDirection.Output
            Dim i As Integer = cmd.ExecuteNonQuery()
            res.responseObject = New PRP_users()
            res.responseObject.outres = Convert.ToInt32(cmd.Parameters("@empFound").Value)
            res.response = res.responseObject.outres
            res.responseMsg = ""
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
            closeConnection()
        End Try
        Return res
    End Function

    Public Function Check_Password(ByVal args As PRP_JRLogin) As QueryResponse(Of PRP_users)
        Dim res As New QueryResponse(Of PRP_users)

        openConnection()
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "JR_Check_Password"
            cmd.Parameters.Add("@emp_cd", SqlDbType.NVarChar, 6).Value = args.emp_cd
            cmd.Parameters.Add("@sec_cd", SqlDbType.NVarChar, 400).Value = args.userpass
            cmd.Parameters.Add("@empFound", SqlDbType.Int)
            cmd.Parameters("@empFound").Direction = ParameterDirection.Output
            Dim i As Integer = cmd.ExecuteNonQuery()
            res.responseObject = New PRP_users()
            res.responseObject.outres = Convert.ToInt32(cmd.Parameters("@empFound").Value)
            res.response = res.responseObject.outres
            res.responseMsg = ""
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
            closeConnection()
        End Try
        Return res
    End Function

    Public Function CheckPasswordValidity(ByVal emp_cd As String) As QueryResponse(Of PRP_JR_CheckLoginValidity)
        Dim res As New QueryResponse(Of PRP_JR_CheckLoginValidity)

        openConnection()
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "JR_checkPasswordValidity"
            cmd.Parameters.Add("@emp_cd", SqlDbType.NVarChar, 6).Value = emp_cd.ToString().Trim()
            cmd.Parameters.Add("@expDays", SqlDbType.Int)
            cmd.Parameters("@expDays").Direction = ParameterDirection.Output
            cmd.Parameters.Add("@message", SqlDbType.VarChar, 200)
            cmd.Parameters("@message").Direction = ParameterDirection.Output
            Dim i As Integer = cmd.ExecuteNonQuery()
            res.responseObject = New PRP_JR_CheckLoginValidity()
            res.responseObject.ExpiryDays = Convert.ToInt64(cmd.Parameters("@expDays").Value)
            res.responseObject.Message = cmd.Parameters("@message").Value.ToString().Trim()
            res.response = 1 : res.responseMsg = ""
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
            closeConnection()
        End Try
        Return res
    End Function


    Public Function Delete(ByVal args As PRP_JRLogin) As QueryResponse(Of PRP_JRLogin) Implements IJRModule(Of PRP_JRLogin).Delete
        Throw New NotImplementedException()
    End Function

    Public Function Insert(ByVal args As PRP_JRLogin) As QueryResponse(Of PRP_JRLogin) Implements IJRModule(Of PRP_JRLogin).Insert
        Throw New NotImplementedException()
    End Function

    Public Function Update(ByVal args As PRP_JRLogin) As QueryResponse(Of PRP_JRLogin) Implements IJRModule(Of PRP_JRLogin).Update
        Dim res As New QueryResponse(Of PRP_JRLogin)
        openConnection()
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "JR_Change_Password"
            cmd.Parameters.Add("emp_cd", SqlDbType.NVarChar, 6).Value = args.emp_cd
            cmd.Parameters.Add("sec_cd", SqlDbType.NVarChar, 50).Value = args.userpass
            res.response = cmd.ExecuteNonQuery()
            res.responseMsg = "Password is Changed Succesfully"
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
            closeConnection()
        End Try
        Return res
    End Function

    Public Function View() As QueryResponse(Of PRP_JRLogin) Implements IJRModule(Of PRP_JRLogin).View
        Throw New NotImplementedException()
    End Function

    Public Function View(ByVal args As PRP_JRLogin) As QueryResponse(Of PRP_JRLogin) Implements IJRModule(Of PRP_JRLogin).View
        Dim res As New QueryResponse(Of PRP_JRLogin)
        openConnection()
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "JR_Display_User"
            cmd.Parameters.Add("@emp_cd", SqlDbType.Char).Value = args.emp_cd.ToString().Trim()
            dat = New SqlDataAdapter(cmd)
            Dim ds As New DataSet()
            dat.Fill(ds)
            Dim no As Int32 = 0
            If ds.Tables(0).Rows.Count > 0 Then
                Dim row As DataRow = ds.Tables(0).Rows(0)
                res.responseObject = New PRP_JRLogin()
                With res.responseObject
                    .emp_cd = row("emp_cd").ToString()
                    .comp_cd = row("comp_cd").ToString()
                    .locn_cd = row("locn_cd").ToString()
                    .present = row("present").ToString()
                    .dept_cd = row("dept_cd").ToString()
                    .end_date = row("end_date").ToString()
                    .start_date = row("start_date").ToString()
                    .userpass = row("userpass").ToString()
                    .dec_userpass = row("userpass").ToString()
                End With
                res.response = 1 : res.responseMsg = ""
            Else
                res.response = -1 : res.responseMsg = ""
            End If
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
            closeConnection()
        End Try
        Return res
    End Function
End Class


Public Class CLS_User_Master
    Inherits db_Connection
    Implements IJRModule(Of PRP_users)

    Public Sub New()
        MyBase.new("cnQuality") 'Maintenance Development Database
    End Sub

    'Public Function Check_User_Login(ByVal varusrcod As String, ByVal varusrpwd As String) As QueryResponse(Of PRP_users)
    '    Dim res As New QueryResponse(Of PRP_users)
    '    openConnection()
    '    cmd = New SqlCommand()
    '    Try
    '        cmd.Connection = con
    '        cmd.CommandType = CommandType.StoredProcedure
    '        cmd.CommandTimeout = 500
    '        cmd.CommandText = "JR_Check_User"
    '        cmd.Parameters.Add("@emp_cd", SqlDbType.NVarChar, 6).Value = varusrcod
    '        cmd.Parameters.Add("@sec_cd", SqlDbType.NVarChar, 50).Value = varusrpwd
    '        Dim p1 As New SqlParameter("@outres", SqlDbType.Int)
    '        p1.Direction = ParameterDirection.ReturnValue
    '        cmd.Parameters.Add(p1)
    '        cmd.ExecuteNonQuery()
    '        res.responseObject = New PRP_users()
    '        res.responseObject.outres = Convert.ToInt32(cmd.Parameters("@outres").Value)
    '        res.response = res.responseObject.outres
    '        res.responseMsg = ""
    '    Catch ex As Exception
    '        res.response = -1 : res.responseMsg = ex.Message.ToString()
    '    Finally
    '        cmd.Dispose()
    '        closeConnection()
    '    End Try
    '    Return res
    'End Function

    Public Function Add_JR_Audit_Trails_Entry(ByVal reason As String, ByVal activity As String, ByVal emp_cd As String) As QueryResponse(Of PRP_JRAccess)
        Dim res As New QueryResponse(Of PRP_JRAccess)
        openConnection()
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "JR_Audit_Trails_Entry"
            cmd.Parameters.Add("@AT_Reason", SqlDbType.VarChar, 1000).Value = reason
            cmd.Parameters.Add("@AT_Activity", SqlDbType.VarChar, 10000).Value = activity
            cmd.Parameters.Add("@AT_UpdatedBy", SqlDbType.Char, 7).Value = emp_cd.ToString().Trim()
            res.response = cmd.ExecuteNonQuery()
            res.responseMsg = ""
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
            closeConnection()
        End Try
        Return res
    End Function

    Public Function Display_User_Name(ByVal varusrcod As String) As QueryResponse(Of PRP_users)
        Dim res As New QueryResponse(Of PRP_users)
        Dim conn As New SqlConnection("User ID=sushil;Initial Catalog=tacl;Data Source=192.168.9.137;password=assushil")
        openConnection()
        cmd = New SqlCommand()
        Try
            cmd.Connection = conn
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "NIS_Display_User"
            cmd.Parameters.Add("@Par", SqlDbType.Int).Value = 3
            cmd.Parameters.Add("@usr_cod", SqlDbType.NVarChar, 6).Value = varusrcod
            dat = New SqlDataAdapter(cmd)
            Dim ds As New DataSet()
            dat.Fill(ds)
            Dim no As Int32 = 0
            If ds.Tables(0).Rows.Count > 0 Then
                Dim drr As DataRow = ds.Tables(0).Rows(0)
                res.responseObject = New PRP_users()
                res.responseObject.empnm = drr("emp_nm").ToString()
                res.response = 1 : res.responseMsg = ""
            Else
                res.response = -1 : res.responseMsg = ""
            End If
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
            closeConnection()
        End Try
        Return res
    End Function

    Public Function Delete(ByVal args As PRP_users) As QueryResponse(Of PRP_users) Implements IJRModule(Of PRP_users).Delete
        Throw New NotImplementedException()
    End Function

    Public Function Insert(ByVal args As PRP_users) As QueryResponse(Of PRP_users) Implements IJRModule(Of PRP_users).Insert
        Throw New NotImplementedException()
    End Function

    Public Function Update(ByVal args As PRP_users) As QueryResponse(Of PRP_users) Implements IJRModule(Of PRP_users).Update
        Throw New NotImplementedException()
    End Function

    Public Function View() As QueryResponse(Of PRP_users) Implements IJRModule(Of PRP_users).View
        Throw New NotImplementedException()
    End Function

    Public Function View(ByVal args As PRP_users) As QueryResponse(Of PRP_users) Implements IJRModule(Of PRP_users).View
        Throw New NotImplementedException()
    End Function
End Class

Public Class CLS_JRRole
    Inherits db_Connection
    Implements IJRModule(Of PRP_JRRole)

    Public Sub New()
        MyBase.New("cnhrm1") 'Maintenance Development Database
    End Sub

    Public Function Display_JRRoles() As QueryResponse(Of PRP_JRRole)
        Dim res As New QueryResponse(Of PRP_JRRole)
        openConnection()
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "JR_Display"
            cmd.Parameters.Add("@par", SqlDbType.Int).Value = 26
            dat = New SqlDataAdapter(cmd)
            Dim ds As New DataSet()
            dat.Fill(ds)
            Dim no As Int32 = 0
            If ds.Tables(0).Rows.Count > 0 Then
                res.responseObjectList = New List(Of PRP_JRRole)
                For Each drr As DataRow In ds.Tables(0).Rows
                    no = no + 1
                    res.responseObjectList.Add(New PRP_JRRole() With {
                        .RoleId = drr("Id").ToString(),
                        .Roles = drr("Roles").ToString()
                    })
                Next
                res.response = 1 : res.responseMsg = ""
            Else
                res.response = -1 : res.responseMsg = "Records not Found"
            End If
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
            closeConnection()
        End Try
        Return res
    End Function

    Public Function UserRoleByUserCode(ByVal usercode As String) As QueryResponse(Of PRP_JRRole)
        Dim res As New QueryResponse(Of PRP_JRRole)
        openConnection()
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "JR_UserRole"
            cmd.Parameters.Add("@emp_cd", SqlDbType.Char).Value = usercode.ToString().Trim()
            dat = New SqlDataAdapter(cmd)
            Dim ds As New DataSet()
            dat.Fill(ds)
            Dim no As Int32 = 0
            If ds.Tables(0).Rows.Count > 0 Then
                res.responseObjectList = New List(Of PRP_JRRole)
                For Each drr As DataRow In ds.Tables(0).Rows
                    no = no + 1
                    res.responseObjectList.Add(New PRP_JRRole() With {
                        .emp_cd = drr("emp_cd").ToString(),
                        .emp_nm = drr("emp_nm").ToString(),
                        .RoleId = drr("RoleId").ToString(),
                        .Roles = drr("Roles").ToString()
                    })
                Next
                res.response = 1 : res.responseMsg = ""
            Else
                res.response = -1 : res.responseMsg = ""
            End If
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
            closeConnection()
        End Try
        Return res
    End Function
    Public Function JR_MaxgetUserRole(ByVal usercode As String) As QueryResponse(Of PRP_JRRole)
        Dim res As New QueryResponse(Of PRP_JRRole)
        openConnection()
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.CommandType = CommandType.Text
            cmd.CommandTimeout = 500
            cmd.CommandText = "SELECT max(RoleID) as RoleID FROM [dbo].[JR_getUserRole](@emp_cd)"
            cmd.Parameters.Add("@emp_cd", SqlDbType.Char).Value = usercode.ToString().Trim()
            dat = New SqlDataAdapter(cmd)
            Dim ds As New DataSet()
            dat.Fill(ds)
            Dim no As Int32 = 0
            If ds.Tables(0).Rows.Count > 0 Then
                Dim row As DataRow = ds.Tables(0).Rows(0)
                res.responseObject = New PRP_JRRole()
                With res.responseObject
                    .RoleId = row("RoleID").ToString()
                End With
                res.response = 1 : res.responseMsg = ""
            Else
                res.response = -1 : res.responseMsg = ""
            End If
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
            closeConnection()
        End Try
        Return res
    End Function

    Public Function JR_MaxgetUserRole(ByVal usercode As String, ByVal auth_cd As String) As QueryResponse(Of PRP_JRRole)
        Dim res As New QueryResponse(Of PRP_JRRole)
        openConnection()
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.CommandType = CommandType.Text
            cmd.CommandTimeout = 500
            cmd.CommandText = "SELECT max(RoleID) as RoleID FROM [dbo].[JR_getAuthRole](@emp_cd,@auth_cd)"
            cmd.Parameters.Add("@emp_cd", SqlDbType.Char).Value = usercode.ToString().Trim()
            cmd.Parameters.Add("@auth_cd", SqlDbType.Char).Value = auth_cd.ToString().Trim()
            dat = New SqlDataAdapter(cmd)
            Dim ds As New DataSet()
            dat.Fill(ds)
            Dim no As Int32 = 0
            If ds.Tables(0).Rows.Count > 0 Then
                Dim row As DataRow = ds.Tables(0).Rows(0)
                res.responseObject = New PRP_JRRole()
                With res.responseObject
                    .RoleId = row("RoleID").ToString()
                End With
                res.response = 1 : res.responseMsg = ""
            Else
                res.response = -1 : res.responseMsg = ""
            End If
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
            closeConnection()
        End Try
        Return res
    End Function


    Public Function JR_getUserRole(ByVal usercode As String, ByVal auth_cd As String) As QueryResponse(Of PRP_JRRole)
        Dim res As New QueryResponse(Of PRP_JRRole)
        openConnection()
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.CommandType = CommandType.Text
            cmd.CommandTimeout = 500
            cmd.CommandText = "SELECT * FROM [dbo].[JR_getAuthRole](@emp_cd,@auth_cd)"
            cmd.Parameters.Add("@emp_cd", SqlDbType.Char).Value = usercode.ToString().Trim()
            cmd.Parameters.Add("@auth_cd", SqlDbType.Char).Value = auth_cd.ToString().Trim()
            dat = New SqlDataAdapter(cmd)
            Dim ds As New DataSet()
            dat.Fill(ds)
            Dim no As Int32 = 0
            If ds.Tables(0).Rows.Count > 0 Then
                res.responseObjectList = New List(Of PRP_JRRole)
                For Each drr As DataRow In ds.Tables(0).Rows
                    no = no + 1
                    res.responseObjectList.Add(New PRP_JRRole() With {
                        .RoleId = drr("RoleID").ToString()
                    })
                Next
                res.response = 1 : res.responseMsg = ""
            Else
                res.response = -1 : res.responseMsg = ""
            End If


            'If ds.Tables(0).Rows.Count > 0 Then
            '    Dim row As DataRow = ds.Tables(0).Rows(0)
            '    res.responseObject = New PRP_JRRole()
            '    With res.responseObject
            '        .RoleId = row("RoleID").ToString()
            '    End With
            '    res.response = 1 : res.responseMsg = ""
            'Else
            '    res.response = -1 : res.responseMsg = ""
            'End If
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
            closeConnection()
        End Try
        Return res
    End Function





    Public Function MenuRoleByUserCode(ByVal usercode As String) As QueryResponse(Of PRP_JRRole)
        Dim res As New QueryResponse(Of PRP_JRRole)
        openConnection()
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "JR_menuRole"
            cmd.Parameters.Add("@emp_cd", SqlDbType.Char).Value = usercode.ToString().Trim()
            dat = New SqlDataAdapter(cmd)
            Dim ds As New DataSet()
            dat.Fill(ds)
            Dim no As Int32 = 0
            If ds.Tables(0).Rows.Count > 0 Then
                Dim row As DataRow = ds.Tables(0).Rows(0)
                res.responseObject = New PRP_JRRole()
                With res.responseObject
                    .RoleId = row("RoleId").ToString()
                End With
                res.response = 1 : res.responseMsg = ""
            Else
                res.response = -1 : res.responseMsg = ""
            End If
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
            closeConnection()
        End Try
        Return res
    End Function

    Public Function Delete(ByVal args As PRP_JRRole) As QueryResponse(Of PRP_JRRole) Implements IJRModule(Of PRP_JRRole).Delete
        Throw New NotImplementedException()
    End Function

    Public Function Insert(ByVal args As PRP_JRRole) As QueryResponse(Of PRP_JRRole) Implements IJRModule(Of PRP_JRRole).Insert
        Throw New NotImplementedException()
    End Function

    Public Function Update(ByVal args As PRP_JRRole) As QueryResponse(Of PRP_JRRole) Implements IJRModule(Of PRP_JRRole).Update
        Throw New NotImplementedException()
    End Function

    Public Function View() As QueryResponse(Of PRP_JRRole) Implements IJRModule(Of PRP_JRRole).View
        Throw New NotImplementedException()
    End Function

    Public Function View(ByVal args As PRP_JRRole) As QueryResponse(Of PRP_JRRole) Implements IJRModule(Of PRP_JRRole).View
        Throw New NotImplementedException()
    End Function
End Class

Public Class CLS_JRMenu
    Inherits db_Connection
    Implements IJRModule(Of PRP_JRMenu)

    Public Sub New()
        MyBase.New("cnhrm1") 'Maintenance Development Database
    End Sub

    Public Function Delete(ByVal args As PRP_JRMenu) As QueryResponse(Of PRP_JRMenu) Implements IJRModule(Of PRP_JRMenu).Delete
        Throw New NotImplementedException()
    End Function

    Public Function Insert(ByVal args As PRP_JRMenu) As QueryResponse(Of PRP_JRMenu) Implements IJRModule(Of PRP_JRMenu).Insert
        Throw New NotImplementedException()
    End Function

    Public Function Update(ByVal args As PRP_JRMenu) As QueryResponse(Of PRP_JRMenu) Implements IJRModule(Of PRP_JRMenu).Update
        Throw New NotImplementedException()
    End Function

    Public Function View() As QueryResponse(Of PRP_JRMenu) Implements IJRModule(Of PRP_JRMenu).View
        Throw New NotImplementedException()
    End Function

    Public Function View(ByVal args As PRP_JRMenu) As QueryResponse(Of PRP_JRMenu) Implements IJRModule(Of PRP_JRMenu).View
        Throw New NotImplementedException()
    End Function

    Public Function ShowJRMenus(ByVal roleID As Integer, ByVal parentId As Integer, ByVal usercd As String) As QueryResponse(Of PRP_JRMenu)
        Dim res As New QueryResponse(Of PRP_JRMenu)
        openConnection()
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "JR_menuAccess"
            cmd.Parameters.Add("@roleId", SqlDbType.Int).Value = roleID
            cmd.Parameters.Add("@parentId", SqlDbType.Int).Value = parentId
            cmd.Parameters.Add("@emp_cd", SqlDbType.Char).Value = usercd.ToString().Trim()
            dat = New SqlDataAdapter(cmd)
            Dim ds As New DataSet()
            dat.Fill(ds)
            Dim no As Int32 = 0
            If ds.Tables(0).Rows.Count > 0 Then
                res.responseObjectList = New List(Of PRP_JRMenu)
                For Each drr As DataRow In ds.Tables(0).Rows
                    no = no + 1
                    res.responseObjectList.Add(New PRP_JRMenu() With {
                        .MenuId = drr("MenuId").ToString(),
                        .Title = drr("Title").ToString(),
                        .Url = drr("Url").ToString(),
                        .RoleId = drr("RoleId").ToString(),
                        .Roles = drr("Roles").ToString()
                    })
                Next
                res.response = 1 : res.responseMsg = ""
            Else
                res.response = -1 : res.responseMsg = ""
            End If
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
            closeConnection()
        End Try
        Return res
    End Function

End Class

Public Class CLS_JRAccess
    Inherits db_Connection
    Implements IJRModule(Of PRP_JRAccess)

    Public Sub New()
        MyBase.New("cnhrm1") 'Maintenance Development Database
    End Sub

    Public Function Delete(ByVal args As PRP_JRAccess) As QueryResponse(Of PRP_JRAccess) Implements IJRModule(Of PRP_JRAccess).Delete
        Throw New NotImplementedException()
    End Function

    Public Function Insert(ByVal args As PRP_JRAccess) As QueryResponse(Of PRP_JRAccess) Implements IJRModule(Of PRP_JRAccess).Insert
        Dim res As New QueryResponse(Of PRP_JRAccess)
        openConnection()
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "JR_InsertUser"
            cmd.Parameters.Add("@Emp_cd", SqlDbType.NVarChar, 10).Value = args.Emp_cd
            cmd.Parameters.Add("@Dept_cd", SqlDbType.Int).Value = args.Dept_cd
            cmd.Parameters.Add("@is_DTC", SqlDbType.NVarChar, 10).Value = args.is_DTC
            cmd.Parameters.Add("@locn_cd", SqlDbType.NVarChar, 10).Value = args.locn_cd
            res.response = cmd.ExecuteNonQuery()
            res.responseMsg = "JR Login ID saved successfully"
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
            closeConnection()
        End Try
        Return res
    End Function

    Public Function Update(ByVal args As PRP_JRAccess) As QueryResponse(Of PRP_JRAccess) Implements IJRModule(Of PRP_JRAccess).Update
        Dim res As New QueryResponse(Of PRP_JRAccess)
        openConnection()
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "JR_UpdateUser"
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = args.ID
            cmd.Parameters.Add("@Emp_cd", SqlDbType.NVarChar, 10).Value = args.Emp_cd
            cmd.Parameters.Add("@Dept_cd", SqlDbType.Int).Value = args.Dept_cd
            cmd.Parameters.Add("@is_DTC", SqlDbType.NVarChar, 10).Value = args.is_DTC
            res.response = cmd.ExecuteNonQuery()
            res.responseMsg = "JR Login ID updated successfully"
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
            closeConnection()
        End Try
        Return res
    End Function

    Public Function View() As QueryResponse(Of PRP_JRAccess) Implements IJRModule(Of PRP_JRAccess).View
        Throw New NotImplementedException()
    End Function

    Public Function View(ByVal args As PRP_JRAccess) As QueryResponse(Of PRP_JRAccess) Implements IJRModule(Of PRP_JRAccess).View
        Throw New NotImplementedException()
    End Function

    Public Function GetEmployeeDetails(ByVal emp_cd As String) As QueryResponse(Of PRP_JRAccess)
        Dim res As New QueryResponse(Of PRP_JRAccess)
        res.responseObject = New PRP_JRAccess()
        openConnection()
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "JR_Display"
            cmd.Parameters.Add("@Par", SqlDbType.Int).Value = 14
            cmd.Parameters.Add("@emp_cd", SqlDbType.NVarChar, 6).Value = emp_cd.ToString()
            dat = New SqlDataAdapter(cmd)
            Dim ds As New DataSet()
            dat.Fill(ds)

            If ds.Tables(0).Rows.Count > 0 Then
                res.responseObjectList = New List(Of PRP_JRAccess)
                For Each drr As DataRow In ds.Tables(0).Rows
                    res.responseObjectList.Add(New PRP_JRAccess() With {
                        .Dept_cd = drr("dept_cd").ToString(),
                        .Dept_nm = drr("dept_nm").ToString(),
                        .desig_nm = drr("desig_nm").ToString(),
                        .desig_cd = drr("desig_cd").ToString(),
                        .catg_cd = drr("catg_cd").ToString(),
                        .catg_nm = drr("catg_nm").ToString(),
                        .Emp_nm = drr("Emp_nm").ToString(),
                        .Emp_cd = drr("Emp_cd").ToString(),
                        .locn_cd = drr("locn_cd").ToString()
                    })
                Next
                res.response = 1 : res.responseMsg = ""
            Else
                res.response = -1 : res.responseMsg = "Department not Found"
            End If
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
            closeConnection()
        End Try
        Return res
    End Function

    Public Function GetSelectedEXisting_EmployeeDetails(ByVal emp_cd As String) As QueryResponse(Of PRP_JRAccess)
        Dim res As New QueryResponse(Of PRP_JRAccess)
        res.responseObject = New PRP_JRAccess()
        openConnection()
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "JR_Display"
            cmd.Parameters.Add("@Par", SqlDbType.Int).Value = 16
            cmd.Parameters.Add("@emp_cd", SqlDbType.NVarChar, 6).Value = emp_cd.ToString()
            dat = New SqlDataAdapter(cmd)
            Dim ds As New DataSet()
            dat.Fill(ds)

            If ds.Tables(0).Rows.Count > 0 Then
                res.responseObjectList = New List(Of PRP_JRAccess)
                For Each drr As DataRow In ds.Tables(0).Rows
                    res.responseObjectList.Add(New PRP_JRAccess() With {
                        .ID = drr("id").ToString(),
                        .Dept_cd = drr("dept_cd").ToString(),
                        .Dept_nm = drr("dept_nm").ToString(),
                        .desig_nm = drr("desig_nm").ToString(),
                        .desig_cd = drr("desig_cd").ToString(),
                        .catg_cd = drr("catg_cd").ToString(),
                        .catg_nm = drr("catg_nm").ToString(),
                        .Emp_nm = drr("Emp_nm").ToString(),
                        .Emp_cd = drr("Emp_cd").ToString(),
                        .is_DTC = drr("is_DTC").ToString(),
                        .locn_cd = drr("locn_cd").ToString()
                    })
                Next
                res.response = 1 : res.responseMsg = ""
            Else
                res.response = -1 : res.responseMsg = "Department not Found"
            End If
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
            closeConnection()
        End Try
        Return res
    End Function

End Class

Public Class CLS_JRInbox
    Inherits db_Connection
    Implements IJRModule(Of PRP_JRInbox)

    Public Sub New()
        MyBase.New("cnhrm1") 'Maintenance Development Database
    End Sub


    Public Function Delete(ByVal args As PRP_JRInbox) As QueryResponse(Of PRP_JRInbox) Implements IJRModule(Of PRP_JRInbox).Delete
        Throw New NotImplementedException()
    End Function

    Public Function Insert(ByVal args As PRP_JRInbox) As QueryResponse(Of PRP_JRInbox) Implements IJRModule(Of PRP_JRInbox).Insert
        Throw New NotImplementedException()
    End Function

    Public Function Update(ByVal args As PRP_JRInbox) As QueryResponse(Of PRP_JRInbox) Implements IJRModule(Of PRP_JRInbox).Update
        Throw New NotImplementedException()
    End Function

    Public Function View() As QueryResponse(Of PRP_JRInbox) Implements IJRModule(Of PRP_JRInbox).View
        Throw New NotImplementedException()
    End Function

    Public Function View(ByVal args As PRP_JRInbox) As QueryResponse(Of PRP_JRInbox) Implements IJRModule(Of PRP_JRInbox).View
        Throw New NotImplementedException()
    End Function

    Public Function Display_JRInbox(ByVal empcd As String) As QueryResponse(Of PRP_JRInbox)
        Dim res As New QueryResponse(Of PRP_JRInbox)
        openConnection()
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "JR_Display"
            cmd.Parameters.Add("@par", SqlDbType.Int).Value = 10
            cmd.Parameters.Add("@emp_cd", SqlDbType.VarChar).Value = empcd.ToString().Trim()
            dat = New SqlDataAdapter(cmd)
            Dim ds As New DataSet()
            dat.Fill(ds)
            Dim no As Int32 = 0
            If ds.Tables(0).Rows.Count > 0 Then
                res.responseObjectList = New List(Of PRP_JRInbox)
                For Each drr As DataRow In ds.Tables(0).Rows
                    no = no + 1
                    res.responseObjectList.Add(New PRP_JRInbox() With {
                        .Id = drr("Id").ToString(),
                        .emp_cd = drr("emp_cd").ToString(),
                        .emp_nm = drr("emp_nm").ToString(),
                        .Dept_Cd = drr("Dept_Cd").ToString(),
                        .Dept_Nm = drr("Dept_Nm").ToString(),
                        .Desig_Nm = drr("Desig_Nm").ToString(),
                        .final_auth_cd_dept = drr("final_auth_cd_dept").ToString(),
                        .final_auth_cd_hr = drr("final_auth_cd_hr").ToString()
                    })
                Next
                res.response = 1 : res.responseMsg = ""
            Else
                res.response = -1 : res.responseMsg = "Records not Found"
            End If
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
            closeConnection()
        End Try
        Return res
    End Function
    Public Function Display_JROutbox(ByVal empcd As String) As QueryResponse(Of PRP_JRInbox)
        Dim res As New QueryResponse(Of PRP_JRInbox)
        openConnection()
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "JR_Display"
            cmd.Parameters.Add("@par", SqlDbType.Int).Value = 12
            cmd.Parameters.Add("@emp_cd", SqlDbType.VarChar).Value = empcd.ToString().Trim()
            dat = New SqlDataAdapter(cmd)
            Dim ds As New DataSet()
            dat.Fill(ds)
            Dim no As Int32 = 0
            If ds.Tables(0).Rows.Count > 0 Then
                res.responseObjectList = New List(Of PRP_JRInbox)
                For Each drr As DataRow In ds.Tables(0).Rows
                    no = no + 1
                    res.responseObjectList.Add(New PRP_JRInbox() With {
                        .Id = drr("Id").ToString(),
                        .emp_cd = drr("emp_cd").ToString(),
                        .emp_nm = drr("emp_nm").ToString(),
                        .Dept_Cd = drr("Dept_Cd").ToString(),
                        .Dept_Nm = drr("Dept_Nm").ToString(),
                        .Desig_Nm = drr("Desig_Nm").ToString(),
                        .final_auth_cd_dept = drr("final_auth_cd_dept").ToString(),
                        .final_auth_cd_hr = drr("final_auth_cd_hr").ToString()
                    })
                Next
                res.response = 1 : res.responseMsg = ""
            Else
                res.response = -1 : res.responseMsg = "Records not Found"
            End If
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
            closeConnection()
        End Try
        Return res
    End Function
    Public Function Display_JRFinalApprovalInbox(ByVal empcd As String) As QueryResponse(Of PRP_JRInbox)
        Dim res As New QueryResponse(Of PRP_JRInbox)
        openConnection()
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "JR_Display"
            cmd.Parameters.Add("@par", SqlDbType.Int).Value = 19
            cmd.Parameters.Add("@emp_cd", SqlDbType.VarChar).Value = empcd.ToString().Trim()
            dat = New SqlDataAdapter(cmd)
            Dim ds As New DataSet()
            dat.Fill(ds)
            Dim no As Int32 = 0
            If ds.Tables(0).Rows.Count > 0 Then
                res.responseObjectList = New List(Of PRP_JRInbox)
                For Each drr As DataRow In ds.Tables(0).Rows
                    no = no + 1
                    res.responseObjectList.Add(New PRP_JRInbox() With {
                        .Id = drr("Id").ToString(),
                        .emp_cd = drr("emp_cd").ToString(),
                        .emp_nm = drr("emp_nm").ToString(),
                        .Dept_Cd = drr("Dept_Cd").ToString(),
                        .Dept_Nm = drr("Dept_Nm").ToString(),
                        .Desig_Nm = drr("Desig_Nm").ToString(),
                        .final_auth_cd_dept = drr("final_auth_cd_dept").ToString(),
                        .final_auth_cd_hr = drr("final_auth_cd_hr").ToString()
                    })
                Next
                res.response = 1 : res.responseMsg = ""
            Else
                res.response = -1 : res.responseMsg = "Records not Found"
            End If
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
            closeConnection()
        End Try
        Return res
    End Function
    Public Function Display_JRHODApprovalInbox(ByVal empcd As String) As QueryResponse(Of PRP_JRInbox)
        Dim res As New QueryResponse(Of PRP_JRInbox)
        openConnection()
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "JR_Display"
            cmd.Parameters.Add("@par", SqlDbType.Int).Value = 20
            cmd.Parameters.Add("@emp_cd", SqlDbType.VarChar).Value = empcd.ToString().Trim()
            dat = New SqlDataAdapter(cmd)
            Dim ds As New DataSet()
            dat.Fill(ds)
            Dim no As Int32 = 0
            If ds.Tables(0).Rows.Count > 0 Then
                res.responseObjectList = New List(Of PRP_JRInbox)
                For Each drr As DataRow In ds.Tables(0).Rows
                    no = no + 1
                    res.responseObjectList.Add(New PRP_JRInbox() With {
                        .Id = drr("Id").ToString(),
                        .emp_cd = drr("emp_cd").ToString(),
                        .emp_nm = drr("emp_nm").ToString(),
                        .Dept_Cd = drr("Dept_Cd").ToString(),
                        .Dept_Nm = drr("Dept_Nm").ToString(),
                        .Desig_Nm = drr("Desig_Nm").ToString(),
                        .final_auth_cd_dept = drr("final_auth_cd_dept").ToString(),
                        .final_auth_cd_hr = drr("final_auth_cd_hr").ToString()
                    })
                Next
                res.response = 1 : res.responseMsg = ""
            Else
                res.response = -1 : res.responseMsg = "Records not Found"
            End If
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
            closeConnection()
        End Try
        Return res
    End Function

End Class

Public Class cls_Lv_emp_Sec
    Inherits db_Connection
    Implements IJRModule(Of PRP_lv_emp_sec)


    Public Sub New()
        MyBase.new("cnl") 'Maintenance Development Database
    End Sub

    Public Function Check_Password(ByVal varempcd As String, ByVal varoldpwd As String) As QueryResponse(Of PRP_lv_emp_sec)
        Dim res As New QueryResponse(Of PRP_lv_emp_sec)
        openConnection()
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "NIS_Check_Password"
            cmd.Parameters.Add("@Par", SqlDbType.NVarChar, 6).Value = 1
            cmd.Parameters.Add("@emp_cd", SqlDbType.NVarChar, 6).Value = varempcd
            cmd.Parameters.Add("@sec_cd", SqlDbType.NVarChar, 50).Value = varoldpwd
            Dim p1 As New SqlParameter("@outres", SqlDbType.Int)
            p1.Direction = ParameterDirection.ReturnValue
            cmd.Parameters.Add(p1)
            cmd.CommandType = CommandType.StoredProcedure
            res.response = cmd.ExecuteNonQuery()
            res.slipNo = Convert.ToInt32(cmd.Parameters("@outres").Value)
            res.responseMsg = ""
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
            closeConnection()
        End Try
        Return res
    End Function


    Public Function Delete(ByVal args As PRP_lv_emp_sec) As QueryResponse(Of PRP_lv_emp_sec) Implements IJRModule(Of PRP_lv_emp_sec).Delete
        Throw New NotImplementedException()
    End Function

    Public Function Insert(ByVal args As PRP_lv_emp_sec) As QueryResponse(Of PRP_lv_emp_sec) Implements IJRModule(Of PRP_lv_emp_sec).Insert
        Throw New NotImplementedException()
    End Function

    Public Function Update(ByVal args As PRP_lv_emp_sec) As QueryResponse(Of PRP_lv_emp_sec) Implements IJRModule(Of PRP_lv_emp_sec).Update
        Dim res As New QueryResponse(Of PRP_lv_emp_sec)
        openConnection()
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "NIS_Change_Password"
            cmd.Parameters.Add("par", SqlDbType.Int).Value = 1
            cmd.Parameters.Add("emp_cd", SqlDbType.NVarChar, 6).Value = args.emp_cd
            cmd.Parameters.Add("sec_cd", SqlDbType.NVarChar, 50).Value = args.sec_cd
            res.response = cmd.ExecuteNonQuery()
            res.responseMsg = "Password is Changed Succesfully"
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
            closeConnection()
        End Try
        Return res
    End Function

    Public Function View() As QueryResponse(Of PRP_lv_emp_sec) Implements IJRModule(Of PRP_lv_emp_sec).View
        Throw New NotImplementedException()
    End Function

    Public Function View(ByVal args As PRP_lv_emp_sec) As QueryResponse(Of PRP_lv_emp_sec) Implements IJRModule(Of PRP_lv_emp_sec).View
        Throw New NotImplementedException()
    End Function
End Class

Public Class cls_Department
    Inherits db_Connection
    Implements IJRModule(Of PRP_Department)


    Public Sub New()
        MyBase.new("cnhrm1") 'Maintenance Development Database
    End Sub

    Public Function Delete(ByVal args As PRP_Department) As QueryResponse(Of PRP_Department) Implements IJRModule(Of PRP_Department).Delete
        Throw New NotImplementedException()
    End Function

    Public Function Insert(ByVal args As PRP_Department) As QueryResponse(Of PRP_Department) Implements IJRModule(Of PRP_Department).Insert
        Throw New NotImplementedException()
    End Function

    Public Function Update(ByVal args As PRP_Department) As QueryResponse(Of PRP_Department) Implements IJRModule(Of PRP_Department).Update
        Throw New NotImplementedException()
    End Function

    Public Function View() As QueryResponse(Of PRP_Department) Implements IJRModule(Of PRP_Department).View
        Dim res As New QueryResponse(Of PRP_Department)
        Dim c As Int64 = 0
        Dim rettyp As String = ""
        openConnection()
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "JR_Display"
            cmd.Parameters.Add("@Par", SqlDbType.Int).Value = 1
            cmd.Parameters.Add("@emp_cd", SqlDbType.NVarChar).Value = System.Web.HttpContext.Current.Session("usrnam")
            dat = New SqlDataAdapter(cmd)
            Dim ds As New DataSet()
            dat.Fill(ds)
            If ds.Tables(0).Rows.Count > 0 Then
                res.responseObjectList = New List(Of PRP_Department)
                For Each row As DataRow In ds.Tables(0).Rows
                    res.responseObjectList.Add(New PRP_Department() With {
                    .dept_cd = row("dept_cd").ToString(),
                    .dept_nm = row("dept_nm").ToString().Trim()
                    })
                Next
                res.response = 1 : res.responseMsg = ""
            Else
                res.response = -1 : res.responseMsg = ""
            End If
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
            closeConnection()
        End Try
        Return res
    End Function
    Public Function getDepartmentList(ByVal empcd As String) As QueryResponse(Of PRP_Department)
        Dim res As New QueryResponse(Of PRP_Department)
        Dim c As Int64 = 0
        Dim rettyp As String = ""
        openConnection()
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "JR_Display"
            cmd.Parameters.Add("@Par", SqlDbType.Int).Value = 17
            cmd.Parameters.Add("@emp_cd", SqlDbType.NVarChar).Value = empcd.ToString().Trim()
            dat = New SqlDataAdapter(cmd)
            Dim ds As New DataSet()
            dat.Fill(ds)
            If ds.Tables(0).Rows.Count > 0 Then
                res.responseObjectList = New List(Of PRP_Department)
                For Each row As DataRow In ds.Tables(0).Rows
                    res.responseObjectList.Add(New PRP_Department() With {
                    .dept_cd = row("dept_cd").ToString().Trim(),
                    .dept_nm = row("dept_nm").ToString().Trim()
                    })
                Next
                res.response = 1 : res.responseMsg = ""
            Else
                res.response = -1 : res.responseMsg = ""
            End If
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
            closeConnection()
        End Try
        Return res
    End Function
    Public Function getDepartmentListtoFirstAuthority(ByVal empcd As String) As QueryResponse(Of PRP_Department)
        Dim res As New QueryResponse(Of PRP_Department)
        Dim c As Int64 = 0
        Dim rettyp As String = ""
        openConnection()
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "JR_Display"
            cmd.Parameters.Add("@Par", SqlDbType.Int).Value = 22
            cmd.Parameters.Add("@emp_cd", SqlDbType.NVarChar).Value = empcd.ToString().Trim()
            dat = New SqlDataAdapter(cmd)
            Dim ds As New DataSet()
            dat.Fill(ds)
            If ds.Tables(0).Rows.Count > 0 Then
                res.responseObjectList = New List(Of PRP_Department)
                For Each row As DataRow In ds.Tables(0).Rows
                    res.responseObjectList.Add(New PRP_Department() With {
                    .dept_cd = row("dept_cd").ToString(),
                    .dept_nm = row("dept_nm").ToString().Trim()
                    })
                Next
                res.response = 1 : res.responseMsg = ""
            Else
                res.response = -1 : res.responseMsg = ""
            End If
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
            closeConnection()
        End Try
        Return res
    End Function



    Public Function View(ByVal args As PRP_Department) As QueryResponse(Of PRP_Department) Implements IJRModule(Of PRP_Department).View
        Throw New NotImplementedException()
    End Function
End Class

Public Class cls_Employee
    Inherits db_Connection
    Implements IJRModule(Of PRP_Employee)


    Public Sub New()
        MyBase.new("cnhrm1") 'Maintenance Development Database
    End Sub

    Public Function View() As QueryResponse(Of PRP_Employee) Implements IJRModule(Of PRP_Employee).View
        Throw New NotImplementedException()
    End Function

    Public Function View(ByVal args As PRP_Employee) As QueryResponse(Of PRP_Employee) Implements IJRModule(Of PRP_Employee).View
        Throw New NotImplementedException()
    End Function

    Public Function View(ByVal vardeptcd As String) As QueryResponse(Of PRP_Employee)
        Dim res As New QueryResponse(Of PRP_Employee)
        Dim c As Int64 = 0
        Dim rettyp As String = ""
        openConnection()
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "JR_Display"
            cmd.Parameters.Add("@Par", SqlDbType.Int).Value = 2
            cmd.Parameters.Add("@dept_cd", SqlDbType.NVarChar, 11).Value = vardeptcd
            dat = New SqlDataAdapter(cmd)
            Dim ds As New DataSet()
            dat.Fill(ds)
            If ds.Tables(0).Rows.Count > 0 Then
                res.responseObjectList = New List(Of PRP_Employee)
                For Each row As DataRow In ds.Tables(0).Rows
                    res.responseObjectList.Add(New PRP_Employee() With {
                    .emp_nm = row("emp_nm").ToString().Trim,
                    .emp_cd = row("emp_cd").ToString().Trim
                    })
                Next
                res.response = 1 : res.responseMsg = ""
            Else
                res.response = -1 : res.responseMsg = "Employees List not Found"
            End If
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
            closeConnection()
        End Try
        Return res
    End Function
    Public Function GetEmployeeListforJREntry(ByVal vardeptcd As String, ByVal varempcd As String) As QueryResponse(Of PRP_Employee)
        Dim res As New QueryResponse(Of PRP_Employee)
        Dim c As Int64 = 0
        Dim rettyp As String = ""
        openConnection()
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "JR_Display"
            cmd.Parameters.Add("@Par", SqlDbType.Int).Value = 21
            cmd.Parameters.Add("@emp_cd", SqlDbType.NVarChar, 11).Value = varempcd
            cmd.Parameters.Add("@dept_cd", SqlDbType.NVarChar, 11).Value = vardeptcd
            dat = New SqlDataAdapter(cmd)
            Dim ds As New DataSet()
            dat.Fill(ds)
            If ds.Tables(0).Rows.Count > 0 Then
                res.responseObjectList = New List(Of PRP_Employee)
                For Each row As DataRow In ds.Tables(0).Rows
                    res.responseObjectList.Add(New PRP_Employee() With {
                    .emp_nm = row("emp_nm").ToString().Trim,
                    .emp_cd = row("emp_cd").ToString().Trim
                    })
                Next
                res.response = 1 : res.responseMsg = ""
            Else
                res.response = -1 : res.responseMsg = "Employees List not Found"
            End If
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
            closeConnection()
        End Try
        Return res
    End Function

    Public Function checkJRAuth(ByVal empcd As String) As QueryResponse(Of PRP_Employee)
        Dim res As New QueryResponse(Of PRP_Employee)
        openConnection()
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "JR_Display"
            cmd.Parameters.Add("@Par", SqlDbType.Int).Value = 27
            cmd.Parameters.Add("@emp_cd", SqlDbType.NVarChar, 11).Value = empcd.ToString().Trim()
            dat = New SqlDataAdapter(cmd)
            Dim ds As New DataSet()
            dat.Fill(ds)
            Dim no As Int32 = 0
            If ds.Tables(0).Rows.Count > 0 Then
                Dim drr As DataRow = ds.Tables(0).Rows(0)
                res.responseObject = New PRP_Employee()
                res.responseObject.emp_cd = drr("emp_cd").ToString()
                res.response = 1 : res.responseMsg = ""
            Else
                res.response = -1 : res.responseMsg = ""
            End If
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
            closeConnection()
        End Try
        Return res
    End Function

    Public Function AllEmployee_notExistinJRSys() As QueryResponse(Of PRP_Employee)
        Dim res As New QueryResponse(Of PRP_Employee)
        openConnection()
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "JR_Display"
            cmd.Parameters.Add("@Par", SqlDbType.Int).Value = 13
            dat = New SqlDataAdapter(cmd)
            Dim ds As New DataSet()
            dat.Fill(ds)
            Dim no As Int32 = 0
            If ds.Tables(0).Rows.Count > 0 Then
                res.responseObjectList = New List(Of PRP_Employee)
                For Each row As DataRow In ds.Tables(0).Rows
                    res.responseObjectList.Add(New PRP_Employee() With {
                    .emp_nm = row("emp_nm").ToString().Trim,
                    .emp_cd = row("emp_cd").ToString().Trim
                    })
                Next
                res.response = 1 : res.responseMsg = ""
            Else
                res.response = -1 : res.responseMsg = "Employees List not Found"
            End If
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
            closeConnection()
        End Try
        Return res
    End Function
    Public Function AllEmployee_ExistinJRSys() As QueryResponse(Of PRP_Employee)
        Dim res As New QueryResponse(Of PRP_Employee)
        openConnection()
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "JR_Display"
            cmd.Parameters.Add("@Par", SqlDbType.Int).Value = 15
            dat = New SqlDataAdapter(cmd)
            Dim ds As New DataSet()
            dat.Fill(ds)
            Dim no As Int32 = 0
            If ds.Tables(0).Rows.Count > 0 Then
                res.responseObjectList = New List(Of PRP_Employee)
                For Each row As DataRow In ds.Tables(0).Rows
                    res.responseObjectList.Add(New PRP_Employee() With {
                    .emp_nm = row("emp_nm").ToString().Trim,
                    .emp_cd = row("emp_cd").ToString().Trim
                    })
                Next
                res.response = 1 : res.responseMsg = ""
            Else
                res.response = -1 : res.responseMsg = "Employees List not Found"
            End If
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
            closeConnection()
        End Try
        Return res
    End Function


    ''Sushil 21-09-2021
    Public Function Display_EmployeeDetail(ByVal varempcd As String) As QueryResponse(Of PRP_EmployeeDetail)
        Dim res As New QueryResponse(Of PRP_EmployeeDetail)
        openConnection()
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "JR_Display"
            cmd.Parameters.Add("@Par", SqlDbType.Int).Value = 3
            cmd.Parameters.Add("@emp_cd", SqlDbType.NVarChar, 11).Value = varempcd

            dat = New SqlDataAdapter(cmd)
            Dim ds As New DataSet()
            dat.Fill(ds)
            Dim no As Int32 = 0
            If ds.Tables(0).Rows.Count > 0 Then
                Dim drr As DataRow = ds.Tables(0).Rows(0)
                res.responseObject = New PRP_EmployeeDetail()
                res.responseObject.emp_cd = varempcd
                res.responseObject.emp_nm = drr("emp_nm").ToString()
                res.responseObject.dept_nm = drr("dept_nm").ToString()
                res.responseObject.desig_nm = drr("desig_nm").ToString()
                res.responseObject.dept_cd = drr("dept_cd").ToString()
                res.responseObject.catg_cd = drr("catg_cd").ToString()
                res.responseObject.catg_nm = drr("catg_nm").ToString()
                res.responseObject.dt_join = drr("dt_join").ToString()

                res.response = 1 : res.responseMsg = ""
            Else
                res.response = -1 : res.responseMsg = ""
            End If
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
            closeConnection()
        End Try
        Return res
    End Function
    ''Sushil 21-09-2021

    Public Function Delete(ByVal args As PRP_Employee) As QueryResponse(Of PRP_Employee) Implements IJRModule(Of PRP_Employee).Delete
        Throw New NotImplementedException()
    End Function

    Public Function Insert(ByVal args As PRP_Employee) As QueryResponse(Of PRP_Employee) Implements IJRModule(Of PRP_Employee).Insert
        Throw New NotImplementedException()
    End Function

    Public Function Update(ByVal args As PRP_Employee) As QueryResponse(Of PRP_Employee) Implements IJRModule(Of PRP_Employee).Update
        Throw New NotImplementedException()
    End Function
End Class

Public Class CLS_JRHdr
    Inherits db_Connection
    Implements IJRModule(Of PRP_JRHdr)
    Public Sub New()
        MyBase.new("cnhrm1") 'Maintenance Development Database
    End Sub

    Public Function SaveJREntry(ByVal args As PRP_JRHdr) As QueryResponse(Of PRP_JRHdr)
        Dim res As New QueryResponse(Of PRP_JRHdr)
        Dim obj_hdr As New CLS_JRHdr
        If args.btnsave = "Save" Then
            res = New QueryResponse(Of PRP_JRHdr)
            ' args.revision_date = "1900-01-01"
            res = Save_JR_hdr(args)
            args.Id = res.CheckID
        ElseIf args.btnsave = "Update" Then
            res = New QueryResponse(Of PRP_JRHdr)
            res = Update_JR_hdr(args)
        End If
        If res.response = 1 Then
            If args.btnsave.Trim() = "Save" Then res.responseMsg = "JR Saved Successfully." Else If args.btnsave.Trim() = "Update" Then res.responseMsg = "JR Updated Successfully."
            If res.CheckID = -2 Then
                res.responseMsg = "This JR is already exist."
            End If
        End If
        Return res

    End Function

    Public Function getUserPassword(ByVal empcd As String) As QueryResponse(Of PRP_JRHdr)
        Dim res As New QueryResponse(Of PRP_JRHdr)
        openConnection()
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "JR_Display"
            cmd.Parameters.Add("@Par", SqlDbType.Int).Value = 32
            cmd.Parameters.Add("@emp_cd", SqlDbType.NVarChar, 11).Value = empcd

            dat = New SqlDataAdapter(cmd)
            Dim ds As New DataSet()
            dat.Fill(ds)
            If ds.Tables.Count > 0 Then
                If ds.Tables(0).Rows.Count > 0 Then
                    Dim drr As DataRow = ds.Tables(0).Rows(0)
                    res.responseObject = New PRP_JRHdr()
                    With res.responseObject
                        .userpass = drr(0).ToString().Trim()
                    End With
                    res.response = 1 : res.responseMsg = ""
                Else
                    res.response = -1 : res.responseMsg = ""
                End If
            Else
                res.response = -1 : res.responseMsg = ""
            End If
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
            closeConnection()
        End Try
        Return res
    End Function

    Public Function getHRMAuthority(ByVal empcd As String) As QueryResponse(Of PRP_JRHdr)
        Dim res As New QueryResponse(Of PRP_JRHdr)
        openConnection()
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "JR_Display"
            cmd.Parameters.Add("@Par", SqlDbType.Int).Value = 35
            cmd.Parameters.Add("@emp_cd", SqlDbType.NVarChar, 11).Value = empcd

            dat = New SqlDataAdapter(cmd)
            Dim ds As New DataSet()
            dat.Fill(ds)
            If ds.Tables.Count > 0 Then
                If ds.Tables(0).Rows.Count > 0 Then
                    Dim drr As DataRow = ds.Tables(0).Rows(0)
                    res.responseObject = New PRP_JRHdr()
                    With res.responseObject
                        .emp_cd = drr(0).ToString().Trim()
                    End With
                    res.response = 1 : res.responseMsg = ""
                Else
                    res.response = -1 : res.responseMsg = ""
                End If
            Else
                res.response = -1 : res.responseMsg = ""
            End If
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
            closeConnection()
        End Try
        Return res
    End Function



    Public Function CheckDuplicate(ByVal empcd As String) As QueryResponse(Of String)
        Dim res As New QueryResponse(Of String)
        openConnection()
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "JR_Display"
            cmd.Parameters.Add("@Par", SqlDbType.Int).Value = 30
            cmd.Parameters.Add("@emp_cd", SqlDbType.NVarChar, 11).Value = empcd

            dat = New SqlDataAdapter(cmd)
            Dim ds As New DataSet()
            dat.Fill(ds)
            If ds.Tables.Count > 0 Then
                If ds.Tables(0).Rows.Count > 0 Then
                    Dim drr As DataRow = ds.Tables(0).Rows(0)
                    res.response = -1 : res.responseMsg = drr(0).ToString().Trim()
                Else
                    res.response = 1 : res.responseMsg = ""
                End If
            Else
                res.response = 1 : res.responseMsg = ""
            End If
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
            closeConnection()
        End Try
        Return res
    End Function



    Public Function Save_JR_hdr(ByVal args As PRP_JRHdr, ByVal con As SqlConnection, ByVal trans As SqlTransaction) As QueryResponse(Of PRP_JRHdr)
        Dim res As New QueryResponse(Of PRP_JRHdr)
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.Transaction = trans
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "JR_Save_Hdr"
            cmd.Parameters.Add("@Id", SqlDbType.Int)
            cmd.Parameters.Add("@Emp_Cd", SqlDbType.NVarChar, 10).Value = args.emp_cd
            cmd.Parameters.Add("@Emp_Nm", SqlDbType.NVarChar, 100).Value = args.emp_nm
            cmd.Parameters.Add("@DOJ", SqlDbType.NVarChar, 11).Value = Convert.ToDateTime(args.doj).ToString("yyyy-MM-dd")
            cmd.Parameters.Add("@Dept_Cd", SqlDbType.NVarChar, 10).Value = args.dept_cd
            cmd.Parameters.Add("@Dept_Nm", SqlDbType.NVarChar, 50).Value = args.dept_nm
            cmd.Parameters.Add("@Desig_Cd", SqlDbType.NVarChar, 10).Value = args.desig_cd
            cmd.Parameters.Add("@Desig_Nm", SqlDbType.NVarChar, 50).Value = args.desig_nm
            cmd.Parameters.Add("@Catg_Cd", SqlDbType.NVarChar, 10).Value = args.catg_cd
            cmd.Parameters.Add("@Catg_Nm", SqlDbType.NVarChar, 50).Value = args.catg_nm
            cmd.Parameters.Add("@Revision_No", SqlDbType.NVarChar, 10).Value = args.revision_no
            cmd.Parameters.Add("@Revision_Date", SqlDbType.NVarChar, 11).Value = Convert.ToDateTime(args.revision_date).ToString("yyyy-MM-dd")
            cmd.Parameters.Add("@Supersede_No", SqlDbType.NVarChar, 10).Value = args.supersede_no
            cmd.Parameters.Add("@Reason", SqlDbType.NVarChar, 5000).Value = args.reason
            cmd.Parameters.Add("@luser_Id", SqlDbType.NVarChar, 10).Value = (System.Web.HttpContext.Current.Session("usrnam"))
            cmd.Parameters.Add("@IsCurrent", SqlDbType.Int, 1).Value = args.isCurrent
            cmd.Parameters.Add("@JR_Detail", SqlDbType.Int, 1).Value = args.jr_detail
            cmd.Parameters("@Id").Direction = ParameterDirection.Output
            res.response = cmd.ExecuteNonQuery()
            res.CheckID = cmd.Parameters("@Id").Value
            res.response = 1 : res.responseMsg = ""
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
        End Try
        Return res
    End Function
    Public Function Save_JR_Dtl(ByVal args As PRP_JRHdr, ByVal con As SqlConnection, ByVal trans As SqlTransaction) As QueryResponse(Of PRP_JRHdr)
        Dim res As New QueryResponse(Of PRP_JRHdr)
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.Transaction = trans
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "JR_Save_dtl"
            cmd.Parameters.Add("@F_JR_Emp_Hdr", SqlDbType.NVarChar, 10).Value = args.Id
            cmd.Parameters.Add("@JR_Detail", SqlDbType.NVarChar, 500000).Value = args.jr_detail
            res.response = cmd.ExecuteNonQuery()
            res.response = 1 : res.responseMsg = ""
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
        End Try
        Return res
    End Function

    Public Function Save_JR_Inbox(ByVal args As PRP_JRHdr, ByVal con As SqlConnection, ByVal trans As SqlTransaction) As QueryResponse(Of PRP_JRHdr)
        Dim res As New QueryResponse(Of PRP_JRHdr)
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.Transaction = trans
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "JR_SaveInbox"
            cmd.Parameters.Add("@JR_Hdr_Id", SqlDbType.Int).Value = args.Id
            cmd.Parameters.Add("@Emp_Cd", SqlDbType.NVarChar, 10).Value = args.emp_cd
            res.response = cmd.ExecuteNonQuery()
            res.response = 1 : res.responseMsg = ""
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
        End Try
        Return res
    End Function

    Public Function Update_JR_hdr(ByVal args As PRP_JRHdr, ByVal con As SqlConnection, ByVal trans As SqlTransaction) As QueryResponse(Of PRP_JRHdr)
        Dim res As New QueryResponse(Of PRP_JRHdr)
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.Transaction = trans
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "JR_Update_Hdr"
            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = args.f_hdr_id
            cmd.Parameters.Add("@Emp_Cd", SqlDbType.NVarChar, 10).Value = args.emp_cd
            cmd.Parameters.Add("@Emp_Nm", SqlDbType.NVarChar, 100).Value = args.emp_nm
            cmd.Parameters.Add("@DOJ", SqlDbType.NVarChar, 11).Value = Convert.ToDateTime(args.doj).ToString("yyyy-MM-dd")
            cmd.Parameters.Add("@Dept_Cd", SqlDbType.NVarChar, 10).Value = args.dept_cd
            cmd.Parameters.Add("@Dept_Nm", SqlDbType.NVarChar, 50).Value = args.dept_nm
            cmd.Parameters.Add("@Desig_Cd", SqlDbType.NVarChar, 10).Value = args.desig_cd
            cmd.Parameters.Add("@Desig_Nm", SqlDbType.NVarChar, 50).Value = args.desig_nm
            cmd.Parameters.Add("@Catg_Cd", SqlDbType.NVarChar, 10).Value = args.catg_cd
            cmd.Parameters.Add("@Catg_Nm", SqlDbType.NVarChar, 50).Value = args.catg_nm
            cmd.Parameters.Add("@Revision_No", SqlDbType.NVarChar, 10).Value = args.revision_no
            cmd.Parameters.Add("@Revision_Date", SqlDbType.NVarChar, 11).Value = Convert.ToDateTime(args.revision_date).ToString("yyyy-MM-dd")
            cmd.Parameters.Add("@Supersede_No", SqlDbType.NVarChar, 10).Value = args.supersede_no
            cmd.Parameters.Add("@Reason", SqlDbType.NVarChar, 5000).Value = args.reason
            cmd.Parameters.Add("@luser_Id", SqlDbType.NVarChar, 10).Value = (System.Web.HttpContext.Current.Session("usrnam"))
            cmd.Parameters.Add("@JR_Detail", SqlDbType.NVarChar, 500000).Value = args.jr_detail
            res.response = cmd.ExecuteNonQuery()
            res.response = 1 : res.responseMsg = ""
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
        End Try
        Return res
    End Function



    Public Function Save_JR_hdr(ByVal args As PRP_JRHdr) As QueryResponse(Of PRP_JRHdr)
        Dim res As New QueryResponse(Of PRP_JRHdr)
        openConnection()
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            ' cmd.CommandText = "JR_Save_Hdr"
            cmd.CommandText = "JR_Save_Hdr"
            cmd.Parameters.Add("@Id", SqlDbType.Int)
            cmd.Parameters.Add("@Emp_Cd", SqlDbType.NVarChar, 10).Value = args.emp_cd
            cmd.Parameters.Add("@Emp_Nm", SqlDbType.NVarChar, 100).Value = args.emp_nm
            cmd.Parameters.Add("@DOJ", SqlDbType.NVarChar, 11).Value = args.doj  '   Convert.ToDateTime(args.doj).ToString("yyyy-MM-dd")
            cmd.Parameters.Add("@Dept_Cd", SqlDbType.NVarChar, 10).Value = args.dept_cd
            cmd.Parameters.Add("@Dept_Nm", SqlDbType.NVarChar, 50).Value = args.dept_nm
            cmd.Parameters.Add("@Desig_Cd", SqlDbType.NVarChar, 10).Value = args.desig_cd
            cmd.Parameters.Add("@Desig_Nm", SqlDbType.NVarChar, 50).Value = args.desig_nm
            cmd.Parameters.Add("@Catg_Cd", SqlDbType.NVarChar, 10).Value = args.catg_cd
            cmd.Parameters.Add("@Catg_Nm", SqlDbType.NVarChar, 50).Value = args.catg_nm
            cmd.Parameters.Add("@Revision_No", SqlDbType.NVarChar, 10).Value = args.revision_no
            cmd.Parameters.Add("@Revision_Date", SqlDbType.NVarChar, 11).Value = args.revision_date '  Convert.ToDateTime(args.revision_date).ToString("yyyy-MM-dd")
            cmd.Parameters.Add("@Supersede_No", SqlDbType.NVarChar, 10).Value = args.supersede_no
            cmd.Parameters.Add("@Reason", SqlDbType.NVarChar, 5000).Value = args.reason
            cmd.Parameters.Add("@luser_Id", SqlDbType.NVarChar, 10).Value = (System.Web.HttpContext.Current.Session("usrnam"))
            cmd.Parameters.Add("@IsCurrent", SqlDbType.Int, 1).Value = args.isCurrent
            cmd.Parameters.Add("@JR_Detail", SqlDbType.NVarChar, 500000).Value = args.jr_detail
            cmd.Parameters("@Id").Direction = ParameterDirection.Output
            res.response = cmd.ExecuteNonQuery()
            res.CheckID = cmd.Parameters("@Id").Value
            res.response = 1 : res.responseMsg = ""
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
            closeConnection()
        End Try
        Return res
    End Function

    Public Function Save_JR_Dtl(ByVal args As PRP_JRHdr) As QueryResponse(Of PRP_JRHdr)
        Dim res As New QueryResponse(Of PRP_JRHdr)
        openConnection()
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "JR_Save_dtl"
            cmd.Parameters.Add("@F_JR_Emp_Hdr", SqlDbType.NVarChar, 10).Value = args.Id
            cmd.Parameters.Add("@JR_Detail", SqlDbType.NVarChar, 500000).Value = args.jr_detail
            res.response = cmd.ExecuteNonQuery()
            res.response = 1 : res.responseMsg = ""
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
            closeConnection()
        End Try
        Return res
    End Function
    Public Function Update_JR_hdr_EditMode(ByVal args As PRP_JRHdr) As QueryResponse(Of PRP_JRHdr)
        Dim res As New QueryResponse(Of PRP_JRHdr)
        openConnection()
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "JR_Update_Hdr_EditMode"
            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = args.f_hdr_id
            cmd.Parameters.Add("@Emp_Cd", SqlDbType.NVarChar, 10).Value = args.emp_cd
            cmd.Parameters.Add("@Emp_Nm", SqlDbType.NVarChar, 100).Value = args.emp_nm
            cmd.Parameters.Add("@DOJ", SqlDbType.NVarChar, 11).Value = args.doj  ' Convert.ToDateTime(args.doj).ToString("yyyy-MM-dd")
            cmd.Parameters.Add("@Dept_Cd", SqlDbType.NVarChar, 10).Value = args.dept_cd
            cmd.Parameters.Add("@Dept_Nm", SqlDbType.NVarChar, 50).Value = args.dept_nm
            cmd.Parameters.Add("@Desig_Cd", SqlDbType.NVarChar, 10).Value = args.desig_cd
            cmd.Parameters.Add("@Desig_Nm", SqlDbType.NVarChar, 50).Value = args.desig_nm
            cmd.Parameters.Add("@Catg_Cd", SqlDbType.NVarChar, 10).Value = args.catg_cd
            cmd.Parameters.Add("@Catg_Nm", SqlDbType.NVarChar, 50).Value = args.catg_nm
            cmd.Parameters.Add("@Revision_No", SqlDbType.NVarChar, 10).Value = args.revision_no
            cmd.Parameters.Add("@Revision_Date", SqlDbType.NVarChar, 11).Value = args.revision_date ' Convert.ToDateTime(args.revision_date).ToString("yyyy-MM-dd")
            cmd.Parameters.Add("@Supersede_No", SqlDbType.NVarChar, 10).Value = args.supersede_no
            cmd.Parameters.Add("@Reason", SqlDbType.NVarChar, 5000).Value = args.reason
            cmd.Parameters.Add("@luser_Id", SqlDbType.NVarChar, 10).Value = (System.Web.HttpContext.Current.Session("usrnam"))
            cmd.Parameters.Add("@JR_Detail", SqlDbType.NVarChar, 500000).Value = args.jr_detail
            res.response = cmd.ExecuteNonQuery()

            res.response = 1 : res.responseMsg = "Updated Successfully"
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
            closeConnection()
        End Try
        Return res
    End Function



    Public Function Update_JR_hdr(ByVal args As PRP_JRHdr) As QueryResponse(Of PRP_JRHdr)
        Dim res As New QueryResponse(Of PRP_JRHdr)
        openConnection()
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "JR_Update_Hdr"
            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = args.f_hdr_id
            cmd.Parameters.Add("@Emp_Cd", SqlDbType.NVarChar, 10).Value = args.emp_cd
            cmd.Parameters.Add("@Emp_Nm", SqlDbType.NVarChar, 100).Value = args.emp_nm
            cmd.Parameters.Add("@DOJ", SqlDbType.NVarChar, 11).Value = args.doj  ' Convert.ToDateTime(args.doj).ToString("yyyy-MM-dd")
            cmd.Parameters.Add("@Dept_Cd", SqlDbType.NVarChar, 10).Value = args.dept_cd
            cmd.Parameters.Add("@Dept_Nm", SqlDbType.NVarChar, 50).Value = args.dept_nm
            cmd.Parameters.Add("@Desig_Cd", SqlDbType.NVarChar, 10).Value = args.desig_cd
            cmd.Parameters.Add("@Desig_Nm", SqlDbType.NVarChar, 50).Value = args.desig_nm
            cmd.Parameters.Add("@Catg_Cd", SqlDbType.NVarChar, 10).Value = args.catg_cd
            cmd.Parameters.Add("@Catg_Nm", SqlDbType.NVarChar, 50).Value = args.catg_nm
            cmd.Parameters.Add("@Revision_No", SqlDbType.NVarChar, 10).Value = args.revision_no
            cmd.Parameters.Add("@Revision_Date", SqlDbType.NVarChar, 11).Value = args.revision_date ' Convert.ToDateTime(args.revision_date).ToString("yyyy-MM-dd")
            cmd.Parameters.Add("@Supersede_No", SqlDbType.NVarChar, 10).Value = args.supersede_no
            cmd.Parameters.Add("@Reason", SqlDbType.NVarChar, 5000).Value = args.reason
            cmd.Parameters.Add("@luser_Id", SqlDbType.NVarChar, 10).Value = (System.Web.HttpContext.Current.Session("usrnam"))
            cmd.Parameters.Add("@JR_Detail", SqlDbType.NVarChar, 500000).Value = args.jr_detail
            res.response = cmd.ExecuteNonQuery()

            res.response = 1 : res.responseMsg = ""
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
            closeConnection()
        End Try
        Return res
    End Function
    Public Function JR_Approval(ByVal args As PRP_JRHdr) As QueryResponse(Of PRP_JRHdr)
        Dim res As New QueryResponse(Of PRP_JRHdr)
        Dim res_inbox As New QueryResponse(Of PRP_JRInbox)
        Dim obj_hdr As New CLS_JRHdr
        Dim obj_inbox As New CLS_JRInbox
        Try
            res = Update_JR_Inbox(args)
            If res.response = -1 Then
                res.response = -1
                Throw New Exception(res.responseMsg)
            End If
            res.response = 1
            If args.RoleId = 2 Then res.responseMsg = "JR is Approved by User Successfully." Else If args.RoleId = 3 Then res.responseMsg = "JR is Successfully Approved by User's First Authority." Else If args.RoleId = 5 Then res.responseMsg = "JR is Successfully Approved by Final Authority and forwarded to HR department." Else If args.RoleId = 6 Then res.responseMsg = "JR is Successfully Approved by HR department."
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
        End Try
        Return res
    End Function

    Public Function Update_JR_Inbox(ByVal args As PRP_JRHdr, ByVal con As SqlConnection, ByVal trans As SqlTransaction) As QueryResponse(Of PRP_JRHdr)
        Dim res As New QueryResponse(Of PRP_JRHdr)
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.Transaction = trans
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "JR_UpdateInbox"
            cmd.Parameters.Add("@JR_Hdr_Id", SqlDbType.Int).Value = args.f_hdr_id
            cmd.Parameters.Add("@finalapp_id", SqlDbType.NVarChar, 10).Value = args.finalapp_id
            cmd.Parameters.Add("@RoleID", SqlDbType.Int).Value = args.RoleId
            cmd.Parameters.Add("@Revision_Date", SqlDbType.NVarChar, 11).Value = args.revision_date
            cmd.Parameters.Add("@response", SqlDbType.Int).Direction = ParameterDirection.Output
            cmd.Parameters.Add("@responseMsg", SqlDbType.VarChar).Direction = ParameterDirection.Output
            res.response = cmd.ExecuteNonQuery()
            res.response = Convert.ToInt64(cmd.Parameters("@response").Value) : res.responseMsg = cmd.Parameters("@responseMsg").Value.ToString().Trim()
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
        End Try
        Return res
    End Function

    Public Function Update_JR_Inbox(ByVal args As PRP_JRHdr) As QueryResponse(Of PRP_JRHdr)
        Dim res As New QueryResponse(Of PRP_JRHdr)
        openConnection()
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "JR_UpdateInbox"
            cmd.Parameters.Add("@JR_Hdr_Id", SqlDbType.Int).Value = args.f_hdr_id
            cmd.Parameters.Add("@finalapp_id", SqlDbType.NVarChar, 10).Value = args.finalapp_id
            cmd.Parameters.Add("@RoleID", SqlDbType.Int).Value = args.RoleId
            cmd.Parameters.Add("@Revision_Date", SqlDbType.NVarChar, 11).Value = args.revision_date
            cmd.Parameters.Add("@response", SqlDbType.Int).Direction = ParameterDirection.Output
            cmd.Parameters.Add("@responseMsg", SqlDbType.NVarChar, 500).Direction = ParameterDirection.Output
            res.response = cmd.ExecuteNonQuery()
            res.response = Convert.ToInt64(cmd.Parameters("@response").Value) : res.responseMsg = cmd.Parameters("@responseMsg").Value.ToString().Trim()
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
            closeConnection()
        End Try
        Return res
    End Function



    'Public Function JR_Approval(ByVal args As PRP_JRHdr, ByVal con As SqlConnection, ByVal trans As SqlTransaction) As QueryResponse(Of PRP_JRHdr)
    '    Dim res As New QueryResponse(Of PRP_JRHdr)
    '    cmd = New SqlCommand()
    '    Try
    '        cmd.Connection = con
    '        cmd.Transaction = trans
    '        cmd.CommandType = CommandType.StoredProcedure
    '        cmd.CommandTimeout = 500
    '        cmd.CommandText = "JR_Approval"
    '        cmd.Parameters.Add("@Id", SqlDbType.Int).Value = args.f_hdr_id
    '        cmd.Parameters.Add("@RoleID", SqlDbType.Int).Value = args.RoleId
    '        cmd.Parameters.Add("@finalapp_id", SqlDbType.NVarChar, 10).Value = args.finalapp_id
    '        res.response = cmd.ExecuteNonQuery()
    '        res.response = 1 : res.responseMsg = ""
    '    Catch ex As Exception
    '        res.response = -1 : res.responseMsg = ex.Message.ToString()
    '    Finally
    '        cmd.Dispose()
    '    End Try
    '    Return res
    'End Function

    Public Function JR_MovetoInbox(ByVal args As PRP_JRHdr) As QueryResponse(Of PRP_JRHdr)
        Dim res As New QueryResponse(Of PRP_JRHdr)
        openConnection()
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "JR_UpdateInbox"
            cmd.Parameters.Add("@JR_Hdr_Id", SqlDbType.Int).Value = args.f_hdr_id
            cmd.Parameters.Add("@RoleID", SqlDbType.Int).Value = args.RoleId
            cmd.Parameters.Add("@move", SqlDbType.VarChar, 1).Value = args.move
            cmd.Parameters.Add("@response", SqlDbType.Int).Direction = ParameterDirection.Output
            cmd.Parameters.Add("@responseMsg", SqlDbType.NVarChar, 500).Direction = ParameterDirection.Output
            res.response = cmd.ExecuteNonQuery()
            res.response = Convert.ToInt64(cmd.Parameters("@response").Value) : res.responseMsg = cmd.Parameters("@responseMsg").Value.ToString().Trim()
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
            closeConnection()
        End Try
        Return res
    End Function




    Public Function JR_Approve(ByVal args As PRP_JRHdr) As QueryResponse(Of PRP_JRHdr)
        Dim res As New QueryResponse(Of PRP_JRHdr)
        openConnection()
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "JR_Approval"
            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = args.f_hdr_id
            cmd.Parameters.Add("@RoleID", SqlDbType.Int).Value = args.RoleId
            cmd.Parameters.Add("@finalapp_id", SqlDbType.NVarChar, 10).Value = args.finalapp_id
            res.response = cmd.ExecuteNonQuery()
            res.response = 1 : res.responseMsg = ""
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
            closeConnection()
        End Try
        Return res
    End Function
    'Public Function geHRContents(ByVal id As Integer) As QueryResponse(Of PRP_JRHdr)
    Public Function getJRContents(ByVal id As Integer) As QueryResponse(Of PRP_JRHdr)
        Dim res As New QueryResponse(Of PRP_JRHdr)
        openConnection()
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "JR_Display"
            cmd.Parameters.Add("@Par", SqlDbType.Int).Value = 18
            cmd.Parameters.Add("@id", SqlDbType.NVarChar, 11).Value = id

            dat = New SqlDataAdapter(cmd)
            Dim ds As New DataSet()
            dat.Fill(ds)
            Dim no As Int32 = 0
            If ds.Tables(0).Rows.Count > 0 Then
                Dim drr As DataRow = ds.Tables(0).Rows(0)
                res.responseObject = New PRP_JRHdr()
                With res.responseObject
                    .emp_cd = drr("Emp_cd").ToString()
                    .emp_nm = drr("emp_nm").ToString()
                    .doj = drr("DOJ").ToString()
                    If drr("Emp_app_dt").ToString() <> "" Then .Emp_app_dt = Convert.ToDateTime(drr("Emp_app_dt").ToString()).ToString("dd-MMM-yyyy") : .Emp_att_tm = Convert.ToDateTime(drr("Emp_app_dt").ToString()).ToString("HH:mm:ss") Else .Emp_app_dt = "" : .Emp_att_tm = ""
                    .hr_finalapp_id = drr("hr_finalapp_id").ToString()
                    .hr_finalapp_nm = drr("hr_finalapp_nm").ToString()
                    If drr("hr_finalapp_dt").ToString() <> "" Then .hr_finalapp_dt = Convert.ToDateTime(drr("hr_finalapp_dt").ToString()).ToString("dd-MMM-yyyy") : .hr_finalapp_tm = Convert.ToDateTime(drr("hr_finalapp_dt").ToString()).ToString("HH:mm:ss") Else .hr_finalapp_dt = "" : .hr_finalapp_tm = ""
                    .finalapp_id = drr("finalapp_id").ToString()
                    .finalapp_nm = drr("finalapp_nm").ToString()
                    If drr("finalapp_dt").ToString() <> "" Then .finalapp_dt = Convert.ToDateTime(drr("finalapp_dt").ToString()).ToString("dd-MMM-yyyy") : .finalapp_tm = Convert.ToDateTime(drr("finalapp_dt").ToString()).ToString("HH:mm:ss") Else .finalapp_dt = "" : .finalapp_tm = ""
                    .tra = drr("Tra").ToString()
                    .sta = drr("Sta").ToString()
                    .prepapp_id = drr("prepapp_id").ToString()
                    .prepapp_nm = drr("prepapp_nm").ToString()
                    If drr("prepapp_dt").ToString() <> "" Then .prepapp_dt = Convert.ToDateTime(drr("prepapp_dt").ToString()).ToString("dd-MMM-yyyy") : .prepapp_tm = Convert.ToDateTime(drr("prepapp_dt").ToString()).ToString("HH:mm:ss") Else .prepapp_dt = "" : .prepapp_tm = ""

                    .firstapp_id = drr("firstapp_id").ToString()
                    .firstapp_nm = drr("firstapp_nm").ToString()
                    If drr("firstapp_dt").ToString() <> "" Then .firstapp_dt = Convert.ToDateTime(drr("firstapp_dt").ToString()).ToString("dd-MMM-yyyy") : .firstapp_tm = Convert.ToDateTime(drr("firstapp_dt").ToString()).ToString("HH:mm:ss") Else .firstapp_dt = "" : .firstapp_tm = ""
                    .EntryExists = drr("EntryExists").ToString()
                    .revision_no = drr("revision_no").ToString()
                    .revision_date = drr("revision_date").ToString()
                    .supersede_no = drr("supersede_no").ToString()
                    .reason = drr("reason").ToString()
                    .jr_detail = drr("JR_Detail").ToString()
                    .f_hdr_id = drr("Id").ToString()


                    '.Emp_app_dt = IIf(String.IsNullOrEmpty(drr("Emp_app_dt").ToString()), "", Convert.ToDateTime(drr("Emp_app_dt").ToString()).ToString("dd-MMM-yyyy"))
                    ' .hr_finalapp_dt = drr("hr_finalapp_dt").ToString()
                    '.hr_finalapp_tm = ""
                    'If .hr_finalapp_dt <> "" Then
                    '    .hr_finalapp_dt = Convert.ToDateTime(drr("hr_finalapp_dt").ToString()).ToString("dd-MMM-yyyy")
                    '    .hr_finalapp_tm = Convert.ToDateTime(drr("hr_finalapp_dt").ToString()).ToString("HH:mm:ss")
                    'End If

                    '.finalapp_id = drr("finalapp_id").ToString()
                    '.finalapp_nm = drr("finalapp_nm").ToString()
                    '.finalapp_dt = drr("finalapp_dt").ToString()
                    '.finalapp_tm = ""
                    'If .finalapp_dt <> "" Then
                    '    .finalapp_dt = Convert.ToDateTime(drr("finalapp_dt").ToString()).ToString("dd-MMM-yyyy")
                    '    .finalapp_tm = Convert.ToDateTime(drr("finalapp_dt").ToString()).ToString("HH:mm:ss")
                    'End If
                    '.tra = drr("Tra").ToString()
                    '.sta = drr("Sta").ToString()

                    '.prepapp_id = drr("prepapp_id").ToString()
                    '.prepapp_nm = drr("prepapp_nm").ToString()
                    '.prepapp_dt = drr("prepapp_dt").ToString()
                    '.prepapp_tm = ""
                    'If .prepapp_dt <> "" Then
                    '    .prepapp_dt = Convert.ToDateTime(drr("prepapp_dt").ToString()).ToString("dd-MMM-yyyy")
                    '    .prepapp_tm = Convert.ToDateTime(drr("prepapp_dt").ToString()).ToString("HH:mm:ss")
                    'End If


                End With
                res.response = 1 : res.responseMsg = ""
            Else
                res.response = -1 : res.responseMsg = "JR Contents not Found"
            End If
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
            closeConnection()
        End Try
        Return res
    End Function




    Public Function Delete(ByVal args As PRP_JRHdr) As QueryResponse(Of PRP_JRHdr) Implements IJRModule(Of PRP_JRHdr).Delete
        Throw New NotImplementedException()
    End Function

    Public Function Insert(ByVal args As PRP_JRHdr) As QueryResponse(Of PRP_JRHdr) Implements IJRModule(Of PRP_JRHdr).Insert
        Throw New NotImplementedException()
    End Function

    Public Function Update(ByVal args As PRP_JRHdr) As QueryResponse(Of PRP_JRHdr) Implements IJRModule(Of PRP_JRHdr).Update
        Throw New NotImplementedException()
    End Function

    Public Function View() As QueryResponse(Of PRP_JRHdr) Implements IJRModule(Of PRP_JRHdr).View
        Throw New NotImplementedException()
    End Function

    Public Function View(ByVal args As PRP_JRHdr) As QueryResponse(Of PRP_JRHdr) Implements IJRModule(Of PRP_JRHdr).View
        Throw New NotImplementedException()
    End Function
End Class

Public Class CLS_JRDtl
    Inherits db_Connection
    Implements IJRModule(Of PRP_JRDtl)

    Public Sub New()
        MyBase.new("cnhrm1") 'Maintenance Development Database
    End Sub

    Public Function Delete(ByVal args As PRP_JRDtl) As QueryResponse(Of PRP_JRDtl) Implements IJRModule(Of PRP_JRDtl).Delete
        Throw New NotImplementedException()
    End Function

    Public Function Insert(ByVal args As PRP_JRDtl) As QueryResponse(Of PRP_JRDtl) Implements IJRModule(Of PRP_JRDtl).Insert
        Throw New NotImplementedException()
    End Function

    Public Function Update(ByVal args As PRP_JRDtl) As QueryResponse(Of PRP_JRDtl) Implements IJRModule(Of PRP_JRDtl).Update
        Throw New NotImplementedException()
    End Function

    Public Function Save_JR_Dtl(ByVal args As PRP_JRDtl) As QueryResponse(Of PRP_JRDtl)
        Dim res As New QueryResponse(Of PRP_JRDtl)
        openConnection()
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "JR_Save_dtl"
            cmd.Parameters.Add("@F_JR_Emp_Hdr", SqlDbType.NVarChar, 10).Value = args.F_JR_Emp_Hdr
            cmd.Parameters.Add("@JR_Detail", SqlDbType.NVarChar, 10000).Value = args.JR_Detail
            cmd.Parameters.Add("@Sub_Point", SqlDbType.NVarChar, 10).Value = args.Sub_Point
            cmd.Parameters.Add("@Sub_PointOfPoint", SqlDbType.NVarChar, 10).Value = args.Sub_PointOfPoint
            cmd.Parameters.Add("@PointNo", SqlDbType.NVarChar, 10).Value = args.PointNo
            cmd.Parameters.Add("@SubPointNo", SqlDbType.NVarChar, 10).Value = args.SubPointNo
            res.response = cmd.ExecuteNonQuery()
            res.responseMsg = ""
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
            closeConnection()
        End Try
        Return res
    End Function


    Public Function View() As QueryResponse(Of PRP_JRDtl) Implements IJRModule(Of PRP_JRDtl).View
        Throw New NotImplementedException()
    End Function

    Public Function View(ByVal args As PRP_JRDtl) As QueryResponse(Of PRP_JRDtl) Implements IJRModule(Of PRP_JRDtl).View
        Throw New NotImplementedException()
    End Function
End Class

Public Class cls_EmployeeDetail
    Inherits db_Connection
    Implements IJRModule(Of PRP_EmployeeDetail)

    Public Sub New()
        MyBase.new("cnhrm1") 'Maintenance Development Database
    End Sub

    Public Function View() As QueryResponse(Of PRP_EmployeeDetail) Implements IJRModule(Of PRP_EmployeeDetail).View
        Throw New NotImplementedException()
    End Function

    Public Function View(ByVal varempcd As String) As QueryResponse(Of PRP_EmployeeDetail)
        Dim res As New QueryResponse(Of PRP_EmployeeDetail)
        openConnection()
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "JR_Display"
            cmd.Parameters.Add("@Par", SqlDbType.Int).Value = 3
            cmd.Parameters.Add("@emp_cd", SqlDbType.NVarChar, 11).Value = varempcd

            dat = New SqlDataAdapter(cmd)
            Dim ds As New DataSet()
            dat.Fill(ds)
            Dim no As Int32 = 0
            If ds.Tables(0).Rows.Count > 0 Then
                Dim drr As DataRow = ds.Tables(0).Rows(0)
                res.responseObject = New PRP_EmployeeDetail()
                res.responseObject.emp_cd = varempcd
                res.responseObject.emp_nm = drr("emp_nm").ToString()
                res.responseObject.dept_nm = drr("dept_nm").ToString()
                res.responseObject.desig_nm = drr("desig_nm").ToString().Trim() & " / " & drr("catg_nm").ToString()
                res.responseObject.dept_cd = drr("dept_cd").ToString()
                res.responseObject.desig_cd = drr("desig_cd").ToString()
                res.responseObject.catg_cd = drr("catg_cd").ToString()
                res.responseObject.catg_nm = drr("catg_nm").ToString()
                res.responseObject.dt_join = drr("dt_join").ToString()

                res.response = 1 : res.responseMsg = ""
            Else
                res.response = -1 : res.responseMsg = "Employee not Found"
            End If
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
            closeConnection()
        End Try
        Return res
    End Function

    Public Function View_JRHDR(ByVal varempcd As String, ByVal vardeptcd As String, ByVal vardesigcd As String) As QueryResponse(Of PRP_JRHdr)
        Dim res As New QueryResponse(Of PRP_JRHdr)
        openConnection()
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "JR_Display"
            cmd.Parameters.Add("@Par", SqlDbType.Int).Value = 4
            cmd.Parameters.Add("@emp_cd", SqlDbType.NVarChar, 11).Value = varempcd
            cmd.Parameters.Add("@dept_cd", SqlDbType.NVarChar, 11).Value = vardeptcd
            cmd.Parameters.Add("@desig_Cd", SqlDbType.NVarChar, 11).Value = vardesigcd
            'If jrID > 0 Then
            '    cmd.Parameters.Add("@id", SqlDbType.Int).Value = jrID
            'End If

            dat = New SqlDataAdapter(cmd)
            Dim ds As New DataSet()
            dat.Fill(ds)
            Dim no As Int32 = 0
            If ds.Tables(0).Rows.Count > 0 Then
                Dim drr As DataRow = ds.Tables(0).Rows(0)
                res.responseObject = New PRP_JRHdr()
                res.responseObject.emp_cd = varempcd
                res.responseObject.f_hdr_id = drr("f_hdr_id")
                res.responseObject.revision_no = drr("revision_no").ToString()
                res.responseObject.revision_date = drr("revision_date").ToString()
                res.responseObject.supersede_no = drr("supersede_no").ToString()
                res.responseObject.reason = drr("reason").ToString()
                res.responseObject.jr_detail = drr("JR_Detail").ToString()
                res.responseObject.EntryExists = drr("EntryExists").ToString() '' 1 For Data Saved and 0 for Not Data Saved

                res.response = 1 : res.responseMsg = ""
            Else
                res.response = -1 : res.responseMsg = "JR not Found"
            End If
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
            closeConnection()
        End Try
        Return res
    End Function
    Public Function View_JRReport(ByVal empcd As String) As QueryResponse(Of PRP_JRHdr)
        Dim res As New QueryResponse(Of PRP_JRHdr)
        openConnection()
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "JR_Display"
            cmd.Parameters.Add("@Par", SqlDbType.Int).Value = 11
            cmd.Parameters.Add("@emp_cd", SqlDbType.NVarChar, 11).Value = empcd
            'cmd.Parameters.Add("@dept_cd", SqlDbType.NVarChar, 11).Value = vardeptcd
            'cmd.Parameters.Add("@dept_cd", SqlDbType.NVarChar, 11).Value = vardeptcd


            dat = New SqlDataAdapter(cmd)
            Dim ds As New DataSet()
            dat.Fill(ds)
            Dim no As Int32 = 0
            If ds.Tables(0).Rows.Count > 0 Then
                res.responseObjectList = New List(Of PRP_JRHdr)
                For Each drr As DataRow In ds.Tables(0).Rows
                    res.responseObjectList.Add(New PRP_JRHdr() With {
                    .emp_nm = drr("employeename").ToString(),
                    .emp_cd = drr("employeecode").ToString(),
                    .revision_no = drr("revisionno").ToString(),
                    .revision_date = Convert.ToDateTime(drr("effectivedate").ToString())
                })
                Next
                res.response = 1 : res.responseMsg = ""
            Else
                res.response = -1 : res.responseMsg = ""
            End If
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
            closeConnection()
        End Try
        Return res
    End Function

    Public Function checkDepartmentCode(ByVal vardeptcd As String) As QueryResponse(Of PRP_JRHdr)
        Dim res As New QueryResponse(Of PRP_JRHdr)
        openConnection()
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "JR_Display"
            cmd.Parameters.Add("@Par", SqlDbType.Int).Value = 29
            cmd.Parameters.Add("@dept_cd", SqlDbType.NVarChar, 11).Value = vardeptcd
            dat = New SqlDataAdapter(cmd)
            Dim ds As New DataSet()
            dat.Fill(ds)
            Dim no As Int32 = 0
            If ds.Tables(0).Rows.Count > 0 Then
                Dim row As DataRow = ds.Tables(0).Rows(0)
                res.responseObject = New PRP_JRHdr()
                res.responseObject.dept_cd = row("dept_cd").ToString()
                res.response = 1 : res.responseMsg = ""
            Else
                res.response = -1 : res.responseMsg = "Department Code not Found"
            End If
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
            closeConnection()
        End Try
        Return res
    End Function

    Public Function View_JRDetailforEditing(ByVal vardeptcd As String) As QueryResponse(Of PRP_JRHdr)
        Dim res As New QueryResponse(Of PRP_JRHdr)
        openConnection()
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "JR_Display"
            cmd.Parameters.Add("@Par", SqlDbType.Int).Value = 28
            cmd.Parameters.Add("@dept_cd", SqlDbType.NVarChar, 11).Value = vardeptcd
            dat = New SqlDataAdapter(cmd)
            Dim ds As New DataSet()
            dat.Fill(ds)
            Dim no As Int32 = 0
            If ds.Tables(0).Rows.Count > 0 Then
                res.responseObjectList = New List(Of PRP_JRHdr)
                For Each drr As DataRow In ds.Tables(0).Rows
                    res.responseObjectList.Add(New PRP_JRHdr() With {
                    .Id = drr("id").ToString(),
                    .emp_cd = drr("emp_cd").ToString(),
                    .emp_nm = drr("emp_nm").ToString(),
                    .dept_cd = drr("dept_cd").ToString(),
                    .dept_nm = drr("dept_nm").ToString(),
                    .desig_nm = drr("desig_nm").ToString(),
                    .revision_no = drr("Revision_No").ToString(),
                    .userpass = drr("userpass").ToString()
                })
                Next
                res.response = 1 : res.responseMsg = ""
            Else
                res.response = -1 : res.responseMsg = ""
            End If
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
            closeConnection()
        End Try
        Return res
    End Function

    Public Function View_JRDetailforEditingEmployeewise(ByVal varempcd As String) As QueryResponse(Of PRP_JRHdr)
        Dim res As New QueryResponse(Of PRP_JRHdr)
        openConnection()
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "JR_Display"
            cmd.Parameters.Add("@Par", SqlDbType.Int).Value = 37
            cmd.Parameters.Add("@emp_cd", SqlDbType.NVarChar, 11).Value = varempcd
            dat = New SqlDataAdapter(cmd)
            Dim ds As New DataSet()
            dat.Fill(ds)
            Dim no As Int32 = 0
            If ds.Tables(0).Rows.Count > 0 Then
                res.responseObjectList = New List(Of PRP_JRHdr)
                For Each drr As DataRow In ds.Tables(0).Rows
                    res.responseObjectList.Add(New PRP_JRHdr() With {
                    .Id = drr("id").ToString(),
                    .emp_cd = drr("emp_cd").ToString(),
                    .emp_nm = drr("emp_nm").ToString(),
                    .dept_cd = drr("dept_cd").ToString(),
                    .dept_nm = drr("dept_nm").ToString(),
                    .desig_nm = drr("desig_nm").ToString(),
                    .revision_no = drr("Revision_No").ToString(),
                    .userpass = drr("userpass").ToString()
                })
                Next
                res.response = 1 : res.responseMsg = ""
            Else
                res.response = -1 : res.responseMsg = ""
            End If
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
            closeConnection()
        End Try
        Return res
    End Function




    Public Function View_JRDetailDepartmentwise(ByVal vardeptcd As String) As QueryResponse(Of PRP_JRHdr)
        Dim res As New QueryResponse(Of PRP_JRHdr)
        openConnection()
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "JR_Display"
            cmd.Parameters.Add("@Par", SqlDbType.Int).Value = 31
            cmd.Parameters.Add("@dept_cd", SqlDbType.NVarChar, 11).Value = vardeptcd
            dat = New SqlDataAdapter(cmd)
            Dim ds As New DataSet()
            dat.Fill(ds)
            Dim no As Int32 = 0
            If ds.Tables(0).Rows.Count > 0 Then
                res.responseObjectList = New List(Of PRP_JRHdr)
                For Each drr As DataRow In ds.Tables(0).Rows
                    res.responseObjectList.Add(New PRP_JRHdr() With {
                    .Id = drr("id").ToString(),
                    .emp_cd = drr("emp_cd").ToString(),
                    .emp_nm = drr("emp_nm").ToString(),
                    .dept_cd = drr("dept_cd").ToString(),
                    .dept_nm = drr("dept_nm").ToString(),
                    .desig_nm = drr("desig_nm").ToString(),
                    .revision_no = drr("Revision_No").ToString(),
                    .userpass = drr("userpass").ToString()
                })
                Next
                res.response = 1 : res.responseMsg = ""
            Else
                res.response = -1 : res.responseMsg = ""
            End If
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
            closeConnection()
        End Try
        Return res
    End Function

    Public Function View_JRDetailEmployeewise(ByVal varempcd As String) As QueryResponse(Of PRP_JRHdr)
        Dim res As New QueryResponse(Of PRP_JRHdr)
        openConnection()
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "JR_Display"
            cmd.Parameters.Add("@Par", SqlDbType.Int).Value = 36
            cmd.Parameters.Add("@emp_cd", SqlDbType.NVarChar, 11).Value = varempcd
            dat = New SqlDataAdapter(cmd)
            Dim ds As New DataSet()
            dat.Fill(ds)
            Dim no As Int32 = 0
            If ds.Tables(0).Rows.Count > 0 Then
                res.responseObjectList = New List(Of PRP_JRHdr)
                For Each drr As DataRow In ds.Tables(0).Rows
                    res.responseObjectList.Add(New PRP_JRHdr() With {
                    .Id = drr("id").ToString(),
                    .emp_cd = drr("emp_cd").ToString(),
                    .emp_nm = drr("emp_nm").ToString(),
                    .dept_cd = drr("dept_cd").ToString(),
                    .dept_nm = drr("dept_nm").ToString(),
                    .desig_nm = drr("desig_nm").ToString(),
                    .revision_no = drr("Revision_No").ToString(),
                    .userpass = drr("userpass").ToString()
                })
                Next
                res.response = 1 : res.responseMsg = ""
            Else
                res.response = -1 : res.responseMsg = ""
            End If
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
            closeConnection()
        End Try
        Return res
    End Function




    Public Function View_JRReport(ByVal vardeptcd As String, ByVal vardatfro As String, ByVal vardatTo As String) As QueryResponse(Of PRP_JRHdr)
        Dim res As New QueryResponse(Of PRP_JRHdr)
        openConnection()
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "JR_Display"
            cmd.Parameters.Add("@Par", SqlDbType.Int).Value = 5
            cmd.Parameters.Add("@dept_cd", SqlDbType.NVarChar, 11).Value = vardeptcd
            dat = New SqlDataAdapter(cmd)
            Dim ds As New DataSet()
            dat.Fill(ds)
            Dim no As Int32 = 0
            If ds.Tables(0).Rows.Count > 0 Then
                res.responseObjectList = New List(Of PRP_JRHdr)
                For Each drr As DataRow In ds.Tables(0).Rows
                    res.responseObjectList.Add(New PRP_JRHdr() With {
                    .dept_cd = vardeptcd,
                    .emp_nm = drr("employeename").ToString(),
                    .emp_cd = drr("employeecode").ToString(),
                    .revision_no = drr("revisionno").ToString(),
                    .revision_date = Convert.ToDateTime(drr("effectivedate").ToString()),
                    .Id = drr("id").ToString()
                })
                Next
                res.response = 1 : res.responseMsg = ""
            Else
                res.response = -1 : res.responseMsg = ""
            End If
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
            closeConnection()
        End Try
        Return res
    End Function

    Public Function View_PendingJR(ByVal varempcd As String) As QueryResponse(Of PRP_JRHdr)
        Dim res As New QueryResponse(Of PRP_JRHdr)
        openConnection()
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "JR_Display"
            cmd.Parameters.Add("@Par", SqlDbType.Int).Value = 7
            cmd.Parameters.Add("@emp_cd", SqlDbType.NVarChar, 11).Value = varempcd


            '05-02-2022
            dat = New SqlDataAdapter(cmd)
            Dim ds As New DataSet()
            dat.Fill(ds)
            Dim no As Int32 = 0

            If ds.Tables(0).Rows.Count > 0 Then
                res.responseObjectList = New List(Of PRP_JRHdr)
                For Each drr As DataRow In ds.Tables(0).Rows
                    'SrNo	emp_cd	emp_nm	dept_cd	dept_nm	desig_cd	desig_nm
                    res.responseObjectList.Add(New PRP_JRHdr() With {
                    .revision_no = drr("SrNo").ToString(),
                    .emp_cd = drr("emp_cd").ToString(),
                    .emp_nm = drr("emp_nm").ToString(),
                    .dept_cd = drr("dept_cd").ToString(),
                    .dept_nm = drr("dept_nm").ToString(),
                    .desig_cd = drr("desig_cd").ToString(),
                    .desig_nm = drr("desig_nm").ToString()
                })
                Next
                res.response = 1 : res.responseMsg = ""
            Else
                res.response = -1 : res.responseMsg = ""
            End If
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
            closeConnection()
        End Try
        Return res
    End Function

    Public Function View_JRLists(ByVal varempcd As String, ByVal tag As Int64) As QueryResponse(Of PRP_JRHdr)
        Dim res As New QueryResponse(Of PRP_JRHdr)
        openConnection()
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "JR_Display"
            If tag = 1 Then
                cmd.Parameters.Add("@Par", SqlDbType.Int).Value = 25
            ElseIf tag = 2 Then
                cmd.Parameters.Add("@Par", SqlDbType.Int).Value = 7
            End If
            cmd.Parameters.Add("@emp_cd", SqlDbType.NVarChar, 11).Value = varempcd


            '05-02-2022
            dat = New SqlDataAdapter(cmd)
            Dim ds As New DataSet()
            dat.Fill(ds)
            Dim no As Int32 = 0

            If ds.Tables(0).Rows.Count > 0 Then
                res.responseObjectList = New List(Of PRP_JRHdr)
                For Each drr As DataRow In ds.Tables(0).Rows
                    'SrNo	emp_cd	emp_nm	dept_cd	dept_nm	desig_cd	desig_nm
                    res.responseObjectList.Add(New PRP_JRHdr() With {
                    .revision_no = drr("SrNo").ToString(),
                    .emp_cd = drr("emp_cd").ToString(),
                    .emp_nm = drr("emp_nm").ToString(),
                    .dept_cd = drr("dept_cd").ToString(),
                    .dept_nm = drr("dept_nm").ToString(),
                    .desig_cd = drr("desig_cd").ToString(),
                    .desig_nm = drr("desig_nm").ToString()
                })
                Next
                res.response = 1 : res.responseMsg = ""
            Else
                res.response = -1 : res.responseMsg = ""
            End If
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
            closeConnection()
        End Try
        Return res
    End Function

    Public Function View_JRLists1(ByVal varempcd As String, ByVal tag As Int64) As QueryResponse(Of PRP_JRHdr)
        Dim res As New QueryResponse(Of PRP_JRHdr)
        openConnection()
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "JR_Display"
            cmd.Parameters.Add("@Par", SqlDbType.Int).Value = 34
            cmd.Parameters.Add("@tag", SqlDbType.Int).Value = tag

            '05-02-2022
            dat = New SqlDataAdapter(cmd)
            Dim ds As New DataSet()
            dat.Fill(ds)
            Dim no As Int32 = 0

            If ds.Tables(0).Rows.Count > 0 Then
                res.responseObjectList = New List(Of PRP_JRHdr)
                For Each drr As DataRow In ds.Tables(0).Rows
                    'SrNo	emp_cd	emp_nm	dept_cd	dept_nm	desig_cd	desig_nm
                    res.responseObjectList.Add(New PRP_JRHdr() With {
                    .revision_no = drr("SrNo").ToString(),
                    .emp_cd = drr("emp_cd").ToString(),
                    .emp_nm = drr("emp_nm").ToString(),
                    .dept_cd = drr("dept_cd").ToString(),
                    .dept_nm = drr("dept_nm").ToString(),
                    .desig_cd = drr("desig_cd").ToString(),
                    .desig_nm = drr("desig_nm").ToString()
                })
                Next
                res.response = 1 : res.responseMsg = ""
            Else
                res.response = -1 : res.responseMsg = ""
            End If
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
            closeConnection()
        End Try
        Return res
    End Function



    Public Function View_JRUsersList(ByVal s As PRP_SearchwithPagination) As QueryResponse(Of PRP_JRHdr)
        Dim res As New QueryResponse(Of PRP_JRHdr)
        openConnection()
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "JR_GetEmployeeListPageWise_Sort"
            cmd.Parameters.Add("@emp_cd", SqlDbType.NVarChar, 11).Value = s.emp_cd
            cmd.Parameters.Add("@PageIndex", SqlDbType.NVarChar, 11).Value = s.PageIndex
            cmd.Parameters.Add("@PageSize", SqlDbType.NVarChar, 11).Value = s.pageSize
            cmd.Parameters.Add("@SortDirection", SqlDbType.NVarChar, 11).Value = s.sortDirection
            cmd.Parameters.Add("@SortColumn", SqlDbType.NVarChar, 11).Value = s.sortColumn
            cmd.Parameters.Add("@RecordCount", SqlDbType.Int, 4).Direction = ParameterDirection.Output
            '05-02-2022
            dat = New SqlDataAdapter(cmd)
            Dim ds As New DataSet()
            dat.Fill(ds)
            Dim no As Int32 = 0

            If ds.Tables(0).Rows.Count > 0 Then
                res.responseObjectList = New List(Of PRP_JRHdr)
                For Each drr As DataRow In ds.Tables(0).Rows
                    res.responseObjectList.Add(New PRP_JRHdr() With {
                    .revision_no = drr("SrNo").ToString(),
                    .emp_cd = drr("emp_cd").ToString(),
                    .emp_nm = drr("emp_nm").ToString(),
                    .dept_cd = drr("dept_cd").ToString(),
                    .dept_nm = drr("dept_nm").ToString(),
                    .desig_cd = drr("desig_cd").ToString(),
                    .desig_nm = drr("desig_nm").ToString()
                })
                Next
                res.responseObject.TotalRecords = Convert.ToInt64(cmd.Parameters("@RecordCount").Value)
                res.response = 1 : res.responseMsg = ""
            Else
                res.response = -1 : res.responseMsg = ""
            End If
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
            closeConnection()
        End Try
        Return res
    End Function





    Public Function View_JRRevision(ByVal varempcd As String) As QueryResponse(Of PRP_JRHdr)
        Dim res As New QueryResponse(Of PRP_JRHdr)
        openConnection()
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "JR_Display"
            cmd.Parameters.Add("@Par", SqlDbType.Int).Value = 9
            cmd.Parameters.Add("@emp_cd", SqlDbType.NVarChar, 11).Value = varempcd


            '05-02-2022
            dat = New SqlDataAdapter(cmd)
            Dim ds As New DataSet()
            dat.Fill(ds)
            Dim no As Int32 = 0

            If ds.Tables(0).Rows.Count > 0 Then
                res.responseObjectList = New List(Of PRP_JRHdr)
                For Each drr As DataRow In ds.Tables(0).Rows
                    'SrNo	emp_cd	emp_nm	dept_cd	dept_nm	desig_cd	desig_nm
                    res.responseObjectList.Add(New PRP_JRHdr() With {
                    .catg_cd = drr("SrNo").ToString(),
                    .revision_no = drr("Revision_No").ToString(),
                    .revision_date = drr("Revision_Date").ToString(),
                    .supersede_no = drr("Supersede_No").ToString(),
                    .reason = drr("Reason").ToString()
                })
                Next
                res.response = 1 : res.responseMsg = ""
            Else
                res.response = -1 : res.responseMsg = "JR Revision History not Found for this Employee"
            End If
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
            closeConnection()
        End Try
        Return res
    End Function

    Public Function Print_JR(ByVal varempcd As String, ByVal jrID As Integer) As QueryResponse(Of PRP_JRHdr)
        Dim res As New QueryResponse(Of PRP_JRHdr)
        openConnection()
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "JR_Display"
            cmd.Parameters.Add("@Par", SqlDbType.Int).Value = 6
            cmd.Parameters.Add("@emp_cd", SqlDbType.NVarChar, 10).Value = varempcd
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = jrID

            dat = New SqlDataAdapter(cmd)
            Dim ds As New DataSet()
            dat.Fill(ds)
            '.revision_date = Convert.ToDateTime(drr("Revision_Date").ToString()),
            Dim no As Int32 = 0
            If ds.Tables(0).Rows.Count > 0 Then
                Dim drr As DataRow = ds.Tables(0).Rows(0)
                res.responseObject = New PRP_JRHdr()
                With res.responseObject
                    .emp_cd = varempcd
                    .emp_nm = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(drr("Emp_Nm").ToString())
                    .doj = Convert.ToDateTime(drr("DOJ").ToString())   '.ToString("dd/MM/yyyy")
                    .dept_nm = drr("Dept_Nm").ToString()
                    .desig_nm = drr("Desig_Nm").ToString()
                    .catg_nm = drr("Catg_Nm").ToString()
                    .revision_no = drr("Revision_No").ToString()
                    .revision_date = (drr("Revision_Date").ToString())
                    .supersede_no = drr("Supersede_No").ToString()
                    .reason = drr("Reason").ToString()
                    .jr_detail = drr("JR_Detail").ToString()
                End With

                'res.responseObjectList = New List(Of PRP_JRHdr)
                'For Each drr As DataRow In ds.Tables(0).Rows
                '    res.responseObjectList.Add(New PRP_JRHdr() With {
                '    .emp_cd = varempcd,
                '    .emp_nm = drr("Emp_Nm").ToString(),
                '    .doj = Convert.ToDateTime(drr("DOJ").ToString()),
                '    .dept_nm = drr("Dept_Nm").ToString(),
                '    .desig_nm = drr("Desig_Nm").ToString(),
                '    .catg_nm = drr("Catg_Nm").ToString(),
                '    .revision_no = drr("Revision_No").ToString(),
                '    .revision_date = (drr("Revision_Date").ToString()),
                '    .supersede_no = drr("Supersede_No").ToString(),
                '    .reason = drr("Reason").ToString(),
                '    .jr_detail = drr("JR_Detail").ToString()
                '})
                'Next
                res.response = 1 : res.responseMsg = ""
            Else
                res.response = -1 : res.responseMsg = ""
            End If
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
            closeConnection()
        End Try
        Return res
    End Function

    ''19-07-2022----->
    Public Function Print_JRRevision(ByVal varempcd As String) As QueryResponse(Of PRP_JRHdr)
        Dim res As New QueryResponse(Of PRP_JRHdr)
        openConnection()
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "JR_Display"
            cmd.Parameters.Add("@Par", SqlDbType.Int).Value = 9
            cmd.Parameters.Add("@emp_cd", SqlDbType.NVarChar, 10).Value = varempcd

            dat = New SqlDataAdapter(cmd)
            Dim ds As New DataSet()
            dat.Fill(ds)

            Dim no As Int32 = 0
            If ds.Tables(0).Rows.Count > 0 Then
                res.responseObjectList = New List(Of PRP_JRHdr)
                For Each drr As DataRow In ds.Tables(0).Rows
                    res.responseObjectList.Add(New PRP_JRHdr() With {
                    .revision_no = drr("Revision_No").ToString(),
                    .revision_date = drr("Revision_Date").ToString(),
                    .supersede_no = drr("Supersede_No").ToString(),
                    .reason = drr("Reason").ToString()
                })
                Next
                res.response = 1 : res.responseMsg = ""
            Else
                res.response = -1 : res.responseMsg = ""
            End If
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
            closeConnection()
        End Try
        Return res
    End Function
    ''19-07-2022-----<



    ''Sushil 21-09-2021
    'Public Function Display_EmployeeDetail(ByVal varempcd As String) As QueryResponse(Of PRP_EmployeeDetail)
    '    Dim res As New QueryResponse(Of PRP_EmployeeDetail)
    '    openConnection()
    '    cmd = New SqlCommand()
    '    Try
    '        cmd.Connection = con
    '        cmd.CommandType = CommandType.StoredProcedure
    '        cmd.CommandTimeout = 500
    '        cmd.CommandText = "JR_Display"
    '        cmd.Parameters.Add("@Par", SqlDbType.Int).Value = 3
    '        cmd.Parameters.Add("@emp_cd", SqlDbType.NVarChar, 11).Value = varempcd

    '        dat = New SqlDataAdapter(cmd)
    '        Dim ds As New DataSet()
    '        dat.Fill(ds)
    '        Dim no As Int32 = 0
    '        If ds.Tables(0).Rows.Count > 0 Then
    '            Dim drr As DataRow = ds.Tables(0).Rows(0)
    '            res.responseObject = New PRP_EmployeeDetail()
    '            res.responseObject.emp_cd = varempcd
    '            res.responseObject.emp_nm = drr("emp_nm").ToString()
    '            res.responseObject.dept_nm = drr("dept_nm").ToString()
    '            res.responseObject.desig_nm = drr("desig_nm").ToString()
    '            res.responseObject.dept_cd = drr("dept_cd").ToString()
    '            res.responseObject.catg_cd = drr("catg_cd").ToString()
    '            res.responseObject.catg_nm = drr("catg_nm").ToString()
    '            res.responseObject.dt_join = drr("dt_join").ToString()

    '            res.response = 1 : res.responseMsg = ""
    '        Else
    '            res.response = -1 : res.responseMsg = ""
    '        End If
    '    Catch ex As Exception
    '        res.response = -1 : res.responseMsg = ex.Message.ToString()
    '    Finally
    '        cmd.Dispose()
    '        closeConnection()
    '    End Try
    '    Return res
    'End Function
    ''Sushil 21-09-2021

    Public Function Delete(ByVal args As PRP_EmployeeDetail) As QueryResponse(Of PRP_EmployeeDetail) Implements IJRModule(Of PRP_EmployeeDetail).Delete
        Throw New NotImplementedException()
    End Function



    Public Function Insert(ByVal args As PRP_EmployeeDetail) As QueryResponse(Of PRP_EmployeeDetail) Implements IJRModule(Of PRP_EmployeeDetail).Insert
        Throw New NotImplementedException()
    End Function


    Public Function Update(ByVal args As PRP_EmployeeDetail) As QueryResponse(Of PRP_EmployeeDetail) Implements IJRModule(Of PRP_EmployeeDetail).Update
        Throw New NotImplementedException()
    End Function

    Public Function View1(ByVal args As PRP_EmployeeDetail) As QueryResponse(Of PRP_EmployeeDetail) Implements IJRModule(Of PRP_EmployeeDetail).View
        Throw New NotImplementedException()
    End Function
End Class

Public Class commonfunctions
    Inherits db_Connection
    Public Sub New()
        MyBase.new("cnl") 'Maintenance Development Database
    End Sub
    Public Function Set_Welcome_Message(ByVal usernm As String) As QueryResponse(Of PRP_users)
        Dim objusr As New CLS_User_Master()
        Dim res As New QueryResponse(Of PRP_users)
        Dim varusrnam As String = ""
        res = objusr.Display_User_Name(usernm.ToString().Trim())
        Return res
        'varusrnam = res.responseObject.empnm.ToString()
        'CType(mp.FindControl("lblusrnam"), Label).Text = "Welcome, " + varusrnam
    End Function

    Public Sub Set_Welcome_Message(ByVal mp As MasterPage, ByVal u As String)
        Dim objusr As New CLS_User_Master()
        Dim res As New QueryResponse(Of PRP_users)
        Dim varusrnam As String = ""
        res = objusr.Display_User_Name(System.Web.HttpContext.Current.Session("usrnam"))
        varusrnam = res.responseObject.empnm.ToString()
        CType(mp.FindControl("lblusrnam"), Label).Text = "Welcome, " + varusrnam
    End Sub

    Public Sub NLSMessageBox(ByVal p As Page, ByVal msg As String)
        Dim lbl As New Label
        lbl.Text = "<script language='javascript'>" & Environment.NewLine & _
               "window.alert('" + msg + "')</script>"
        p.Controls.Add(lbl)
    End Sub
    Public Function ValidUser(ByVal varusrnam As String, ByVal varusrpas As String) As Boolean
        Dim objusr As New CLS_JR_Login()
        Dim res As New QueryResponse(Of PRP_users)
        Dim valid As Boolean = False
        res = objusr.Check_User_Login(varusrnam, varusrpas)
        If res.responseObject.outres = 1 Then valid = True
        Return valid
    End Function
    Public Sub HideMenu(ByVal m As MasterPage)
        CType(m.FindControl("NavigationMenu"), Menu).Visible = False
    End Sub

    Public Shared Function GetWebsiteURL() As String
        Dim url As String = ""
        url = HttpContext.Current.Request.Url.Scheme & "://" & HttpContext.Current.Request.Url.Authority & HttpContext.Current.Request.ApplicationPath.TrimEnd("/") & "/"
        Return url
    End Function

End Class

Public Class Cls_Hit_counter
    Inherits db_Connection
    Implements IJRModule(Of PRP_Hit_Counter)


    Public Sub New()
        MyBase.new("cnhrm1") 'Maintenance Development Database
    End Sub

    Public Function Delete(ByVal args As PRP_Hit_Counter) As QueryResponse(Of PRP_Hit_Counter) Implements IJRModule(Of PRP_Hit_Counter).Delete
        Throw New NotImplementedException()
    End Function

    Public Function AddHitCounter(ByVal hit_cou As Int32) As QueryResponse(Of PRP_Hit_Counter)
        Dim res As New QueryResponse(Of PRP_Hit_Counter)
        openConnection()
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "JR_Hit_Count"
            cmd.Parameters.AddWithValue("@par", SqlDbType.Int).Value = 2
            cmd.Parameters.Add("@hit_cou", SqlDbType.BigInt).Value = hit_cou
            res.response = cmd.ExecuteNonQuery()
            res.responseMsg = ""
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
            closeConnection()
        End Try
        Return res
    End Function



    Public Function Insert(ByVal args As PRP_Hit_Counter) As QueryResponse(Of PRP_Hit_Counter) Implements IJRModule(Of PRP_Hit_Counter).Insert
        Throw New NotImplementedException()
    End Function

    Public Function Update(ByVal args As PRP_Hit_Counter) As QueryResponse(Of PRP_Hit_Counter) Implements IJRModule(Of PRP_Hit_Counter).Update
        Throw New NotImplementedException()
    End Function

    Public Function View() As QueryResponse(Of PRP_Hit_Counter) Implements IJRModule(Of PRP_Hit_Counter).View
        Dim res As New QueryResponse(Of PRP_Hit_Counter)
        openConnection()
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "JR_Hit_Count"
            cmd.Parameters.AddWithValue("@par", SqlDbType.Int).Value = 1
            dat = New SqlDataAdapter(cmd)
            Dim ds As New DataSet()
            dat.Fill(ds)
            Dim no As Int32 = 0
            If ds.Tables(0).Rows.Count > 0 Then
                Dim row As DataRow = ds.Tables(0).Rows(0)
                res.responseObject = New PRP_Hit_Counter()
                res.responseObject.hit_cou = row("hit_cou").ToString()
                res.response = 1 : res.responseMsg = ""
            Else
                res.response = -1 : res.responseMsg = ""
            End If
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
            closeConnection()
        End Try
        Return res
    End Function

    Public Function View(ByVal args As PRP_Hit_Counter) As QueryResponse(Of PRP_Hit_Counter) Implements IJRModule(Of PRP_Hit_Counter).View
        Throw New NotImplementedException()
    End Function
End Class


'Sushil 25-10-2021----->
Public Class CLS_JRHdr_Dtl
    Inherits db_Connection
    Implements IJRModule(Of PRP_JRHdr)


    Public Sub New()
        MyBase.new("cnl") 'Maintenance Development Database
    End Sub


    Public Function Delete(ByVal args As PRP_JRHdr) As QueryResponse(Of PRP_JRHdr) Implements IJRModule(Of PRP_JRHdr).Delete
        Dim res As New QueryResponse(Of PRP_JRHdr)
        openConnection()
        cmd = New SqlCommand()
        Try

            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "NIVS_Display_IssueDetail"
            cmd.Parameters.Add("par", SqlDbType.Int).Value = 20
            'cmd.Parameters.Add("miv_no", SqlDbType.BigInt).Value = args.miv_no
            'cmd.Parameters.Add("miv_yr", SqlDbType.Int).Value = args.miv_yr
            res.response = cmd.ExecuteNonQuery()
            res.responseMsg = ""
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
            closeConnection()
        End Try
        Return res
    End Function
    Public Function Insert(ByVal args As PRP_JRHdr, ByVal con As SqlConnection, ByVal trans As SqlTransaction) As QueryResponse(Of PRP_JRHdr)
        Dim res As New QueryResponse(Of PRP_JRHdr)
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.Transaction = trans
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "JR_Save_Hdr"
            '@Emp_Cd, @Emp_Nm, @DOJ, @Dept_Cd, @Dept_Nm, @Desig_Cd, @Desig_Nm, @Catg_Cd, @Catg_Nm, 
            '@Revision_No, @Revision_Date, @Supersede_No, @Reason, @luser_Id,


            cmd.Parameters.Add("reason", SqlDbType.NVarChar, 1000).Value = args.reason
            cmd.Parameters.Add("reason", SqlDbType.NVarChar, 1000).Value = args.reason
            cmd.Parameters.Add("reason", SqlDbType.NVarChar, 1000).Value = args.reason
            cmd.Parameters.Add("reason", SqlDbType.NVarChar, 1000).Value = args.reason
            cmd.Parameters.Add("reason", SqlDbType.NVarChar, 1000).Value = args.reason
            cmd.Parameters.Add("reason", SqlDbType.NVarChar, 1000).Value = args.reason
            cmd.Parameters.Add("reason", SqlDbType.NVarChar, 1000).Value = args.reason
            cmd.Parameters.Add("reason", SqlDbType.NVarChar, 1000).Value = args.reason
            cmd.Parameters.Add("reason", SqlDbType.NVarChar, 1000).Value = args.reason
            cmd.Parameters.Add("reason", SqlDbType.NVarChar, 1000).Value = args.reason
            cmd.Parameters.Add("reason", SqlDbType.NVarChar, 1000).Value = args.reason
            cmd.Parameters.Add("reason", SqlDbType.NVarChar, 1000).Value = args.reason
            cmd.Parameters.Add("reason", SqlDbType.NVarChar, 1000).Value = args.reason
            cmd.Parameters.Add("reason", SqlDbType.NVarChar, 1000).Value = args.reason
            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = args.reason
            res.response = cmd.ExecuteNonQuery()
            res.responseMsg = "Data Saved"
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
        End Try
        Return res
    End Function

    Public Function Insert(ByVal args As PRP_JRHdr) As QueryResponse(Of PRP_JRHdr) Implements IJRModule(Of PRP_JRHdr).Insert
        Throw New NotImplementedException()
    End Function

    Public Function Save_Pmivdtl_With_transaction(ByVal args As PRP_JRHdr, ByVal con As SqlConnection, ByVal tran As SqlTransaction) As QueryResponse(Of PRP_JRHdr)
        Dim res As New QueryResponse(Of PRP_JRHdr)
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            'cmd.Transaction = tran
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "JR_Save_Hdr"

            '@Emp_Cd, @Emp_Nm, @DOJ, @Dept_Cd, @Dept_Nm, @Desig_Cd, @Desig_Nm, @Catg_Cd, @Catg_Nm, 
            '@Revision_No, @Revision_Date, @Supersede_No, @Reason, @luser_Id,

            cmd.Parameters.Add("@Emp_Cd", SqlDbType.NVarChar, 1000).Value = args.reason
            cmd.Parameters.Add("@Emp_Nm", SqlDbType.NVarChar, 1000).Value = args.reason
            cmd.Parameters.Add("@DOJ", SqlDbType.DateTime).Value = args.reason
            cmd.Parameters.Add("@Dept_Cd", SqlDbType.NVarChar, 1000).Value = args.reason
            cmd.Parameters.Add("@Dept_Nm", SqlDbType.NVarChar, 1000).Value = args.reason
            cmd.Parameters.Add("@Desig_Cd", SqlDbType.NVarChar, 1000).Value = args.reason
            cmd.Parameters.Add("@Desig_Nm", SqlDbType.NVarChar, 1000).Value = args.reason
            cmd.Parameters.Add("@Catg_Cd", SqlDbType.NVarChar, 1000).Value = args.reason
            cmd.Parameters.Add("@Catg_Nm", SqlDbType.NVarChar, 1000).Value = args.reason
            cmd.Parameters.Add("@Revision_No", SqlDbType.NVarChar, 1000).Value = args.reason
            cmd.Parameters.Add("@Revision_Date", SqlDbType.DateTime).Value = args.reason
            cmd.Parameters.Add("@Supersede_No", SqlDbType.NVarChar, 1000).Value = args.reason
            cmd.Parameters.Add("@Reason", SqlDbType.NVarChar, 5000).Value = args.reason
            cmd.Parameters.Add("@luser_Id", SqlDbType.NVarChar, 1000).Value = args.reason
            cmd.Parameters.Add("@id", SqlDbType.Int).Direction = ParameterDirection.Output

            res.response = cmd.ExecuteNonQuery()
            res.responseMsg = ""

            Dim id As String = cmd.Parameters("@id").Value.ToString()
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
        End Try
        Return res
    End Function

    Public Function Display_Current_Ret_No() As QueryResponse(Of PRP_JRHdr)
        Dim res As New QueryResponse(Of PRP_JRHdr)
        openConnection()
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "NIVS_Display_IssueDetail"
            cmd.Parameters.Add("@Par", SqlDbType.Int).Value = 21
            dat = New SqlDataAdapter(cmd)
            Dim ds As New DataSet()
            dat.Fill(ds)
            Dim no As Int32 = 0
            If ds.Tables(0).Rows.Count > 0 Then
                Dim drr As DataRow = ds.Tables(0).Rows(0)
                res.responseObject = New PRP_JRHdr()
                'res.responseObject.Ret_No = drr("last_no")
                res.response = 1 : res.responseMsg = ""
            Else
                res.response = -1 : res.responseMsg = ""
            End If
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
            closeConnection()
        End Try
        Return res
    End Function

    Public Function Display_Ret_No(ByVal args As PRP_JRHdr) As QueryResponse(Of PRP_JRHdr)
        Dim res As New QueryResponse(Of PRP_JRHdr)
        res.responseObject = New PRP_JRHdr()
        openConnection()
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "NIVS_Display_IssueDetail"
            cmd.Parameters.Add("@Par", SqlDbType.Int).Value = 23
            'cmd.Parameters.Add("@miv_no", SqlDbType.Int).Value = args.miv_no
            'cmd.Parameters.Add("@miv_yr", SqlDbType.Int).Value = args.miv_yr
            dat = New SqlDataAdapter(cmd)
            Dim ds As New DataSet()
            dat.Fill(ds)
            Dim no As Int32 = 0
            If ds.Tables(0).Rows.Count > 0 Then
                Dim drr As DataRow = ds.Tables(0).Rows(0)
                'res.responseObject.Ret_No = drr("ret_no")
            End If
            'res.responseObject.Ret_No = IIf(String.IsNullOrWhiteSpace(res.responseObject.Ret_No), 0, res.responseObject.Ret_No)
            res.response = 1
            res.responseMsg = ""
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
            closeConnection()
        End Try
        Return res
    End Function


    Public Function Update(ByVal args As PRP_JRHdr) As QueryResponse(Of PRP_JRHdr) Implements IJRModule(Of PRP_JRHdr).Update
        Throw New NotImplementedException()
    End Function

    Public Function View() As QueryResponse(Of PRP_JRHdr) Implements IJRModule(Of PRP_JRHdr).View
        Throw New NotImplementedException()
    End Function

    Public Function View(ByVal args As PRP_JRHdr) As QueryResponse(Of PRP_JRHdr) Implements IJRModule(Of PRP_JRHdr).View
        Throw New NotImplementedException()
    End Function
End Class

Public Class CLS_JR_Audit_Trails
    Inherits db_Connection
    Implements IJRModule(Of PRP_JR_Audit_Trails)

    Public Sub New()
        MyBase.new("cnhrm1") 'Maintenance Development Database
    End Sub

    Public Function Delete(ByVal args As PRP_JR_Audit_Trails) As QueryResponse(Of PRP_JR_Audit_Trails) Implements IJRModule(Of PRP_JR_Audit_Trails).Delete
        Throw New NotImplementedException()
    End Function

    Public Function Insert(ByVal args As PRP_JR_Audit_Trails) As QueryResponse(Of PRP_JR_Audit_Trails) Implements IJRModule(Of PRP_JR_Audit_Trails).Insert
        Throw New NotImplementedException()
    End Function

    Public Function Update(ByVal args As PRP_JR_Audit_Trails) As QueryResponse(Of PRP_JR_Audit_Trails) Implements IJRModule(Of PRP_JR_Audit_Trails).Update
        Throw New NotImplementedException()
    End Function

    Public Function View() As QueryResponse(Of PRP_JR_Audit_Trails) Implements IJRModule(Of PRP_JR_Audit_Trails).View
        Throw New NotImplementedException()
    End Function

    Public Function View(ByVal args As PRP_JR_Audit_Trails) As QueryResponse(Of PRP_JR_Audit_Trails) Implements IJRModule(Of PRP_JR_Audit_Trails).View
        Throw New NotImplementedException()
    End Function

    Public Function getJRAuditTrailsList(ByVal empcd As String) As QueryResponse(Of PRP_JR_Audit_Trails)
        Dim res As New QueryResponse(Of PRP_JR_Audit_Trails)
        res.responseObject = New PRP_JR_Audit_Trails()
        Dim updateon_dt As String = "" : Dim updateon_tm As String = "" : Dim updateon As String = ""
        openConnection()
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "JR_Display"
            cmd.Parameters.Add("@Par", SqlDbType.Int).Value = 23
            cmd.Parameters.Add("@emp_cd", SqlDbType.Char, 10).Value = empcd.ToString().Trim()
            dat = New SqlDataAdapter(cmd)
            Dim ds As New DataSet()
            dat.Fill(ds)
            Dim no As Int32 = 0
            If ds.Tables(0).Rows.Count > 0 Then
                res.responseObjectList = New List(Of PRP_JR_Audit_Trails)
                For Each drr As DataRow In ds.Tables(0).Rows
                    If drr("AT_UpdatedOn").ToString() <> "" Then updateon_dt = Convert.ToDateTime(drr("AT_UpdatedOn").ToString()).ToString("dd-MM-yyyy") : updateon_tm = Convert.ToDateTime(drr("AT_UpdatedOn").ToString()).ToString("HH:mm:ss") : updateon = updateon_dt & " " & updateon_tm Else updateon_tm = "" : updateon_dt = "" : updateon = ""
                    res.responseObjectList.Add(New PRP_JR_Audit_Trails() With {
                    .AT_Activity = drr("AT_Activity").ToString(),
                    .AT_Id = Convert.ToInt64(drr("AT_Id").ToString()),
                    .AT_Reason = drr("AT_Reason").ToString(),
                    .AT_UpdatedBy = drr("AT_UpdatedBy").ToString(),
                    .AT_UpdatedOn = updateon
                })
                Next
                res.response = 1 : res.responseMsg = ""
            Else
                res.response = -1 : res.responseMsg = ""
            End If
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
            closeConnection()
        End Try
        Return res
    End Function

End Class


Public Class EncryptDecrypt
    Public Shared Function Encrypt(ByVal clearText As String) As String
        Dim EncryptionKey As String = "MAKV2SPBNI99212"
        Dim clearBytes As Byte() = Encoding.Unicode.GetBytes(clearText)
        Using encryptor As Aes = Aes.Create()
            Dim pdb As New Rfc2898DeriveBytes(EncryptionKey, New Byte() {&H49, &H76, &H61, &H6E, &H20, &H4D, _
             &H65, &H64, &H76, &H65, &H64, &H65, _
             &H76})
            encryptor.Key = pdb.GetBytes(32)
            encryptor.IV = pdb.GetBytes(16)
            Using ms As New MemoryStream()
                Using cs As New CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write)
                    cs.Write(clearBytes, 0, clearBytes.Length)
                    cs.Close()
                End Using
                clearText = Convert.ToBase64String(ms.ToArray())
            End Using
        End Using
        Return clearText
    End Function

    Public Shared Function Decrypt(ByVal cipherText As String) As String
        Dim EncryptionKey As String = "MAKV2SPBNI99212"
        cipherText = cipherText.Replace(" ", "+")
        Dim cipherBytes As Byte() = Convert.FromBase64String(cipherText)
        Using encryptor As Aes = Aes.Create()
            Dim pdb As New Rfc2898DeriveBytes(EncryptionKey, New Byte() {&H49, &H76, &H61, &H6E, &H20, &H4D, _
             &H65, &H64, &H76, &H65, &H64, &H65, _
             &H76})
            encryptor.Key = pdb.GetBytes(32)
            encryptor.IV = pdb.GetBytes(16)
            Using ms As New MemoryStream()
                Using cs As New CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write)
                    cs.Write(cipherBytes, 0, cipherBytes.Length)
                    cs.Close()
                End Using
                cipherText = Encoding.Unicode.GetString(ms.ToArray())
            End Using
        End Using
        Return cipherText
    End Function

End Class


Public Class CLS_JR_Dashboard
    Inherits db_Connection
    Implements IJRModule(Of PRP_JR_Dashboard)

    Public Sub New()
        MyBase.new("cnhrm1") 'Maintenance Development Database
    End Sub


    Public Function Delete(ByVal args As PRP_JR_Dashboard) As QueryResponse(Of PRP_JR_Dashboard) Implements IJRModule(Of PRP_JR_Dashboard).Delete
        Throw New NotImplementedException()
    End Function

    Public Function Insert(ByVal args As PRP_JR_Dashboard) As QueryResponse(Of PRP_JR_Dashboard) Implements IJRModule(Of PRP_JR_Dashboard).Insert
        Throw New NotImplementedException()
    End Function

    Public Function Update(ByVal args As PRP_JR_Dashboard) As QueryResponse(Of PRP_JR_Dashboard) Implements IJRModule(Of PRP_JR_Dashboard).Update
        Throw New NotImplementedException()
    End Function

    Public Function View() As QueryResponse(Of PRP_JR_Dashboard) Implements IJRModule(Of PRP_JR_Dashboard).View
        Throw New NotImplementedException()
    End Function

    Public Function View(ByVal args As PRP_JR_Dashboard) As QueryResponse(Of PRP_JR_Dashboard) Implements IJRModule(Of PRP_JR_Dashboard).View
        Throw New NotImplementedException()
    End Function
    Public Function View(ByVal empcd As String) As QueryResponse(Of PRP_JR_Dashboard)
        Dim res As New QueryResponse(Of PRP_JR_Dashboard)
        res.responseObject = New PRP_JR_Dashboard()
        Dim updateon_dt As String = "" : Dim updateon_tm As String = "" : Dim updateon As String = ""
        openConnection()
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "JR_Display"
            cmd.Parameters.Add("@Par", SqlDbType.Int).Value = 24
            cmd.Parameters.Add("@emp_cd", SqlDbType.Char, 10).Value = empcd.ToString().Trim()
            dat = New SqlDataAdapter(cmd)
            Dim ds As New DataSet()
            dat.Fill(ds)
            Dim no As Int32 = 0
            If ds.Tables(0).Rows.Count > 0 Then
                res.responseObjectList = New List(Of PRP_JR_Dashboard)
                For Each drr As DataRow In ds.Tables(0).Rows
                    res.responseObjectList.Add(New PRP_JR_Dashboard() With {
                    .JR_count = Convert.ToInt64(drr("JR_count").ToString()),
                    .tabname = drr("tabname").ToString().Trim(),
                    .url = drr("url").ToString().Trim(),
                    .color = drr("color").ToString().Trim()
                })
                Next
                res.response = 1 : res.responseMsg = ""
            Else
                res.response = -1 : res.responseMsg = ""
            End If
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
            closeConnection()
        End Try
        Return res
    End Function

    Public Function View1(ByVal empcd As String) As QueryResponse(Of PRP_JR_Dashboard)
        Dim res As New QueryResponse(Of PRP_JR_Dashboard)
        res.responseObject = New PRP_JR_Dashboard()
        Dim updateon_dt As String = "" : Dim updateon_tm As String = "" : Dim updateon As String = ""
        openConnection()
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "JR_Display"
            cmd.Parameters.Add("@Par", SqlDbType.Int).Value = 33
            cmd.Parameters.Add("@emp_cd", SqlDbType.Char, 10).Value = empcd.ToString().Trim()
            dat = New SqlDataAdapter(cmd)
            Dim ds As New DataSet()
            dat.Fill(ds)
            Dim no As Int32 = 0
            If ds.Tables(0).Rows.Count > 0 Then
                res.responseObjectList = New List(Of PRP_JR_Dashboard)
                For Each drr As DataRow In ds.Tables(0).Rows
                    res.responseObjectList.Add(New PRP_JR_Dashboard() With {
                    .JR_count = Convert.ToInt64(drr("JR_count").ToString()),
                    .tabname = drr("tabname").ToString().Trim(),
                    .url = drr("url").ToString().Trim(),
                    .color = drr("color").ToString().Trim()
                })
                Next
                res.response = 1 : res.responseMsg = ""
            Else
                res.response = -1 : res.responseMsg = ""
            End If
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
            closeConnection()
        End Try
        Return res
    End Function
End Class

Public Class CLS_JRAccessRights
    Inherits db_Connection
    Implements IJRModule(Of PRP_JRAccessRights)


    Public Sub New()
        MyBase.new("cnhrm1") 'Maintenance Development Database
    End Sub

    Public Function Delete(ByVal args As PRP_JRAccessRights) As QueryResponse(Of PRP_JRAccessRights) Implements IJRModule(Of PRP_JRAccessRights).Delete
        Throw New NotImplementedException()
    End Function

    Public Function Insert(ByVal args As PRP_JRAccessRights) As QueryResponse(Of PRP_JRAccessRights) Implements IJRModule(Of PRP_JRAccessRights).Insert
        Throw New NotImplementedException()
    End Function

    Public Function Update(ByVal args As PRP_JRAccessRights) As QueryResponse(Of PRP_JRAccessRights) Implements IJRModule(Of PRP_JRAccessRights).Update
        Throw New NotImplementedException()
    End Function

    Public Function View() As QueryResponse(Of PRP_JRAccessRights) Implements IJRModule(Of PRP_JRAccessRights).View
        Dim res As New QueryResponse(Of PRP_JRAccessRights)
        openConnection()
        cmd = New SqlCommand()
        Try
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 500
            cmd.CommandText = "JR_AccessRight"
            'cmd.Parameters.Add("@par", SqlDbType.Int).Value = 26
            dat = New SqlDataAdapter(cmd)
            Dim ds As New DataSet()
            dat.Fill(ds)
            Dim no As Int32 = 0
            If ds.Tables(0).Rows.Count > 0 Then
                res.responseObjectList = New List(Of PRP_JRAccessRights)
                For Each drr As DataRow In ds.Tables(0).Rows
                    no = no + 1
                    res.responseObjectList.Add(New PRP_JRAccessRights() With {
                        .accessRights = drr("AccessRight").ToString(),
                        .isAdmin = drr("isAdmin").ToString(),
                        .isFinalAuth = drr("isFinalAuth").ToString(),
                        .isFirstAuth = drr("isFirstAuth").ToString(),
                        .isHR = drr("isHR").ToString(),
                        .isUser = drr("isUser").ToString()
                    })
                Next
                res.response = 1 : res.responseMsg = ""
            Else
                res.response = -1 : res.responseMsg = "Records not Found"
            End If
        Catch ex As Exception
            res.response = -1 : res.responseMsg = ex.Message.ToString()
        Finally
            cmd.Dispose()
            closeConnection()
        End Try
        Return res
    End Function

    Public Function View(ByVal args As PRP_JRAccessRights) As QueryResponse(Of PRP_JRAccessRights) Implements IJRModule(Of PRP_JRAccessRights).View

    End Function
End Class



'Sushil 25-10-2021-----<

#End Region
