#pragma checksum "E:\FPT-Aptech\Project Sem4\FourN-final\FourN-final\FourN-20-7-2021\C#Project\FourN.AdminSite\Areas\ProjectManagement\Views\Project\Error.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fb08b222739a98c2b5c790f4070c0bf94a83b2ed"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(FourN.AdminSite.Pages.Project.Areas_ProjectManagement_Views_Project_Error), @"mvc.1.0.view", @"/Areas/ProjectManagement/Views/Project/Error.cshtml")]
namespace FourN.AdminSite.Pages.Project
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
#line 1 "E:\FPT-Aptech\Project Sem4\FourN-final\FourN-final\FourN-20-7-2021\C#Project\FourN.AdminSite\Areas\ProjectManagement\Views\_ViewImports.cshtml"
using FourN.AdminSite;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\FPT-Aptech\Project Sem4\FourN-final\FourN-final\FourN-20-7-2021\C#Project\FourN.AdminSite\Areas\ProjectManagement\Views\_ViewImports.cshtml"
using FourN.Data.ViewModel;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "E:\FPT-Aptech\Project Sem4\FourN-final\FourN-final\FourN-20-7-2021\C#Project\FourN.AdminSite\Areas\ProjectManagement\Views\_ViewImports.cshtml"
using FourN.AdminSite.Helper;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "E:\FPT-Aptech\Project Sem4\FourN-final\FourN-final\FourN-20-7-2021\C#Project\FourN.AdminSite\Areas\ProjectManagement\Views\_ViewImports.cshtml"
using static FourN.Data.SystemEnum;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fb08b222739a98c2b5c790f4070c0bf94a83b2ed", @"/Areas/ProjectManagement/Views/Project/Error.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ec10d1bee53f2f01598187629fa9100b0a45a17f", @"/Areas/ProjectManagement/Views/_ViewImports.cshtml")]
    public class Areas_ProjectManagement_Views_Project_Error : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<div class=""content-wrapper"">
    <div class=""content-header"">
        <div style=""margin: 100px;"" class=""container-fluid"">
            <div class=""col-sm-3""></div>
            <div class=""col-sm-6"">
                <h1 style=""color: red"" class=""m-0"">SORRY !!!</h1>
            </div>

            <br />
            <br />
            <h3 class=""m-0"">
                You must not delete this project
            </h3>
            <h3>
                Because there are <b style=""color: red"">STILL SOME TASKS</b> in this project
            </h3>
        </div><!-- /.col -->
        <div class=""col-sm-3""></div><!-- /.row -->
    </div><!-- /.container-fluid -->
</div>
</div>");
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
