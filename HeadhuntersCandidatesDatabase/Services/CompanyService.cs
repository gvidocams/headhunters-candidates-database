using HeadhuntersCandidatesDatabase.Models;
using System.Collections.Generic;
using System.Linq;
using HeadhuntersCandidatesDatabase.Exceptions;

namespace HeadhuntersCandidatesDatabase.Services
{
    public class CompanyService
    {
        private List<Company> _companies;
        private int _id = 1;

        public CompanyService(List<Company> companies)
        {

            _companies = companies;
        }

        public Company[] GetCompanies()
        {
            return _companies.ToArray();
        }

        public Company GetCompanyById(int id)
        {
            var company = _companies.FirstOrDefault(c => c.Id == id);

            return company;
        }

        public void AddCompany(Company company)
        {
            Validate.Company(company);

            Validate.DuplicateCompany(_companies, company);

            company.Id = _id++;
            _companies.Add(company);
        }

        public void UpdateCompany(int id, Company company)
        {
            Validate.Company(company);

            var c = _companies.FirstOrDefault(c => c.Id == id);

            if (c == null)
            {
                throw new InvalidIdException(id);
            }

            c.CompanyName = company.CompanyName;
            c.OpenedPositions = company.OpenedPositions;
        }

        public void RemoveCompany(int id)
        {
            var company = _companies.FirstOrDefault(c => c.Id == id);

            if (company != null)
            {
                _companies.Remove(company);
            }
        }

        public void ClearCompanies()
        {
            _companies.Clear();

            _id = 1;
        }
    }
}
