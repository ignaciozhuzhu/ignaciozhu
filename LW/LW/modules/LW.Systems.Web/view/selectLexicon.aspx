<%@ Page Title="选择词汇" Language="C#" MasterPageFile="mymaster.Master" AutoEventWireup="true" CodeBehind="selectLexicon.aspx.cs" Inherits="LW.Systems.Web.view.selectLexicon" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderBody" runat="server">
    <div class="form-group" style="padding-top: 100px">
        <div class="col-sm-offset-1 col-sm-10">
            <button id="CET4" type="button" class="btn btn-default">英语四级</button>
        </div>
        <div class="col-sm-offset-1 col-sm-10" style="padding-top: 10px">
            <button id="CET6" type="button" class="btn btn-default">英语六级</button>
        </div>
        <div class="col-sm-offset-1 col-sm-10" style="padding-top: 10px">
            <button id="ESP" type="button" class="btn btn-default">西语词汇</button>
        </div>
        <div id="info" class="col-sm-offset-1 col-sm-10" style="padding-top: 10px">
        </div>
    </div>

    <script type="text/javascript">

        $("#CET4").click(function () {
            insertlexicon("cet4");
        })
        $("#CET6").click(function () {
            insertlexicon("cet6");
        })
        $("#ESP").click(function () {
            insertlexicon("ESP");
        })

        function insertlexicon(Lexicon) {
            $.ajax({
                url: "/modules/LW.Systems.Web/Ajax/userhandler.ashx",
                data: { fn: "insertlexicon", Lexicon: Lexicon },
                type: "post",
                success: function (text) {
                    d = mini.decode(text);
                    $("#info").html(d.data[0].info);
                }
            })
        }

    </script>

</asp:Content>
