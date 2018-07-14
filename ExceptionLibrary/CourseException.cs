using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionLibrary
{
    public class CourseException:ApplicationException
    {
        public CourseException():base()
        {

        }
        public CourseException(string message):base(message)
        {

        }
    }
}
