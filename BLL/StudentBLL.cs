using DAL;
using Entites;
using ExceptionLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BLL
{
   public  class StudentBLL
    {
        int ID;

        PrometheusDAL dal = null;

        public StudentBLL(string constring)
        {
            dal = new PrometheusDAL(constring);

        }
        //Validations;
        #region ValidateEditDetails()

        public bool ValidateEditDetails(Student student)
        {
            StringBuilder errorList = new StringBuilder();
            bool validate = true;
            try
            {
                //FName
                if (student.FName == string.Empty)
                {
                    errorList.AppendLine("First Name should be provided..");
                    validate = false;
                }

                else if (!Regex.IsMatch(student.FName, @"[A-Za-z ]+"))
                {
                    errorList.AppendLine("First Name should start with A-Z|a-z..");
                    validate = false;
                }

                //LName Validation
                if (student.LName == string.Empty)
                {
                    errorList.AppendLine("Last Name should be provided..");
                    validate = false;
                }

                else if (!Regex.IsMatch(student.LName, @"[A-Za-z ]+"))
                {
                    errorList.AppendLine("Last Name should start with A-Z|a-z..");
                    validate = false;
                }


                if ((student.DOB.ToString()) == string.Empty)
                {
                    errorList.AppendLine("DOB should be provided..");
                    validate = false;
                }
                //Mobile Number
                if (student.MobileNo.ToString() == string.Empty)
                {
                    errorList.AppendLine("Mobile Number should be provided..");
                    validate = false;
                }
                else if (!Regex.IsMatch(student.MobileNo.ToString(), @"^[6-9]{1}[0-9]{9}"))
                {
                    errorList.AppendLine("Mobile Number should begin with 6|7|8|9..");
                    validate = false;
                }

                //City
                if (student.City == string.Empty)
                {
                    errorList.AppendLine("Please enter the City..");
                    validate = false;
                }
                if (validate == false)
                {
                    throw new StudentException(errorList.ToString());
                }
            }
            catch (StudentException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
            return validate;
        }
        #endregion


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

        #region GetStudentMyProfile(int studentID)
        public Student GetStudentMyProfile(int studentID)
        {

            try
            {
                return dal.ViewStudentMyProfile(studentID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region EnrollACourse(int CourseID, int StudID)
        public int EnrollACourse(int cID, int StudID)
        {
            try
            {
                int res = dal.CheckEnrollment(cID, StudID);
                if (res == 1)
                {
                    return 0;
                }
                else
                {
                    return dal.EnrollACourse(cID, StudID);
                }
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
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

      

        #region UpdateMyDetails(Student student)
        public int UpdateStudentDetails(Student student)
        {

            int result = 0;
            try
            {
                if (ValidateEditDetails(student))
                {
                    result = dal.UpdateStudentDetails(student);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
         
        }
        
        #endregion



        #region ViewMyCourses(int iD)
        public IEnumerable<Course> ViewMyCourses(int iD)
        {
            try
            {
                return dal.ViewStudentCourses(iD);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region ViewMyAssignments(int courseID)
        public IEnumerable<Homework> ViewMyAssignments(int courseID)
        {
            try
            {
                return dal.ViewMyAssignments(courseID);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region ViewMyCoursesDetails(int courseID)
        public IEnumerable<Course> ViewMyCourseDetails(int courseID)
        {
            try
            {
                return dal.ViewMyCourseDetails(courseID);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
