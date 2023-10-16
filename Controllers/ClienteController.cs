using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Teste_TGS.Interfaces;
using Teste_TGS.Models;
using Teste_TGS.ViewModels;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Teste_TGS.Controllers;

public class ClienteController : Controller
{
    private readonly ILogger<ClienteController> _logger;
    private readonly IConfiguration _iConfiguration;
    private readonly string _baseUrl;
    private readonly IHttpClientFactory _clientFactory;
    public ClienteController(ILogger<ClienteController> logger, IConfiguration iConfiguration, IHttpClientFactory iClientFactory)
    {
        _iConfiguration = iConfiguration;
        _baseUrl = _iConfiguration.GetSection("ApiSettings")["BaseUrl"];
        _logger = logger;
        _clientFactory = iClientFactory;
    }

    public async Task<IActionResult> IndexAsync()
    {
        var client = _clientFactory.CreateClient("localhost");
        var response = await client.GetAsync($"{_baseUrl}cliente");
        // var response = await _httpClient.GetAsync($"{_baseUrl}");
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();

        List<Cliente> clientes = JsonConvert.DeserializeObject<List<Cliente>>(content);

        ICollection<ClienteViewModel> clienteViewModel = new List<ClienteViewModel>();

        foreach (var cliente in clientes)
        {
            ClienteViewModel obj = new ClienteViewModel();
            obj.Id = cliente.Id;
            obj.Nome = cliente.Nome;
            obj.Email = cliente.Email;
            obj.Logotipo = new LogoTipoViewModel();
            obj.Logotipo.imagemString = ConverterArquivoByteArrayEmBase64(cliente.LogoTipo);
            clienteViewModel.Add(obj);
        }
        return View(clienteViewModel);
    }


    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(ClienteViewModel clienteViewModel)
    {

        Cliente cliente = new Cliente();
        cliente.Email = clienteViewModel.Email;
        cliente.Nome = clienteViewModel.Nome;
        cliente.LogoTipo = ConverteArquivo(clienteViewModel.Logotipo.Arquivo);

        var clienteJson = JsonConvert.SerializeObject(cliente);
        var data = new StringContent(clienteJson, System.Text.Encoding.UTF8, "application/json");

        var client = _clientFactory.CreateClient("localhost");

        var response = await client.PostAsync($"{_baseUrl}cliente/Create", data);
        response.EnsureSuccessStatusCode();

        return RedirectToAction("Create", "Logradouro", new { Id = cliente.Id });
    }
    public async Task<IActionResult> DetailsAsync(int id)
    {

        if (id == 0)
        {
            RedirectToAction("Index", "Cliente");
        }

        var client = _clientFactory.CreateClient("localhost");

        var response = await client.GetAsync($"{_baseUrl}cliente/getById/{id}");

        var content = await response.Content.ReadAsStringAsync();

        Cliente cliente = JsonConvert.DeserializeObject<Cliente>(content);
        if (cliente == null)
        {
            return NotFound();
        }

        ClienteViewModel obj = new ClienteViewModel();

        obj.Id = cliente.Id;
        obj.Nome = cliente.Nome;
        obj.Email = cliente.Email;
        obj.Logotipo = new LogoTipoViewModel();
        obj.Logotipo.imagemString = ConverterArquivoByteArrayEmBase64(cliente.LogoTipo);
        obj.Logradouros = new List<LogradouroViewModel>();
        foreach (var item in cliente.logradouros)
        {
            LogradouroViewModel logradouroViewModel = new LogradouroViewModel
            {
                Id = item.Id,
                Rua = item.Rua,
                Bairro = item.Bairro,
                Cidade = item.Cidade,
                Estado = item.Estado,
                Pais = item.Pais,
                Cep = item.Cep,
                ClienteId = item.ClienteId
            };
            obj.Logradouros.Add(logradouroViewModel);
        }


        return View(obj);
    }

    public async Task<IActionResult> EditAsync(int id)
    {
        if (id == 0)
        {
            RedirectToAction("Index", "Cliente");
        }

        var client = _clientFactory.CreateClient("localhost");

        var response = await client.GetAsync($"{_baseUrl}cliente/getById/{id}");

        var content = await response.Content.ReadAsStringAsync();

        Cliente cliente = JsonConvert.DeserializeObject<Cliente>(content);
        if (cliente == null)
        {
            return NotFound();
        }

        ClienteViewModel obj = new ClienteViewModel();

        obj.Id = cliente.Id;
        obj.Nome = cliente.Nome;
        obj.Email = cliente.Email;
        obj.Logotipo = new LogoTipoViewModel();
        obj.Logotipo.imagemString = ConverterArquivoByteArrayEmBase64(cliente.LogoTipo);
        obj.Logradouros = new List<LogradouroViewModel>();
        foreach (var item in cliente.logradouros)
        {
            LogradouroViewModel logradouroViewModel = new LogradouroViewModel
            {
                Id = item.Id,
                Rua = item.Rua,
                Bairro = item.Bairro,
                Cidade = item.Cidade,
                Estado = item.Estado,
                Pais = item.Pais,
                Cep = item.Cep,
                ClienteId = item.ClienteId
            };
            obj.Logradouros.Add(logradouroViewModel);
        }


        return View(obj);
    }

    [HttpPost]
    public async Task<IActionResult> EditAsync(ClienteViewModel clienteViewModel)
    {

        Cliente cliente = new Cliente();
        cliente.Id = clienteViewModel.Id;
        cliente.Email = clienteViewModel.Email;
        cliente.Nome = clienteViewModel.Nome;
        cliente.LogoTipo = ConverteArquivo(clienteViewModel.Logotipo.Arquivo);

        var client = _clientFactory.CreateClient("localhost");
        var clienteJson = JsonConvert.SerializeObject(cliente);
        var data = new StringContent(clienteJson, System.Text.Encoding.UTF8, "application/json");

        var response = await client.PutAsync($"{_baseUrl}cliente/edit", data);
        response.EnsureSuccessStatusCode();

        return RedirectToAction("Index");

    }
    public async Task<IActionResult> DeleteAsync(int id)
    {
        if (id == 0)
        {
            RedirectToAction("Index", "Cliente");
        }

        var client = _clientFactory.CreateClient("localhost");

        var response = await client.GetAsync($"{_baseUrl}cliente/getById/{id}");

        var content = await response.Content.ReadAsStringAsync();

        Cliente cliente = JsonConvert.DeserializeObject<Cliente>(content);
        if (cliente == null)
        {
            return NotFound();
        }

        ClienteViewModel obj = new ClienteViewModel();

        obj.Id = cliente.Id;
        obj.Nome = cliente.Nome;
        obj.Email = cliente.Email;
        obj.Logotipo = new LogoTipoViewModel();
        obj.Logotipo.imagemString = ConverterArquivoByteArrayEmBase64(cliente.LogoTipo);



        return View(obj);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmedAsync(int id)
    {
        var client = _clientFactory.CreateClient("localhost");

        var response = await client.DeleteAsync($"{_baseUrl}cliente/delete/{id}");
        response.EnsureSuccessStatusCode();
        return RedirectToAction("Index");
    }

    protected string ConverterArquivoByteArrayEmBase64(byte[] arq)
    {
        try
        {
            return "data:application/pdf;base64," + Convert.ToBase64String(arq);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected byte[] ConverteArquivo(IFormFile arq)
    {
        byte[]? result = null;
        if (arq.Length > 0)
        {
            //Leitura dos binarios
            using (BinaryReader br = new BinaryReader(arq.OpenReadStream()))
            {
                // Converte o arquivo em bytes
                return br.ReadBytes((int)arq.OpenReadStream().Length);
            }
        }
        else
        {
            return result;
        }
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}