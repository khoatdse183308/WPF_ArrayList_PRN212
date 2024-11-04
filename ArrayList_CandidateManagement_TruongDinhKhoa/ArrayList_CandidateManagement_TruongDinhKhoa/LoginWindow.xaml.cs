using CandidateManagement_BusinessObject;
using CandidateManagement_Services;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ArrayList_CandidateManagement_TruongDinhKhoa
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private IHRAccountService _ihraccountService;
        public LoginWindow()
        {
            InitializeComponent();
            _ihraccountService = new HRAccountService();
        }

        private void btnLogin_Click_1(object sender, RoutedEventArgs e)
        {
            HRAccount hraccount = _ihraccountService.GetHraccountByEmail(txtEmail.Text);
            if (hraccount != null && txtPassword.Password.Equals(hraccount.Password))
            {
                int? roleID = hraccount.MemberRole;
                CandidateProfileWindow candidateScren = new CandidateProfileWindow(roleID);
                candidateScren.ShowDialog();


            }
            else
            {
                MessageBox.Show("Not valid account!!");
            }
        }

        private void btnCancel_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}