using Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using UI.View.IView;

namespace UI.Presenter
{
    public class CurrencySearchPresenter
    {
        private readonly ICurrencySearch _view;
        private Manager _manager;

        public CurrencySearchPresenter(ICurrencySearch view, Manager manager)
        {
            this._view = view;
            this._manager = manager;
            _view.ListCurrencies = GetListCurrencies();
            _view.Search += View_Search;
        }

        private async void View_Search(object sender, EventArgs e)
        {
            try
            {
                double result = await _manager.CurrencySearchAsync(_view.ID, _view.Date);
                MessageBox.Show(result.ToString(), "Выполнено");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message,"Предупреждение");
            }
        }

        private List<ModelComboBox> GetListCurrencies()
        {
            return _manager.GetIdName();
        }
    }
}
