using System;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Security;

namespace HospitalIntegrationApp.Services
{
    public interface IPasswordHasher
    {
        string Hash(string password);
        bool Verify(string password, string hash);
    }

    public sealed class BcryptPasswordHasher : IPasswordHasher
    {
        private const int MinWorkFactor = 4;
        private const int MaxWorkFactor = 31;

        private readonly SecureRandom _secureRandom;
        private readonly int _workFactor;

        public BcryptPasswordHasher(int workFactor = 12)
        {
            if (workFactor < MinWorkFactor || workFactor > MaxWorkFactor)
            {
                throw new ArgumentOutOfRangeException(nameof(workFactor),
                    $"Çalışma faktörü {MinWorkFactor} ile {MaxWorkFactor} arasında olmalıdır.");
            }

            _workFactor = workFactor;
            _secureRandom = new SecureRandom();
        }

        public string Hash(string password)
        {
            if (password == null)
            {
                throw new ArgumentNullException(nameof(password));
            }

            if (password.Length == 0)
            {
                throw new ArgumentException("Parola boş olamaz.", nameof(password));
            }

            var salt = new byte[16];
            _secureRandom.NextBytes(salt);
            return OpenBsdBCrypt.Generate(password.ToCharArray(), salt, _workFactor);
        }

        public bool Verify(string password, string hash)
        {
            if (string.IsNullOrEmpty(hash) || password == null)
            {
                return false;
            }

            try
            {
                return OpenBsdBCrypt.CheckPassword(hash, password.ToCharArray());
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}
