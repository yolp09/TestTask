using Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Model
{
    public class Manager
    {
        private DataManager _dataManager;

        public Manager(string connectionString)
        {
            this._dataManager = new DataManager(connectionString);
        }

        public Task AddExchangeRateAsync(string date)
        {
            return Task.Run(() => AddExchangeRate(date));
        }
        public Task<double> CurrencySearchAsync(string id, string date)
        {
            return Task.Run(() => CurrencySearch(id, date));
        }
        public Task AddCurrenciesAsync()
        {
            return Task.Run(() => AddCurrencies());
        }
        public DataSet GetCurrencies()
        {
            return _dataManager.GetCurrencies();
        }
        public List<ModelComboBox> GetIdName()
        {
            List<ModelComboBox> result = new List<ModelComboBox>();
            DataSet ds = _dataManager.GetCurrencies();

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                result.Add(new ModelComboBox
                {
                    Id = ds.Tables[0].Rows[i].ItemArray[0].ToString(),
                    Name = ds.Tables[0].Rows[i].ItemArray[1].ToString()
                });
            }
            return result;
        }

        private void AddExchangeRate(string date)
        {
            if (_dataManager.CheckingAvailabilityExchangeRate(date)) throw new Exception($"Данные курса валют за {date} уже добавлены!!!");
            _dataManager.AddExchangeRate(date);
        }
        private double CurrencySearch(string id, string date)
        {
            return _dataManager.CurrencySearch(id, date);
        }
        private void AddCurrencies()
        {
            if (_dataManager.CheckingAvailabilityCurrencies()) throw new Exception("Валюты уже добавлены!!!");
            _dataManager.AddCurrencies();
        }
    }
}
