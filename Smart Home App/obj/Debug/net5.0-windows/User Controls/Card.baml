   M S B A M L   `   `   `  ����I  ESmart Home App, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:Smart_Home_App.User_ControlsSmart_Home_App.User_Controls  5      '    !Smart_Home_App.User_Controls.Card   5      W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      <local*clr-namespace:Smart_Home_App.User_Controls     5      -   5        $
��card��5      .��5	      ��   �� CornerRadius$  25��6    �� Padding$ 20q�6   $	��150��6,   $��Stretch=�69    J� Effect 5
   
   3  -System.Windows.Media.Effects.DropShadowEffect  5         ShadowDepth$ 1Q�6      
BlurRadius$ 20Q�6/      Opacity$	 0.5Q�6?   ��5   
   �� 5       �� 
TargetType" ��6   .�5      ��  �� Property � �� �� Value$	 150��6*   	 �� Triggers	 5      �� 5      
 �� Binding
 6"   ��  �� ElementName$ toggle�� �� Path$ 	IsChecked� �� Value True6X   .a�5      ��  � �� �#3256f167   5      �� 5      
 6"   �� $ toggle��$ 	IsChecked�	 False6X   .a�5      ��  � �� �#efefee67   5      �� 5      
 6"   �� $
 card��$ IsHorizontal� True6Y   .a�5      ��  � ��$	 190��62   5      �� 5      
 6"   �� $
 card��$ IsHorizontal�	 False6Y   .a�5       ��  � ��$	 150��62   5!      5#      ._�5&   
   � .+�5'      �� $��SemiBold"�6   $	��Top=�6.   $
��Left=�6F   $��0 5 0 0q�6a   ��5(      �� 5)      " ��6   	 5*      �� 5+      
 6*   �� $ toggle��$ 	IsChecked� True6`   .a�5,   "   ��  � ��$ On��69   �� 5-   "    � �� �#ffffff6?   5.      �� 50      
 6*   �� $ toggle��$ 	IsChecked�	 False6a   .a�51   "   ��  � ��$	 Off��69   �� 52   "    � �� �#3256f16?   53      55      57      �� 59      -   5         ��Name$ toggle��59      $��Right=�6'    d� 	IsChecked 6C   �� $
 card��$ 	IsChecked���5:      �� 5;      " ��6      toggleButton �� BasedOn# [  62   .�5<      ��  � ��$	 Top=�6>   	 5=      �� 5>      
 6*   �� $
 card��$ IsHorizontal� True6a   .a�5?   "   ��  � ��$ Center=�6F   5@      �� 5B      
 6*   �� $
 card��$ IsHorizontal�	 False6a   .a�5C   "   ��  � ��$	 Top=�6F   5D      5F      5H      �� 5J      $��Center=�6   $��40��6/   $��40��6:   $
��Left=�6F   ��5K      �� 5L      " ��6   	 5M      �� 5N      
 6*   �� $ toggle��$ 	IsChecked� True6a   .a�5O   "   ��  � �� 6;   �� $
 card��$ ImageOn�5P      �� 5R      
 6*   �� $ toggle��$ 	IsChecked�	 False6a   .a�5S   "   ��  � �� 6;   �� $
 card��$ ImageOff�5T      5V      5X      �� 5Z      $��Bottom=�6   $��SemiBold"�63   ��5[      �� $
 card��$ Title���5\      �� 5]      " ��6   	 5^      �� 5_      
 6*   �� $ toggle��$ 	IsChecked� True6a   .a�5`   "   ��  � �� �#ffffff6?   5a      �� 5c      
 6*   �� $ toggle��$ 	IsChecked�	 False6a   .a�5d   "   ��  � �� �#2f2c376?   5e      5g      5i      5j      5k      5l      