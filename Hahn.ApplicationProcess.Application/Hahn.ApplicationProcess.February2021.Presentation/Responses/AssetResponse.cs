using Hahn.ApplicationProcess.February2021.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hahn.ApplicationProcess.February2021.Presentation.Responses
{
    public class AssetResponse
    {
        public bool Status { get; set; }
        public Asset Asset { get; set; }
    }
}
