namespace pageObject;

public static class Extensions
{
    public static string RemoveWhiteSpace(this string str)
    {
        return string.Concat(str.Where(c=> !char.IsWhiteSpace(c)));
    }
}
