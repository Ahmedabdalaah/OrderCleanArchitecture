﻿using MediatR;

namespace OrderCleanArchitecture.Core.Features.Employes.Commands.Models
{
    public class EditEmployeeCommand : IRequest<string>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public int CategoryId { get; set; }
    }
}
