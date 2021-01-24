using Model;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.View;
using UI.View.IView;

namespace UI.Presenter
{
    public class MainPresenter
    {
        private readonly IMainForm _view;
        private Manager _manager;

        public MainPresenter(IMainForm view)
        {
            this._view = view;
            this._manager = new Manager(Properties.Settings.Default.ConnectionString);
            _view.AllCurrencies += View_AllCurrencies;
            _view.CurrencySearch += View_CurrencySearch;
            _view.AddExchangeRate += View_AddExchangeRate;
            _view.AddCurrencies += View_AddCurrencies;
        }

        private async void View_AddCurrencies(object sender, EventArgs e)
        {
            try
            {
                await _manager.AddCurrenciesAsync();
                MessageBox.Show("Данные загружены", "Выполнено");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Предупреждение");
            }
        }

        private void View_AddExchangeRate(object sender, EventArgs e)
        {
            AddExchangeRateForm form = new AddExchangeRateForm();
            AddExchangeRatePresenter presenter = new AddExchangeRatePresenter(form, _manager);

            form.ShowDialog();
        }

        private async void View_CurrencySearch(object sender, EventArgs e)
        {
            try
            {
                await Task.Run(() =>
                {
                    CurrencySearchForm form = new CurrencySearchForm();
                    CurrencySearchPresenter presenter = new CurrencySearchPresenter(form, _manager);

                    form.ShowDialog();
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }

        private async void View_AllCurrencies(object sender, EventArgs e)
        {
            try
            {
                await Task.Run(() =>
                {
                    AllCurrenciesForm form = new AllCurrenciesForm();
                    AllCurrenciesPresenter presenter = new AllCurrenciesPresenter(form, _manager);

                    form.ShowDialog();
                });
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }
    }
}
