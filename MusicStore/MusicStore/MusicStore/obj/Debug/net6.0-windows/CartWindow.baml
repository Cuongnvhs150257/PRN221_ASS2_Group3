   M S B A M L   `   `   `  ????E  AMusicStore, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:MusicStore
MusicStore  5   	       MusicStore.CartWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:MusicStore     5   	     ? Title$  
CartWindow??5   	   $	??450??6   $	??944??6)   
????ح?.??5	      ?  ? ColumnDefinitions 5
   
   ?? 5      $
??223* ?6   ?? 5      $
??685* ?6   .+?5   
   ?? -   5         ??Name$ btnCheckout??5      $??	Check out??6&   $
??Left=?6:   $??	72,53,0,0q?6U   $	??Top=?6h   $??37??6?   $	??121??6?   $??16(?6?   6?   ?? 5   
   -   5         ??Name$ lblTotal??5      $??Total:??6"   $
??Left=?63   $??
65,369,0,0q?6N   $	??Top=?6b   $
??Bold"?6z   $??24(?6?   $??1??6?   ?? 5   
   -   5         ??Name$ txtTotal??5      $
??Left=?6$   $??142,374,0,0q?6?    ?? TextWrapping$
 Wrap=?6T   $?? ??6h   $	??Top=?6p   $	??120??6?   $??22(?6?   $??1??6?   ?? 5   
   -   5        $??lvCart??5   )   $??42,113,27,70q?6   $??2??67    ?? View 5      ?? 5      .P?5      ?? $??AlbumId??6%    ?? Width$	 100??66   ?? 5      $??Tilte??6%   $	 280??64   ?? 5      $??Price??6%   $	 100??64   ?? 5      $??Count??6%   $	 100??64   ?? 5      $??Date Created??6%   $	 170??6;   ?? 5      $??Remove From cart??6%   $	 100??6?    ?? CellTemplate 5      ?? 5      .R?5   "   ?? -   5        $??Remove from cart??5      $??0q?5      $??Center=?5       5!   %   5#      5%      5(      5,      5.      5/      