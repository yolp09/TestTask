using System;

namespace UI.View.IView
{
    public interface IMainForm : IView
    {
        event EventHandler AllCurrencies;
        event EventHandler CurrencySearch;
        event EventHandler AddExchangeRate;
        event EventHandler AddCurrencies;
    }
}