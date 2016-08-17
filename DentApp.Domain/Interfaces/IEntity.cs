using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentApp.Domain.Interfaces
{
    public interface IEntity<T>
    {
        T Identity { get; set; }
        ObjectId Id { get; set; }
    }
}
