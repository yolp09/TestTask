using System;
using System.Windows.Forms;
using UI.View.IView;

namespace UI.View
{
    public partial class MainForm : Form, IMainForm
    {
        public MainForm()
        {
            InitializeComponent();
            InitializeMyControl();
        }

        #region IMainForm

        public event EventHandler AllCurrencies;
        public event EventHandler CurrencySearch;
        public event EventHandler AddExchangeRate;
        public event EventHandler AddCurrencies;
        #endregion

        #region Проброс событий

        private void ButtonCurrencySearch_Click(object sender, EventArgs e)
        {
            if (CurrencySearch != null)
                CurrencySearch(this, EventArgs.Empty);
        }
        private void ButtonAllCurrencies_Click(object sender, EventArgs e)
        {
            if (AllCurrencies != null)
                AllCurrencies(this, EventArgs.Empty);
        }
        private void ButtonAddExchangeRate_Click(object sender, EventArgs e)
        {
            if (AddExchangeRate != null)
                AddExchangeRate(this, EventArgs.Empty);
        }
        private void ButtonAddCurrencies_Click(object sender, EventArgs e)
        {
            if (AddCurrencies != null)
                AddCurrencies(this, EventArgs.Empty);
        }
        #endregion

        private void InitializeMyControl()
        {
            buttonAllCurrencies.Click += ButtonAllCurrencies_Click;
            buttonCurrencySearch.Click += ButtonCurrencySearch_Click;
            buttonAddExchangeRate.Click += ButtonAddExchangeRate_Click;
            buttonAddCurrencies.Click += ButtonAddCurrencies_Click;
        }
    }
}
