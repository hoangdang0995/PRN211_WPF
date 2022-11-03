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
    /// Interaction logic for pop_TonGiao.xaml
    /// </summary>
    public partial class pop_TonGiao : Window
    {
        Database da = new Database();
        string type = "";
        string id = "";

        public pop_TonGiao()
        {
            InitializeComponent();
            type = "add";
        }

        public pop_TonGiao(string id)
        {
            InitializeComponent();
            type = "edit";
            this.id = id;
        }

        private string New_Id()
        {
            DataTable dt = (new Database()).Select("SELECT MAX(MATONGIAO) FROM TONGIAO");
            if (dt.Rows.Count > 0)
            {
                string str = dt.Rows[0][0].ToString();
                str = str.Substring(2);
                return "TG" + (int.Parse(str) + 1).ToString("0000");
            }
            else
                return "TG0001";
        }

        void Init_add()
        {
            txt_matongiao.Text = New_Id();
            txt_matongiao.IsEnabled = false;
            txt_tentongiao.Text = "";
            txt_tentongiao.Focus();
        }

        void Init_edit()
        {
            DataTable dt = (new DAO.Database()).Select("SELECT * FROM TONGIAO WHERE MATONGIAO='" + id + "'");
            if (dt.Rows.Count > 0)
            {
                txt_matongiao.Text = dt.Rows[0]["MATONGIAO"].ToString();
                txt_matongiao.IsEnabled = false;
                txt_tentongiao.Text = dt.Rows[0]["TENTONGIAO"].ToString();
            }
            txt_tentongiao.Focus();
        }

        void Init()
        {
            if (type == "add")
                Init_add();
            else if (type == "edit")
                Init_edit();                
        }

        private void cmd_DongY_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (type == "add")
                {
                    da.Query("INSERT INTO TONGIAO (MATONGIAO, TENTONGIAO) VALUES ('" + txt_matongiao.Text + "','" + BUS.Bus.convertitle(txt_tentongiao.Text) + "')");
                }
                else if (type == "edit")
                {
                    DataTable dt = (new DAO.Database()).Select("select * from TONGIAO where MATONGIAO = '" + id + "'");
                    if (dt.Rows.Count > 0)
                    {
                        da.Query("UPDATE TONGIAO SET MATONGIAO = '" + txt_matongiao.Text + "', TENTONGIAO = '" + BUS.Bus.convertitle(txt_tentongiao.Text) + "' WHERE MATONGIAO = '" + dt.Rows[0]["MATONGIAO"].ToString() + "'");
                    }
                }

                this.DialogResult = true;
                Close();
            }
            catch
            {
                MessageBox.Show("Thông tin nhập chưa chính xác, xin vui lòng kiểm tra lại!\nChú ý: Tên tôn giáo không được trùng!");
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
