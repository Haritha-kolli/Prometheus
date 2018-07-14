using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionLibrary
{
    public class HomeworkException : ApplicationException
    {
        public HomeworkException():base()
        {

        }
        public HomeworkException(string message):base(message)
        {

        }
    }
}
