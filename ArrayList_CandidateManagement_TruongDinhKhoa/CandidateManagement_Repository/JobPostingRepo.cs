using CandidateManagement_BusinessObject;
using CandidateManagement_DAO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateManagement_Repository
{
    public class JobPostingRepo : IJobPostingRepo
    {
        private readonly JobPostingDAO _jobPostingDAO;
        public JobPostingRepo()
        {
            _jobPostingDAO = new JobPostingDAO();
        }
        public bool AddJobPosting(JobPosting posting) => _jobPostingDAO.AddJobPosting(posting);

        public bool DeleteJobPosting(string postingId) => _jobPostingDAO.DeleteJobPosting(postingId);

        public ArrayList GetAllJobPostings() => _jobPostingDAO.LoadJobPostings();

        public JobPosting GetJobPostingById(string id) => _jobPostingDAO.GetJobPostingById(id);

        public bool UpdateJobPosting(JobPosting posting) => _jobPostingDAO.UpdateJobPosting(posting);
    }
}
