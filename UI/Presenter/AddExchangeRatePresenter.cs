using Model;
using System;
using System.Windows.Forms;
using UI.View.IView;

namespace UI.Presenter
{
    public class AddExchangeRatePresenter
    {
        private readonly IAddExchangeRate _view;
        private Manager _manager;

        public AddExchangeRatePresenter(IAddExchangeRate view, Manager manager)
        {
            this._view = view;
            this._manager = manager;
            _view.Add += View_Add;
        }

        private async void View_Add(object sender, System.EventArgs e)
        {
            try
            {
                await _manager.AddExchangeRateAsync(_view.Date);
                MessageBox.Show($"Данные за {_view.Date} загружены", "Выполнено");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message,"Предупреждение");
            }
        }
    }
}
