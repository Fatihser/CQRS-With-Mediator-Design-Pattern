using FSE.Cqrs.CQRS.Results;
using MediatR;

namespace FSE.Cqrs.CQRS.Queries
{
    public class GetStudentByIdQuery:IRequest<GetStudentByIdQueryResult>
    {
        public GetStudentByIdQuery(int ıd)
        {
            Id = ıd;
        }

        public int Id { get; set; }
    }
}
