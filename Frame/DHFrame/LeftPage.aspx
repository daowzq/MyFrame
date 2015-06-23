<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Grid.Master" AutoEventWireup="true" CodeBehind="LeftPage.aspx.cs" Inherits="HDFrame.LeftPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Css/common.css" rel="stylesheet" />
    <script src="js/jquery-1.7.2.min.js"></script>
    <script type="text/javascript">
        Ext.onReady(function () {
            //Ext.create('Ext.panel.Panel', {
            //    width: 200,
            //    html: '<p>World!</p>',
            //    renderTo: Ext.getBody()
            //});

            $('.left_nav').find("li").bind('click', function () {
                $(this).addClass("active").siblings("li").removeClass("active");
                var activeindex = $(this).index();
                if (activeindex == 1) {
                    $('.nav_dropdown').hide();
                    $('.nav_dr1').show();
                } else if (activeindex == 2) {
                    $('.nav_dropdown').hide();
                    $('.nav_dr2').show();
                } else {
                    $(".nav_dropdown").hide();
                    return false;
                }
                $(document).click(function () { $(".nav_dropdown").hide() });
                return false;
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="navigotar">
        <ul class="left_nav">
            <li><a class="nav_home">首页</a></li>
            <li><a class="nav_procure">采购管理</a></li>
            <li><a class="nav_inventory">库存管理</a></li>
            <li><a class="nav_data">基础数据</a></li>
            <li><a class="nav_chemical">化学知识库</a></li>
            <li><a class="nav_warn">警告牌</a></li>
            <li><a class="nav_sys">系统管理</a></li>
        </ul>
        <div class="nav_dropdown nav_dr1">
            <i class="pic3"></i>
            <ul>
                <li><a>首页</a><i></i></li>
                <li><a>采购管理单</a><i></i></li>
                <li><a>供应商管理单</a><i></i></li>
            </ul>
        </div>
        <div class="nav_dropdown nav_dr2">
            <i class="pic3"></i>
            <ul>
                <li><a>库存查询</a><i></i></li>
                <li><a>新增入库</a><i></i></li>
            </ul>
        </div>
    </div>
</asp:Content>
