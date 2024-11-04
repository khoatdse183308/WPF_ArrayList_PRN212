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
    public class CandidateProfileService : ICandidateProfileService
    {

        private readonly CandidateProfileRepo _candidateProfileRepo;
        public CandidateProfileService()
        {
            _candidateProfileRepo = new CandidateProfileRepo();
        }
        public bool AddCandidateProfile(CandidateProfile candidateProfile) => _candidateProfileRepo.AddCandidateProfile(candidateProfile);

        public bool DeleteCandidateProfile(string candidateProfileId) => _candidateProfileRepo.DeleteCandidateProfile(candidateProfileId);

        public CandidateProfile GetCandidateProfileById(string id) => _candidateProfileRepo.GetCandidateProfileById(id);

        public ArrayList GetCandidateProfilesByFullName(string fullName) => _candidateProfileRepo.GetCandidateProfilesByFullName(fullName);

        public ArrayList LoadCandidateProfile() => _candidateProfileRepo.LoadCandidateProfile();

        public bool UpdateCandidateProfile(CandidateProfile candidateProfile) => _candidateProfileRepo.UpdateCandidateProfile(candidateProfile);
    }
}
