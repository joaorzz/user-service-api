using Domain.Settings;
using System.Text;
using Xunit;

namespace Tests.Domain.Settings
{
    public class JwtAuthSettingsTest
    {
        [Fact]
        public void JwtAuthSettings_GetEncodedSecret_ReturnsCorrectValue()
        {
            // Arrange
            const string authority = "AuthorityFake";
            const string audience = "AudienceFake";
            const string issuer = "IssuerFake";
            const string secretKey = "SecretKeyFake";
            JwtAuthSettings jwtAuthSettings = new JwtAuthSettings
            {
                Authority = authority,
                Audience = audience,
                Issuer = issuer,
                Secret = secretKey
            };

            // Act
            byte[] encodedSecret = jwtAuthSettings.GetEncodedSecret();
            string decodedSecret = Encoding.ASCII.GetString(encodedSecret);

            // Assert
            Assert.Equal(authority, jwtAuthSettings.Authority);
            Assert.Equal(audience, jwtAuthSettings.Audience);
            Assert.Equal(issuer, jwtAuthSettings.Issuer);
            Assert.Equal(secretKey, decodedSecret);
        }
    }
}
