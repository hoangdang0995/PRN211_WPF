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
using DevExpress.Xpf.Docking;
using System.Data;
namespace GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    using setting = Properties.Settings;
    using DevExpress.Xpf.Docking;
    public partial class frm_HeThongQuanLy : Window
    {
        public static DataTable dtquyen;
        //private void role()
        //{
        //    dtquyen = (new DAO.Database()).Select("SELECT * FROM PHANQUYEN where MALOAI = '" + setting.Default.maloainguoidung + "'");
        //    if (setting.Default.loainguoidung.ToLower() == "admin")
        //        return;

        //        cmd_ChuyenNganh.IsVisible = false;
        //        cmd_KhoaHoc.IsVisible = false;
        //        cmd_LopHoc.IsVisible = false;
        //        rbpgr_NhapDiem.IsVisible = false;
        //        cmd_SinhVien.IsVisible = false;

        //        int sv = 0;
        //        int gv = 0;
        //        int dmk = 0;

        //    if (timtenformtrongdt("CHUYENNGANH", dtquyen) > -1)
        //    {
        //        if (dtquyen.Rows[timtenformtrongdt("CHUYENNGANH", dtquyen)]["KICHHOAT"].ToString().ToLower() == "true")
        //        {
        //            cmd_ChuyenNganh.IsVisible = true;
        //            dmk++;
        //        }

        //        if (dtquyen.Rows[timtenformtrongdt("DANTOC", dtquyen)]["KICHHOAT"].ToString().ToLower() == "true")
        //        {
        //            sv++;
        //        }

        //        if (dtquyen.Rows[timtenformtrongdt("GIANGVIEN", dtquyen)]["KICHHOAT"].ToString().ToLower() == "true")
        //        {
        //            gv++;
        //        }

        //        if (dtquyen.Rows[timtenformtrongdt("HOCVIHOCHAM", dtquyen)]["KICHHOAT"].ToString().ToLower() == "true")
        //        {
        //            gv++;
        //        }

        //        if (dtquyen.Rows[timtenformtrongdt("HOCKY", dtquyen)]["KICHHOAT"].ToString().ToLower() == "true")
        //        {
        //            dmk++;
        //        }

        //        if (dtquyen.Rows[timtenformtrongdt("KHOA", dtquyen)]["KICHHOAT"].ToString().ToLower() == "true")
        //        {
        //            dmk++;
        //        }

        //        if (dtquyen.Rows[timtenformtrongdt("KHOAHOC", dtquyen)]["KICHHOAT"].ToString().ToLower() == "true")
        //        {
        //            cmd_KhoaHoc.IsVisible = true;
        //            dmk++;
        //        }

        //        if (dtquyen.Rows[timtenformtrongdt("LOAINGUOIDUNG", dtquyen)]["KICHHOAT"].ToString().ToLower() == "true")

        //        if (dtquyen.Rows[timtenformtrongdt("LOPHOC", dtquyen)]["KICHHOAT"].ToString().ToLower() == "true")
        //        {
        //            cmd_LopHoc.IsVisible = true;
        //            dmk++;
        //        }

        //        if (dtquyen.Rows[timtenformtrongdt("MONHOC", dtquyen)]["KICHHOAT"].ToString().ToLower() == "true")
        //        {
        //            dmk++;
        //        }

        //        if (dtquyen.Rows[timtenformtrongdt("NGUOIDUNG", dtquyen)]["KICHHOAT"].ToString().ToLower() == "true")

        //        if (dtquyen.Rows[timtenformtrongdt("BANGDIEM", dtquyen)]["KICHHOAT"].ToString().ToLower() == "true")
        //            rbpgr_NhapDiem.IsVisible = true;

        //        if (dtquyen.Rows[timtenformtrongdt("SINHVIEN", dtquyen)]["KICHHOAT"].ToString().ToLower() == "true")
        //        {
        //            cmd_SinhVien.IsVisible = true;
        //            sv++;
        //        }

        //        if (dtquyen.Rows[timtenformtrongdt("TONGIAO", dtquyen)]["KICHHOAT"].ToString().ToLower() == "true")
        //        {
        //            sv++;
        //        }

        //        if (dtquyen.Rows[timtenformtrongdt("LOAIGIANGVIEN", dtquyen)]["KICHHOAT"].ToString().ToLower() == "true")
        //        {
        //            sv++;
        //        }

        //        if (dtquyen.Rows[timtenformtrongdt("KETQUA", dtquyen)]["KICHHOAT"].ToString().ToLower() == "true")
        //        {
        //            sv++;
        //        }
        //    }

        //    //if (sv == 0)
        //        //rbpgr_SinhVien.IsVisible = false;
        //}

        public static int timtenformtrongdt(string tenmodun, DataTable dt)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["MODULE"].ToString().Equals(tenmodun))
                {
                    return i;
                }
            }
            return -1;
        }

        public string TenND { get { return setting.Default.tennguoidung; } }
        public frm_HeThongQuanLy()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(MainWindow_Loaded);
        }

        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
           //role();
        }

        private  void ShowUserControl(string title,UserControl wd)
        {
            DocumentGroup documentGroup = dockManagerMainForm.GetItem("dockManagerMainForm") as DocumentGroup;
            if (documentGroup == null)
            {
                documentGroup = dockManagerMainForm.DockController.AddDocumentGroup(DevExpress.Xpf.Layout.Core.DockType.Left); // create the if necessary
                documentGroup.Name = "dockManagerMainForm";
            }
            LayoutPanel panel = dockManagerMainForm.DockController.AddDocumentPanel(documentGroup);  // сreate a panel in the document group
            panel.Content = wd;
            panel.Caption = title;
            panel.ShowCloseButton = true;
            panel.ShowCaption = true;
            panel.CaptionAlignMode = CaptionAlignMode.AlignInGroup;

            this.dockManagerMainForm.DockController.Activate(panel);  
        }

        private void cmd_ThongTinTK_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            ShowUserControl("Thông tin tài khoản", G_system.Show("frm_ThongTinTaiKhoan", "GUI"));
        }

        //private void cmd_DanToc_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        //{
           
        //}

        //private void cmd_DanToc_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        //{
        //    ShowUserControl("Dân Tộc", G_system.Show("frm_DanToc", "GUI"));
        //}

        //private void cmd_GiangVien_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        //{
        //    ShowUserControl("Giảng Viên", G_system.Show("frm_Giangvien", "GUI"));
        //}

        private void cmd_DangNhap_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            login();
        }

        void login()
        {
            frm_DangNhap _dangnhap = new frm_DangNhap();
            var res = MessageBox.Show("Bạn có muốn thoát chương trình không?", "Thông báo", MessageBoxButton.YesNo);
            if (res == MessageBoxResult.Yes)
            {
                _dangnhap.Show();
                this.Close();
            }
        }

        private void cmd_SinhVien_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            ShowUserControl("Sinh Viên", G_system.Show("frm_Sinhvien", "GUI"));
        }

        //private void cmd_NguoiDung_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        //{
        //    ShowUserControl("Người dùng", G_system.Show("frm_Nguoidung", "GUI"));
        //}

        //private void cmd_TonGiao_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        //{
        //    ShowUserControl("Tôn Giáo", G_system.Show("frm_Tongiao", "GUI"));
        //}

        //private void cmd_HocVi_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        //{
        //    ShowUserControl("Học Hàm - Học Vị", G_system.Show("frm_hocham_hocvi", "GUI"));
        //}

        //private void cmd_LoaiGiangVien_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        //{
        //    ShowUserControl("Loại Giảng Viên", G_system.Show("Loaigv", "GUI"));
        //}

        //private void cmd_HocKy_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        //{
        //    ShowUserControl("Học Kỳ", G_system.Show("frm_HocKy", "GUI"));
        //}

        //private void cmd_ChuyenNganh_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        //{
        //    ShowUserControl("Chuyên Ngành", G_system.Show("frm_Chuyennganh", "GUI"));
        //}

        //private void cmd_Khoa_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        //{
        //    ShowUserControl("Khoa", G_system.Show("frm_Khoa", "GUI"));
        //}

        //private void cmd_MonHoc_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        //{
        //    ShowUserControl("Môn Học", G_system.Show("frm_monhoc", "GUI"));
        //}

        //private void cmd_KhoaHoc_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        //{
        //    ShowUserControl("Khóa Học", G_system.Show("frm_khoahoc", "GUI"));
        //}

        //private void cmd_LopHoc_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        //{
        //    ShowUserControl("Lớp Học", G_system.Show("frm_lophoc", "GUI"));
        //}

        //private void cmd_NhapDiem_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        //{
        //    ShowUserControl("Nhập điểm", G_system.Show("frm_NhapDiem", "GUI"));
        //}

        //private void cmd_LoaiNguoiDung_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        //{
        //    ShowUserControl("Loại người dùng", G_system.Show("frm_LoaiNguoiDung", "GUI"));
        //}

        private void cmd_Thoat_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            var res = MessageBox.Show("Bạn có muốn thoát chương trình không?", "Thông báo", MessageBoxButton.YesNo);
            if (res == MessageBoxResult.Yes)
            {
                this.Close();
            }
        }

        //private void cmd_KetQuaHKTheoMonHoc_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        //{
        //    ShowUserControl("Kết quả học tập theo môn học", G_system.Show("frm_KetQuaTheoMonHoc", "GUI"));
        //}

        //private void cmd_XepLop_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        //{
        //    ShowUserControl("Xếp lớp", G_system.Show("frm_SinhVien_Lop", "GUI"));
        //}

        //private void cmd_KetQuaHKTheoLop_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        //{
        //    ShowUserControl("Kết quả học tập theo lớp học", G_system.Show("frm_KetQuaTheoLopHoc", "GUI"));
        //}

        //private void cmd_KetQua1SinhVien_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        //{
        //    ShowUserControl("Kết quả học tập của 1 sinh viên", G_system.Show("frm_KetQuaCua1SinhVien", "GUI"));
        //}

        //private void cmd_ThongTinPhanMem_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        //{
        //    ShowUserControl("Thông tin phần mềm", G_system.Show("frm_ThongTinPhanMem", "GUI"));
        //}
    }
}
