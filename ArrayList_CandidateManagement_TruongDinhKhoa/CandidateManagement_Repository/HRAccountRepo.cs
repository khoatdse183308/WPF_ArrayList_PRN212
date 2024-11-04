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
    public class HRAccountRepo : IHRAccountRepo
    {
        private readonly HRAccountDAO _HRAccountDAO;
        public HRAccountRepo()
        {
            _HRAccountDAO = new HRAccountDAO();
        }
        public HRAccount GetHraccountByEmail(string email) => _HRAccountDAO.GetHraccountByEmail(email);

        public ArrayList LoadHRAccounts() => _HRAccountDAO.LoadHRAccounts();
    }
}
