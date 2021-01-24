using Model;
using UI.View.IView;

namespace UI.Presenter
{
    public class AllCurrenciesPresenter
    {
        private readonly IAllCurrencies _view;
        private Manager _manager;

        public AllCurrenciesPresenter(IAllCurrencies view, Manager manager)
        {
            this._view = view;
            this._manager = manager;
            _view.Data = _manager.GetCurrencies();
        }
    }
}
