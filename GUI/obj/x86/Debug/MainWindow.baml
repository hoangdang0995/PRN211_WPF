   M S B A M L   `   `   `  ????  GUI    GUI.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   a ]DevExpress.Xpf.Core.v12.2, Version=12.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a;dx2http://schemas.devexpress.com/winfx/2008/xaml/core  5   k   d `DevExpress.Xpf.Docking.v12.2, Version=12.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a@dxdo5http://schemas.devexpress.com/winfx/2008/xaml/docking  6?   c _DevExpress.Xpf.Ribbon.v12.2, Version=12.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a>dxr4http://schemas.devexpress.com/winfx/2008/xaml/ribbon  6?   <dxb2http://schemas.devexpress.com/winfx/2008/xaml/bars  6-    ? Title$6  0Hệ thống Quản Lý Sinh Viên - Version 1.0??6	   $	??350??6:   $	??525??6G    ? WindowState$ 	Maximized=?6S    ? Icon$% /GUI;component/Resources/47.png??6l  .??5      ? .+?5   
   $  DevExpress.Xpf.Bars.BarManager  -   5        $??barManager1??5         Items 5      '  !DevExpress.Xpf.Bars.BarButtonItem  5      -   5         ?Name$ cmd_DangNhap??5   8   !  DevExpress.Xpf.Bars.BarItem   Content)  #DevExpress.Xpf.Core.ObjectConverter$ Đăng nhập 6$      
LargeGlyph$+ %/GUI;component/Resources/dangnhap.png??6L     5	      -   5        $ cmd_DangXuat??5	   8   $ Đăng xuất 6$   $+ %/GUI;component/Resources/dangxuat.png??6L     5
      -   5        $ cmd_ThongTinTK??5
   ;   $ Thông Tin TK 6$   $- '/GUI;component/Resources/doimatkhau.png??6Q     5      -   5        $ cmd_NguoiDung??5   9   $ Người dùng 6$   $$ /GUI;component/Resources/5.png??6N     5      -   5        $ cmd_SinhVien??5   8   $ 
Sinh Viên 6$   $% /GUI;component/Resources/56.png??6L     5      -   5        $ 
cmd_DanToc??5   6   $ 
Dân tộc 6$      Glyph$) #/GUI;component/Resources/dantoc.png??6H     5      -   5        $ cmd_TonGiao??5   7   $ 
Tôn giáo 6$   $* $/GUI;component/Resources/tongiao.png??6J     5      -	   5        $ cmd_GiangVien??5   9   $ Giảng Viên 6$   $, &/GUI;component/Resources/giangvien.png??6N     5      -
   5        $ 	cmd_HocVi??5   5   $ 
Học vị 6$   $- '/GUI;component/Resources/dsgiaovien.png??6F     5      -   5        $ cmd_LoaiGiangVien??5   >   $ Loại Giảng viên 6$   $) #/GUI;component/Resources/pupils.png??6W     5      -   5        $ 	cmd_Thoat??5   @   $ Đóng chương trình 6$   $( "/GUI;component/Resources/thoat.png??6Q     5      -   5        $ cmd_KetQuaHKTheoLop??5   J   $- 'Kết quả học kỳ theo lớp học 6$   $1 +/GUI;component/Resources/kqhockytheolop.png??6e     5      -   5        $ cmd_KetQuaHKTheoMonHoc??5   J   $, &Kết quả học kỳ theo môn học 6$   $1 +/GUI;component/Resources/kqhockytheomon.png??6h     5      -   5        $ cmd_DanhSachSinhVien??5   B   $ Danh sách Sinh Viên 6$   $% /GUI;component/Resources/56.png??6^     5      -   5        $ cmd_DanhsachGiangVien??5   C   $ Danh sách Giảng Viên 6$   $- '/GUI;component/Resources/dsgiaovien.png??6`     5      -   5        $ cmd_DanhSachLopHoc??5   @   $ Danh sách Lớp Học 6$   $+ %/GUI;component/Resources/dslophoc.png??6Z     5      -   5        $ cmd_TraCuuSinhVien??5   @   $ Tra cứu Sinh Viên 6$   $0 */GUI;component/Resources/tracuuhocsinh.png??6Z     5      -   5        $ cmd_TraCuuGiangVien??5   A   $ Tra cứu Giảng Viên 6$   $1 +/GUI;component/Resources/tracuugiaovien.png??6\     5      -   5        $ cmd_TraCuuMonHoc??5   >   $ Tra cứu Môn Học 6$   $) #/GUI;component/Resources/monhoc.png??6V   ._?5      ]? -   5        $??
dockPanel1??5      .+?5      )  #DevExpress.Xpf.Ribbon.RibbonControl  -   5        $??ribbonControl1??5   $   $	??Top=?6:      AllowKeyTips .  ???	#FFB16D6D!	   ApplicationButtonSmallIcon$%	 /GUI;component/Resources/47.png??6{   
   
Categories.
 5      5  /DevExpress.Xpf.Ribbon.RibbonDefaultPageCategory  -   5        $  ribbonDefaultPageCategory1??5   N   2  ,DevExpress.Xpf.Ribbon.RibbonPageCategoryBase   Caption$ defaultCategory??64      Pages. 5      &   DevExpress.Xpf.Ribbon.RibbonPage  -   5        $ rbpg_TrangChu??5   =      Caption$ Trang chủ 6)      Groups. 5       +	  %DevExpress.Xpf.Ribbon.RibbonPageGroup	  -   5        $ rbpgr_HeThong??5    E    	  Caption$ Hệ thống??62    	  	ItemLinks. 5!   "   +
  %DevExpress.Xpf.Bars.BarButtonItemLink
  %  DevExpress.Xpf.Bars.BarItemLink   BarItemName$ cmd_DangNhap??68   
  5"   "   $ cmd_DangXuat??68   5#      	  5$      -   5        $ rbpgr_QuanLyND??5$   O   $ Quản Lý Người dùng??62   . 5%   "   
  $ cmd_ThongTinTK??68   
  5&   "   $ cmd_NguoiDung??68   5'      	  5(      -   5        $ rbpgr_SinhVien??5(   F   $ 
Sinh Viên??62   . 5)   "   
  $ cmd_SinhVien??68   
  5*   "   $ 
cmd_DanToc??68   
  5+   "   $ cmd_TonGiao??68   5,      	  5-      -   5        $ rbpgr_GiangVien??5-   G   $ Giảng Viên??62   . 5.   "   
  $ cmd_GiangVien??68   
  5/   "   $ 	cmd_HocVi??68   
  50   "   $ cmd_LoaiGiangVien??68   51      	  52      -   5        $ rbpgr_ChucNang??52   F   $ Chức năng??62   . 53   "   
  $ 	cmd_Thoat??68   54      55        56      -   5        $ rbpg_ThongKe??56   <   $ Thống kê 6)   . 57      	  -   5        $ rbpgr_KetQuaHocTap??57   L   $ Kết quả học tập??62   . 58   "   
  $ cmd_KetQuaHKTheoLop??68   
  59   "   $ cmd_KetQuaHKTheoMonHoc??68   5:      	  5;      -    5        $ rbpgr_XuatDanhSach??5;   K   $ Xuất danh sách??62   . 5<   "   
  $ cmd_DanhSachSinhVien??68   
  5=   "   $ cmd_DanhsachGiangVien??68   
  5>   "   $ cmd_DanhSachLopHoc??68   5?      5@        5A      -!   5        $ rbpg_TraCuu??5A   ;   $ 	Tra cứu 6)   . 5B      	  -"   5        $ rbpgr_TraCuu??5B   D   $ 	Tra cứu??62   . 5C   "   
  $ cmd_TraCuuSinhVien??68   
  5D   "   $ cmd_TraCuuGiangVien??68   
  5E   "   $ cmd_TraCuuMonHoc??68   5F      5G      5H      5I      2  ,DevExpress.Xpf.Ribbon.RibbonStatusBarControl  5J      -#   5        $??rbstt_XinChao??5J   E   $??Bottom=?6-   $??RightToLeft=?6Z   ? 5K      -$   5        $??grid1??5K      ???	#FFE5D3D36$   5L      5M      5N      5O      