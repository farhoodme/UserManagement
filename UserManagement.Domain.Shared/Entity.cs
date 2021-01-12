using System;
using System.Collections.Generic;
using System.Text;

namespace UserManagement
{
    public interface IEntity
    {

    }

    public abstract class Entity<TKey> : IEntity
    {
        public TKey Id { get; set; }
    }

    public abstract class Entity : Entity<int>
    {

    }

    public interface IEntityDto
    {

    }

    public abstract class EntityDto<TKey> : IEntityDto
    {
        public TKey Id { get; set; }
    }

    public abstract class EntityDto : EntityDto<int>
    {

    }
}
