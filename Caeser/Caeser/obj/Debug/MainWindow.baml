   M S B A M L   `   `   `  ����A  =Caeser, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:CaeserCaeser  5   	       Caeser.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:Caeser     5   	     � Title$  Шифр Цезаря��5   	   $	��900��6   $
��1600��6*    � Icon$ 	icon2.ico��67    � WindowStartupLocation$ CenterScreen=�6H   ���#808080.��5	      � .+�5
   
   �� -   5         ��Name$ TextBoxInput��5
      $	��500��6(   $	��600��65   $��100,100,0,0q�6A   $	��Top=�6V    �� TextWrapping$
 Wrap=�6n   $
��Left=�6�      TextBoxStyleSecond#���   6�   $r��lЗдесь Вы можете ввести текст для шифрования(расшифрования)��6�   6  �� 5   
   -   5        $ TextBoxOutput��5      $	��500��6)   $	��600��66   $��900,100,0,0q�6B   $	��Top=�6W   $
 Wrap=�6o   $
��Left=�6�   #���   6�    �� 
IsReadOnly .  �� IsReadOnlyCaretVisible .  $f��`Здесь появится зашифрованный (расшифрованный) текст��6�   �� 5   
   -   5        $ 
TextBoxKey��5      $��50��6&   $	��150��62   $��	0 700 0 0q�6>   $	��Top=�6Q   #���   6i   $��Ключ��6�   �� 5   
   -   5         ��Name$ ButtonEncrypt��5      $��Зашифровать��6(   $��50��6>   $	��200��6J   $��300 750 0 0q�6V   $	��Top=�6k   $
��Left=�6�     ButtonStyle#��[ 6�   6�   �� 5   
   -   5        $ ButtonDecrypt��5      $��Расшифровать��6(   $��50��6?   $	��200��6K   $��1100 750 0 0q�6W   $	��Top=�6m   $
��Left=�6�   #��[ 6�   6�   �� 5   
   -   5        $ 
ButtonCopy��5      $��38��6%   $��38��61   $��1330 260 0 0q�6<     ButtonCopyStyle#��[ 6R   .��5      �� $��copy.png��6   $��35��6&   $��35��62   5      5      5      