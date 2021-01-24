using System;
using System.Windows.Forms;
using UI.View.IView;

namespace UI.View
{
    public partial class AddExchangeRateForm : Form, IAddExchangeRate
    {
        public AddExchangeRateForm()
        {
            InitializeComponent();
            buttonAdd.Click += ButtonAdd_Click;
            dateTimePicker1.MaxDate = DateTime.Now;
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            if (Add != null)
                Add(this, EventArgs.Empty);
        }

        #region IAddExchangeRate

        public string Date { get { return this.dateTimePicker1.Value.ToString("dd.MM.yyyy"); } }
        public event EventHandler Add;
        #endregion
    }
}
