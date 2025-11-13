using System;
using System.Data;
using HospitalIntegrationApp.Factory;
using HospitalIntegrationApp.Models;


namespace HospitalIntegrationApp.Services
{
    public class AuthenticationService
    {
        private readonly IDbFactory _factory;

        public AuthenticationService(IDbFactory factory)
        {
            _factory = factory;
        }

        public bool ValidateUser(string username, string password, out HospitalIntegrationApp.Models.User user)
        {
            user = GetUserByUsername(username);
            if (user == null) return false;

            // NOTE: If your 'sifre' column stores plain text for now, compare directly.
            // Switch to BCrypt.Verify when you migrate to hashed passwords.
            return string.Equals(user.SifreHash ?? string.Empty, password ?? string.Empty, StringComparison.Ordinal);
        }

        public HospitalIntegrationApp.Models.User GetUserByUsername(string username)
        {
            using (var conn = _factory.CreateConnection())
            {
                conn.Open();
                using (var cmd = _factory.CreateCommand(
                    "SELECT `KullanıcıID`, `KullanıcıAdı`, `sifre` FROM `kullanıcı`.`kullanıcı` WHERE `KullanıcıAdı` = @username", conn))
                {
                    var p = cmd.CreateParameter();
                    p.ParameterName = "@username";
                    p.Value = username;
                    cmd.Parameters.Add(p);

                    using (var rdr = cmd.ExecuteReader())
                    {
                        if (!rdr.Read()) return null;

                        var user = new HospitalIntegrationApp.Models.User
                        {
                            KullaniciId = Convert.ToInt32(rdr["KullanıcıID"]),
                            KullaniciAdi = rdr["KullanıcıAdı"]?.ToString(),
                            SifreHash = rdr["sifre"]?.ToString(),
                            IsActive = true,
                            Role = null
                        };
                        return user;
                    }
                }
            }
        }

        public string HashPassword(string plainPassword)
        {
            // Placeholder for future migration to hashed passwords (BCrypt recommended)
            // return BCrypt.Net.BCrypt.HashPassword(plainPassword, workFactor: 12);
            return plainPassword;
        }
    }
}


