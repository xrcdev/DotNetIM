using System;
using System.Collections.Generic;
using System.Text;

namespace im.sdk.untils
{
    public static class BufferUtils
    {

        public static byte[] ToArray(this string str)
        {
            return Encoding.UTF8.GetBytes(str);
        }

        public static string ToString(this byte[] body)
        {
            return Encoding.UTF8.GetString(body);
        }
    }
}
