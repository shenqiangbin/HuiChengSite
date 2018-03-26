$(function () {

    //折叠
    $('pre').each(function () {
        var item = $("<div style='color:blue;cursor:pointer;margin-bottom:-12px;font-size:14px;'>折叠</div>");
        item.click(function () {
            var val = item.html();
            if (val == "折叠") {
                item.next().hide();
                item.html("展开");
                item.css('margin-bottom', '0px');
            } else {
                item.next().show();
                item.html("折叠");
                item.css('margin-bottom', '-12px');
            }
        });
        $(this).before(item);
    });

    //二维码
    var url = location.href;
    $("#qrcode").qrcode({
        render: "canvas",    //设置渲染方式，有table和canvas，使用canvas方式渲染性能相对来说比较好
        text: url,    //扫描二维码后显示的内容,可以直接填一个网址，扫描二维码后自动跳向该链接
        width: "150",               //二维码的宽度
        height: "150",              //二维码的高度
        background: "#ffffff",       //二维码的后景色
        foreground: "#07a0e1",        //二维码的前景色
        src: ''             //二维码中间的图片
    });

    //加载标签
    function initLabelContainer() {
        $.get("/backmgr/label/GetLablesByArticle", { articleId: articleId }, function (result) {
            if (result.code == 200) {
                $("#labelContainer").html('');
                var arr = result.data;
                if (arr.length!=0)
                    $("#labelContainer").append('<img src="/Images/label3.png" alt="标签" width="14"/>');                
                for (var i = 0; i < arr.length; i++) {
                    var item = arr[i];                                    
                    var div = $("<a href='#' class='label-item'>{1}</a>".replace("{1}", item.Name));
                    $("#labelContainer").append(div);
                }
            }
        });
    }
    initLabelContainer();

});