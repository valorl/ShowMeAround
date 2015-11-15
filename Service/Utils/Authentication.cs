using Data;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using Data.Utils;

namespace Service.Utils
{
    public class Authentication
    {
        UserDA userDA;
        SessionDA sessionDA;

        public Authentication()
        {
            userDA = new UserDA();
            sessionDA = new SessionDA();
        }

        // 
        public bool AuthenticateUser(User user, string token)
        {
            var session = sessionDA.GetOneByToken(token);
            if (session == null) throw new ArgumentException("Authentication.Authenticate: Invalid token.");
            if (session.UserID == user.Id)
            {
                // Check if expired
                TimeSpan sinceToken = DateTime.Now - session.TimeStamp;
                if (sinceToken.TotalMinutes >= 15)
                {
                    sessionDA.Delete(session);
                    sessionDA.SaveChanges();
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        }

        public bool ValidateToken(string token)
        {
            var session = sessionDA.GetOneByToken(token);
            if (session == null) return false;
            TimeSpan sinceToken = DateTime.Now - session.TimeStamp;
            if (sinceToken.TotalMinutes >= 15)
            {
                sessionDA.Delete(session);
                sessionDA.SaveChanges();
                return false;
            }
            else return true;
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