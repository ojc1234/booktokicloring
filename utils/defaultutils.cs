namespace booktokicloring.utils;

public class defaultutils
{
    public static bool isnull<T>(T input)
    {
        if (input == null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}