   M S B A M L   `   `   `  ���� b  ^Computer Science IA - Productivity Tool, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulla5clr-namespace:Computer_Science_IA___Productivity_Tool'Computer_Science_IA___Productivity_Tool  8    2Computer_Science_IA___Productivity_Tool.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     Glocal5clr-namespace:Computer_Science_IA___Productivity_Tool     U QMaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes    � Icon$"  Icons/icons8-learning-96.png�� � Title$- 'Computer Science IA - Productivity Tool�� � 
ResizeMode$ CanMinimize=�$	��800��$��615.75�� � WindowStartupLocation$ CenterScreen=�
����������#FAFAFA � 	Resources    MenuOpen �� TargetProperty �� 
TargetName9  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime O� Value  	MenuClose��%�   &	        &	 r     �� .��U� $ (FrameworkElement.Width)�$ GridMenu��.\�  $ 0��$ 70Q�  $ 0:0:0.25��$	 200Q��� .��U� $ (FrameworkElement.Width)�$ GridMenu��.\�  $ 0��$	 200Q�  $ 0:0:0.25��$ 60Q�	 � Triggers	 :� 
 :� RoutedEvent$
 ButtonBase.Click�� :� 
SourceName$ ExpandMenuButton��.[��� #��[  :� $
 ButtonBase.Click��$ ShrinkMenuButton��.[��� #��[ .���� $��Visible=�$��1q�.��� .+��� $��Stretch=�$	��Top=�$
��0 48q����#7a7a7a$��1��� $��48��$	��Top=�.+��� $��Center=�$��Right=� �� Orientation$ 
Horizontal=�.+��� $��Prithvi Vijaykumar�����#606060$��Center=�$��14(�$��0 0 10 0q��� $����C:\Users\Aak242\source\repos\Computer Science IA - Productivity Tool\Computer Science IA - Productivity Tool\Icons\icons8-male-user-filled-96.png��$��30��$��30��$��0 0 15 0q�� $��
0, 0, 0, 0q�.+�� -    �Name$ GridPrincipal��� -   $ GridMenu��$��55��$
��Left=����#f1f1f1.+��� .+�� $	��150�����#006ce5.+��� -    ��Name$ ShrinkMenuButton��$
��49.2��$
��49.2��$	��Top=�$��Right=�$y�	Collapsed=���Z� ��Z� .��'  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=null]]   Kind$ 	ArrowLeft=�$��21��$��29���� -   $ ExpandMenuButton��$
��49.2��$
��49.2��$	��Top=�$��Right=���Z� ��Z� .��  $
 Menu=�$��Center=�$��Center=�$��-20 10 -10 0q�$��25��$��25���� -    ��Name$ ListViewMenu��$��Disabled=����#606060 �� SelectedIndex$ 0��.@��� $
��49.2��.���� $ 
Horizontal=�.+�  $ 	ViewArray=�$��9q�$��25��$��22��$��Center=��� $��VIEW ALL TASKS��$��Center=�$
��15 0q�$��15(�$��Segoe UI Semibold)��� $
��49.2��.���� $ 
Horizontal=�.+�  $	 Add=�$��9q�$��25��$��22��$��Center=��� $��ADD/EDIT TASKS��$��Center=�$
��15 0q�$��15(�$��Segoe UI Semibold)��� $
��49.2��.���� $ 
Horizontal=�.+�  $ Calendar=�$��9q�$��25��$��22��$��Center=��� $��CALENDAR��$��Center=�$
��15 0q�$��15(�$��Segoe UI Semibold)�