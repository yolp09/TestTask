using System.Data;

namespace UI.View.IView
{
    public interface IAllCurrencies : IView
    {
        DataSet Data { set; }
    }
}
