using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionLibrary
{
    public class LoginException:ApplicationException
    {
        public LoginException():base()
        {

        }
        public LoginException(string message):base(message)
        {

        }
    }
}
