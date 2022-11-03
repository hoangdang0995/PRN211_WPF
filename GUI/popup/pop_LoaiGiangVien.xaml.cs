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
using DAO;
using System.Data;

namespace GUI.popup
{
    /// <summary>
    /// Interaction logic for pop_LoaiGiangVien.xaml
    /// </summary>
    public partial class pop_LoaiGiangVien : Window
    {
        Database da = new Database();
        string type = "";
        string id = "";

        private string New_Id()
        {
            DataTable dt = (new Database()).Select("SELECT MAX(MALOAIGV) FROM LOAIGIANGVIEN");
            if (dt.Rows.Count > 0)
            {
                string str = dt.Rows[0][0].ToString();
                str = str.Substring(3);
                return "LGV" + (int.Parse(str) + 1).ToString("000");
            }
            else
                return "LGV001";
        }

        void Init()
        {
            if (type == "add")
                Init_add();
            else if (type == "edit")
                Init_edit();
        }

        void Init_add()
        {
            txt_maloaigv.Text = New_Id();
            txt_maloaigv.IsEnabled = false;
            txt_tenloaigv.Text = "";
            txt_tenloaigv.Focus();
        }

        void Init_edit()
        {
            DataTable dt = (new DAO.Database()).Select("select * from LOAIGIANGVIEN where MALOAIGV = '" + id + "'");
            if (dt.Rows.Count > 0)
            {
                txt_maloaigv.Text = dt.Rows[0]["MALOAIGV"].ToString();
                txt_maloaigv.IsEnabled = true;
                txt_tenloaigv.Text = dt.Rows[0]["TENLOAIGV"].ToString();
            }
            txt_tenloaigv.Focus();
        }

        public pop_LoaiGiangVien()
        {
            InitializeComponent();
            type = "add";
        }

        public pop_LoaiGiangVien(string id)
        {
            InitializeComponent();
            type = "edit";
            this.id = id;
        }

        private void cmd_DongY_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (type == "add")
                {
                    da.Query("INSERT INTO LOAIGIANGVIEN (MALOAIGV, TENLOAIGV) VALUES ('" + txt_maloaigv.Text + "','" + BUS.Bus.convertitle(txt_tenloaigv.Text) + "')");
                }
                else if (type == "edit")
                {
                    DataTable dt = (new DAO.Database()).Select("select * from LOAIGIANGVIEN where MALOAIGV = '" + id + "'");
                    if (dt.Rows.Count > 0)
                    {
                        da.Query("UPDATE LOAIGIANGVIEN SET MALOAIGV = '" + txt_maloaigv.Text + "', TENLOAIGV = '" + BUS.Bus.convertitle(txt_tenloaigv.Text) + "' WHERE MALOAIGV = '" + dt.Rows[0]["MALOAIGV"].ToString() + "'");
                    }
                }
                this.DialogResult = true;
                Close();
            }
            catch
            {
                MessageBox.Show("Thông tin nhập chưa chính xác, xin vui lòng kiểm tra lại!\nChú ý: Tên loại người dùng không được trùng!");
            }
        }      

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Init();
        }

        private void cmd_Exit_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            Close();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                this.Close();
            if (e.Key == Key.Enter)
                cmd_DongY_Click(sender, e);
        }
    }
}
