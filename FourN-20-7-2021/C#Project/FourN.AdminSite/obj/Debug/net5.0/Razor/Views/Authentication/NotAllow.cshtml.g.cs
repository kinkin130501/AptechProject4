#pragma checksum "E:\FPT-Aptech\Project Sem4\FourN-final\FourN-final\FourN-20-7-2021\C#Project\FourN.AdminSite\Views\Authentication\NotAllow.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "caadf7d29617d1446b6affedffa9244ff7d58971"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(FourN.AdminSite.Pages.Authentication.Views_Authentication_NotAllow), @"mvc.1.0.view", @"/Views/Authentication/NotAllow.cshtml")]
namespace FourN.AdminSite.Pages.Authentication
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "E:\FPT-Aptech\Project Sem4\FourN-final\FourN-final\FourN-20-7-2021\C#Project\FourN.AdminSite\Views\_ViewImports.cshtml"
using FourN.AdminSite;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\FPT-Aptech\Project Sem4\FourN-final\FourN-final\FourN-20-7-2021\C#Project\FourN.AdminSite\Views\_ViewImports.cshtml"
using FourN.Data.ViewModel;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "E:\FPT-Aptech\Project Sem4\FourN-final\FourN-final\FourN-20-7-2021\C#Project\FourN.AdminSite\Views\_ViewImports.cshtml"
using FourN.AdminSite.Helper;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"caadf7d29617d1446b6affedffa9244ff7d58971", @"/Views/Authentication/NotAllow.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1675d9f03eda31c1921a03798e9bd970d04b8f71", @"/Views/_ViewImports.cshtml")]
    public class Views_Authentication_NotAllow : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 7 "E:\FPT-Aptech\Project Sem4\FourN-final\FourN-final\FourN-20-7-2021\C#Project\FourN.AdminSite\Views\Authentication\NotAllow.cshtml"
   
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <style>
        .container {
            background: #1b1b1b;
            color: white;
            font-family: ""Bungee"", cursive;
            margin-top: 50px;
            text-align: center;
        }

        a {
            color: #2aa7cc;
            text-decoration: none;
        }

            a:hover {
                color: white;
            }

        svg {
            width: 50vw;
        }

        .lightblue {
            fill: #444;
        }


        #eye-wrap {
            overflow: hidden;
        }

        .error-text {
            font-size: 120px;
        }

        .alarm {
            animation: alarmOn 0.5s infinite;
        }

        ");
            WriteLiteral("@keyframes alarmOn {\r\n            to {\r\n                fill: darkred;\r\n            }\r\n        }\r\n\r\n    </style>\r\n");
            WriteLiteral(@"<div class=""container"">
    <svg xmlns=""http://www.w3.org/2000/svg"" id=""robot-error"" viewBox=""0 0 260 118.9"">
        <defs>
            <clipPath id=""white-clip""><circle id=""white-eye"" fill=""#cacaca"" cx=""130"" cy=""65"" r=""20"" /> </clipPath>
            <text id=""text-s"" class=""error-text"" y=""106""> 403 </text>
        </defs>
        <path class=""alarm"" fill=""#e62326"" d=""M120.9 19.6V9.1c0-5 4.1-9.1 9.1-9.1h0c5 0 9.1 4.1 9.1 9.1v10.6"" />
        <use xlink:href=""#text-s"" x=""-0.5px"" y=""-1px"" fill=""black""></use>
        <use xlink:href=""#text-s"" fill=""#2b2b2b""></use>
        <g id=""robot"">
            <g id=""eye-wrap"">
                <use xlink:href=""#white-eye""></use>
                <circle id=""eyef"" class=""eye"" clip-path=""url(#white-clip)"" fill=""#000"" stroke=""#2aa7cc"" stroke-width=""2"" stroke-miterlimit=""10"" cx=""130"" cy=""65"" r=""11"" />
                <ellipse id=""white-eye"" fill=""#2b2b2b"" cx=""130"" cy=""40"" rx=""18"" ry=""12"" />
            </g>
            <circle class=""lightblue"" cx=""105"" cy=""32"" r");
            WriteLiteral(@"=""2.5"" id=""tornillo"" />
            <use xlink:href=""#tornillo"" x=""50""></use>
            <use xlink:href=""#tornillo"" x=""50"" y=""60""></use>
            <use xlink:href=""#tornillo"" y=""60""></use>
        </g>
    </svg>
    <h1>You are not allowed to enter here</h1>
</div>

    <script>
        
        document.addEventListener(""mousemove"", evt => {
            let x = evt.clientX / innerWidth;
            let y = evt.clientY / innerHeight;

            root.style.setProperty(""--mouse-x"", x);
            root.style.setProperty(""--mouse-y"", y);

            cx = 115 + 30 * x;
            cy = 50 + 30 * y;
            eyef.setAttribute(""cx"", cx);
            eyef.setAttribute(""cy"", cy);

        });

        document.addEventListener(""touchmove"", touchHandler => {
            let x = touchHandler.touches[0].clientX / innerWidth;
            let y = touchHandler.touches[0].clientY / innerHeight;

            root.style.setProperty(""--mouse-x"", x);
            root.style.setProperty(""-");
            WriteLiteral("-mouse-y\", y);\r\n        });\r\n    </script>\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591