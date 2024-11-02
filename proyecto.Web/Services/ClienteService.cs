using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using proyecto.Domain;
using proyecto.Domain.Entities;
using System.Text.Json; // Asegúrate de usar tu modelo aquí

public class ClienteService : IClienteService
{
    private readonly HttpClient _httpClient;

    public ClienteService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    // Obtener todos los clientes
    public async Task<List<Cliente>> GetAllClientesAsync()
    {
        var clientes = await _httpClient.GetFromJsonAsync<List<Cliente>>("https://localhost:7038/api/cliente");
        return clientes ?? new List<Cliente>(); // Retorna una lista vacía si es null
    }

    // Obtener cliente por id
    public async Task<Cliente?> GetClienteByIdAsync(int id)
    {
        var cliente = await _httpClient.GetFromJsonAsync<Cliente>($"https://localhost:7038/api/cliente/{id}");
        return cliente; // Devuelve null si no se encuentra el cliente
    }

    // Crear cliente
    public async Task<Cliente?> CreateClienteAsync(Cliente cliente)
    {
        var response = await _httpClient.PostAsJsonAsync("https://localhost:7038/api/cliente", cliente);
        response.EnsureSuccessStatusCode();
        var createdCliente = await response.Content.ReadFromJsonAsync<Cliente>();
        return createdCliente; // Devuelve null si la respuesta no tiene el cliente
    }

    // Actualizar algún cliente por id
public async Task<Cliente?> UpdateClienteAsync(Cliente cliente)
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
        return null; // Evita deserializar si no hay contenido
    }

    // Captura el contenido de la respuesta como cadena y verifica si está vacía
    var responseBody = await response.Content.ReadAsStringAsync();
    if (string.IsNullOrWhiteSpace(responseBody))
    {
        Console.WriteLine("La respuesta de la API no contiene JSON.");
        return null; // Evita deserializar si el contenido es una cadena vacía
    }

    // Si el contenido no está vacío, intenta deserializar
    var updatedCliente = JsonSerializer.Deserialize<Cliente>(responseBody);
    return updatedCliente;
}


    // Borrar cliente por id
    public async Task DeleteClienteAsync(int id)
    {
        var response = await _httpClient.DeleteAsync($"https://localhost:7038/api/cliente/{id}");
        response.EnsureSuccessStatusCode();
    }
}
