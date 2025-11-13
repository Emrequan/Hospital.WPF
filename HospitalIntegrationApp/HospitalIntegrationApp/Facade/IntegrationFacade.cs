using System.Collections.Generic;
using System.Data;
using System.Linq;
using System;
using HospitalIntegrationApp.Adapter;
using HospitalIntegrationApp.Factory;
using HospitalIntegrationApp.Models;
using HospitalIntegrationApp.Strategy;


namespace HospitalIntegrationApp.Facade
{
    public class IntegrationFacade
    {
        public List<Hasta> GetHastalar(IHastaneStrategy strategy, IDbFactory factory, int hastaneNo)
        {
            var raw = strategy.GetHastalar(factory);
            var unified = HastaAdapter.Convert(raw, hastaneNo);
            return unified;
        }

        public void SaveHastalarToMaster(IEnumerable<Hasta> hastalar, IDbFactory masterFactory)
        {
            using (var conn = masterFactory.CreateConnection())
            {
                conn.Open();
                using (var tx = conn.BeginTransaction())
                {
                    var distinct = hastalar
                        .GroupBy(h => new { h.Ad, h.Soyad, h.DogumTarihi, h.HastaneNo })
                        .Select(g => g.First());

                    foreach (var h in distinct)
                    {
                        // Normalize values for consistent matching
                        var ad = (h.Ad ?? string.Empty).Trim().ToUpperInvariant();
                        var soyad = (h.Soyad ?? string.Empty).Trim().ToUpperInvariant();
                        var dogumTarihi = h.DogumTarihi.Date;
                        var hastaneNo = h.HastaneNo;

                        // Existence check to avoid duplicates even without a DB unique index
                        using (var existsCmd = masterFactory.CreateCommand(
                            "SELECT 1 FROM master_hastalar WHERE ad = @ad AND soyad = @soyad AND dogum_tarihi = @dogum_tarihi AND hastane_no = @hastane_no LIMIT 1", conn))
                        {
                            var e1 = existsCmd.CreateParameter(); e1.ParameterName = "@ad"; e1.Value = ad; existsCmd.Parameters.Add(e1);
                            var e2 = existsCmd.CreateParameter(); e2.ParameterName = "@soyad"; e2.Value = soyad; existsCmd.Parameters.Add(e2);
                            var e3 = existsCmd.CreateParameter(); e3.ParameterName = "@dogum_tarihi"; e3.Value = dogumTarihi; existsCmd.Parameters.Add(e3);
                            var e4 = existsCmd.CreateParameter(); e4.ParameterName = "@hastane_no"; e4.Value = hastaneNo; existsCmd.Parameters.Add(e4);

                            if (existsCmd is IDbCommand ec) { ec.Transaction = tx; }

                            var exists = existsCmd.ExecuteScalar();
                            if (exists != null)
                            {
                                continue; // Skip insert; record already exists
                            }
                        }

                        using (var cmd = masterFactory.CreateCommand(
                            "INSERT INTO master_hastalar (ad, soyad, dogum_tarihi, hastane_no, kaynak_hastane) VALUES (@ad, @soyad, @dogum_tarihi, @hastane_no, @kaynak) ON DUPLICATE KEY UPDATE kaynak_hastane = VALUES(kaynak_hastane)", conn))
                        {
                            var p1 = cmd.CreateParameter(); p1.ParameterName = "@ad"; p1.Value = ad; cmd.Parameters.Add(p1);
                            var p2 = cmd.CreateParameter(); p2.ParameterName = "@soyad"; p2.Value = soyad; cmd.Parameters.Add(p2);
                            var p3 = cmd.CreateParameter(); p3.ParameterName = "@dogum_tarihi"; p3.Value = dogumTarihi; cmd.Parameters.Add(p3);
                            var p4 = cmd.CreateParameter(); p4.ParameterName = "@hastane_no"; p4.Value = hastaneNo; cmd.Parameters.Add(p4);
                            var p5 = cmd.CreateParameter(); p5.ParameterName = "@kaynak"; p5.Value = h.HastaneNo == 101 ? "VAKIF" : "DEVLET"; cmd.Parameters.Add(p5);

                            // Transaction binding (for IDbCommand without explicit tx property in factory API)
                            if (cmd is IDbCommand c)
                            {
                                c.Transaction = tx;
                            }

                            cmd.ExecuteNonQuery();
                        }
                    }
                    tx.Commit();
                }
            }
        }
    }
}



