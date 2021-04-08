using Hahn.ApplicationProcess.February2021.Domain.Models.Constants;
using Hahn.ApplicationProcess.February2021.Domain.Repository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.ApplicationProcess.February2021.Data.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        public DepartmentRepository()
        {
        }

        public Dictionary<int, string> GetDepartments()
        {
            return Enum.GetValues(typeof(DepartmentEnum))
                          .Cast<DepartmentEnum>()
                          .ToDictionary(t => (int)t, t => t.ToString());
        }
    }
}
