   M S B A M L   `   `   `  ����W  SEnterpriseMVVM.DesktopClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulla5clr-namespace:EnterpriseMVVM.DesktopClient.ViewModels'EnterpriseMVVM.DesktopClient.ViewModels  5   	   K*clr-namespace:EnterpriseMVVM.DesktopClientEnterpriseMVVM.DesktopClient  5   	   N JEnterpriseMVVM.Data, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullV>clr-namespace:EnterpriseMVVM.Data;assembly=EnterpriseMVVM.DataEnterpriseMVVM.Data 5   	   3    -EnterpriseMVVM.DesktopClient.Views.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   L
viewModels5clr-namespace:EnterpriseMVVM.DesktopClient.ViewModels     5   	   <local*clr-namespace:EnterpriseMVVM.DesktopClient     5   	   Odata>clr-namespace:EnterpriseMVVM.Data;assembly=EnterpriseMVVM.Data     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)    � 	Resources 5         VisibilityConverter �� 
TargetType �� Property �� Value��%n   &	        '��      �� 5   
   6'   �� 5   
   " ��6   .�5      ��  � ��$ 0q�6(   5      5      .��5      ]� $��30q�6   .+�5   
   ]� $
��Left=�6   $	��200��6*   $��0 0 32 0q�66   .+�5      �� $	��Top=�6   �� 5       �� Command 6   �� *AddCustomerCommand+.�6C   Add Customer6Q    �� 5       6   �� *GetCustomerListCommand+.�6G   	Refresh6P   5      �� 5      ��6   �� *	Customers+ �� SelectedItem 68   �� *SelectedCustomer+ 5       �� DataType"  EnterpriseMVVM.Data.Customer��%�  (��       5   #   *, +)�� 6   "  6#   .R�5      �� �� 5   "   $
��Bold"�6&   .�68   First Name:6F    �� 5   "   �6&   �� *	FirstName+ �� 5    "   $
��Bold"�6&   .�68   
Last Name:6E    �� 5!   "   �6&   �� *
LastName+ �� 5"   "   $
��Bold"�6&   .�68   Email:6A    �� 5#   "   �6&   �� *Email+5$      5%      5&      5'      5(      �� 5)   
   $��Right=�6   y�6,   �� *HasCustomer+ �� 	Converter# [  .+�5*      �� .��6   
First Name6    �� 5+      ��6   �� *SelectedCustomer.FirstName+	 �� ValidatesOnDataErrors$
	 True��
 �� UpdateSourceTrigger$
 PropertyChanged=��� 5.      .��6   
LastName6   �� 5/      ��6   �� *SelectedCustomer.LastName+$
	 True��$
 PropertyChanged=��� 52      .��6   Email6   �� 53      ��6   �� *SelectedCustomer.Email+$
	 True��$
 PropertyChanged=��� 56      �� 57       6   �� *SaveCustomerCommand+.�6D   Save6J    �� 58       6   �� *DeleteCustomerCommand+.�6F   Delete6N   59      5;      5<      5=      