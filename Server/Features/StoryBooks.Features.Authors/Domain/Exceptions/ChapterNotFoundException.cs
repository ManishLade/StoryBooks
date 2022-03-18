﻿namespace StoryBooks.Features.Authors.Domain.Exceptions;

using StoryBooks.Features.Domain.Exceptions;

internal class ChapterNotFoundException : BaseDomainException
{
    public ChapterNotFoundException() { }

    public ChapterNotFoundException(string error) => this.Error = error;
}