using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class LoginRepository : ILoginRepository
    {
        private GreenPayContext db;

        public LoginRepository(GreenPayContext context)
        {
            this.db = context;
        }
        public bool IsExitUser(string username, string password)
        {
            return db.AdminLogins.Any(u => u.UserName == username && u.Password == password);
        }
    }
}
