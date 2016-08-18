using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentApp.Infra.Data.Context
{
    public class MongoDBContextOptions
    {
        public string ConnectionString { get; set; }
        public string DataBaseName { get; set; }
    }
}
