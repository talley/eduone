namespace EduOne.Helpers
{
    public static class WebServerHelpers
    {

        public static string GetApiApplicationUrl(bool IsProd)
        {
            if (IsProd)
            {
                return "";
            }
            else
            {
                return "https://localhost:7027/api/";
            }
        }

        public static string GetApplicationUrl(bool IsProd)
        {
            if (IsProd)
            {
                return "";
            }
            else
            {
                return "https://localhost:7027/";
            }
        }
    }
}
