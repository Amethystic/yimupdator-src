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

        public static string folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), yimpath);
        public static string InjectorPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), yimpath, Injector);
        public static string ZIPPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), ZIP);
        public static string CustLauncherPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), yimpath, Launcher);
        public static string DLLPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), yimpath, DLL);
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
            using (WebClient webClient = new WebClient())
            {
                Install_Anim.Call_StartInstAnim();

                try
                {
                    ManualResetEvent downloadCompleted = new ManualResetEvent(false);
                    webClient.DownloadFileCompleted += (sender, e) =>
                    {
                        if (e.Error == null) { Console.WriteLine("File downloaded successfully."); }
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
                        if (e.Error == null) { Console.WriteLine("File downloaded successfully."); }
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
                        if (e.Error == null) { Console.WriteLine("File downloaded successfully."); }
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

                Launch();
            }
        }

        static void Update()
        {
            using (WebClient webClient = new WebClient())
            {
                Install_Anim.Call_Update();

                try
                {
                    ManualResetEvent downloadCompleted = new ManualResetEvent(false);
                    webClient.DownloadFileCompleted += (sender, e) =>
                    {
                        if (e.Error == null) { Console.WriteLine("File downloaded successfully."); }
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
                        if (e.Error == null) { Console.WriteLine("File downloaded successfully."); }
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
                        if (e.Error == null) { Console.WriteLine("File downloaded successfully."); }
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

                Launch();
            }
        }
        static void Launch()
        {
            Install_Anim.Call_LaunchGame();

            try
            {
                Process.Start(CustLauncherPath);
                WaitForGTA5ToStart();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        static void WaitForGTA5ToStart()
        {
            Console.WriteLine("Waiting for GTA 5 to start...");

            while (Process.GetProcessesByName("GTA5").Length == 0)
            {
                // Sleep for a short duration before checking again
                Thread.Sleep(1000);
            }
            Thread.Sleep(1000);
            Console.WriteLine("GTA 5 has started!");
            GTA5Open = true;
            Thread.Sleep(5000);
            Inject();
        }

        static void Inject()
        {
            Install_Anim.Call_Inject();

            if (!GTA5Open)
            {
                try
                {
                    Process.Start(Injector);
                    Thread.Sleep(5000);
                    Install_Anim.Call_Success();
                }
                catch (Exception)
                {
                    Thread.Sleep(5000);
                    Install_Anim.Call_Fail();
                }
            }
            else
            {
                Thread.Sleep(5000);
                Install_Anim.Call_Fail();
            }
        }
    }
}
