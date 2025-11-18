using System;
using System.Data;
using HospitalIntegrationApp.Factory;
using HospitalIntegrationApp.Models


namespace HospitalIntegrationApp.Services
{
    public class AuthenticationService
    {
        private readonly IDbFactory _factory;
        private const int BCryptWorkFactor = 12;

        public AuthenticationService(IDbFactory factory)
        {
            _factory = factory;
        }

        public bool ValidateUser(string username, string password, out HospitalIntegrationApp.Models.User user)
        {
            user = GetUserByUsername(username);
            if (user == null) return false;

            var girilenParola = password ?? string.Empty;
            var kayitliDeger = user.SifreHash ?? string.Empty;
            if (string.IsNullOrWhiteSpace(kayitliDeger)) return false;

            var hashGibi = kayitliDeger.StartsWith("$2", StringComparison.Ordinal);
            if (hashGibi)
            {
                return BCrypt.Net.BCrypt.Verify(girilenParola, kayitliDeger);
            }

            if (!string.Equals(kayitliDeger, girilenParola, StringComparison.Ordinal))
            {
                return false;
            }

            var yeniHash = HashPassword(girilenParola);
            TryUpgradeUserPasswordHash(user.KullaniciId, yeniHash);
            return true;
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
            if (string.IsNullOrEmpty(plainPassword))
            {
                throw new ArgumentException("Parola değeri boş olamaz.", nameof(plainPassword));
            }

            return BCrypt.Net.BCrypt.HashPassword(plainPassword, workFactor: BCryptWorkFactor);
        }

        private void TryUpgradeUserPasswordHash(int userId, string yeniHash)
        {
            try
            {
                // Hash'lenmiş parolalar 60+ karakter olduğundan ilgili sütunun NVARCHAR olması gerekir.
                using (var conn = _factory.CreateConnection())
                {
                    conn.Open();
                    using (var cmd = _factory.CreateCommand("UPDATE `kullanıcı`.`kullanıcı` SET `sifre` = @hash WHERE `KullanıcıID` = @id", conn))
                    {
                        var hashParam = cmd.CreateParameter();
                        hashParam.ParameterName = "@hash";
                        hashParam.Value = yeniHash;
                        cmd.Parameters.Add(hashParam);

                        var idParam = cmd.CreateParameter();
                        idParam.ParameterName = "@id";
                        idParam.Value = userId;
                        cmd.Parameters.Add(idParam);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.TraceWarning("Parola hash'i güncellenirken hata oluştu: {0}", ex);
            }
        }
    }
}


