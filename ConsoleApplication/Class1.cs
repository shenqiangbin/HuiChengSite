using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication
{
    class Class1
    {
[ValidateAntiForgeryToken]
[HttpPost]
public ActionResult SendTelCode(string tel)
{
    if (string.IsNullOrEmpty(tel))
        return Json(new { code = 401, msg = "手机不能为空" });
    try
    {
        string body = ConfigHelper.GetChangePwdTelBody();
        string code = new Random().Next(100000, 999999).ToString();

        validateCodeService.AddTelCode(tel, code);
        body = body.Replace("{code}", code);

        smsInfoService.AddSmsInfo(new SmsInfo { RecieveNum = tel, RecieveName = "", Msg = body });
        return Json(new { code = 200, msg = "ok" });
    }
    catch (Exception ex)
    {
        LogOpr.Error(ex.Message);
        return Json(new { code = 500 });
    }
}




    }
}
