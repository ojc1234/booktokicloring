using System.Net;
using booktokicloring.utils;

namespace booktokicloring
{
    public class Class1
    {
        public static void Main()
        {
              
        }

        public static void stringcheak()
        {
            string url =
                "https://booktoki295.com/novel/228?stx=%ED%99%94%EC%82%B0%EA%B7%80%ED%99%98&book=%EC%9D%BC%EB%B0%98%EC%86%8C%EC%84%A4&spage=1";
            var htmlparsed = requestClass.dictrequestList(url);
            foreach (var i in htmlparsed)
            {
                Console.WriteLine(i);
            }
        }

        public static void Listcheack(string url1,string dire,int last)
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
                string filed = dire;
                string num = cheaknum.ToString();
                string body = "";
                foreach (var j in htmlparsed)
                {
                    body += j + "\n";
                }

                string 제목 = htmlparsed[1]+i;
                System.IO.File.WriteAllText(filed + 제목 + ".txt", body);
                cheaknum++;
                Thread.Sleep(2000);
            }
        }
    }
}