using core.Interfaces.Repositories.Services;
using core.Interfaces.Services.IServicesService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core.Services.Services
{
    public class ServicesService : IServicesService
    {
        private IServicesRepository _servicesRepository;
        public ServicesService(IServicesRepository servicesRepository)
        {
            _servicesRepository = servicesRepository;
        }
    }
}
