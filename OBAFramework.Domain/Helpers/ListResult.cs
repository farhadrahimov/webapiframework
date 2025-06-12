using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBAFramework.Domain.Helpers
{
    public class ListResult<T> where T : class
    {
        public IEnumerable<T>? List { get; set; }
        public int TotalCount { get; set; }
    }
}
