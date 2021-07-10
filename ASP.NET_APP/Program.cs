using System;
using System.Threading.Tasks;
using ASP.NET_APP_Lesson_1.Helpers;

namespace ASP.NET_APP
{
    class Program
    {
        static async Task Main(string[] args)
        {
              
            var blogInfoCollectiion = await BlogWorker.GetBlogsInfoRndAsync( 25);

            await Logger.WriteInFileAsync(blogInfoCollectiion);

            Console.ReadKey();
        }
    }
}
