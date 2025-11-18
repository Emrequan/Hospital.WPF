using System.Collections.Generic;
using HospitalIntegrationApp.Facade;
using HospitalIntegrationApp.Factory;
using HospitalIntegrationApp.Models;
using HospitalIntegrationApp.Strategy;


namespace HospitalIntegrationApp.Application
{
    public class IntegrationService : IIntegrationService
    {
        private readonly IntegrationFacade _facade;

        public IntegrationService()
        {
            _facade = new IntegrationFacade();
        }

        public List<Hasta> GetAllPatients()
        {
            var all = new List<Hasta>();
            var vakif = _facade.GetHastalar(new VakifStrategy(), new VakifDbFactory(), 101);
            var devlet = _facade.GetHastalar(new DevletStrategy(), new DevletDbFactory(), 202);
            all.AddRange(vakif);
            all.AddRange(devlet);
            return all;
        }

        public void SavePatientsToMaster(IEnumerable<Hasta> patients)
        {
            _facade.SaveHastalarToMaster(patients, new MasterDbFactory());
        }
    }
}










