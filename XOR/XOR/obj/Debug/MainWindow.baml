   M S B A M L   `   `   `  ����>  :XOR, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:XORXOR  5   	       XOR.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   #localclr-namespace:XOR     5   	     � Title$  XOR шифр��5   	   $	��900��6   $
��1600��6'    � Icon$ 	icon2.ico��64    � WindowStartupLocation$ CenterScreen=�6E   ���#808080.��5	      � .+�5
   
   �� -   5         ��Name$ TextBoxInput��5
      $	��500��6(   $	��600��65   $��
100,50,0,0q�6A   $	��Top=�6U    �� TextWrapping$
 Wrap=�6m   $
��Left=�6�      TextBoxStyleSecond#���   6�   $r��lЗдесь Вы можете ввести текст для шифрования(расшифрования)��6�   6  �� 5   
   -   5        $ TextBoxOutput��5      $	��500��6)   $	��600��66   $��
900,50,0,0q�6B   $	��Top=�6V   $
 Wrap=�6n   $
��Left=�6�   #���   6�    �� 
IsReadOnly .  �� IsReadOnlyCaretVisible .  $f��`Здесь появится зашифрованный (расшифрованный) текст��6�   �� 5   
   -   5        $ 
TextBoxKey��5      $	��100��6&   $	��450��63   $��0 600 800 0q�6?    �� TextAlignment$ Center=�6T   $
 Wrap=�6k   $	��Top=�6   #���   6�   $��Ключ��6�   �� 5   
   -   5        $ TextBoxCheck��5      $	��100��6(   $	��450��65   $��800 600 0 0q�6A   $ Center=�6V   $
 Wrap=�6m   $	��Top=�6�   #���   6�    .  .  $��Проверка��6�   �� 5   
   -   5         ��Name$ ButtonEncrypt��5      $	��100��6(   $	��200��65   $��	0 725 0 0q�6A   $	��Top=�6T   $��Center=�6l     ButtonStyle#��[ 6�   .��5      �� 	 �� TextAlignment$	 Center=�6     ForButtonStyle#��[ 6/   Зашифровать/�� 5      Расшифровать6,   5      �� 5   
   -   5        $ 
ButtonCopy��5      $��38��6%   $��38��61   $��1335 170 0 0q�6<     ButtonCopyStyle#��[ 6R   .��5      �� $��	copy2.png��6   $��35��6'   $��35��63   5      �� 5   
   -   5        $ 	ButtonEnc��5      $��38��6$   $��38��60   $��275 170 0 0q�6;   #��[ 6P   .��5      �� $��enc.png��6   $��35��6%   $��35��61   5      �� 5   
   -   5        $ ButtonNewShift��5      $��38��6)   $��38��65   $��0 170 1335 0q�6@   #��[ 6V   .��5      �� $��new_key.png��6   $��35��6)   $��35��65   5      5      5      