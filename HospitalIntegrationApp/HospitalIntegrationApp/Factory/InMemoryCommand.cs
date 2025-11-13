using System;
using System.Collections.Generic;
using System.Data;
using HospitalIntegrationApp.Models;


namespace HospitalIntegrationApp.Factory
{
    public class InMemoryCommand : IDbCommand
    {
        private string _commandText;
        private InMemoryConnection _connection;
        private IDataReader _reader;

        public InMemoryCommand(string commandText, InMemoryConnection connection)
        {
            _commandText = commandText;
            _connection = connection;
        }

        public string CommandText
        {
            get => _commandText;
            set => _commandText = value;
        }

        public int CommandTimeout { get; set; } = 30;
        public CommandType CommandType { get; set; } = CommandType.Text;
        public IDbConnection Connection
        {
            get => _connection;
            set => _connection = (InMemoryConnection)value;
        }

        public IDataParameterCollection Parameters => new InMemoryParameterCollection();
        public IDbTransaction Transaction { get; set; }
        public UpdateRowSource UpdatedRowSource { get; set; }

        public void Cancel()
        {
            // In-memory için gerekli değil
        }

        public IDbDataParameter CreateParameter()
        {
            return new InMemoryParameter();
        }

        public int ExecuteNonQuery()
        {
            return 0; // In-memory için gerekli değil
        }

        public IDataReader ExecuteReader()
        {
            return new InMemoryDataReader(_connection.Data);
        }

        public IDataReader ExecuteReader(CommandBehavior behavior)
        {
            return new InMemoryDataReader(_connection.Data);
        }

        public object ExecuteScalar()
        {
            return null; // In-memory için gerekli değil
        }

        public void Prepare()
        {
            // In-memory için gerekli değil
        }

        public void Dispose()
        {
            // In-memory için gerekli değil
        }
    }
}










