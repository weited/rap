   M S B A M L   `   `   `  ????>  :RAP, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:RAP.ViewRAP.View  5      !    RAP.View.ResearcherListView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      (localclr-namespace:RAP.View     5      ???	#FF405764  ? 	Resources  5         researcherList  ResearcherController S? ObjectInstance S? 
MethodName??%I   &	        7  S? 5   
   8   $ LoadResearchers??5      5      5      .??5      ? ???	#FF405764.+?5   
   ?? -   5         ??Name$ ResearcherNameList??5       ?? Orientation$ Vertical=?61   $??10,10,10,10q?6H   ???	#FF405764.+?5      ?  ? RowDefinitions 5      ?? 5      ?? 5      ?? 5      ?? 5       ?? 5!      ?? 5"      ?? 5#      .+?5&      ?? $??0??6   $??Filter by name??6%   ???#f26d65$??
10,30,10,0q?6S   $??14(?6g   $
??Bold"?6u   ???	#FF4057646?   ?? 5'      -   5         ??Name$ 
FilterName??5'   '   $??2??6    ?? TextWrapping$
 Wrap=?6;   $
??auto??6O   $??5 0 5 0q?6x   ?? 5(      -   5         ??Name$ 	emp_Level??5(   )   $??3??6   $??5 0 5 0q?6[   $
??Bold"?6l   ???#f26d65.@?5)      ?? 	 ?? 
IsSelected	 . $??All Researchers??65   ?? 5*      .??6$   Student only62   ?? 5+      .??6#   	A Postdoc6.   ?? 5,      .??6#   
B Lecturer6/   ?? 5-      .??6#   C Senior Lecturer66   ?? 5.      .??6#   D Associate Professo69   ?? 5/      .??6#   E Professor Students69   50      ?? 53      -   5        $??ResearchersName??53   (   $??5??6   $??5 0 5 0q?6?   $??80??6?   $??80??6?   ??6A   ?? 
 ?? Source#
 [  6?   ?? 54      -   5        $??6??54      $??Generate Report??6&   $??
10,4,10,10q?6@   6T   57      59      5<      5=      