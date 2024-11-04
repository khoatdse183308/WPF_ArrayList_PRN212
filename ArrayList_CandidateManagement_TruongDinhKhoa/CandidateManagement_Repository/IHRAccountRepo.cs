using CandidateManagement_BusinessObject;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateManagement_Repository
{
    public interface IHRAccountRepo
    {
        public ArrayList LoadHRAccounts();

        public HRAccount GetHraccountByEmail(string email);
    }
}
