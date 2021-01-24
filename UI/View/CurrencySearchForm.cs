using Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using UI.View.IView;

namespace UI.View
{
    public partial class CurrencySearchForm : Form, ICurrencySearch
    {
        public CurrencySearchForm()
        {
            InitializeComponent();
            buttonSearch.Click += ButtonSearch_Click;
            dateTimePicker1.MaxDate = DateTime.Now;
        }

        private void ButtonSearch_Click(object sender, EventArgs e)
        {
            if (Search != null)
                Search(this, EventArgs.Empty);
        }
        private void comboBoxCyrrency_SelectedIndexChanged(object sender, EventArgs e)
        {
            ModelComboBox command = (ModelComboBox)comboBoxCyrrency.SelectedItem;
            ID = command.Id;
        }

        #region ICurrencySearch
        public List<ModelComboBox> ListCurrencies
        {
            set
            {
                comboBoxCyrrency.DataSource = value; comboBoxCyrrency.DisplayMember = "Name";
                comboBoxCyrrency.ValueMember = "Id";
            }
        }
        public string Date { get { return this.dateTimePicker1.Value.ToString("dd.MM.yyyy"); } }
        public string ID { get; private set; }
        public event EventHandler Search;
        #endregion
    }
}
