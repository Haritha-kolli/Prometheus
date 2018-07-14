using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionLibrary
{
    public class TeacherException : ApplicationException
    {
        public TeacherException() : base()
        {

        }
        public TeacherException(string message):base(message)
        {

        }
    }
}
