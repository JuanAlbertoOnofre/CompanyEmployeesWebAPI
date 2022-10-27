using Contracts;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryManager/*: IRepositoryManager*/
    {
        private RepositoryContext _repositoryContext;
        private ICompanyRepository _companyRepository;
        private IEmployeeRepository _employeeRepository;

        #region Builder
        public RepositoryManager(RepositoryContext repositiryContext)
        {
            _repositoryContext = repositiryContext;
        }
        #endregion

        public ICompanyRepository Company
        {
            get 
            {
                if (_companyRepository == null)
                    _companyRepository = new CompanyRepository(_repositoryContext);
                return _companyRepository;
            }
        }

        public IEmployeeRepository Employee
        {
            get 
            {
                if (_employeeRepository == null)
                    _employeeRepository = new EmployeeRespository(_repositoryContext);
                return _employeeRepository;
            }
        }

        public void Save() => _repositoryContext.SaveChanges();

    }
}
