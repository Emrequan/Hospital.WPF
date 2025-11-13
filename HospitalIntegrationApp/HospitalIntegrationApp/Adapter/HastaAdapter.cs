using System;
using System.Collections.Generic;
using System.Linq;
using HospitalIntegrationApp.Models;


namespace HospitalIntegrationApp.Adapter
{
    public static class HastaAdapter
    {
        public static List<Hasta> Convert(List<RawHasta> rawData, int hastaneNo)
        {
            return rawData.Select(r => new Hasta
            {
                Ad = r.Ad,
                Soyad = r.Soyad,
                DogumTarihi = DateTime.TryParse(r.DogumTarihi, out var dt) ? dt : DateTime.MinValue,
                HastaneNo = hastaneNo
            }).ToList();
        }
    }
}



