<%@ Page Title="闪现" Language="C#" MasterPageFile="mymaster.Master" AutoEventWireup="true" CodeBehind="memory_back.aspx.cs" Inherits="LW.Systems.Web.view.memory_back" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolderBody" runat="server">

    <form id="mainForm" class="form-horizontal" role="form" style="width: 100%; margin: 0 auto; padding-top: 10mm;">
        <div>
            <div id="word" style="font-size: 45px; line-height: 60px;"></div>
            <div style="padding: 5px; width: 290px; margin: 0px auto; padding-top: 10px">
                <div style="float: left; width: 130px; 楷体; color: #9999a5" id="Pronunciation"></div>
                <div id="DivSound" style="margin-left: 130px;"></div>
            </div>
            <table style="width: 80%; margin: 0px auto;">
                <tr class="yes">
                    <td class="tomid slant" style="vertical-align: middle; border: 1px solid #ddd">1.</td>
                    <td style="vertical-align: middle; text-align: left; padding-left: 20px; border: 1px solid #ddd">Yes!</td>
                </tr>
                <tr>
                    <td class="tomid slant" style="vertical-align: middle; border: 1px solid #ddd">2.</td>
                    <td style="vertical-align: middle; text-align: left; padding-left: 20px; border: 1px solid #ddd">No...</td>
                </tr>
            </table>
            
            <div style="float: left; width: 15%; height: 231px;">
                <img id="rightarrow" src="/images/右箭头.gif" onclick="nextword()" />
            </div>

            <div style="height: 400px;"></div>

            <div style="font-size:13px">
                <div style="float: left; font-weight: bold; width: 10%">
                    <font style="padding-left:30px">进度</font>
                </div>
                <div style="float: left; width: 80%;margin: 0px auto;">
                    <div id="nkown" style="text-align: center;  color: #fff; background-color: #209e85; float: left;"></div>
                    <div id="learn" style="text-align: center;  color: #fff; background-color: #50c1ab; float: left;"></div>
                    <div id="toLearn" style="text-align: center;  background-color: #f5f5f5; float: left;"></div>
                    <div id="forget" style="text-align: center;  color: #fff; background-color: #f89406; float: left;"></div>
                </div>
            </div>
        </div>
    </form>

    <script type="text/javascript">

        //鼠标放置显示变化---------------------------------------------------begin
        $(".yes").mouseover(function () {
            $(".yes").css("background-color", "#209e85");
            $(".yes").css("color", "#fff");
            $(".yes").css("cursor", "pointer");
            $(".slant:eq(0)").css("background-image", "none");
        });
        $(".yes").mouseout(function () {
            $(".yes").css("background-color", "transparent");
            $(".yes").css("color", "#000");
            $(".slant").css("background-image", "url(/images/slant.gif)");
        });

        $(".no").mouseover(function () {
            $(".no").css("background-color", "#f4434b");
            $(".no").css("color", "#fff");
            $(".no").css("cursor", "pointer");
            $(".slant:eq(1)").css("background-image", "none");
        });
        $(".no").mouseout(function () {
            $(".no").css("background-color", "transparent");
            $(".no").css("color", "#000");
            $(".slant").css("background-image", "url(/images/slant.gif)");
        });


        //鼠标放置显示变化---------------------------------------------------begin
        $("#rightarrow").mouseover(function () {
            $("#rightarrow").css("cursor", "pointer");
            $("#rightarrow").attr("src", "/images/右箭头绿.gif");
        });
        $("#rightarrow").mouseout(function () {
            $("#rightarrow").attr("src", "/images/右箭头.gif");
        });
        //鼠标放置显示变化---------------------------------------------------end

        //鼠标放置显示变化---------------------------------------------------end

        var userid = "22";
        var word = '';
        getword(userid);
        getschedule();

        //获取页面单词
        function getword() {
            $.ajax({
                data: { userid: userid, fn: "getword" },
                url: "/modules/LW.Systems.Web/Ajax/wordhandler.ashx",
                type: "post",
                success: function (text) {
                    var d = mini.decode(text);
                    $("#word").html(d.data[0].WordE);
                    $("#Pronunciation").html(d.data[0].Pronunciation);
                    word = d.data[0].WordE;
                    var value = "http://dict.youdao.com/dictvoice?type=2&audio=" + word + "";
                    document.getElementById('Player').URL = value;
                }
            });
        }

        //获取进度条
        function getschedule() {
            $.ajax({
                data: { userid: userid, fn: "getschedule" },
                url: "/modules/LW.Systems.Web/Ajax/wordhandler.ashx",
                type: "post",
                success: function (text) {
                    var d = mini.decode(text);
                    var toLearn = parseInt(d.data[0].ct);
                    var nkown = parseInt(d.data[1].ct);
                    var learn = parseInt(d.data[2].ct);
                    var forget = parseInt(d.data[3].ct);
                    totalWordToday = toLearn + nkown + learn + forget
                    $("#nkown").width(nkown / totalWordToday * 100 + '%');
                    $("#learn").width(learn / totalWordToday * 100 + '%');
                    $("#toLearn").width(toLearn / totalWordToday * 100 + '%');
                    //$("#toLearn").css('border-width',"0px");
                    $("#forget").width(forget / totalWordToday * 91 + '%');
                    if (nkown == 0) nkown = ''
                    if (learn == 0) learn = ''
                    if (toLearn == 0) toLearn = ''
                    if (forget == 0) forget = ''
                    $("#nkown").text(nkown);
                    $("#learn").text(learn);
                    $("#toLearn").text(toLearn);
                    $("#forget").text(forget);
                }
            });
        }


        function nextword() {
            $.ajax({
                data: { userid: userid, fn: "nextword" },
                url: "/modules/LW.Systems.Web/Ajax/wordhandler.ashx",
                type: "post",
                success: function (text) {
                    // etInterval(function () { $(".refresh").load(location.href + " .refresh"); }, 5000);
                    // $("#wordC").append('cc');

                    getword(userid);
                }
            });
        }


    </script>

    <script src="/modules/LW.Systems.Web/view/sound.js?1" type="text/javascript"></script>


</asp:Content>
