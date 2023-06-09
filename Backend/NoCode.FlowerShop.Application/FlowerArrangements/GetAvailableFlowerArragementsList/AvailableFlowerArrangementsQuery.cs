﻿using ErrorOr;
using FluentValidation;
using MediatR;

namespace NoCode.FlowerShop.Application.FlowerArrangements.GetAvailableFlowerArragementsList;

public sealed record AvailableFlowerArrangementsQuery() : IRequest<ErrorOr<AvailableFlowerArrangementsResult>>;

public sealed class AvailableFlowerArrangementsValidator : AbstractValidator<AvailableFlowerArrangementsQuery> { }