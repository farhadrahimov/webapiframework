using OBAFramework.Repository.Infrastructure;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBAFramework.Repository.CQRS.Queries
{
    public interface IExampleQuery
    {
        Task<List<decimal>> GetGraduateAsync();
    }

    public class ExampleQuery : IExampleQuery
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly string GetQuery = "SELECT Grade FROM ExamResults WHERE DeleteStatus=0";
        public ExampleQuery(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<decimal>> GetGraduateAsync()
        {
            try
            {
                var res = await _unitOfWork.GetConnection().QueryAsync<decimal>(GetQuery, null, _unitOfWork.GetTransaction());
                return res.ToList();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
