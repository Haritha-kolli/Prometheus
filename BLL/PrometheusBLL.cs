using DAL;
using Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class PrometheusBLL
    {

        int ID;

        PrometheusDAL dal = null;

        public PrometheusBLL(string constring)
        {
            dal = new PrometheusDAL(constring);
           
        }
        #region GetAvailableCourses()
        public IEnumerable<Course> GetAvailableCourses()
        {

            try
            {
                return dal.ViewAvailableCourses();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion


        #region onLogin(string userid, string password)
        public int onLogin(int userid, string password)
        {
           
            try
            {
                
                return dal.onLogin(userid, password);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        #endregion


    }
}
