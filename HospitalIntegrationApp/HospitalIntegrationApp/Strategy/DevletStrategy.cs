using HospitalIntegrationApp.Factory;
using HospitalIntegrationApp.Models;
using System.Collections.Generic;


namespace HospitalIntegrationApp.Strategy
{
    public class DevletStrategy : IHastaneStrategy
    {
        public List<RawHasta> GetHastalar(IDbFactory factory)
        {
            var list = new List<RawHasta>();
            using (var conn = factory.CreateConnection())
            {
                conn.Open();
                using (var cmd = factory.CreateCommand("SELECT isim, soyisim, dogumyili FROM devlet_hastalar", conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new RawHasta
                        {
                            Ad = reader["isim"].ToString(),
                            Soyad = reader["soyisim"].ToString(), 
                            DogumTarihi = reader["dogumyili"].ToString()
                        });
                    }
                }
            }
            return list;
        }
    }
}