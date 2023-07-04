using System.Net;
using booktokicloring.utils;

namespace booktokicloring
{
    public class Class1
    {
        public static void Main()
        {
            stringcheak();
        }

        public static void stringcheak()
        {
            string url = "https://newtoki.pro/book/16989/162595";
            var requested = requestClass.postRequest(url);
            var htmlparsed = requestClass.dictrequestList(url);
            foreach (var i in htmlparsed)
            {
                Console.WriteLine(i);
            }
        }

        public static void Listcheack()
        {
            int cheaknum = 1;
            string 제목 = "데뷔 못하면 죽을 병 걸림";
            for (int i = 162595; i <= 162595; i++)
            {
                string url = "https://newtoki.pro/book/16989/" + i.ToString();


                var requested = requestClass.postRequest(url);
                List<string> htmlparsed = requestClass.dictrequestList(url);
                Console.WriteLine(htmlparsed);
                string filed = @"E:\codingstudy\booktokicloring\output\";
                string num = cheaknum.ToString();
                string body = "";
                htmlparsed.ConvertAll<string>(input =>
                    {
                        Console.WriteLine($"[{input}]");
                        return input;
                    }
                );


                //System.IO.File.WriteAllText(filed + 제목 + num + ".txt", body);
                cheaknum++;
            }
        }
    }
}