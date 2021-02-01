using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

public class AccountController : Controller
{
    private ILoginRepository loginRepository;
    GreenPayContext db = new GreenPayContext();

    public AccountController()
    {
        loginRepository = new LoginRepository(db);
    }
    // GET: Account
    public ActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public ActionResult Login(LoginViewModel login, string ReturnUrl = "/")
    {
        if (ModelState.IsValid)
        {
            if (loginRepository.IsExitUser(login.UserName, login.Password))
            {
                FormsAuthentication.SetAuthCookie(login.UserName, login.RememberMe);
                return Redirect(ReturnUrl);
            }
            else
            {
                ModelState.AddModelError("UserName", "کاربری یافت نشد");
            }
        }
        return View();
    }

    public ActionResult SignOut()
    {
        FormsAuthentication.SignOut();
        return Redirect("/");
    }
}
