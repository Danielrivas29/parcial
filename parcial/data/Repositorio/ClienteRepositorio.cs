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
        public async Task<bool> deleteCliente(int id)
        {
            var db = dbConnection();
            var sql = @"delete from clientes where idClientes=@Id";
            var result = await db.ExecuteAsync(sql, new { id });
            return result > 0;
        }

        public Task<cliente> getClienteById(int id)
        {
            var db = dbConnection();
            var consulta = @"select * from clientes where idClientes=@Id";
            return db.QueryFirstOrDefaultAsync<cliente>(consulta, new { Id = id });
        }

        public Task<IEnumerable<cliente>> getClientes()
        {
            var db = dbConnection();
            var consulta = @"select * from clientes";
            return db.QueryAsync<cliente>(consulta);
        }

        public async Task<bool> insertCliente(cliente cliente)
        {
            var db = dbConnection();
            var sql = @"insert into clientes(Documento,Nombre, Edad, Foto, TipoDocumento_idTipoDocumento, ultimo)values(@Documento,@Nombre, @Edad, @Foto, @tipoDoc, @premium)";
            var result = await db.ExecuteAsync(sql, new { cliente.documento, cliente.nombre, cliente.edad, cliente.foto, cliente.tipoDoc, cliente.premium });

            return result > 0;
        }

        public async Task<bool> updateCliente(cliente cliente)
        {
            var db = dbConnection();
            var sql = @"update clientes set Documento=@Documento,Nombre=@Nombre,Edad=@Edad,Foto=@Foto,TipoDocumento_idTipoDocumento=@TipoDoc,ultimo=@Premium where (idClientes=@Id)";
            var result = await db.ExecuteAsync(sql, new { cliente.documento, cliente.nombre, cliente.edad, cliente.foto, cliente.tipoDoc, cliente.premium, cliente.id });
            return result > 0;

        }
    }
}
