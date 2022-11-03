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

namespace GUI
{
    /// <summary>
    /// Interaction logic for frm_DanToc.xaml
    /// </summary>
    public partial class frm_DanToc : UserControl
    {
        private void role()
        {
            DataTable dtpquyen = frm_HeThongQuanLy.dtquyen;
            if (frm_HeThongQuanLy.timtenformtrongdt("DANTOC", dtpquyen) > -1)
            {
                cmdadd.IsEnabled = false;
                if (dtpquyen.Rows[frm_HeThongQuanLy.timtenformtrongdt("DANTOC", dtpquyen)]["THEM"].ToString().ToLower() == "true")
                    cmdadd.IsEnabled = true;
                cmdedit.IsEnabled = false;
                if (dtpquyen.Rows[frm_HeThongQuanLy.timtenformtrongdt("DANTOC", dtpquyen)]["SUA"].ToString().ToLower() == "true")
                    cmdedit.IsEnabled = true;
                cmddelete.IsEnabled = false;
                if (dtpquyen.Rows[frm_HeThongQuanLy.timtenformtrongdt("DANTOC", dtpquyen)]["XOA"].ToString().ToLower() == "true")
                    cmddelete.IsEnabled = true;
            }
        }

        public frm_DanToc()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadFormDanToc();
            role();
        }
        void LoadFormDanToc()
        {
            Init();
        }

        void Init()
        {
            DataTable dt = (new DAO.Database()).Select("SELECT * FROM DANTOC");
            gctrl_DanToc.ItemsSource = dt;
        }

        private void cmdadd_Click(object sender, RoutedEventArgs e)
        {
            popup.pop_DanhToc _dantoc = new popup.pop_DanhToc();
            var res = _dantoc.ShowDialog();
            if (res == true)
            {
                Init();
            }
        }

        private void cmdedit_Click(object sender, RoutedEventArgs e)
        {
            popup.pop_DanhToc _dantoc = new popup.pop_DanhToc(gctrl_DanToc.GetFocusedRowCellValue("MADANTOC").ToString());
            var res = _dantoc.ShowDialog();
            if (res == true)
            {
                Init();
            }
        }

        private void cmddelete_Click(object sender, RoutedEventArgs e)
        {
            var res = MessageBox.Show("Bạn có muốn xoá tên dân tộc '" + gctrl_DanToc.GetFocusedRowCellValue("TENDANTOC") + "' có mã là '" + gctrl_DanToc.GetFocusedRowCellValue("MADANTOC").ToString() + "' này không? \nNhấn YES để xoá - Nhấn NO để thoát.", "Thông báo", MessageBoxButton.YesNo);
            if (res == MessageBoxResult.Yes)
            {
                (new DAO.Database()).Query("DELETE FROM DANTOC WHERE MADANTOC = '" + gctrl_DanToc.GetFocusedRowCellValue("MADANTOC").ToString() + "'");
                Init();
            }
        }

        private void cmdimport_Click(object sender, RoutedEventArgs e)
        {
            //popup.Import imp = new popup.Import();
            //var res = imp.ShowDialog();
            //if (res == true)
            //{
            //    DataTable dttemp = imp.datareturn;
            //    for (int i = 0; i < dttemp.Rows.Count; i++)
            //    {
            //        string stri = "SELECT MADANTOC, TENDANTOC FROM DANTOC";
            //        DataTable dtmp = (new DAO.Database()).Select(stri);
            //        if (dtmp.Rows.Count > 0)
            //        {
            //            if (imp.tuychinh == "capnhat")
            //            {
            //                string sql = "UPDATE DANTOC SET TENDANTOC = '" + dttemp.Rows[i]["TENDANTOC"] + "' WHERE MADANTOC = '" + dttemp.Rows[i]["MADANTOC"] + "'";
            //                (new DAO.Database()).Query(sql);
            //            }
            //        }
            //        else
            //        {
            //            string sql1 = "INSERT INTO DANTOC VALUES('" + dttemp.Rows[i]["MADANTOC"] + "','" + dttemp.Rows[i]["TENDANTOC"] + "')";
            //            (new DAO.Database()).Query(sql1);
            //        }
            //    }
            //    Init();
            //    MessageBox.Show("Import thành công!");
            //}
        }

        private void cmdexport_Click(object sender, RoutedEventArgs e)
        {
            DataTable dtie = (new DAO.Database()).Select("SELECT MADANTOC AS MÃ_DÂN_TỘC, TENDANTOC AS TÊN_DÂN_TỘC FROM DANTOC");
            BUS.Bus.Export(dtie, "DanToc");
        }
    }
}
