using System;


namespace HospitalIntegrationApp.Models
{
    public class User
    {
        public int KullaniciId { get; set; }
        public string KullaniciAdi { get; set; }
        public string SifreHash { get; set; }
        public bool IsActive { get; set; }
        public string Role { get; set; }
    }
}








