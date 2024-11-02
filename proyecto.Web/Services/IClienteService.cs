using System.Collections.Generic;
using System.Threading.Tasks;
using proyecto.Domain;
using proyecto.Domain.Entities; // Asegúrate de usar el namespace correcto

public interface IClienteService
{
    Task<List<Cliente>> GetAllClientesAsync();
    Task<Cliente> GetClienteByIdAsync(int id);
    Task<Cliente> CreateClienteAsync(Cliente cliente);
    Task<Cliente> UpdateClienteAsync(Cliente cliente);
    Task DeleteClienteAsync(int id);
}
