using Entites;
using ExceptionLibrary;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class TeacherDAL
    {
        //Connection, Command, DataReader
        SqlConnection cn = null;
        SqlCommand cmd = null;
        SqlDataReader dr = null;

        public TeacherDAL(string conString)
        {
            cn = new SqlConnection(conString);
        }

        //checked --* should have in SignUp
        #region AddTeacher(Teacher teacher)
        public int AddTeacher(Teacher teacher)
        {
            int no = 0;
            try
            {
                //1.Way of inserting the values;

                // cmd = new SqlCommand
                //("insert into haritha.M3_150913_Product(ProdName,Price,ExpDate) values('" + pd.ProdName + "','" + pd.Price + "','" + pd.ExpDate + "')", cn);

                //Inserting using Stored Procedures;

                cmd = new SqlCommand("[haritha].[SPX_Insert_150913_Teacher]", cn);
                cmd.Parameters.AddWithValue("@FName", teacher.FName);
                cmd.Parameters.AddWithValue("@LName", teacher.LName);
                cmd.Parameters.AddWithValue("@DOB", teacher.DOB);
                cmd.Parameters.AddWithValue("@City", teacher.City);
                cmd.Parameters.AddWithValue("@Password", teacher.Pasword);
                cmd.Parameters.AddWithValue("@MobileNo", teacher.MobileNo);
                cmd.Parameters.AddWithValue("@IsAdmin", "No");

                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cn.Open();
                no = cmd.ExecuteNonQuery();

            }
            catch (TeacherException e)
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
        #region ViewMyProfile(int studentID)

        public Teacher ViewTeacherMyProfile(int teacherID)
        {
            Teacher teacher = new Teacher();

            try
            {
                //Using stored Procedure
                cmd = new SqlCommand
                ("[haritha].[SPX_Teacher_150913_MyProfile]", cn);
                cmd.Parameters.AddWithValue("@teachID", teacherID);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cn.Open();
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {

                        teacher.TeacherID = (int)dr[0];
                        teacher.FName = dr[1].ToString();
                        teacher.LName = dr[2].ToString();
                        teacher.DOB = (DateTime)dr[3];
                        teacher.City = dr[4].ToString(); ;
                        teacher.MobileNo = dr[6].ToString();
                    }
                }


            }
            catch (TeacherException e)
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
            return teacher;
        }

        #endregion

        //Checked 
        #region TeachACourse(int CourseID,int teacherID)

        public int TeachACourse(int courseID, int teacherID)
        {

            int no = 0;
            try
            {

                //Inserting using Stored Procedures;

                cmd = new SqlCommand("[haritha].[SPX_Teaches_150913_Course]", cn);
                cmd.Parameters.AddWithValue("@CID", courseID);
                cmd.Parameters.AddWithValue("@TID", teacherID);

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

        //1.To be Verified  -(have to pass teacherID also while retirving the student data)
        //2.Modified the Procedure - Have to change the Code
        #region ViewStudentDetails(int courseID)

        public IEnumerable<Student> ViewStudentDetails(int courseID)
        {
            List<Student> courseStudentList = new List<Student>();
            try
            {
                //Using stored Procedure
                cmd = new SqlCommand
                ("[haritha].[SPX_View_150913_MyCourseStudents]", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CourseID", courseID);
                cn.Open();
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Student student = new Student();
                        student.StudentID = (int)dr[0];
                        student.FName = dr[1].ToString();
                        student.LName = dr[2].ToString();
                        student.City = dr[3].ToString();
                        student.MobileNo = dr[4].ToString();

                        courseStudentList.Add(student);
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
            return courseStudentList;
        }

        #endregion

        //Checked 
        #region ViewMyTeachingCourses(int teacherID)
        public IEnumerable<Course> ViewMyTeachingCourses(int teachID)
        {
            List<Course> myCourseList = new List<Course>();
            try
            {
                //Using stored Procedure
                cmd = new SqlCommand
                ("[haritha].[SPX_Teacher_150913_MyCourses]", cn);
                cmd.Parameters.AddWithValue("@teacherID", teachID);
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

        //Checked -- *
        #region ViewMyCourseAssignments(int courseID)

        public IEnumerable<Homework> ViewMyCourseAssignments(int cID)
        {
            List<Homework> myAssignmentList = new List<Homework>();
            try
            {
                //Using stored Procedure
                cmd = new SqlCommand
                ("[haritha].[SPX_Teacher_150913_CourseAssignment]", cn);
                cmd.Parameters.AddWithValue("@courseID", cID);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cn.Open();
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Homework homework = new Homework();
                        homework.HomeworkID = (int)dr[0];
                        homework.Description = dr[1].ToString();
                        homework.DeadLine = (DateTime)dr[2];
                        homework.ReqTime = (int)dr[3];
                        homework.LongDescription = dr[4].ToString();
                        myAssignmentList.Add(homework);
                    }
                }


            }
            catch (HomeworkException e)
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
            return myAssignmentList;
        }
        #endregion

        //Checked 
        #region CheckEnrollment

        public int CheckEnrollment(int CourseID, int teacherID)
        {

            int no = 0;
            try
            {

                //Inserting using Stored Procedures;

                cmd = new SqlCommand("[haritha].[SPX_TeacherCheck_150913_Course]", cn);
                cmd.Parameters.AddWithValue("@cID", CourseID);
                cmd.Parameters.AddWithValue("@tID", teacherID);

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
        #region EnrollACourse(int CourseID,int teacherID)

        public int EnrollACourse(int CourseID, int teacheID)
        {

            int no = 0;
            try
            {

                //Inserting using Stored Procedures;
                cmd = new SqlCommand("[haritha].[SPX_Teaches_150913_Course]", cn);
                cmd.Parameters.AddWithValue("@CID", CourseID);
                cmd.Parameters.AddWithValue("@TID", teacheID);

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
        #region UpdateTeacherDetails(Teacher teacher)
        public int UpdateTeacherDetails(Teacher teacher)
        {
            int no;

            try
            {

                //Using Stored Procedure;

                cmd = new SqlCommand("[haritha].[SPX_Update_150913_Teacher]", cn);
                cmd.Parameters.AddWithValue("@Tid", teacher.TeacherID);
                cmd.Parameters.AddWithValue("@TFName", teacher.FName);
                cmd.Parameters.AddWithValue("@TLNAme", teacher.LName);
                cmd.Parameters.AddWithValue("@TDOB", teacher.DOB);
                cmd.Parameters.AddWithValue("@TCity", teacher.City);
                cmd.Parameters.AddWithValue("@TMobileNo", teacher.MobileNo);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cn.Open();
                no = cmd.ExecuteNonQuery();
            }
            catch (TeacherException e)
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
        #region CreateNewHomework(Homework homework,int teacherID,int courseID)

        public int CreateNewHomework(Homework homework, int teachID, int cID)
        {
            int no = 0;
            int homeID;
            try
            {

                //Inserting using Stored Procedures;

                cmd = new SqlCommand("[haritha].[SPX_Create_150913_Homework]", cn);
                cmd.Parameters.AddWithValue("@HDescrip", homework.Description);
                cmd.Parameters.AddWithValue("@HDeadLine", homework.DeadLine);
                cmd.Parameters.AddWithValue("@HTimeRequired", homework.ReqTime);
                cmd.Parameters.AddWithValue("@HLongDescrip", homework.LongDescription);

                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cn.Open();
                no = cmd.ExecuteNonQuery();
                if (no == 1)
                {
                    cmd = new SqlCommand
                    ("[haritha].[SPX_Get_M3_150913_homeworkID]", cn);
                   
                    homeID = (int)cmd.ExecuteScalar();

                    cmd = new SqlCommand("[haritha].[SPX_Updating_150913_Assignment]", cn);
                    cmd.Parameters.AddWithValue("@HhomeworkID",homeID);
                    cmd.Parameters.AddWithValue("@HteacherID", teachID);
                    cmd.Parameters.AddWithValue("@HcourseID", cID);

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    no = cmd.ExecuteNonQuery();
                }

            }
            catch (HomeworkException e)
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


        


    }
}
