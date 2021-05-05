using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSTienda.DTOs;

namespace WSTienda.Interfaces
{
    public interface ISaleService
    {
        public void Add(SaleRequestDTO model);
    }
}
