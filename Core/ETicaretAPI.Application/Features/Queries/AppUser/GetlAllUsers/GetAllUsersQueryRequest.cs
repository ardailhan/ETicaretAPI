using MediatR;

namespace ETicaretAPI.Application.Features.Queries.AppUser.GetlAllUsers
{
    public class GetAllUsersQueryRequest : IRequest<GetAllUsersQueryResponse>
    {
        public int Page { get; set; } = 0;
        public int Size { get; set; } = 5;
    }
}