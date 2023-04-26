using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pr15_bondyrev
{
    public partial class Form1 : Form
    {
        Organization_postal_addres person = new Organization_postal_addres();
        public Form1()
        {
            InitializeComponent();
            initDataGridView();
            groupBox2.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            switch (comboBox1.Text)
            {
                case "Москва":
                {
                    comboBox2.Text = "101000";
                    break;
                }
                case "Санкт-Петербург":
                {
                    comboBox2.Text = "187015";
                    break;
                }
                case "Новосибирск":
                {
                    comboBox2.Text = "630000";
                    break;
                }
                case "Екатеринбург":
                {
                    comboBox2.Text = "620000";
                    break;
                }
                case "Казань":
                {
                    comboBox2.Text = "420000";
                    break;
                }
            }
        }

        private void comboBox3_TextChanged(object sender, EventArgs e)
        {
            if (comboBox3.Text == "Квартира")
            {
                groupBox1.Visible = true;
                groupBox2.Visible = false;
            }
            else
            {
                groupBox2.Visible = true;
                groupBox1.Visible = false;
            }

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
        private DataGridViewColumn dataGridViewColumn1 = null;
        private DataGridViewColumn dataGridViewColumn2 = null;
        private DataGridViewColumn dataGridViewColumn3 = null;
        private DataGridViewColumn dataGridViewColumn4 = null;

        private List<Organization_postal_addres> list = new List<Organization_postal_addres>();

        private void initDataGridView()
        {
            dataGridView1.DataSource = null;
            dataGridView1.Columns.Add(getDataGridViewColumn1());
            dataGridView1.Columns.Add(getDataGridViewColumn2());
            dataGridView1.Columns.Add(getDataGridViewColumn3());
            dataGridView1.Columns.Add(getDataGridViewColumn4());
            dataGridView1.AutoResizeColumns();
        }
        private DataGridViewColumn getDataGridViewColumn1()
        {
            if (dataGridViewColumn1 == null)
            {
                dataGridViewColumn1 = new DataGridViewTextBoxColumn();
                dataGridViewColumn1.Name = "";
                dataGridViewColumn1.HeaderText = "ФИО";
                dataGridViewColumn1.ValueType = typeof(string);
                dataGridViewColumn1.Width = dataGridView1.Width / 4;
            }
            return dataGridViewColumn1;
        }
        private DataGridViewColumn getDataGridViewColumn2()
        {
            if (dataGridViewColumn2 == null)
            {
                dataGridViewColumn2 = new DataGridViewTextBoxColumn();
                dataGridViewColumn2.Name = "";
                dataGridViewColumn2.HeaderText = "Адрес";
                dataGridViewColumn2.ValueType = typeof(int);
                dataGridViewColumn2.Width = dataGridView1.Width / 4;
            }
            return dataGridViewColumn2;
        }
        private DataGridViewColumn getDataGridViewColumn3()
        {
            if (dataGridViewColumn3 == null)
            {
                dataGridViewColumn3 = new DataGridViewTextBoxColumn();
                dataGridViewColumn3.Name = "";
                dataGridViewColumn3.HeaderText = "Город";
                dataGridViewColumn3.ValueType = typeof(string);
                dataGridViewColumn3.Width = dataGridView1.Width / 4;
            }
            return dataGridViewColumn3;
        }
        private DataGridViewColumn getDataGridViewColumn4()
        {
            if (dataGridViewColumn4 == null)
            {
                dataGridViewColumn4 = new DataGridViewTextBoxColumn();
                dataGridViewColumn4.Name = "";
                dataGridViewColumn4.HeaderText = "Индекс";
                dataGridViewColumn4.ValueType = typeof(int);
                dataGridViewColumn4.Width = dataGridView1.Width / 4;
            }
            return dataGridViewColumn4;
        }
        private void addCitizen(string fio, string adress, string city, int index)
        {
            Organization_postal_addres s = new Organization_postal_addres(fio, adress, city, index);
            list.Add(s);
            textBox1.Text = "";
            textBox2.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            numericUpDown1.Value = 1;
            numericUpDown2.Value = 1;
            showListInGrid();
        }

        private void deletePersone(int elementIndex)
        {
            list.RemoveAt(elementIndex);
            showListInGrid();
        }
        private void showListInGrid()
        {
            dataGridView1.Rows.Clear();
            foreach (Organization_postal_addres s in list)
            {
                DataGridViewRow row = new DataGridViewRow();
                DataGridViewTextBoxCell cell1 = new DataGridViewTextBoxCell();
                DataGridViewTextBoxCell cell2 = new DataGridViewTextBoxCell();
                DataGridViewTextBoxCell cell3 = new DataGridViewTextBoxCell();
                DataGridViewTextBoxCell cell4 = new DataGridViewTextBoxCell();
                cell1.ValueType = typeof(string);
                cell1.Value = s.Fio;
                cell2.ValueType = typeof(string);
                cell2.Value = s.Adress;
                cell3.ValueType = typeof(string);
                cell3.Value = s.City;
                cell4.ValueType = typeof(int);
                cell4.Value = s.Index;
                row.Cells.Add(cell1);
                row.Cells.Add(cell2);
                row.Cells.Add(cell3);
                row.Cells.Add(cell4);
                dataGridView1.Rows.Add(row);
            }
        }
        bool chislo(string s)
        {
            foreach (var item in s)
            {
                if (!char.IsDigit(item))
                    return false;
            }
            return true;
        }
        bool nechislo(string s)
        {
            foreach (var item in s)
            {
                if (!char.IsLetter(item))
                    return false;
            }
            return true;
        }
        bool fioproverka(string s)
        {
            foreach (var item in s)
            {
                if (item == ' ')
                    continue;
                if (!char.IsLetter(item))
                    return false;
            }
            return true;
        }
        bool povtor(string str)
        {
            bool check = false;
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                dataGridView1.Rows[i].Selected = false;
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                    if (dataGridView1.Rows[i].Cells[j].Value != null)
                        if (dataGridView1.Rows[i].Cells[j].Value.ToString().Contains(str))
                        {
                            check = true;
                        }
            }
            return check;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            

        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int selectedRow = dataGridView1.SelectedCells[0].RowIndex;
            DialogResult dr = MessageBox.Show("Удалить строку", "",
            MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                try
                {
                    deletePersone(selectedRow);
                }
                catch (Exception)
                {
                }
            }

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
           
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && comboBox1.Text != "" && comboBox2.Text != "" && comboBox3.Text != "" && (textBox2.Text != ""||)
            {
                bool proverka1 = fioproverka(textBox1.Text);
                bool proverka2 = nechislo(textBox3.Text);
                bool proverka3 = chislo(textBox4.Text);
                bool proverka4 = chislo(textBox2.Text);
                bool proverka5 = chislo(textBox5.Text);
                bool proverka6 = povtor(textBox4.Text);
                if (proverka1 == true)
                {
                    if (proverka2 == true)
                    {
                        if (proverka3 == true && textBox4.TextLength == 10 && proverka6 == false)
                        {
                            if (proverka4 == true && Convert.ToInt32(textBox2.Text) > 1950 && Convert.ToInt32(textBox2.Text) <= 2023)
                            {
                                if (proverka5 == true && Convert.ToInt64(textBox5.Text) >= 80000000000 && Convert.ToInt64(textBox5.Text) < 90000000000)
                                {
                                    addCitizen(textBox1.Text, Convert.ToInt32(textBox2.Text), textBox3.Text, Convert.ToInt32(textBox4.Text), Convert.ToInt64(textBox5.Text));
                                }
                                else
                                    MessageBox.Show("Номер телефона должен состоять из 11 цифр и начинаться на 8");
                            }
                            else
                                MessageBox.Show("Год должен находиться в диапазоне от 1950 до 2023");
                        }
                        else
                            MessageBox.Show("Данные паспорта не могут повторяться и должны содержать только 10 цифр");
                    }
                    else
                        MessageBox.Show("Страна должно состоять только из букв");
                }
                else
                    MessageBox.Show("В ФИО гражданина могут быть только буквы");
            }
            else
                MessageBox.Show("Заполни все поля");
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                dataGridView1.Rows[i].Selected = false;
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                    if (dataGridView1.Rows[i].Cells[j].Value != null)
                        if (dataGridView1.Rows[i].Cells[j].Value.ToString().Contains(textBox1.Text))
                        {
                            dataGridView1.Rows[i].Selected = true;
                            break;
                        }
            }
        }
    }
}
