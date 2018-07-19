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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
namespace Login
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        StudentBLL bll = null;

        public int ID=1500;
        public MainWindow()
        {
            InitializeComponent();
            bll = new StudentBLL(@"Data Source=ndamssql\sqlilearn;Initial Catalog=16MayCHN;User ID=sqluser;Password=sqluser");
            txtSID.Text = ID.ToString();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

           try
            {
                Student student = bll.GetStudentMyProfile(ID);
                txtUserName.Text = student.FName.ToString() + " " + student.LName.ToString();
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

                dgAvaliableCourses.ItemsSource = bll.GetAvailableCourses();

                //Making the Available COurses Datagrid visible
                GridAvaliableCourses.Visibility=Visibility.Visible;
            }
            catch(CourseException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        //Checked
        #region ViewMyProfile()
        private void btnMyProfile_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //1.Hide other Views;
                gdEditMyProfile.Visibility = Visibility.Hidden;
                GridAvaliableCourses.Visibility = Visibility.Hidden;
                GridMyCourses.Visibility = Visibility.Hidden;

                
                Student student = new Student();

                //2.Call to the Procedure in DAL through BLL GetStudentMyProfile(ID);

                student = bll.GetStudentMyProfile(ID);

                
                txtID.Text = student.StudentID.ToString();

                //MessageBox.Show(student.StudentID.ToString());

                txtName.Text = student.FName.ToString() + " " + student.LName.ToString();

                //MessageBox.Show(student.FName.ToString() + " " + student.LName.ToString());

                txtDOB.Text = student.DOB.ToString();

                //MessageBox.Show(student.DOB.ToString());

                txtCity.Text = student.City.ToString();

                //MessageBox.Show(student.City.ToString());

                txtMobile.Text = student.MobileNo.ToString();

                //MessageBox.Show(student.MobileNo.ToString());

                //3.Making the Student Profile Visible;

                gdMyProfile.Visibility = Visibility.Visible;

            }
            catch(StudentException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        //Checked
        #region EditMyProfile()
        private void btnEditProfile_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //1.Hiding the Other GridViews
                GridAvaliableCourses.Visibility = Visibility.Hidden;
                gdMyProfile.Visibility = Visibility.Hidden;
                GridMyCourses.Visibility = Visibility.Hidden;

                //2.EditProfile View Visible 
                gdEditMyProfile.Visibility = Visibility.Visible;

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
        #region EnrolltheCourse()

        private void btnTaketheCourse_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                
                Course course = new Course();
                course =(Course) dgAvaliableCourses.SelectedValue;
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
        #region UpdateMyProfile_Click()
        private void btnUpdateMyProfile_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                
                Student student = new Student();

                student.StudentID = int.Parse(txtSID.Text);
                student.FName = txtSFName.Text;
                student.LName = txtSLName.Text;
                student.City = txtSCity.Text;
                student.DOB = DateTime.Parse(txtSDOB.Text);
                student.MobileNo = txtSMobile.Text;
                int result=bll.UpdateStudentDetails(student);
                if(result==1)
                {
                    txtSFName.Text = string.Empty;
                    txtSLName.Text = string.Empty;
                    txtSCity.Text = string.Empty;
                    txtSDOB.Text = string.Empty;
                    txtSMobile.Text= string.Empty;
                    MessageBox.Show("Changes Saved Successfully");

                    gdEditMyProfile.Visibility = Visibility.Hidden;

                    student = bll.GetStudentMyProfile(ID);
                    
                    txtID.Text = student.StudentID.ToString();
                    
                    txtName.Text = student.FName.ToString() + " " + student.LName.ToString();
                    
                    txtDOB.Text = student.DOB.ToString();
                    
                    txtCity.Text = student.City.ToString();

                    txtMobile.Text = student.MobileNo.ToString();

                    txtUserName.Text = student.FName.ToString() + " " + student.LName.ToString();

                    gdMyProfile.Visibility = Visibility.Visible;
                }

            }
            catch(StudentException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

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

                //2.Make MyCourses View Visible
                GridMyCourses.Visibility = Visibility.Visible;
                
                this.DataContext = bll.ViewMyCourses(ID);
                //IEnumerable<Course> courselist= bll.ViewMyCourses(ID);

                //this.DataContext = courselist;
            }
            catch(CourseException ex)
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
        #region ViewMyAssignments()
        private void btnViewMyAssignments_Click(object sender, RoutedEventArgs e)
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
            catch(CourseException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        //Checked
        #region ViewSelectedCourseDetails()
        private void btnViewCourseDetails_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Course SelectedCourse = (Course)CmbMyCourses.SelectedItem;
                dgResult.ItemsSource =bll.ViewMyCourseDetails(SelectedCourse.CourseID);
            }
            catch(CourseException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion


        private void lstMyCourses_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Course SelectedCourse = (Course)CmbMyCourses.SelectedItem;
        }

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
