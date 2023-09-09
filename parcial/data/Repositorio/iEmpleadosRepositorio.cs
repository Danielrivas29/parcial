using model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data.Repositorio
{
    public interface iEmpleadosRepositorio
    {
        Task<IEnumerable<empleados>> getEmpleados();
        Task<empleados> getEmpleadosById(int id);
        Task<bool> insertEmpleados(empleados empleados);
        Task<bool> updateEmpleados(empleados empleados);
        Task<bool> deleteEmpleados(int id);
    }
}
