   M S B A M L   `   `   `  ����>  :XOR, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:XORXOR  5   	       XOR.WindowExplanation   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   #localclr-namespace:XOR     5   	     � Title$  XOR шифр��5   	   $	��550��6   $
��1000��6'    � Icon$ 	icon2.ico��64    � WindowStartupLocation$ CenterScreen=�6E   ���#808080.��5	      � .+�5
   
   �� -   5         ��Name$ TextBoxExplonation��5
      $	��250��6.   $	��900��6;   $	��Top=�6G   $��0 50 0 0q�6_    �� TextWrapping$
 Wrap=�6r      TextBoxStyle#��[  6�    �� 
IsReadOnly .  �� IsReadOnlyCaretVisible .  .��6�   ��Это - XOR шифр. Перед Вами будут 4 окна для ввода шифра, ввода ключа, вывода зашифрованного текста, а также для проверки работы шифра. Есть возможность скопировать текст из окна вывода. Выберете режим шифрования и нажмите "ОК!"5      �� 5   
    �� Orientation$ 
Horizontal=�6   $	��Top=�6.   $��Center=�6F   $��	0 350 0 0q�6d   $��68��6w   .+�5      	� -   5         	�Name$ 	AutoShift��5      $+��%Автоматический ключ��6-   $��20q�6K   	 d� 	IsChecked$
	 TrueY�6W     RadioButtonStyle#��[ 6h   	� 5      -   5        $ ManualShift��5      $&�� Ручной ввод ключа��6/   $��20q�6K   #��[ 6W   5      �� 5   
   -   5        
 ��Name$
 ButtonOkExplonation��5      $	��OK!��6.   $��50��6<   $	��200��6H   $	��Top=�6T   $��	0 450 0 0q�6l     ButtonStyle#��[ 6   6�   5      5      