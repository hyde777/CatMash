﻿namespace Domain.Tests;

public interface ICatRepository
{
    Task Update(ICat cat);
    Task<ICat> Get(Guid id);
}