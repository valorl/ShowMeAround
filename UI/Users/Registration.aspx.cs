using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess;
using Data;
using System.Net.Http;
using System.IO;
using System.Web.Services;
using System.Web.Script.Services;
using System.Globalization;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Web.ModelBinding;
using System.Text;

namespace UI.Users
{
    public partial class Registration : System.Web.UI.Page
    {
        private User user = new User();
        static StringBuilder strDiv = new StringBuilder();
        protected void Page_Load(object sender, EventArgs e)
        {
             ProgressUpdatePanel.ContentTemplateContainer.Controls.Add(languageLabel);
             ProgressUpdatePanel.Update();
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            
            user.LastName = lastname.ToString();
            user.FirstName = firstname.ToString();
            user.Email = email.ToString();
            user.BirthDate = DateTime.Parse(Request.Form[birthdate.UniqueID]);

            foreach (DataListItem item in DataList1.Items)
            {
                if (!(item.FindControl("CheckBox1") as CheckBox).Checked)
                {
                    Interest interest = new Interest();
                    interest.Name = item.ToString();
                    user.AddInterest(interest);
                }
            }
              
            HttpClient client = new HttpClient();
            HttpResponseMessage wcfResponse = client.GetAsync("http://localhost:3729/HttpService.svc/MyHttpGetData/10").Result;
            HttpContent stream = wcfResponse.Content;
            var data = stream.ReadAsStringAsync();
            // Label1.Text = data.Result;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Language language = new Language();
            language.Name = DropDownList1.SelectedItem.ToString();
            
            if (!strDiv.ToString().Contains(DropDownList1.SelectedItem.Text.ToString()))
            {
                strDiv.Append(string.Format(@DropDownList1.SelectedItem.ToString()) + " ");
                languageLabel.Text += strDiv.ToString();
                user.AddLanguage(language);
            }
            else
            {
                languageLabel.Text = strDiv.ToString() + " ";
            }

        }
    }
}