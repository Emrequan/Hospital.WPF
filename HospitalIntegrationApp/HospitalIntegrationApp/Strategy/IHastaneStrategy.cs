using HospitalIntegrationApp.Factory;
using HospitalIntegrationApp.Models;
using System.Collections.Generic;
using System.Data.Odbc;


namespace HospitalIntegrationApp.Strategy
{
    public interface IHastaneStrategy
    {
        List<RawHasta> GetHastalar(IDbFactory factory);
    }
}