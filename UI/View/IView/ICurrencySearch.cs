using Model;
using System;
using System.Collections.Generic;

namespace UI.View.IView
{
    public interface ICurrencySearch
    {
        List<ModelComboBox> ListCurrencies { set; }
        string ID { get; }
        string Date { get; }
        event EventHandler Search;
    }
}
