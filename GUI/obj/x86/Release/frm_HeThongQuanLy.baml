   M S B A M L   `   `   `  ???? d  `DevExpress.Xpf.Docking.v22.1, Version=22.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aeJclr-namespace:DevExpress.Xpf.Docking;assembly=DevExpress.Xpf.Docking.v22.1DevExpress.Xpf.Docking   GUI   GUI.frm_HeThongQuanLy   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35a ]DevExpress.Xpf.Core.v22.1, Version=22.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aR NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     `	dxDockingJclr-namespace:DevExpress.Xpf.Docking;assembly=DevExpress.Xpf.Docking.v22.1     ;dx2http://schemas.devexpress.com/winfx/2008/xaml/core  @dxdo5http://schemas.devexpress.com/winfx/2008/xaml/docking   c _DevExpress.Xpf.Ribbon.v22.1, Version=22.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a@dxr4http://schemas.devexpress.com/winfx/2008/xaml/ribbon   <dxb2http://schemas.devexpress.com/winfx/2008/xaml/bars  -     ?Name$  frm_hethong?? ? Title$6 0Hệ thống Quản Lý Sinh Viên - Version 1.0??$	??609??$
??1200?? ? WindowState$ 	Maximized=? ? Icon$% /GUI;component/Resources/47.png??.??? .+?$  DevExpress.Xpf.Bars.BarManager  -   $??barManager1??   Items '  !DevExpress.Xpf.Bars.BarButtonItem  -    ?Name$ cmd_DangNhap??!  DevExpress.Xpf.Bars.BarItem   Content)  #DevExpress.Xpf.Core.ObjectConverter$ Đăng xuất    
LargeGlyph:  4DevExpress.Xpf.Core.Internal.SvgImageSourceConverter$+ %/GUI;component/Resources/dangxuat.png   -   $ cmd_ThongTinTK??$ Thông Tin Tài Khoản $- '/GUI;component/Resources/doimatkhau.png   -   $ cmd_NguoiDung??$ Người dùng $$ /GUI;component/Resources/5.png   -   $ cmd_LoaiNguoiDung??$ Loại Người dùng $+ %/GUI;component/Resources/phancong.png   -   $ cmd_SinhVien??$ 
Sinh Viên $% /GUI;component/Resources/56.png   -   $ 
cmd_DanToc??$ 
Dân tộc    Glyph$) #/GUI;component/Resources/dantoc.png   -	   $ cmd_TonGiao??$ 
Tôn giáo $* $/GUI;component/Resources/tongiao.png   -
   $ cmd_GiangVien??$ Giảng Viên $, &/GUI;component/Resources/giangvien.png 	 ?? 	IsEnabled	 .   -   $ 	cmd_HocVi??$ Học hàm - Học vị $- '/GUI;component/Resources/dsgiaovien.png   -   $ cmd_LoaiGiangVien??$ Loại Giảng viên $) #/GUI;component/Resources/pupils.png   -   $ 	cmd_Thoat??$ Đóng chương trình $( "/GUI;component/Resources/thoat.png   -   $ cmd_KetQuaHKTheoLop??$- 'Kết quả học kỳ theo lớp học $1 +/GUI;component/Resources/kqhockytheolop.png   -   $ cmd_KetQuaHKTheoMonHoc??$, &Kết quả học kỳ theo môn học $1 +/GUI;component/Resources/kqhockytheomon.png   -   $ cmd_DanhSachSinhVien??$ Danh sách Sinh Viên $% /GUI;component/Resources/56.png   -   $ cmd_DanhsachGiangVien??$ Danh sách Giảng Viên $- '/GUI;component/Resources/dsgiaovien.png   -   $ cmd_DanhSachLopHoc??$ Danh sách Lớp Học $+ %/GUI;component/Resources/dslophoc.png   -   $ cmd_TraCuuSinhVien??$ Tra cứu Sinh Viên $0 */GUI;component/Resources/tracuuhocsinh.png   -   $ cmd_TraCuuGiangVien??$ Tra cứu Giảng Viên $1 +/GUI;component/Resources/tracuugiaovien.png   -   $ cmd_TraCuuMonHoc??$ Tra cứu Môn Học $) #/GUI;component/Resources/monhoc.png   -   $ cmd_NhapDiem??$ Nhập điểm $= 7/GUI;component/Resources/Blu%20Style%20png%20pages1.png   -   $ 	cmd_HocKy??$ 
Học Kỳ $( "/GUI;component/Resources/hocky.png   -   $ cmd_Khoa??$
 Khoa $* $/GUI;component/Resources/khoilop.png   -   $ cmd_KhoaHoc??$ Khoá Học $) #/GUI;component/Resources/namhoc.png   -   $ cmd_ChuyenNganh??$ Chuyên Ngành $- '/GUI;component/Resources/nghenghiep.png   -   $ 
cmd_MonHoc??$ 
Môn Học $) #/GUI;component/Resources/monhoc.png   -   $ 
cmd_LopHoc??$ Lớp Học $) #/GUI;component/Resources/lophoc.png   -   $ cmd_ThongTinPhanMem??$ Thông tin Phần mềm $( "/GUI;component/Images/xoabonho.png   -   $ cmd_KetQua1SinhVien??$0 *Kết quả học tập của 1 Sinh viên $0 */GUI;component/Resources/kqcnamtheomon.png   -   $ 
cmd_XepLop??$ Xếp lớp $/ )/GUI;component/Resources/closephanlop.png ._?]? -    $??
dockPanel1??.+?)  #DevExpress.Xpf.Ribbon.RibbonControl  -!   $??ribbonControl1??$	??Top=?
   AllowKeyTips
 .  !   ApplicationButtonLargeIcon$* $/GUI;component/Images/dsgiaovien.png ???	#FFC17777???	#FFA05A5A   RibbonStyle$ 
Office2007=?   Items. 5  /DevExpress.Xpf.Ribbon.RibbonDefaultPageCategory  -"   $  ribbonDefaultPageCategory1??2  ,DevExpress.Xpf.Ribbon.RibbonPageCategoryBase   Caption$ defaultCategory??   Pages. &	   DevExpress.Xpf.Ribbon.RibbonPage	  -#   $ rbpg_TrangChu?? 	  Caption$ Trang chủ / 	  (AllowRemoveFromParentDuringCustomization .   	  Groups. +
  %DevExpress.Xpf.Ribbon.RibbonPageGroup
  -$   $ rbpgr_HeThong?? 
  Caption$ Hệ thống?? 
  Items. +  %DevExpress.Xpf.Bars.BarButtonItemLink  )  #DevExpress.Xpf.Bars.BarItemLinkBase   BarItemName$ cmd_DangNhap??
  -%   $ rbpgr_QuanLyND??$ Quản Lý Người dùng??.   $ cmd_ThongTinTK??  $ cmd_NguoiDung??  $ cmd_LoaiNguoiDung??
  -&   $ rbpgr_SinhVien??$ 
Sinh Viên??.   $ cmd_SinhVien??  $ 
cmd_DanToc??  $ cmd_TonGiao??  $ 
cmd_XepLop??
  -'   $ rbpgr_GiangVien??$ Giảng Viên??.   $ cmd_GiangVien??  $ 	cmd_HocVi??  $ cmd_LoaiGiangVien??
  -(   $ rbpgr_DanhMucKhac??$ Danh mục khác??.   $ 	cmd_HocKy??  $ cmd_Khoa??  $ cmd_KhoaHoc??  $ cmd_ChuyenNganh??  $ 
cmd_MonHoc??  $ 
cmd_LopHoc??
  -)   $ rbpgr_ChucNang??$ Chức năng??.   $ 	cmd_Thoat??	  -*   $ rbpg_ThongKe??$ Thống kê . 
  -+   $ rbpgr_KetQuaHocTap??$ Kết quả học tập??.   $ cmd_KetQuaHKTheoLop??  $ cmd_KetQuaHKTheoMonHoc??  $ cmd_KetQua1SinhVien??
  -,   $ rbpgr_NhapDiem??$  Nhập điểm học tập??.   $ cmd_NhapDiem??	  --   $ ribbonPage1??$ 
Thông tin . 
  -.   $ rbpgr_TroGiup??$ Trợ Giúp??.   $ cmd_ThongTinPhanMem???? $??30??$??Bottom=?.@??? 
???  ??????  ?? ElementName$ frm_hethong?? ?? StringFormat$ Xin Chào : {0}?? ?? Path$ TenND?? -/   $??grd_formcon??.+?.   (DevExpress.Xpf.Docking.DockLayoutManager  -0     Name$ dockManagerMainForm??????  ?? ImageSource$- '/GUI;component/Resources/background.jpg??   
LayoutRoot. (   "DevExpress.Xpf.Docking.LayoutGroup  -1   $??rootLayoutGroup??