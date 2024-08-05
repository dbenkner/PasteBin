namespace PasteBin.Services
{
    public class RandomService
    {
        public static string GenerateRandomStaring(int length)
        {
            Random random = new Random();
            string allowedChars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            string res = string.Empty;
            for(int i = 0; i < length; i++)
            {

                res += allowedChars[random.Next(62)];
            }
            return res;
        }
    }
}
