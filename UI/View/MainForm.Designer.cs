namespace UI.View
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonAllCurrencies = new System.Windows.Forms.Button();
            this.buttonCurrencySearch = new System.Windows.Forms.Button();
            this.buttonAddCurrencies = new System.Windows.Forms.Button();
            this.buttonAddExchangeRate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonAllCurrencies
            // 
            this.buttonAllCurrencies.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAllCurrencies.Location = new System.Drawing.Point(36, 52);
            this.buttonAllCurrencies.Name = "buttonAllCurrencies";
            this.buttonAllCurrencies.Size = new System.Drawing.Size(237, 72);
            this.buttonAllCurrencies.TabIndex = 0;
            this.buttonAllCurrencies.Text = "Просмотр всех валют";
            this.buttonAllCurrencies.UseVisualStyleBackColor = true;
            // 
            // buttonCurrencySearch
            // 
            this.buttonCurrencySearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonCurrencySearch.Location = new System.Drawing.Point(36, 152);
            this.buttonCurrencySearch.Name = "buttonCurrencySearch";
            this.buttonCurrencySearch.Size = new System.Drawing.Size(237, 72);
            this.buttonCurrencySearch.TabIndex = 1;
            this.buttonCurrencySearch.Text = "Поиск курса валют на определенную дату";
            this.buttonCurrencySearch.UseVisualStyleBackColor = true;
            // 
            // buttonAddCurrencies
            // 
            this.buttonAddCurrencies.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAddCurrencies.Location = new System.Drawing.Point(352, 52);
            this.buttonAddCurrencies.Name = "buttonAddCurrencies";
            this.buttonAddCurrencies.Size = new System.Drawing.Size(328, 72);
            this.buttonAddCurrencies.TabIndex = 2;
            this.buttonAddCurrencies.Text = "Добавление в таблицу всех валют с сайта ЦБ РФ";
            this.buttonAddCurrencies.UseVisualStyleBackColor = true;
            // 
            // buttonAddExchangeRate
            // 
            this.buttonAddExchangeRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAddExchangeRate.Location = new System.Drawing.Point(352, 152);
            this.buttonAddExchangeRate.Name = "buttonAddExchangeRate";
            this.buttonAddExchangeRate.Size = new System.Drawing.Size(328, 72);
            this.buttonAddExchangeRate.TabIndex = 3;
            this.buttonAddExchangeRate.Text = "Добавление в таблицу курса валют за указанную дату";
            this.buttonAddExchangeRate.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 374);
            this.Controls.Add(this.buttonAddExchangeRate);
            this.Controls.Add(this.buttonAddCurrencies);
            this.Controls.Add(this.buttonCurrencySearch);
            this.Controls.Add(this.buttonAllCurrencies);
            this.Name = "MainForm";
            this.Text = "Курсы валют";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonAllCurrencies;
        private System.Windows.Forms.Button buttonCurrencySearch;
        private System.Windows.Forms.Button buttonAddCurrencies;
        private System.Windows.Forms.Button buttonAddExchangeRate;
    }
}