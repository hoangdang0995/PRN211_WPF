   M S B A M L   `   `   `  ????d  `DevExpress.Xpf.Docking.v22.1, Version=22.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aeJclr-namespace:DevExpress.Xpf.Docking;assembly=DevExpress.Xpf.Docking.v22.1DevExpress.Xpf.Docking  5   	    GUI   GUI.frm_HeThongQuanLy   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35a ]DevExpress.Xpf.Core.v22.1, Version=22.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aR NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   `	dxDockingJclr-namespace:DevExpress.Xpf.Docking;assembly=DevExpress.Xpf.Docking.v22.1     5   	   ;dx2http://schemas.devexpress.com/winfx/2008/xaml/core  5   r   @dxdo5http://schemas.devexpress.com/winfx/2008/xaml/docking   6?   c _DevExpress.Xpf.Ribbon.v22.1, Version=22.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a@dxr4http://schemas.devexpress.com/winfx/2008/xaml/ribbon   6?   <dxb2http://schemas.devexpress.com/winfx/2008/xaml/bars  64  -   5          ?Name$  frm_hethong??5   	    ? Title$6 0Hệ thống Quản Lý Sinh Viên - Version 1.0??5   	   $	??609??6:   $
??1200??6J    ? WindowState$ 	Maximized=?6Z    ? Icon$% /GUI;component/Resources/47.png??6s  .??5      ? .+?5      $  DevExpress.Xpf.Bars.BarManager  -   5        $??barManager1??5         Items 5	      '  !DevExpress.Xpf.Bars.BarButtonItem  5
      -   5         ?Name$ cmd_DangNhap??5
   ,   !  DevExpress.Xpf.Bars.BarItem   Content)  #DevExpress.Xpf.Core.ObjectConverter$ Đăng xuất 6      
LargeGlyph:  4DevExpress.Xpf.Core.Internal.SvgImageSourceConverter$+ %/GUI;component/Resources/dangxuat.png 6@   6s     5      -   5        $ cmd_ThongTinTK??5   6   $ Thông Tin Tài Khoản 6   $- '/GUI;component/Resources/doimatkhau.png 6q     5      -   5        $ cmd_SinhVien??5   ,   $ 
Sinh Viên 6   $% /GUI;component/Resources/56.png 6@   6m     5      -   5        $ cmd_xemDiem??5   +   $ Xem Điểm 6   $- '/GUI;component/Resources/dsgiaovien.png 6>   6s   ._?5      ]? -   5        $??
dockPanel1??5      .+?5      )  #DevExpress.Xpf.Ribbon.RibbonControl  -   5        $??ribbonControl1??5      $	??Top=?6.      AllowKeyTips .  !	   ApplicationButtonLargeIcon$*	 $/GUI;component/Images/dsgiaovien.png 6X   ???	#FFC17777???	#FFA05A5A
   RibbonStyle$
 
Office2007=?6?      Items. 5      5  /DevExpress.Xpf.Ribbon.RibbonDefaultPageCategory  -	   5        $  ribbonDefaultPageCategory1??5   ?   2  ,DevExpress.Xpf.Ribbon.RibbonPageCategoryBase   Caption$ defaultCategory??6%      Pages. 5      &	   DevExpress.Xpf.Ribbon.RibbonPage	  -
   5        $ rbpg_TrangChu??5   +    	  Caption$ Trang chủ 6   / 	  (AllowRemoveFromParentDuringCustomization .   	  Groups. 5   	   +
  %DevExpress.Xpf.Ribbon.RibbonPageGroup
  -   5        $ rbpgr_HeThong??5   0    
  Caption$ Hệ thống??6    
  Items. 5   
   +  %DevExpress.Xpf.Bars.BarButtonItemLink  )  #DevExpress.Xpf.Bars.BarItemLinkBase   BarItemName$ cmd_DangNhap??6    5   
   
  5   	   -   5        $ rbpgr_QuanLyND??5   :   $ Quản Lý Người dùng??6   . 5   
     $ cmd_ThongTinTK??6      5   
   $ cmd_NguoiDung??6      5   
   $ cmd_LoaiNguoiDung??6    5   
   
  5   	   -   5        $ rbpgr_SinhVien??5   1   $ 
Sinh Viên??6   . 5    
     $ cmd_SinhVien??6    5!   
   
  5#   	   -   5        $ rbpgr_xemDiem??5#   0   $ Xem Điểm??6   . 5$   
     $ cmd_xemDiem??6    5%   
   5'   	   5)      5*      ?? 5+      $??30??6   $??Bottom=?6   .@?5,      ?? 
???  ????6"   ??  ?? ElementName$ frm_hethong?? ?? StringFormat$ Xin Chào : {0}?? ?? Path$ TenND?5-      5.      ? 5/      -   5        $??grd_formcon??5/      .+?50      .   (DevExpress.Xpf.Docking.DockLayoutManager  -   5          Name$ dockManagerMainForm??50   #   ??51      ?? 52   	    ?? ImageSource$- '/GUI;component/Resources/background.jpg??6      
LayoutRoot. 54      (   "DevExpress.Xpf.Docking.LayoutGroup  -   5        $??rootLayoutGroup??54      55   	   56      57      58      59      5:      5;      