﻿namespace Transport.Domain.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException(string entityName) : base($"{entityName} not found")
        {
        }
    }
}
