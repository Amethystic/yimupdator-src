using System;
using System.Threading.Tasks;

namespace YimUpdater.SRC.etc.Anims
{
    internal class Install_Anim
    {
        public static void Call_StartInstAnim()
        {
            Console.Clear();
            Console.WriteLine(@"

_/      _/  _/                      _/      _/                               
 _/  _/        _/_/_/  _/_/        _/_/  _/_/    _/_/    _/_/_/    _/    _/  
  _/      _/  _/    _/    _/      _/  _/  _/  _/_/_/_/  _/    _/  _/    _/   
 _/      _/  _/    _/    _/      _/      _/  _/        _/    _/  _/    _/    
_/      _/  _/    _/    _/      _/      _/    _/_/_/  _/    _/    _/_/_/     

Starting Installlation...");
            Task.Delay(2000).Wait();
        }
        public static void Call_Requirements()
        {
            Console.Clear();
            Console.WriteLine(@"

_/      _/  _/                      _/      _/                               
 _/  _/        _/_/_/  _/_/        _/_/  _/_/    _/_/    _/_/_/    _/    _/  
  _/      _/  _/    _/    _/      _/  _/  _/  _/_/_/_/  _/    _/  _/    _/   
 _/      _/  _/    _/    _/      _/      _/  _/        _/    _/  _/    _/    
_/      _/  _/    _/    _/      _/      _/    _/_/_/  _/    _/    _/_/_/     

Installing Requirements...");
            Task.Delay(2000).Wait();
        }
        public static void Call_Folders()
        {
            Console.Clear();
            Console.WriteLine(@"

_/      _/  _/                      _/      _/                               
 _/  _/        _/_/_/  _/_/        _/_/  _/_/    _/_/    _/_/_/    _/    _/  
  _/      _/  _/    _/    _/      _/  _/  _/  _/_/_/_/  _/    _/  _/    _/   
 _/      _/  _/    _/    _/      _/      _/  _/        _/    _/  _/    _/    
_/      _/  _/    _/    _/      _/      _/    _/_/_/  _/    _/    _/_/_/     

Creating Folders...");
            Task.Delay(2000).Wait();
        }
        public static void Call_LaunchGame()
        {
            Console.Clear();
            Console.WriteLine(@"

_/      _/  _/                      _/      _/                               
 _/  _/        _/_/_/  _/_/        _/_/  _/_/    _/_/    _/_/_/    _/    _/  
  _/      _/  _/    _/    _/      _/  _/  _/  _/_/_/_/  _/    _/  _/    _/   
 _/      _/  _/    _/    _/      _/      _/  _/        _/    _/  _/    _/    
_/      _/  _/    _/    _/      _/      _/    _/_/_/  _/    _/    _/_/_/     

Launching GTAV...");
            Task.Delay(2000).Wait();
        }
        public static void Call_Update()
        {
            Console.Clear();
            Console.WriteLine(@"

_/      _/  _/                      _/      _/                               
 _/  _/        _/_/_/  _/_/        _/_/  _/_/    _/_/    _/_/_/    _/    _/  
  _/      _/  _/    _/    _/      _/  _/  _/  _/_/_/_/  _/    _/  _/    _/   
 _/      _/  _/    _/    _/      _/      _/  _/        _/    _/  _/    _/    
_/      _/  _/    _/    _/      _/      _/    _/_/_/  _/    _/    _/_/_/     

Updating the DLL to the Latest Version");
            Task.Delay(2000).Wait();
        }
        public static void Call_Success()
        {
            Console.Clear();
            Console.WriteLine(@"

_/      _/  _/                      _/      _/                               
 _/  _/        _/_/_/  _/_/        _/_/  _/_/    _/_/    _/_/_/    _/    _/  
  _/      _/  _/    _/    _/      _/  _/  _/  _/_/_/_/  _/    _/  _/    _/   
 _/      _/  _/    _/    _/      _/      _/  _/        _/    _/  _/    _/    
_/      _/  _/    _/    _/      _/      _/    _/_/_/  _/    _/    _/_/_/     

We're done! Inject and enjoy");
            Task.Delay(2000).Wait();
        }
    }
}
