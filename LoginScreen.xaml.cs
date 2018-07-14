using BLL;
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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class LoginScreen : Window
    {
        
        PrometheusBLL bll = null;
        public LoginScreen()
        {
            InitializeComponent();
            bll = new PrometheusBLL(@"Data Source=ndamssql\sqlilearn;Initial Catalog=16MayCHN;User ID=sqluser;Password=sqluser");
        }
        #region OnSignIn()

        private void btnSignIn_Click(object sender, RoutedEventArgs e)
        {
            int result;
            try
            {
                //MessageBox.Show((int.Parse)(txtUserName.Text)+" "+ txtPassword.Text);

                result = bll.onLogin((int.Parse)(txtUserName.Text), txtPassword.Password);

                //MessageBox.Show(result.ToString());
                if (result == 1)
                {
                    //MessageBox.Show("Admin");
                    //pass it to the Admin window;

                    LoginScreen logScreen = new LoginScreen();
                    AdminHome admin = new AdminHome();
                    admin.ID= (int.Parse)(txtUserName.Text);
                    txtUserName.Text = string.Empty;
                    txtPassword.Password = string.Empty;
                    logScreen.Close();
                    admin.Show();
                }
                else if (result == 2)
                {
                    
                    TeacherHome teacherHome = new TeacherHome();
                    LoginScreen logScreen = new LoginScreen();
                    teacherHome.ID= (int.Parse)(txtUserName.Text);
                    txtUserName.Text = string.Empty;
                    txtPassword.Password = string.Empty;
                    logScreen.Close();
                    teacherHome.Show();
                    //pass it on to the Teacher Window;
                }
                else if (result == 3)
                {
                    //pass it on to the Student window;
                    LoginScreen logScreen = new LoginScreen();
                    MainWindow studentwpf = new MainWindow();
                    studentwpf.ID = (int.Parse)(txtUserName.Text);
                    txtUserName.Text = string.Empty;
                    txtPassword.Password = string.Empty;
                    logScreen.Close();
                    studentwpf.Show();
                }
                else
                    throw new LoginException("User Not Found");
            }
            catch (LoginException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
        #endregion
    }
}
