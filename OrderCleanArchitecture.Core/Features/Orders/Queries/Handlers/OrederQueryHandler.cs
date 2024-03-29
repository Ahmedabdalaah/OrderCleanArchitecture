using AutoMapper;
using MediatR;
using OrderCleanArchitecture.Core.Bases.ResponsHandler;
using OrderCleanArchitecture.Core.Features.Orders.Queries.DTO;
using OrderCleanArchitecture.Core.Features.Orders.Queries.Models;
using OrderCleanArchitecture.Service.Abstracts;

namespace OrderCleanArchitecture.Core.Features.Orders.Queries.Handlers
{
    public class OrederQueryHandler : ResponseHandler,
                                IRequestHandler<GetAllOrdersQuery, List<GetAllOrderDTO>>,
                                IRequestHandler<GetOrderByIdQuery, GetOrderByIdDTO>,
                                IRequestHandler<GetOrderByEmpQuery, GetOrderByEmpDTO>


    {
        private IMapper _mapper;
        private IOrderService _orderService;
        public OrederQueryHandler(IMapper mapper, IOrderService orderService)
        {
            _mapper = mapper;
            _orderService = orderService;
        }
        public async Task<List<GetAllOrderDTO>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
        {
            var orders = await _orderService.GetOrderAsync();
            var orderMapper = _mapper.Map<List<GetAllOrderDTO>>(orders);
            return orderMapper;
        }

        public async Task<GetOrderByIdDTO> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var orders = await _orderService.GetOrderByIdAsync(request.Id);
            var orderMapper = _mapper.Map<GetOrderByIdDTO>(orders);
            return orderMapper;
        }

        public async Task<GetOrderByEmpDTO> Handle(GetOrderByEmpQuery request, CancellationToken cancellationToken)
        {
            var order = await _orderService.SearchOrderAsunc(request.Id);
            var orderMapper = _mapper.Map<GetOrderByEmpDTO>(order);
            return orderMapper;
        }
    }
}
