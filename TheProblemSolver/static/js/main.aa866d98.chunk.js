(window.webpackJsonp=window.webpackJsonp||[]).push([[0],[,,,,function(e,t,a){e.exports={loading:"Loading_loading__3inxq",spinner:"Loading_spinner__2tnRw"}},function(e,t,a){e.exports=a(16)},,,,,,,function(e,t,a){},,,function(e,t,a){},function(e,t,a){"use strict";a.r(t);var n=a(0),r=a.n(n),l=a(2),i=a.n(l),c=(a(11),a(12),a(3)),o=a.n(c),m=function(e){var t=e.article,a=e.month,n=e.prevMonth;return r.a.createElement(r.a.Fragment,null,n===a?r.a.createElement("span",{className:"timeline-label"}):r.a.createElement("span",{className:"timeline-label"},r.a.createElement("span",{className:"label label-primary"},a)),r.a.createElement("div",{className:"timeline-item"},r.a.createElement("div",{className:"timeline-point timeline-point-blank"},r.a.createElement("i",{className:"fa fa-money"})),r.a.createElement("div",{className:"timeline-event"},r.a.createElement("div",{className:"timeline-heading"},r.a.createElement("a",{href:t.link,target:"_article"},r.a.createElement("h4",null,t.title))),r.a.createElement("div",{className:"timeline-footer"},r.a.createElement("p",{className:"text-right"},0===t.author.indexOf("@")?r.a.createElement("a",{href:"https://twitter.com/".concat(t.author),target:"_twitter"},t.author):r.a.createElement(r.a.Fragment,null,t.author))))))},s=(a(15),function(e){var t=e.articles,a="";return r.a.createElement("div",{className:"timeline"},t.map(function(e,t){var n=function(e){return"".concat(e.getMonth()+1,"-").concat(e.getFullYear())}(new Date(e.date)),l=r.a.createElement(m,{key:t,article:e,month:n,prevMonth:a});return a=n,l}))}),u=a(4),d=a.n(u),E=function(){return r.a.createElement("div",{className:d.a.loading})},h=function(){var e=o()("http://theproblemsolver.nl/api/react"),t=e.data,a=e.loading,n=e.error;return n?r.a.createElement("div",null,"Error: ",n.message):a||!t?r.a.createElement(E,null):r.a.createElement(s,{articles:t})},p=function(){return r.a.createElement("div",{className:"container"},r.a.createElement("h3",{className:"title",style:{fontWeight:700}},"React reading list"),r.a.createElement(h,null))};Boolean("localhost"===window.location.hostname||"[::1]"===window.location.hostname||window.location.hostname.match(/^127(?:\.(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)){3}$/));i.a.render(r.a.createElement(p,null),document.getElementById("root")),"serviceWorker"in navigator&&navigator.serviceWorker.ready.then(function(e){e.unregister()})}],[[5,1,2]]]);
//# sourceMappingURL=main.aa866d98.chunk.js.map