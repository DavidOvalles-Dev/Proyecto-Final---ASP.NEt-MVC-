using Microsoft.AspNetCore.Mvc;
using proyecto.Domain.Entities;
using System.Text.Json;

public class EventoController : Controller
{
    private readonly HttpClient _httpClient;

    public EventoController(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri("https://localhost:7038/api/"); // URL de tu API
    }

    public async Task<IActionResult> Index()
    {
        var response = await _httpClient.GetAsync("Evento");
        if (response.IsSuccessStatusCode)
        {
            var jsonData = await response.Content.ReadAsStringAsync();
            var eventos = JsonSerializer.Deserialize<List<Evento>>(jsonData, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return View(eventos);
        }
        return View(new List<Evento>());
    }


    [HttpPost]
    public async Task<IActionResult> MarcarCompletada(int id)
    {
        var response = await _httpClient.DeleteAsync($"Evento/{id}");

        if (response.IsSuccessStatusCode)
        {
            TempData["Message"] = "Evento completado (eliminado)";
            return RedirectToAction("Index");
        }

        TempData["Error"] = "No se pudo completar el Evento.";
        return RedirectToAction("Index");
    }

    public IActionResult Create() => View();

    [HttpPost]
    public async Task<IActionResult> Create(Evento evento)
    {
        if (!ModelState.IsValid) return View(evento);

        var response = await _httpClient.PostAsJsonAsync("evento", evento);
        if (response.IsSuccessStatusCode)
            return RedirectToAction("Index");

        ModelState.AddModelError("", "Error al crear el evento");
        return View(evento);
    }




}
