using Microsoft.AspNetCore.Mvc;
using ProtocolSystemDBM.Models;
using ProtocolSystemDBM.Services.Interfaces;
using ProtocolSystemDBM.ViewModels.Protocols;

namespace ProtocolSystemDBM.Controllers
{
    public class ProtocolController : Controller
    {
        private readonly IProtocolService _protocolService;
        private readonly IProtocolStatusService _protocolStatusService;
        private readonly IUserService _userService;

        public ProtocolController(IProtocolService protocolService, IProtocolStatusService protocolStatusService, IUserService userService)
        {
            _protocolService = protocolService;
            _protocolStatusService = protocolStatusService;
            _userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            ListProtocolsViewModel protocolsViewModel = new ListProtocolsViewModel
            {
                Protocols = await _protocolService.GetProtocolsAsync()
            };

            return View(protocolsViewModel);
        }

        public async Task<IActionResult> Create()
        {
            RegisterProtocolViewModel registerProtocolViewModel = new RegisterProtocolViewModel
            {
                Users = await _userService.GetUsersAsync(),
                ProtocolStatuses = await _protocolStatusService.GetProtocolStatusesAsync()
            };

            return View(registerProtocolViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(RegisterProtocolViewModel registerProtocolViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    registerProtocolViewModel.Users = await _userService.GetUsersAsync();
                    registerProtocolViewModel.ProtocolStatuses = await _protocolStatusService.GetProtocolStatusesAsync();

                    throw new ArgumentException("Erro ao cadastrar protocolo");
                }

                await _protocolService.CreateProtocolAsync(registerProtocolViewModel.FromViewModelToEntity());
                return RedirectToAction(nameof(Index));
            }
            catch (ArgumentException exception)
            {
                ModelState.AddModelError(string.Empty, exception.Message);
                return View(registerProtocolViewModel);
            }
            catch
            {
                ModelState.AddModelError(string.Empty, "Erro durante o processamento");
                return View(registerProtocolViewModel);
            }
        }

        public async Task<IActionResult> Update(Guid id)
        {
            Protocol protocol = await _protocolService.GetProtocolByIdAsync(id);
            List<User> users = await _userService.GetUsersAsync();
            List<ProtocolStatus> protocolStatuses = await _protocolStatusService.GetProtocolStatusesAsync();

            return View(UpdateProtocolViewModel.FromEntityToViewModel(protocol, users, protocolStatuses));
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateProtocolViewModel updateProtocolViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    updateProtocolViewModel.Users = await _userService.GetUsersAsync();
                    updateProtocolViewModel.ProtocolStatuses = await _protocolStatusService.GetProtocolStatusesAsync();

                    throw new ArgumentException("Erro ao atualizar protocolo");
                }

                await _protocolService.UpdateProtocolAsync(updateProtocolViewModel.FromViewModelToEntity());
                return RedirectToAction(nameof(Index));
            }
            catch (ArgumentException exception)
            {
                ModelState.AddModelError(string.Empty, exception.Message);
                return View(updateProtocolViewModel);
            }
            catch
            {
                ModelState.AddModelError(string.Empty, "Erro durante o processamento");
                return View(updateProtocolViewModel);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _protocolService.DeleteProtocolAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError(string.Empty, "Erro ao excluir protocolo");
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
