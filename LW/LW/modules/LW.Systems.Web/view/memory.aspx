<%@ Page Title="明细" Language="C#" MasterPageFile="mymaster.Master" AutoEventWireup="true" CodeBehind="memory.aspx.cs" Inherits="LW.Systems.Web.view.memory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderBody" runat="server">

    <form id="mainForm" class="form-horizontal" role="form" style="width: 100%; margin: 0 auto; padding-top: 20px">

        <div id="divmemory">
            <div class="word" style="font-size: 45px; line-height: 60px;"></div>
            <div style="padding: 5px; width: 290px; margin: 0px auto; padding-top: 10px">
                <div style="float: left; width: 130px; 楷体; color: #9999a5" class="Pronunciation"></div>
                <div class="DivSound" style="margin-left: 130px;"></div>
            </div>
            <div id="Sentence" style="width: 75%; margin: 0px auto; height: 70px;">
                <div style="background-color: #eee; height: 55px; border: 1px solid #e3e3e3; border-radius: 3px;">
                    <div class="Sentence" style="font-size: 16px; text-align: left; padding: 15px 15px 15px 15px"></div>
                </div>
            </div>
            <div id="wordC" style="width: 75%; margin: 0px auto; height: 70px;">
                <div style="background-color: #eee; height: 55px; border: 1px solid #e3e3e3; border-radius: 3px;">
                    <div class="wordC" style="font-size: 16px; text-align: left; padding: 15px 15px 15px 15px"></div>
                </div>
            </div>
            <table id="ifknown" style="width: 75%; margin: 0px auto;">
                <tr class="yes">
                    <td class="tomid slant" style="vertical-align: middle; border: 1px solid #ddd">1.</td>
                    <td style="vertical-align: middle; text-align: left; padding-left: 20px; border: 1px solid #ddd">认识</td>
                </tr>
                <tr class="no">
                    <td class="tomid slant" style="vertical-align: middle; border: 1px solid #ddd">2.</td>
                    <td style="vertical-align: middle; text-align: left; padding-left: 20px; border: 1px solid #ddd">不认识</td>
                </tr>
            </table>
            <table id="ifremind" style="width: 75%; margin: 0px auto;">
                <tr class="yes">
                    <td class="tomid slant" style="vertical-align: middle; border: 1px solid #ddd">1.</td>
                    <td style="vertical-align: middle; text-align: left; padding-left: 20px; border: 1px solid #ddd">想起来了</td>
                </tr>
                <tr class="no">
                    <td class="tomid slant" style="vertical-align: middle; border: 1px solid #ddd">2.</td>
                    <td style="vertical-align: middle; text-align: left; padding-left: 20px; border: 1px solid #ddd">没想起来</td>
                </tr>
            </table>
            <table id="lookdetail" style="width: 75%; margin: 0px auto;">
                <tr class="yes">
                    <td class="tomid slant" style="vertical-align: middle; border: 1px solid #ddd">1.</td>
                    <td style="vertical-align: middle; text-align: left; padding-left: 20px; border: 1px solid #ddd">查看明细</td>
                </tr>
            </table>

            <div style="height: 410px;"></div>

            <div style="float: left; font-weight: bold; font-size: 12px">
                <font style="padding-left: 60px">进度</font>
            </div>
            <div style="font-size: 12px; width: 75%; margin: 0px auto;">
                <div style="float: left; width: 100%; margin: 0px auto; border: 1px solid #ddd">
                    <div id="nkown" style="text-align: center; color: #fff; background-color: #209e85; float: left;"></div>
                    <div id="learn" style="text-align: center; color: #fff; background-color: #50c1ab; float: left;"></div>
                    <div id="toLearn" style="text-align: center; background-color: #f5f5f5; float: left;"></div>
                    <div id="forget" style="text-align: center; color: #fff; background-color: #f89406; float: left;"></div>
                </div>
            </div>
        </div>

        <div id="divworddetail">
            <div style="float: left; width: 85%; height: 168px;">
                <div style="float: left; width: 13%; height: 76px;"></div>
                <div style="float: left; width: 87%; height: 76px; line-height: 60px;">
                    <div class="word" style="font-weight: normal; font-size: 42px; float: left;" class="text-center"></div>
                    <div class="Pronunciation" style="color: #9999a5; float: left; padding: 8px 0 0 8px"></div>
                    <div class="DivSound" style="float: left; padding: 8px 0 0 8px">
                        <span>&nbsp;&nbsp;&nbsp;</span>
                    </div>
                </div>
                <div style="float: left; width: 13%; height: 86px; font-weight: bold; font-size: 13px; padding-top: 5px">单词解释</div>
                <div style="float: left; width: 87%; height: 92px;">
                    <div style="background-color: #f5f5f5; height: 75px; border: 1px solid #e3e3e3; border-radius: 3px;">
                        <div class="wordC" style="font-size: 16px; text-align: left; padding: 15px 15px 15px 15px"></div>
                    </div>
                </div>
            </div>
            <div style="float: left; width: 15%; height: 168px; visibility: hidden">图</div>

            <div style="float: left; width: 11%; height: 226px; font-weight: bold; font-size: 13px; padding-top: 5px">例句</div>
            <div style="float: left; width: 74%; height: 231px; text-align: left; font-size: 16px;">
                <div class="Sentence" style="padding: 15px 15px 15px 15px"></div>
            </div>
            <div style="float: left; width: 15%; height: 231px;">
                <img alt="rightarrow" class="rightarrow" src="/images/rightarrow.gif" />
            </div>
            <div style="float: left; width: 11%; height: 227px; font-weight: bold; font-size: 13px; padding-top: 5px">笔记</div>
            <div style="float: left; width: 74%; height: 231px;"></div>
            <div style="float: left; width: 15%; height: 231px;"></div>
        </div>

        <div id="divgroup">
            <div style="float: left; width: 14%; height: 58px; font-weight: bold">总结</div>
            <div style="float: left; width: 86%; height: 58px; text-align: left; font-size: 20px; font-weight: bold">快速回顾</div>

            <div id="idgridgroup" style="float: left; width: 90%; height: 368px">
                
            </div>

            <div style="float: left; width: 10%; height: 368px; padding-top: 170px">
                <img alt="rightarrow" class="rightarrow" src="/images/rightarrow.gif" />
            </div>

        </div>

        <div id="divcongratulations">
            恭喜您!
            今日单词任务已完成
        </div>


    </form>

    <div id="diverror" style="display: none">
        未知异常!
    </div>

    <script type="text/javascript">
        var word;
        var orderby;
        var status;
        $(document).ready(function () {
             getuserorderby();
        });

        //进入这个页面首先判断用户的学习状态
        function getuserorderby() {
            $.ajax({
                data: { fn: "getuserstatusnow" },
                url: "/modules/LW.Systems.Web/Ajax/wordhandler.ashx",
                type: "post",
                success: function (text) {
                    if (text == "0") {
                        showdivcongratulations();
                        return;
                    }
                    else if (text == "8") {
                        nextsmallgroup();
                    }
                    else {
                        getword();
                    }
                }
            })
        }

        //获取页面单词
        function getword() {
            $.ajax({
                data: { fn: "getword" },
                url: "/modules/LW.Systems.Web/Ajax/wordhandler.ashx",
                type: "post",
                success: function (text) {
                    if (rightclick == "1")
                        $.ajax({
                            data: { fn: "revolve" },
                            url: "/modules/LW.Systems.Web/Ajax/wordhandler.ashx",
                            type: "post",
                            success: function (text) {
                                rightclick = 0;
                                var d = mini.decode(text);
                                if (d.data[0].info == "memory")
                                    getword();
                                else {
                                    showdivgroup();
                                    $("#idgridgroup").empty();
                                    for (var i = 0; i < 7; i++) {
                                        word = d.data[i].WordE;
                                        var Level = d.data[i].Level;
                                        var colorlevel;
                                        var style;
                                        var styleno;
                                        var levelwidth;
                                        var levelnowidth;
                                        levelwidth = Level * 19.5;
                                        levelnowidth = (5 - Level) * 19.5;
                                        if (Level == 0) {
                                            colorlevel = "#f2dede";
                                            styleno = "border-radius: 3px;";
                                        }
                                        else {
                                            colorlevel = "#dff0d8";
                                            if (Level == 5) {
                                                style = "border-radius: 3px;";
                                            }
                                            else {
                                                style = "border-top-left-radius: 3px;border-bottom-left-radius: 3px;";
                                                styleno = "border-top-right-radius: 3px;border-bottom-right-radius: 3px;";
                                            }
                                        }
                                        //$("#idgridgroup").append('<div style="float: left; width: 20%;height:60px"></div><div style="float: left; width: 75%;height:60px"><div style="float: left; width: 150px; font-weight: bold;text-align: left;">' + word + '</div><div style="float: left; font-size: 10px">' + d.data[i].wordC + '</div></div>')
                                        $("#idgridgroup").append('<div style="float: left; width: 15%;height:60px"></div><div style="float: left; width: 80%;height:60px;padding:15px 0 0 10px;border: 1px solid #ddd;background-color:' + colorlevel + '"><div style="float: left; width: 150px; font-weight: bold;text-align: left;">' + word + '</div><div style="float: left;width:260px; font-size: 10px;text-align: left;">' + d.data[i].wordC + '</div><div style="float: left;"><div style="float: left; width: 100px; margin: 0px auto; border: 1px solid #ddd;border-radius: 3px;"><div style="background-color: #209e85; float: left;height:20px;width:' + levelwidth + 'px;' + style + '"></div><div style="background-color: #fff; float: left;height:20px;width:' + levelnowidth + 'px;' + styleno + '"></div></div></div></div>')
                                    }
                                }
                            }
                        });

                    else {
                        var d = mini.decode(text);
                        if (d.data[0] == undefined) {
                            $("#mainForm").hide();
                            $("#diverror").show();
                            return;
                        }
                        $(".word").html(d.data[0].WordE);
                        $(".Pronunciation").html(d.data[0].Pronunciation);
                        $(".wordC").html(d.data[0].wordC);
                        orderby = d.data[0].OrderBy;
                        status = d.data[0].Status;
                        word = d.data[0].WordE;

                        var Sentence = d.data[0].Sentence;
                        Sentence = Sentence.replace(word, '<span style= "font-weight: bold;font-size:20px">' + word + '</span>');
                        $(".Sentence").html(Sentence);

                        var value = "http://dict.youdao.com/dictvoice?type=2&audio=" + word + "";
                        if (navigator.userAgent.indexOf('Chrome') < 0) {
                            //非谷歌专用播放器
                            document.getElementById('Player').URL = value;
                        }
                        showdivmemory();
                    }
                }
            });
        }

        function showdivmemory() {
            $("#ifknown").show();
            $("#divmemory").show();
            $("#divworddetail").hide();
            $("#divgroup").hide();
            $("#divcongratulations").hide();
            getschedule();

            $("#Sentence").hide();
            $("#wordC").hide();
            $("#ifremind").hide();
            $("#lookdetail").hide();
            if (status == 12) {
                $("#Sentence").show();
            }
        }
        function showdivworddetail() {
            $("#divmemory").hide();
            $("#divworddetail").show();
            $("#divgroup").hide();
            $("#divcongratulations").hide();
        }
        function showdivgroup() {
            $("#divmemory").hide();
            $("#divworddetail").hide();
            $("#divgroup").show();
            $("#divcongratulations").hide();
        }
        function showdivcongratulations() {
            $("#divmemory").hide();
            $("#divworddetail").hide();
            $("#divgroup").hide();
            $("#divcongratulations").show();
        }

        function lookdetail() {
            //$.ajax({
            //    data: { fn: "lookdetail" },
            //    url: "/modules/LW.Systems.Web/Ajax/wordhandler.ashx",
            //    type: "post",
            //    success: function (text) {

            //    }
            //});
            showdivworddetail();
        }

        function revolve() {
            $.ajax({
                data: { fn: "revolve" },
                url: "/modules/LW.Systems.Web/Ajax/wordhandler.ashx",
                type: "post",
                success: function (text) {
                    var d = mini.decode(text);
                    if (d.data[0].info == "memory")
                        getword();
                    else {
                        showdivgroup();
                        $("#idgridgroup").empty();
                        for (var i = 0; i < 7; i++) {
                            word = d.data[i].WordE;
                            $("#idgridgroup").append('<div style="float: left; width: 20%;height:60px"></div><div style="float: left; width: 75%;height:60px;"><div style="float: left; width: 150px; font-weight: bold;text-align: left;">' + word + '</div><div style="float: left; font-size: 10px">' + d.data[i].wordC + '</div></div>')
                        }
                    }
                }
            });
        }

        function nextsmallgroup() {
            $.ajax({
                data: { fn: "nextsmallgroup" },
                url: "/modules/LW.Systems.Web/Ajax/wordhandler.ashx",
                type: "post",
                success: function (text) {
                    getuserorderby();
                }
            });
        }

        var IfWordReady = "0";//防超车:这是为了防止右箭头按钮按的太快了,未等后台更新OrderBy就点了.
        function updatewordstatus(status) {
            $.ajax({
                data: { orderby: orderby, status: status, fn: "updatewordstatus" },
                url: "/modules/LW.Systems.Web/Ajax/wordhandler.ashx",
                type: "post",
                success: function (text) {
                    IfWordReady = "1";
                    getschedule();
                }
            });
        }

        //获取进度条
        function getschedule() {
            $.ajax({
                data: { fn: "getschedule" },
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
                    $("#forget").width(forget / totalWordToday * 100 + '%');
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

        //鼠标放置显示变化---------------------------------------------------begin
        $(".yes").mouseover(function () {
            $(".yes").css("background-color", "#209e85");
            $(".yes").css("color", "#fff");
            $(".yes").css("cursor", "pointer");
            $(".slant:eq(0)").css("background-image", "none");
            $(".slant:eq(2)").css("background-image", "none");
            $(".slant:eq(4)").css("background-image", "none");
        });
        $(".yes").mouseout(function () {
            $(".yes").css("background-color", "transparent");
            $(".yes").css("color", "#000");
            $(".slant").css("background-image", "url(/images/slant.gif)");
        });
        $(".yes").click(function () {
            lookdetail();
        })
        $("#ifknown").find(".yes").click(function () {
            if (status == 12) {
                updatewordstatus(11);
            }
            else {
                updatewordstatus(10);
            }
        })

        $(".no").mouseover(function () {
            $(".no").css("background-color", "#f4434b");
            $(".no").css("color", "#fff");
            $(".no").css("cursor", "pointer");
            $(".slant:eq(1)").css("background-image", "none");
            $(".slant:eq(3)").css("background-image", "none");
        });
        $(".no").mouseout(function () {
            $(".no").css("background-color", "transparent");
            $(".no").css("color", "#000");
            $(".slant").css("background-image", "url(/images/slant.gif)");
        });
        $("#ifknown").find(".no").click(function () {
            updatewordstatus(12);
            if (status != 1) {
                $("#wordC").show();
                $("#ifknown").hide();
                $("#lookdetail").show();
            }
            else {
                $("#Sentence").show();
                $("#ifknown").hide();
                $("#ifremind").show();
            }
        })
        $("#ifremind").find(".no").click(function () {
            $("#wordC").show();
            $("#ifremind").hide();
            $("#lookdetail").show();
        })

        $(".rightarrow").mouseover(function () {
            $(".rightarrow").css("cursor", "pointer");
            $(".rightarrow").attr("src", "/images/rightarrowGr.gif");
        });
        $(".rightarrow").mouseout(function () {
            $(".rightarrow").attr("src", "/images/rightarrow.gif");
        });
        var rightclick = 0;//这是为了防止按的太快了.
        $("#divworddetail").find(".rightarrow").click(function () {
            if (IfWordReady == "1") {
                IfWordReady == "0"
                rightclick = '1';
                getword();
            }
        })

        $("#divgroup").find(".rightarrow").click(function () {
            if (IfWordReady == "1") {
                IfWordReady == "0"
                rightclick = '1';
                nextsmallgroup();
            }
        })

        //鼠标放置显示变化---------------------------------------------------end

    </script>
    <script src="/modules/LW.Systems.Web/view/sound.js?6" type="text/javascript"></script>


</asp:Content>
