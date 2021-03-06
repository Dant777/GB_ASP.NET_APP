using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ASP.NET_APP_Lesson_1.Helpers
{
    public static class Logger
    {
        /// <summary>
        /// Запись коллекции в файл
        /// </summary>
        /// <param name="strCollection">Коллекция</param>
        public static void WriteInFile(string[] strCollection)
        {
            var writePath = "result.txt";

            try
            {
                using var sw = new StreamWriter(writePath, false, Encoding.Default);
                foreach (var str in strCollection)
                {
                    sw.WriteLine(str + "\n");
                    
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("Запись выполнена");
        }

        /// <summary>
        /// Запись коллекции в файл
        /// </summary>
        /// <param name="strCollection">Коллекция</param>
        public static async Task WriteInFileAsync(string[] strCollection)
        {
            var writePath = "result.txt";

            try
            {
                await Task.Run(() =>
                {
                    using var sw = new StreamWriter(writePath, false, Encoding.Default);
                    foreach (var str in strCollection)
                    {
                        sw.WriteLine(str + "\n");

                    }
                });

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("Запись выполнена");
        }
    }
}