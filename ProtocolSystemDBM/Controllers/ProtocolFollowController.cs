using Microsoft.AspNetCore.Mvc;
using ProtocolSystemDBM.Models;
using ProtocolSystemDBM.Services.Interfaces;
using ProtocolSystemDBM.ViewModels.ProtocolFollows;

namespace ProtocolSystemDBM.Controllers
{
    public class ProtocolFollowController : Controller
    {
        private readonly IProtocolFollowService _protocolFollowService;

        public ProtocolFollowController(IProtocolFollowService protocolFollowService)
        {
            _protocolFollowService = protocolFollowService;
        }

        public async Task<IActionResult> List(Guid id)
        {
            ListProtocolFollowsViewModel protocolFollowsViewModel = new ListProtocolFollowsViewModel
            {
                Id = id,
                ProtocolFollows = await _protocolFollowService.GetProtocolFollowsByProtocolIdAsync(id)
            };

            return View(protocolFollowsViewModel);
        }

        public IActionResult Create(Guid id)
        {
            RegisterProtocolFollowViewModel registerProtocolFollowViewModel = new RegisterProtocolFollowViewModel { ProtocolId = id };
            return View(registerProtocolFollowViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(RegisterProtocolFollowViewModel registerProtocolFollowViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ArgumentException("Erro ao cadastrar acompanhamento de protocolo");
                }

                await _protocolFollowService.CreateProtocolFollowAsync(registerProtocolFollowViewModel.FromViewModelToEntity());
                return RedirectToAction(nameof(List), new { id = registerProtocolFollowViewModel.ProtocolId });
            }
            catch (ArgumentException exception)
            {
                ModelState.AddModelError(string.Empty, exception.Message);
                return View(registerProtocolFollowViewModel);
            }
            catch
            {
                ModelState.AddModelError(string.Empty, "Erro durante o processamento");
                return View(registerProtocolFollowViewModel);
            }
        }

        public async Task<IActionResult> Update(Guid id)
        {
            ProtocolFollow protocolFollow = await _protocolFollowService.GetProtocolFollowByIdAsync(id);
            return View(UpdateProtocolFollowViewModel.FromEntityToViewModel(protocolFollow));
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateProtocolFollowViewModel updateProtocolFollowViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ArgumentException("Erro ao atualizar acompanhamento de protocolo");
                }

                await _protocolFollowService.UpdateProtocolFollowAsync(updateProtocolFollowViewModel.FromViewModelToEntity());
                return RedirectToAction(nameof(List), new { id = updateProtocolFollowViewModel.ProtocolId });
            }
            catch (ArgumentException exception)
            {
                ModelState.AddModelError(string.Empty, exception.Message);
                return View(updateProtocolFollowViewModel);
            }
            catch
            {
                ModelState.AddModelError(string.Empty, "Erro durante o processamento");
                return View(updateProtocolFollowViewModel);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id, Guid protocolId)
        {
            try
            {
                await _protocolFollowService.DeleteProtocolFollowAsync(id);
                return RedirectToAction(nameof(List), new { id = protocolId });
            }
            catch
            {
                ModelState.AddModelError(string.Empty, "Erro ao excluir acompanhamento de protocolo");
                return RedirectToAction(nameof(List), new { id = protocolId });
            }
        }
    }
}
