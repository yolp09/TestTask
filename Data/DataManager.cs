using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Data
{
    public class DataManager
    {
        private readonly string _connectionString;

        public DataManager(string connectionString)
        {
            this._connectionString = connectionString;
        }
        //Функция для получения всех валют и добавления их в таблицу бд
        public void AddCurrencies()
        {
            List<Currency> tmp = Currencies.GetCurrencies();
            foreach (var item in tmp)
            {
                AddCurrency(item);
            }
        }
        //Функция для получения всех значений валют и добавления их в таблицу бд
        public void AddExchangeRate(string date)
        {
            List<CurrencyRate> tmp = CurrencyRates.GetCurrencyRate(date);
            foreach (var item in tmp)
            {
                AddExchangeRate(item);
            }
        }
        //Функция поиска значения валют по id и date
        public double CurrencySearch(string id, string date)
        {
            double result = 0;
            string sqlExpression = "sp_CurrencySearch";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter idParam = new SqlParameter
                {
                    ParameterName = "@id",
                    Value = id
                };
                SqlParameter dateParam = new SqlParameter
                {
                    ParameterName = "@date",
                    Value = date
                };
                command.Parameters.Add(idParam);
                command.Parameters.Add(dateParam);
                command.Parameters.Add("@result", SqlDbType.Money).Direction = ParameterDirection.Output;

                command.ExecuteNonQuery();

                if (command.Parameters["@result"].Value == DBNull.Value) throw new Exception("Данные не найдены");
                result = Convert.ToDouble(command.Parameters["@result"].Value);
            }
            return result;
        }
        //Функция получения всех валют
        public DataSet GetCurrencies()
        {
            DataSet ds = new DataSet();
            string sqlExpression = "sp_GetCurrencies";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(sqlExpression, connection);
                adapter.Fill(ds);
            }
            return ds;
        }
        //Функция проверки наличия валют в таблице
        public bool CheckingAvailabilityCurrencies()
        {
            bool result = false;
            string sqlExpression = "sp_CheckingAvailabilityCurrencies";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                var returnValue = command.Parameters.Add("@Return", SqlDbType.Bit);
                returnValue.Direction = ParameterDirection.ReturnValue;

                command.ExecuteNonQuery();
                result = Convert.ToBoolean(returnValue.Value);
            }
            return result;
        }
        //Функция проверки наличия значений за указанную дату
        public bool CheckingAvailabilityExchangeRate(string date)
        {
            bool result = false;
            string sqlExpression = "sp_CheckingAvailabilityExchangeRate";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter dateParam = new SqlParameter
                {
                    ParameterName = "@date",
                    Value = date
                };
                command.Parameters.Add(dateParam);

                var returnValue = command.Parameters.Add("@Return", SqlDbType.Bit);
                returnValue.Direction = ParameterDirection.ReturnValue;

                command.ExecuteNonQuery();
                result = Convert.ToBoolean(returnValue.Value);
            }
            return result;
        }
        //Добавление валюты
        private void AddCurrency(Currency value)
        {
            string sqlExpression = "sp_InsertCurrencies";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter idParam = new SqlParameter
                {
                    ParameterName = "@id",
                    Value = value.ID
                };
                SqlParameter nameParam = new SqlParameter
                {
                    ParameterName = "@name",
                    Value = value.Name
                };
                SqlParameter engNameParam = new SqlParameter
                {
                    ParameterName = "@engName",
                    Value = value.EngName
                };
                SqlParameter nominalParam = new SqlParameter
                {
                    ParameterName = "@nominal",
                    Value = value.Nominal
                };
                SqlParameter parentCodeParam = new SqlParameter
                {
                    ParameterName = "@parentCode",
                    Value = value.ParentCode
                };
                SqlParameter numCodeParam = new SqlParameter
                {
                    ParameterName = "@numCode",
                    Value = value.NumCode
                };
                SqlParameter charCodeParam = new SqlParameter
                {
                    ParameterName = "@charCode",
                    Value = value.CharCode
                };
                command.Parameters.Add(idParam);
                command.Parameters.Add(nameParam);
                command.Parameters.Add(engNameParam);
                command.Parameters.Add(nominalParam);
                command.Parameters.Add(parentCodeParam);
                command.Parameters.Add(numCodeParam);
                command.Parameters.Add(charCodeParam);

                var result = command.ExecuteNonQuery();
            }
        }
        //Добавление курса валюты
        private void AddExchangeRate(CurrencyRate value)
        {
            string sqlExpression = "sp_InsertExchangeRate";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter idParam = new SqlParameter
                {
                    ParameterName = "@currenciesId",
                    Value = value.ID
                };
                SqlParameter valueParam = new SqlParameter
                {
                    ParameterName = "@value",
                    Value = value.Value
                };
                SqlParameter dateParam = new SqlParameter
                {
                    ParameterName = "@date",
                    Value = value.Date
                };

                command.Parameters.Add(idParam);
                command.Parameters.Add(valueParam);
                command.Parameters.Add(dateParam);

                var result = command.ExecuteNonQuery();
            }
        }
    }
}
