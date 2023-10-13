using System.Text;

namespace Domain.Settings
{
    public class JwtAuthSettings
    {
        public string Authority { get; set; }
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public string Secret { get; set; }

        public byte[] GetEncodedSecret()
        {
            return Encoding.ASCII.GetBytes(Secret);
        }
    }
}
