using model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data.Repositorio
{
    public interface iVentaRepositorio
    {
        Task<IEnumerable<ventas>> getVenta();
        Task<bool> insertVenta(ventas ventas);
    }
}
