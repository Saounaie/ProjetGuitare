   M S B A M L   `   `   `  ����J  FFabrication_IHM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Fabrication_IHMFabrication_IHM  5   	   $    Fabrication_IHM.AddMicroWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:Fabrication_IHM     5   	     � Title$  AddMicroWindow��5   	   $	��450��6    $	��800��6-    � WindowStartupLocation$ CenterScreen=�69   .��5	      � $��Center=�6   $��Center=�6(   $	��600��6C    � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $��0��6   $��Nom du micro :��6-   $��10q�6F   $��Center=�6R   �� 5   
   -   5         ��Name$ nomMicroTBX��5      $��0��6'   $��1��64   $��10q�6D   $	��200��6P   �� 5   
   $��1��6   $��0��6   $��Caractéristiques :��6-   $��10q�6J   $��Center=�6V   �� 5   
   -   5        $ caractMicroTBX��5      $��1��6*   $��1��67   $��10q�6G   $	��200��6S   $	��100��6_   �� 5   
   $��2��6   $��0��6   $��Stock :��6-   $��10q�6?   �� 5   
   -   5        $ stockMicTBX��5      $��2��6'   $��1��64   $��10q�6E   $	��200��6Q   �� 5    
   $��4��6   $��1��6"    �� Orientation$ 
Horizontal=�62   $��Right=�6K   $��10q�6g   .+�5!      �� -   5         ��Name$ cancelAddMicroBTN��5!      $��Annuler��60   $��10q�6B   $��80��6N   6Y   �� 5"      -   5        $ addMicroBTN��5"      $��Ajouter��6*   $��10q�6V   $��80��6b   5#      5$      5%      