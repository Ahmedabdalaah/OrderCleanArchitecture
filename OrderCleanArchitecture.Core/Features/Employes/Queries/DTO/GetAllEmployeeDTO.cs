﻿namespace OrderCleanArchitecture.Core.Features.Employes.Queries.DTO
{
    public class GetAllEmployeeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string? CategoryName { get; set; }

    }
}