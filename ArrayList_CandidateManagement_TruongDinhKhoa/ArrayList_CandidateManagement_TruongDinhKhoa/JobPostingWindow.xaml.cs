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
    /// Interaction logic for JobPostingWindow.xaml
    /// </summary>
    public partial class JobPostingWindow : Window
    {
        private readonly IJobPostingService _jobpostingService;
        public JobPostingWindow()
        {
            InitializeComponent();
            _jobpostingService = new JobPostingService();
        }

        public void loadInit()
        {
            this.DtgJobPosting.ItemsSource = _jobpostingService.GetAllJobPostings();

            txtPostingID.Text = "";
            txtJobPostingTitle.Text = "";
            txtDescription.Text = "";
            txtPostedDate.SelectedDate = null;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            loadInit();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPostingID.Text) || string.IsNullOrWhiteSpace(txtJobPostingTitle.Text) || string.IsNullOrWhiteSpace(txtDescription.Text) || string.IsNullOrWhiteSpace(txtPostedDate.Text))
            {
                MessageBox.Show("All fields are required!!");
                return;
            }
            JobPosting jobPosting = new JobPosting();
            jobPosting.PostingId = txtPostingID.Text;
            jobPosting.JobPostingTitle = txtJobPostingTitle.Text;
            jobPosting.Description = txtDescription.Text;
            jobPosting.PostedDate = DateTime.Parse(txtPostedDate.Text);
            if (_jobpostingService.AddJobPosting(jobPosting))
            {
                MessageBox.Show("Add success");
                loadInit();
            }
            else
            {
                MessageBox.Show("Add fail!!!!");
            }
        }

        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            JobPosting jobPosting = new JobPosting();
            jobPosting.PostingId = txtPostingID.Text;
            jobPosting.JobPostingTitle = txtJobPostingTitle.Text;
            jobPosting.Description = txtDescription.Text;
            jobPosting.PostedDate = DateTime.Parse(txtPostedDate.Text);
            if (_jobpostingService.UpdateJobPosting(jobPosting))
            {
                MessageBox.Show("Updtae success");
                loadInit();
            }
            else
            {
                MessageBox.Show("Update fail!!!!");
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string jobPostingID = txtPostingID.Text;
            if (jobPostingID.Length > 0 && _jobpostingService.DeleteJobPosting(jobPostingID))
            {
                MessageBox.Show($"Delete {jobPostingID} successfull ");
                loadInit();
            }
            else
            {
                MessageBox.Show($"Delete {jobPostingID} unsuccessfull!!!!!! ");
            }
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void DtgJobPosting_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dataGrid = sender as DataGrid;

            DataGridRow row =
                (DataGridRow)dataGrid.ItemContainerGenerator.ContainerFromIndex(dataGrid.SelectedIndex);
            if (row != null)
            {
                DataGridCell RowColumn =
                dataGrid.Columns[0].GetCellContent(row).Parent as DataGridCell;
                string id = ((TextBlock)RowColumn.Content).Text;
                JobPosting jobPosting = _jobpostingService.GetJobPostingById(id);
                if (jobPosting != null)
                {
                    txtPostingID.Text = jobPosting.PostingId;
                    txtJobPostingTitle.Text = jobPosting.JobPostingTitle;
                    txtDescription.Text = jobPosting.Description;
                    txtPostedDate.SelectedDate = jobPosting.PostedDate;
                }
            }
        }
    }
}
