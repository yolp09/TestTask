using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

namespace Data
{
    //класс значений валют за указанную дату
    public class CurrencyRate
    {
        public string ID { get; set; }
        public double Value { get; set; }
        public string Date { get; set; }
    }

    //класс для всех значений валют с сайта ЦБ РФ за указанную дату
    public class CurrencyRates
    {
        public class ValCurs
        {
            [XmlElementAttribute("Valute")]
            public ValCursValute[] ValuteList;
        }

        public class ValCursValute
        {
            [XmlAttribute("ID")]
            public string ID { get; set; }
            [XmlElementAttribute("Value")]
            public string Value { get; set; }
        }

        public static List<CurrencyRate> GetCurrencyRate(string date)
        {
            string address = String.Format(@"{0}{1}", @"http://www.cbr.ru/scripts/XML_daily.asp?date_req=", date);
            List<CurrencyRate> result = new List<CurrencyRate>();
            XmlSerializer xs = new XmlSerializer(typeof(ValCurs));
            XmlReader xr = new XmlTextReader(address);
            foreach (ValCursValute valute in ((ValCurs)xs.Deserialize(xr)).ValuteList)
            {
                result.Add(new CurrencyRate()
                {
                    ID = valute.ID,
                    Value = Convert.ToDouble(valute.Value),
                    Date = date
                });
            }
            return result;
        }
    }
}