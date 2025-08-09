using core.Interfaces.Services.Washed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core.Services.Washed
{
    public class WashedService : IWashedService
    {
        private readonly IWashedService _washedService;
        public WashedService(IWashedService washedService)
        {
            _washedService = washedService;
        }
    }
}
