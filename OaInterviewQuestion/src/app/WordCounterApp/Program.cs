using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using WordCounterApi;

namespace WordCounterApp
{
    class Program
    {
        static int Main(string[] args)
        {
            string filename = string.Empty;

            if (args.Length == 1 && HelpRequired(args[0]))
            {
                DisplayHelp();
                return -2;
            }
            else if (args.Length == 1)
            {
                filename = args[0];
            }
            else
            {
                DisplayHelp();
                return -2;

            }


            try
            {
                var api = new Counter();
                var result = api.CountWords(filename);
                Console.WriteLine(string.Format("{0:MMddyyyyhhmmss} Total Words in File {1}", DateTime.Now, result));

            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(string.Format("{0:MMddyyyyhhmmss} Error {1}", DateTime.Now, ex));
                return -4;
            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format("{0:MMddyyyyhhmmss} Error {1}", DateTime.Now, ex));
                return -8;
            }
            finally
            {
                Console.WriteLine(string.Format("{0:MMddyyyyhhmmss} Finiesh Execution.  Results: {1}", DateTime.Now, "Finished Successly"));
            }
            return 0;

        }

        static bool HelpRequired(string param)
        {
            return param == "-h" || param == "--help" || param == "/?";
        }

        static void DisplayHelp()
        {
            Console.WriteLine(string.Format("Word Counter"));
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine(string.Format("WordCounterApp.exe <filename>"));
            Console.WriteLine(Environment.NewLine);
        }

    }
}
