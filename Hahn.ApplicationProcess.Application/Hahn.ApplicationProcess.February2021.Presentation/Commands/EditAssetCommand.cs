using Hahn.ApplicationProcess.February2021.Presentation.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hahn.ApplicationProcess.February2021.Presentation.Commands
{
    public class EditAssetCommand : IRequest<AssetResponse>
    {
        public int AssetId { get; set; }
        public string AssetName { get; set; }
        public int DepartmentId { get; set; }
        public string CountryOfDepartment { get; set; }
        public DateTime PurchaseDate { get; set; }
        public string EMailAdressOfDepartment { get; set; }
        public bool Broken { get; set; }
    }
}
