#Region "Copyright"

' Copyright © 2023, TeamDev. All rights reserved.
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
Imports DotNetBrowser.Browser
Imports DotNetBrowser.Engine

Module Program
    Sub Main(args() As String)
        Dim builder = new EngineOptions.Builder()
        ' Uncomment the line below to specify your license key
        ' builder.LicenseKey = "your_license_key"

        Using engine As IEngine = EngineFactory.Create(builder.Build())
            Dim browser As IBrowser = engine.CreateBrowser()

            browser.Navigation _
                    .LoadUrl("https://quotes.toscrape.com/random").Wait()

            Dim document = browser.MainFrame.Document
            Dim quote = document.GetElementByClassName("text")?.InnerText
            Dim author = document.GetElementByClassName("author")?.InnerText

            System.Console.WriteLine(quote)
            System.Console.WriteLine($"— {author}")
        End Using
    End Sub
End Module
' #enddocfragment "Example.Console"