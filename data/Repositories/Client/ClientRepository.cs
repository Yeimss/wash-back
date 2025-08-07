using core.Interfaces.Repositories.Client;
using data.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data.Repositories.Client
{
    public class ClientRepository : IClientRepository
    {
        private readonly LavaderoBDContext _context;
        public ClientRepository(LavaderoBDContext context)
        {
            _context = context;
        }

    }
}
