using Entites;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExceptionLibrary;

namespace DAL
{
    public class PrometheusDAL
    {
        //Connection, Command, DataReader
        SqlConnection cn = null;
        SqlCommand cmd = null;
        SqlDataReader dr = null;
       
        public PrometheusDAL(string conString)
        {
            cn = new SqlConnection(conString);
        }
        

        //Checked
        #region onLogin(int userid, string password)
        public int onLogin(int uid, string pasword)
        {
          
            int no = 0;
            int result = 0;

            try
            {
            

                //Authenticating Teacher using Stored Procedures;
                cmd = new SqlCommand("[haritha].[SPX_Student_150913_LoginCheck]", cn);
                cmd.Parameters.AddWithValue("@studentID", uid);
                cmd.Parameters.AddWithValue("@password", pasword);


                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cn.Open();
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    result = 3;
                    
                }

                else
                {
                    cmd = new SqlCommand("[haritha].[SPX_Teacher_150913_LoginCheck]", cn);
                    cmd.Parameters.AddWithValue("@teacherID", uid);
                    cmd.Parameters.AddWithValue("@password", pasword);


                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    dr.Close();
                    dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {

                        cmd = new SqlCommand("[haritha].[SPX_Admin_150913_Check]", cn);
                        cmd.Parameters.AddWithValue("@teacherID", uid);

                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        dr.Close();
                        dr = cmd.ExecuteReader();
                        if (dr.HasRows)
                        {
                            
                            result= 1;
                        }
                        else

                            result = 2;

                    }
                    else
                        result = 0;
                }

            }
            catch(TeacherException e)
            {
                throw e;
            }
            catch (StudentException e)
            {
                throw e;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dr.Close();
                cn.Close();
            }

            return result;

        }
        #endregion

       
        //checked
        #region AddStudent(Student student)
        public int AddStudent(Student student)
        {
            int no = 0;
            try
            {
               

                //Inserting Student Records using Stored Procedures;

                cmd = new SqlCommand("[haritha].[SPX_Insert_150913_Student]", cn);
                cmd.Parameters.AddWithValue("@FName", student.FName);
                cmd.Parameters.AddWithValue("@LName", student.LName);
                cmd.Parameters.AddWithValue("@DOB", student.DOB);
                cmd.Parameters.AddWithValue("@City", student.City);
                cmd.Parameters.AddWithValue("@Password", student.Pasword);
                cmd.Parameters.AddWithValue("@MobileNo", student.MobileNo);
               

                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cn.Open();
                no = cmd.ExecuteNonQuery();

            }
            catch (StudentException e)
            {
                throw e;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cn.Close();
            }

            return no;
        }
        #endregion

        //Checked - {student, teacher}
        #region ViewAvailableCourses()
        public IEnumerable<Course> ViewAvailableCourses()
        {
            List<Course> availableCourseList = new List<Course>();
            try
            {
                //Using stored Procedure
                cmd = new SqlCommand
                ("[haritha].[SPX_View_150913_AvailableCourses]", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cn.Open();
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Course course = new Course();
                        course.CourseID = (int)dr[0];
                        course.CourseName = dr[1].ToString();
                        course.StartDate = (DateTime)dr[2];
                        course.EndDate = (DateTime)dr[3];
                        availableCourseList.Add(course);
                    }
                }


            }
            catch (CourseException e)
            {
                throw e;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dr.Close();
                cn.Close();
            }
            return availableCourseList;
        }
        #endregion

        //Checked
        #region ViewStudentCourses(int studentID)


        public IEnumerable<Course> ViewStudentCourses(int studentID)
        {
            List<Course> myCourseList = new List<Course>();
            try
            {
                //Using stored Procedure
                cmd = new SqlCommand
                ("[haritha].[SPX_Student_150913_MyCourses]", cn);
                cmd.Parameters.AddWithValue("@studentID", studentID);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cn.Open();
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Course course = new Course();
                        course.CourseID = (int)dr[0];
                        course.CourseName = dr[1].ToString();
                        course.StartDate = (DateTime)dr[2];
                        course.EndDate = (DateTime)dr[3];
                        myCourseList.Add(course);
                    }
                }


            }
            catch (CourseException e)
            {
                throw e;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dr.Close();
                cn.Close();
            }
            return myCourseList;
        }
        #endregion

        //Checked
        #region EnrollACourse(int CourseID,int studentID)

        public int EnrollACourse(int CourseID, int StudentID)
        {

            int no = 0;
            try
            {

                //Inserting using Stored Procedures;
                    cmd = new SqlCommand("[haritha].[SPX_Enrolling_150913_Course]", cn);
                    cmd.Parameters.AddWithValue("@courseID", CourseID);
                    cmd.Parameters.AddWithValue("@studentID", StudentID);

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cn.Open();
                    no = cmd.ExecuteNonQuery();
               
            }
            catch (CourseException e)
            {
                throw e;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cn.Close();
            }

            return no;
        }

        #endregion

        //Checked
        #region CheckEnrollment

        public int CheckEnrollment(int CourseID, int StudentID)
        {

            int no = 0;
            try
            {

                //Inserting using Stored Procedures;

                cmd = new SqlCommand("[haritha].[SPX_StudentCheck_150913_Course]", cn);
                cmd.Parameters.AddWithValue("@cID", CourseID);
                cmd.Parameters.AddWithValue("@sID", StudentID);

                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cn.Open();
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    no = 1;
                }


            }
            catch (CourseException e)
            {
                throw e;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dr.Close();
                cn.Close();
            }
            return no;
        }


        #endregion

        //Checked
        #region ViewStudentMyProfile(int studentID)

        public Student ViewStudentMyProfile(int studentID)
        {
            Student student = new Student();

            try
            {
                //Using stored Procedure
                cmd = new SqlCommand
                ("[haritha].[SPX_Student_150913_MyProfile]", cn);
                cmd.Parameters.AddWithValue("@studentID", studentID);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cn.Open();
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        
                        student.StudentID = (int)dr[0];
                        student.FName = dr[1].ToString();
                        student.LName= dr[2].ToString();
                        student.DOB= (DateTime)dr[3];
                        student.City = dr[4].ToString(); ;
                        student.MobileNo= dr[6].ToString();
                    }
                }


            }
            catch (StudentException e)
            {
                throw e;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dr.Close();
                cn.Close();
            }
            return student;
        }

        #endregion

        //Checked
        #region UpdateStudentDetails(Student student)
        public int UpdateStudentDetails(Student student)
        {
            int no;
         
            try
            {
                
                //Using Stored Procedure;

                cmd = new SqlCommand("[haritha].[SPX_Update_150913_Student]", cn);
                cmd.Parameters.AddWithValue("@id", student.StudentID);
                cmd.Parameters.AddWithValue("@FName", student.FName);
                cmd.Parameters.AddWithValue("@LNAme", student.LName);
                cmd.Parameters.AddWithValue("@DOB", student.DOB);
                cmd.Parameters.AddWithValue("@City", student.City);
                cmd.Parameters.AddWithValue("@MobileNo", student.MobileNo);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cn.Open();
                no = cmd.ExecuteNonQuery();
            }
            catch (StudentException e)
            {
                throw e;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dr.Close();
                cn.Close();
            }
            return no;
        }


        #endregion

        //Checked
        #region ViewStudentAssignments(int courseID)

        public IEnumerable<Homework> ViewMyAssignments(int cID)
        {
            List<Homework> myHomeworkList = new List<Homework>();
            try
            {
                //Using stored Procedure
                cmd = new SqlCommand
                ("[haritha].[SPX_Student_150913_CourseAssignment]", cn);
                cmd.Parameters.AddWithValue("@courseID", cID);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cn.Open();
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Homework homework = new Homework();
                        homework.HomeworkID= (int)dr[0];
                        homework.Description = dr[1].ToString();
                        homework.DeadLine = (DateTime)dr[2];
                        homework.ReqTime = (int)dr[3];
                        homework.LongDescription = dr[4].ToString();
                       
                        myHomeworkList.Add(homework);
                    }
                }


            }
            catch (CourseException e)
            {
                throw e;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dr.Close();
                cn.Close();
            }
            return myHomeworkList;
        }

        #endregion

        //Checked
        #region ViewStudentCourseDetails(int courseID)
        public IEnumerable<Course> ViewMyCourseDetails(int cID)
        {
            List<Course> courselist = new List<Course>();
            try
            {
                //Using stored Procedure
                cmd = new SqlCommand
                ("[haritha].[SPX_Student_150913_CourseDetails]", cn);
                cmd.Parameters.AddWithValue("@courseID", cID);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cn.Open();
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Course course = new Course();
                        course.CourseID = (int)dr[0];
                        course.CourseName = dr[1].ToString();
                        course.StartDate = (DateTime)dr[2];
                        course.EndDate = (DateTime)dr[3];

                        courselist.Add(course);
                    }
                }


            }
            catch (CourseException e)
            {
                throw e;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dr.Close();
                cn.Close();
            }
            return courselist;
        }
        #endregion
    }
}
