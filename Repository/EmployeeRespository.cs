using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class EmployeeRespository  : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRespository(RepositoryContext repositoryContext) : base(repositoryContext) 
        { 
        
        }
    }
}
