﻿#region Copyright

// Copyright © 2022, TeamDev. All rights reserved.
// 
// Redistribution and use in source and/or binary forms, with or without
// modification, must retain the above copyright notice and the following
// disclaimer.
// 
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS
// "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT
// LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR
// A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT
// OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL,
// SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT
// LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE,
// DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY
// THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
// (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE
// OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

#endregion

// #docfragment "Example.Console"
using System;
using DotNetBrowser.Browser;
using DotNetBrowser.Engine;

namespace Example.Console
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            EngineOptions.Builder builder = new EngineOptions.Builder();
            // Uncomment the line below to specify your license key
            //builder.LicenseKey = "your_license_key";

            using (IEngine engine = EngineFactory.Create(builder.Build()))
            {
                IBrowser browser = engine.CreateBrowser();
                browser.Navigation
                       .LoadUrl("https://html5test.com/").Wait();
                string title = browser.Title;
                System.Console.WriteLine($"Web page title: {title}");
            }
        }
    }
}
// #enddocfragment "Example.Console"