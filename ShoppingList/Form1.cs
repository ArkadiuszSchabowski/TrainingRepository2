using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShoppingList
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Btn1_Click(object sender, EventArgs e)
        {
            if (ProgressBar1.Value < 100)
            {
                if (TextBox1.Text.Length != 0)
                {
                    if (ListBox1.Items.Contains(TextBox1.Text))
                    {
                        DialogResult result = MessageBox.Show("Element jest już na liście. Czy chcesz go dodać ponownie?", "Ostrzeżenie", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (result == DialogResult.No)
                        {
                        MessageBox.Show("Element nie został dodany!", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            TextBox1.Clear();
                            return;
                        }
                    }
                    ListBox1.Items.Add(TextBox1.Text);
                    ProgressBar1.Value += 10;
                    TextBox1.Clear();
                }
                else
                {
                    MessageBox.Show("Próbowano dodać pusty element!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Lista jest pełna!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Btn2_Click(object sender, EventArgs e)
        {
            int i = ListBox1.SelectedIndex;
            if (i != -1)
            {
                ListBox1.Items.RemoveAt(ListBox1.SelectedIndex);
                ProgressBar1.Value -= 10;
            }
            else
            {
                MessageBox.Show("Nie zaznaczono elementu!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void Btn3_Click(object sender, EventArgs e)
        {
            ListBox1.Items.Clear();
            ProgressBar1.Value = 0;
        }
    }
}
