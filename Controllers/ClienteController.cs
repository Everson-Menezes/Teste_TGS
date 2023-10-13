using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Teste_TGS.Models;
using Teste_TGS.ViewModels;


namespace Teste_TGS.Controllers;

public class ClienteController : Controller
{
    private readonly ILogger<ClienteController> _logger;

    public ClienteController(ILogger<ClienteController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        var clientes = new List<Cliente>
        {
            new Cliente { Id = 1, Nome = "Cliente 1", Email = "cliente1@example.com" },
            new Cliente { Id = 2, Nome = "Cliente 2", Email = "cliente2@example.com" },
            new Cliente { Id = 3, Nome = "Cliente 3", Email = "cliente3@example.com" },
            // Adicione mais clientes conforme necessário
        };
        //_context.TB_cliente;
        ICollection<ClienteViewModel> clienteViewModel = new List<ClienteViewModel>();

        foreach (var registro in clientes)
        {
            ClienteViewModel obj = new ClienteViewModel();
            obj.Id = registro.Id;
            obj.Nome = registro.Nome;
            obj.Email = registro.Email;
            obj.Logotipo = registro.Logotipo;
            clienteViewModel.Add(obj);
        }
        return View(clienteViewModel);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}


// using EGGY_TCC_IDENTITY.Data;
// using EGGY_TCC_IDENTITY.Models;
// using EGGY_TCC_IDENTITY.ViewModels;
// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Identity;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.AspNetCore.Mvc.Rendering;
// using Microsoft.EntityFrameworkCore;
// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;

// namespace EGGY_TCC_IDENTITY.Controllers
// {
//     [Authorize(Roles = "Master, Avançado, Básico")]
//     public class clientesController : Controller
//     {
//         private readonly ApplicationDbContext _context;
//         private readonly UserManager<IdentityUser> _userManager;
//         private readonly RoleManager<IdentityRole> _roleManager;
//         private readonly SignInManager<IdentityUser> _signInManager;

//         public clientesController(ApplicationDbContext context, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<IdentityUser> signInManager)
//         {
//             _context = context;
//             _userManager = userManager;
//             _roleManager = roleManager;
//             _signInManager = signInManager;
//         }

//         // GET: clientes
//         public IActionResult Index()
//         {
//             var clientes = _context.TB_cliente;
//             ICollection<clienteViewModel> clienteViewModel = new List<clienteViewModel>();

//             foreach (var registro in clientes)
//             {
//                 clienteViewModel obj = new clienteViewModel();
//                 obj.ID_Usuario = registro.ID_USUARIO_ADM;
//                 obj.ID_cliente = registro.ID_cliente;
//                 obj.CNPJ = registro.DE_CNPJ;
//                 obj.Email = registro.DE_EMAIL;
//                 obj.NomeFantasia = registro.DE_NOME_FANTASIA;
//                 obj.RazaoSocial = registro.DE_RAZAO_SOCIAL;
//                 obj.Representante = registro.DE_REPRESENTANTE;
//                 obj.Telefone = registro.DE_TELEFONE;
//                 clienteViewModel.Add(obj);
//             }
//             return View(clienteViewModel);
//         }
//         public IActionResult Details(int? id)
//         {

//             if (id == null)
//             {
//                 RedirectToAction("Index", "Home");
//             }

//             var cliente = _context.TB_cliente.FirstOrDefault(m => m.ID_cliente == id);

//             if (cliente == null)
//             {
//                 return NotFound();
//             }

//             clienteViewModel clienteViewModel = new clienteViewModel();
//             clienteViewModel.ID_cliente = cliente.ID_cliente;
//             clienteViewModel.ID_Usuario = cliente.ID_USUARIO_ADM;
//             clienteViewModel.NomeFantasia = cliente.DE_NOME_FANTASIA;
//             clienteViewModel.RazaoSocial = cliente.DE_RAZAO_SOCIAL;
//             clienteViewModel.Representante = cliente.DE_REPRESENTANTE;
//             clienteViewModel.Telefone = cliente.DE_TELEFONE;
//             clienteViewModel.Email = cliente.DE_EMAIL;
//             clienteViewModel.CNPJ = cliente.DE_CNPJ;
//             clienteViewModel.UsuarioAdm.DE_LOGIN = cliente.DE_LOGIN_USUARIO_ADM;
//             clienteViewModel.DT_CADASTRO = cliente.DT_CADASTRO;
//             clienteViewModel.DT_ALTERACAO = cliente.DT_ALTERACAO;

//             return View(clienteViewModel);
//         }

//         [AllowAnonymous]
//         // GET: clientes/Create
//         public IActionResult Create()
//         {
//             ViewData["ID_Usuario"] = new SelectList(_context.TB_USUARIO, "ID_Usuario", "UserName");
//             return View();
//         }

//         // POST: clientes/Create
//         // To protect from overposting attacks, enable the specific properties you want to bind to.
//         // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//         [HttpPost]
//         [AllowAnonymous]
//         public async Task<IActionResult> Create(clienteViewModel clienteViewModel)
//         {

//             if (ModelState.IsValid)
//             {
//                 var user = new IdentityUser();

//                 user.UserName = clienteViewModel.UsuarioAdm.DE_LOGIN;
//                 user.Email = clienteViewModel.UsuarioAdm.DE_EMAIL;
//                 user.PasswordHash = clienteViewModel.UsuarioAdm.DE_SENHA;
//                 // Armazena os dados do usuário na tabela AspNetUsers
//                 var resultado = await _userManager.CreateAsync(user, user.PasswordHash);

//                 if (resultado.Succeeded)
//                 {
//                     var role = await _roleManager.FindByIdAsync("c89dd03e-3405-4a74-ac9a-e4817bee4119");
//                     await _userManager.AddToRoleAsync(user, role.Name);
//                     TB_cliente cliente = new TB_cliente();
//                     TB_USUARIO usuario = new TB_USUARIO();
//                     TB_APOIADOR apoiador = new TB_APOIADOR();
//                     TB_cliente_APOIADOR clienteApoiador = new TB_cliente_APOIADOR();

//                     cliente.DE_REPRESENTANTE = clienteViewModel.Representante;
//                     cliente.DE_EMAIL = clienteViewModel.Email;
//                     cliente.DE_TELEFONE = clienteViewModel.Telefone;
//                     cliente.DE_CNPJ = clienteViewModel.CNPJ;
//                     cliente.DE_RAZAO_SOCIAL = clienteViewModel.RazaoSocial;
//                     cliente.DE_NOME_FANTASIA = clienteViewModel.NomeFantasia;
//                     cliente.DT_CADASTRO = DateTime.Now;
//                     cliente.DT_ALTERACAO = DateTime.Now;
//                     cliente.DT_INATIVACAO = null;
//                     cliente.ID_STATUS = 1;
//                     usuario.DE_SENHA = clienteViewModel.UsuarioAdm.DE_SENHA;
//                     cliente.DE_LOGIN_USUARIO_ADM = usuario.DE_LOGIN = clienteViewModel.UsuarioAdm.DE_LOGIN;
//                     apoiador.DE_NOME = usuario.DE_NOME = clienteViewModel.UsuarioAdm.DE_NOME;
//                     apoiador.DE_EMAIL = usuario.DE_EMAIL = clienteViewModel.UsuarioAdm.DE_EMAIL;
//                     apoiador.DT_CADASTRO = usuario.DT_CADASTRO = DateTime.Now;
//                     apoiador.DT_ALTERACAO = usuario.DT_ALTERACAO = DateTime.Now;
//                     apoiador.DT_INATIVACAO = usuario.DT_INATIVACAO = null;
//                     usuario.ID_STATUS = 1;
//                     apoiador.BL_RECEBE_NOVIDADE = clienteViewModel.BL_RECEBE_NOVIDADE;
//                     _context.Add(usuario);
//                     _context.Add(apoiador);
//                     await _context.SaveChangesAsync();
//                     cliente.ID_USUARIO_ADM = apoiador.ID_USUARIO = usuario.ID_USUARIO;
//                     usuario.ID_APOIADOR = apoiador.ID_APOIADOR;
//                     _context.Add(cliente);
//                     _context.Update(usuario);
//                     _context.Update(apoiador);
//                     await _context.SaveChangesAsync();
//                     clienteApoiador.ID_cliente = cliente.ID_cliente;
//                     clienteApoiador.ID_APOIADOR = apoiador.ID_APOIADOR;
//                     _context.Add(clienteApoiador);
//                     await _context.SaveChangesAsync();
//                     await _signInManager.SignInAsync(user, isPersistent: false);
//                     return RedirectToAction("Index", "Home");
//                 }

//             }
//             return View(clienteViewModel);
//         }
//         [Authorize(Roles = "Master, Avançado")]
//         public async Task<IActionResult> Edit(int? id)
//         {
//             var usuarioLogado = User.Identity.Name;
//             int idUsuario = _context.TB_USUARIO.Where(x => x.DE_LOGIN.Equals(usuarioLogado)).Select(x => x.ID_USUARIO).FirstOrDefault();
//             List<int> listaclientes = _context.TB_cliente.Where(x => x.ID_USUARIO_ADM == idUsuario).Select(x => x.ID_cliente).Distinct().ToList();
//             if (id == null)
//             {
//                 return NotFound();
//             }

//             var cliente = await _context.TB_cliente.FindAsync(id);

//             if (cliente == null)
//             {
//                 return NotFound();
//             }
//             clienteViewModel clienteViewModel = new clienteViewModel();
//             if (listaclientes.Contains(cliente.ID_cliente) || User.IsInRole("Master"))
//             {
//                 clienteViewModel.ID_cliente = cliente.ID_cliente;
//                 clienteViewModel.Representante = cliente.DE_REPRESENTANTE;
//                 clienteViewModel.UsuarioAdm.DE_LOGIN = cliente.DE_LOGIN_USUARIO_ADM;
//                 clienteViewModel.Email = cliente.DE_EMAIL;
//                 clienteViewModel.Telefone = cliente.DE_TELEFONE;
//                 clienteViewModel.CNPJ = cliente.DE_CNPJ;
//                 clienteViewModel.RazaoSocial = cliente.DE_RAZAO_SOCIAL;
//                 clienteViewModel.NomeFantasia = cliente.DE_NOME_FANTASIA;
//                 clienteViewModel.ID_Usuario = cliente.ID_USUARIO_ADM;
//                 clienteViewModel.ID_Status = cliente.ID_STATUS;
//                 clienteViewModel.DT_CADASTRO = cliente.DT_CADASTRO;
//                 clienteViewModel.DT_ALTERACAO = cliente.DT_ALTERACAO;
//                 return View(clienteViewModel);
//             }
//             return RedirectToAction("Index", "Home");
//         }

//         // POST: clientes/Edit/5
//         // To protect from overposting attacks, enable the specific properties you want to bind to.
//         // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//         [HttpPost]
//         [Authorize(Roles = "Master, Avançado")]
//         public async Task<IActionResult> Edit(int id, clienteViewModel clienteViewModel)
//         {
//             var usuarioLogado = User.Identity.Name;
//             int idUsuario = _context.TB_USUARIO.Where(x => x.DE_LOGIN.Equals(usuarioLogado)).Select(x => x.ID_USUARIO).FirstOrDefault();
//             List<int> listaclientes = _context.TB_cliente.Where(x => x.ID_USUARIO_ADM == idUsuario).Select(x => x.ID_cliente).Distinct().ToList();
//             if (id != clienteViewModel.ID_cliente)
//             {
//                 return NotFound();
//             }

//             if (ModelState.IsValid)
//             {
//                 if (listaclientes.Contains(id) || User.IsInRole("Master"))
//                 {
//                     TB_cliente cliente = new TB_cliente();
//                     cliente.ID_cliente = clienteViewModel.ID_cliente;
//                     cliente.DE_REPRESENTANTE = clienteViewModel.Representante;
//                     cliente.DE_EMAIL = clienteViewModel.Email;
//                     cliente.DE_TELEFONE = clienteViewModel.Telefone;
//                     cliente.DE_CNPJ = clienteViewModel.CNPJ;
//                     cliente.DE_RAZAO_SOCIAL = clienteViewModel.RazaoSocial;
//                     cliente.DE_NOME_FANTASIA = clienteViewModel.NomeFantasia;
//                     cliente.ID_STATUS = clienteViewModel.ID_Status;
//                     cliente.ID_USUARIO_ADM = clienteViewModel.ID_Usuario;
//                     cliente.DE_LOGIN_USUARIO_ADM = clienteViewModel.UsuarioAdm.DE_LOGIN;
//                     cliente.DT_CADASTRO = clienteViewModel.DT_CADASTRO;
//                     cliente.DT_ALTERACAO = DateTime.Now;

//                     try
//                     {
//                         _context.Update(cliente);
//                         await _context.SaveChangesAsync();
//                     }
//                     catch (DbUpdateConcurrencyException)
//                     {
//                         if (!clienteExists(cliente.ID_cliente))
//                         {
//                             return NotFound();
//                         }
//                         else
//                         {
//                             throw;
//                         }
//                     }
//                     return RedirectToAction(nameof(Index));
//                 }
//             }
//             return View(clienteViewModel);
//         }
//         [Authorize(Roles = "Master")]
//         public async Task<IActionResult> Delete(int? id)
//         {
//             if (id == null)
//             {
//                 return NotFound();
//             }

//             var cliente = await _context.TB_cliente.FirstOrDefaultAsync(m => m.ID_cliente == id);
//             if (cliente == null)
//             {
//                 return NotFound();
//             }
//             clienteViewModel clienteViewModel = new clienteViewModel();
//             clienteViewModel.ID_cliente = cliente.ID_cliente;
//             clienteViewModel.Representante = cliente.DE_REPRESENTANTE;
//             clienteViewModel.UsuarioAdm.DE_LOGIN = cliente.DE_LOGIN_USUARIO_ADM;
//             clienteViewModel.Email = cliente.DE_EMAIL;
//             clienteViewModel.Telefone = cliente.DE_TELEFONE;
//             clienteViewModel.CNPJ = cliente.DE_CNPJ;
//             clienteViewModel.RazaoSocial = cliente.DE_RAZAO_SOCIAL;
//             clienteViewModel.NomeFantasia = cliente.DE_NOME_FANTASIA;
//             clienteViewModel.ID_Usuario = cliente.ID_USUARIO_ADM;
//             clienteViewModel.ID_Status = cliente.ID_STATUS;
//             clienteViewModel.DT_CADASTRO = cliente.DT_CADASTRO;
//             clienteViewModel.DT_ALTERACAO = cliente.DT_ALTERACAO;
//             return View(clienteViewModel);
//         }
//         [Authorize(Roles = "Master")]
//         [HttpPost, ActionName("Delete")]
//         [ValidateAntiForgeryToken]
//         public async Task<IActionResult> DeleteConfirmed(int id)
//         {
//             var cliente = await _context.TB_cliente.FindAsync(id);
//             _context.TB_cliente.Remove(cliente);
//             await _context.SaveChangesAsync();
//             return RedirectToAction(nameof(Index));
//         }

//         private bool clienteExists(int id)
//         {
//             return _context.TB_cliente.Any(e => e.ID_cliente == id);
//         }
//     }
// }