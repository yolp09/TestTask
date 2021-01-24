using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

namespace Data
{
    //класс валют
    public class Currency
    {
        [XmlAttribute("ID")]
        public string ID { get; set; }
        [XmlElementAttribute("Name")]
        public string Name { get; set; }
        [XmlElementAttribute("EngName")]
        public string EngName { get; set; }
        [XmlElementAttribute("Nominal")]
        public int Nominal;
        [XmlElementAttribute("ParentCode")]
        public string ParentCode { get; set; }
        [XmlElementAttribute("ISO_Num_Code")]
        public string NumCode { get; set; }
        [XmlElementAttribute("ISO_Char_Code")]
        public string CharCode { get; set; }
    }
    //класс для получения всех валют с сайта ЦБ РФ
    public class Currencies
    {
        public class Valuta
        {
            [XmlElementAttribute("Item")]
            public Currency[] ValueList;
        }

        public static List<Currency> GetCurrencies()
        {
            List<Currency> result = new List<Currency>();
            XmlSerializer xs = new XmlSerializer(typeof(Valuta));
            XmlReader xr = new XmlTextReader(@"http://www.cbr.ru/scripts/XML_valFull.asp");
            foreach (Currency value in ((Valuta)xs.Deserialize(xr)).ValueList)
            {
                result.Add(value);
            }
            return result;
        }
    }
}
