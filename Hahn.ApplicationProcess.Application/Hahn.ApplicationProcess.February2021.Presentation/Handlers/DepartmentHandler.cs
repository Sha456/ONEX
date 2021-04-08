using Hahn.ApplicationProcess.February2021.Domain.Repository;
using Hahn.ApplicationProcess.February2021.Presentation.Queries;
using Hahn.ApplicationProcess.February2021.Presentation.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Hahn.ApplicationProcess.February2021.Presentation.Handlers
{
    public class DepartmentHandler : IRequestHandler<GetDepartmentsQuery, IList<DepartmentResponse>>
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentHandler(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task<IList<DepartmentResponse>> Handle(GetDepartmentsQuery request, CancellationToken cancellationToken)
        {
     
                Dictionary<int, string> allDepartments = _departmentRepository.GetDepartments();
                IList<DepartmentResponse> listOfDepartmentResponse = new List<DepartmentResponse>();
                foreach (var i in allDepartments)
                {
                    DepartmentResponse departmentResponse = new DepartmentResponse
                    {
                        DepartmentId = i.Key,
                        DepartmentName = i.Value
                    };
                    listOfDepartmentResponse.Add(departmentResponse);
                }
                return listOfDepartmentResponse;
            
        }





    }
}
