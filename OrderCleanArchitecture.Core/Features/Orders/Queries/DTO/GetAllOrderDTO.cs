﻿namespace OrderCleanArchitecture.Core.Features.Orders.Queries.DTO
{
    public class GetAllOrderDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int EmployeeId { get; set; }
    }
}
