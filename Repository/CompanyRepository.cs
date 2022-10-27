using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Repository
{
    //By inheriting from the RepositoryBase class, they will have access to all
    //the methods from it.Furthermore, every user class will have its interface
    //for additional model-specific methods
                                    //Hereda                  //Implementa
    public class CompanyRepository : RepositoryBase<Company>, ICompanyRepository
    {
        public CompanyRepository(RepositoryContext repositoryContext): base(repositoryContext) 
        { 
        
        }
        public IEnumerable<Company> GetAllCompanies(bool trackChanges) =>
            FindAll(trackChanges).OrderBy(c => c.Name).ToList();

        //public Company GetCompany(Guid companyId, bool trackChanges) =>
        //    FindByCondition(c => c.Id.Equals(companyId), trackChanges)
        //    .SingleOrDefault();
    }
}
