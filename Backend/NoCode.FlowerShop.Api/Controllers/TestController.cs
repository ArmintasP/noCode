using Azure.Core;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NoCode.FlowerShop.Application.Common.Interfaces.Authentication;
using NoCode.FlowerShop.Application.Common.Interfaces.Persistence;
using NoCode.FlowerShop.Application.Customers.Authentication.Register;
using NoCode.FlowerShop.Domain;
using NoCode.FlowerShop.Domain.Common;
using NoCode.FlowerShop.Infrastructure.Persistence.Repositories;
using System.Runtime.InteropServices;

namespace NoCode.FlowerShop.Api.Controllers;

[Route("test")]
public class TestController : ApiController
{
    private readonly IFlowerArrangementRepository _flowerArrangementRepository;
    private readonly IFlowerArrangementCategoryRepository _flowerArrangementCategoryRepository;
    private readonly IFlowerRepository _flowerRepository;
    private readonly ISender _mediator;
    private readonly IPasswordProvider _passwordProvider;
    private readonly IAdministratorRepository _administratorRepository;
    private readonly IDeliveryLocationRepository _deliveryLocationRepository;
    private readonly ICartRepository _cartRepository;
    private readonly IOrderRepository _orderRepository;

    public TestController(
        IFlowerArrangementRepository flowerArrangementRepository,
        IFlowerRepository flowerRepository,
        IFlowerArrangementCategoryRepository flowerArrangementCategoryRepository,
        ISender mediator,
        IPasswordProvider passwordProvider,
        IAdministratorRepository administratorRepository,
        IDeliveryLocationRepository deliveryLocationRepository,
        ICartRepository cartRepository,
        IOrderRepository orderRepository)
    {
        _flowerArrangementRepository = flowerArrangementRepository;
        _flowerRepository = flowerRepository;
        _flowerArrangementCategoryRepository = flowerArrangementCategoryRepository;
        _mediator = mediator;
        _passwordProvider = passwordProvider;
        _administratorRepository = administratorRepository;
        _deliveryLocationRepository = deliveryLocationRepository;
        _cartRepository = cartRepository;
        _orderRepository = orderRepository;
    }

    [HttpGet("populate-data")]
    [AllowAnonymous]
    public async Task<IActionResult> PopulateData()
    {
        await _mediator.Send(new CustomerRegisterCommand("customer@gmail.com", "Abcd1234"));
        await _mediator.Send(new CustomerRegisterCommand("customer2@gmail.com", "Abcd1234"));
        await _mediator.Send(new CustomerRegisterCommand("customer3@gmail.com", "Abcd1234"));
        await CreateAndSaveAdministrator("admin@gmail.com", "Abcd1234");
        await CreateAndSaveAdministrator("admin2@gmail.com", "Abcd1234");

        var fa1 = new FlowerArrangement(
            "flower arrangement1", "descr", "https://i.imgur.com/ge7UFcA.jpeg", 20m, 100,
            new FlowerArrangementCategory("cartegory1"),
            new() { new Flowers(new Flower("flower1", "https://i.imgur.com/ge7UFcA.jpeg"), 3),
                    new Flowers(new Flower("flower3", "https://i.imgur.com/ge7UFcA.jpeg"), 3)});

        await _flowerArrangementRepository.AddAsync(fa1);

        var fa2 = new FlowerArrangement(
            "flower arrangement2", "descr", "https://i.imgur.com/ge7UFcA.jpeg", 1.4m, 10,
            new FlowerArrangementCategory("carteg2"),
            new() { new Flowers(new Flower("flower2", "https://i.imgur.com/ge7UFcA.jpeg"), 5) });

        await _flowerArrangementRepository.AddAsync(fa2);

        var f4 = new Flower("flower4", "https://i.imgur.com/ge7UFcA.jpeg");
        var f5 = new Flower("flower5", "https://i.imgur.com/ge7UFcA.jpeg");

        await _flowerRepository.AddAsync(f4);
        await _flowerRepository.AddAsync(f5);

        var fc3 = new FlowerArrangementCategory("cartegory4");
        var fc4 = new FlowerArrangementCategory("cartegory5");

        await _flowerArrangementCategoryRepository.AddAsync(fc3);
        await _flowerArrangementCategoryRepository.AddAsync(fc4);

        var dl1 = new DeliveryLocation("NoCodia", "NoCodicty", "c# street", "noCODE");
        var dl2 = new DeliveryLocation("NoCodia2", "NoCodicty2", "c# street 2", "noCODE2");

        await _deliveryLocationRepository.AddAsync(dl1);
        await _deliveryLocationRepository.AddAsync(dl2);


        var c4 = CreateCustomer("customer4@gmail.com", "Abcd1234");
        var c5 = CreateCustomer("customer5@gmail.com", "Abcd1234");

        var cart1 = new Cart(
            c4,
           new()
           {
               new FlowerArrangementPair(
                   new FlowerArrangement(
                        "flower arrangement3", "descr", "https://i.imgur.com/ge7UFcA.jpeg", 20m, 100,
                        new FlowerArrangementCategory("cartegory6"),
                        new() { new Flowers(f4, 2),
                                new Flowers(f5, 2)}),
                   quantity: 2),
              new FlowerArrangementPair(
                   new FlowerArrangement(
                        "flower arrangement4", "descr", "https://i.imgur.com/ge7UFcA.jpeg", 1m, 255,
                        new FlowerArrangementCategory("cartegory7"),
                        new() { new Flowers(f4, 2) }),
                   quantity: 10)
           });

        var fp1 = new FlowerArrangementPair(
                   fa2,
                   quantity: 1);
        var fp2 = new FlowerArrangementPair(
                   fa1,
                   quantity: 10);

        var cart2 = new Cart(
           c5,
           new()
           {
               fp1, fp2
           });

        await _cartRepository.AddAsync(cart1);
        await _cartRepository.AddAsync(cart2);

        var o1 = new Order(DeliveryOption.SelfPickup, OrderStatus.Completed, "Nocody", "Hubby", "+404404404404",
            new() { fp1, fp2 },
            c4,
            new DeliveryLocation("a", "b", "c", "d"));

        await _orderRepository.AddAsync(o1);

        return Ok();
    }
    private Task CreateAndSaveAdministrator(string email, string password)
    {
        var (hashedPassword, salt) = _passwordProvider.HashPassword(password);

        var administrator = new Administrator(Guid.NewGuid(), email, hashedPassword, salt);
        return _administratorRepository.AddAsync(administrator);
    }

    private Customer CreateCustomer(string email, string password)
    {
        var (hashedPassword, salt) = _passwordProvider.HashPassword(password);

        return new Customer(email, hashedPassword, salt);
    }
}
