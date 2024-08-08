using University.Interfaces;

namespace University.Services
{
    public class BaseDecodeServices : IBaseDecode
    {
        public string GetBaseDecode(string PlainText)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(PlainText);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }
    }
}
