namespace OrderCleanArchitecture.Core.Features.Orders.Queries.DTO
{
    public class GetOrderByIdDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string? EmployeeName { get; set; }
    }
}
