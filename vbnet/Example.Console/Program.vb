#Region "Copyright"

' Copyright © 2022, TeamDev. All rights reserved.
' 
' Redistribution and use in source and/or binary forms, with or without
' modification, must retain the above copyright notice and the following
' disclaimer.
' 
' THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS
' "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT
' LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR
' A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT
' OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL,
' SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT
' LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE,
' DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY
' THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
' (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE
' OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

#End Region

' #docfragment "Example.Console"
Imports System
Imports DotNetBrowser.Browser
Imports DotNetBrowser.Engine

Namespace Example.Console
	Friend Class Program
		Public Shared Sub Main(args() As String)
			Using engine As IEngine = EngineFactory.Create()
				Dim browser As IBrowser = engine.CreateBrowser()
				browser.Navigation.LoadUrl("https://html5test.com/").Wait()
				System.Console.WriteLine($"Web page title: {browser.Title}")
			End Using

			System.Console.WriteLine("Press any key to terminate...")
			System.Console.ReadKey()
		End Sub
	End Class
End Namespace
' #enddocfragment "Example.Console"