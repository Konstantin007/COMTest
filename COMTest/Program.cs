using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;

namespace COMTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Modul7018 modul = new Modul7018("COM7");

            Console.WriteLine("Port is opened");
            Random r = null;
            int x = 0;

            int i = 1;
            do
            {
                r = new Random();
                x = r.Next(99);
                                
                modul.writeToPort("@02"+x);
                Console.WriteLine(modul.readFromPort());

                modul.writeToPort("@02");
                Console.WriteLine(modul.readFromPort());

                i++;
            } while (i < 2);

            
            
            modul.closePort();
            Console.WriteLine("Port is closed");
            Console.ReadKey();
        }
    }
}
