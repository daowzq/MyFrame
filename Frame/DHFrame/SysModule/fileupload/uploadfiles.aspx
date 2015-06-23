<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="uploadfiles.aspx.cs" Inherits="HDFrame.SysModule.upload.uploadfiles" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">

    <title>多文件上传</title>

    <link href="../../Js/plupload/jquery.ui.plupload/css/jquery.ui.plupload.css" rel="stylesheet" />
    <link href="../../Js/plupload/jquery-ui/jquery-ui.css" rel="stylesheet" />
    <script type="text/javascript" src="../../Js/jquery-1.7.2.min.js"></script>
    <script type="text/javascript" src="../../Js/plupload/jquery-ui/jquery-ui-1.8.22.min.js"></script>
    <script type="text/javascript" src="../../Js/plupload/browserplus.js"></script>
    <script type="text/javascript" src="../../Js/plupload/plupload.full.js"></script>
    <script type="text/javascript" src="../../Js/plupload/i18n/zh-cn.js"></script>
    <script type="text/javascript" src="../../Js/plupload/jquery.ui.plupload/jquery.ui.plupload.js"></script>

    <script type="text/javascript">
        // Convert divs to queue widgets when the DOM is ready
        $(function () {

            var uploader = $("#uploader").plupload({
                // General settings
                runtimes: 'gears,flash,silverlight,browserplus,html5', // 这里是说用什么技术引擎
                url: '../uploadFiles.ashx', // 服务端上传路径
                //url: "http://localhost:2557/photos/UploadPhoto/xxttIMAGE/123456789",
                max_file_size: '300mb', // 文件上传最大限制。
                chunk_size: '8mb', // 上传分块每块的大小，这个值小于服务器最大上传限制的值即可。
                unique_names: true, // 上传的文件名是否唯一

                // Resize images on clientside if we can
                //// 是否生成缩略图（仅对图片文件有效）
                //resize: { width: 320, height: 240, quality: 90 },

                // Specify what files to browse for
                ////  这个数组是选择器，就是上传文件时限制的上传文件类型
                //filters: [{ title: "Zip files", extensions: "zip,rar,7z" },
                //   { title: "Image files", extensions: "jpg,gif,png" }
                //],

                // Flash settings
                // plupload.flash.swf 的所在路径
                flash_swf_url: '../../Js/plupload/plupload.flash.swf',

                // Silverlight settings
                // silverlight所在路径
                silverlight_xap_url: '../../Js/plupload/plupload.silverlight.xap',
                init: {
                    FileUploaded: function (up, file, info) {
                        // Called when file has finished uploading
                        //Info 服务器返回的数据信息
                    }
                }
            });
            // $("span").remove(".ui-icon");
            // Client side form validation
        });
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <div id="uploader" style="width: 600px">
            <p>You browser doesn't have Flash, Silverlight, Gears, BrowserPlus or HTML5 support.</p>
        </div>
    </form>
</body>
</html>

