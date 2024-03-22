using AutoMapper;
using MediatR;
using OrderCleanArchitecture.Core.Bases.ResponsHandler;
using OrderCleanArchitecture.Core.Features.Employes.Queries.DTO;
using OrderCleanArchitecture.Core.Features.Employes.Queries.Models;
using OrderCleanArchitecture.Service.Abstracts;


namespace OrderCleanArchitecture.Core.Features.Employes.Queries.Handlers
{
    public class EmployeeHandler : ResponseHandler,
                        IRequestHandler<GetAllEmployeeQuery, List<GetAllEmployeeDTO>>,
                IRequestHandler<GetEmployeeByIDQuery, GetEmployeeIDDto>
    {
        #region Filds
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;
        #endregion
        #region Constructor
        public EmployeeHandler(IMapper mapper, IEmployeeService employeeService)
        {
            _employeeService = employeeService;
            _mapper = mapper;
        }

        #endregion
        #region Handle Actions
        public async Task<List<GetAllEmployeeDTO>> Handle(GetAllEmployeeQuery request, CancellationToken cancellationToken)
        {
            var employeetList = await _employeeService.GetEmployeeAsync();
            var employeeMapper = _mapper.Map<List<GetAllEmployeeDTO>>(employeetList);
            return employeeMapper;
        }

        public async Task<GetEmployeeIDDto> Handle(GetEmployeeByIDQuery request, CancellationToken cancellationToken)
        {
            var employee = await _employeeService.GetEmployeeByIdAsync(request.Id);
            var employeeMapper = _mapper.Map<GetEmployeeIDDto>(employee);
            return employeeMapper;
        }



        #endregion

    }
}
