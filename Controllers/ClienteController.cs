using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Teste_TGS.Interfaces;
using Teste_TGS.Models;
using Teste_TGS.ViewModels;


namespace Teste_TGS.Controllers;

public class ClienteController : Controller
{
    private readonly ILogger<ClienteController> _logger;
    private readonly IClienteRepository _clienteRepository;

    public ClienteController(ILogger<ClienteController> logger, IClienteRepository clienteRepository)
    {
        _logger = logger;
        _clienteRepository = clienteRepository;
    }

    public IActionResult Index()
    {
        var clientes = _clienteRepository.GetAllClientes();

        ICollection<ClienteViewModel> clienteViewModel = new List<ClienteViewModel>();

        foreach (var registro in clientes)
        {
            ClienteViewModel obj = new ClienteViewModel();
            obj.Id = registro.Id;
            obj.Nome = registro.Nome;
            obj.Email = registro.Email;

            clienteViewModel.Add(obj);
        }
        return View(clienteViewModel);
    }


    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Cliente cliente)
    {
        if (ModelState.IsValid)
        {
            _clienteRepository.CreateCliente(cliente);
            return RedirectToAction("Index");
        }
        return View(cliente);
    }
    public IActionResult Details(int id)
    {

        if (id == 0)
        {
            RedirectToAction("Index", "Home");
        }

        var cliente = _clienteRepository.GetClienteById(id);

        if (cliente == null)
        {
            return NotFound();
        }

        ClienteViewModel obj = new ClienteViewModel();
        obj.Id = cliente.Id;
        obj.Nome = cliente.Nome;
        obj.Email = cliente.Email;

        return View(obj);
    }

    public IActionResult Edit(int id)
    {
        var cliente = _clienteRepository.GetClienteById(id);
        if (cliente == null)
        {
            return NotFound();
        }
        ClienteViewModel obj = new ClienteViewModel();
        obj.Id = cliente.Id;
        obj.Nome = cliente.Nome;
        obj.Email = cliente.Email;

        return View(obj);
    }

    // [HttpPost]
    // public IActionResult Edit(Cliente cliente)
    // {
    //     if (ModelState.IsValid)
    //     {
    //         _clienteRepository.UpdateCliente(cliente);
    //         return RedirectToAction("Index");
    //     }
    //     return View(cliente);
    // }

    public IActionResult Delete(int id)
    {
        var cliente = _clienteRepository.GetClienteById(id);
        if (cliente == null)
        {
            return NotFound();
        }

        ClienteViewModel obj = new ClienteViewModel();
        obj.Id = cliente.Id;
        obj.Nome = cliente.Nome;
        obj.Email = cliente.Email;

        return View(obj);
    }

    [HttpPost, ActionName("Delete")]
    public IActionResult DeleteConfirmed(int id)
    {
        _clienteRepository.DeleteCliente(id);
        return RedirectToAction("Index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}