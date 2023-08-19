using System.Net;
using System.Text.RegularExpressions;
using booktokicloring.utils;
using booktokicloring.manatoki;
namespace booktokicloring
{
    public class getNovel
    {
        public static void Main()
        {
            //MainfunStatic().ForEach(s => Console.WriteLine(s));
            manatoki.newestsite.ain("https://manatoki.net");
        }

        public List<string> Mainfun()
        {
            string url =
                "https://booktoki302.com/novel/228?stx=%ED%99%94%EC%82%B0%EA%B7%80%ED%99%98&book=%EC%9D%BC%EB%B0%98%EC%86%8C%EC%84%A4&spage=1";
            var htmlparsed = requestClass.dictrequestList(url);
            return htmlparsed;
        }
        public static List<string> MainfunStatic()
        {
            string url =
                "https://booktoki303.com/novel/228?stx=%ED%99%94%EC%82%B0%EA%B7%80%ED%99%98&book=%EC%9D%BC%EB%B0%98%EC%86%8C%EC%84%A4&spage=1";
            var htmlparsed = requestClass.dictrequestList(url);
            return htmlparsed;
        }
        public static void Stringcheak()
        {
            string url =
                "https://booktoki301.com/novel/228?stx=%ED%99%94%EC%82%B0%EA%B7%80%ED%99%98&book=%EC%9D%BC%EB%B0%98%EC%86%8C%EC%84%A4&spage=1";
            var htmlparsed = requestClass.dictrequestList(url);
            foreach (var i in htmlparsed)
            {
                Console.WriteLine(i);
            }
            NovelDownload(url,@"/Users/noni/Documents/novel/",2);
        }

        public static void NovelDownload(string url1, string dire, int last)
        {
            int cheaknum = 1;

            for (int i = 1; i <= last; i++)
            {
                string url =
                    url1 +
                    i;


                var requested = requestClass.postRequest(url);
                List<string> htmlparsed = requestClass.dictrequestList(url);
                Console.WriteLine(htmlparsed);
                string directory = dire;
                string num = cheaknum.ToString();
                string body = "";
                //foreach (var j in htmlparsed) body += j + "\n";
                htmlparsed.ForEach((j) => { body += j + "\n"; });
                string 제목 = htmlparsed[1] + i;
                File.WriteAllText(directory + 제목 + ".txt", body);

                cheaknum++;
                Thread.Sleep(2000);
            }
        }
    }
}