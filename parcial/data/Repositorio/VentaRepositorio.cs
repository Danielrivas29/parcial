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
    public class VentaRepositorio : iVentaRepositorio
    {
        public readonly mysqlconfig _connection;
        public VentaRepositorio(mysqlconfig connection)
        {
            _connection = connection;
        }
        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connection._connectionstring);
        }
        public async Task<bool> insertVenta(ventas ventas)
        {
            var db = dbConnection();
            var sql = @"insert into venta(Fecha, Edad, idempleados, idclientes, idproductos)values(@Fecha, @Edad, @idempleados, @idclientes, @idproductos)";
            var result = await db.ExecuteAsync(sql, new { ventas.fecha, ventas.edad, ventas.idempleados, ventas.idclientes, ventas.idproductos});

            return result > 0;
        }

        public Task<IEnumerable<ventas>> getVenta()
        {
            var db = dbConnection();
            var consulta = @"select * from venta";
            return db.QueryAsync<ventas>(consulta);
        }
    }
}
