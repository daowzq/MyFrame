<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="HDFrame.Home" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01//EN" "http://www.w3.org/TR/html4/strict.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Pragma" content="no-cache">
    <meta http-equiv="Cache-Control" content="no-cache">
    <meta http-equiv="Expires" content="0">
    <title>Home</title>
    <!-- Ext JS -->
    <%-- <link href="ExtJs/resources/css/ext-all.css" rel="stylesheet" />--%>
    <link href="ExtJs/resources/css/ext-neptune.css" rel="stylesheet" />
    <link href="ExtJs/home/resources/css/sink.css" rel="stylesheet" />
    <script type="text/javascript" src="ExtJs/ext-all-debug.js"></script>
    <script type="text/javascript" src="ExtJs/home/all-classes.js"></script>
    <script type="text/javascript" src="ExtJs/ext-neptune.js"></script>
    <script type="text/javascript">
        Ext.application({
            defaultUrl: "ExtJs/home/",
            name: 'KitchenSink',
            autoCreateViewport: true,
            controllers: [
                'Main'
            ]
        });
    </script>
</head>
<body></body>
</html>
