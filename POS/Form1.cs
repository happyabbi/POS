using System;
using System.Windows.Forms;

namespace POS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            var rows = dataGridViewMenu.Rows;
            rows.Add("紅茶", 25);
            rows.Add("綠茶", 25);
            rows.Add("奶茶", 30);
            rows.Add("珍珠奶茶", 35);
            rows.Add("玉泉奶茶", 35);

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void dataGridViewMenu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewMenu.Rows[e.RowIndex].Cells[0].Value == null) {
                return;
            }

            buttonName.Text = dataGridViewMenu.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBoxPrice.Text = dataGridViewMenu.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Subtotal();
            dataGridViewOrder.Rows.Add(name, price, number, sum);
            Calculate();
        }

        string name;
        double price;
        double number;
        double sum;

        private void Subtotal() {
             name = buttonName.Text;
             price = double.Parse(textBoxPrice.Text);
             number = (double)numericUpDownNumber.Value;
             sum = price * number;
            textBoxTotal.Text = sum.ToString();

        }

        private void numericUpDownNumber_ValueChanged(object sender, EventArgs e)
        {
            Subtotal(); 
        }

        private void Calculate() {
            var sum = 0.0;

            for (int i = 0; i < dataGridViewOrder.Rows.Count; i++) {
                var row = dataGridViewOrder.Rows[i];
                if(row.Cells[0].Value!= null)
                {
                    sum = sum + (double)row.Cells[3].Value;
                }
                textBoxTotals.Text = sum.ToString();
            }

        }
    }
}
