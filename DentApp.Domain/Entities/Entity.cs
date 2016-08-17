using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DentApp.Domain.Interfaces;
using MongoDB.Bson;

namespace DentApp.Domain.Entities
{
    public abstract class BaseEntity
    {
    }

    public class Entity<T> : BaseEntity, IEntity<T>
    {
        public virtual T Identity { get; set; }
        public virtual ObjectId Id { get; set; }
    }
}
