using CandidateManagement_BusinessObject;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateManagement_Repository
{
    public interface ICandidateProfileRepo
    {
        public ArrayList LoadCandidateProfile();

        public CandidateProfile GetCandidateProfileById(string id);

        public ArrayList GetCandidateProfilesByFullName(string fullName);

        public bool AddCandidateProfile(CandidateProfile candidateProfile);

        public bool UpdateCandidateProfile(CandidateProfile candidateProfile);

        public bool DeleteCandidateProfile(string candidateProfileId);
       
    }
}
