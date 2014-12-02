namespace Common.Assets
{
    public class AssetProvider
    {
        public static string SCHEME = "ndc";

        public static bool IsLocal(string route)
        {
            return route.StartsWith(SCHEME);
        }

        public static AssetResource Get(string route)
        {
            if (route.Contains("html"))
            {
                return new AssetResource("text/html", Resources.Html);
            }

            return new AssetResource("text/css", Resources.Css);
        }
    }
}
