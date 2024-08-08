using Application.DataTransferModels.ResponseModels;
using University.Interfaces;

namespace University.Services
{
    public class BaseServices : IBase
    {
        public  string GetBase(string PlainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(PlainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }
    }
}
