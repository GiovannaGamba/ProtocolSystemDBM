using Microsoft.AspNetCore.Mvc;
using ProtocolSystemDBM.Models;
using ProtocolSystemDBM.Services.Interfaces;
using ProtocolSystemDBM.ViewModels.ProtocolStatuses;

namespace ProtocolSystemDBM.Controllers
{
    public class ProtocolStatusController : Controller
    {
        private readonly IProtocolStatusService _protocolStatusService;

        public ProtocolStatusController(IProtocolStatusService protocolStatusService)
        {
            _protocolStatusService = protocolStatusService;
        }

        public async Task<IActionResult> Index()
        {
            ListProtocolStatusesViewModel protocolStatusesViewModel = new ListProtocolStatusesViewModel
            {
                ProtocolStatuses = await _protocolStatusService.GetProtocolStatusesAsync()
            };

            return View(protocolStatusesViewModel);
        }

        public IActionResult Create()
        {
            return View(new RegisterProtocolStatusViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(RegisterProtocolStatusViewModel createProtocolStatusViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ArgumentException("Erro ao cadastrar status do protocolo");
                }

                ProtocolStatus protocolStatus = new ProtocolStatus(createProtocolStatusViewModel.Name);
                await _protocolStatusService.CreateProtocolStatusAsync(protocolStatus);
                return RedirectToAction(nameof(Index));
            }
            catch (ArgumentException exception)
            {
                ModelState.AddModelError(string.Empty, exception.Message);
                return View(createProtocolStatusViewModel);
            }
            catch
            {
                ModelState.AddModelError(string.Empty, "Erro durante o processamento");
                return View(createProtocolStatusViewModel);
            }
        }

        public async Task<IActionResult> Update(Guid id)
        {
            ProtocolStatus protocolStatus = await _protocolStatusService.GetProtocolStatusByIdAsync(id);
            if (protocolStatus == null)
            {
                return NotFound();
            }

            UpdateProtocolStatusViewModel updateViewModel = new UpdateProtocolStatusViewModel
            {
                Id = protocolStatus.Id,
                Name = protocolStatus.Name,
                Deleted = protocolStatus.Deleted
            };

            return View(updateViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateProtocolStatusViewModel updateProtocolStatusViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ArgumentException("Erro ao atualizar status do protocolo");
                }

                ProtocolStatus protocolStatus = new ProtocolStatus(updateProtocolStatusViewModel.Name)
                {
                    Id = updateProtocolStatusViewModel.Id,
                    Deleted = updateProtocolStatusViewModel.Deleted
                };
                await _protocolStatusService.UpdateProtocolStatusAsync(protocolStatus);
                return RedirectToAction(nameof(Index));
            }
            catch (ArgumentException exception)
            {
                ModelState.AddModelError(string.Empty, exception.Message);
                return View(updateProtocolStatusViewModel);
            }
            catch
            {
                ModelState.AddModelError(string.Empty, "Erro durante o processamento");
                return View(updateProtocolStatusViewModel);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _protocolStatusService.DeleteProtocolStatusAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError(string.Empty, "Erro ao excluir status do protocolo");
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
