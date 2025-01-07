using Contracts;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    internal class CompanyRespository : RepositoryBase<Company> , ICompanyRepository
    {
        public CompanyRespository(RepositoryContext repositoryContext)
            :base(repositoryContext) 
        {

        }

        public IEnumerable<Company> GetAllCompanies(bool trackChanges) =>
        
            FindAll(trackChanges).OrderBy(c => c.Name).ToList();
        
    }
}
