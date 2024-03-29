﻿namespace StoryBooks.Features.Application.Exceptions;

using System;
using System.Collections.Generic;
using System.Linq;

using FluentValidation.Results;

public class ModelValidationException : Exception
{
    public ModelValidationException()
        : base("One or more validation failures have occurred.")
        => this.Errors = new Dictionary<string, IEnumerable<string>>();

    public ModelValidationException(List<ValidationFailure> failures)
        : this()
    {
        var failureGroups = failures
            .GroupBy(e => e.PropertyName, e => e.ErrorMessage);

        foreach (var failureGroup in failureGroups)
        {
            var propertyName = failureGroup.Key;
            var propertyFailures = failureGroup.ToArray();

            this.Errors.Add(propertyName, propertyFailures);
        }
    }

    public IDictionary<string, IEnumerable<string>> Errors { get; }
}