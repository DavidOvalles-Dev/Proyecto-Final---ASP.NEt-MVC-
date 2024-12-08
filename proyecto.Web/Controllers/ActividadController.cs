using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using proyecto.Domain.Entities;

public class ActividadController : Controller
{
    private readonly HttpClient _httpClient;

    public ActividadController(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri("https://localhost:7038/api/"); // URL de tu API
    }

    public async Task<IActionResult> Index()
    {
        var response = await _httpClient.GetAsync("Actividad");
        ViewData["ActivePage"] = "Actividades";

        if (response.IsSuccessStatusCode)
        {
            var jsonData = await response.Content.ReadAsStringAsync();
            var actividades = JsonSerializer.Deserialize<List<Actividad>>(jsonData, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return View(actividades);
        }
        return View(new List<Actividad>());
    }

    public async Task<IActionResult> Create()
    {
        try
        {
            var response = await _httpClient.GetAsync("Miembro");

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var miembros = JsonSerializer.Deserialize<List<Miembro>>(jsonData, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
                ViewBag.Miembros = miembros;
            }
            else
            {
                TempData["Error"] = "No se pudieron cargar los miembros.";
                ViewBag.Miembros = new List<Miembro>();
            }
        }
        catch (Exception ex)
        {
            TempData["Error"] = $"Ocurrió un error: {ex.Message}";
            ViewBag.Miembros = new List<Miembro>();
        }

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Actividad actividad, int OrganizadorId, List<int> MiembroIds)
    {
        if (!ModelState.IsValid)
        {
            return View(actividad);
        }

        var actividadData = new
        {
            actividad.Nombre,
            actividad.Descripcion,
            actividad.Fecha,
            OrganizadorId,
            MiembroIds
        };

        var jsonContent = new StringContent(
            JsonSerializer.Serialize(actividadData),
            System.Text.Encoding.UTF8,
            "application/json"
        );

        var response = await _httpClient.PostAsync("Actividad", jsonContent);

        if (response.IsSuccessStatusCode)
        {
            TempData["Message"] = "Actividad creada con éxito.";
            return RedirectToAction("Index");
        }

        TempData["Error"] = "No se pudo crear la actividad.";
        return View(actividad);
    }

    public async Task<IActionResult> MarcarAsistencia(int actividadId)
    {
        var response = await _httpClient.GetAsync($"Miembro/ByActividad/{actividadId}");
        if (response.IsSuccessStatusCode)
        {
            var jsonData = await response.Content.ReadAsStringAsync();
            var miembros = JsonSerializer.Deserialize<List<Miembro>>(jsonData, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            ViewBag.ActividadId = actividadId;
            return View(miembros);
        }

        TempData["Error"] = "No se pudieron cargar los miembros.";
        return RedirectToAction("Index");
    }

    [HttpPost]
    public async Task<IActionResult> GuardarAsistencia(int actividadId, Dictionary<int, bool> Asistencia)
    {
        var asistenciaData = Asistencia.Select(a => new
        {
            MiembroId = a.Key,
            ActividadId = actividadId,
            Asistio = a.Value
        });

        var jsonContent = new StringContent(
            JsonSerializer.Serialize(asistenciaData),
            System.Text.Encoding.UTF8,
            "application/json"
        );

        var response = await _httpClient.PostAsync("MiembroActividad/GuardarAsistencia", jsonContent);

        if (response.IsSuccessStatusCode)
        {
            TempData["Message"] = "Asistencia guardada con éxito.";
            return RedirectToAction("Index");
        }

        TempData["Error"] = "No se pudo guardar la asistencia.";
        return RedirectToAction("MarcarAsistencia", new { actividadId });
    }

    public async Task<IActionResult> VerParticipantes(int actividadId)
    {
        var response = await _httpClient.GetAsync($"Miembro/ByActividad/{actividadId}");
        if (response.IsSuccessStatusCode)
        {
            var jsonData = await response.Content.ReadAsStringAsync();
            var miembros = JsonSerializer.Deserialize<List<Miembro>>(jsonData, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            ViewBag.Actividad = await _httpClient.GetFromJsonAsync<Actividad>($"Actividad/{actividadId}");
            return View(miembros);
        }

        TempData["Error"] = "No se pudieron cargar los participantes.";
        return RedirectToAction("Index");
    }

    [HttpPost]
    public async Task<IActionResult> MarcarCompletada(int id)
    {
        var response = await _httpClient.DeleteAsync($"Actividad/{id}");

        if (response.IsSuccessStatusCode)
        {
            TempData["Message"] = "Actividad completada (eliminada)";
            return RedirectToAction("Index");
        }

        TempData["Error"] = "No se pudo completar la actividad.";
        return RedirectToAction("Index");
    }
}
