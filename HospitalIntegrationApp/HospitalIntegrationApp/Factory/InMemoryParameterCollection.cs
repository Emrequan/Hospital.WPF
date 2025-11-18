using System;
using System.Collections;
using System.Data;


namespace HospitalIntegrationApp.Factory
{
    public class InMemoryParameterCollection : IDataParameterCollection
    {
        public object this[string parameterName] { get => null; set { } }
        public object this[int index] { get => null; set { } }
        public bool IsReadOnly => true;
        public bool IsFixedSize => true;
        public int Count => 0;
        public object SyncRoot => this;
        public bool IsSynchronized => false;

        public int Add(object value)
        {
            return 0;
        }

        public void Clear()
        {
            // In-memory için gerekli değil
        }

        public bool Contains(string parameterName)
        {
            return false;
        }

        public bool Contains(object value)
        {
            return false;
        }

        public void CopyTo(Array array, int index)
        {
            // In-memory için gerekli değil
        }

        public IEnumerator GetEnumerator()
        {
            return new object[0].GetEnumerator();
        }

        public int IndexOf(string parameterName)
        {
            return -1;
        }

        public int IndexOf(object value)
        {
            return -1;
        }

        public void Insert(int index, object value)
        {
            // In-memory için gerekli değil
        }

        public void Remove(object value)
        {
            // In-memory için gerekli değil
        }

        public void RemoveAt(string parameterName)
        {
            // In-memory için gerekli değil
        }

        public void RemoveAt(int index)
        {
            // In-memory için gerekli değil
        }
    }
}











