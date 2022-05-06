using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Threading;

namespace Embedding.Wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static readonly TraceSource Log = new TraceSource("Embedding.Wpf");

        private void OnUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            e.Handled = true;
            LogError($"Unhandled exception in main thread : {e.Exception}");
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            Current.DispatcherUnhandledException += OnUnhandledException;
        }
        private static void LogError(string message)
        {
            Console.Error.WriteLine(message);
            Log.TraceEvent(TraceEventType.Error, 1, message);
        }
    }
}
