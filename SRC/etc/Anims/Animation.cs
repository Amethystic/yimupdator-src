using System;
using System.Threading.Tasks;

namespace YimUpdater.SRC.etc.Anims
{
    internal class Animation
    {
        public static void Do()
        {
            Console.Title = "Yim is starting up...";
            Console.Clear();
            Console.WriteLine(@"_/      _/  _/                               
 _/  _/        _/_/_/  _/_/                  
  _/      _/  _/    _/    _/                 
 _/      _/  _/    _/    _/                  
_/      _/  _/    _/    _/                   ");
            Task.Delay(1200).Wait();
            Console.WriteLine(@"    _/      _/                               
   _/_/  _/_/    _/_/    _/_/_/    _/    _/  
  _/  _/  _/  _/_/_/_/  _/    _/  _/    _/   
 _/      _/  _/        _/    _/  _/    _/    
_/      _/    _/_/_/  _/    _/    _/_/_/     ");
            Task.Delay(1500).Wait();
            Console.Clear();
            Console.WriteLine(@"
_/      _/  _/                               
 _/  _/        _/_/_/  _/_/                  
  _/      _/  _/    _/    _/                 
 _/      _/  _/    _/    _/                  
_/      _/  _/    _/    _/                   
    _/      _/                               
   _/_/  _/_/    _/_/    _/_/_/    _/    _/  
  _/  _/  _/  _/_/_/_/  _/    _/  _/    _/   
 _/      _/  _/        _/    _/  _/    _/    
_/      _/    _/_/_/  _/    _/    _/_/_/ .     

");
            Task.Delay(500).Wait();
            Console.Clear();
            Console.WriteLine(@"
_/      _/  _/                               
 _/  _/        _/_/_/  _/_/                  
  _/      _/  _/    _/    _/                 
 _/      _/  _/    _/    _/                  
_/      _/  _/    _/    _/                   
    _/      _/                               
   _/_/  _/_/    _/_/    _/_/_/    _/    _/  
  _/  _/  _/  _/_/_/_/  _/    _/  _/    _/   
 _/      _/  _/        _/    _/  _/    _/    
_/      _/    _/_/_/  _/    _/    _/_/_/ . .   

");
            Task.Delay(500).Wait();
            Console.Clear();
            Console.WriteLine(@"
_/      _/  _/                               
 _/  _/        _/_/_/  _/_/                  
  _/      _/  _/    _/    _/                 
 _/      _/  _/    _/    _/                  
_/      _/  _/    _/    _/                   
    _/      _/                               
   _/_/  _/_/    _/_/    _/_/_/    _/    _/  
  _/  _/  _/  _/_/_/_/  _/    _/  _/    _/   
 _/      _/  _/        _/    _/  _/    _/    
_/      _/    _/_/_/  _/    _/    _/_/_/ . . . 

");
            Task.Delay(2000).Wait();
            End();

        }
        public static void End()
        {
            Console.Title = "YimMenu";
            InstallationProcess.InstallStart();
        }
    }
}
