using Contracts;
using Entities.Models;
using Service.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    internal sealed class CompanyService : ICompanyService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _Logger;
        public CompanyService(IRepositoryManager repository,ILoggerManager logger)
        {
            _Logger = logger;
            _repository = repository;
        }

        public IEnumerable<Company> GetAllCompanies(bool trackChanges)
        {
            try
            {
                var companies = _repository.Company.GetAllCompanies(trackChanges);
                return companies;
            }
            catch (Exception ex)
            {
                _Logger.LogError($"Some thing went wrong in {nameof(GetAllCompanies)} service method");
                throw;
            }
        }
        
    }
}
