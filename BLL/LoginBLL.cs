using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BLL
{
    public class LoginBLL
    {
        Login lg = new Login();

        public bool login(string tk, string mk)
        {
            return lg.LoginDAO(tk,mk);
        }

    }
}
