using OBAWebAPI.Framework.Repository.Infrastructure;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OBAWebAPI.Framework.Domain.Models;
using OBAWebAPI.Framework.Repository.CQRS.Queries;
using Microsoft.EntityFrameworkCore;

namespace OBAWebAPI.Framework.Repository.Repositories
{
    public interface IExampleRepository
    {
        Task<List<decimal>> GetGraduateAsync();

        Task<IEnumerable<ExampleModel>> GetData();
    }

    public class ExampleRepository : IExampleRepository
    {
        private readonly IExampleQuery _exampleQuery;
        private readonly AppDbContext _appDbContext;

        public ExampleRepository(IExampleQuery exampleQuery, AppDbContext appDbContext)
        {
            _exampleQuery = exampleQuery;
            _appDbContext = appDbContext;
        }

        public Task<List<decimal>> GetGraduateAsync()
        {
            var res = _exampleQuery.GetGraduateAsync();
            return res;
        }

        public async Task<IEnumerable<ExampleModel>> GetData()
        {
            try
            {
                var data = await _appDbContext.ExampleTable.ToListAsync();
                return data;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
