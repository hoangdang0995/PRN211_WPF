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
    /// Interaction logic for pop_HocHamHocVi.xaml
    /// </summary>
    public partial class pop_HocHamHocVi : Window
    {
        Database da = new Database();
        string type = "";
        string id = "";

        private string New_Id()
        {
            DataTable dt = (new Database()).Select("SELECT MAX(MAHOCVIHOCHAM) FROM HOCVIHOCHAM");
            if (dt.Rows.Count > 0)
            {
                string str = dt.Rows[0][0].ToString();
                str = str.Substring(3);
                return "HHV" + (int.Parse(str) + 1).ToString("000");
            }
            else
                return "HHV001";
        }

        public pop_HocHamHocVi()
        {
            InitializeComponent();
            type = "add";
        }

        public pop_HocHamHocVi(string id)
        {
            InitializeComponent();
            type = "edit";
            this.id = id;
        }

        void Init_edit()
        {
            DataTable dt = (new DAO.Database()).Select("select * from HOCVIHOCHAM where MAHOCVIHOCHAM = '" + id + "'");
            if (dt.Rows.Count > 0)
            {
                txt_mahochamhocvi.Text = dt.Rows[0]["MAHOCVIHOCHAM"].ToString();
                txt_mahochamhocvi.IsEnabled = false;
                txt_tenhochamhocvi.Text = dt.Rows[0]["TENHOCVIHOCHAM"].ToString();
            }
            txt_tenhochamhocvi.Focus();
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
            txt_mahochamhocvi.Text = New_Id();
            txt_mahochamhocvi.IsEnabled = false;
            txt_tenhochamhocvi.Text = "";
            txt_tenhochamhocvi.Focus();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Init();
        }

        private void cmd_DongY_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (type == "add")
                {
                    da.Query("INSERT INTO HOCVIHOCHAM (MAHOCVIHOCHAM, TENHOCVIHOCHAM) VALUES ('" + txt_mahochamhocvi.Text + "','" + BUS.Bus.convertitle(txt_tenhochamhocvi.Text) + "')");
                }
                else if (type == "edit")
                {
                    DataTable dt = (new DAO.Database()).Select("select * from HOCVIHOCHAM where MAHOCVIHOCHAM = '" + id + "'");
                    if (dt.Rows.Count > 0)
                    {
                        da.Query("UPDATE HOCVIHOCHAM SET MAHOCVIHOCHAM = '" + txt_mahochamhocvi.Text + "', TENHOCVIHOCHAM = '" + BUS.Bus.convertitle(txt_tenhochamhocvi.Text) + "' WHERE MAHOCVIHOCHAM = '" + dt.Rows[0]["MAHOCVIHOCHAM"].ToString() + "'");
                    }
                }
                this.DialogResult = true;
                Close();
            }
            catch
            {
                MessageBox.Show("Thông tin nhập chưa chính xác, xin vui lòng kiểm tra lại!\nChú ý: Tên học hàm - học vị không được trùng!");
            }
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
