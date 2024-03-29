﻿namespace StoryBooks.Features.Domain.Exceptions;

public class InvalidPhoneNumberException : BaseDomainException
{
    public InvalidPhoneNumberException()
    {
    }

    public InvalidPhoneNumberException(string error) => this.Error = error;
}