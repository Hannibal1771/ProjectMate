   M S B A M L   `   `   `  ����B  >Company, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:CompanyCompany  5   	       Company.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Company     5   	   -   5          � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)    � WindowStyle$
 None=�65    � 
ResizeMode$ NoResize=�6H    � WindowStartupLocation$ CenterScreen=�6^    � 	Resources 5	       �� 
TargetType �� Property �� Value   SB(Loading) g� RepeatBehavior	 �� TargetProperty
 �� 
TargetName9  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime O� Value��%	  '�       &	  P     �� 5
   
   " �6   .�5      ��  � �� �	#FF382F2F6+   5      �� 5   
   $ Forever��6)   .��5      U� $V	 P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleY)�6,   $
 	rectangle��6�   .\�5        $ 0��6'   $ 1.417Q�63     5      $ 0:0:0.8��6'   $ 0.959Q�69   5      U� 5      $U	 O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.Y)�6,   $
 	rectangle��6�   .\�5        $ 0��6'   $ -6.25Q�63     5      $ 0:0:0.8��6'   $ 0.625Q�69   5      U� 5      $V	 P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleY)�6,   $
 
rectangle1��6�   .\�5        $ 0��6'   $ 1Q�63     5      $ 0:0:0.4��6'   $ 1.458Q�69     5      $ 0:0:0.8��6'   $ 0.958Q�69   5      U� 5      $U	 O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.Y)�6,   $
 
rectangle1��6�   .\�5        $ 0��6'   $ 0Q�63     5      $ 0:0:0.4��6'   $ -6.875Q�69     5      $ 0:0:0.8��6'   $ 0.625Q�69   5      U� 5       $V	 P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleY)�6,   $
 
rectangle2��6�   .\�5!        $ 0:0:0.2��6'   $ 1Q�69     5"      $ 0:0:0.5��6'   $ 1.458Q�69     5#      $ 0:0:0.8��6'   $ 1.041Q�69   5$      U� 5%      $U	 O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.Y)�6,   $
 
rectangle2��6�   .\�5&        $ 0:0:0.2��6'   $ 0Q�69     5'      $ 0:0:0.5��6'   $ -6.875Q�69     5(      $ 0:0:0.8��6'   $ -0.625Q�69   5)      U� 5*      $V	 P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleY)�6,   $
 
rectangle3��6�   .\�5+        $ 0:0:0.4��6'   $ 1Q�69     5,      $ 0:0:0.6��6'   $ 1.458Q�69     5-      $ 0:0:0.8��6'   $ 0.958Q�69   5.      U� 5/      $U	 O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.Y)�6,   $
 
rectangle3��6�   .\�50        $ 0:0:0.4��6'   $ 0Q�69     51      $ 0:0:0.6��6'   $ -6.875Q�69     52      $ 0:0:0.8��6'   $ 0.625Q�69   53      54      55       � Triggers 56      :� 57   
    :� RoutedEvent$ FrameworkElement.Loaded��6   .[�58      �� -   5         ��Name$! SB_Loading__BeginStoryboard��58      #��[  6C   �� 59      #��[  6   5:      .��5<      � .+�5=   
   �� $
��Left=�6   $��393.75,390,0,10q�6/   $
��Wrap=�6H   $��	Loading..��6\   
�������$��20(�6�   $��Segoe UI Light)�6�   �� 5>   
   $
��Left=�6   $��409,188,0,212q�6/   $
��Wrap=�6F   $��Company��6Z   
�������$��30(�6|   $��Microsoft YaHei UI Light)�6�   �� 5?   
   $
��Left=�6   $��751.96,418.417,0,-8.417q�6/   $
��Wrap=�6P   $
��2021��6d   
�������$��20(�6�   $��Microsoft YaHei Light)�6�   �� 5@   
   $
��Left=�6   $��295.393,185.017,0,214.983q�6/   $
��Wrap=�6R   $��Shadow��6f   
�������$��31(�6�   $��Yu Gothic UI)�6�   A� 5A   
   $
��Left=�6   $��41.25��6-   $��540.117,163.75,0,0q�6<   
���   �$	��Top=�6g   $��41.133��6   ��5B      �� 5C       �� EndPoint$ 0.5,1&�6&    �� 
StartPoint$ 0.5,0&�67   .��5D      �  � Color$ 	#FF382F2F��6#    � Offset$ 0.427Q�65   � 5E      $ White��6#   $ 1Q�61   5F      5H      �� 5I   
   -   5         ��Name$ 	rectangle��5I      $
��Left=�6'   $��30��6B   $��363.75,342.5,0,0q�6N   
���   �$	��Top=�6w   $��30��6�   
������� J� RenderTransformOrigin$ 0.5,0.5&�6�   z�5J      V� 5K      .~�5L      �� �� 5M      �� 5N      T� 5O      5P      5R      �� 5S   
   -   5        $ 
rectangle1��5S      $
��Left=�6(   $��30��6C   $��393.75,342.5,0,0q�6O   
���   �$	��Top=�6x   $��30��6�   
�������$ 0.5,0.5&�6�   z�5T      V� 5U      .~�5V      �� �� 5W      �� 5X      T� 5Y      5Z      5\      �� 5]   
   -   5        $ 
rectangle2��5]      $
��Left=�6(   $��30��6C   $��423.75,342.5,0,0q�6O   
���   �$	��Top=�6x   $��30��6�   
�������$ 0.5,0.5&�6�   z�5^      V� 5_      .~�5`      �� �� 5a      �� 5b      T� 5c      5d      5f      �� 5g   
   -   5        $ 
rectangle3��5g      $
��Left=�6(   $��30��6C   $��453.75,342.5,0,0q�6O   
���   �$	��Top=�6x   $��30��6�   
�������$ 0.5,0.5&�6�   z�5h      V� 5i      .~�5j      �� �� 5k      �� 5l      T� 5m      5n      5p      5q      5r      