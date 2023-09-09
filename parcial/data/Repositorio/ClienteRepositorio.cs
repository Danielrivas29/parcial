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
    public class ClienteRepositorio : iClienteRepositorio
    {
        public readonly mysqlconfig _connection;
        public ClienteRepositorio(mysqlconfig connection)
        {
            _connection = connection;
        }
        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connection._connectionstring);
        }
        public Task<IEnumerable<cliente>> getClientes()
        {
            var db = dbConnection();
            var consulta = @"select * from clientes";
            return db.QueryAsync<cliente>(consulta);
        }

        public Task<cliente> getClienteById(int id)
        {
            var db = dbConnection();
            var consulta = @"select * from clientes where idClientes=@Id";
            return db.QueryFirstOrDefaultAsync<cliente>(consulta, new { Id = id });
        }

        public async Task<bool> insertCliente(cliente cliente)
        {
            var db = dbConnection();
            var sql = @"insert into clientes(Documento, Nombre, Edad, Genero, idclientes)values(@Documento, @Nombre, @Edad, @Genero, @idclientes)";
            var result = await db.ExecuteAsync(sql, new { cliente.documento, cliente.nombre, cliente.edad, cliente.genero, cliente.idclientes });

            return result > 0;
        }

        public async Task<bool> updateCliente(cliente cliente)
        {
            var db = dbConnection();
            var sql = @"update clientes set Documento=@Documento,Nombre=@Nombre,Edad=@Edad,Genero=@Genero,idclientes=@idclientes where (idclientes=@Idclientes)";
            var result = await db.ExecuteAsync(sql, new { cliente.documento, cliente.nombre, cliente.edad, cliente.genero, cliente.idclientes });
            return result > 0;
        }
        public async Task<bool> deleteCliente(int id)
        {
            var db = dbConnection();
            var sql = @"delete from clientes where idclientes=@Id";
            var result = await db.ExecuteAsync(sql, new { id });
            return result > 0;
        }
    }
}
