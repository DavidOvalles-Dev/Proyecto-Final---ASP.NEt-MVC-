using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using proyecto.Domain.Entities;

public class MiembroController : Controller
{
    private readonly HttpClient _httpClient;

    public MiembroController(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri("https://localhost:7038/api/"); // URL de tu API
    }

    public async Task<IActionResult> Index()
    {
        var response = await _httpClient.GetAsync("Miembro");
        if (response.IsSuccessStatusCode)
        {
            var jsonData = await response.Content.ReadAsStringAsync();
            var miembros = JsonSerializer.Deserialize<List<Miembro>>(jsonData, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return View(miembros);
        }
        return View(new List<Miembro>());
    }

    public IActionResult Create()
    {
        return View(new Miembro());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Miembro miembro)
    {
        if (!ModelState.IsValid)
        {
            return View(miembro);
        }

        var miembroJson = JsonSerializer.Serialize(miembro);
        var content = new StringContent(miembroJson, System.Text.Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync("Miembro", content);
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }

        ModelState.AddModelError(string.Empty, "Error al crear el miembro.");
        return View(miembro);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var response = await _httpClient.GetAsync($"Miembro/{id}");
        if (response.IsSuccessStatusCode)
        {
            var jsonData = await response.Content.ReadAsStringAsync();
            var miembro = JsonSerializer.Deserialize<Miembro>(jsonData, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return View(miembro);
        }
        return NotFound();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Miembro miembro)
    {
        if (id != miembro.Id)
        {
            return NotFound();
        }

        if (!ModelState.IsValid)
        {
            return View(miembro);
        }

        var miembroJson = JsonSerializer.Serialize(miembro);
        var content = new StringContent(miembroJson, System.Text.Encoding.UTF8, "application/json");

        var response = await _httpClient.PutAsync($"Miembro/{id}", content);
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }

        ModelState.AddModelError(string.Empty, "Error al editar el miembro.");
        return View(miembro);
    }

    public async Task<IActionResult> Details(int id)
    {
        var response = await _httpClient.GetAsync($"Miembro/{id}");
        if (response.IsSuccessStatusCode)
        {
            var jsonData = await response.Content.ReadAsStringAsync();
            var miembro = JsonSerializer.Deserialize<Miembro>(jsonData, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return View(miembro);
        }

        return NotFound(); // Si no encuentra al miembro, redirige a una página 404
    }

    public async Task<IActionResult> Delete(int id)
    {
        var response = await _httpClient.GetAsync($"Miembro/{id}");
        if (response.IsSuccessStatusCode)
        {
            var jsonData = await response.Content.ReadAsStringAsync();
            var miembro = JsonSerializer.Deserialize<Miembro>(jsonData, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return View(miembro);
        }
        return NotFound();
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var response = await _httpClient.DeleteAsync($"Miembro/{id}");
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }

        ModelState.AddModelError(string.Empty, "Error al eliminar el miembro.");
        return RedirectToAction("Index");
    }
}
