using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp21
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            laptop laptop = new laptop();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = laptop.reedbyall();
        }
        public db db1=new db();
        bool b=false;
        private void button1_Click(object sender, EventArgs e)
        {
            if (b == false)
            {
                laptop laptop = new laptop() { model = textBox1.Text, cpu = textBox2.Text, price = Convert.ToDouble(textBox3.Text) };
                bool b = laptop.register(laptop);
                if (b)
                {
                    MessageBox.Show("register succsesfuly");
                }
                else
                {
                    MessageBox.Show("register is faild becuase the product is repeatily");
                }
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = laptop.reedbyall();
            }
            else
            {
                if(id!=0)
                {
                    laptop laptop = new laptop() { model = textBox1.Text, cpu = textBox2.Text, price = Convert.ToDouble(textBox3.Text) };
                    laptop.update(id, laptop);
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = laptop.reedbyall();
                }
                button1.Text = "register";
                b = false;
            }
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            laptop laptop = new laptop();
            if (textBox4.Text == "")
            {
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = laptop.reedbyall();
            }
            else
            {

                dataGridView1.DataSource = null;
                dataGridView1.DataSource = laptop.reedbymodel(textBox4.Text);
            }
        }
        public int id=0;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id =(int) dataGridView1.Rows[e.RowIndex].Cells[0].Value;
            laptop laptop = new laptop();
            
            laptop= laptop.reedbyid(id);
            textBox1.Text = laptop.model;
            textBox2.Text = laptop.cpu;
            textBox3.Text = laptop.price.ToString();
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button1.Text = "update";
            b = true;
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            laptop laptop= new laptop();
            DialogResult = MessageBox.Show("do you want delete this ?", "warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (DialogResult == DialogResult.Yes)
            {
                if (id != 0)
                {
                    laptop.delete(id);
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = laptop.reedbyall();
                }
                else
                {
                    MessageBox.Show("please select a laptop");
                }
            }

           
        }
    }
}
