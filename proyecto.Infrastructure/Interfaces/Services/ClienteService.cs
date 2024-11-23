
using proyecto.Domain.Entities;
using Proyecto.Domain.Core;
using System.Net.Http.Json;
using System.Text.Json;

namespace Proyecto.Application.Services
{
    public class ClienteService : IService<Cliente>
    {
        private readonly HttpClient _httpClient;

        public ClienteService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // Obtener todos los clientes
        public async Task<List<Cliente>> GetAllAsync()
        {
            var clientes = await _httpClient.GetFromJsonAsync<List<Cliente>>("https://localhost:7038/api/cliente");
            return clientes ?? new List<Cliente>(); // Retorna una lista vacía si es null
        }

        // Obtener cliente por id
        public async Task<Cliente?> GetByIdAsync(int id)
        {
            var cliente = await _httpClient.GetFromJsonAsync<Cliente>($"https://localhost:7038/api/cliente/{id}");
            return cliente; // Devuelve null si no se encuentra el cliente
        }

        // Crear cliente
        public async Task<Cliente?> CreateAsync(Cliente cliente)
        {
            var response = await _httpClient.PostAsJsonAsync("https://localhost:7038/api/cliente", cliente);
            response.EnsureSuccessStatusCode();
            var createdCliente = await response.Content.ReadFromJsonAsync<Cliente>();
            return createdCliente; // Devuelve null si la respuesta no tiene el cliente
        }

        // Actualizar cliente
        public async Task<Cliente?> UpdateAsync(Cliente cliente)
        {
            var response = await _httpClient.PutAsJsonAsync($"https://localhost:7038/api/cliente/{cliente.Id}", cliente);

            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine($"Error: {response.StatusCode}");
                return null;
            }

            // Verificar si la respuesta tiene contenido
            if (response.Content.Headers.ContentLength == 0)
            {
                Console.WriteLine("La respuesta de la API está vacía.");
                return null;
            }

            // Intentar deserializar el contenido de la respuesta
            var responseBody = await response.Content.ReadAsStringAsync();
            if (string.IsNullOrWhiteSpace(responseBody))
            {
                Console.WriteLine("La respuesta de la API no contiene JSON.");
                return null;
            }

            var updatedCliente = JsonSerializer.Deserialize<Cliente>(responseBody);
            return updatedCliente;
        }

        // Borrar cliente
        public async Task DeleteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"https://localhost:7038/api/cliente/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}

