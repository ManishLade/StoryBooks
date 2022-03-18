﻿namespace StoryBooks.Features.Authors.Domain.Exceptions;

using StoryBooks.Features.Domain.Exceptions;

internal class BookNotFoundException : BaseDomainException
{
    public BookNotFoundException() { }

    public BookNotFoundException(string error) => this.Error = error;
}