   M S B A M L   `   `   `  ����F  BTradingBook, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:TradingBookTradingBook  5   	       TradingBook.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:TradingBook     5   	     � Title$  
MainWindow��5   	   $
��1080��6   $
��1620��6*    � 	Resources 5
       �� 
TargetType �� Property �� Value �� 
TargetType �� Triggers P� Property P� Value	 �� 
TargetName
 :� RoutedEvent ��Name �� 
TargetName �� TargetProperty W� From	 W� To g� Duration��%Y  '��       �� 5   
   " ��6   .�5      ��  � �� 5      �� 5      " ��6&   .R�5      � #��z��6   #��z��6?   .+�5      �� $��StrecthRectangle��6(   $��Stretch=�6@   $��Stretch=�6^   ���	#FFF0F1F66z   �� 5      $��bottomRectangle��6(   $��Stretch=�6?   $��Bottom=�6]   ���	#FF575C93$��10��6�   $��	10,0,10,0q�6�   ]� 5      .+�5   "   �� $��ContentButton��63   #��z��6H   $��Center=�6l   $��Center=�6�   6�   5      5       5      P� 5       �@J�	IsFocused .  . �5   "   �� $	 bottomRectangle��6C    � �� �	#FFF0F1F66t   5      P� 5       �@J�	IsFocused . . �5   "   �� $	 ContentButton��6I    � �� �	#FF575C936x   �� 5   "   $	 ContentButton��6I    � ��$ 	ExtraBold"�6d   6x   5      :� 5       $
 Button.Click��6+   [�5!   "   �� 5"   &   $ mouseEnterBeginStoryboard��66   .��5#   *   �� .��5$   .   W� $ bottomRectangle��6>   $ Width�6f   $ 0X�6�   $	 200X�6�   $ 0:0:0.5D�6�   6�   5%   +   5&   '   5(      5*      5,      5-      5.      .��52      �  � RowDefinitions 53   
   �� 54      $��50 �6   6*   �� 55      $	��10* �6   6+   .+�5;   
   � $��0��6   $��0��5<      .+�5@      �  � ColumnDefinitions 5A      �� 5B      $��3* �6'   64   �� 5C      $��3* �6'   64   �� 5D      $��3* �6'   64   �� 5E      $��3* �6'   64   �� 5F      $��3* �6'   64   �� 5G      $��3* �6'   64   �� 5H      $��3* �6'   64   .+�5J      � $��0��6   $��0��5K      
���**��5N      � 5O      $��1��6   $��0��5P      
����ح�5S      � 5T      $��2��6   $��0��5U      
�������.+�5W      �� -   5        $��researchButton��5W   0   $��Research��6   6e   5Y      � 5Z      $��3��6   $��0��5[      
���E��.+�5]      �� -   5        $��
homeButton��5]   ,   $
��HOME��6   6>   5^      � 5_      $��4��6   $��0��5`      
�������.+�5b      �� -   5        $��tradeButton��5b   -   $��Trade��6   $
��Auto��6@   6M   5c      � 5d      $��5��6   $��0��5e      
�������5h      � 5j      $��6��6   $��0��5k      
�������.+�5m      �� -   5        $��exportButton��5m   .   $��Export��6   $
��Auto��6B   6O   5n      5q      5v      � 5z   
   -   5        $��
MainLayout��5z      $��0��6!   $��1��5{      
������.+�5         TradingBook.HomeLayout  -   5          Name$ 	HomeLaout��5      64      TradingBook.TradeLayout  5�      -   5          Name$ TradeLayout��5�       67      TradingBook.ExportLayout  5�      -   5          Name$ ExportLayout��5�   !   69       TradingBook.ResearchLayout  5�      -	   5          Name$ ResearchLayout��5�   #   6=   5�      5�      5�      