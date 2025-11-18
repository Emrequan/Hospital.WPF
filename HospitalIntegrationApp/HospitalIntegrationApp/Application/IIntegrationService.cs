using System.Collections.Generic;
using HospitalIntegrationApp.Models;


namespace HospitalIntegrationApp.Application
{
    public interface IIntegrationService
    {
        List<Hasta> GetAllPatients();
        void SavePatientsToMaster(IEnumerable<Hasta> patients);
    }
}










