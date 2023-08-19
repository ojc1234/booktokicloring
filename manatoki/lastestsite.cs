namespace booktokicloring.manatoki;
using booktokicloring.utils;
public class newestsite
{
    public string site;

    public newestsite(string sourcesite)
    {
    }

    public static Uri? ain(string sourcesite)
    {
        //① HttpClient 개체 생성
        HttpClient httpClient = new HttpClient();

        //② GetAsync() 메서드 호출
        var httpResponseMessage = httpClient.GetAsync(sourcesite);

        //③ HTML 가져오기
        var responseBody = httpResponseMessage.Result.RequestMessage.RequestUri;

        //④ 출력
        return responseBody;

    }
}