using CadastroDeClientes.Models;
using CadastroDeClientes.Repository;
using CadastroDeClientes.ViewModels;
using DER.WebApp.Common.Helper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace CadastroDeClientes.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IClienteRepository _clienteRepository;
        public ClienteController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }
        public IActionResult Index()
        {
            List<ClienteModel> clientes = _clienteRepository.BuscarTodos();

            var cidades = new CidadeItens().RetornaCidades();
            var estados = new EstadoItens().RetornaEstados();
            var sexos = new SexoItens().RetornaSexo();

            foreach (var item in clientes)
            {
                item.NomeCidade = cidades.FirstOrDefault(x => x.Id == item.IdCidade).Nome;
                item.SiglaUF = estados.FirstOrDefault(x => x.Id == item.IdEstado).UF;
            }

            return View(clientes);
        }

        public IActionResult Criar()
        {
            ViewData["Cidades"] = new CidadeItens().RetornaCidades().Select(x => new { Text = x.Nome, Value = x.Id });
            ViewData["Estados"] = new EstadoItens().RetornaEstados().Select(x => new { Text = x.UF, Value = x.Id });

            return View();
        }

        public IActionResult Editar(int id)
        {
            ClienteModel cliente = _clienteRepository.ListarId(id);
            ViewData["Cidades"] = new CidadeItens().RetornaCidades().Select(x => new { Text = x.Nome, Value = x.Id });
            ViewData["Estados"] = new EstadoItens().RetornaEstados().Select(x => new { Text = x.UF, Value = x.Id });

            return View(cliente);
        }

        public IActionResult ApagarConfirmacao(int id)
        {
            ClienteModel cliente = _clienteRepository.ListarId(id);
            return View(cliente);
        }
        public IActionResult Apagar(int id)
        {
            try
            {
                bool apagado = _clienteRepository.Apagar(id);

                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Cliente Apagado com sucesso!";
                }
                else
                {
                    TempData["MensagemErro"] = "Ops, não conseguimos apagar o cliente!";
                }

                return RedirectToAction("Index");
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos apagar o cliente, tente novamente, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Criar(ClienteModel cliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (!CPF.Validar(cliente.CPF))
                    {
                        return Json(new ClienteValidatorViewModel() { validCPF = false });
                    }
                    _clienteRepository.Adicionar(cliente);
                    TempData["MensagemSucesso"] = "Cliente cadastrado com sucesso";
                    return RedirectToAction("Index");
                }
                ViewData["Cidades"] = new CidadeItens().RetornaCidades().Select(x => new { Text = x.Nome, Value = x.Id });
                ViewData["Estados"] = new EstadoItens().RetornaEstados().Select(x => new { Text = x.UF, Value = x.Id });

                return View(cliente);
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos cadastrar o cliente, tente novamente, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Alterar(ClienteModel cliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _clienteRepository.Atualizar(cliente);
                    TempData["MensagemSucesso"] = "Cliente alterado com sucesso!";
                    return RedirectToAction("Index");
                }
                ViewData["Cidades"] = new CidadeItens().RetornaCidades().Select(x => new { Text = x.Nome, Value = x.Id });
                ViewData["Estados"] = new EstadoItens().RetornaEstados().Select(x => new { Text = x.UF, Value = x.Id });

                return View("Editar", cliente);
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos alterar o cliente, tente novamente, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
