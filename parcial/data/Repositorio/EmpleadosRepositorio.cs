using Dapper;
using model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data.Repositorio
{
    public class EmpleadosRepositorio : iEmpleadosRepositorio
    {
        public readonly mysqlconfig _connection;
        public EmpleadosRepositorio(mysqlconfig connection)
        {
            _connection = connection;
        }
        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connection._connectionstring);
        }
        public Task<IEnumerable<empleados>> getEmpleados()
        {
            var db = dbConnection();
            var consulta = @"select * from Empleados";
            return db.QueryAsync<empleados>(consulta);
        }

        public Task<empleados> getEmpleadosById(int id)
        {
            var db = dbConnection();
            var consulta = @"select * from Empleados where idempleados=@Id";
            return db.QueryFirstOrDefaultAsync<empleados>(consulta, new { Id = id });
        }

        public async Task<bool> insertEmpleados(empleados empleados)
        {
            var db = dbConnection();
            var sql = @"insert into empleados(Nombre, Documento, Salario, Cargo, idempleados)values(@Nombre, @Documento, @Salario, @Cargo, @idempleados)";
            var result = await db.ExecuteAsync(sql, new { empleados.nombre, empleados.documento, empleados.salario, empleados.cargo, empleados.idempleados });

            return result > 0;
        }

        public async Task<bool> updateEmpleados(empleados empleados)
        {
            var db = dbConnection();
            var sql = @"update empleados set Nombre=@Nombre,Documento=@Documento,Salario=@Salario, Cargo=@Cargo,idempleados=@idempleados where (idempleados=@Idempleados)";
            var result = await db.ExecuteAsync(sql, new { empleados.nombre, empleados.documento, empleados.salario, empleados.cargo, empleados.idempleados });
            return result > 0;
        }
        public async Task<bool> deleteEmpleados(int id)
        {
            var db = dbConnection();
            var sql = @"delete from empleados where idempleados=@Id";
            var result = await db.ExecuteAsync(sql, new { id });
            return result > 0;
        }
    }
}
