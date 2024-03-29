﻿namespace StoryBooks.Features.Presentation.Controllers;

using System;
using System.Threading.Tasks;

using MediatR;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

using StoryBooks.Features.Application;
using StoryBooks.Features.Presentation.Extensions;

[ApiController]
[Route("[controller]")]
[Obsolete("Use minimal API endpoints!")]
public abstract class ApiController : ControllerBase
{
    public const string PathSeparator = "/";
    public const string Id = "{id}";

    private IMediator? mediator;

    protected IMediator Mediator
    {
        get
        {
            this.mediator ??= this.HttpContext
                .RequestServices
                .GetService<IMediator>();

            if (mediator is null)
            {
                throw new ArgumentException("Mediator is not initialized!");
            }

            return this.mediator;
        }
    }

    protected Task<ActionResult<TResult>> Send<TResult>(IRequest<TResult> request)
        => this.Mediator.Send(request).ToActionResult();

    protected Task<ActionResult> Send(IRequest<Result> request)
        => this.Mediator.Send(request).ToActionResult();

    protected Task<ActionResult<TResult>> Send<TResult>(IRequest<Result<TResult>> request)
        => this.Mediator.Send(request).ToActionResult();
}