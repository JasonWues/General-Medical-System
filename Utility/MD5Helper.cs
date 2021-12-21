using System.Text;

namespace Utility
{
    public class MD5Helper
    {
        public static string MD5Encrypt32(string password)
        {
            string pwd = "";
            System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();
            Byte[] s = md5.ComputeHash(Encoding.UTF8.GetBytes(password));
            for (int i = 0; i < s.Length; i++)
            {
                pwd = pwd + s[i].ToString("x");
            }

            return pwd;
        }

    }
}
