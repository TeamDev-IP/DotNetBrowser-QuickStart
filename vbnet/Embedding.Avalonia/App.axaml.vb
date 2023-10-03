Imports Avalonia
Imports Avalonia.Controls.ApplicationLifetimes
Imports Avalonia.Markup.Xaml

Partial Public Class App
	Inherits Application

	Public Overrides Sub Initialize()
		AvaloniaXamlLoader.Load(Me)
	End Sub

	Public Overrides Sub OnFrameworkInitializationCompleted()
		Dim tempVar As Boolean = TypeOf ApplicationLifetime Is IClassicDesktopStyleApplicationLifetime
		Dim desktop As IClassicDesktopStyleApplicationLifetime = If(tempVar, CType(ApplicationLifetime, IClassicDesktopStyleApplicationLifetime), Nothing)
		If tempVar Then
			desktop.MainWindow = New MainWindow()
		End If

		MyBase.OnFrameworkInitializationCompleted()
	End Sub
End Class