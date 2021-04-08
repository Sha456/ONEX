using Hahn.ApplicationProcess.February2021.Presentation.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hahn.ApplicationProcess.February2021.Presentation.Queries
{
    public class GetAllAssetsQuery : IRequest<List<AllAssetResponse>>
    {
        public GetAllAssetsQuery() { }

    }
}
