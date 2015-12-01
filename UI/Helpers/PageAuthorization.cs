
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Utilities;

namespace UI.Helpers
{
    public static class PageAuthorization
    {
        public static bool Authorize()
        {
            if (System.Web.HttpContext.Current.Session["logged_in_user_obj"] != null) return true;
            return false;
        }
    }


    
}