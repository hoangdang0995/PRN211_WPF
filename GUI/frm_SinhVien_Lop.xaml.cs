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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using DAO;

namespace GUI
{
    /// <summary>
    /// Interaction logic for frm_SinhVien_Lop.xaml
    /// </summary>
    public partial class frm_SinhVien_Lop : UserControl
    {
        Database da = new Database();
        string id = "";

        private string New_Id()
        {
            DataTable dt = (new Database()).Select("SELECT MAX(MAKETQUA) as ma FROM KETQUA");
            if (dt.Rows.Count > 0)
            {
                string str = dt.Rows[0][0].ToString();
                if (str == "")
                    str = "SL00000000";
                str = str.Substring(2);
                return "SL" + (int.Parse(str) + 1).ToString("00000000");
            }
            else
                return "SL00000001";
        }

        private void role()
        {
            DataTable dtpquyen = frm_HeThongQuanLy.dtquyen;
            if (frm_HeThongQuanLy.timtenformtrongdt("KETQUA", dtpquyen) > -1)
            {
                cmd_them.IsEnabled = false;
                if (dtpquyen.Rows[frm_HeThongQuanLy.timtenformtrongdt("KETQUA", dtpquyen)]["THEM"].ToString().ToLower() == "true")
                    cmd_them.IsEnabled = true;
                cmd_Xoa.IsEnabled = false;
                if (dtpquyen.Rows[frm_HeThongQuanLy.timtenformtrongdt("KETQUA", dtpquyen)]["XOA"].ToString().ToLower() == "true")
                    cmd_Xoa.IsEnabled = true;
            }
        }

        void Load_Lop()
        {
            DataTable dt = (new DAO.Database()).Select("SELECT MALOP, TENLOP FROM LOP");
            cbx_DanhSachLop.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                TextBlock _txttemp = new TextBlock();
                _txttemp.Tag = dt.Rows[i]["MALOP"].ToString();
                _txttemp.Text = dt.Rows[i]["TENLOP"].ToString();
                cbx_DanhSachLop.Items.Add(_txttemp);
            }
            if (dt.Rows.Count != 0)
                cbx_DanhSachLop.SelectedIndex = 0;
        }

        public frm_SinhVien_Lop()
        {
            InitializeComponent();
        }

        DataTable dtlop;

        void Init_Lop()
        {
            dtlop = (new DAO.Database()).Select("SELECT MAKETQUA,KETQUA.MASINHVIEN, hoTENSINHVIEN, NGAYSINH FROM KETQUA, SINHVIEN, LOP WHERE KETQUA.MASINHVIEN=SINHVIEN.MASINHVIEN AND KETQUA.MALOP=LOP.MALOP AND LOP.MALOP= '" + ((TextBlock)cbx_DanhSachLop.SelectedItem).Tag.ToString() + "'");

            DataColumn _check = new DataColumn();
            _check.ColumnName = "check";
            _check.DataType = typeof(bool);
            _check.DefaultValue = false;
            dtlop.Columns.Add(_check);

            gctrl_DanhSachLop.ItemsSource = dtlop;
        }

        DataTable dtsv;

        void Init_SinhVien()
        {
            dtsv = (new DAO.Database()).Select(@"SELECT * FROM SINHVIEN sv,KETQUA kq
                                                        Where sv.MASINHVIEN= kq.MASINHVIEN (+) and MAKETQUA  IS NULL" );

            DataColumn _check = new DataColumn();
            _check.ColumnName = "check";
            _check.DataType = typeof(bool);
            _check.DefaultValue = false;
            dtsv.Columns.Add(_check);

            gctrl_DanhSachSinhVien.ItemsSource = dtsv;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Load_Lop();
            Init_SinhVien();
            Init_Lop();
            role();
        }

        private void cmd_LoadDSLop_Click(object sender, RoutedEventArgs e)
        {
            Init_Lop();
        }

        private void cmd_them_Click(object sender, RoutedEventArgs e)
        {
            DataTable dttamlop = da.Select("SELECT * FROM LOP WHERE MALOP = '" + ((TextBlock)cbx_DanhSachLop.SelectedItem).Tag.ToString() + "'");
            int SLtronglop = 0;
            if(dttamlop.Rows.Count > 0)
            {
                 SLtronglop=int.Parse(dttamlop.Rows[0]["SOLUONG"].ToString());
            }

            //  điếm so lượng được check
            int slcheck = 0;
            for (int i = 0; i < dtsv.Rows.Count; i++)
                if (dtsv.Rows[i]["check"].ToString().ToLower() == "true")
                    slcheck++;
            if (slcheck == 0)
            {
                MessageBox.Show("Chưa chọn sinh viên!");
                return;
            }
            // số lượng check + số lượng hiên có < so lượng lớp
            int sotam = slcheck + dtlop.Rows.Count;
            if (sotam > SLtronglop)
            {
                var res = MessageBox.Show("Vượt quá số lượng lớp\nBạn có muốn làm tiếp không ?", "Vượt quá số lượng lớp", MessageBoxButton.YesNo);
                if (res == MessageBoxResult.No)
                    return;
                else
                {
                    // thêm học sinh
                    for (int i = 0; i < dtsv.Rows.Count; i++)
                    {
                        if (dtsv.Rows[i]["check"].ToString().ToLower() == "true")
                        {
                            //nếu vượt quá thì kết thúc
                            if (i + dtlop.Rows.Count > SLtronglop)
                            {
                                MessageBox.Show("Đã vượt qua số lượng của lớp học !");
                                return;
                            }
                            string sql = "INSERT INTO KETQUA (MAKETQUA, MASINHVIEN, MALOP) VALUES ('" + New_Id().ToString() + "','" + dtsv.Rows[i]["MASINHVIEN"].ToString() + "','" + ((TextBlock)cbx_DanhSachLop.SelectedItem).Tag.ToString() + "')";
                            da.Query(sql);

                            Init_Lop();
                        }
                    }

                }
            }
            else
            {
                for (int i = 0; i < dtsv.Rows.Count; i++)
                {
                    if (dtsv.Rows[i]["check"].ToString().ToLower() == "true")
                    {
                        string sql = "INSERT INTO KETQUA (MAKETQUA, MASINHVIEN, MALOP) VALUES ('" + New_Id().ToString() + "','" + dtsv.Rows[i]["MASINHVIEN"].ToString() + "','" + ((TextBlock)cbx_DanhSachLop.SelectedItem).Tag.ToString() + "')";
                        da.Query(sql);
                    }
                }
                //xuất ra kết qu
                //MessageBox.Show("Bạn đã thêm học sinh vào lớp thành công!", "Thông báo");
                Init_SinhVien();
                Init_Lop();
            }
        }

        private void cmd_Xoa_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < dtlop.Rows.Count; i++)
            {
                if (dtlop.Rows[i]["check"].ToString().ToLower() == "true")
                {
                    var res = MessageBox.Show("Bạn có muốn xoá tên các sinh viên đang được chọn trong lớp này không? \nNhấn YES để xoá - Nhấn NO để thoát.", "Thông báo", MessageBoxButton.YesNo);
                    if (res == MessageBoxResult.Yes)
                    {
                        (new DAO.Database()).Query("DELETE FROM KETQUA WHERE MAKETQUA = '" + dtlop.Rows[i]["MAKETQUA"].ToString() + "'");
                    }
                }
            }
            MessageBox.Show("Bạn đã xoá thành công các sinh viên có trong lớp học này!", "Thông báo");
            Init_SinhVien();
            Init_Lop();
        }
    }
}
