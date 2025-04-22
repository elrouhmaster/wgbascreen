
Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.Threading
Public Class Form1
   Public conn As New SqlClient.SqlConnection()
    Public cmd As New SqlClient.SqlCommand   
    Public server_ip As String = "."
    Public db_name As String = "wgba"
    Public db_user As String = "sa"
    Public db_pass As String = "Sa258456"
    'Dim ww As Int16=0
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        CenterPictures()

         Try
            'Dim msar As String = Application.StartupPath & "\devexpress.itil.dll" ' Application.StartupPath & "\devexpresss.dll"
            'Dim str As String = My.Computer.FileSystem.ReadAllText(msar)
            'Dim fld() As String = str.Split(",")
            'Dim mm As New windowsdll2.encrypt
            'server_ip = mm.deencrypt1(fld(0))
            'db_pass = mm.deencrypt1(fld(1))
            'Dim locall = 0
            'If fld.Length > 2 Then
            '    locall = fld(2)
            'End If

            'If locall = 1 Then
              
            '    conn = New SqlClient.SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='" & server_ip & "\monjz_db.mdf';Integrated Security=True")
              
            'Else
                conn = New SqlClient.SqlConnection("Server=" & server_ip & ";Database=" & db_name & ";User Id=" & db_user & ";Password='" & db_pass & "';MultipleActiveResultSets=True")
            'End If
            If conn.State = ConnectionState.Closed Then conn.Open()
            cmd.Connection = conn
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub Form1_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        CenterPictures()
    End Sub
    Private Sub CenterPictures()
        Dim spacing As Integer = 10
        ' Total available width minus spacing
        Dim totalSpacing As Integer = spacing * 3
        Dim availableWidth As Integer = Panel1.Width - totalSpacing
        ' Width per picture
        Dim picWidth As Integer = availableWidth \ 4
        Dim picHeight As Integer = Panel1.Height ' Use full panel height
        ' Y position to vertically center (if height is smaller than panel)
        Dim posY As Integer = (Panel1.Height - picHeight) \ 2
        ' X positions for each PictureBox
        Dim startX As Integer = (Panel1.Width - ((picWidth * 4) + totalSpacing)) \ 2
        GroupBox1.SetBounds(startX, posY, picWidth, picHeight)
        GroupBox2.SetBounds(startX + (picWidth + spacing) * 1, posY, picWidth, picHeight)
        GroupBox3.SetBounds(startX + (picWidth + spacing) * 2, posY, picWidth, picHeight)
        GroupBox4.SetBounds(startX + (picWidth + spacing) * 3, posY, picWidth, picHeight)

        TextBox6.Width =Width 
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        'اظهار تاريخ التوقيع
        'عدم اظهار التاريخ من اجوال ابليكشن
        Dim str As String = "select  top 2  e.empname as ' ' from tlbatt t,empolyees e where e.empno=t.empno and t.wgbano=1  order by t.id desc "
        Dim dataSet11 As New DataSet()
        Dim Adapter_main As New SqlDataAdapter(str, conn)
        Adapter_main.Fill(dataSet11, "search")
        DataGridView1.DataSource = dataSet11.Tables("search")
          DataGridView1.Columns(0).AutoSizeMode=DataGridViewAutoSizeColumnMode.Fill
         DataGridView1.Columns(0).DefaultCellStyle.Alignment=DataGridViewContentAlignment.MiddleCenter
        '''''''''''''''''''''''''''''''''''
        str  = "select  top 2  e.empname as ' ' from tlbatt t,empolyees e where e.empno=t.empno and t.wgbano=2  order by t.id desc "
         dataSet11 = New DataSet()
         Adapter_main=New SqlDataAdapter(str, conn)
        Adapter_main.Fill(dataSet11, "search")
        DataGridView2.DataSource = dataSet11.Tables("search")
        DataGridView2.Columns(0).AutoSizeMode=DataGridViewAutoSizeColumnMode.Fill
         DataGridView2.Columns(0).DefaultCellStyle.Alignment=DataGridViewContentAlignment.MiddleCenter
        
         ''''''''''''''''''''''''''''''''''''''''
         str  = "select  top 2  e.empname  as ' ' from tlbatt t,empolyees e where e.empno=t.empno and t.wgbano=3  order by t.id desc "
         dataSet11 = New DataSet()
         Adapter_main=New SqlDataAdapter(str, conn)
        Adapter_main.Fill(dataSet11, "search")
        DataGridView3.DataSource = dataSet11.Tables("search")
          DataGridView3.Columns(0).AutoSizeMode=DataGridViewAutoSizeColumnMode.Fill
        DataGridView3.Columns(0).DefaultCellStyle.Alignment=DataGridViewContentAlignment.MiddleCenter
         '''''''''''''''''''''''''''''''''''
         str  = "select  top 2  e.empname as ' ' from tlbatt t,empolyees e where e.empno=t.empno and t.wgbano=4  order by t.id desc "
         dataSet11 = New DataSet()
         Adapter_main=New SqlDataAdapter(str, conn)
        Adapter_main.Fill(dataSet11, "search")
        DataGridView4.DataSource = dataSet11.Tables("search")
          DataGridView4.Columns(0).AutoSizeMode=DataGridViewAutoSizeColumnMode.Fill
         DataGridView4.Columns(0).DefaultCellStyle.Alignment=DataGridViewContentAlignment.MiddleCenter

        'ww +=1
        'RichTextBox1.Text=ww
    End Sub
End Class
