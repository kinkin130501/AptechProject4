#pragma checksum "E:\FPT-Aptech\Project Sem4\FourN-final\FourN-final\FourN-20-7-2021\C#Project\Partner\Views\UserExamination\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d083b440f165d45eced22e20d43008f4699a2bf2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_UserExamination_Index), @"mvc.1.0.view", @"/Views/UserExamination/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d083b440f165d45eced22e20d43008f4699a2bf2", @"/Views/UserExamination/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"53a1f87bb51e19b0bda39ed97d9e7ff4998c32d9", @"/Views/_ViewImports.cshtml")]
    public class Views_UserExamination_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<UserExaminationDisplayModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "0", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_IndexPartial", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "E:\FPT-Aptech\Project Sem4\FourN-final\FourN-final\FourN-20-7-2021\C#Project\Partner\Views\UserExamination\Index.cshtml"
  
    ViewData["Title"] = "Examination Management";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div class=""container"">
    <div style=""margin-top:15px"" class=""container subMenu"">
        <div class=""container row mt-3"">

            <div class=""col-md-10"">
                <div class=""col-md-12 child-inline row"">
                    <div class=""col-md-6"">
                        <input class=""form-control"" id=""TxtSearch"" placeholder=""Enter Email"" />
                    </div>
                    <div class=""col-md-6 mt-1"">
                        <select id=""ResultStatus"" class=""form-control select2"">
                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d083b440f165d45eced22e20d43008f4699a2bf25866", async() => {
                WriteLiteral("All result");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d083b440f165d45eced22e20d43008f4699a2bf27055", async() => {
                WriteLiteral("Passed");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 17 "E:\FPT-Aptech\Project Sem4\FourN-final\FourN-final\FourN-20-7-2021\C#Project\Partner\Views\UserExamination\Index.cshtml"
                                WriteLiteral((int)ResultEnum.Vuot);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d083b440f165d45eced22e20d43008f4699a2bf28751", async() => {
                WriteLiteral("Failed");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 18 "E:\FPT-Aptech\Project Sem4\FourN-final\FourN-final\FourN-20-7-2021\C#Project\Partner\Views\UserExamination\Index.cshtml"
                                WriteLiteral((int)ResultEnum.KhongVuot);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                        </select>
                    </div>
                </div>
            </div>

            <div class=""col-md-2 p-3 mt-4"">
                <div class=""col-md-12"">
                    <div class=""form-group"">
                        <button class=""btn btn-primary"" id=""btnFilter"">Filter</button>
                    </div>
                </div>
            </div>
        </div>
    </div>

");
#nullable restore
#line 34 "E:\FPT-Aptech\Project Sem4\FourN-final\FourN-final\FourN-20-7-2021\C#Project\Partner\Views\UserExamination\Index.cshtml"
     if (Model.UserExaminations.Any())
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div id=\"IndexPartial\" style=\"display:block; margin-top:15px\">\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "d083b440f165d45eced22e20d43008f4699a2bf211215", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
#nullable restore
#line 37 "E:\FPT-Aptech\Project Sem4\FourN-final\FourN-final\FourN-20-7-2021\C#Project\Partner\Views\UserExamination\Index.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model = Model.UserExaminations;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("model", __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n        </div> ");
#nullable restore
#line 38 "E:\FPT-Aptech\Project Sem4\FourN-final\FourN-final\FourN-20-7-2021\C#Project\Partner\Views\UserExamination\Index.cshtml"
               }
                    else
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div id=\"IndexPartial\" style=\"display:block; margin-top:15px\">\n            <div class=\"text-center\" style=\"color:brown\">\n                <h2>Not Examination</h2>\n            </div>\n        </div>\n");
#nullable restore
#line 46 "E:\FPT-Aptech\Project Sem4\FourN-final\FourN-final\FourN-20-7-2021\C#Project\Partner\Views\UserExamination\Index.cshtml"
     }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</div>


<script>

    function showAll() {
        $.ajax({
            url: ""/UserExamination/IndexPartial"",
            method: ""get"",
            success: function (res) {
                $(""#IndexPartial"").html("""");
                $(""#IndexPartial"").html(res.html);
                $("".subMenu"").show();
            },
        })
    }

    function showDetails(userExamId) {
        $.ajax({
            url: ""/UserExamination/Details"",
            type: ""get"",
            data: {
                userExamId: userExamId,
            },
            success: function (res) {
                $(""#IndexPartial"").html("""");
                $(""#IndexPartial"").html(res.html);
                $("".subMenu"").hide();
            },
            error: function () {
                toastr.error("""");
            }
        });
    }



    $(""#btnFilter"").off().click(function () {
        var dateStart = $(""#txtDateStart"").val();
        var dateEnd = $(""#txtDateEnd"").val();
        var examType = $(""#ExamType"").val();
    ");
            WriteLiteral(@"    var txtSearch = $(""#TxtSearch"").val();
        var resultStatus = $(""#ResultStatus"").val();

        $.ajax({
            url: ""/UserExamination/SearchUserExaminations"",
            method: ""POST"",
            data: {
                ExamType: examType,
                DateStart: dateStart,
                DateEnd: dateEnd,
                TxtSearch: txtSearch,
                ResultStatus: resultStatus
            },
            success: function (res) {
                $(""#IndexPartial"").html("""");
                $(""#IndexPartial"").html(res.html);
                $("".subMenu"").show();
            },
        })
    })
</script>

");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<UserExaminationDisplayModel> Html { get; private set; }
    }
}
#pragma warning restore 1591