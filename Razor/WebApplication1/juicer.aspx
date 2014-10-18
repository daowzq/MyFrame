<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="juicer.aspx.cs" Inherits="WebApplication1.juicer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<script src="SurveyUI/juicer.js"></script>
<script src="SurveyUI/jquery_1.10.2.min.js"></script>
<script id="tpl" type="text/template">
    <ul>
        {@each list as it,index}
            <li>${it.name} (index: ${index})</li>
        {@/each}
        {@each blah as it}
            <li>
                num: ${it.num} <br />
                {@if it.num==3}
                    {@each it.inner as it2}
                        ${it2.time} <br />
                    {@/each}
                {@/if}
            </li>
        {@/each}
    </ul>
</script>
<script type="text/javascript">
    var data = {
        list: [
            { name: ' guokai', show: true },
            { name: ' benben', show: false },
            { name: ' dierbaby', show: true }
        ],
        blah: [
            { num: 1 },
            { num: 2 },
            {
                num: 3, inner: [
                   { 'time': '15:00' },
                   { 'time': '16:00' },
                   { 'time': '17:00' },
                   { 'time': '18:00' }
                ]
            },
            { num: 4 }
        ]
    };

    var tpl = document.getElementById('tpl').innerHTML;
    var html = juicer(tpl, data);

</script>
<body>
    <script type="text/javascript">
        $("body").append(html);
    </script>

</body>
