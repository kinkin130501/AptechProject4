#pragma checksum "E:\FPT-Aptech\Project Sem4\FourN-final\FourN-final\FourN-20-7-2021\C#Project\Partner\Views\Answer\_IndexNoEdit.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8a1298886a6973355968fc05fddfba36f596201c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Answer__IndexNoEdit), @"mvc.1.0.view", @"/Views/Answer/_IndexNoEdit.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8a1298886a6973355968fc05fddfba36f596201c", @"/Views/Answer/_IndexNoEdit.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"53a1f87bb51e19b0bda39ed97d9e7ff4998c32d9", @"/Views/_ViewImports.cshtml")]
    public class Views_Answer__IndexNoEdit : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ExaminationQuestionsActiveViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "E:\FPT-Aptech\Project Sem4\FourN-final\FourN-final\FourN-20-7-2021\C#Project\Partner\Views\Answer\_IndexNoEdit.cshtml"
  
    int startNumber = 65;
    char prefix;
    var answer = "";
    var ran = new Random();

#line default
#line hidden
#nullable disable
            WriteLiteral("<div>\n\n    <dl class=\"row\">\n        <dt class=\"col-sm-2\">\n            Câu hỏi\n        </dt>\n        <dd class=\"col-sm-10\">\n            ");
#nullable restore
#line 15 "E:\FPT-Aptech\Project Sem4\FourN-final\FourN-final\FourN-20-7-2021\C#Project\Partner\Views\Answer\_IndexNoEdit.cshtml"
       Write(Html.DisplayFor(model => model.Content));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dd>\n        <dt class=\"col-sm-2\">\n            Loại\n        </dt>\n        <dd class=\"col-sm-10\">\n");
#nullable restore
#line 21 "E:\FPT-Aptech\Project Sem4\FourN-final\FourN-final\FourN-20-7-2021\C#Project\Partner\Views\Answer\_IndexNoEdit.cshtml"
              
                var type = HelperViewData.GetEnumDisplayName((QuestionTypes)Model.QuestionType);
            

#line default
#line hidden
#nullable disable
            WriteLiteral("            ");
#nullable restore
#line 24 "E:\FPT-Aptech\Project Sem4\FourN-final\FourN-final\FourN-20-7-2021\C#Project\Partner\Views\Answer\_IndexNoEdit.cshtml"
       Write(type);

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dd>\n        <dt class=\"col-sm-2\">\n            Điểm\n        </dt>\n        <dd class=\"col-sm-10\">\n            ");
#nullable restore
#line 30 "E:\FPT-Aptech\Project Sem4\FourN-final\FourN-final\FourN-20-7-2021\C#Project\Partner\Views\Answer\_IndexNoEdit.cshtml"
       Write(Html.DisplayFor(model => model.Score));

#line default
#line hidden
#nullable disable
            WriteLiteral(" điểm\n        </dd>\n\n    </dl>\n");
#nullable restore
#line 34 "E:\FPT-Aptech\Project Sem4\FourN-final\FourN-final\FourN-20-7-2021\C#Project\Partner\Views\Answer\_IndexNoEdit.cshtml"
     if (Model.AnswerActive.Count != 0)
    {
        if (Model.QuestionType == (int)QuestionTypes.TracNghiem)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"            <div>
                <table class=""table"">
                    <thead>
                        <tr>
                            <th>Đáp án</th>
                            <th>Nội dung</th>
                            <th>Đáp án đúng</th>
                        </tr>
                    </thead>
                    <tbody>
");
#nullable restore
#line 48 "E:\FPT-Aptech\Project Sem4\FourN-final\FourN-final\FourN-20-7-2021\C#Project\Partner\Views\Answer\_IndexNoEdit.cshtml"
                         if (Model.IsRandom)
                        {
                            

#line default
#line hidden
#nullable disable
#nullable restore
#line 50 "E:\FPT-Aptech\Project Sem4\FourN-final\FourN-final\FourN-20-7-2021\C#Project\Partner\Views\Answer\_IndexNoEdit.cshtml"
                             foreach (var i in Model.AnswerActive.OrderBy(x => ran.Next()))
                            {
                                prefix = (char)startNumber;
                                startNumber++;

                                

#line default
#line hidden
#nullable disable
#nullable restore
#line 55 "E:\FPT-Aptech\Project Sem4\FourN-final\FourN-final\FourN-20-7-2021\C#Project\Partner\Views\Answer\_IndexNoEdit.cshtml"
                                 if (i.IsCorrect) { answer = "Đáp án đúng"; } else { answer = ""; }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <tr>\n\n                                    <td>");
#nullable restore
#line 58 "E:\FPT-Aptech\Project Sem4\FourN-final\FourN-final\FourN-20-7-2021\C#Project\Partner\Views\Answer\_IndexNoEdit.cshtml"
                                   Write(prefix);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                                    <td style=\"white-space: pre-line\">");
#nullable restore
#line 59 "E:\FPT-Aptech\Project Sem4\FourN-final\FourN-final\FourN-20-7-2021\C#Project\Partner\Views\Answer\_IndexNoEdit.cshtml"
                                                                 Write(i.Content);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                                    <td>");
#nullable restore
#line 60 "E:\FPT-Aptech\Project Sem4\FourN-final\FourN-final\FourN-20-7-2021\C#Project\Partner\Views\Answer\_IndexNoEdit.cshtml"
                                   Write(answer);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n\n                                </tr>\n");
#nullable restore
#line 63 "E:\FPT-Aptech\Project Sem4\FourN-final\FourN-final\FourN-20-7-2021\C#Project\Partner\Views\Answer\_IndexNoEdit.cshtml"
                            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 63 "E:\FPT-Aptech\Project Sem4\FourN-final\FourN-final\FourN-20-7-2021\C#Project\Partner\Views\Answer\_IndexNoEdit.cshtml"
                             
                        }
                        else
                        {
                            

#line default
#line hidden
#nullable disable
#nullable restore
#line 67 "E:\FPT-Aptech\Project Sem4\FourN-final\FourN-final\FourN-20-7-2021\C#Project\Partner\Views\Answer\_IndexNoEdit.cshtml"
                             foreach (var i in Model.AnswerActive)
                            {
                                prefix = (char)startNumber;
                                startNumber++;

                                

#line default
#line hidden
#nullable disable
#nullable restore
#line 72 "E:\FPT-Aptech\Project Sem4\FourN-final\FourN-final\FourN-20-7-2021\C#Project\Partner\Views\Answer\_IndexNoEdit.cshtml"
                                 if (i.IsCorrect) { answer = "Đáp án đúng"; } else { answer = ""; }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <tr>\n\n                                    <td>");
#nullable restore
#line 75 "E:\FPT-Aptech\Project Sem4\FourN-final\FourN-final\FourN-20-7-2021\C#Project\Partner\Views\Answer\_IndexNoEdit.cshtml"
                                   Write(prefix);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                                    <td style=\"white-space: pre-line\">");
#nullable restore
#line 76 "E:\FPT-Aptech\Project Sem4\FourN-final\FourN-final\FourN-20-7-2021\C#Project\Partner\Views\Answer\_IndexNoEdit.cshtml"
                                                                 Write(i.Content);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                                    <td>");
#nullable restore
#line 77 "E:\FPT-Aptech\Project Sem4\FourN-final\FourN-final\FourN-20-7-2021\C#Project\Partner\Views\Answer\_IndexNoEdit.cshtml"
                                   Write(answer);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n\n                                </tr>\n");
#nullable restore
#line 80 "E:\FPT-Aptech\Project Sem4\FourN-final\FourN-final\FourN-20-7-2021\C#Project\Partner\Views\Answer\_IndexNoEdit.cshtml"
                            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 80 "E:\FPT-Aptech\Project Sem4\FourN-final\FourN-final\FourN-20-7-2021\C#Project\Partner\Views\Answer\_IndexNoEdit.cshtml"
                             
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\n\n                    </tbody>\n                </table>\n            </div>\n");
#nullable restore
#line 87 "E:\FPT-Aptech\Project Sem4\FourN-final\FourN-final\FourN-20-7-2021\C#Project\Partner\Views\Answer\_IndexNoEdit.cshtml"
        }
        else
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <h3>Gợi ý đáp án:</h3>\n");
#nullable restore
#line 91 "E:\FPT-Aptech\Project Sem4\FourN-final\FourN-final\FourN-20-7-2021\C#Project\Partner\Views\Answer\_IndexNoEdit.cshtml"
             foreach (var i in Model.AnswerActive)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <p>");
#nullable restore
#line 93 "E:\FPT-Aptech\Project Sem4\FourN-final\FourN-final\FourN-20-7-2021\C#Project\Partner\Views\Answer\_IndexNoEdit.cshtml"
              Write(i.Content);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>    \n");
#nullable restore
#line 94 "E:\FPT-Aptech\Project Sem4\FourN-final\FourN-final\FourN-20-7-2021\C#Project\Partner\Views\Answer\_IndexNoEdit.cshtml"
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 94 "E:\FPT-Aptech\Project Sem4\FourN-final\FourN-final\FourN-20-7-2021\C#Project\Partner\Views\Answer\_IndexNoEdit.cshtml"
             
        }
    }
    else
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <p class=\"text-center\">Câu hỏi này hiện chưa có đáp án</p>\n");
#nullable restore
#line 100 "E:\FPT-Aptech\Project Sem4\FourN-final\FourN-final\FourN-20-7-2021\C#Project\Partner\Views\Answer\_IndexNoEdit.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\n\n\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ExaminationQuestionsActiveViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591