using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Teste_TGS.Interfaces;
using Teste_TGS.Models;
using Teste_TGS.ViewModels;

namespace Teste_TGS.Controllers;

public class LogradouroController : Controller
{
    private readonly ILogger<LogradouroController> _logger;
    private readonly IConfiguration _iConfiguration;
    private readonly string _baseUrl;
    private readonly IHttpClientFactory _clientFactory;
    public LogradouroController(ILogger<LogradouroController> logger, IConfiguration iConfiguration, IHttpClientFactory iClientFactory)
    {
        _logger = logger;
        _iConfiguration = iConfiguration;
        _baseUrl = _iConfiguration.GetSection("ApiSettings")["BaseUrl"];
        _clientFactory = iClientFactory;
    }

    public IActionResult Create(int Id)
    {
        LogradouroViewModel logradouroViewModel = new LogradouroViewModel
        {
            ClienteId = Id
        };
        return View(logradouroViewModel);
    }

    [HttpPost, ActionName("Cadastrar")]
    public async Task<IActionResult> CadastrarAsync(LogradouroViewModel logradouroViewModel)
    {

        Logradouro logradouro = new Logradouro();
        logradouro.Rua = logradouroViewModel.Rua;
        logradouro.Bairro = logradouroViewModel.Bairro;
        logradouro.Cidade = logradouroViewModel.Cidade;
        logradouro.Estado = logradouroViewModel.Estado;
        logradouro.Pais = logradouroViewModel.Pais;
        logradouro.Cep = logradouroViewModel.Cep;
        logradouro.ClienteId = logradouroViewModel.ClienteId;

        var logradouroJson = JsonConvert.SerializeObject(logradouro);
        var data = new StringContent(logradouroJson, System.Text.Encoding.UTF8, "application/json");

        var client = _clientFactory.CreateClient("localhost");

        var response = await client.PostAsync($"{_baseUrl}logradouro/create", data);
        response.EnsureSuccessStatusCode();
        return RedirectToAction("Details", "Cliente", new { id = logradouro.ClienteId });
    }
    [HttpGet, ActionName("Edit")]
    public async Task<IActionResult> EditAsync(int id, int clienteId)
    {
        var client = _clientFactory.CreateClient("localhost");

        var response = await client.GetAsync($"{_baseUrl}logradouro/get/{id}/{clienteId}");
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();

        Logradouro logradouro = JsonConvert.DeserializeObject<Logradouro>(content);
        if (logradouro == null)
        {
            return NotFound();
        }
        LogradouroViewModel obj = new LogradouroViewModel();

        obj.Id = logradouro.Id;
        obj.Rua = logradouro.Rua;
        obj.Bairro = logradouro.Bairro;
        obj.Cidade = logradouro.Cidade;
        obj.Estado = logradouro.Estado;
        obj.Pais = logradouro.Pais;
        obj.Cep = logradouro.Cep;
        obj.ClienteId = logradouro.ClienteId;

        return View(obj);
    }
    [HttpPost]
    public async Task<IActionResult> EditAsync(LogradouroViewModel logradouroViewModel)
    {

        Logradouro logradouro = new Logradouro();

        logradouro.Id = logradouroViewModel.Id;
        logradouro.Rua = logradouroViewModel.Rua;
        logradouro.Bairro = logradouroViewModel.Bairro;
        logradouro.Cidade = logradouroViewModel.Cidade;
        logradouro.Estado = logradouroViewModel.Estado;
        logradouro.Pais = logradouroViewModel.Pais;
        logradouro.Cep = logradouroViewModel.Cep.Replace(".", "").Replace("-", "");
        logradouro.ClienteId = logradouroViewModel.ClienteId;

        var logradouroJson = JsonConvert.SerializeObject(logradouro);
        var data = new StringContent(logradouroJson, System.Text.Encoding.UTF8, "application/json");
        var client = _clientFactory.CreateClient("localhost");
        var response = await client.PutAsync($"{_baseUrl}logradouro/edit/", data);
        response.EnsureSuccessStatusCode();

        return RedirectToAction("Details", "Cliente", new { id = logradouro.ClienteId });
    }
    public async Task<IActionResult> DeleteAsync(int id, int clienteId)
    {
        var client = _clientFactory.CreateClient("localhost");

        var response = await client.GetAsync($"{_baseUrl}logradouro/get/{id}/{clienteId}");
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();

        Logradouro logradouro = JsonConvert.DeserializeObject<Logradouro>(content);

        if (logradouro == null)
        {
            return NotFound();
        }
        LogradouroViewModel obj = new LogradouroViewModel();

        obj.Id = logradouro.Id;
        obj.Rua = logradouro.Rua;
        obj.Bairro = logradouro.Bairro;
        obj.Cidade = logradouro.Cidade;
        obj.Estado = logradouro.Estado;
        obj.Pais = logradouro.Pais;
        obj.Cep = logradouro.Cep;
        obj.ClienteId = logradouro.ClienteId;

        return View(obj);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmedAsync(int id)
    {
        var client = _clientFactory.CreateClient("localhost");

        var response = await client.DeleteAsync($"{_baseUrl}logradouro/delete/{id}");
        response.EnsureSuccessStatusCode();
        return RedirectToAction("Index", "Cliente");
    }
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}