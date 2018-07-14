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
    public  class AdminBLL
    {

        AdminDAL dal = null;

        public AdminBLL(string constring)
        {
            dal = new AdminDAL(constring);
        }
        //Validation;
        #region ValidateHomework()
        public bool ValidateHomework(Homework homework)
        {
            StringBuilder errorList = new StringBuilder();
            bool validate = true;
            try
            {
                if (homework.Description == string.Empty)
                {
                    errorList.AppendLine("Description should be provided..");
                    validate = false;
                }
                if (homework.DeadLine.ToString() == string.Empty)
                {
                    errorList.AppendLine("Deadline should be provided");
                    validate = false;
                }
                if (homework.ReqTime.ToString() == string.Empty)
                {
                    errorList.AppendLine("Required time should be provided");
                    validate = false;
                }
                if (homework.LongDescription == string.Empty)
                {
                    errorList.AppendLine("Long description should be provided");
                    validate = false;
                }
                if (validate == false)
                {
                    throw new HomeworkException(errorList.ToString());
                }
            }
            catch (HomeworkException ex)
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

        #region ValidateEditDetails()
            
        public bool ValidateEditDetails(Teacher teacher)
        {
            StringBuilder errorList = new StringBuilder();
            bool validate = true;
            try
            {
                //FName
                if (teacher.FName == string.Empty)
                {
                    errorList.AppendLine("First Name should be provided..");
                    validate = false;
                }

                else if (!Regex.IsMatch(teacher.FName, @"[A-Za-z ]+"))
                {
                    errorList.AppendLine("First Name should start with A-Z|a-z..");
                    validate = false;
                }

                //LName Validation
                if (teacher.LName == string.Empty)
                {
                    errorList.AppendLine("Last Name should be provided..");
                    validate = false;
                }

                else if (!Regex.IsMatch(teacher.LName, @"[A-Za-z ]+"))
                {
                    errorList.AppendLine("Last Name should start with A-Z|a-z..");
                    validate = false;
                }


                if ((teacher.DOB.ToString()) == string.Empty)
                {
                    errorList.AppendLine("DOB should be provided..");
                    validate = false;
                }
                //Mobile Number
                if (teacher.MobileNo.ToString() == string.Empty)
                {
                    errorList.AppendLine("Mobile Number should be provided..");
                    validate = false;
                }
                else if (!Regex.IsMatch(teacher.MobileNo.ToString(), @"^[6-9]{1}[0-9]{9}"))
                {
                    errorList.AppendLine("Mobile Number should begin with 6|7|8|9..");
                    validate = false;
                }

                //City
                if (teacher.City == string.Empty)
                {
                    errorList.AppendLine("Please enter the City..");
                    validate = false;
                }
                if (validate == false)
                {
                    throw new TeacherException(errorList.ToString());
                }
            }
            catch (TeacherException ex)
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

        #region ValidateAddStudent()
        public bool ValidateAddStudent(Student student)
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
            catch(StudentException ex)
            {
                throw ex;
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return validate;
        }

        #endregion

        #region ValidateAddTeacher()

        public bool ValidateAddTeacher(Teacher teacher)
        {
            StringBuilder errorList = new StringBuilder();
            bool validate = true;
            try
            {
                //FName
                if (teacher.FName == string.Empty)
                {
                    errorList.AppendLine("First Name should be provided..");
                    validate = false;
                }

                else if (!Regex.IsMatch(teacher.FName, @"[A-Za-z ]+"))
                {
                    errorList.AppendLine("First Name should start with A-Z|a-z..");
                    validate = false;
                }

                //LName Validation
                if (teacher.LName == string.Empty)
                {
                    errorList.AppendLine("Last Name should be provided..");
                    validate = false;
                }

                else if (!Regex.IsMatch(teacher.LName, @"[A-Za-z ]+"))
                {
                    errorList.AppendLine("Last Name should start with A-Z|a-z..");
                    validate = false;
                }


                if ((teacher.DOB.ToString()) == string.Empty)
                {
                    errorList.AppendLine("DOB should be provided..");
                    validate = false;
                }
                //Mobile Number
                if (teacher.MobileNo.ToString() == string.Empty)
                {
                    errorList.AppendLine("Mobile Number should be provided..");
                    validate = false;
                }
                else if (!Regex.IsMatch(teacher.MobileNo.ToString(), @"^[6-9]{1}[0-9]{9}"))
                {
                    errorList.AppendLine("Mobile Number should begin with 6|7|8|9..");
                    validate = false;
                }

                //City
                if (teacher.City == string.Empty)
                {
                    errorList.AppendLine("Please enter the City..");
                    validate = false;
                }
                if (validate == false)
                {
                    throw new TeacherException(errorList.ToString());
                }
            }
            catch (TeacherException ex)
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

        #region GetTeacherMyProfile(int teacherID)
        public Teacher GetTeacherMyProfile(int teacherID)
        {

            try
            {
                return dal.ViewTeacherMyProfile(teacherID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region EnrollACourse(int CourseID, int TeachID)
        public int EnrollACourse(int cID, int TeachID)
        {
            try
            {
                int res = dal.CheckEnrollment(cID, TeachID);
                if (res == 1)
                {
                    return 0;
                }
                else
                {
                    return dal.EnrollACourse(cID, TeachID);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region UpdateMyDetails(Teacher teacher)
        public int UpdateTeacherDetails(Teacher teacher)
        {
            int result = 0;
            try
            {
                if(ValidateEditDetails(teacher))
                {
                    result = dal.UpdateTeacherDetails(teacher);
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
                return dal.ViewMyTeachingCourses(iD);
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
                return dal.ViewMyCourseAssignments(courseID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region ViewAllTeacherDetails()
        public IEnumerable<Teacher> ViewAllTeacherDetails()
        {
            try
            {
                return dal.ViewAllTeacherDetails();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region CreateNewHomework(Homework homework,int ID, int courseID)
        public int CreateNewHomework(Homework homework, int ID, int courseID)
        {
            int result = 0;
            try
            {
                if (ValidateHomework(homework))
                {
                    result = dal.CreateNewHomework(homework, ID, courseID);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }


        #endregion

        #region AddStudent()
        public int AddStudent(Student student)
        {
            int result = 0;
            try
            {
                if(ValidateAddStudent(student))
                {
                    result = dal.AddStudent(student);
                }
               
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return result;
        }
        #endregion

        #region AddTeacher()
        public int AddTeacher(Teacher teacher)
        {
            int result = 0;
            try
            {
                if(ValidateAddTeacher(teacher))
                {
                    result = dal.AddTeacher(teacher);
                }
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
        #endregion

        #region ViewStudentDetails(int courseID)
        public IEnumerable<Student> ViewStudentDetails(int courseID)
        {
            try
            {
                return dal.ViewStudentDetails(courseID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region GrantAdminRight(int teachID)
        public int GrantAdminRight(int teachID)
        {
            try
            {
                return dal.GrantAdminRight(teachID);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region RevokeAdminRight(int teachID)
        public int RevokeAdminRight(int teachID)
        {
            try
            {
                return dal.RevokeAdminRight(teachID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
