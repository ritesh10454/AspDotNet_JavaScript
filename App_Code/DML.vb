Imports Microsoft.VisualBasic
#Region "Properties"
Public Class PRP_Lists

    Private var_department As List(Of PRP_Department)
    Public Property Department() As List(Of PRP_Department)
        Get
            Return var_department
        End Get
        Set(ByVal value As List(Of PRP_Department))
            var_department = value
        End Set
    End Property

    Private var_PRP_department_List As List(Of PRP_Department)
    Public Property PRP_Department_List() As List(Of PRP_Department)
        Get
            Return var_PRP_department_List
        End Get
        Set(ByVal value As List(Of PRP_Department))
            var_PRP_department_List = value
        End Set
    End Property

    Private var_employee As List(Of PRP_Employee)
    Public Property Employee() As List(Of PRP_Employee)
        Get
            Return var_employee
        End Get
        Set(ByVal value As List(Of PRP_Employee))
            var_employee = value
        End Set
    End Property

    Private var_PRP_Employee_List As List(Of PRP_Employee)
    Public Property PRP_Employee_List() As List(Of PRP_Employee)
        Get
            Return var_PRP_employee_List
        End Get
        Set(ByVal value As List(Of PRP_Employee))
            var_PRP_employee_List = value
        End Set
    End Property

    Private var_UserRole As PRP_hry
    Public Property UserRole() As PRP_hry
        Get
            Return var_UserRole
        End Get
        Set(ByVal value As PRP_hry)
            var_UserRole = value
        End Set
    End Property

End Class

Public Class PRP_hry
    Private var_emp_cd As String
    Private var_emp_nm As String
    Private var_Apr_id As String
    Private var_Apr_emp_nm As String
    Private var_Aut_id As String
    Private var_aut_emp_nm As String
    Private var_eid As String
    Private var_reid As String
    Private var_tag As String
    Private var_tpi As String
    Private var_tpiid As String
    Private var_dept_nm As String
    Private var_desig_nm As String
    Private var_dept_cd As Int32
    Private var_rpt As String
    Private var_srno As Int32

    Public Property srno As Int32
        Get
            Return var_srno
        End Get
        Set(ByVal value As Int32)
            var_srno = value
        End Set
    End Property
    Public Property rpt As String
        Get
            Return var_rpt
        End Get
        Set(ByVal value As String)
            var_rpt = value
        End Set
    End Property
    Public Property dept_cd As Int32
        Get
            Return var_dept_cd
        End Get
        Set(ByVal value As Int32)
            var_dept_cd = value
        End Set
    End Property
    Public Property desig_nm As String
        Get
            Return var_desig_nm
        End Get
        Set(ByVal value As String)
            var_desig_nm = value
        End Set
    End Property
    Public Property dept_nm As String
        Get
            Return var_dept_nm
        End Get
        Set(ByVal value As String)
            var_dept_nm = value
        End Set
    End Property

    Public Property emp_nm As String
        Get
            Return var_emp_nm
        End Get
        Set(ByVal value As String)
            var_emp_nm = value
        End Set
    End Property
    Public Property aut_id As String
        Get
            Return var_Aut_id
        End Get
        Set(ByVal value As String)
            var_Aut_id = value
        End Set
    End Property
    Public Property aut_emp_nm As String
        Get
            Return var_aut_emp_nm
        End Get
        Set(ByVal value As String)
            var_aut_emp_nm = value
        End Set
    End Property
    Public Property apr_emp_nm As String
        Get
            Return var_Apr_emp_nm
        End Get
        Set(ByVal value As String)
            var_Apr_emp_nm = value
        End Set
    End Property

    Public Property eid As String
        Get
            Return var_eid
        End Get
        Set(ByVal value As String)
            var_eid = value
        End Set
    End Property

    Public Property emp_cd As String
        Get
            Return var_emp_cd
        End Get
        Set(ByVal value As String)
            var_emp_cd = value
        End Set
    End Property

    Public Property reid As String
        Get
            Return var_reid
        End Get
        Set(ByVal value As String)
            var_reid = value
        End Set
    End Property

    Public Property apr_id As String
        Get
            Return var_Apr_id
        End Get
        Set(ByVal value As String)
            var_Apr_id = value
        End Set
    End Property

    Public Property tag As String
        Get
            Return var_tag
        End Get
        Set(ByVal value As String)
            var_tag = value
        End Set
    End Property

    Public Property tpi As String
        Get
            Return var_tpi
        End Get
        Set(ByVal value As String)
            var_tpi = value
        End Set
    End Property

    Public Property tpiid As String
        Get
            Return var_tpiid
        End Get
        Set(ByVal value As String)
            var_tpiid = value
        End Set
    End Property
End Class

Public Class PRP_lv_emp_sec
    Private var_emp_cd As String
    Private var_sec_cd As String
    Public Property emp_cd As String
        Get
            Return var_emp_cd
        End Get
        Set(ByVal value As String)
            var_emp_cd = value
        End Set
    End Property

    Public Property sec_cd As String
        Get
            Return var_sec_cd
        End Get
        Set(ByVal value As String)
            var_sec_cd = value
        End Set
    End Property
End Class

Public Class PRP_Login
    Private var_UserID As String
    Private var_pwd As String
    Private var_indt_entry As Char
    Private var_indt_app As Char
    Private var_auth_ID As String
    Private var_Auth_ID_2 As String
    Private var_Auth_ID_3 As String
    Private var_dept_Cd As Int32
    Private var_Email As String
    Private var_Store_status As Char
    Private var_UserNm As String
    Private var_dept_nm As String
    Private var_desig_nm As String
    Public Property dept_nm As String
        Get
            Return var_dept_nm
        End Get
        Set(ByVal value As String)
            var_dept_nm = value
        End Set
    End Property
    Public Property desig_nm As String
        Get
            Return var_desig_nm
        End Get
        Set(ByVal value As String)
            var_desig_nm = value
        End Set
    End Property
    Public Property auth_ID As String
        Get
            Return var_auth_ID
        End Get
        Set(ByVal value As String)
            var_auth_ID = value
        End Set
    End Property

    Public Property Auth_ID_2 As String
        Get
            Return var_Auth_ID_2
        End Get
        Set(ByVal value As String)
            var_Auth_ID_2 = value
        End Set
    End Property

    Public Property Auth_ID_3 As String
        Get
            Return var_Auth_ID_3
        End Get
        Set(ByVal value As String)
            var_Auth_ID_3 = value
        End Set
    End Property

    Public Property dept_Cd As Integer
        Get
            Return var_dept_Cd
        End Get
        Set(ByVal value As Integer)
            var_dept_Cd = value
        End Set
    End Property

    Public Property Email As String
        Get
            Return var_Email
        End Get
        Set(ByVal value As String)
            var_Email = value
        End Set
    End Property

    Public Property indt_app As Char
        Get
            Return var_indt_app
        End Get
        Set(ByVal value As Char)
            var_indt_app = value
        End Set
    End Property

    Public Property indt_entry As Char
        Get
            Return var_indt_entry
        End Get
        Set(ByVal value As Char)
            var_indt_entry = value
        End Set
    End Property

    Public Property pwd As String
        Get
            Return var_pwd
        End Get
        Set(ByVal value As String)
            var_pwd = value
        End Set
    End Property

    Public Property Store_status As Char
        Get
            Return var_Store_status
        End Get
        Set(ByVal value As Char)
            var_Store_status = value
        End Set
    End Property

    Public Property UserID As String
        Get
            Return var_UserID
        End Get
        Set(ByVal value As String)
            var_UserID = value
        End Set
    End Property

    Public Property UserNm As String
        Get
            Return var_UserNm
        End Get
        Set(ByVal value As String)
            var_UserNm = value
        End Set
    End Property
End Class
'Sushil----->
Public Class PRP_Employee
    Private var_emp_cd As String
    Private var_emp_nm As String

    Public Property emp_cd As String
        Get
            Return var_emp_cd
        End Get
        Set(ByVal value As String)
            var_emp_cd = value
        End Set
    End Property
    Public Property emp_nm As String
        Get
            Return var_emp_nm
        End Get
        Set(ByVal value As String)
            var_emp_nm = value
        End Set
    End Property

End Class
'Sushil-----<
Public Class PRP_Hit_Counter
    Private var_hit_cou As Int64
    Public Property hit_cou As Long
        Get
            Return var_hit_cou
        End Get
        Set(ByVal value As Long)
            var_hit_cou = value
        End Set
    End Property
End Class

Public Class PRP_User_Master
    Private var_emp As String
    Private var_u_id As Int64
    Private var_emp_cd As String
    Private var_emp_nm As String
    Private var_loc_cod As Int32
    Private var_pre_exp_yrs As Int32
    Private var_pre_exp_mon As Int32
    Private var_dt_join As DateTime
    Private var_desig_cd As Int32
    Private var_dept_cd As Int32
    Private var_std_qual_cd As Int32
    Private var_sta As Int16
    Private var_rev_num As Int16
    Private var_las_usr_cod As String
    Private var_las_usr_pas As String
    Private var_las_usr_dat As DateTime

    Private var_dept_nm As String
    Private var_desig_nm As String
    Private var_catg_nm As String
    Private var_std_qual_desc As String
    Private var_isDTC As String
    Public Property isDTC() As String
        Get
            Return var_isDTC
        End Get
        Set(ByVal value As String)
            var_isDTC = value
        End Set
    End Property

    Public Property emp_cd As String
        Get
            Return var_emp_cd
        End Get
        Set(ByVal value As String)
            var_emp_cd = value
        End Set
    End Property

    Public Property dept_nm As String
        Get
            Return var_dept_nm
        End Get
        Set(ByVal value As String)
            var_dept_nm = value
        End Set
    End Property

    Public Property desig_nm As String
        Get
            Return var_desig_nm
        End Get
        Set(ByVal value As String)
            var_desig_nm = value
        End Set
    End Property
    Private var_catg_cd As Int32
    Public Property catg_cd() As Int32
        Get
            Return var_catg_cd
        End Get
        Set(ByVal value As Int32)
            var_catg_cd = value
        End Set
    End Property

    Public Property catg_nm As String
        Get
            Return var_catg_nm
        End Get
        Set(ByVal value As String)
            var_catg_nm = value
        End Set
    End Property

    Public Property std_qual_desc As String
        Get
            Return var_std_qual_desc
        End Get
        Set(ByVal value As String)
            var_std_qual_desc = value
        End Set
    End Property

    Public Property emp_nm As String
        Get
            Return var_emp_nm
        End Get
        Set(ByVal value As String)
            var_emp_nm = value
        End Set
    End Property

    Public Property emp As String
        Get
            Return var_emp
        End Get
        Set(ByVal value As String)
            var_emp = value
        End Set
    End Property

    Public Property las_usr_cod As String
        Get
            Return var_las_usr_cod
        End Get
        Set(ByVal value As String)
            var_las_usr_cod = value
        End Set
    End Property

    Public Property las_usr_dat As Date
        Get
            Return var_las_usr_dat
        End Get
        Set(ByVal value As Date)
            var_las_usr_dat = value
        End Set
    End Property

    Public Property sta As Short
        Get
            Return var_sta
        End Get
        Set(ByVal value As Short)
            var_sta = value
        End Set
    End Property

    Public Property u_id As Long
        Get
            Return var_u_id
        End Get
        Set(ByVal value As Long)
            var_u_id = value
        End Set
    End Property

    Public Property dept_cd As Integer
        Get
            Return var_dept_cd
        End Get
        Set(ByVal value As Integer)
            var_dept_cd = value
        End Set
    End Property

    Public Property desig_cd As Integer
        Get
            Return var_desig_cd
        End Get
        Set(ByVal value As Integer)
            var_desig_cd = value
        End Set
    End Property

    Public Property dt_join As Date
        Get
            Return var_dt_join
        End Get
        Set(ByVal value As Date)
            var_dt_join = value
        End Set
    End Property

    Public Property loc_cod As Integer
        Get
            Return var_loc_cod
        End Get
        Set(ByVal value As Integer)
            var_loc_cod = value
        End Set
    End Property

    Public Property pre_exp_mon As Integer
        Get
            Return var_pre_exp_mon
        End Get
        Set(ByVal value As Integer)
            var_pre_exp_mon = value
        End Set
    End Property

    Public Property pre_exp_yrs As Integer
        Get
            Return var_pre_exp_yrs
        End Get
        Set(ByVal value As Integer)
            var_pre_exp_yrs = value
        End Set
    End Property

    Public Property rev_num As Short
        Get
            Return var_rev_num
        End Get
        Set(ByVal value As Short)
            var_rev_num = value
        End Set
    End Property

    Public Property std_qual_cd As Integer
        Get
            Return var_std_qual_cd
        End Get
        Set(ByVal value As Integer)
            var_std_qual_cd = value
        End Set
    End Property

    Public Property las_usr_pas As String
        Get
            Return var_las_usr_pas
        End Get
        Set(ByVal value As String)
            var_las_usr_pas = value
        End Set
    End Property
End Class
''Sushil----->
Public Class PRP_Department
    Private var_dept_cd As String
    Private var_dept_nm As String
    Public Property dept_cd As String
        Get
            Return var_dept_cd
        End Get
        Set(ByVal value As String)
            var_dept_cd = value
        End Set
    End Property

    Public Property dept_nm As String
        Get
            Return var_dept_nm
        End Get
        Set(ByVal value As String)
            var_dept_nm = value
        End Set
    End Property
End Class
''Sushil-----<

''Sushil----->
Public Class PRP_EmployeeDetail
    Private var_emp_cd As String
    Private var_emp_nm As String
    Private var_dept_nm As String
    Private var_dept_cd As String
    Private var_desig_nm As String
    Private var_desig_cd As String
    Private var_catg_nm As String
    Private var_catg_cd As String
    Private var_dt_join As String

    Public Property emp_cd As String
        Get
            Return var_emp_cd
        End Get
        Set(ByVal value As String)
            var_emp_cd = value
        End Set
    End Property
    Public Property emp_nm As String
        Get
            Return var_emp_nm
        End Get
        Set(ByVal value As String)
            var_emp_nm = value
        End Set
    End Property
    Public Property dept_cd As String
        Get
            Return var_dept_cd
        End Get
        Set(ByVal value As String)
            var_dept_cd = value
        End Set
    End Property
    Public Property dept_nm As String
        Get
            Return var_dept_nm
        End Get
        Set(ByVal value As String)
            var_dept_nm = value
        End Set
    End Property
    Public Property desig_cd As String
        Get
            Return var_desig_cd
        End Get
        Set(ByVal value As String)
            var_desig_cd = value
        End Set
    End Property
    Public Property desig_nm As String
        Get
            Return var_desig_nm
        End Get
        Set(ByVal value As String)
            var_desig_nm = value
        End Set
    End Property
    Public Property catg_cd As String
        Get
            Return var_catg_cd
        End Get
        Set(ByVal value As String)
            var_catg_cd = value
        End Set
    End Property
    Public Property catg_nm As String
        Get
            Return var_catg_nm
        End Get
        Set(ByVal value As String)
            var_catg_nm = value
        End Set
    End Property
    Public Property dt_join As String
        Get
            Return var_dt_join
        End Get
        Set(ByVal value As String)
            var_dt_join = value
        End Set
    End Property
End Class

Public Class PRP_JRHdr

    Private var_Emp_Cd As String
    Private var_Emp_Nm As String
    Private var_DOJ As String
    Private var_Dept_Cd As String
    Private var_Dept_Nm As String
    Private var_Desig_Cd As String
    Private var_Desig_Nm As String
    Private var_Catg_Cd As String
    Private var_Catg_Nm As String
    Private var_Revision_Date As String
    Private var_Supersede_No As String
    Private var_Reason As String
    Private var_Jr_Detail As String
    Private var_IsCurrent As Integer
    Private var_F_Hdr_Id As Integer
    Private var_btnsave As String
    Private var_TotalRecords As Int64
    Public Property TotalRecords() As Int64
        Get
            Return var_TotalRecords
        End Get
        Set(ByVal value As Int64)
            var_TotalRecords = value
        End Set
    End Property

    Private var_move As String
    Public Property move() As String
        Get
            Return var_move
        End Get
        Set(ByVal value As String)
            var_move = value
        End Set
    End Property
    Private var_sta As Int64
    Public Property sta() As Int64
        Get
            Return var_sta
        End Get
        Set(ByVal value As Int64)
            var_sta = value
        End Set
    End Property
    Private var_tra As String
    Public Property tra() As String
        Get
            Return var_tra
        End Get
        Set(ByVal value As String)
            var_tra = value
        End Set
    End Property
    Private var_btnaction As String
    Public Property btnaction() As String
        Get
            Return var_btnaction
        End Get
        Set(ByVal value As String)
            var_btnaction = value
        End Set
    End Property

    Public Property btnsave() As String
        Get
            Return var_btnsave
        End Get
        Set(ByVal value As String)
            var_btnsave = value
        End Set
    End Property

    Private var_RoleId As Int64
    Public Property RoleId() As Int64
        Get
            Return var_RoleId
        End Get
        Set(ByVal value As Int64)
            var_RoleId = value
        End Set
    End Property

    Private var_EntryExists As Int64
    Public Property EntryExists() As Int64
        Get
            Return var_EntryExists
        End Get
        Set(ByVal value As Int64)
            var_EntryExists = value
        End Set
    End Property
    Private var_firstapp_id As String
    Public Property firstapp_id() As String
        Get
            Return var_firstapp_id
        End Get
        Set(ByVal value As String)
            var_firstapp_id = value
        End Set
    End Property
    Private var_firstapp_nm As String
    Public Property firstapp_nm() As String
        Get
            Return var_firstapp_nm
        End Get
        Set(ByVal value As String)
            var_firstapp_nm = value
        End Set
    End Property
    Private var_firstapp_dt As String
    Public Property firstapp_dt() As String
        Get
            Return var_firstapp_dt
        End Get
        Set(ByVal value As String)
            var_firstapp_dt = value
        End Set
    End Property
    Private var_firstapp_tm As String
    Public Property firstapp_tm() As String
        Get
            Return var_firstapp_tm
        End Get
        Set(ByVal value As String)
            var_firstapp_tm = value
        End Set
    End Property
    Private var_finalapp_id As String
    Public Property finalapp_id() As String
        Get
            Return var_finalapp_id
        End Get
        Set(ByVal value As String)
            var_finalapp_id = value
        End Set
    End Property
    Private var_finalapp_nm As String
    Public Property finalapp_nm() As String
        Get
            Return var_finalapp_nm
        End Get
        Set(ByVal value As String)
            var_finalapp_nm = value
        End Set
    End Property
    Private var_finalapp_dt As String
    Public Property finalapp_dt() As String
        Get
            Return var_finalapp_dt
        End Get
        Set(ByVal value As String)
            var_finalapp_dt = value
        End Set
    End Property
    Private var_finalapp_tm As String
    Public Property finalapp_tm() As String
        Get
            Return var_finalapp_tm
        End Get
        Set(ByVal value As String)
            var_finalapp_tm = value
        End Set
    End Property

    Private var_hr_finalapp_id As String
    Public Property hr_finalapp_id() As String
        Get
            Return var_hr_finalapp_id
        End Get
        Set(ByVal value As String)
            var_hr_finalapp_id = value
        End Set
    End Property
    Private var_hr_finalapp_nm As String
    Public Property hr_finalapp_nm() As String
        Get
            Return var_hr_finalapp_nm
        End Get
        Set(ByVal value As String)
            var_hr_finalapp_nm = value
        End Set
    End Property
    Private var_hr_finalapp_dt As String
    Public Property hr_finalapp_dt() As String
        Get
            Return var_hr_finalapp_dt
        End Get
        Set(ByVal value As String)
            var_hr_finalapp_dt = value
        End Set
    End Property
    Private var_hr_finalapp_tm As String
    Public Property hr_finalapp_tm() As String
        Get
            Return var_hr_finalapp_tm
        End Get
        Set(ByVal value As String)
            var_hr_finalapp_tm = value
        End Set
    End Property

    Private var_prepapp_id As String
    Public Property prepapp_id() As String
        Get
            Return var_prepapp_id
        End Get
        Set(ByVal value As String)
            var_prepapp_id = value
        End Set
    End Property
    Private var_prepapp_dt As String
    Public Property prepapp_dt() As String
        Get
            Return var_prepapp_dt
        End Get
        Set(ByVal value As String)
            var_prepapp_dt = value
        End Set
    End Property
    Private var_prepapp_tm As String
    Public Property prepapp_tm() As String
        Get
            Return var_prepapp_tm
        End Get
        Set(ByVal value As String)
            var_prepapp_tm = value
        End Set
    End Property

    Private var_prepapp_nm As String
    Public Property prepapp_nm() As String
        Get
            Return var_prepapp_nm
        End Get
        Set(ByVal value As String)
            var_prepapp_nm = value
        End Set
    End Property
    Public Property emp_cd As String
        Get
            Return var_Emp_Cd
        End Get
        Set(ByVal value As String)
            var_Emp_Cd = value
        End Set
    End Property
    Public Property emp_nm As String
        Get
            Return var_Emp_Nm
        End Get
        Set(ByVal value As String)
            var_Emp_Nm = value
        End Set
    End Property
    Private var_Emp_app_dt As String
    Public Property Emp_app_dt() As String
        Get
            Return var_Emp_app_dt
        End Get
        Set(ByVal value As String)
            var_Emp_app_dt = value
        End Set
    End Property
    Private var_Emp_att_tm As String
    Public Property Emp_att_tm() As String
        Get
            Return var_Emp_att_tm
        End Get
        Set(ByVal value As String)
            var_Emp_att_tm = value
        End Set
    End Property



    Public Property dept_cd As String
        Get
            Return var_Dept_Cd
        End Get
        Set(ByVal value As String)
            var_Dept_Cd = value
        End Set
    End Property
    Public Property dept_nm As String
        Get
            Return var_Dept_Nm
        End Get
        Set(ByVal value As String)
            var_Dept_Nm = value
        End Set
    End Property
    Public Property desig_cd As String
        Get
            Return var_Desig_Cd
        End Get
        Set(ByVal value As String)
            var_Desig_Cd = value
        End Set
    End Property
    Public Property desig_nm As String
        Get
            Return var_Desig_Nm
        End Get
        Set(ByVal value As String)
            var_Desig_Nm = value
        End Set
    End Property
    Public Property catg_cd As String
        Get
            Return var_Catg_Cd
        End Get
        Set(ByVal value As String)
            var_Catg_Cd = value
        End Set
    End Property
    Public Property catg_nm As String
        Get
            Return var_Catg_Nm
        End Get
        Set(ByVal value As String)
            var_Catg_Nm = value
        End Set
    End Property
    Public Property doj As String
        Get
            Return var_DOJ
        End Get
        Set(ByVal value As String)
            var_DOJ = value
        End Set
    End Property
    Private var_Revision_No As String
    Public Property revision_no As String
        Get
            Return var_Revision_No
        End Get
        Set(ByVal value As String)
            var_Revision_No = value
        End Set
    End Property
    Public Property revision_date As String
        Get
            Return var_Revision_Date
        End Get
        Set(ByVal value As String)
            var_Revision_Date = value
        End Set
    End Property
    Public Property supersede_no As String
        Get
            Return var_Supersede_No
        End Get
        Set(ByVal value As String)
            var_Supersede_No = value
        End Set
    End Property
    Public Property reason As String
        Get
            Return var_Reason
        End Get
        Set(ByVal value As String)
            var_Reason = value
        End Set
    End Property
    Public Property jr_detail As String
        Get
            Return var_Jr_Detail
        End Get
        Set(ByVal value As String)
            var_Jr_Detail = value
        End Set
    End Property
    Public Property isCurrent As Integer
        Get
            Return var_IsCurrent
        End Get
        Set(ByVal value As Integer)
            var_IsCurrent = value
        End Set
    End Property
    Public Property f_hdr_id As Integer
        Get
            Return var_F_Hdr_Id
        End Get
        Set(ByVal value As Integer)
            var_F_Hdr_Id = value
        End Set
    End Property
    Private var_Id As Integer
    Public Property Id() As Integer
        Get
            Return var_Id
        End Get
        Set(ByVal value As Integer)
            var_Id = value
        End Set
    End Property

    Private var_userpass As String
    Public Property userpass() As String
        Get
            Return var_userpass
        End Get
        Set(ByVal value As String)
            var_userpass = value
        End Set
    End Property




    'Private var_PRP_JRDtl As List(Of PRP_JRDtl)
    'Public Property PRP_JRDtl() As List(Of PRP_JRDtl)
    '    Get
    '        Return var_PRP_JRDtl
    '    End Get
    '    Set(ByVal value As List(Of PRP_JRDtl))
    '        var_PRP_JRDtl = value
    '    End Set
    'End Property

End Class

Public Class PRP_JRDtl
    Private var_F_JR_Emp_Hdr As String
    Public Property F_JR_Emp_Hdr() As String
        Get
            Return var_F_JR_Emp_Hdr
        End Get
        Set(ByVal value As String)
            var_F_JR_Emp_Hdr = value
        End Set
    End Property

    Private var_JR_Detail As String
    Public Property JR_Detail() As String
        Get
            Return var_JR_Detail
        End Get
        Set(ByVal value As String)
            var_JR_Detail = value
        End Set
    End Property

    Private var_Sub_Point As String
    Public Property Sub_Point() As String
        Get
            Return var_Sub_Point
        End Get
        Set(ByVal value As String)
            var_Sub_Point = value
        End Set
    End Property
    Private var_Sub_PointOfPoint As String
    Public Property Sub_PointOfPoint() As String
        Get
            Return var_Sub_PointOfPoint
        End Get
        Set(ByVal value As String)
            var_Sub_PointOfPoint = value
        End Set
    End Property

    Private var_PointNo As String
    Public Property PointNo() As String
        Get
            Return var_PointNo
        End Get
        Set(ByVal value As String)
            var_PointNo = value
        End Set
    End Property

    Private var_SubPointNo As String
    Public Property SubPointNo() As String
        Get
            Return var_SubPointNo
        End Get
        Set(ByVal value As String)
            var_SubPointNo = value
        End Set
    End Property

End Class
''Sushil----->
Public Class QueryResponse(Of T)

    Private var_respnse As Int64

    Public Property response() As Int64

        Get
            Return var_respnse
        End Get
        Set(ByVal value As Int64)
            var_respnse = value
        End Set
    End Property

    Private var_responseMsg As String
    Public Property responseMsg() As String
        Get
            Return var_responseMsg
        End Get
        Set(ByVal value As String)
            var_responseMsg = value
        End Set
    End Property

    Private var_responseSet As System.Data.DataSet

    Public Property responseSet() As System.Data.DataSet

        Get
            Return var_responseSet
        End Get
        Set(ByVal value As System.Data.DataSet
)
            var_responseSet = value
        End Set
    End Property

    Private var_responseTableList As List(Of System.Data.DataTable)
    Public Property responseTableList() As List(Of System.Data.DataTable)
        Get
            Return var_responseTableList
        End Get
        Set(ByVal value As List(Of System.Data.DataTable))
            var_responseTableList = value
        End Set
    End Property


    Private var_responseObjectList As List(Of T)
    Public Property responseObjectList() As List(Of T)
        Get
            Return var_responseObjectList
        End Get
        Set(ByVal value As List(Of T))
            var_responseObjectList = value
        End Set
    End Property


    Private var_responseObject As T
    Public Property responseObject() As T
        Get
            Return var_responseObject
        End Get
        Set(ByVal value As T)
            var_responseObject = value
        End Set
    End Property


    Private var_CheckID As Int32
    Public Property CheckID() As Int32
        Get
            Return var_CheckID
        End Get
        Set(ByVal value As Int32)
            var_CheckID = value
        End Set
    End Property


    Private var_slipNo As Int32
    Public Property slipNo() As Int32
        Get
            Return var_slipNo
        End Get
        Set(ByVal value As Int32)
            var_slipNo = value
        End Set
    End Property


    Private var_preStock As Double
    Public Property preStock() As Double
        Get
            Return var_preStock
        End Get
        Set(ByVal value As Double)
            var_preStock = value
        End Set
    End Property


    Private var_currentMivNo As Int64
    Public Property currentMivNo() As Int64
        Get
            Return var_currentMivNo
        End Get
        Set(ByVal value As Int64)
            var_currentMivNo = value
        End Set
    End Property


End Class

Public Class PRP_SearchwithPagination
    Private var_emp_cd As String
    Public Property emp_cd() As String
        Get
            Return var_emp_cd
        End Get
        Set(ByVal value As String)
            var_emp_cd = value
        End Set
    End Property
    Private var_PageIndex As Int64
    Public Property PageIndex() As Int64
        Get
            Return var_PageIndex
        End Get
        Set(ByVal value As Int64)
            var_PageIndex = value
        End Set
    End Property
    Private var_pageSize As Int64
    Public Property pageSize() As Int64
        Get
            Return var_pageSize
        End Get
        Set(ByVal value As Int64)
            var_pageSize = value
        End Set
    End Property
    Private var_sortDirection As String
    Public Property sortDirection() As String
        Get
            Return var_sortDirection
        End Get
        Set(ByVal value As String)
            var_sortDirection = value
        End Set
    End Property
    Private var_sortColumn As String
    Public Property sortColumn() As String
        Get
            Return var_sortColumn
        End Get
        Set(ByVal value As String)
            var_sortColumn = value
        End Set
    End Property




End Class



Public Class PRP_usersData
    Private var_Users As List(Of PRP_users)
    Public Property Users() As List(Of PRP_users)
        Get
            Return var_Users
        End Get
        Set(ByVal value As List(Of PRP_users))
            var_Users = value
        End Set
    End Property
    Private var_TotalRecords As Int64
    Public Property TotalRecords() As Int64
        Get
            Return var_TotalRecords
        End Get
        Set(ByVal value As Int64)
            var_TotalRecords = value
        End Set
    End Property
End Class

Public Class PRP_users
    Private var_TotalRecords As Int64
    Public Property TotalRecords() As Int64
        Get
            Return var_TotalRecords
        End Get
        Set(ByVal value As Int64)
            var_TotalRecords = value
        End Set
    End Property


    Private var_empcd As String
    Public Property empcd() As String
        Get
            Return var_empcd
        End Get
        Set(ByVal value As String)
            var_empcd = value
        End Set
    End Property


    Private var_empnm As String
    Public Property empnm() As String
        Get
            Return var_empnm
        End Get
        Set(ByVal value As String)
            var_empnm = value
        End Set
    End Property


    Private var_outres As Integer
    Public Property outres() As Integer
        Get
            Return var_outres
        End Get
        Set(ByVal value As Integer)
            var_outres = value
        End Set
    End Property



End Class

Public Class Prp_Breadcrumb
    Dim mp As MasterPage
    'Public obj As UserControl = DirectCast(mp.FindControl("


    Private var_menuHeader As String
    Public Property menuHeader() As String
        Get
            Return var_menuHeader
        End Get
        Set(ByVal value As String)
            var_menuHeader = value
        End Set
    End Property


    Private var_mainMenuLabel As String
    Public Property mainMenuLabel() As String
        Get
            Return var_mainMenuLabel
        End Get
        Set(ByVal value As String)
            var_mainMenuLabel = value
        End Set
    End Property


    Private var_menuLabel As String
    Public Property menuLabel() As String
        Get
            Return var_menuLabel
        End Get
        Set(ByVal value As String)
            var_menuLabel = value
        End Set
    End Property



End Class

Public Class PRP_JRMenu
    Inherits PRP_JRRole
    Private var_MenuId As Int32
    Public Property MenuId() As Int32
        Get
            Return var_MenuId
        End Get
        Set(ByVal value As Int32)
            var_MenuId = value
        End Set
    End Property

    Private var_Title As String
    Public Property Title() As String
        Get
            Return var_Title
        End Get
        Set(ByVal value As String)
            var_Title = value
        End Set
    End Property

    Private var_Url As String
    Public Property Url() As String
        Get
            Return var_Url
        End Get
        Set(ByVal value As String)
            var_Url = value
        End Set
    End Property

End Class

Public Class PRP_JRRole
    Private var_emp_cd As String
    Public Property emp_cd() As String
        Get
            Return var_emp_cd
        End Get
        Set(ByVal value As String)
            var_emp_cd = value
        End Set
    End Property

    Private var_emp_nm As String
    Public Property emp_nm() As String
        Get
            Return var_emp_nm
        End Get
        Set(ByVal value As String)
            var_emp_nm = value
        End Set
    End Property

    Private var_RoleId As Int32
    Public Property RoleId() As Int32
        Get
            Return var_RoleId
        End Get
        Set(ByVal value As Int32)
            var_RoleId = value
        End Set
    End Property

    Private VAR_Roles As String
    Public Property Roles() As String
        Get
            Return VAR_Roles
        End Get
        Set(ByVal value As String)
            VAR_Roles = value
        End Set
    End Property



End Class

Public Class PRP_JRInbox
    Private var_Id As Int64
    Public Property Id() As Int64
        Get
            Return var_Id
        End Get
        Set(ByVal value As Int64)
            var_Id = value
        End Set
    End Property

    Private var_emp_cd As String
    Public Property emp_cd() As String
        Get
            Return var_emp_cd
        End Get
        Set(ByVal value As String)
            var_emp_cd = value
        End Set
    End Property

    Private var_emp_nm As String
    Public Property emp_nm() As String
        Get
            Return var_emp_nm
        End Get
        Set(ByVal value As String)
            var_emp_nm = value
        End Set
    End Property

    Private var_Dept_Cd As Int64
    Public Property Dept_Cd() As Int64
        Get
            Return var_Dept_Cd
        End Get
        Set(ByVal value As Int64)
            var_Dept_Cd = value
        End Set
    End Property

    Private var_Dept_Nm As String
    Public Property Dept_Nm() As String
        Get
            Return var_Dept_Nm
        End Get
        Set(ByVal value As String)
            var_Dept_Nm = value
        End Set
    End Property

    Private var_Desig_Nm As String
    Public Property Desig_Nm() As String
        Get
            Return var_Desig_Nm
        End Get
        Set(ByVal value As String)
            var_Desig_Nm = value
        End Set
    End Property

    Private var_final_auth_cd_dept As String
    Public Property final_auth_cd_dept() As String
        Get
            Return var_final_auth_cd_dept
        End Get
        Set(ByVal value As String)
            var_final_auth_cd_dept = value
        End Set
    End Property

    Private var_final_auth_cd_hr As String
    Public Property final_auth_cd_hr() As String
        Get
            Return var_final_auth_cd_hr
        End Get
        Set(ByVal value As String)
            var_final_auth_cd_hr = value
        End Set
    End Property
End Class

Public Class PRP_JRAccess
    Private var_ID As Int64
    Public Property ID() As Int64
        Get
            Return var_ID
        End Get
        Set(ByVal value As Int64)
            var_ID = value
        End Set
    End Property
    Private var_Emp_cd As String
    Public Property Emp_cd() As String
        Get
            Return var_Emp_cd
        End Get
        Set(ByVal value As String)
            var_Emp_cd = value
        End Set
    End Property
    Private var_Emp_nm As String
    Public Property Emp_nm() As String
        Get
            Return var_Emp_nm
        End Get
        Set(ByVal value As String)
            var_Emp_nm = value
        End Set
    End Property
    Private var_Dept_cd As Int64
    Public Property Dept_cd() As Int64
        Get
            Return var_Dept_cd
        End Get
        Set(ByVal value As Int64)
            var_Dept_cd = value
        End Set
    End Property

    Private var_Dept_nm As String
    Public Property Dept_nm() As String
        Get
            Return var_Dept_nm
        End Get
        Set(ByVal value As String)
            var_Dept_nm = value
        End Set
    End Property
    Private var_locn_cd As Int64
    Public Property locn_cd() As Int64
        Get
            Return var_locn_cd
        End Get
        Set(ByVal value As Int64)
            var_locn_cd = value
        End Set
    End Property
    Private var_is_DTC As String
    Public Property is_DTC() As String
        Get
            Return var_is_DTC
        End Get
        Set(ByVal value As String)
            var_is_DTC = value
        End Set
    End Property
    Private var_desig_cd As Int64
    Public Property desig_cd() As Int64
        Get
            Return var_desig_cd
        End Get
        Set(ByVal value As Int64)
            var_desig_cd = value
        End Set
    End Property
    Private var_desig_nm As String
    Public Property desig_nm() As String
        Get
            Return var_desig_nm
        End Get
        Set(ByVal value As String)
            var_desig_nm = value
        End Set
    End Property
    Private var_catg_cd As Int64
    Public Property catg_cd() As Int64
        Get
            Return var_catg_cd
        End Get
        Set(ByVal value As Int64)
            var_catg_cd = value
        End Set
    End Property
    Private var_catg_nm As String
    Public Property catg_nm() As String
        Get
            Return var_catg_nm
        End Get
        Set(ByVal value As String)
            var_catg_nm = value
        End Set
    End Property




End Class


Public Class PRP_JR_Audit_Trails
    Private var_AT_Id As Int64
    Public Property AT_Id() As Int64
        Get
            Return var_AT_Id
        End Get
        Set(ByVal value As Int64)
            var_AT_Id = value
        End Set
    End Property
    Private var_AT_Reason As String
    Public Property AT_Reason() As String
        Get
            Return var_AT_Reason
        End Get
        Set(ByVal value As String)
            var_AT_Reason = value
        End Set
    End Property
    Private var_AT_Activity As String
    Public Property AT_Activity() As String
        Get
            Return var_AT_Activity
        End Get
        Set(ByVal value As String)
            var_AT_Activity = value
        End Set
    End Property
    Private var_AT_UpdatedBy As String
    Public Property AT_UpdatedBy() As String
        Get
            Return var_AT_UpdatedBy
        End Get
        Set(ByVal value As String)
            var_AT_UpdatedBy = value
        End Set
    End Property
    Private var_AT_UpdatedOn As String
    Public Property AT_UpdatedOn() As String
        Get
            Return var_AT_UpdatedOn
        End Get
        Set(ByVal value As String)
            var_AT_UpdatedOn = value
        End Set
    End Property


End Class

Public Class PRP_JR_Dashboard
    Private var_JR_count As Int64
    Public Property JR_count() As Int64
        Get
            Return var_JR_count
        End Get
        Set(ByVal value As Int64)
            var_JR_count = value
        End Set
    End Property
    Private var_tabname As String
    Public Property tabname() As String
        Get
            Return var_tabname
        End Get
        Set(ByVal value As String)
            var_tabname = value
        End Set
    End Property
    Private var_url As String
    Public Property url() As String
        Get
            Return var_url
        End Get
        Set(ByVal value As String)
            var_url = value
        End Set
    End Property
    Private var_color As String
    Public Property color() As String
        Get
            Return var_color
        End Get
        Set(ByVal value As String)
            var_color = value
        End Set
    End Property
End Class

Public Class PRP_JRLogin
    Private var_comp_cd As Int32
    Public Property comp_cd() As String
        Get
            Return var_comp_cd
        End Get
        Set(ByVal value As String)
            var_comp_cd = value
        End Set
    End Property

    Private var_locn_cd As Int32
    Public Property locn_cd() As Int32
        Get
            Return var_locn_cd
        End Get
        Set(ByVal value As Int32)
            var_locn_cd = value
        End Set
    End Property

    Private var_emp_cd As String
    Public Property emp_cd() As String
        Get
            Return var_emp_cd
        End Get
        Set(ByVal value As String)
            var_emp_cd = value
        End Set
    End Property
    Private var_dept_cd As Int32
    Public Property dept_cd() As Int32
        Get
            Return var_dept_cd
        End Get
        Set(ByVal value As Int32)
            var_dept_cd = value
        End Set
    End Property

    Private var_present As Int32
    Public Property present() As Int32
        Get
            Return var_present
        End Get
        Set(ByVal value As Int32)
            var_present = value
        End Set
    End Property
    Private var_userpass As String
    Public Property userpass() As String
        Get
            Return var_userpass
        End Get
        Set(ByVal value As String)
            var_userpass = value
        End Set
    End Property
    Private var_dec_userpass As String
    Public Property dec_userpass() As String
        Get
            Return EncryptDecrypt.Decrypt(var_dec_userpass)
        End Get
        Set(ByVal value As String)
            var_dec_userpass = value
        End Set
    End Property
    Private var_enc_userpass As String
    Public Property enc_userpass() As String
        Get
            Return EncryptDecrypt.Encrypt(var_enc_userpass)
        End Get
        Set(ByVal value As String)
            var_enc_userpass = value
        End Set
    End Property
    Private var_start_date As String
    Public Property start_date() As String
        Get
            Return var_start_date
        End Get
        Set(ByVal value As String)
            var_start_date = value
        End Set
    End Property
    Private var_end_date As String
    Public Property end_date() As String
        Get
            Return var_end_date
        End Get
        Set(ByVal value As String)
            var_end_date = value
        End Set
    End Property
End Class

Public Class PRP_JR_CheckLoginValidity
    Private var_ExpiryDays As Int64
    Public Property ExpiryDays() As Int64
        Get
            Return var_ExpiryDays
        End Get
        Set(ByVal value As Int64)
            var_ExpiryDays = value
        End Set
    End Property
    Private var_Message As String
    Public Property Message() As String
        Get
            Return var_Message
        End Get
        Set(ByVal value As String)
            var_Message = value
        End Set
    End Property


End Class



Public Class PRP_JR_ClientMaster
    Private var_ClientKeyId As Int64
    Public Property ClientKeyId() As Int64
        Get
            Return var_ClientKeyId
        End Get
        Set(ByVal value As Int64)
            var_ClientKeyId = value
        End Set
    End Property
    Private var_ClientID As String
    Public Property ClientID() As String
        Get
            Return var_ClientID
        End Get
        Set(ByVal value As String)
            var_ClientID = value
        End Set
    End Property
    Private var_ClientSecret As String
    Public Property ClientSecret() As String
        Get
            Return var_ClientSecret
        End Get
        Set(ByVal value As String)
            var_ClientSecret = value
        End Set
    End Property
    Private var_ClientName As String
    Public Property ClientName() As String
        Get
            Return var_ClientName
        End Get
        Set(ByVal value As String)
            var_ClientName = value
        End Set
    End Property
    Private var_Active As Boolean
    Public Property Active() As Boolean
        Get
            Return var_Active
        End Get
        Set(ByVal value As Boolean)
            var_Active = value
        End Set
    End Property
    Private var_RefreshTokenLifeTime As Int64
    Public Property RefreshTokenLifeTime() As Int64
        Get
            Return var_RefreshTokenLifeTime
        End Get
        Set(ByVal value As Int64)
            var_RefreshTokenLifeTime = value
        End Set
    End Property
    Private var_AllowedOrigin As String
    Public Property AllowedOrigin() As String
        Get
            Return var_AllowedOrigin
        End Get
        Set(ByVal value As String)
            var_AllowedOrigin = value
        End Set
    End Property
End Class

Public Class PRP_JR_RefreshToken
    Private var_ID As String
    Public Property ID() As String
        Get
            Return var_ID
        End Get
        Set(ByVal value As String)
            var_ID = value
        End Set
    End Property
    Private var_UserName As String
    Public Property UserName() As String
        Get
            Return var_UserName
        End Get
        Set(ByVal value As String)
            var_UserName = value
        End Set
    End Property
    Private var_ClientID As String
    Public Property ClientID() As String
        Get
            Return var_ClientID
        End Get
        Set(ByVal value As String)
            var_ClientID = value
        End Set
    End Property
    Private var_IssuedTime As String
    Public Property IssuedTime() As String
        Get
            Return var_IssuedTime
        End Get
        Set(ByVal value As String)
            var_IssuedTime = value
        End Set
    End Property
    Private var_ExpiredTime As String
    Public Property ExpiredTime() As String
        Get
            Return var_ExpiredTime
        End Get
        Set(ByVal value As String)
            var_ExpiredTime = value
        End Set
    End Property
    Private var_ProtectedTicket As String
    Public Property ProtectedTicket() As String
        Get
            Return var_ProtectedTicket
        End Get
        Set(ByVal value As String)
            var_ProtectedTicket = value
        End Set
    End Property


End Class

Public Class PRP_JRAccessRights
    Private var_accessRights As String
    Public Property accessRights() As String
        Get
            Return var_accessRights
        End Get
        Set(ByVal value As String)
            var_accessRights = value
        End Set
    End Property

    Private var_isAdmin As Boolean
    Public Property isAdmin() As Boolean
        Get
            Return var_isAdmin
        End Get
        Set(ByVal value As Boolean)
            var_isAdmin = value
        End Set
    End Property

    Private var_isHR As Boolean
    Public Property isHR() As Boolean
        Get
            Return var_isHR
        End Get
        Set(ByVal value As Boolean)
            var_isHR = value
        End Set
    End Property
    Private var_isFinalAuth As Boolean
    Public Property isFinalAuth() As Boolean
        Get
            Return var_isFinalAuth
        End Get
        Set(ByVal value As Boolean)
            var_isFinalAuth = value
        End Set
    End Property
    Private var_isFirstAuth As Boolean
    Public Property isFirstAuth() As Boolean
        Get
            Return var_isFirstAuth
        End Get
        Set(ByVal value As Boolean)
            var_isFirstAuth = value
        End Set
    End Property
    Private var_isUser As Boolean
    Public Property isUser() As Boolean
        Get
            Return var_isUser
        End Get
        Set(ByVal value As Boolean)
            var_isUser = value
        End Set
    End Property



End Class

#End Region
