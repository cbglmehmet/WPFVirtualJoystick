   M S B A M L   `   `   `  ????J  FvirtualJoystick, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:virtualJoystickvirtualJoystick  5   	        virtualJoystick.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:virtualJoystick     5   	   -   5          ? Title$  
MainWindow??5   	   $	??360??6   $	??520??6)   
??? ???.??5	      ? .+?5
   
       virtualJoystick.VirtualJoy  -   5          Name$ joystick??5
      $
??Left=?6-   $	??320??6I   $	??320??6V   $	??Top=?6b   ? 5   
   $??Right=?6   $	??100??6+   $	??Top=?68   $	??200??6P    ? ColumnDefinitions 5      ?? 5      6%   ?? 5      6%    ? RowDefinitions 5      ?? 5      6"   ?? 5      6"   .+?5      ?? $??
X Value : ??6   $??0??6)   $??0??69   $??20(?6F   $??Center=?6T   $??Right=?6o   6?   ?? 5      $??
Y Value : ??6   $??0??6)   $??1??69   $??20(?6F   $??Center=?6T   $??Right=?6o   6?   ?? 5      -   5        $??	lblXValue??5      $??-??6%   $??1??61   $??0??6A   $??20(?6N   $??Center=?6\   $
??Left=?6w   6?   ?? 5      -   5        $??	lblYValue??5      $??-??6%   $??1??61   $??1??6A   $??20(?6N   $??Center=?6\   $
??Left=?6w   6?   5      5      5      