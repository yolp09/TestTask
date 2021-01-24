using System;

namespace UI.View.IView
{
    public interface IAddExchangeRate
    {
        string Date { get; }
        event EventHandler Add;
    }
}
