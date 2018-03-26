//全局的ajax访问，处理ajax清求时session超时
$.ajaxSetup({
    contentType: "application/x-www-form-urlencoded;charset=utf-8",
    complete: function (XMLHttpRequest, textStatus) {
        //通过XMLHttpRequest取得响应头，sessionstatus，
        var sessionstatus = XMLHttpRequest.getResponseHeader("userstatus");
        if (sessionstatus == "unauthorize") {
            window.location.href = "/backmgr/account/unauthorize";
            //如果超时就处理 ，指定要跳转的页面(比如登陆页)
            //$('body').append('<div style="height: 100%;position: absolute;z-index: 999999999;background-color: #F8F8F8;width: 100%;top: 0;text-align: center;padding-top: 200px;">对不起，无权操作</div>');
            //setTimeout(function () { window.location.href = "/"; }, 2000);

        }
    }
});

var msger = {
    tip: function (msg) {
        layer.msg(msg);
    }
}
