<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Charting.aspx.cs" Inherits="LW.Systems.Web.view.Charting" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>(。・`ω´・)</title>
    <link href="/script/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <script src="/script/jquery/jquery-1.11.1.min.js"></script>
    <script src="/script/bootstrap/js/bootstrap.min.js"></script>
    <link href="../Resources/bootstrap-table.css" rel="stylesheet" />
    <script src="../Resources/bootstrap-table.js"></script>
    <script src="/script/bootstrap/plugins/bootstrap-table-master/src/locale/bootstrap-table-zh-CN.js"></script>
    <script src="/script/bootstrap/plugins/bootstrap-datetimepicker/bootstrap-datetimepicker.js"></script>
</head>
<body>
    <div class="container">
        <form id="form2" class="form-horizontal" style="height: auto; width: 80%; padding-top: 20px">
            <div class="form-group">
                <label for="user" class="col-sm-1 control-label" style="width: 100px">昵称：</label>
                <div class="col-sm-3">
                    <input type="text" class="form-control" id="user" />
                </div>
                <label for="content" class="col-sm-1 control-label" style="width: 100px">内容：</label>
                <div class="col-sm-3">
                    <input type="text" class="form-control" id="content" />
                </div>
            </div>

            <div class="form-group">
                <label for="dates" class="col-sm-1 control-label" style="width: 100px">时间：</label>
                <div class="col-sm-3">
                    <div class='input-group date' id='datetimepicker1'>
                        <input type='text' class="form-control" id="dates" />
                        <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span>
                        </span>
                    </div>
                </div>
                <label for="datee" class="col-sm-1 control-label" style="width: 100px">～～</label>
                <div class="col-sm-3">
                    <div class='input-group date' id='datetimepicker2'>
                        <input type='text' class="form-control" id="datee" />
                        <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span>
                        </span>
                    </div>
                </div>
                <div class="col-sm-2">
                    <button type="button" class="btn btn-success btn-block" onclick="getDealerList()">查询</button>
                </div>
            </div>

            <div style="border-top: 2px solid #05a5b0; width: 125%; height: auto; overflow-y: auto">
                <div class="table-responsive">
                    <table id="table-dealerList" data-toggle="table" data-height="100%" data-cache="false" data-page-size="15" data-page-list="[10, 15, 20,50]"
                        data-url="/modules/LW.Systems.Web/ajax/chartinghandler.ashx?fn=getchartinglist" data-query-params="queryParams" data-side-pagination="server" data-pagination="true"
                        data-striped="true">
                        <thead>
                            <tr >
                                <th data-field="datetime" style="text-align: center; border-bottom: none;width: 200px">时间</th>
                                <th data-field="user" style="text-align: center; border-bottom: none;width: 200px">昵称</th>
                                <th data-field="content" style="text-align: center; border-bottom: none;width: 200px">内容</th>
                            </tr>
                        </thead>
                    </table>
                </div>
            </div>
        </form>

    </div>

</body>
</html>

<script>
    Date.prototype.Format = function (formatStr) {
        var str = formatStr;
        var Week = ['日', '一', '二', '三', '四', '五', '六'];
        str = str.replace(/yyyy|YYYY/, this.getFullYear());
        str = str.replace(/yy|YY/, (this.getYear() % 100) > 9 ? (this.getYear() % 100).toString() : '0' + (this.getYear() % 100));
        str = str.replace(/MM/, this.getMonth() + 1 > 9 ? (this.getMonth() + 1).toString() : '0' + (this.getMonth() + 1));
        str = str.replace(/M/g, this.getMonth() + 1);
        str = str.replace(/w|W/g, Week[this.getDay()]);
        str = str.replace(/dd|DD/, this.getDate() > 9 ? this.getDate().toString() : '0' + this.getDate());
        str = str.replace(/d|D/g, this.getDate());
        str = str.replace(/hh|HH/, this.getHours() > 9 ? this.getHours().toString() : '0' + this.getHours());
        str = str.replace(/h|H/g, this.getHours());
        str = str.replace(/mm/, this.getMinutes() > 9 ? this.getMinutes().toString() : '0' + this.getMinutes());
        str = str.replace(/m/g, this.getMinutes());
        str = str.replace(/ss|SS/, this.getSeconds() > 9 ? this.getSeconds().toString() : '0' + this.getSeconds());
        str = str.replace(/s|S/g, this.getSeconds());
        return str;
    }
    $(function () {
        $('#datetimepicker1').datetimepicker();
        $('#datetimepicker2').datetimepicker();
    });

    function getDealerList() {
        $('#table-dealerList').bootstrapTable('refresh')
    }
    $(function () {
        $('#table-dealerList').bootstrapTable();
        $(window).resize(function () {
            $('#table-dealerList').bootstrapTable('resetView');
        });
    })
    //点击进入明细页面
    //$('#table-dealerList').bootstrapTable({
    //    onDblClickRow: function (row) {
    //        window.location.href = '/modules/an.sales.web/view/SH/taizhangForAdmin.aspx?dealerCode=' + row["CorporationCode"];
    //    }
    //});

    function queryParams(params) {
        var user = $("#user").val();
        var dates = $("#dates").val();
        dates = ReplaceAll(dates, '/', '-');
        var datee = $("#datee").val();
        var content = $("#content").val();
        return {
            user: user,
            dates: dates,
            datee: datee,
            content: content,
            pageSize: params.pageSize,
            pageNumber: params.pageNumber
        };
    }

    function ReplaceAll(str, sptr, sptr1) {
        while (str.indexOf(sptr) >= 0) {
            str = str.replace(sptr, sptr1);
        }
        return str;
    }


</script>
