using CandidateManagement_BusinessObject;
using CandidateManagement_Services;
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

namespace ArrayList_CandidateManagement_TruongDinhKhoa
{
    /// <summary>
    /// Interaction logic for CandidateProfileWindow.xaml
    /// </summary>
    public partial class CandidateProfileWindow : Window
    {
        private int? RoleID = 0;
        private ICandidateProfileService _candidateProfileService;
        private IJobPostingService _jobpostingService;
        public CandidateProfileWindow()
        {
            InitializeComponent();
            _candidateProfileService = new CandidateProfileService();
            _jobpostingService = new JobPostingService();
        }

        public CandidateProfileWindow(int? roleID)
        {
            InitializeComponent();
            _candidateProfileService = new CandidateProfileService();
            _jobpostingService = new JobPostingService();
            this.RoleID = roleID;
            switch (roleID)
            {
                case 1:
                    {

                        break;
                    }
                case 2:
                    {
                        btnAdd.IsEnabled = false;
                        break;
                    }
                default:
                    {
                        this.Close();
                        break;
                    }
            }
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            loadDataInit();
        }

        public void loadDataInit()
        {
            this.dtgCandidateProfile.ItemsSource = _candidateProfileService.LoadCandidateProfile();
            this.cmbPostingID.ItemsSource = _jobpostingService.GetAllJobPostings();
            this.cmbPostingID.DisplayMemberPath = "JobPostingTitle";
            this.cmbPostingID.SelectedValuePath = "PostingId";

            txtCandidateID.Text = "";
            txtFullName.Text = "";
            txtProfileURL.Text = "";
            txtBirthday.Text = "";
            txtDescription.Text = "";
            cmbPostingID.SelectedValue = "";
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCandidateID.Text) || string.IsNullOrWhiteSpace(txtFullName.Text) ||
                string.IsNullOrWhiteSpace(txtBirthday.Text) || string.IsNullOrWhiteSpace(txtProfileURL.Text) ||
                cmbPostingID.SelectedValue == null || string.IsNullOrWhiteSpace(txtDescription.Text))
            {
                MessageBox.Show("All fields are required!");
                return;
            }
            CandidateProfile candidate = new CandidateProfile();
            candidate.CandidateId = txtCandidateID.Text;
            candidate.Fullname = txtFullName.Text;
            candidate.ProfileUrl = txtProfileURL.Text;
            candidate.Birthday = DateTime.Parse(txtBirthday.Text);
            candidate.ProfileShortDescription = txtDescription.Text;
            candidate.PostingId = cmbPostingID.SelectedValue.ToString();
            if (_candidateProfileService.AddCandidateProfile(candidate))
            {
                MessageBox.Show("Add successfull");
                loadDataInit();
            }
            else
            {
                MessageBox.Show("Add unsuccessfull !!!!");
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCandidateID.Text) || string.IsNullOrWhiteSpace(txtFullName.Text) ||
                string.IsNullOrWhiteSpace(txtBirthday.Text) || string.IsNullOrWhiteSpace(txtProfileURL.Text) ||
                cmbPostingID.SelectedValue == null || string.IsNullOrWhiteSpace(txtDescription.Text))
            {
                MessageBox.Show("All fields are required!");
                return;
            }
            CandidateProfile candidate = new CandidateProfile();
            candidate.CandidateId = txtCandidateID.Text;
            candidate.Fullname = txtFullName.Text;
            candidate.ProfileUrl = txtProfileURL.Text;
            candidate.Birthday = DateTime.Parse(txtBirthday.Text);
            candidate.ProfileShortDescription = txtDescription.Text;
            candidate.PostingId = cmbPostingID.SelectedValue.ToString();
            if (_candidateProfileService.UpdateCandidateProfile(candidate))
            {
                MessageBox.Show("Update successfull");
                loadDataInit();
            }
            else
            {
                MessageBox.Show("Update unsuccessfull !!!!");
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            string candidateID = txtCandidateID.Text;
            if (candidateID == "")
            {
                MessageBox.Show("Please select a row to delete !");
                return;
            }
            MessageBoxResult result = MessageBox.Show($"Are you sure you want to delete {candidateID} Profile?",
                                                      "Confirm Delete",
                                                      MessageBoxButton.YesNo,
                                                      MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                if (candidateID.Length > 0 && _candidateProfileService.DeleteCandidateProfile(candidateID))
                {
                    MessageBox.Show("Delete Successfull");
                    loadDataInit();
                }
                else
                {
                    MessageBox.Show("Delete unsuccessfull!!!");
                }
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void dtgCandidateProfile_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dataGrid = sender as DataGrid;

            DataGridRow row =
                (DataGridRow)dataGrid.ItemContainerGenerator.ContainerFromIndex(dataGrid.SelectedIndex);
            if (row != null)
            {
                DataGridCell RowColumn =
                dataGrid.Columns[0].GetCellContent(row).Parent as DataGridCell;
                string id = ((TextBlock)RowColumn.Content).Text;
                CandidateProfile candidateProfile = _candidateProfileService.GetCandidateProfileById(id);
                if (candidateProfile != null)
                {
                    txtCandidateID.Text = candidateProfile.CandidateId;
                    txtFullName.Text = candidateProfile.Fullname;
                    txtProfileURL.Text = candidateProfile.ProfileUrl;
                    txtBirthday.SelectedDate = candidateProfile.Birthday;
                    txtDescription.Text = candidateProfile.ProfileShortDescription;
                    cmbPostingID.SelectedValue = candidateProfile.PostingId;
                }
            }
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            string name = txtFullName.Text;
            var listCandidateProfile = _candidateProfileService.GetCandidateProfilesByFullName(name);
            this.dtgCandidateProfile.ItemsSource = listCandidateProfile;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            JobPostingWindow jobPostingWindow = new JobPostingWindow();
            jobPostingWindow.ShowDialog();
        }

        private void txtProfileURL_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
