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
                Console.WriteLine(string.Format("{0:MMddyyyyhhmmss} Started Execution.", DateTime.Now));

                var api = new Counter();
                var totalWords = api.CountWords(filename);
                Console.WriteLine(string.Format("Total words in file {0}", totalWords));

                Console.WriteLine(string.Format("Unique words in file"));
                var uniqueWordMetrics = api.CountUniqueWords(filename);
                foreach (var metric in uniqueWordMetrics)
                {
                    Console.WriteLine(string.Format("{0} {1}", metric.Word, metric.Count));
                }

                

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
                Console.WriteLine(string.Format("{0:MMddyyyyhhmmss} Finished Execution.  Results: {1}", DateTime.Now, "Finished Successly"));
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
