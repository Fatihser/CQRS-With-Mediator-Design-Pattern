using FSE.Cqrs.CQRS.Results;
using MediatR;
using System.Collections.Generic;

namespace FSE.Cqrs.CQRS.Queries
{
    public class GetStudentsQuery:IRequest<IEnumerable<GetStudentsQueryResult>>
    {
    }
}
