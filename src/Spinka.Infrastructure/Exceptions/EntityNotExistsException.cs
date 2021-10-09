using System;

namespace Spinka.Infrastructure.Exceptions
{
    public class EntityNotExistsException : Exception
    {
        public string Name { get; protected set; }
        public object Key { get; protected set; }

        public EntityNotExistsException(string entityName, object key)
        {
            Name = entityName;
            Key = key;
        }

        public override string Message => $"Entity {Name} was not found by key {Key}";
    }
}