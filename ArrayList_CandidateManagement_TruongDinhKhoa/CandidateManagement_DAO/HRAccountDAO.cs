using CandidateManagement_BusinessObject;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateManagement_DAO
{
    public class HRAccountDAO
    {
        private readonly string _dataPath;

        public HRAccountDAO()
        {
            _dataPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data");
        }

        public ArrayList LoadHRAccounts()
        {
            ArrayList hrAccounts = new ArrayList();
            string filePath = Path.Combine(_dataPath, "HRAccount.txt");

            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"Cannot find file: {filePath}");
            }

            using (StreamReader sr = new StreamReader(filePath))
            {
                // Skip header line
                sr.ReadLine();

                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (string.IsNullOrWhiteSpace(line)) continue;

                    var fields = line.Split('\t');

                    var account = new HRAccount
                    {
                        Email = fields[0],
                        Password = fields[1],
                        FullName = fields[2],
                        MemberRole = int.Parse(fields[3])
                    };

                    hrAccounts.Add(account);
                }
            }
            return hrAccounts;
        }

        private bool SaveHRAccounts(ArrayList accounts)
        {
            try
            {
                string filePath = Path.Combine(_dataPath, "HRAccount.txt");
                using (StreamWriter sw = new StreamWriter(filePath))
                {
                    sw.WriteLine("Email\tPassword\tFullName\tMemberRole");
                    foreach (HRAccount account in accounts)
                    {
                        sw.WriteLine($"{account.Email}\t{account.Password}\t{account.FullName}\t{account.MemberRole}");
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public HRAccount GetHraccountByEmail(string email)
        {
            try
            {
                var accounts = LoadHRAccounts();
                foreach (HRAccount account in accounts)
                {
                    if (account.Email.Equals(email))
                    {
                        return account;
                    }
                }
                return null;
            }
            catch
            {
                return null;
            }
        }
    }
}
