﻿namespace StoryBooks.Features.Authors.Domain.Exceptions;

using StoryBooks.Features.Domain.Exceptions;

internal class InvalidBattleException : BaseDomainException
{
    public InvalidBattleException() { }

    public InvalidBattleException(string error) => this.Error = error;
}