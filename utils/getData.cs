using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace booktokicloring.utils
{
    internal class requestClass
    {
        public static string postRequest(string Word)
        {
            String callUrl = Word;

            String postData = "a=1&b=2";

            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(callUrl);
            // 인코딩 UTF-8
            byte[] sendData = UTF8Encoding.UTF8.GetBytes(postData);
            httpWebRequest.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
            httpWebRequest.Method = "POST";
            httpWebRequest.ContentLength = sendData.Length;
            Stream requestStream = httpWebRequest.GetRequestStream();
            requestStream.Write(sendData, 0, sendData.Length);
            requestStream.Close();
            HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            StreamReader streamReader =
                new StreamReader(httpWebResponse.GetResponseStream(), Encoding.GetEncoding("UTF-8"));
            string sRE = streamReader.ReadToEnd();

            streamReader.Close();
            httpWebResponse.Close();
            return sRE;
        }

        public static List<string> dictrequestList(string url)
        {
            string html = postRequest(url);
            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);
            List<string> peno = htmlParserBoldList(htmlDoc);
            Console.WriteLine("작동됨");
            return peno;
        }
        private static List<string> htmlParserBoldList(HtmlDocument parseHTML)
        {
            var XPath = "//*[@id=\"novel_content\"]/div[2]";
            HtmlDocument htmlDoc = parseHTML;
            string bodyNode = htmlDoc.DocumentNode.SelectSingleNode(XPath)?.InnerText;
            var mainchild = htmlDoc.DocumentNode.SelectSingleNode(XPath)?.ChildNodes;
            List<string> array = new List<string>();
            if (mainchild == null) return null;
            foreach (var child in mainchild)
            {
                array.Add(child.InnerText);
            }

            return  array;
        }
    }
}