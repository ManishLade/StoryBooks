﻿namespace StoryBooks.Features.Authors.Domain.Exceptions;

using StoryBooks.Features.Domain.Exceptions;

internal class InvalidGenreException : BaseDomainException
{
    public InvalidGenreException() { }

    public InvalidGenreException(string error) => this.Error = error;
}