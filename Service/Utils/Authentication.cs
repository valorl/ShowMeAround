using Data;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using Data.Utils;
using System.ServiceModel.Web;

namespace Service.Utils
{
    public class Authentication
    {
        private const string _adminpass = "T1mU2YUBjCLUrkhmI4UV";
        UserDA userDA;
        SessionDA sessionDA;

        public Authentication()
        {
            userDA = new UserDA();
            sessionDA = new SessionDA();
        }


        public string SMA_ADMIN_PASS
        {
            get { return _adminpass; }
        }


        public User Authorize(IncomingWebRequestContext request)
        {
            var headers = request.Headers;
            var auth_header = headers.Get("sma_auth");
            if (auth_header == null) throw new WebFaultException(System.Net.HttpStatusCode.Unauthorized);  // Return 401

            string token = auth_header.Split()[1];

            if (!ValidateToken(token)) throw new WebFaultException(System.Net.HttpStatusCode.Unauthorized);  // Return 401
            return userDA.GetOneByID(sessionDA.GetOneByToken(token).UserID);
        }

        public bool ValidateToken(string token)
        {
            var session = sessionDA.GetOneByToken(token);
            if (session == null) return false;
            TimeSpan sinceToken = DateTime.Now - session.TimeStamp;
            if (sinceToken.TotalMinutes >= 60)
            {
                sessionDA.Delete(session);
                sessionDA.SaveChanges();
                return false;
            }
            else
            {
                session.TimeStamp = DateTime.Now;
                sessionDA.Update(session);
                sessionDA.SaveChanges();
                return true;
            }
        }

        public bool ValidateCredentials(string email, string password)
        {
            var user = userDA.GetOneByEmail(email);
            if (user == null) return false;
            var salt = user.PwDSalt;

            if (PasswordHasher.HashPwd(password, salt) == user.PwdHash) return true;
            return false;
        }
    }
}