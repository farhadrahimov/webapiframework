using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBAFramework.Domain.Helpers
{
    public class BaseModel
    {
        public long Id { get; set; }

        [StringLength(200)]
        public string Name { get; set; } = string.Empty;
    }
}
