using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            DataGridViewRowCollection rows = dataGridViewMenu.Rows;
            rows.Add(new Object[] {"紅茶",25 });
            rows.Add(new Object[] { "綠茶", 25 });
            rows.Add(new Object[] { "奶茶", 30 });
            rows.Add(new Object[] { "珍珠奶茶", 35 });

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
            subtotal();
            dataGridViewOrder.Rows.Add(new Object[] { name, price, number, sum });
            calculate();
        }

        string name;
        double price;
        double number;
        double sum;

        private void subtotal() {
             name = buttonName.Text;
             price = double.Parse(textBoxPrice.Text);
             number = (double)numericUpDownNumber.Value;
             sum = price * number;
            textBoxTotal.Text = sum.ToString();

        }

        private void numericUpDownNumber_ValueChanged(object sender, EventArgs e)
        {
            subtotal(); 
        }

        private void calculate() {
            double sum = 0.0;

            for (int i = 0; i < dataGridViewOrder.Rows.Count; i++) {
                DataGridViewRow row = dataGridViewOrder.Rows[i];
                if(row.Cells[0].Value!= null)
                {
                    sum = sum + (double)row.Cells[3].Value;
                }
                textBoxTotals.Text = sum.ToString();
            }

        }
    }
}
