using BLL;
using Entites;
using ExceptionLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Login
{
    /// <summary>
    /// Interaction logic for TeacherHome.xaml
    /// </summary>
    public partial class TeacherHome : Window
    {

        public int ID=1203;
        TeacherBLL bll = null;
        public TeacherHome()
        {
            InitializeComponent();
            bll = new TeacherBLL(@"Data Source=ndamssql\sqlilearn;Initial Catalog=16MayCHN;User ID=sqluser;Password=sqluser");
            txtSID.Text = ID.ToString();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                Teacher teacher = bll.GetTeacherMyProfile(1203);
                txtUserName.Text = teacher.FName.ToString() + " " + teacher.LName.ToString();
            }
            catch (TeacherException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void lstMyCourses_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Course SelectedCourse = (Course)CmbMyCourses.SelectedItem;
        }

        //Checked
        #region ViewMyCourses()
        private void btnMyCourses_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //1.Hide all other Views
                GridAvaliableCourses.Visibility = Visibility.Hidden;
                gdMyProfile.Visibility = Visibility.Hidden;
                gdEditMyProfile.Visibility = Visibility.Hidden;
                gdCreateHomework.Visibility = Visibility.Hidden;
                //2.Make MyCourses View Visible
                GridMyCourses.Visibility = Visibility.Visible;

                this.DataContext = bll.ViewMyCourses(ID);
                //IEnumerable<Course> courselist= bll.ViewMyCourses(ID);

                //this.DataContext = courselist;
            }
            catch (CourseException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        //Checked
        #region ViewAvailableCourses()
        private void btnAvailableCourses_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Hiding other views
                gdEditMyProfile.Visibility = Visibility.Hidden;
                gdMyProfile.Visibility = Visibility.Hidden;
                GridMyCourses.Visibility = Visibility.Hidden;
                gdCreateHomework.Visibility = Visibility.Hidden;


                dgAvaliableCourses.ItemsSource = bll.GetAvailableCourses();
                
                //Making the Available COurses Datagrid visible
                GridAvaliableCourses.Visibility = Visibility.Visible;
            }
            catch (CourseException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        //Checked
        #region  ViewMyProfile()
        private void btnMyProfile_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //1.Hide other Views;
                gdEditMyProfile.Visibility = Visibility.Hidden;
                GridAvaliableCourses.Visibility = Visibility.Hidden;
                GridMyCourses.Visibility = Visibility.Hidden;
                gdCreateHomework.Visibility = Visibility.Hidden;

                Teacher teacher = new Teacher();

                //2.Call to the Procedure in DAL through BLL GetteacherMyProfile(ID);

                teacher = bll.GetTeacherMyProfile(ID);


                txtID.Text = teacher.TeacherID.ToString();

                //MessageBox.Show(teacher.TeacherID.ToString());

                txtName.Text = teacher.FName.ToString() + " " + teacher.LName.ToString();

                //MessageBox.Show(teacher.FName.ToString() + " " + teacher.LName.ToString());

                txtDOB.Text = teacher.DOB.ToString();

                //MessageBox.Show(teacher.DOB.ToString());

                txtCity.Text = teacher.City.ToString();

                //MessageBox.Show(teacher.City.ToString());

                txtMobile.Text = teacher.MobileNo.ToString();

                //MessageBox.Show(teacher.MobileNo.ToString());

                //3.Making the teacher Profile Visible;

                gdMyProfile.Visibility = Visibility.Visible;

            }
            catch (StudentException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        #endregion

        //Checked
        #region ShowEditMyProfile()
        private void btnEditProfile_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //1.Hiding the Other GridViews
                GridAvaliableCourses.Visibility = Visibility.Hidden;
                gdMyProfile.Visibility = Visibility.Hidden;
                GridMyCourses.Visibility = Visibility.Hidden;
                gdCreateHomework.Visibility = Visibility.Hidden;

                //2.EditProfile View Visible 
                gdEditMyProfile.Visibility = Visibility.Visible;

            }
            catch (TeacherException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        //Checked
        #region UpdateMyProfile()
        private void btnUpdateMyProfile_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                Teacher teacher = new Teacher();

                teacher.TeacherID = int.Parse(txtSID.Text);
                teacher.FName = txtSFName.Text;
                teacher.LName = txtSLName.Text;
                teacher.City = txtSCity.Text;
                teacher.DOB = DateTime.Parse(txtSDOB.Text);
                teacher.MobileNo = txtSMobile.Text;
                int result = bll.UpdateTeacherDetails(teacher);
                if (result == 1)
                {
                    txtSFName.Text = string.Empty;
                    txtSLName.Text = string.Empty;
                    txtSCity.Text = string.Empty;
                    txtSDOB.Text = string.Empty;
                    txtSMobile.Text = string.Empty;
                    MessageBox.Show("Changes Saved Successfully");

                    GridAvaliableCourses.Visibility = Visibility.Hidden;
                    gdMyProfile.Visibility = Visibility.Hidden;
                    GridMyCourses.Visibility = Visibility.Hidden;
                    gdCreateHomework.Visibility = Visibility.Hidden;

                    gdEditMyProfile.Visibility = Visibility.Hidden;

                    teacher = new Teacher();

                    //2.Call to the Procedure in DAL through BLL GetteacherMyProfile(ID);

                    teacher = bll.GetTeacherMyProfile(ID);


                    txtID.Text = teacher.TeacherID.ToString();

                    //MessageBox.Show(teacher.TeacherID.ToString());

                    txtName.Text = teacher.FName.ToString() + " " + teacher.LName.ToString();

                    //MessageBox.Show(teacher.FName.ToString() + " " + teacher.LName.ToString());

                    txtDOB.Text = teacher.DOB.ToString();

                    //MessageBox.Show(teacher.DOB.ToString());

                    txtCity.Text = teacher.City.ToString();

                    //MessageBox.Show(teacher.City.ToString());

                    txtMobile.Text = teacher.MobileNo.ToString();

                    txtUserName.Text = teacher.FName.ToString() + " " + teacher.LName.ToString();

                    //MessageBox.Show(teacher.MobileNo.ToString());

                    //3.Making the teacher Profile Visible;

                    gdMyProfile.Visibility = Visibility.Visible;
                }

            }
            catch (StudentException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        //Checked
        #region TaketheCourse()
        private void btnTaketheCourse_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                Course course = new Course();
                course = (Course)dgAvaliableCourses.SelectedValue;
                //MessageBox.Show(course.CourseName.ToString());

                //passing the CourseID and StudentID to the StudentBLL to insert a row in the Enrollment table

                int result = bll.EnrollACourse(course.CourseID, ID);

                //MessageBox.Show(result.ToString());
                if (result == 1)
                {
                    MessageBox.Show("You have enrolled for " + course.CourseName.ToString() + " successfully");
                }
                else
                {
                    MessageBox.Show("You have already enrolled for " + course.CourseName.ToString() + ".");
                }

            }
            catch (CourseException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        //Checked
        #region CreateHomework
        private void btnCreateHomework_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //1.Hide other Views;
                gdEditMyProfile.Visibility = Visibility.Hidden;
                GridAvaliableCourses.Visibility = Visibility.Hidden;
                GridMyCourses.Visibility = Visibility.Hidden;
                gdMyProfile.Visibility = Visibility.Hidden;

                //2.Displaying the CreateHomework Grid;
                gdCreateHomework.Visibility = Visibility.Visible;



            }
            catch(HomeworkException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region ViewHomework
        private void btnViewHomework_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Course selectedCourse = (Course)CmbMyCourses.SelectedItem;

                int courseID = selectedCourse.CourseID;

                dgResult.ItemsSource = bll.ViewMyAssignments(courseID);
            }
            catch (HomeworkException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (CourseException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        //have to check the procedure
        #region StudentDetails
        private void btnStudentDetails_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Course selectedCourse = (Course)CmbMyCourses.SelectedItem;

                int courseID = selectedCourse.CourseID;
                //Display Course Student List in dgResult Grid;
                dgResult.ItemsSource = bll.ViewStudentDetails(courseID);

            }
            catch (StudentException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region CreateNewHomework()
        private void btnInsertNewHomework_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //1.Have to Insert a New Homework Record;
                //2.Need to update the Assignment TABLE -
                //---(HomeworkID, ID as TeacherID, CourseID -{pass the selected courseID})

                Course selectedCourse = (Course)CmbMyCourses.SelectedItem;

                int courseID = selectedCourse.CourseID;

                Homework homework = new Homework();

                homework.Description = txtDescription.Text;

                homework.DeadLine = DateTime.Parse(dpDeadLine.Text);

                homework.ReqTime = int.Parse(txtReqTime.Text);

                homework.LongDescription = txtLongDescrip.Text;

                int result=bll.CreateNewHomework(homework,ID, courseID);

                if(result==1)
                {
                    MessageBox.Show("Assignment Created..");
                }


                //1.Hide other Views;
                gdEditMyProfile.Visibility = Visibility.Hidden;
                GridAvaliableCourses.Visibility = Visibility.Hidden;
                gdMyProfile.Visibility = Visibility.Hidden;
                gdCreateHomework.Visibility = Visibility.Hidden;

                //2.Displaying the CreateHomework Grid;
                GridMyCourses.Visibility = Visibility.Hidden;

            }
            catch(HomeworkException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        private void Label_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
