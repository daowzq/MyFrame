(function(c){c.Zebra_DatePicker=function(H,x){var U={always_show_clear:!1,always_visible:!1,days:"日,一,二,三,四,五,六".split(","),direction:0,disabled_dates:!1,first_day_of_week:1,format:"Y-m-d",lang_clear_date:"清空",months:"一月,二月,三月,四月,五月,六月,七月,八月,九月,十月,十一月,十二月".split(","),offset:[20,-5],inside:!0,readonly_element:!0,show_week_number:!1,start_date:!1,view:"days",weekend_days:[0,6]},k,f,r,s,u,y,z,B,L,I,P,j,n,t,o,g,F,C,D,J,G,q,w,M,N,Q,b=this;b.settings={};var A=c(H);b.hide=function(){b.settings.always_visible||(R("hide"),f.css("display","none"))};b.show=function(){k=b.settings.view;var a=V(A.val()||(b.settings.start_date?b.settings.start_date:""));a?(C=a.getMonth(),o=a.getMonth(),D=a.getFullYear(),g=a.getFullYear(),F=a.getDate(),v(p(D,l(C,2),l(F,2)))&&(o=j,g=n)):(o=j,g=n);E();if(b.settings.always_visible)f.css("display","block");else{var a=f.outerWidth(),d=f.outerHeight(),m=r.offset().left+b.settings.offset[0],e=r.offset().top-d+b.settings.offset[1],h=c(window).width(),S=c(window).height(),i=c(window).scrollTop(),K=c(window).scrollLeft();m+a>K+h&&(m=K+h-a);m<K&&(m=K);e+d>i+S&&(e=i+S-d);e<i&&(e=i);f.css({left:m,top:e});f.fadeIn(c.browser.msie&&c.browser.version.match(/^[6-8]/)?0:150,"linear");R()}};var V=function(a){if(""!=c.trim(a)){for(var d=W(b.settings.format.replace(/\s/g,"")),m="d,D,j,l,N,S,w,F,m,M,n,Y,y".split(","),e=[],h=[],g=0;g<m.length;g++)-1<(position=d.indexOf(m[g]))&&e.push({character:m[g],position:position});e.sort(function(a,d){return a.position-d.position});c.each(e,function(a,d){switch(d.character){case"d":h.push("0[1-9]|[12][0-9]|3[01]");break;case"D":h.push("[a-z]{3}");break;case"j":h.push("[1-9]|[12][0-9]|3[01]");break;case"l":h.push("[a-z]+");break;case"N":h.push("[1-7]");break;case"S":h.push("st|nd|rd|th");break;case"w":h.push("[0-6]");break;case"F":h.push("[a-z]+");break;case"m":h.push("0[1-9]|1[012]+");break;case"M":h.push("[a-z]{3}");break;case"n":h.push("[1-9]|1[012]");break;case"Y":h.push("[0-9]{4}");break;case"y":h.push("[0-9]{2}")}});if(h.length&&(e.reverse(),c.each(e,function(a,c){d=d.replace(c.character,"("+h[h.length-a-1]+")")}),h=RegExp("^"+d+"$","ig"),segments=h.exec(a.replace(/\s/g,"")))){var f,l,j,n="Sunday,Monday,Tuesday,Wednesday,Thursday,Friday,Saturday".split(","),o="January,February,March,April,May,June,July,August,September,October,November,December".split(","),p,k=!0;e.reverse();c.each(e,function(a,d){if(!k)return!0;switch(d.character){case"m":case"n":l=i(segments[a+1]);break;case"d":case"j":f=i(segments[a+1]);break;case"D":case"l":case"F":case"M":p="D"==d.character||"l"==d.character?b.settings.days:b.settings.months;k=!1;c.each(p,function(c,b){if(k)return!0;if(segments[a+1].toLowerCase()==b.substring(0,"D"==d.character||"M"==d.character?3:b.length).toLowerCase()){switch(d.character){case"D":segments[a+1]=n[c].substring(0,3);break;case"l":segments[a+1]=n[c];break;case"F":segments[a+1]=o[c];l=c+1;break;case"M":segments[a+1]=o[c].substring(0,3),l=c+1}k=!0}});break;case"Y":j=i(segments[a+1]);break;case"y":j="19"+i(segments[a+1])}});if(k&&(a=new Date(j,(l||1)-1,f||1),a.getFullYear()==j&&a.getDate()==(f||1)&&a.getMonth()==(l||1)-1))return a}return!1}},X=function(a){c.browser.mozilla?a.css("MozUserSelect","none"):c.browser.msie?a.bind("selectstart",function(){return!1}):a.mousedown(function(){return!1})},W=function(a){return a.replace(/([-.*+?^${}()|[\]\/\\])/g,"\\$1")},Y=function(a){for(var d="",c=a.getDate(),e=a.getDay(),h=b.settings.days[e],g=a.getMonth()+1,i=b.settings.months[g-1],a=a.getFullYear()+"",f=0;f<b.settings.format.length;f++){var j=b.settings.format.charAt(f);switch(j){case"y":a=a.substr(2);case"Y":d+=a;break;case"m":g=l(g,2);case"n":d+=g;break;case"M":i=i.substr(0,3);case"F":d+=i;break;case"d":c=l(c,2);case"j":d+=c;break;case"D":h=h.substr(0,3);case"l":d+=h;break;case"N":e++;case"w":d+=e;break;case"S":d=1==c%10&&"11"!=c?d+"st":2==c%10&&"12"!=c?d+"nd":3==c%10&&"13"!=c?d+"rd":d+"th";break;default:d+=j}}return d},T=function(){var a=(new Date(g,o+1,0)).getDate(),d=(new Date(g,o,1)).getDay(),m=(new Date(g,o,0)).getDate(),d=d-b.settings.first_day_of_week,d=0>d?7+d:d;O(b.settings.months[o]+", "+g);var e="<tr>";b.settings.show_week_number&&(e+="<th>"+b.settings.show_week_number+"</th>");for(var h=0;7>h;h++)e+="<th>"+b.settings.days[(b.settings.first_day_of_week+h)%7].substr(0,2)+"</th>";e+="</tr><tr>";for(h=0;42>h;h++){0<h&&0==h%7&&(e+="</tr><tr>");if(0==h%7&&b.settings.show_week_number)var f=new Date(g,o,h),f=Math.ceil(((f-new Date(g,0,1))/864E5+f.getDay()+1)/7),e=e+('<td class="dp_week_number">'+f+"</td>");f=h-d+1;if(h<d)e+='<td class="dp_not_in_month">'+(m-d+h+1)+"</td>";else if(f>a)e+='<td class="dp_not_in_month">'+(f-a)+"</td>";else{var j=(b.settings.first_day_of_week+h)%7,n=i(p(g,l(o,2),l(f,2))),k="";v(n)?k=-1<c.inArray(j,b.settings.weekend_days)?"dp_weekend_disabled":k+" dp_disabled":(-1<c.inArray(j,b.settings.weekend_days)&&(k="dp_weekend"),o==C&&g==D&&F==f&&(k+=" dp_selected"),o==L&&g==I&&P==f&&(k+=" dp_current"));e+="<td"+(""!=k?' class="'+c.trim(k)+'"':"")+">"+l(f,2)+"</td>"}}u.html(c(e+"</tr>"));b.settings.always_visible&&(Q=c("td:not(.dp_disabled, .dp_weekend_disabled, .dp_not_in_month, .dp_blocked, .dp_week_number)",u));u.css("display","")},R=function(a){if(c.browser.msie&&c.browser.version.match(/^6/)){if(!G){var d=i(f.css("zIndex"))-1;G=jQuery("<iframe>",{src:'javascript:document.write("")',scrolling:"no",frameborder:0,allowtransparency:"true",css:{zIndex:d,position:"absolute",top:-1E3,left:-1E3,width:f.outerWidth(),height:f.outerHeight(),filter:"progid:DXImageTransform.Microsoft.Alpha(opacity=0)",display:"none"}});c("body").append(G)}switch(a){case"hide":G.css("display","none");break;default:a=f.offset(),G.css({top:a.top,left:a.left,display:"block"})}}},v=function(a){if(0!==q){var d=(a+"").length;if(8==d&&(q&&(a<p(n,l(j,2),l(t,2))||"undefined"!=typeof w&&a>w)||!q&&(a>p(n,l(j,2),l(t,2))||"undefined"!=typeof w&&a<w))||6==d&&(q&&(a<p(n,l(j,2))||"undefined"!=typeof w&&a>N)||!q&&(a>p(n,l(j,2))||"undefined"!=typeof w&&a<N))||4==d&&(q&&(a<n||"undefined"!=typeof w&&a>M)||!q&&(a>n||"undefined"!=typeof w&&a<M)))return!0}if(J){var a=a+"",b=i(a.substr(0,4)),e=i(a.substr(4,2))+1,h=i(a.substr(6,2)),f=!1;c.each(J,function(){if(!f&&(-1<c.inArray(b,this[2])||-1<c.inArray("*",this[2])))if(void 0!=e&&-1<c.inArray(e,this[1])||-1<c.inArray("*",this[1]))if(void 0!=h&&-1<c.inArray(h,this[0])||-1<c.inArray("*",this[0])){if("*"==this[3])return f=!0;var a=(new Date(b,e-1,h)).getDay();if(-1<c.inArray(a,this[3]))return f=!0}});if(f)return!0}return!1},O=function(a){c(".dp_caption",s).html(a);if(0!==q){var a=g,d=o,b,e;"days"==k?(e=0>d-1?p(a-1,11):p(a,l(d-1,2)),b=11<d+1?p(a+1,"00"):p(a,l(d+1,2))):"months"==k?(e=a-1,b=a+1):"years"==k&&(e=a-7,b=a+7);v(e)?(c(".dp_previous",s).addClass("dp_blocked"),c(".dp_previous",s).removeClass("dp_hover")):c(".dp_previous",s).removeClass("dp_blocked");v(b)?(c(".dp_next",s).addClass("dp_blocked"),c(".dp_next",s).removeClass("dp_hover")):c(".dp_next",s).removeClass("dp_blocked")}},E=function(){if(""==u.text()||"days"==k){if(""==u.text()){b.settings.always_visible||f.css("left",-1E3);f.css({display:"block"});T();var a=u.outerWidth(),d=u.outerHeight();s.css("width",a);y.css({width:a,height:d});z.css({width:a,height:d});B.css("width",a);f.css({display:"none"})}else T();y.css("display","none");z.css("display","none")}else if("months"==k){O(g);a="<tr>";for(d=0;12>d;d++){0<d&&0==d%3&&(a+="</tr><tr>");var m="dp_month_"+d,e=i(p(g,l(d,2)));v(e)?m+=" dp_disabled":!1!==C&&C==d?m+=" dp_selected":L==d&&I==g&&(m+=" dp_current");a+='<td class="'+c.trim(m)+'">'+b.settings.months[d].substr(0,3)+"</td>"}y.html(c(a+"</tr>"));b.settings.always_visible&&c("td:not(.dp_disabled)",y);y.css("display","");u.css("display","none");z.css("display","none")}else if("years"==k){O(g-7+" - "+(g+4));a="<tr>";for(d=0;12>d;d++)0<d&&0==d%3&&(a+="</tr><tr>"),m="",e=i(g-7+d),v(e)?m+=" dp_disabled":D&&D==g-7+d?m+=" dp_selected":I==g-7+d&&(m+=" dp_current"),a+="<td"+(""!=c.trim(m)?' class="'+c.trim(m)+'"':"")+">"+(g-7+d)+"</td>";z.html(c(a+"</tr>"));b.settings.always_visible&&c("td:not(.dp_disabled)",z);z.css("display","");u.css("display","none");y.css("display","none")}(b.settings.always_show_clear||b.settings.always_visible||""!=A.val())&&"block"!=B.css("display")?B.css("display",""):B.css("display","none")},l=function(a,d){for(a+="";a.length<d;)a="0"+a;return a},p=function(){for(var a="",d=0;d<arguments.length;d++)a+=arguments[d]+"";return a},i=function(a){return parseInt(!0===a||!1===a?0:a,10)};b._keyup=function(a){("block"==f.css("display")||27==a.which)&&b.hide();return!0};b._mousedown=function(a){if("block"==f.css("display")){if(c(a.target).get(0)===r.get(0))return!0;0==c(a.target).parents().filter(".Zebra_DatePicker").length&&b.hide()}return!0};(function(){b.settings=c.extend({},U,x);b.settings.readonly_element&&A.attr("readonly","readonly");if(!b.settings.always_visible){var a;r=c('<button type="button" class="Zebra_DatePicker_Icon">Pick a date</button>');b.icon=r}q=!c.isArray(b.settings.direction)&&(!0===b.settings.direction||0<i(b.settings.direction))||c.isArray(b.settings.direction)&&2==b.settings.direction.length&&(!0===b.settings.direction[0]||0<i(b.settings.direction[0]))?!0:!c.isArray(b.settings.direction)&&(!1===b.settings.direction||0>i(b.settings.direction))||c.isArray(b.settings.direction)&&2==b.settings.direction.length&&(!1===b.settings.direction[0]||0>i(b.settings.direction[0]))?!1:0;a=new Date;j=a.getMonth();L=a.getMonth();n=a.getFullYear();I=a.getFullYear();t=a.getDate();P=a.getDate();0!==q&&(a=new Date(n,j,t+i(c.isArray(b.settings.direction)?b.settings.direction[0]:b.settings.direction)),j=a.getMonth(),n=a.getFullYear(),t=a.getDate());0!==q&&c.isArray(b.settings.direction)&&2==b.settings.direction.length&&(a=new Date(n,j,t+(0<q?1:-1)*i(b.settings.direction[1])),w=i(p(a.getFullYear(),l(a.getMonth(),2),l(a.getDate(),2))),N=i(p(a.getFullYear(),l(a.getMonth(),2))),M=i(p(a.getFullYear())));if(v(p(n,l(j,2),l(t,2)))){for(;v(n);)q?n++:n--,j=0;for(;v(p(n,l(j,2)));)q?j++:j--,11<j?(n++,j=0):0>j&&(n--,j=0),t=1;for(;v(p(n,l(j,2),l(t,2)));)q?t++:t--,a=new Date(n,j,t),n=a.getFullYear(),j=a.getMonth(),t=a.getDate()}b.settings.always_visible||((b.settings.readonly_element?r.add(A):r).bind("click",function(a){a.preventDefault();f.css("display")!="none"?b.hide():b.show()}),r.insertAfter(H),b.settings.inside&&(r.addClass("Zebra_DatePicker_Icon_Inside"),a=r.outerWidth(!0),r.outerHeight(!0),r.css({left:-a,top:r.outerHeight(!0)-r.height()})));a='<div class="Zebra_DatePicker"><table class="dp_header"><tr><td class="dp_previous">&laquo;</td><td class="dp_caption">&nbsp;</td><td class="dp_next">&raquo;</td></tr></table><table class="dp_daypicker"></table><table class="dp_monthpicker"></table><table class="dp_yearpicker"></table><table class="dp_footer"><tr><td>'+b.settings.lang_clear_date+"</td></tr></table></div>";f=c(a);b.datepicker=f;s=c("table.dp_header",f);u=c("table.dp_daypicker",f);y=c("table.dp_monthpicker",f);z=c("table.dp_yearpicker",f);B=c("table.dp_footer",f);b.settings.always_visible?(b.settings.always_visible.append(f),b.show()):c("body").append(f);f.delegate("td:not(.dp_disabled, .dp_weekend_disabled, .dp_not_in_month, .dp_blocked, .dp_week_number)","mouseover",function(){c(this).addClass("dp_hover")}).delegate("td:not(.dp_disabled, .dp_weekend_disabled, .dp_not_in_month, .dp_blocked, .dp_week_number)","mouseout",function(){c(this).removeClass("dp_hover")});X(c("td",s));c(".dp_previous",s).bind("click",function(){if(!c(this).hasClass("dp_blocked")){if(k=="months")g--;else if(k=="years")g=g-12;else if(--o<0){o=11;g--}E()}});c(".dp_caption",s).bind("click",function(){k=k=="days"?"months":k=="months"?"years":"days";E()});c(".dp_next",s).bind("click",function(){if(!c(this).hasClass("dp_blocked")){if(k=="months")g++;else if(k=="years")g=g+12;else if(++o==12){o=0;g++}E()}});u.delegate("td:not(.dp_disabled, .dp_weekend_disabled, .dp_not_in_month, .dp_week_number)","click",function(){var a=new Date(g,o,i(c(this).html()));A.val(Y(a));if(b.settings.always_visible){C=a.getMonth();o=a.getMonth();D=a.getFullYear();g=a.getFullYear();F=a.getDate();Q.removeClass("dp_selected");c(this).addClass("dp_selected")}b.hide()});y.delegate("td:not(.dp_disabled)","click",function(){var a=c(this).attr("class").match(/dp\_month\_([0-9]+)/);o=i(a[1]);k="days";b.settings.always_visible&&A.val("");E()});z.delegate("td:not(.dp_disabled)","click",function(){g=i(c(this).html());k="months";b.settings.always_visible&&A.val("");E()});c("td",B).bind("click",function(a){a.preventDefault();A.val("");if(!b.settings.always_visible){g=o=D=C=F=null;B.css("display","none")}b.hide()});b.settings.always_visible||c(document).bind({mousedown:b._mousedown,keyup:b._keyup});J=[];E()})()};c.fn.Zebra_DatePicker=function(H){return this.each(function(){if(void 0!=c(this).data("Zebra_DatePicker")){var x=c(this).data("Zebra_DatePicker");x.icon.remove();x.datepicker.remove();c(document).unbind("keyup",x._keyup);c(document).unbind("mousedown",x._mousedown)}x=new c.Zebra_DatePicker(this,H);c(this).data("Zebra_DatePicker",x)})}})(jQuery);