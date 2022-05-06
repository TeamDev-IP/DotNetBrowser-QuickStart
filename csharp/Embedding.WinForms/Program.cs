using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

namespace Embedding.WinForms
{
    static class Program
    {
        private static readonly TraceSource Log = new TraceSource("Embedding.WinForms");
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            AppDomain.CurrentDomain.UnhandledException += OnUnhandledException;
            Application.ThreadException += OnThreadException;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        private static void OnThreadException(object sender, ThreadExceptionEventArgs e)
        {
            LogError($"Unhandled exception in main thread : {e.Exception}");
        }

        private static void OnUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            LogError($"Unhandled exception in current domain : {(Exception)e.ExceptionObject}");
        }

        private static void LogError(string message)
        {
            Console.Error.WriteLine(message);
            Log.TraceEvent(TraceEventType.Error, 1, message);
        }
    }
}
