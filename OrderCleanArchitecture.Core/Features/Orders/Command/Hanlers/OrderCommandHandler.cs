using AutoMapper;
using MediatR;
using OrderCleanArchitecture.Core.Bases.ResponsHandler;
using OrderCleanArchitecture.Core.Features.Orders.Command.Models;
using OrderCleanArchitecture.Data.Entities;
using OrderCleanArchitecture.Service.Abstracts;

namespace OrderCleanArchitecture.Core.Features.Orders.Command.Hanlers
{
    public class OrderCommandHandler : ResponseHandler,
                                     IRequestHandler<AddOrderCommand, string>,
                                     IRequestHandler<EditOrderCommands, string>,
                                     IRequestHandler<DeleteOrderCommand, string>
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;
        public OrderCommandHandler(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }
        public async Task<string> Handle(AddOrderCommand request, CancellationToken cancellationToken)
        {
            var orderMapper = _mapper.Map<Order>(request);
            await _orderService.AddOrderAsunc(orderMapper);
            return "Success";
        }

        public async Task<string> Handle(EditOrderCommands request, CancellationToken cancellationToken)
        {
            var orderMapper = _mapper.Map<Order>(request);
            await _orderService.EditOrderAsunc(orderMapper);
            return "Success";
        }

        public async Task<string> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _orderService.GetOrderByIdAsync(request.Id);
            _orderService.RemoveOrderAsync(order);
            return "Success";

        }
    }
}
