using MediatR;

namespace ETicaretAPI.Application.Features.Queries.Order.GetAllOrders
{
    public class GetAllOrdersQueryRequest : IRequest<List<GetAllOrdersQueryResponse>>
    {
        public int Page { get; set; } = 0;
        public int Size { get; set; } = 5;
    }
}
