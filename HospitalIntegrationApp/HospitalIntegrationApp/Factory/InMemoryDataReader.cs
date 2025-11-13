using System;
using System.Collections.Generic;
using System.Data;
using HospitalIntegrationApp.Models;


namespace HospitalIntegrationApp.Factory
{
    public class InMemoryDataReader : IDataReader
    {
        private List<RawHasta> _data;
        private int _currentIndex = -1;

        public InMemoryDataReader(List<RawHasta> data)
        {
            _data = data;
        }

        public int Depth => 0;
        public bool IsClosed => false;
        public int RecordsAffected => _data.Count;
        public int FieldCount => 3; // Ad, Soyad, DogumTarihi

        public object this[int i] => GetValue(i);
        public object this[string name] => GetValue(GetOrdinal(name));

        public void Close()
        {
            // In-memory için gerekli değil
        }

        public void Dispose()
        {
            // In-memory için gerekli değil
        }

        public bool GetBoolean(int i)
        {
            return false;
        }

        public byte GetByte(int i)
        {
            return 0;
        }

        public long GetBytes(int i, long fieldOffset, byte[] buffer, int bufferoffset, int length)
        {
            return 0;
        }

        public char GetChar(int i)
        {
            return '\0';
        }

        public long GetChars(int i, long fieldOffset, char[] buffer, int bufferoffset, int length)
        {
            return 0;
        }

        public IDataReader GetData(int i)
        {
            return null;
        }

        public string GetDataTypeName(int i)
        {
            return "String";
        }

        public DateTime GetDateTime(int i)
        {
            return DateTime.MinValue;
        }

        public decimal GetDecimal(int i)
        {
            return 0;
        }

        public double GetDouble(int i)
        {
            return 0;
        }

        public Type GetFieldType(int i)
        {
            return typeof(string);
        }

        public float GetFloat(int i)
        {
            return 0;
        }

        public Guid GetGuid(int i)
        {
            return Guid.Empty;
        }

        public short GetInt16(int i)
        {
            return 0;
        }

        public int GetInt32(int i)
        {
            return 0;
        }

        public long GetInt64(int i)
        {
            return 0;
        }

        public string GetName(int i)
        {
            // Varsayılan isimler (Vakıf şeması)
            switch (i)
            {
                case 0: return "ad";
                case 1: return "soyad";
                case 2: return "dogum_tarihi";
                default: return "";
            }
        }

        public int GetOrdinal(string name)
        {
            // Hem Vakıf (ad, soyad, dogum_tarihi) hem Devlet (isim, soyisim, dogumyili) alan adlarını destekle
            var key = (name ?? "").Trim().ToLower();
            switch (key)
            {
                case "ad":
                case "isim":
                    return 0;
                case "soyad":
                case "soyisim":
                    return 1;
                case "dogum_tarihi":
                case "dogumyili":
                    return 2;
                default:
                    return -1;
            }
        }

        public DataTable GetSchemaTable()
        {
            return null;
        }

        public string GetString(int i)
        {
            if (_currentIndex >= 0 && _currentIndex < _data.Count)
            {
                var hasta = _data[_currentIndex];
                switch (i)
                {
                    case 0: return hasta.Ad;
                    case 1: return hasta.Soyad;
                    case 2: return hasta.DogumTarihi;
                    default: return "";
                }
            }
            return "";
        }

        public object GetValue(int i)
        {
            return GetString(i);
        }

        public int GetValues(object[] values)
        {
            return 0;
        }

        public bool IsDBNull(int i)
        {
            return false;
        }

        public bool NextResult()
        {
            return false;
        }

        public bool Read()
        {
            _currentIndex++;
            return _currentIndex < _data.Count;
        }
    }
}
