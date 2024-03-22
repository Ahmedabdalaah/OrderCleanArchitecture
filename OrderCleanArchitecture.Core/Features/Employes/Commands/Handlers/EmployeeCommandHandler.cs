using AutoMapper;
using MediatR;
using OrderCleanArchitecture.Core.Bases.ResponsHandler;
using OrderCleanArchitecture.Core.Features.Employes.Commands.Models;
using OrderCleanArchitecture.Data.Entities;
using OrderCleanArchitecture.Service.Abstracts;

namespace OrderCleanArchitecture.Core.Features.Employes.Commands.Handlers
{
    public class EmployeeCommandHandler : ResponseHandler,
                                        IRequestHandler<AddEmployeeCommand, string>,
                                        IRequestHandler<EditEmployeeCommand, string>,
                                        IRequestHandler<DeleteEmployeeCommand, string>

    {
        #region Fields
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;
        #endregion
        #region Constructor
        public EmployeeCommandHandler(IEmployeeService employeeService, IMapper mapper)
        {
            _employeeService = employeeService;
            _mapper = mapper;
        }
        #endregion
        #region Handle Functions
        public async Task<string> Handle(AddEmployeeCommand request, CancellationToken cancellationToken)
        {
            // mapping between request and employee
            var employeeMapper = _mapper.Map<Employee>(request);
            //add
            var result = await _employeeService.AddEmployeeAsunc(employeeMapper);
            return "Success";
        }

        public async Task<string> Handle(EditEmployeeCommand request, CancellationToken cancellationToken)
        {
            // mapping between request and employee
            var employeeMapper = _mapper.Map<Employee>(request);
            //add
            var result = await _employeeService.EditEmployeeAsunc(employeeMapper);
            return "Success";
        }

        public async Task<string> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = await _employeeService.GetEmployeeByIdAsync(request.Id);
            var studentResult = await _employeeService.RemoveEmployeeAsync(employee);
            return "Success";
        }
        #endregion
    }
}
