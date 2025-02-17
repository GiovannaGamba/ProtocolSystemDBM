using Microsoft.AspNetCore.Mvc;
using ProtocolSystemDBM.Models;
using ProtocolSystemDBM.Services.Interfaces;
using ProtocolSystemDBM.ViewModels.Users;

namespace ProtocolSystemDBM.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                ListUsersViewModel usersViewModel = new ListUsersViewModel
                {
                    Users = await _userService.GetUsersAsync()
                };

                return View(usersViewModel);
            }
            catch
            {
                ModelState.AddModelError(string.Empty, "Erro ao carregar usuários");
                return View(new ListUsersViewModel());
            }
        }

        public IActionResult Create()
        {
            return View(new RegisterUserViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(RegisterUserViewModel registerUserViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ArgumentException("Erro ao cadastrar usuário");
                }

                await _userService.CreateUserAsync(registerUserViewModel.FromViewModelToEntity());
                return RedirectToAction(nameof(Index));
            }
            catch (ArgumentException exception)
            {
                ModelState.AddModelError(string.Empty, exception.Message);
                return View(registerUserViewModel);
            }
            catch
            {
                ModelState.AddModelError(string.Empty, "Erro durante o processamento");
                return View(registerUserViewModel);
            }
        }

        public async Task<IActionResult> Update(Guid id)
        {
            try
            {
                User user = await _userService.GetUserById(id);
                return View(UpdateUserViewModel.FromEntityToViewModel(user));
            }
            catch
            {
                ModelState.AddModelError(string.Empty, "Erro ao carregar dados do usuário");
                return View();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateUserViewModel updateUserViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ArgumentException("Erro ao atualizar usuário");
                }

                await _userService.UpdateUserAsync(updateUserViewModel.FromViewModelToEntity());
                return RedirectToAction(nameof(Index));
            }
            catch (ArgumentException exception)
            {
                ModelState.AddModelError(string.Empty, exception.Message);
                return View(updateUserViewModel);
            }
            catch
            {
                ModelState.AddModelError(string.Empty, "Erro durante o processamento");
                return View(updateUserViewModel);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _userService.DeleteUserAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError(string.Empty, "Erro ao excluir usuário");
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
