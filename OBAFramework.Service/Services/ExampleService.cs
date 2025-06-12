using OBAFramework.Domain.Models;
using OBAFramework.Repository.Infrastructure;
using OBAFramework.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBAFramework.Service.Services
{
    public interface IExampleService
    {
        Task<decimal[]> GetDecreaseGraduate(int value);
        Task<IEnumerable<ExampleModel>> GetData();
    }

    public class ExampleService : IExampleService
    {
        private readonly IExampleRepository _exampleRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ExampleService(IExampleRepository exampleRepository, IUnitOfWork unitOfWork)
        {
            _exampleRepository = exampleRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<ExampleModel>> GetData()
        {
            var data = await _exampleRepository.GetData();
            return data;
        }

        public async Task<decimal[]> GetDecreaseGraduate(int value)
        {
            try
            {
                var data = await _exampleRepository.GetGraduateAsync();
                var newData = data.Select(item => item / value).ToList();

                return newData.ToArray();
            }
            catch
            {
                throw;
            }
        }
    }
}
