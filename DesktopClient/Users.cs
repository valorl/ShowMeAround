using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Service;

namespace DesktopClient
{
    public partial class Users : Form
    {
        public Users()
        {
            InitializeComponent();
            //UserDA.GetAll();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            UserService.Create(User user);
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            //no action for now
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            //no action for now
        }

        private void FillButton_Click(object sender, EventArgs e)
        {
            UserService.GetAll();
        }
    }
}
