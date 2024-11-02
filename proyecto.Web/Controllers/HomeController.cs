using Microsoft.AspNetCore.Mvc;
using proyecto.Web.Models;
using System.Diagnostics;
using proyecto.Domain.Entities;
using proyecto.Domain.Data;
using System.Net.Http;
using System.Text.Json;
using System.Text;

namespace proyecto.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public readonly IClienteService _clienteService;


        //aqui dejo el logger y lo meto jutno a la interfaz que cree para que no de errores
        public HomeController(ILogger<HomeController> logger, IClienteService clienteService)
        {
            _logger = logger;
            _clienteService = clienteService;
        }


        public async Task<IActionResult> Index()
        {

            //aqui llamo al metodo que hice de cliente Service
            List<Cliente> clientes = await _clienteService.GetAllClientesAsync();
            return View(clientes);
        }

        [HttpGet]
        public IActionResult Register()
        {

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Register(Cliente cliente)
        {
            Console.WriteLine("Ejecutando desde el form correctamente");
            Console.WriteLine($"Nombre: {cliente.Nombre}, Apellido: {cliente.Apellido}, Email: {cliente.Email}, Tel�fono: {cliente.Telefono}");

            // Verificaci�n de campos vac�os para depuraci�n
            if (string.IsNullOrEmpty(cliente.Nombre))
            {
                Console.WriteLine("El campo Nombre est� vac�o.");
            }
            if (string.IsNullOrEmpty(cliente.Apellido))
            {
                Console.WriteLine("El campo Apellido est� vac�o.");
            }
            if (string.IsNullOrEmpty(cliente.Email))
            {
                Console.WriteLine("El campo Email est� vac�o.");
            }
            if (string.IsNullOrEmpty(cliente.Telefono))
            {
                Console.WriteLine("El campo Tel�fono est� vac�o.");
            }
            if (cliente.Id <= 0)
            {
                Console.WriteLine("El campo Id es inv�lido.");
            }

            if (ModelState.IsValid)
            {
                Console.WriteLine("ModelState es v�lido");
                try
                {
                    await _clienteService.CreateClienteAsync(cliente);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al crear cliente: " + ex.Message);
                    ModelState.AddModelError("", "Ocurri� un error al registrar el cliente: " + ex.Message);
                }
            }
            else
            {
                Console.WriteLine("ModelState no es v�lido");
                foreach (var modelState in ModelState)
                {
                    Console.WriteLine($"Propiedad: {modelState.Key}");
                    foreach (var error in modelState.Value.Errors)
                    {
                        Console.WriteLine($"Error: {error.ErrorMessage}");
                    }
                }
            }

            return View(cliente); // Retornar la vista con el modelo en caso de error
        }


        [HttpGet]
        public async Task<IActionResult> Borrar(int id)
        {
            Console.WriteLine("Ejecutando");
            // Llama a la API para obtener los datos del elemento por ID
            var item = await _clienteService.GetClienteByIdAsync(id); // Llama a la API usando tu servicio de acceso
            if (item == null)
            {
                return NotFound();
            }

            // Pasa el elemento a la vista de confirmaci�n
            return View("Borrar", item);
        }



        // Acci�n POST para confirmar la eliminaci�n
        [HttpPost]
        public async Task<IActionResult> ConfirmarBorrar(int id)
        {
            await _clienteService.DeleteClienteAsync(id); // L�gica para eliminar el elemento en la API
            return RedirectToAction("Index"); // Redirige despu�s de la eliminaci�n
        }

        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            // Llama a la API para obtener los datos del elemento
            var item = await _clienteService.GetClienteByIdAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            // Pasa el elemento a la vista de edici�n
            return View("Editar", item);
        }


        [HttpPost]
        public async Task<IActionResult> ConfirmarEditar(Cliente model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // Llama a la API para actualizar el elemento
            var updatedCliente = await _clienteService.UpdateClienteAsync(model);


            if (updatedCliente == null) // Comprueba si el resultado es nulo
            {
                return RedirectToAction("Index"); // se supone que esto deberia ser NOT found pero por alguna razon me retorna not found pero se aplican los cambios a la base de datos asi que por ahora lo dejare asi  
            }

            // Redirige despu�s de la edici�n
            return RedirectToAction("Index");
        }

        //Editar

        [HttpGet]
        public async Task<IActionResult> Detalles(int id)
        {
            // Llama a la API para obtener los datos del elemento
            var item = await _clienteService.GetClienteByIdAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            // Pasa el elemento a la vista de edici�n
            return View("Detalles", item);
        }






        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }



    }
}
