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
using Utilities;
using Data;

namespace DesktopClient
{
    public partial class Users : Form
    {
        private SMARestClient client;
        private List<User> users;

        public Users()
        {
            InitializeComponent();
            client = new SMARestClient("UserService.svc");
            users = new List<User>();

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            client.AdminToken = "T1mU2YUBjCLUrkhmI4UV";

            lblNameContent.MaximumSize = new Size(200, 0);
            lblNameContent.AutoSize = true;

            lblInterestedContent.MaximumSize = new Size(200, 0);
            lblInterestedContent.AutoSize = true;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            listUsers.DataSource = null;
            listUsers.DisplayMember = "FirstName";
            listUsers.DataSource = client.Get<List<User>>("/users");
        }

        private void btnViewEdit_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            client.AdminToken = "T1mU2YUBjCLUrkhmI4UV";
            var listItems = (List<User>)listUsers.DataSource;
            User user = (User)listUsers.SelectedItem;
            int id = user.Id;
            if (user != null)
            { 
                listItems.Remove(user);
                listUsers.DataSource = null;
                listUsers.DataSource = listItems;
                client.Delete("/user", user.Id);

            }
          }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void listUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            var list = (ListBox)sender;
            User user = (User)list.SelectedItem;

            if (user == null) return;

            lblNameContent.Text = user.FirstName + " " + user.LastName;
            tboxEmail.Text = user.Email;
            tboxBirthDate.Text = user.BirthDate.ToString("dd/MM/yyyy");
            tboxCity.Text = user.City.Name;

            if(user.Languages != null && user.Languages.Count > 0)
            {
                string speaks = "";
                foreach (var lang in user.Languages)
                {
                    speaks += lang.Name + ", ";
                }
                speaks.Substring(0, speaks.Length - 2);
                lblSpeaksContent.Text = speaks;
            }

            if(user.Interests != null && user.Interests.Count > 0)
            {
                string interests = "";
                foreach (var interest in user.Interests)
                {
                    interests += interest.Name + ", ";
                }
                interests.Substring(0, interests.Length - 2);
                lblInterestedContent.Text = interests;
            }

            lblMeetups.Text = "0";
        }

        private void listUsers_Format(object sender, ListControlConvertEventArgs e)
        {
            string first = ((User)e.ListItem).FirstName;
            string last = ((User)e.ListItem).LastName;
            e.Value = first + " " + last;
        }
    }
}
