﻿namespace ETicaretAPI.Application.Features.Queries.Order.GetAllOrders
{
    public class GetAllOrdersQueryResponse
    {
        public string OrderCode { get; set; }
        public string UserName { get; set; }
        public float TotalPrice { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
