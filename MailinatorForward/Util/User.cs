using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace MailinatorForward.Util
{
    class User
    {
        String FirstName;
        String LastName;
        String Address;
        int Id;

        public User(String _FirstName, String _Lastname, String _Address, int _Id) {

            this.FirstName = _FirstName;
            this.LastName = _Lastname;
            this.Address = _Address;
            this.Id = _Id;

        }
        public String GetFirstName()
        {
            return FirstName;
        }
        public String GetLastName()
        {
            return LastName;
        }
        public String GetAddress()
        {
            return Address;
        }
        public int GetId()
        {
            return Id;
        }
        public String MakeString() {
            String info;
            info = String.Format("This is a forwarded email, originally sent to {0} {1}, Id number {2}", FirstName, LastName, Id);
            return info;
        }
    }
}
