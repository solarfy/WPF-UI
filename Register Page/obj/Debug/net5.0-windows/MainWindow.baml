   M S B A M L   `   `   `  ����H  DRegister Page, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Register_PageRegister_Page  5   	   I)clr-namespace:Register_Page.User_ControlsRegister_Page.User_Controls  5   	       Register_Page.MainWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:Register_Page     5   	   Z VFontAwesome.WPF, Version=4.7.0.37774, Culture=neutral, PublicKeyToken=0758b07a11a4f466-fa$http://schemas.fontawesome.io/icons/  5   	   2uc)clr-namespace:Register_Page.User_Controls  5   	     � Title$  
MainWindow��5
   	   $	��650��6   $
��1000��6)   
������  � WindowStyle$
 None=�6O    � WindowStartupLocation$ CenterScreen=�5   	    � AllowsTransparency$
 True��6.   .��5      �  � ColumnDefinitions 5   
   �� 5      $	��350 �6   �� 5      $��* �6   .+�5   
   �� ���#ffd500 �� Padding$ 30q�6&    �� CornerRadius$ 	25 0 0 25��63   ._�5      �� $��Center=�6   .+�5      �� $��/Images/img.png��6   $	��160��61   $	��160��6=   $��0 0 0 40q�6J   �� 5      $��Let's get you sey up��6    �� TextAlignment$ Center=�68   $��SemiBold"�6O   $��28(�6e   ���#3636366s   �� 5      $D��>it should only take a couple of minute to pair with your watch��6   $
��Wrap=�5      $��16(�60   $ Center=�6>   ���#363636$��	0 20 0 20q�6j   �� 5         buttonBlack#��[  6   .��5      "  FontAwesome.WPF.ImageAwesome     Icon$ 
AngleRight=�6&   $��25��68   $��25��6C   	   
Foreground	 �#ffd500$��3 0 0 0q�6d   5      5      5       �� 5#   
   -   5        $��1��5#      $ 20q�6!   ���#ffffff$ 	0 25 25 0��6C   ._�5$      � .+�5%      �� $	��Top=�6   $��Right=�61   $��25��6M   $��25��6X   $��0 0 40 0q�6d   ��5&      �� 5'      
 �� 
TargetType"
 ��6*   .R�5(      �� ._�5)   "   � .+�5*   &   �� 5+   #   5,      5-      .��50      �� $��/Images/minimize.png��6     iconApp#��[ 6:   51      �� 53      -   5        $	��Top=�53      $��Right=�61   $��25��6M   $��25��6X   ��55      �� 56      "
 ��6*   .R�57      �� ._�58   "   � .+�59   &   �� 5:   #   5;      5<      .��5?      �� $��/Images/close.png��6   $��25��67   $��0 4 5 0q�6B   #��[ 6S   5@      � 5B      $��Center=�6   $��Center=�64   $��0 10 0 0q�6O    5C      �� 5D      $	��150 �6+   �� 5E      $��* �6+    � RowDefinitions 5H      �� 5I      $
��auto �6(   �� 5J      $
��auto �6(   �� 5K      $
��auto �6(   �� 5L      $
��auto �6(   �� 5M      $
��auto �6(   �� 5N      $
��auto �6(   �� 5O      $
��auto �6(   �� 5P      $
��auto �6(   .+�5S      �� $��0��6    $
��Name��6.     text#��[ 6:   �� 5T      $��1��6    $��Family��6.   #��[ 6<   �� 5U      $��2��6    $��Gender��6.   #��[ 6<   �� 5V      $��3��6    $��Date of Birth��6.   #��[ 6C   �� 5W      $��4��6    $��Email��6.   #��[ 6;   �� 5X      $��5��6    $��Mobile��6.   #��[ 6<   �� 5Y      $��6��6    $��
Membership��6.   #��[ 6@   +   %Register_Page.User_Controls.MyTextBox  5[      $��1��6#   $��0��63      Hint$ karim��6@     5\      $��1��6#   $��1��63   $	 Doe��6@     5]      $��1��6#   $��3��63   $ 
01/02/1980��6@     5^      $��1��6#   $��4��63   $ KarimDoe@email.com��6@     5_      $��1��6#   $��5��63   $ +98 7654 3210��6@   �� 5a       �� Orientation$ 
Horizontal=�6!   $��1��6:   $��2��6J   $
��0 10q�6W   .+�5b      *   $Register_Page.User_Controls.MyOption     Icon$
 Male=�6&      Text$
 Male��62     5c      $ Female=�6&   $ Female��64   5d      �� 5f      $ 
Horizontal=�6!   $��1��6:   $��6��6J   $
��0 10q�6W   .+�5g        $ 
CreditCard=�6&   $ Classic��68     5h      $ 
CreditCard=�6&   $ Silver��68     5i      $ 
CreditCard=�6&   $
 Gold��68   5j      � 5l      $��1��6   $��7��6+   $��0 40 0 0q�68    5m      �� 5n      $��* �6/   �� 5o      $��* �6/   .+�5r      �� $��Cancel��6!   $��0 0 10 0q�62     
buttonMain#��[ 6D   �� 5s      $
��Save��6!   $��10 0 0 0q�60   $��1��6B     buttonMainGreen#��[ 6R   5t      5u      5v      5w      5x      5y      