using CandidateManagement_BusinessObject;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CandidateManagement_DAO
{
    public class CandidateProfileDAO
    {
        public readonly string _dataPath;

        public CandidateProfileDAO()
        {
            _dataPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data");
        }

        public ArrayList LoadCandidateProfile()
        {
            ArrayList list = new ArrayList();
            string filePath = Path.Combine(_dataPath, "CandidateProfile.txt");
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"Can not find the file {filePath}");
            }
            using (StreamReader sr = new StreamReader(filePath))
            {
                sr.ReadLine();
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (string.IsNullOrWhiteSpace(line)) continue;
                    var fields = line.Split('\t');
                    var candidateProfile = new CandidateProfile
                    {
                        CandidateId = fields[0],
                        Fullname = fields[1],
                        Birthday = DateTime.Parse(fields[2]),
                        ProfileShortDescription = fields[3],
                        ProfileUrl = fields[4],
                        PostingId = fields[5],
                    };
                    list.Add(candidateProfile);
                }
            }
            return list;
        }

        private bool SaveCandidateToFile(ArrayList candidateList)
        {
            try
            {
                string filePath = Path.Combine(_dataPath, "CandidateProfile.txt");
                using (StreamWriter sr = new StreamWriter(filePath))
                {
                    {
                        sr.WriteLine("CandidateID\tFullname\tBirthday\tProfileShortDescription\tProfileURL\tPostingID");
                        foreach (CandidateProfile candidate in candidateList)
                        {
                            sr.WriteLine($"{candidate.CandidateId}\t{candidate.Fullname}\t{candidate.Birthday:yyyy-MM-dd HH:mm:ss.fff}\t{candidate.ProfileShortDescription ?? "NULL"}\t{candidate.ProfileUrl}\t{candidate.PostingId}");
                        }
                    }
                    return true;
                }
            }
            catch { return false; }
        }

        public CandidateProfile GetCandidateProfileById(string id)
        {
            try
            {
                var profileList = LoadCandidateProfile();
                foreach (CandidateProfile profile in profileList)
                {
                    if (profile.CandidateId.Equals(id))
                    {
                        return profile;
                    }
                }
                return null;
            }
            catch
            {
                return null;
            }
        }



        public ArrayList GetCandidateProfilesByFullName(string fullName)
        {
            try
            {
                var candidateProfiles = LoadCandidateProfile();
                ArrayList result = new ArrayList();
                if (string.IsNullOrWhiteSpace(fullName)) return candidateProfiles;
                foreach (CandidateProfile profile in candidateProfiles)
                {
                    if (profile.Fullname.Contains(fullName, StringComparison.OrdinalIgnoreCase))
                    {
                        result.Add(profile);
                    }
                }
                return result;
            }
            catch
            {
                return new ArrayList();
            }
        }

        public bool AddCandidateProfile(CandidateProfile candidateProfile)
        {
            try
            {
                var candidate = LoadCandidateProfile();
                candidate.Add(candidateProfile);
                return SaveCandidateToFile(candidate);
            }
            catch { return false; }
        }

        public bool UpdateCandidateProfile(CandidateProfile candidateProfile)
        {
            try
            {
                var candidate = LoadCandidateProfile();
                bool isSuccess = false;
                for (int i = 0; i < candidate.Count; i++)
                {
                    var existingProfile = candidate[i] as CandidateProfile;
                    if (existingProfile.CandidateId == candidateProfile.CandidateId)
                    {
                        candidate[i] = candidateProfile;
                        isSuccess = true;
                        break;
                    }
                }
                if (!isSuccess)
                {
                    return false;
                }
                return SaveCandidateToFile(candidate);
            }
            catch { return false; }
        }

        public bool DeleteCandidateProfile(string candidateProfileId)
        {
            try
            {
                var candidate = LoadCandidateProfile();
                bool isSuccess = false;
                for (int i = 0; i < candidate.Count; i++)
                {
                    var existingProfile = candidate[i] as CandidateProfile;
                    if (existingProfile.CandidateId == candidateProfileId)
                    {
                        candidate.RemoveAt(i);
                        isSuccess = true;
                        break;
                    }
                }
                if (!isSuccess)
                {
                    return false;
                }
                return SaveCandidateToFile(candidate);
            }
            catch { return false; }
        }

    }
}
