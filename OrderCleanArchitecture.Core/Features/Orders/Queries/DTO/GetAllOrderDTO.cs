namespace OrderCleanArchitecture.Core.Features.Orders.Queries.DTO
{
    public class GetAllOrderDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Describtion { get; set; }
        public string? EmployeeName { get; set; }
    }
}
