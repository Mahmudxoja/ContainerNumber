using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContainerNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string container_number = "";
            string container_type = "";

            do
            {
                Hint();
                Console.WriteLine("Please, enter container number: ");

                container_number = Console.ReadLine().ToUpper();
                Console.Clear();
                container_type = Container.TypeContainer(container_number);
            } while (container_type == null);

            Console.WriteLine("Container number {0}", container_number);
            Console.WriteLine("Container type is {0}", container_type);
            if (container_type == "large")
            {
                if (Container.LargeContainer(container_number, out int true_last_number))
                    Console.WriteLine("Container number is TRUE!");
                else
                {
                    Console.WriteLine("Container number is FALSE!");
                    Console.WriteLine("Last number should be {0}", true_last_number);
                }
            }
            else
            {
                if (Container.MediumContainer(container_number, out int true_last_number))
                    Console.WriteLine("Container number is TRUE!");
                else
                {
                    Console.WriteLine("Container number is FALSE!");
                    Console.WriteLine("Last number should be {0}", true_last_number);
                }
            }
            Console.ReadKey();
        }

        static void Hint()
        {
            Console.WriteLine(@"*********************************************************************
* The number of a large-capacity container consists of 11 characters, 
* including 4 letters and 7 digits(for example, OOLU1263890).
* 
* Room medium container consists of 9 digits(e.g. 318100531)
*********************************************************************");
        }
    }
}
