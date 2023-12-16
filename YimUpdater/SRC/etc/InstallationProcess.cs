using System;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using YimUpdater.SRC.etc.Anims;

namespace YimUpdater.SRC.etc
{
    internal class InstallationProcess
    {
        public static string yimpath = "YimMenu";
        public static string DLL = "YimMenu.dll";
        public static string ZIP = "YimMenu.zip";
        public static string Launcher = "gtalauncher.exe";
        public static string Injector = "YimMenuAutoInjector.exe";
        public static string InjectorLaucnher = "IIL.exe";
        public static string Documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        public static string folderPath = Path.Combine(Documents, yimpath);
        public static string InjectorPath = Path.Combine(Documents, yimpath, Injector);
        public static string ZIPPath = Path.Combine(Documents, ZIP);
        public static string CustLauncherPath = Path.Combine(Documents, yimpath, Launcher);
        public static string ILLauncherPath = Path.Combine(Documents, yimpath, InjectorLaucnher);
        public static string DLLPath = Path.Combine(Documents, yimpath, DLL);

        public static bool GTA5Open = false;

        public static void InstallStart()
        {
            Install_Anim.Call_StartInstAnim();
            Create_Folders();
        }
        static void Create_Folders()
        {
            Install_Anim.Call_Folders();

            try
            {
                if (Directory.Exists(folderPath))
                {
                    Console.WriteLine("Directory is existing already");
                    Task.Delay(2000).Wait();
                }
                else
                {
                    Directory.CreateDirectory(folderPath);
                }
                Install_Requirements();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
        static void Install_Requirements()
        {
            Install_Anim.Call_Requirements();

            if (File.Exists(DLLPath))
            {
                Console.WriteLine($"DLL already exists, Updating it.");
                Update();
            }
            else
            {
                Download();
            }
        }
        static void Download()
        {
            Install_Anim.Call_StartInstAnim();
            using (WebClient webClient = new WebClient())
            {
                try
                {
                    ManualResetEvent downloadCompleted = new ManualResetEvent(false);
                    webClient.DownloadFileCompleted += (sender, e) =>
                    {
                        if (e.Error == null) { Console.WriteLine("YimMenu | File downloaded successfully."); }
                        else { Console.WriteLine($"Download failed: {e.Error.Message}"); }
                        downloadCompleted.Set();
                    };

                    webClient.DownloadFileAsync(new Uri("https://github.com/YimMenu/YimMenu/releases/download/nightly/YimMenu.dll"), DLLPath);
                    downloadCompleted.WaitOne();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Download failed: {ex.Message}");
                }

                try
                {
                    ManualResetEvent downloadCompleted = new ManualResetEvent(false);
                    webClient.DownloadFileCompleted += (sender, e) =>
                    {
                        if (e.Error == null) { Console.WriteLine("YimMenuAutoInjector | File downloaded successfully."); }
                        else { Console.WriteLine($"Download failed: {e.Error.Message}"); }
                        downloadCompleted.Set();
                    };

                    webClient.DownloadFileAsync(new Uri("https://github.com/Amethystic/yimupdator-src/releases/download/etc/YimMenuAutoInjector.exe"), InjectorPath);
                    downloadCompleted.WaitOne();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Download failed: {ex.Message}");
                }

                try
                {
                    ManualResetEvent downloadCompleted = new ManualResetEvent(false);
                    webClient.DownloadFileCompleted += (sender, e) =>
                    {
                        if (e.Error == null) { Console.WriteLine("gtalauncher | File downloaded successfully."); }
                        else { Console.WriteLine($"Download failed: {e.Error.Message}"); }
                        downloadCompleted.Set();
                    };

                    webClient.DownloadFileAsync(new Uri("https://github.com/Amethystic/yimupdator-src/releases/download/etc/gtalauncher.exe"), CustLauncherPath);
                    downloadCompleted.WaitOne();

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Download failed: {ex.Message}");
                }

                try
                {
                    ManualResetEvent downloadCompleted = new ManualResetEvent(false);
                    webClient.DownloadFileCompleted += (sender, e) =>
                    {
                        if (e.Error == null) { Console.WriteLine("ILL (Inject Launcher since C# gay | File downloaded successfully."); }
                        else { Console.WriteLine($"Download failed: {e.Error.Message}"); }
                        downloadCompleted.Set();
                    };

                    webClient.DownloadFileAsync(new Uri("https://github.com/Amethystic/yimupdator-src/releases/download/etc/IIL.exe"), ILLauncherPath);
                    downloadCompleted.WaitOne();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Download failed: {ex.Message}");
                }

                Launch();
            }
        }

        static void Update()
        {
            Install_Anim.Call_Update();
            using (WebClient webClient = new WebClient())
            {
                try
                {
                    ManualResetEvent downloadCompleted = new ManualResetEvent(false);
                    webClient.DownloadFileCompleted += (sender, e) =>
                    {
                        if (e.Error == null) { Console.WriteLine("YimMenu | File downloaded successfully."); }
                        else { Console.WriteLine($"Download failed: {e.Error.Message}"); }
                        downloadCompleted.Set();
                    };

                    webClient.DownloadFileAsync(new Uri("https://github.com/YimMenu/YimMenu/releases/download/nightly/YimMenu.dll"), DLLPath);
                    downloadCompleted.WaitOne();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Download failed: {ex.Message}");
                }

                try
                {
                    ManualResetEvent downloadCompleted = new ManualResetEvent(false);
                    webClient.DownloadFileCompleted += (sender, e) =>
                    {
                        if (e.Error == null) { Console.WriteLine("YimMenuAutoInjector | File downloaded successfully."); }
                        else { Console.WriteLine($"Download failed: {e.Error.Message}"); }
                        downloadCompleted.Set();
                    };

                    webClient.DownloadFileAsync(new Uri("https://github.com/Amethystic/yimupdator-src/releases/download/etc/YimMenuAutoInjector.exe"), InjectorPath);
                    downloadCompleted.WaitOne();

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Download failed: {ex.Message}");
                }

                try
                {
                    ManualResetEvent downloadCompleted = new ManualResetEvent(false);
                    webClient.DownloadFileCompleted += (sender, e) =>
                    {
                        if (e.Error == null) { Console.WriteLine("gtalauncher | File downloaded successfully."); }
                        else { Console.WriteLine($"Download failed: {e.Error.Message}"); }
                        downloadCompleted.Set();
                    };

                    webClient.DownloadFileAsync(new Uri("https://github.com/Amethystic/yimupdator-src/releases/download/etc/gtalauncher.exe"), CustLauncherPath);
                    downloadCompleted.WaitOne();

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Download failed: {ex.Message}");
                }

                try
                {
                    ManualResetEvent downloadCompleted = new ManualResetEvent(false);
                    webClient.DownloadFileCompleted += (sender, e) =>
                    {
                        if (e.Error == null) { Console.WriteLine("ILL (Inject Launcher since C# gay | File downloaded successfully."); }
                        else { Console.WriteLine($"Download failed: {e.Error.Message}"); }
                        downloadCompleted.Set();
                    };

                    webClient.DownloadFileAsync(new Uri("https://github.com/Amethystic/yimupdator-src/releases/download/etc/IIL.exe"), ILLauncherPath);
                    downloadCompleted.WaitOne();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Download failed: {ex.Message}");
                }

                Launch();
            }
        }
        static void Launch()
        {
            Install_Anim.Call_LaunchGame();

            try
            {
                ProcessStartInfo startInfo = new ProcessStartInfo(CustLauncherPath)
                {
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    RedirectStandardOutput = true,
                    RedirectStandardError = false
                };

                // Check the result of the process execution
                using (Process process = new Process { StartInfo = startInfo })
                {
                    process.Start();
                    process.WaitForExit();
                    int exitCode = process.ExitCode;

                    if (exitCode == 0)
                    {
                        WaitForGTA5ToStart();
                    }
                    else
                    {
                        Install_Anim.Call_Fail();
                    }
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        static void WaitForGTA5ToStart()
        {
            Console.WriteLine("Waiting for GTA 5 to start...");

            while (Process.GetProcessesByName("GTA5").Length == 0) { Thread.Sleep(1000); }
            Console.WriteLine("GTA 5 has started!");
            Thread.Sleep(10000);

            GTA5Open = true;
            if (GTA5Open)
            {
                Inject();
            }
            else
            {
                Install_Anim.Call_Fail();
            }
        }

        static void Inject()
        {
            string yimpath = "YimMenu";
            string Injector = "IIL.exe";
            string Documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string fullPath = Path.Combine(Documents, yimpath, Injector);

            Install_Anim.Call_Inject();
            try
            {
                if (GTA5Open)
                {
                    ProcessStartInfo startInfo = new ProcessStartInfo(fullPath)
                    {
                        FileName = fullPath,
                        UseShellExecute = true,  // Use the shell to execute the process
                        CreateNoWindow = false   // Show the window of the new process
                    };

                    using (Process process = Process.Start(startInfo))
                    {
                        process.WaitForExit();
                        int exitCode = process.ExitCode;

                        if (exitCode == 0)
                        {
                            Thread.Sleep(5000);
                            Install_Anim.Call_Success();
                        }
                        else
                        {
                            Thread.Sleep(5000);
                            Install_Anim.Call_Fail();
                        }
                    }
                }
                else
                {
                    Thread.Sleep(5000);
                    Install_Anim.Call_Fail();
                }
            }
            finally
            {
                Thread.Sleep(5000);
                Install_Anim.Call_Success();
            }
        }
    }
}
