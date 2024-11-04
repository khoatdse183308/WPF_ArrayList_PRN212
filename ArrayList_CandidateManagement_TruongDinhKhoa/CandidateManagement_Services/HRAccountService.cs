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
    public class HRAccountService : IHRAccountService
    {
        private readonly HRAccountRepo _repository;
        public HRAccountService()
        {
            _repository = new HRAccountRepo();
        }
        public HRAccount GetHraccountByEmail(string email) => _repository.GetHraccountByEmail(email);

        public ArrayList LoadHRAccounts() => _repository.LoadHRAccounts();
    }
}
