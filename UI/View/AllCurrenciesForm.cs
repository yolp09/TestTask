using System.Data;
using System.Windows.Forms;
using UI.View.IView;

namespace UI.View
{
    public partial class AllCurrenciesForm : Form, IAllCurrencies
    {
        public AllCurrenciesForm()
        {
            InitializeComponent();
            this.dataGridView1.ReadOnly = true;
        }

        public DataSet Data { set { dataGridView1.DataSource = value.Tables[0]; } }
    }
}
