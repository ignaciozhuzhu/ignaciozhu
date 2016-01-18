//发音控件----------------------------------------------------------------------------------------------------------------------------------begin

if (navigator.userAgent.indexOf('Chrome') >= 0) {
    //如果是谷歌浏览器用embed标签
    $("#soundUK").hide();
    $("#soundUS").hide();
    function play_click(sef, type) {
        var url = 'http://dict.youdao.com/dictvoice?type=' + type + '&audio=' + word + '';
        var div = document.getElementById('div4SoundChr');
        div.innerHTML = '<embed id="myembed" src="' + url + '"></embed>';
        document.getElementById('myembed').style.display = 'none';
    }
}
else
{
    //其他情况用flash播放器
    $("#soundUKChr").hide();
    $("#soundUSChr").hide();
    document.write(' <OBJECT id="Player"');
    document.write(' classid="clsid:6BF52A52-394A-11d3-B153-00C04F79FAA6"');
    var value = "http://dict.youdao.com/dictvoice?type=2&audio=" + word + "";
    document.write(' width=0 height=0 > <param name="URL" value=' + value + ' /> <param name="AutoStart" value="false" /> </OBJECT>');
}

//鼠标放置发音图标显示变化---------------------------------------------------begin
//谷歌下
$("#soundUKChr").mouseover(function () {
    $("#soundUKChr").css("cursor", "pointer");
    $("#soundUKChr").attr("src", "/images/soundGreenOn.jpg");
});
$("#soundUKChr").mouseout(function () {
    $("#soundUKChr").attr("src", "/images/soundGray.jpg");
});
$("#soundUSChr").mouseover(function () {
    $("#soundUSChr").css("cursor", "pointer");
    $("#soundUSChr").attr("src", "/images/soundGreenOn.jpg");
});
$("#soundUSChr").mouseout(function () {
    $("#soundUSChr").attr("src", "/images/soundGreen.jpg");
});
//IE下
$("#soundUK").mouseover(function () {
    $("#soundUK").css("cursor", "pointer");
    $("#soundUK").attr("src", "/images/soundGreenOn.jpg");
});
$("#soundUK").mouseout(function () {
    $("#soundUK").attr("src", "/images/soundGray.jpg");
});
$("#soundUS").mouseover(function () {
    $("#soundUS").css("cursor", "pointer");
    $("#soundUS").attr("src", "/images/soundGreenOn.jpg");
});
$("#soundUS").mouseout(function () {
    $("#soundUS").attr("src", "/images/soundGreen.jpg");
});
//鼠标放置发音图标显示变化---------------------------------------------------end
//发音控件----------------------------------------------------------------------------------------------------------------------------------end
