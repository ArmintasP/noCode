using ErrorOr;
using MediatR;
using NoCode.FlowerShop.Application.Customers.FlowerArrangements.GetFlowerArrangementById;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoCode.FlowerShop.Application.Customers.Carts;
public sealed record GetCartByCustomerIdQuery(Guid customerId) : IRequest<ErrorOr<GetCartByCustomerIdResult>>;
