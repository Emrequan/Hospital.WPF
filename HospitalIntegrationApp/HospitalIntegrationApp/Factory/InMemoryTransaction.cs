using System;
using System.Data;


namespace HospitalIntegrationApp.Factory
{
    public class InMemoryTransaction : IDbTransaction
    {
        public IDbConnection Connection => null;
        public IsolationLevel IsolationLevel => IsolationLevel.ReadCommitted;

        public void Commit()
        {
            // In-memory için gerekli değil
        }

        public void Rollback()
        {
            // In-memory için gerekli değil
        }

        public void Dispose()
        {
            // In-memory için gerekli değil
        }
    }
}











