using CandidateManagement_BusinessObject;
using CandidateManagement_Repository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateManagement_Services
{
    public class JobPostingService : IJobPostingService
    {
        private readonly JobPostingRepo _repo;
        public JobPostingService()
        {
            _repo = new JobPostingRepo();
        }
        public bool AddJobPosting(JobPosting posting) => _repo.AddJobPosting(posting);

        public bool DeleteJobPosting(string postingId) => _repo.DeleteJobPosting(postingId);

        public ArrayList GetAllJobPostings() => _repo.GetAllJobPostings();

        public JobPosting GetJobPostingById(string id) => _repo.GetJobPostingById(id);

        public bool UpdateJobPosting(JobPosting posting) => _repo.UpdateJobPosting(posting);
    }
}
