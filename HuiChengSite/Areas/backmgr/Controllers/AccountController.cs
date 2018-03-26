using HuiChengSite.Common;
using HuiChengSite.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HuiChengSite.Areas.backmgr.Controllers
{
    public class AccountController : Controller
    {
        private UserService _userService;

        public AccountController(UserService userService)
        {
            _userService = userService;
        }

        public ActionResult Login()
        {
            if (ContextUser.IsLogined)
               return GoUrl();
            else
                return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string email, string password, string validateCode, string tmpToken, string returnUrl)
        {
            try
            {
                ViewBag.Email = email;
                ViewBag.Password = password;
                ValidateLogin(email, password, validateCode, tmpToken);

                if (CheckUser(email, password))
                {
                    SessionHelper.Store(email, string.Empty);
                    return GoUrl();
                }
                else
                {
                    ViewBag.Msg = "用户名或密码错误";
                }
            }
            catch (ValidateException ex)
            {
                ViewBag.Msg = ex.Message;
            }
            catch (Exception ex)
            {
                //Logger.Log(ex);
                ViewBag.Msg = "登录失败";
            }

            return View();
        }

        private void ValidateLogin(string email, string password, string validateCode, string tmpToken)
        {
            var tmpTokenInServer = TempData["TmpToken"];
            if (tmpTokenInServer == null || tmpTokenInServer.ToString() != tmpToken)
                throw new ValidateException(403, "-");

            if (string.IsNullOrEmpty(email))
                throw new ValidateException(400, "邮箱不能为空");
            if (string.IsNullOrEmpty(password))
                throw new ValidateException(401, "密码不能为空");
            if (string.IsNullOrEmpty(validateCode))
                throw new ValidateException(402, "验证码不能为空");

            if (Session["Code"] != null)
            {
                if (!string.Equals(validateCode, Session["Code"].ToString(), StringComparison.CurrentCultureIgnoreCase))
                    throw new ValidateException(402, "验证码不正确");
            }
        }

        private bool CheckUser(string email, string password)
        {
            var user = _userService.GetUserByEmail(email);
            if (user == null)
                return false;

            var passwordDecrypt = RSAHelper.Decrypt(password, TempData["RSAKey"].ToString());

            if (HashHelper.HashMd5(passwordDecrypt, user.Salt) != user.Password)
                return false;

            return true;
        }

        private ActionResult GoUrl()
        {
            return RedirectToAction("Index", "Home");
        }

        public ActionResult LogOut()
        {
            SessionHelper.Clear();
            return RedirectToAction("login");
        }

        public ActionResult UnAuthorize()
        {
            return View();
        }
    }
}