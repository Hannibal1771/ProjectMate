   M S B A M L   `   `   `  ���� B  >Company, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:CompanyCompany      Company.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     'localclr-namespace:Company     -     � Title$  
MainWindow��$	��450��$	��800�� � WindowStyle$
 None=� � 
ResizeMode$ NoResize=� � WindowStartupLocation$ CenterScreen=� � 	Resources  �� 
TargetType �� Property �� Value   SB(Loading) g� RepeatBehavior	 �� TargetProperty
 �� 
TargetName9  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime O� Value��%M  '�       &	  +     �� " �.���  � �� �	#FF382F2F�� $ Forever��.��U� $V	 P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleY)�$
 	rectangle��.\�  $ 0��$ 1.417Q�  $ 0:0:0.8��$ 0.959Q�U� $U	 O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.Y)�$
 	rectangle��.\�  $ 0��$ -6.25Q�  $ 0:0:0.8��$ 0.625Q�U� $V	 P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleY)�$
 
rectangle1��.\�  $ 0��$ 1Q�  $ 0:0:0.4��$ 1.458Q�  $ 0:0:0.8��$ 0.958Q�U� $U	 O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.Y)�$
 
rectangle1��.\�  $ 0��$ 0Q�  $ 0:0:0.4��$ -6.875Q�  $ 0:0:0.8��$ 0.625Q�U� $V	 P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleY)�$
 
rectangle2��.\�  $ 0:0:0.2��$ 1Q�  $ 0:0:0.5��$ 1.458Q�  $ 0:0:0.8��$ 1.041Q�U� $U	 O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.Y)�$
 
rectangle2��.\�  $ 0:0:0.2��$ 0Q�  $ 0:0:0.5��$ -6.875Q�  $ 0:0:0.8��$ -0.625Q�U� $V	 P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleY)�$
 
rectangle3��.\�  $ 0:0:0.4��$ 1Q�  $ 0:0:0.6��$ 1.458Q�  $ 0:0:0.8��$ 0.958Q�U� $U	 O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.Y)�$
 
rectangle3��.\�  $ 0:0:0.4��$ 0Q�  $ 0:0:0.6��$ -6.875Q�  $ 0:0:0.8��$ 0.625Q� � Triggers :�  :� RoutedEvent$ FrameworkElement.Loaded��.[��� -    ��Name$! SB_Loading__BeginStoryboard��#��[  �� #��[  .��� .+��� $
��Left=�$��393.75,390,0,10q�$
��Wrap=�$��	Loading..��
�������$��20(�$��Segoe UI Light)��� $
��Left=�$��409,188,0,212q�$
��Wrap=�$��Company��
�������$��30(�$��Microsoft YaHei UI Light)��� $
��Left=�$��751.96,418.417,0,-8.417q�$
��Wrap=�$
��2021��
�������$��20(�$��Microsoft YaHei Light)��� $
��Left=�$��295.393,185.017,0,214.983q�$
��Wrap=�$��Shadow��
�������$��31(�$��Yu Gothic UI)�A� $
��Left=�$��41.25��$��540.117,163.75,0,0q�
���   �$	��Top=�$��41.133������  �� EndPoint$ 0.5,1&� �� 
StartPoint$ 0.5,0&�.���  � Color$ 	#FF382F2F�� � Offset$ 0.427Q�� $ White��$ 1Q��� -    ��Name$ 	rectangle��$
��Left=�$��30��$��363.75,342.5,0,0q�
���   �$	��Top=�$��30��
������� J� RenderTransformOrigin$ 0.5,0.5&�z�V� .~��� �� �� T� �� -   $ 
rectangle1��$
��Left=�$��30��$��393.75,342.5,0,0q�
���   �$	��Top=�$��30��
�������$ 0.5,0.5&�z�V� .~��� �� �� T� �� -   $ 
rectangle2��$
��Left=�$��30��$��423.75,342.5,0,0q�
���   �$	��Top=�$��30��
�������$ 0.5,0.5&�z�V� .~��� �� �� T� �� -   $ 
rectangle3��$
��Left=�$��30��$��453.75,342.5,0,0q�
���   �$	��Top=�$��30��
�������$ 0.5,0.5&�z�V� .~��� �� �� T� 