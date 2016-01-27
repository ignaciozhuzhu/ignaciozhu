<%@ Page Title="主页" Language="C#" MasterPageFile="mymaster.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="LW.Systems.Web.view.index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderBody" runat="server">
    
        <div class="form-group" style="padding-top:100px">
            <div class="col-sm-offset-1 col-sm-10">
                <button id="tolearn" type="button" class="btn btn-default">开始学习</button>
            </div>
        </div>


    <script type="text/javascript">

        $("#tolearn").click(function () {
            getuserorderby();
        })

        function start2learn() {
            $.ajax({
                url: "/modules/LW.Systems.Web/Ajax/wordhandler.ashx",
                data: { fn: "start2learn"},
                type: "post",
                success: function (text) {
                    window.location.href = "memory.aspx";
                }
            })
        }

        function getuserorderby() {
            $.ajax({
                url: "/modules/LW.Systems.Web/Ajax/wordhandler.ashx",
                data: { fn: "getuserorderby" },
                type: "post",
                success: function (text) {
                    if (text == "-1") {
                        //未开始学习,进入开始学习
                        start2learn();
                        return;
                    }
                    else {
                        //继续学习
                        window.location.href = "memory.aspx";
                    }
                }
            })
        }

        

    </script>

</asp:Content>
