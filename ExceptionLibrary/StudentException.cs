using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionLibrary
{
    public class StudentException : ApplicationException
    {
        public StudentException():base()
        {

        }
        public StudentException(string message):base(message)
        {

        }
    }
}
