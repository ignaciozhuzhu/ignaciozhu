/**********
 *发音控件*
 *为class = DivSound 的 DIV添加声音控件.
 **********/
//如果是谷歌浏览器用embed标签----------------------------------------------------------------------------------------begin
if (navigator.userAgent.indexOf('Chrome') >= 0) {
    $(".DivSound").append('UK<img class="soundUKChr" src="/images/soundGray.gif" onclick="play_click(this,1)" />')
    $(".DivSound").append('US<img class="soundUSChr" src="/images/soundGreen.gif" onclick="play_click(this,2)" />')
    function play_click(sef, type) {
        var url = 'http://dict.youdao.com/dictvoice?type=' + type + '&audio=' + word + '';
        $(".DivSound").append('<img id="div4SoundChr"><embed id="myembed" src=' + url + '></embed></img>');
        $("embed").hide();
    }
    //鼠标放置发音图标显示变化---------------------------------------------------begin
    $(".soundUKChr").mouseover(function () {
        $(".soundUKChr").css("cursor", "pointer");
        $(".soundUKChr").attr("src", "/images/soundGreenOn.gif");
    });
    $(".soundUKChr").mouseout(function () {
        $(".soundUKChr").attr("src", "/images/soundGray.gif");
    });
    $(".soundUSChr").mouseover(function () {
        $(".soundUSChr").css("cursor", "pointer");
        $(".soundUSChr").attr("src", "/images/soundGreenOn.gif");
    });
    $(".soundUSChr").mouseout(function () {
        $(".soundUSChr").attr("src", "/images/soundGreen.gif");
    });
    //鼠标放置发音图标显示变化---------------------------------------------------end
}
    //如果是谷歌浏览器用embed标签----------------------------------------------------------------------------------------end
    //其他情况用flash播放器--------------------------------------------------------------------------------------------begin
else {
    var value = "http://dict.youdao.com/dictvoice?type=2&audio=" + word + "";
    var str = '<OBJECT id="Player" classid="clsid:6BF52A52-394A-11d3-B153-00C04F79FAA6" width=0 height=0 > <param name="URL" value=' + value + ' /> <param name="AutoStart" value="false" /> </OBJECT>UK<img class="soundUK" src="/images/soundGray.gif" onclick="Player.controls.play();" />US<img class="soundUS" src="/images/soundGreen.gif" onclick="Player.controls.play();" />'
    $(".DivSound")[0].innerHTML = (str);
    //alert()
    //鼠标放置发音图标显示变化---------------------------------------------------begin
    $(".soundUK").mouseover(function () {
        $(".soundUK").css("cursor", "pointer");
        $(".soundUK").attr("src", "/images/soundGreenOn.gif");
    });
    $(".soundUK").mouseout(function () {
        $(".soundUK").attr("src", "/images/soundGray.gif");
    });
    $(".soundUS").mouseover(function () {
        $(".soundUS").css("cursor", "pointer");
        $(".soundUS").attr("src", "/images/soundGreenOn.gif");
    });
    $(".soundUS").mouseout(function () {
        $(".soundUS").attr("src", "/images/soundGreen.gif");
    });
    //鼠标放置发音图标显示变化---------------------------------------------------end
}
//其他情况用flash播放器--------------------------------------------------------------------------------------------end