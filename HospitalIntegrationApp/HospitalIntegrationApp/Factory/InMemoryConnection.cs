using System;
using System.Collections.Generic;
using System.Data;
using HospitalIntegrationApp.Models;


namespace HospitalIntegrationApp.Factory
{
    public class InMemoryConnection : IDbConnection
    {
        private List<RawHasta> _data;
        private ConnectionState _state = ConnectionState.Closed;

        public InMemoryConnection(List<RawHasta> data)
        {
            _data = data;
        }

        public List<RawHasta> Data => _data;

        public string ConnectionString { get; set; }
        public int ConnectionTimeout => 30;
        public string Database => "InMemory";
        public ConnectionState State => _state;

        public IDbTransaction BeginTransaction()
        {
            return new InMemoryTransaction();
        }

        public IDbTransaction BeginTransaction(IsolationLevel il)
        {
            return new InMemoryTransaction();
        }

        public void ChangeDatabase(string databaseName)
        {
            // In-memory için gerekli değil
        }

        public void Close()
        {
            _state = ConnectionState.Closed;
        }

        public IDbCommand CreateCommand()
        {
            return new InMemoryCommand("", this);
        }

        public void Open()
        {
            _state = ConnectionState.Open;
        }

        public void Dispose()
        {
            Close();
        }
    }
}











