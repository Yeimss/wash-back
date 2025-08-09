using core.Interfaces.Repositories.Washed;
using data.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data.Repositories.Washed
{
    public class WashedRepository : IWashedRepository
    {
        private readonly LavaderoBDContext _context;
        public WashedRepository(LavaderoBDContext context) 
        {
            _context = context;
        }
    }
}
