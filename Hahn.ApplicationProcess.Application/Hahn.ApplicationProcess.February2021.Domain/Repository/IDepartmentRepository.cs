using Hahn.ApplicationProcess.February2021.Domain.Models.Constants;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.ApplicationProcess.February2021.Domain.Repository
{
    public interface IDepartmentRepository
    {
        Dictionary<int, string> GetDepartments();
    }
}
