<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="filesqueue.aspx.cs" Inherits="HDFrame.SysModule.upload.filesqueue" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>多文件上传</title>

    <link href="../../Js/plupload/jquery.plupload.queue/css/jquery.plupload.queue.css" rel="stylesheet" />
    <script type="text/javascript" src="../../Js/plupload/browserplus.js"></script>
    <script type="text/javascript" src="../../Js/jquery-1.4.1.min.js"></script>

    <!-- Load plupload and all it's runtimes and finally the jQuery queue widget -->
    <script type="text/javascript" src="../../Js/plupload/plupload.full.js"></script>
    <script type="text/javascript" src="../../Js/plupload/jquery.plupload.queue/jquery.plupload.queue.js"></script>

    <script type="text/javascript">
        // Convert divs to queue widgets when the DOM is ready
        $(function () {
            $("#uploader").pluploadQueue({
                // General settings
                runtimes: 'gears,flash,silverlight,browserplus,html5', // 这里是说用什么技术引擎
                url: '../uploadFiles.ashx', // 服务端上传路径
                max_file_size: '10mb', // 文件上传最大限制。
                chunk_size: '1mb', // 上传分块每块的大小，这个值小于服务器最大上传限制的值即可。
                unique_names: true, // 上传的文件名是否唯一

                // Resize images on clientside if we can
                //// 是否生成缩略图（仅对图片文件有效）
                resize: { width: 320, height: 240, quality: 90 },

                // Specify what files to browse for
                ////  这个数组是选择器，就是上传文件时限制的上传文件类型
                filters: [
                    { title: "Image files", extensions: "jpg,gif,png,bmp" },
                    { title: "Zip files", extensions: "zip,rar,7z" }
                ],

                // Flash settings
                // plupload.flash.swf 的所在路径
                flash_swf_url: '../../Js/plupload/plupload.flash.swf',

                // Silverlight settings
                // silverlight所在路径
                silverlight_xap_url: '../../Js/plupload/plupload.silverlight.xap'
            });

            // Client side form validation
            // 这一块主要是防止在上传未结束前表带提交，具体大家可酌情修改编写 
            $('form').submit(function (e) {
                var uploader = $('#uploader').pluploadQueue();

                // Files in queue upload them first
                if (uploader.files.length > 0) {
                    // When all files are uploaded submit form
                    uploader.bind('StateChanged', function () {
                        if (uploader.files.length === (uploader.total.uploaded + uploader.total.failed)) {
                            $('form')[0].submit();
                        }
                    });

                    uploader.start();
                } else {
                    alert('You must queue at least one file.');
                }

                return false;
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <div id="uploader">
            <p>You browser doesn't have Flash, Silverlight, Gears, BrowserPlus or HTML5 support.</p>
        </div>
    </form>
</body>
</html>
