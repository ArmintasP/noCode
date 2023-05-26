using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoCode.FlowerShop.Contracts.Common;

public sealed record CartSection(
    Guid Id,
    Guid CustomerId,
    List<FlowerArrangementSection> FlowerArrangements);
