﻿using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using YimUpdater.SRC.etc.Anims;

namespace YimUpdater.SRC.etc
{
    internal class InstallationProcess
    {
        public static string yimpath = "YimMenu";
        public static string folderName2 = "dlls";
        public static string DLL = "YimMenu.dll";
        public static string ZIP = "YimMenu.zip";
        public static string Launcher = "gtalauncher.exe";

        public static string folderPath = Path.Combine(yimpath, folderName2);
        public static string ZIPPath = Path.Combine(Environment.CurrentDirectory, ZIP);
        public static string CustLauncherPath = Path.Combine(yimpath, Launcher);
        public static string DLLPath = Path.Combine(yimpath, folderName2, DLL);

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
                    Install_Requirements();
                }
                else
                {
                    Directory.CreateDirectory(folderPath);
                    Install_Requirements();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
        static void Download()
        {
            ManualResetEvent downloadCompleted = new ManualResetEvent(false);
            bool fin = false;

            using (WebClient webClient = new WebClient())
            {
                webClient.DownloadFileCompleted += (sender, e) =>
                {
                    if (e.Error == null)
                    {
                        Console.WriteLine("File downloaded successfully.");
                    }
                    else
                    {
                        Console.WriteLine($"Download failed: {e.Error.Message}");
                    }
                    downloadCompleted.Set();
                    fin = true;
                };

                webClient.DownloadFileAsync(new Uri("https://github.com/YimMenu/YimMenu/releases/download/nightly/YimMenu.dll"), DLLPath);
                downloadCompleted.WaitOne();
            }

            if (!fin)
            {
                Launch();
            }
        }
        static void Install_Requirements()
        {
            Install_Anim.Call_Requirements();

            if (File.Exists(DLLPath))
            {
                Install_Anim.Call_Update();
                Download();
                Launch();
            }
            else
            {
                Console.WriteLine($"Files don't Exist, Installing now");
                Download();
            }
        }
        static void Launch()
        {
            Install_Anim.Call_LaunchGame();
            try
            {
                Process.Start(CustLauncherPath);
                Task.Delay(5000).Wait();
                Install_Anim.Call_Success();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }
    }
}