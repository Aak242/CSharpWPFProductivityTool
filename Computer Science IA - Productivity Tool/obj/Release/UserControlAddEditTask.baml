   M S B A M L   `   `   `  ���� b  ^Computer Science IA - Productivity Tool, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulla5clr-namespace:Computer_Science_IA___Productivity_Tool'Computer_Science_IA___Productivity_Tool  I EDataGridThemes, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG4clr-namespace:DataGridThemes;assembly=DataGridThemesDataGridThemes D    >Computer_Science_IA___Productivity_Tool.UserControlAddEditTask   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     Glocal5clr-namespace:Computer_Science_IA___Productivity_Tool     U QMaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  IDataGridThemes4clr-namespace:DataGridThemes;assembly=DataGridThemes  .��� .+�?  9MaterialDesignThemes.Wpf.Transitions.TransitioningContent  -      Name$  TransitioningContentSlide��C  =MaterialDesignThemes.Wpf.Transitions.TransitioningContentBase   OpeningEffect D  >MaterialDesignThemes.Wpf.Transitions.TransitionEffectExtension  *SlideInFromLeft+   Duration$ 0:0:0.8X�.���� .+��  � ColumnDefinitions �� $��8* ��� $��4* �.+��� $ ��Add, Edit or Delete a Task��$��Bottom=�$
��Left=�$��80,0,0,73.2q����#606060$��22(�$��Segoe UI Light)�$	��242���� $��2��$��Task Description��$��Bottom=�$
��Left=�$
��0 73q����#606060$��22(�$��Segoe UI Light)��  �� $
��269* ��� $
��142* ��� $
��206* �.+��� $��0��$
��Left=�$	��250��$	��Top=�$��
80,-70,0,0q����#7a7a7a$��1��$��2���� $��1��$
��Left=�$	��195��$	��Top=�$��141.2,-70,0,0q����#7a7a7a$��1��$��2��� $	��110�� �� $
��140* ��� $	��73* �.+��� -    ��Name$ DescriptionBox�����#7a7a7a$��1��$��1q�$��Right=�$��
0,-50,10,7q�$��5q�$	��173��$��11(� �� 	IsEnabled . 
��������� -   $ txtName��$��0�����#7a7a7a$
��Left=�$	��Top=�$��
80,-50,0,0q�
������� . $��13(�$��Name of Task��$	��149��$��Segoe UI Light)��� -   $��StartTimeCombobox�� �� 
IsEditable .  �� 
IsReadOnly .  �� Text$ Task starts from:�����#7a7a7a
�������$
��Left=�$	��Top=�$��80,0,0,0q�$��13(�$	��140��$��Segoe UI Light)�.@��� .��00:00�� .��01:00�� .��02:00�� .��03:00�� .��04:00�� .��05:00�� .��06:00�� .��07:00�� .��08:00�� .��09:00�� .��10:00�� .��11:00�� .��12:00�� .��13:00�� .��14:00�� .��15:00�� .��16:00�� .��17:00�� .��18:00�� .��19:00�� .��20:00�� .��21:00�� .��22:00�� .��23:00�� -   $��EndTimeCombobox�� .  . $ Task ends at:�����#7a7a7a
�������$
��Left=�$	��Top=�$��13(�$	��140��$��	244,0,0,0q�$��Segoe UI Light)�	 J� RenderTransformOrigin$	 -0.033,0.554&�.@��� .��00:00�� .��01:00�� .��02:00�� .��03:00�� .��04:00�� .��05:00�� .��06:00�� .��07:00�� .��08:00�� .��09:00�� .��10:00�� .��11:00�� .��12:00�� .��13:00�� .��14:00�� .��15:00�� .��16:00�� .��17:00�� .��18:00�� .��19:00�� .��20:00�� .��21:00�� .��22:00�� .��23:00�� -   
 ��Name$
 NotifyCheckbox�����#7a7a7a$��
80,50,0,42q�$��0��$
��Left=�$��18��$	 0.722,1.326&��� $��0��$0��*Notify me 5 minutes before the task begins��$	��250��$��103,45,51.8,42q�$��12(�$��Segoe UI Light)��  �� $	��58* ��� $
��184* ��� $
��184* ��� $
��184* �.+��� -    ��Name$ AddTasksButton�����#606060$��1��$��
10 20 10 0q�$��Add Task��$��2q�$��Segoe UI Light)��� -   $ EditTasksButton�����#888888$��2��$��10,20,9.6,0q�$��	Edit Task��$��2q�$��Segoe UI Light)�$	��Top=��� -	   $ DeleteButton�����#ebebeb���#606060���#ebebeb$��3��$��
10 20 10 0q�$��Delete Task��$��2q�$��Segoe UI Light)�{�.  �� $��0��$��Bottom=�$
��Left=�$��	80 60 0 0q����#606060$��22(�$��Segoe UI Light)�$	��250��$��Search for Saved Tasks���� $
��Left=�$	��250��$	��Top=�$��80,0,0,0q����#7a7a7a$��1���� $	��610��$��0,-110,0 0 q����#7a7a7a$��1���  �� $��* ��� $��* �.+��� -
   $ SearchTasks��$��0�����#7a7a7a$
��Left=�$��Bottom=�$��80,20,0,0.6q�$	��0.2q�
������� . $��13(�$��Search a Task��$	��373��$��Segoe UI Light)�$��2���� -   $ SearchButton�����#606060$��1��$��170,20,30,0.2q�$��Search��$��2q�$��Segoe UI Light)�$
��Auto��&   System.Windows.Controls.DataGrid  -     Name$ DisplayTasks��$��80,30,16,30q�$	��423��   
IsReadOnly . 