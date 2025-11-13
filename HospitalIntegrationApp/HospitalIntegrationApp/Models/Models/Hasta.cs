using System;


namespace HospitalIntegrationApp.Models
{
    // Uygulama genelinde kullanılacak ortak model
    public class Hasta
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public DateTime DogumTarihi { get; set; }
        public int HastaneNo { get; set; }
    }
}