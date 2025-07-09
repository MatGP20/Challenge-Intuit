using BackEnd.DataService.DataContext;
using BackEnd.DataService.Entities;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.DataService.Services
{
    public class ClienteService : IClienteService
    {
        protected readonly IDbContextFactory _contextFactory;

        public ClienteService(IDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        //GetAll - Se obtienen todos los clientes que se encuentran en la base de Datos
        // y se devuelven en una lista.
        public async Task<IEnumerable<Clientes>> GetAllClientsAsync()
        {
            using (var context = _contextFactory.GetNewInstance())
            {
                return await context.Clientes
                    .AsNoTracking()
                    .ToListAsync();
            }
        }

        //GetById - Se obtiene el cliente especificado en el caso de que se encuentre alguno con el Id introducido.
        public async Task<Clientes> GetClientesByIdAsync(int id)
        {
            using (var context = _contextFactory.GetNewInstance())
            {
                var clienteFound = await context.Clientes
                                .AsNoTracking()
                                .Where(x => x.Id == id)
                                .FirstOrDefaultAsync();

                if(clienteFound == null)
                {
                    return new Clientes();
                }
                return clienteFound;
            }
        }

        //Search - Se buscan todos los clientes que tengan el nombre que se paso como parámetro,
        // sin importar la posición en la que se encuentre el nombre en la cadena.
        public async Task<IEnumerable<Clientes>> SearchClienteByName(string name)
        {
            using (var context = _contextFactory.GetNewInstance())
            {
                return await context.Clientes
                    .AsNoTracking()
                    .Where(x => x.Nombre.Contains(name))
                    .ToListAsync();
            }
        }

        //AddNew - Se agrega el cliente que se pasa por parámetro como nuevo cliente, previo a corroborar
        // que no se encuentre algún cliente ya con el mismo CUIT, en donde en el caso de encontrarlo no se vuelve a agregar.
        public async Task<bool> AddNewClienteAsync(Clientes newClient)
        {
            using (var context = _contextFactory.GetNewInstance())
            {
                var clienteFound = await context.Clientes.AsNoTracking().Where(x=>x.CUIT ==  newClient.CUIT).FirstOrDefaultAsync();
                if (clienteFound == null) 
                {
                    await context.Clientes.AddAsync(newClient);

                    await context.SaveChangesAsync();

                    return true;                        
                }
                return false;
            }
        }

        //Update - Se actualizan los datos de un cliente que se pase por parámetro, pero solo
        // actualizando los valores que se encuentran modificados.
        public async Task<bool> UpdateClienteAsync(Clientes updatedCliente)
        {
            using (var context = _contextFactory.GetNewInstance())
            {
                var clienteFound = await context.Clientes.Where(x=> x.Id == updatedCliente.Id).FirstOrDefaultAsync();
                if(clienteFound == null)
                {
                    return false;
                }

                context.Entry(clienteFound)
                        .CurrentValues.SetValues(updatedCliente);

                await context.SaveChangesAsync();

                return true;
            }
        }
    }
}
