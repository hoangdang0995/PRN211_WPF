using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data;
using DAO;

namespace GUI.popup
{
    /// <summary>
    /// Interaction logic for pop_SinhVien.xaml
    /// </summary>
    public partial class pop_SinhVien : Window
    {
        Database da = new Database();
        string type = "";
        string id = "";

        private string New_Id()
        {
            DataTable dt = (new Database()).Select("SELECT MAX(MASINHVIEN) FROM SINHVIEN");
            if (dt.Rows.Count > 0)
            {
                string str = dt.Rows[0][0].ToString();
                str = str.Substring(2);
                return "DE" + (int.Parse(str) + 1).ToString("000000");
            }
            else
                return "DE00000001";
        }

        public pop_SinhVien()
        {
            InitializeComponent();
            type = "add";
        }

        public pop_SinhVien(string id)
        {
            InitializeComponent();
            type = "edit";
            this.id = id;
        }

        void Init_add()
        {
            txt_masosinhvien.Text = New_Id();
            txt_masosinhvien.IsEnabled = false;
            txt_tensinhvien.Text = "";
            rdb_gtNam.IsChecked = true;
            txt_noisinh.Text = "";
            txt_hotencha.Text = "";
            txt_hotenme.Text = "";
            txt_sodienthoai.Text = "";
            txt_email.Text = "";
            txt_tensinhvien.Focus();
        }

        void Init_edit()
        {
            string sql = "SELECT MASINHVIEN,HOTENSINHVIEN,GIOITINH,NGAYSINH,NOISINH,HOTENCHA,HOTENME,DIENTHOAI,EMAIL FROM SINHVIEN WHERE MASINHVIEN = '" + id + "'";
            DataTable dt = (new DAO.Database()).Select(sql);
            if (dt.Rows.Count > 0)
            {
                txt_masosinhvien.Text = dt.Rows[0]["MASINHVIEN"].ToString();
                txt_masosinhvien.IsEnabled = false;
                txt_tensinhvien.Text = dt.Rows[0]["HOTENSINHVIEN"].ToString();
                rdb_gtNam.IsChecked = true;
                if (dt.Rows[0]["GIOITINH"].ToString() == "Nữ")
                    rdb_gtNu.IsChecked = true;
                txt_noisinh.Text = dt.Rows[0]["NOISINH"].ToString();
                string[] ngaysinh = dt.Rows[0]["NGAYSINH"].ToString().Split(new char[]{'/',' '});
                dtp_ngaysinh.SelectedDate = new DateTime(int.Parse(ngaysinh[2]),int.Parse(ngaysinh[1]),int.Parse(ngaysinh[0])); 
                txt_hotencha.Text = dt.Rows[0]["HOTENCHA"].ToString();
                txt_hotenme.Text = dt.Rows[0]["HOTENME"].ToString();
                txt_sodienthoai.Text = dt.Rows[0]["DIENTHOAI"].ToString();
                txt_email.Text = dt.Rows[0]["EMAIL"].ToString();
            }
            txt_tensinhvien.Focus();
        }

        void Init()
        {
            if (type == "add")
                Init_add();
            else if (type == "edit")
                Init_edit();
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Init();
        }

        private void cmd_DongY_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string _ngaythangnam = dtp_ngaysinh.SelectedDate.Value.ToString("dd-MMM-yyyy");
                string _Gioitinh = "Nam";

                if (rdb_gtNu.IsChecked == true)
                    _Gioitinh = "Nữ";
                if (type == "add")
                {
                    string sql = "INSERT INTO SINHVIEN VALUES(N'" + txt_masosinhvien.Text + "',N'" + txt_tensinhvien.Text + "',N'" + _Gioitinh + "','" + _ngaythangnam + "',N'" + txt_noisinh.Text + "',N'" + txt_hotencha.Text + "',N'" + txt_hotenme.Text + "','" + txt_sodienthoai.Text + "','" + txt_email.Text + "')";
                    da.Query(sql);
                }
                else if (type == "edit")
                {
                    string sql = "UPDATE SINHVIEN SET HOTENSINHVIEN = N'" + txt_tensinhvien.Text + "',GIOITINH=N'" + _Gioitinh + "',NGAYSINH='" + _ngaythangnam + "',NOISINH=N'" + txt_noisinh.Text + "',HOTENCHA=N'" + txt_hotencha.Text + "',HOTENME=N'" + txt_hotenme.Text + "',DIENTHOAI='" + txt_sodienthoai.Text + "',EMAIL='" + txt_email.Text + "' WHERE MASINHVIEN = '" + txt_masosinhvien.Text + "'";
                    da.Query(sql);
                }
                this.DialogResult = true;
                Close();
            }
            catch
            {
                MessageBox.Show("Thông tin nhập chưa chính xác, xin vui lòng kiểm tra lại!\nChú ý: Địa chỉ e-mail không được trùng!");
            }
        }

        private void cmd_Exit_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            Close();
        }

        private void txt_sodienthoai_TextChanged(object sender, TextChangedEventArgs e)
        {
            double tam;
            if (double.TryParse(txt_sodienthoai.Text, out tam))
                txt_sodienthoai.Text = txt_sodienthoai.Text;
            else
                txt_sodienthoai.Text = "";
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                this.Close();
        }
    }
}
