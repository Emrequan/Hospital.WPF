using HospitalIntegrationApp.Factory;
using HospitalIntegrationApp.Models;
using System.Collections.Generic;


namespace HospitalIntegrationApp.Strategy
{
    public class VakifStrategy : IHastaneStrategy
    {
        public List<RawHasta> GetHastalar(IDbFactory factory)
        {
            var list = new List<RawHasta>();
            using (var conn = factory.CreateConnection())
            {
                conn.Open();
                using (var cmd = factory.CreateCommand("SELECT ad, soyad, dogum_tarihi FROM vakif_hastalar", conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new RawHasta
                        {
                            Ad = reader["ad"].ToString(),
                            Soyad = reader["soyad"].ToString(),
                            DogumTarihi = reader["dogum_tarihi"].ToString()
                        });
                    }
                }
            }
            return list;
        }
    }
}