(window.webpackJsonp=window.webpackJsonp||[]).push([[0],{15:function(e,t,a){},18:function(e,t,a){},22:function(e,t,a){"use strict";a.r(t);var n=a(0),r=a.n(n),l=a(5),i=a.n(l),c=(a(14),a(15),a(6)),o=a.n(c),m=a(1),s=a.n(m),u=function(e){var t=e.article,a=e.month,n=e.prevMonth;return r.a.createElement(r.a.Fragment,null,n===a?r.a.createElement("span",{className:"timeline-label"}):r.a.createElement("span",{className:"timeline-label"},r.a.createElement("span",{className:"label label-primary"},a)),r.a.createElement("div",{className:"timeline-item"},r.a.createElement("div",{className:"timeline-point timeline-point-blank"},r.a.createElement("i",{className:"fa fa-money"})),r.a.createElement("div",{className:"timeline-event"},r.a.createElement("div",{className:"timeline-heading"},r.a.createElement("a",{href:t.link,target:"_article"},r.a.createElement("h4",null,t.title))),r.a.createElement("div",{className:"timeline-footer"},r.a.createElement("p",{className:"text-right"},0===t.author.indexOf("@")?r.a.createElement("a",{href:"https://twitter.com/".concat(t.author),target:"_twitter"},t.author):r.a.createElement(r.a.Fragment,null,t.author))))))},d=(a(18),function(e){var t=e.articles,a="";return r.a.createElement("div",{className:"timeline"},t.map(function(e,t){var n=function(e){return"".concat(e.getMonth()+1,"-").concat(e.getFullYear())}(new Date(e.date)),l=r.a.createElement(u,{key:t,article:e,month:n,prevMonth:a});return a=n,l}))}),h=a(7),E=a.n(h),p=function(){return r.a.createElement("div",{className:E.a.loading})},f=s.a.withTracking(function(){var e=o()("http://theproblemsolver.nl/api/react"),t=e.data,a=e.loading,n=e.error;return n?r.a.createElement("div",null,"Error: ",n.message):a||!t?r.a.createElement(p,null):r.a.createElement(d,{articles:t})},"ArticleListContainer"),g=function(){return r.a.createElement("div",{className:"container"},r.a.createElement("h3",{className:"title",style:{fontWeight:700}},"React reading list"),r.a.createElement(f,null))};Boolean("localhost"===window.location.hostname||"[::1]"===window.location.hostname||window.location.hostname.match(/^127(?:\.(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)){3}$/));s.a.init({instrumentationKey:"3ce103f9-2356-4dae-b601-962c513443d8"}),s.a.setAppContext({urlReferrer:document.referrer}),i.a.render(r.a.createElement(g,null),document.getElementById("root")),"serviceWorker"in navigator&&navigator.serviceWorker.ready.then(function(e){e.unregister()})},7:function(e,t,a){e.exports={loading:"Loading_loading__3inxq",spinner:"Loading_spinner__2tnRw"}},8:function(e,t,a){e.exports=a(22)}},[[8,1,2]]]);
//# sourceMappingURL=main.7002e553.chunk.js.map