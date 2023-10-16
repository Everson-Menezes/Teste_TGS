// using System.Diagnostics;
// using Microsoft.AspNetCore.Mvc;
// using Teste_TGS.Interfaces;
// using Teste_TGS.Models;
// using Teste_TGS.ViewModels;

// namespace Teste_TGS.Controllers;

// public class LogradouroController : Controller
// {
//     private readonly ILogger<LogradouroController> _logger;
//     private readonly ILogradouroRepository _logradouroRepository;

//     public LogradouroController(ILogger<LogradouroController> logger, ILogradouroRepository logradouroRepository)
//     {
//         _logger = logger;
//         _logradouroRepository = logradouroRepository;
//     }

//     public IActionResult Index()
//     {
//         return RedirectToAction("Index", "Cliente");
//     }
//     public IActionResult Create(int Id)
//     {
//         LogradouroViewModel logradouroViewModel = new LogradouroViewModel
//         {
//             ClienteId = Id
//         };
//         return View(logradouroViewModel);
//     }

//     [HttpPost]
//     public IActionResult Cadastrar(LogradouroViewModel logradouroViewModel)
//     {

//         Logradouro logradouro = new Logradouro();
//         logradouro.Rua = logradouroViewModel.Rua;
//         logradouro.Bairro = logradouroViewModel.Bairro;
//         logradouro.Cidade = logradouroViewModel.Cidade;
//         logradouro.Estado = logradouroViewModel.Estado;
//         logradouro.Pais = logradouroViewModel.Pais;
//         logradouro.Cep = logradouroViewModel.Cep;
//         logradouro.ClienteId = logradouroViewModel.ClienteId;

//         _logradouroRepository.CreateLogradouro(logradouro);
//         return RedirectToAction("Details", "Cliente", new { id = logradouro.ClienteId });
//     }
//     public IActionResult Edit(int id, int clienteId)
//     {
//         var logradouro = _logradouroRepository.GetLogradouroById(id, clienteId);
//         if (logradouro == null)
//         {
//             return NotFound();
//         }
//         LogradouroViewModel obj = new LogradouroViewModel();

//         obj.Id = logradouro.Id;
//         obj.Rua = logradouro.Rua;
//         obj.Bairro = logradouro.Bairro;
//         obj.Cidade = logradouro.Cidade;
//         obj.Estado = logradouro.Estado;
//         obj.Pais = logradouro.Pais;
//         obj.Cep = logradouro.Cep;
//         obj.ClienteId = logradouro.ClienteId;

//         return View(obj);
//     }
//     [HttpPost]
//     public IActionResult Edit(LogradouroViewModel logradouroViewModel)
//     {

//         Logradouro logradouro = new Logradouro();

//         logradouro.Id = logradouroViewModel.Id;
//         logradouro.Rua = logradouroViewModel.Rua;
//         logradouro.Bairro = logradouroViewModel.Bairro;
//         logradouro.Cidade = logradouroViewModel.Cidade;
//         logradouro.Estado = logradouroViewModel.Estado;
//         logradouro.Pais = logradouroViewModel.Pais;
//         logradouro.Cep = logradouroViewModel.Cep.Replace(".", "").Replace("-", "");
//         logradouro.ClienteId = logradouroViewModel.ClienteId;
//         _logradouroRepository.UpdateLogradouro(logradouro);

//         return RedirectToAction("Details", "Cliente", new { id = logradouro.ClienteId });
//     }
//     public IActionResult Delete(int id, int clienteId)
//     {
//         var logradouro = _logradouroRepository.GetLogradouroById(id, clienteId);
//         if (logradouro == null)
//         {
//             return NotFound();
//         }
//         LogradouroViewModel obj = new LogradouroViewModel();

//         obj.Id = logradouro.Id;
//         obj.Rua = logradouro.Rua;
//         obj.Bairro = logradouro.Bairro;
//         obj.Cidade = logradouro.Cidade;
//         obj.Estado = logradouro.Estado;
//         obj.Pais = logradouro.Pais;
//         obj.Cep = logradouro.Cep;
//         obj.ClienteId = logradouro.ClienteId;

//         return View(obj);
//     }

//     [HttpPost, ActionName("Delete")]
//     public IActionResult DeleteConfirmed(int id)
//     {
//         _logradouroRepository.DeleteLogradouro(id);
//         return RedirectToAction("Index");
//     }
//     [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
//     public IActionResult Error()
//     {
//         return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
//     }
// }