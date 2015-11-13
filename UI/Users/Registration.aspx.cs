using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess;
using Data;
using System.Net.Http;

namespace UI.Users
{
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage wcfResponse = client.GetAsync("http://localhost:3729/HttpService.svc/MyHttpGetData/10").Result;
            HttpContent stream = wcfResponse.Content;
            var data = stream.ReadAsStringAsync();
           // Label1.Text = data.Result;
        }

    }
}