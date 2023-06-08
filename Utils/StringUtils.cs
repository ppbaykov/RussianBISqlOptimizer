namespace RussianBISqlOptimizer.Utils;

public static class StringUtils
{
    public static string QuoteName(string text)
    {
        return $"`{text}`";
    }
    
    public static string EscapeName(string text)
    {
        return $"{text.Replace("`", "``")}";
    }
    
    public static string EscapeAndQuoteName(string text)
    {
        return QuoteName(EscapeName(text));
    }
}