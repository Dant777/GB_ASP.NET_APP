using System;
using System.Linq;
using System.Net.Http;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using ASP.NET_APP_Lesson_1.Helpers;

namespace ASP.NET_APP
{
    class Program
    {
        static async Task Main(string[] args)
        {
              
            var blogInfoCollectiion = await BlogWorker.GetBlogsInfoAsync(-1, 50);

            await Logger.WriteInFileAsync(blogInfoCollectiion);

            Console.ReadKey();
        }
    }
}
