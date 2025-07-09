using BackEnd.DataService.Entities;

namespace BackEnd.DataService.Services
{
    public interface IClienteService
    {
        Task<IEnumerable<Clientes>> GetAllClientsAsync();
        Task<Clientes> GetClientesByIdAsync(int id);
        Task<IEnumerable<Clientes>> SearchClienteByName(string name);
        Task<bool> AddNewClienteAsync(Clientes newClient);
        Task<bool> UpdateClienteAsync(Clientes updatedCliente);
    }
}
