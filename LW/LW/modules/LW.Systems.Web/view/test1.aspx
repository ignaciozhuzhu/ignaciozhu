<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="test1.aspx.cs" Inherits="LW.Systems.Web.view.test1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script src="/script/jquery/jquery-1.12.0.min.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="str">
    
    </div>
    </form>
</body>
</html>

<script type="text/javascript">
    b();

    function a() {
        $.ajax({
            data: { fn: "getword" },
            url: "/modules/LW.Systems.Web/Ajax/wordhandler.ashx",
            type: "post",
            success: function (text) {
                $("#str").append('a');
            }
        });
    }

    function b() {
        a();
        $("#str").append('b');
    }

</script>