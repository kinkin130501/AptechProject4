#pragma checksum "E:\FPT-Aptech\Project Sem4\FourN-final\FourN-final\FourN-20-7-2021\C#Project\Partner\Views\Partner\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0f330f2d152641b9c8d3d48514c8741f8d9417a5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Partner_Index), @"mvc.1.0.view", @"/Views/Partner/Index.cshtml")]
namespace AspNetCore
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
#line 1 "E:\FPT-Aptech\Project Sem4\FourN-final\FourN-final\FourN-20-7-2021\C#Project\Partner\Views\_ViewImports.cshtml"
using Partner;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\FPT-Aptech\Project Sem4\FourN-final\FourN-final\FourN-20-7-2021\C#Project\Partner\Views\_ViewImports.cshtml"
using Partner.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "E:\FPT-Aptech\Project Sem4\FourN-final\FourN-final\FourN-20-7-2021\C#Project\Partner\Views\_ViewImports.cshtml"
using FourN.Data.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "E:\FPT-Aptech\Project Sem4\FourN-final\FourN-final\FourN-20-7-2021\C#Project\Partner\Views\_ViewImports.cshtml"
using FourN.Data.ViewModel;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "E:\FPT-Aptech\Project Sem4\FourN-final\FourN-final\FourN-20-7-2021\C#Project\Partner\Views\_ViewImports.cshtml"
using Partner.Helper;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "E:\FPT-Aptech\Project Sem4\FourN-final\FourN-final\FourN-20-7-2021\C#Project\Partner\Views\_ViewImports.cshtml"
using FourN.Data.EnumModel;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "E:\FPT-Aptech\Project Sem4\FourN-final\FourN-final\FourN-20-7-2021\C#Project\Partner\Views\_ViewImports.cshtml"
using static FourN.Data.SystemEnum;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0f330f2d152641b9c8d3d48514c8741f8d9417a5", @"/Views/Partner/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"53a1f87bb51e19b0bda39ed97d9e7ff4998c32d9", @"/Views/_ViewImports.cshtml")]
    public class Views_Partner_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<DepartmentViewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "E:\FPT-Aptech\Project Sem4\FourN-final\FourN-final\FourN-20-7-2021\C#Project\Partner\Views\Partner\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"container mb-5 mt-2\">\r\n    <div class=\"row\">\r\n");
#nullable restore
#line 8 "E:\FPT-Aptech\Project Sem4\FourN-final\FourN-final\FourN-20-7-2021\C#Project\Partner\Views\Partner\Index.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"col-sm-4\" style=\"padding-top:10px;\">\r\n                <div class=\"card\" style=\"width: 350px;\">\r\n                    <a href=\"#\">\r\n                        <img class=\"card-img-top\"");
            BeginWriteAttribute("src", " src=\"", 398, "\"", 415, 1);
#nullable restore
#line 13 "E:\FPT-Aptech\Project Sem4\FourN-final\FourN-final\FourN-20-7-2021\C#Project\Partner\Views\Partner\Index.cshtml"
WriteAttributeValue("", 404, item.Image, 404, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" style=\"width: 350px; height: 165px\" alt=\"Card image cap\" />\r\n                    </a>\r\n                    <div class=\"card-body\" style=\"height: 315px\">\r\n                        <a");
            BeginWriteAttribute("href", " href=\"", 597, "\"", 629, 2);
            WriteAttributeValue("", 604, "Detail/", 604, 7, true);
#nullable restore
#line 16 "E:\FPT-Aptech\Project Sem4\FourN-final\FourN-final\FourN-20-7-2021\C#Project\Partner\Views\Partner\Index.cshtml"
WriteAttributeValue("", 611, item.DepartmentId, 611, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><h5 class=\"card-title\">");
#nullable restore
#line 16 "E:\FPT-Aptech\Project Sem4\FourN-final\FourN-final\FourN-20-7-2021\C#Project\Partner\Views\Partner\Index.cshtml"
                                                                              Write(item.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5></a>\r\n                        <p class=\"card-text\">");
#nullable restore
#line 17 "E:\FPT-Aptech\Project Sem4\FourN-final\FourN-final\FourN-20-7-2021\C#Project\Partner\Views\Partner\Index.cshtml"
                                        Write(Html.Raw(item.ShortDesc));

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                    </div>\r\n                    <div class=\"card-body\">\r\n                    </div>\r\n                </div>\r\n            </div>\r\n");
#nullable restore
#line 23 "E:\FPT-Aptech\Project Sem4\FourN-final\FourN-final\FourN-20-7-2021\C#Project\Partner\Views\Partner\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<DepartmentViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
