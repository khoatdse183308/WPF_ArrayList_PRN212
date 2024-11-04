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
    public class CandidateProfileRepo : ICandidateProfileRepo
    {
        private readonly CandidateProfileDAO _candidateProfileDAO;

        public CandidateProfileRepo()
        {
            _candidateProfileDAO = new CandidateProfileDAO();
        }
        public bool AddCandidateProfile(CandidateProfile candidateProfile) => _candidateProfileDAO.AddCandidateProfile(candidateProfile);

        public bool DeleteCandidateProfile(string candidateProfileId) => _candidateProfileDAO.DeleteCandidateProfile(candidateProfileId);

        public CandidateProfile GetCandidateProfileById(string id) => _candidateProfileDAO.GetCandidateProfileById(id);

        public ArrayList GetCandidateProfilesByFullName(string fullName) => _candidateProfileDAO.GetCandidateProfilesByFullName(fullName);

        public ArrayList LoadCandidateProfile() => _candidateProfileDAO.LoadCandidateProfile();

        public bool UpdateCandidateProfile(CandidateProfile candidateProfile) => _candidateProfileDAO.UpdateCandidateProfile(candidateProfile);
    }
}
