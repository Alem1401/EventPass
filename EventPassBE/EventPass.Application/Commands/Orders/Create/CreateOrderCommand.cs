using EventPass.Application.DTOs.OrderDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPass.Application.Commands.Orders.Create
{
    public class CreateOrderCommand: IRequest<ResponseOrderDto>
    {
        public CreateOrderDto dto {  get; set; }
    }
}
