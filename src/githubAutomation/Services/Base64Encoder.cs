using gihubAutomation.Client
using githubAutomation.Models;
using System.Text;

namespace githubAutomation.Services


{
    public class Base64Encoder
    {
        public string EncodeService(string content)
        {
            var headerByte = Encoding.ASCII.GetBytes(content);
            var headerAsBase64 = Convert.ToBase64String(headerByte);
            return headerAsBase64;
        }



    }
}
