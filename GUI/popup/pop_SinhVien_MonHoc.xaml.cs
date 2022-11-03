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
    /// Interaction logic for pop_SinhVien_MonHoc.xaml
    /// </summary>
    public partial class pop_SinhVien_MonHoc : Window
    {
        public pop_SinhVien_MonHoc()
        {
            InitializeComponent();
        }

        string _lop = frm_NhapDiem._idlophoc.ToString();
        string _monhoc = frm_NhapDiem._idmonhoc.ToString();

        DataTable dt;

        void Init_Lop()
        {
            dt = (new DAO.Database()).Select("SELECT * FROM GETLIST_TKM WHERE MALOP = '" + _lop.ToString() + "'");

            DataColumn _check = new DataColumn();
            _check.ColumnName = "check";
            _check.DataType = typeof(bool);
            _check.DefaultValue = false;
            dt.Columns.Add(_check);

            gctrl_SinhVienMonHoc.ItemsSource = dt;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txt_lop.Text = _lop.ToString();
            txt_monhoc.Text = _monhoc.ToString();
        }
    }
}
