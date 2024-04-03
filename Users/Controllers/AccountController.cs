using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace Users.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(string login, string password, string email)
        {
            if (!IsValidLogin(login))
            {
                ModelState.AddModelError("login", "Логин должен содержать от 4 до 12 английских символов.");
            }

            if (!IsValidPassword(password))
            {
                ModelState.AddModelError("password", "Пароль должен содержать от 6 до 18 символов, включая хотя бы одну цифру и один спецсимвол.");
            }

            if (!IsValidEmail(email))
            {
                ModelState.AddModelError("email", "Неверный формат email.");
            }

            if (ModelState.IsValid)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        public bool IsValidLogin(string login)
        {
            return !string.IsNullOrWhiteSpace(login) && Regex.IsMatch(login, "^[a-zA-Z]{4,12}$");
        }

        private bool IsValidPassword(string password)
        {
            return !string.IsNullOrWhiteSpace(password) && Regex.IsMatch(password, "^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*\\W).{6,18}$");
        }

        private bool IsValidEmail(string email)
        {
            return !string.IsNullOrWhiteSpace(email) && Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }
    }
}

