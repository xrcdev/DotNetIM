using System.Security.Cryptography;
using System.Text;

namespace IM_Router.untils
{
    public static class Md5Untils
    {
        public static string GetMD5_10(string str)
        {
            // 创建MD5对象
            MD5 md5 = MD5.Create();
            // 需要将字符串转换成字节数组
            byte[] buffer = Encoding.UTF8.GetBytes(str);
            // 返回一个加密好的字节数组
            byte[] MD5Buffer = md5.ComputeHash(buffer);

            // 将字节数组每个元素ToString()  10进制
            // 3244185981728979115075721453575112
            string s = "";
            foreach (var item in MD5Buffer)
            {
                s += item.ToString();
            }
            return s;
        }

        public static string GetMD5_16(string str)
        {
            // 创建MD5对象
            MD5 md5 = MD5.Create();
            // 需要将字符串转换成字节数组
            byte[] buffer = Encoding.UTF8.GetBytes(str);
            // 返回一个加密好的字节数组
            byte[] MD5Buffer = md5.ComputeHash(buffer);

            // 将字节数组每个元素ToString(x) 16进制
            //202cb962ac5975b964b7152d234b70
            string s2 = "";
            foreach (var item in MD5Buffer)
            {
                s2 += item.ToString("x");
            }
            return s2;
        }
        public static string GetMD5_16_x2(string str)
        {
            // 创建MD5对象
            MD5 md5 = MD5.Create();
            // 需要将字符串转换成字节数组
            byte[] buffer = Encoding.UTF8.GetBytes(str);
            // 返回一个加密好的字节数组
            byte[] MD5Buffer = md5.ComputeHash(buffer);

            // 将字节数组每个元素ToString(x) 16进制
            //202cb962ac5975b964b7152d234b70
            string s2 = "";
            foreach (var item in MD5Buffer)
            {
                s2 += item.ToString("x2");
            }
            return s2;
        }

    }
}
