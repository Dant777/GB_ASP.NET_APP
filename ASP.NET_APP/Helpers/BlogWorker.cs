using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ASP.NET_APP_Lesson_1.Helpers
{
    public static class BlogWorker
    {
        private static readonly HttpClient _client = new();

        /// <summary>
        /// Получение 1 поста
        /// </summary>
        /// <param name="blog">Адрес</param>
        /// <returns>Блог</returns>
        private static async Task<string> GetOneBlogInfoAsync(string blog)
        {
            try
            {
                var response = await _client.GetAsync(blog);

                response.EnsureSuccessStatusCode();
                var responseBody = await response.Content.ReadAsStringAsync();
                return responseBody;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("Message :{0} - {1} ", blog, e.Message);
            }

            return string.Empty;
        }

        /// <summary>
        /// Получение постов с определенным id
        /// </summary>
        /// <param name="startId">номер первого id блога попадающего в коллекцию</param>
        /// <param name="numberBlog">кол-во блогов попадающего в коллекцию </param>
        /// <returns>Коллекция блогов</returns>
        public static async Task<string[]> GetBlogsInfoAsync(int startId, int numberBlog)
        {
            var requestUriCollection = Enumerable
                .Range(startId, numberBlog)
                .Select(i => StaticData.BlogUriPost+i)
                .Select(r => Task.Run(async () => await GetOneBlogInfoAsync(r)));
            var result = await Task.WhenAll(requestUriCollection.ToArray());
            return result;
        }

        /// <summary>
        /// Получение постов с случайным/отрицательным/нулевым id
        /// </summary>
        /// <param name="startId">номер первого id блога попадающего в коллекцию</param>
        /// <param name="numberBlog">кол-во блогов попадающего в коллекцию </param>
        /// <returns>Коллекция блогов</returns>
        public static async Task<string[]> GetBlogsInfoRndAsync(int numberBlog)
        {
            Random rnd = new Random();
            List<int> listRndNumb = new List<int>();
            for (int i = 0; i < numberBlog; i++)
            {
                listRndNumb.Add(rnd.Next(-20, 50));
            }

            var requestUriCollection = listRndNumb
                .Select(i => StaticData.BlogUriPost + i)
                .Select(r => Task.Run(async () => await GetOneBlogInfoAsync(r)));
            var result = await Task.WhenAll(requestUriCollection.ToArray());
            return result;
        }
    }
}
