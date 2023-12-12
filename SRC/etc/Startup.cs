using System;
using System.Threading.Tasks;
using YimUpdater.SRC.etc.Anims;

namespace YimUpdater.SRC.etc
{
    internal class Startup
    {
        public static void Do()
        {
            Console.Title = "Please wait...";
            Console.WriteLine(@"

         @@@@@@@@@@@@@@@                          
     @@@@                @@@@@@                   
  @@@                           @@@               
 @@    @@                           @@@           
@@                @                   @@@         
@@@                                      @@       
     @@@@@@@@@@@@@@@                      @@      
            @@           @@@@              @@     
            @                               @@    
           @@                                @    
           @                                 @@   
          @@                                  @@  
          @                                    @  
         @@                                    @  
         @                                     @@ 
        @@                               @@@@   @ 
        @@    @@                    @@@@        @ 
        @        @@@           @@@@             @@
        @           @@     @@@@                 @@
       %@             @@@@@@                    @@
       @@              @@@@@@@@                 @@
       @@              @@@@@@@@                 @@
       @                @@@@                    @@
       @                                        @@
      @@                                        @@
      @@                                        @ 
      @                                         @ 

");
            Task.Delay(2000).Wait();
            Console.Clear();
            Animation.Do();
        }
    }
}
