#if UNITY_ANDROID || UNITY_IPHONE || UNITY_STANDALONE_OSX || UNITY_TVOS
// WARNING: Do not modify! Generated file.

namespace UnityEngine.Purchasing.Security {
    public class GooglePlayTangle
    {
        private static byte[] data = System.Convert.FromBase64String("qYWWS1gxsN4bWQYMQRsF696sWmgc0Gbxe+G+v138b+lzSzyD5htTKVILH+jRofq8sm4nIOxV8kic+XPKd6rRe3qLjSQjTrtslVbGbi0nzd7yt0ma3w8QTbIR+p4U7SUsc6M62yCSETIgHRYZOpZYlucdERERFRATovITdwwtmFrdMvai3ucWm0+tyUYPm0fKFc0QmDxmOBz5klMFUsJVyUMUisID5JQ71422F1BEi0OFlpAhkhEfECCSERoSkhEREJW9KKsMWuF2nHrzEOBSsTWeYAlou5WJo+Q4O+3OofUZQeXhHwqD+7UR646XgbPyY8kYmYn46K/lYpH3PDIRknDd5vAjLYKiDdd7ny0DO8X/DzJXomIKXi0jGJCZTTaDNRITERAR");
        private static int[] order = new int[] { 6,8,12,12,9,6,10,13,11,11,10,13,12,13,14 };
        private static int key = 16;

        public static readonly bool IsPopulated = true;

        public static byte[] Data() {
        	if (IsPopulated == false)
        		return null;
            return Obfuscator.DeObfuscate(data, order, key);
        }
    }
}
#endif
