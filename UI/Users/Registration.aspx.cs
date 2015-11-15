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

namespace UI.Users
{
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            User user = new User();
            user.LastName = lastname.ToString();
            user.FirstName = firstname.ToString();
            user.Email = email.ToString();

            HttpClient client = new HttpClient();
            HttpResponseMessage wcfResponse = client.GetAsync("http://localhost:3729/HttpService.svc/MyHttpGetData/10").Result;
            HttpContent stream = wcfResponse.Content;
            var data = stream.ReadAsStringAsync();
            // Label1.Text = data.Result;
        }

        public void addLanguages()
        {
           // List<string> allLanguages = new List<string>();
            foreach (CultureInfo item in CultureInfo.GetCultures(CultureTypes.InstalledWin32Cultures))
            {
                languageList.Items.Add(item.Name);

            }
        }

    }
}