using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML;
using SFML.Graphics;
using SFML.Window;

namespace Standart1
{
    class Program
    {
       
        static void Main(string[] args)
        {
            RenderWindow Startscreen = new RenderWindow(new VideoMode(1024, 768), "Window1");
            while (Window.IsOpen) ;
            Window.Closed += WindowClosed;
          

        }



        public static EventHandler WindowClosed { object sender; EventArgs e; }
        ((RenderWindow) sender).close();
        Window.DispatchEvent(); 
    }
}
