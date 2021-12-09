#pragma checksum "E:\FPT-Aptech\Project Sem4\FourN-final\FourN-final\FourN-20-7-2021\C#Project\Partner\Views\CandidateExamination\_Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a789be7162e6f32950c16d0d6c8825b1c168172d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_CandidateExamination__Details), @"mvc.1.0.view", @"/Views/CandidateExamination/_Details.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a789be7162e6f32950c16d0d6c8825b1c168172d", @"/Views/CandidateExamination/_Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"53a1f87bb51e19b0bda39ed97d9e7ff4998c32d9", @"/Views/_ViewImports.cshtml")]
    public class Views_CandidateExamination__Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ExaminationViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "E:\FPT-Aptech\Project Sem4\FourN-final\FourN-final\FourN-20-7-2021\C#Project\Partner\Views\CandidateExamination\_Details.cshtml"
  
    var stt = 0;
    var type = HelperViewData.GetEnumDisplayName((ExamTypes)Model.ExamType);

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"container\">\n    <div>\n        <h4>Examination: ");
#nullable restore
#line 8 "E:\FPT-Aptech\Project Sem4\FourN-final\FourN-final\FourN-20-7-2021\C#Project\Partner\Views\CandidateExamination\_Details.cshtml"
                    Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </h4>\n        <h4>Type: ");
#nullable restore
#line 9 "E:\FPT-Aptech\Project Sem4\FourN-final\FourN-final\FourN-20-7-2021\C#Project\Partner\Views\CandidateExamination\_Details.cshtml"
             Write(type);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </h4>\n        <h4>Total question: ");
#nullable restore
#line 10 "E:\FPT-Aptech\Project Sem4\FourN-final\FourN-final\FourN-20-7-2021\C#Project\Partner\Views\CandidateExamination\_Details.cshtml"
                       Write(Model.TotalQuestion);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\n        <h4>Total mark: ");
#nullable restore
#line 11 "E:\FPT-Aptech\Project Sem4\FourN-final\FourN-final\FourN-20-7-2021\C#Project\Partner\Views\CandidateExamination\_Details.cshtml"
                   Write(Model.MaxScore);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\n        <h4>Pass mark: ");
#nullable restore
#line 12 "E:\FPT-Aptech\Project Sem4\FourN-final\FourN-final\FourN-20-7-2021\C#Project\Partner\Views\CandidateExamination\_Details.cshtml"
                  Write(Model.PassScore);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\n    </div>\n<hr />\n");
#nullable restore
#line 15 "E:\FPT-Aptech\Project Sem4\FourN-final\FourN-final\FourN-20-7-2021\C#Project\Partner\Views\CandidateExamination\_Details.cshtml"
 if (Model.ExaminationQuestionsActives.Any())
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 17 "E:\FPT-Aptech\Project Sem4\FourN-final\FourN-final\FourN-20-7-2021\C#Project\Partner\Views\CandidateExamination\_Details.cshtml"
     foreach (var item in Model.ExaminationQuestionsActives.OrderBy(no => no.OrderNo))
    {
        stt++;

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"form-group\">\n            <label><b>Question ");
#nullable restore
#line 21 "E:\FPT-Aptech\Project Sem4\FourN-final\FourN-final\FourN-20-7-2021\C#Project\Partner\Views\CandidateExamination\_Details.cshtml"
                          Write(stt);

#line default
#line hidden
#nullable disable
            WriteLiteral(": (<span class=\"text-success\">");
#nullable restore
#line 21 "E:\FPT-Aptech\Project Sem4\FourN-final\FourN-final\FourN-20-7-2021\C#Project\Partner\Views\CandidateExamination\_Details.cshtml"
                                                            Write(item.Score);

#line default
#line hidden
#nullable disable
            WriteLiteral(" mark</span>) </b>");
#nullable restore
#line 21 "E:\FPT-Aptech\Project Sem4\FourN-final\FourN-final\FourN-20-7-2021\C#Project\Partner\Views\CandidateExamination\_Details.cshtml"
                                                                                         Write(item.Content);

#line default
#line hidden
#nullable disable
            WriteLiteral("</label>\n            <div class=\"b-double\" style=\"padding:7px; margin-bottom:6px\">\n");
#nullable restore
#line 23 "E:\FPT-Aptech\Project Sem4\FourN-final\FourN-final\FourN-20-7-2021\C#Project\Partner\Views\CandidateExamination\_Details.cshtml"
                 if (item.AnswerActive.Any())
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <ul style=\"list-style-type:none\">\n\n");
#nullable restore
#line 27 "E:\FPT-Aptech\Project Sem4\FourN-final\FourN-final\FourN-20-7-2021\C#Project\Partner\Views\CandidateExamination\_Details.cshtml"
                         foreach (var ans in item.AnswerActive)
                        {
                            

#line default
#line hidden
#nullable disable
#nullable restore
#line 29 "E:\FPT-Aptech\Project Sem4\FourN-final\FourN-final\FourN-20-7-2021\C#Project\Partner\Views\CandidateExamination\_Details.cshtml"
                             foreach (var rightAnswer in ViewBag.UserExamRightAnswerList)
                            {
                                if (int.Parse(rightAnswer.AnswerContent) == ans.AnswerId)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <li style=\"color: green\">\n                                        <input type=\"radio\"");
            BeginWriteAttribute("id", " id=\"", 1349, "\"", 1377, 2);
            WriteAttributeValue("", 1354, "answer-id-", 1354, 10, true);
#nullable restore
#line 34 "E:\FPT-Aptech\Project Sem4\FourN-final\FourN-final\FourN-20-7-2021\C#Project\Partner\Views\CandidateExamination\_Details.cshtml"
WriteAttributeValue("", 1364, ans.AnswerId, 1364, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("name", " name=\"", 1378, "\"", 1399, 2);
            WriteAttributeValue("", 1385, "answer-id-", 1385, 10, true);
#nullable restore
#line 34 "E:\FPT-Aptech\Project Sem4\FourN-final\FourN-final\FourN-20-7-2021\C#Project\Partner\Views\CandidateExamination\_Details.cshtml"
WriteAttributeValue("", 1395, stt, 1395, 4, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("value", " value=\"", 1400, "\"", 1421, 1);
#nullable restore
#line 34 "E:\FPT-Aptech\Project Sem4\FourN-final\FourN-final\FourN-20-7-2021\C#Project\Partner\Views\CandidateExamination\_Details.cshtml"
WriteAttributeValue("", 1408, ans.AnswerId, 1408, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" checked>\n                                        <label");
            BeginWriteAttribute("for", " for=\"", 1478, "\"", 1507, 2);
            WriteAttributeValue("", 1484, "answer-id-", 1484, 10, true);
#nullable restore
#line 35 "E:\FPT-Aptech\Project Sem4\FourN-final\FourN-final\FourN-20-7-2021\C#Project\Partner\Views\CandidateExamination\_Details.cshtml"
WriteAttributeValue("", 1494, ans.AnswerId, 1494, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\n                                            <span>\n                                                ");
#nullable restore
#line 37 "E:\FPT-Aptech\Project Sem4\FourN-final\FourN-final\FourN-20-7-2021\C#Project\Partner\Views\CandidateExamination\_Details.cshtml"
                                           Write(ans.Content);

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                                            </span>\n                                        </label>\n                                    </li>\n");
#nullable restore
#line 41 "E:\FPT-Aptech\Project Sem4\FourN-final\FourN-final\FourN-20-7-2021\C#Project\Partner\Views\CandidateExamination\_Details.cshtml"
                                    goto label1;
                                }

                            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 46 "E:\FPT-Aptech\Project Sem4\FourN-final\FourN-final\FourN-20-7-2021\C#Project\Partner\Views\CandidateExamination\_Details.cshtml"
                             foreach (var unRightAnswer in ViewBag.UserExamUnRightAnswerList)
                            {
                                if (int.Parse(unRightAnswer.AnswerContent) == ans.AnswerId)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <li style=\"color: red\">\n                                        <input type=\"radio\"");
            BeginWriteAttribute("id", " id=\"", 2249, "\"", 2277, 2);
            WriteAttributeValue("", 2254, "answer-id-", 2254, 10, true);
#nullable restore
#line 51 "E:\FPT-Aptech\Project Sem4\FourN-final\FourN-final\FourN-20-7-2021\C#Project\Partner\Views\CandidateExamination\_Details.cshtml"
WriteAttributeValue("", 2264, ans.AnswerId, 2264, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("name", " name=\"", 2278, "\"", 2299, 2);
            WriteAttributeValue("", 2285, "answer-id-", 2285, 10, true);
#nullable restore
#line 51 "E:\FPT-Aptech\Project Sem4\FourN-final\FourN-final\FourN-20-7-2021\C#Project\Partner\Views\CandidateExamination\_Details.cshtml"
WriteAttributeValue("", 2295, stt, 2295, 4, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("value", " value=\"", 2300, "\"", 2321, 1);
#nullable restore
#line 51 "E:\FPT-Aptech\Project Sem4\FourN-final\FourN-final\FourN-20-7-2021\C#Project\Partner\Views\CandidateExamination\_Details.cshtml"
WriteAttributeValue("", 2308, ans.AnswerId, 2308, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" checked>\n                                        <label");
            BeginWriteAttribute("for", " for=\"", 2378, "\"", 2407, 2);
            WriteAttributeValue("", 2384, "answer-id-", 2384, 10, true);
#nullable restore
#line 52 "E:\FPT-Aptech\Project Sem4\FourN-final\FourN-final\FourN-20-7-2021\C#Project\Partner\Views\CandidateExamination\_Details.cshtml"
WriteAttributeValue("", 2394, ans.AnswerId, 2394, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\n                                            <span>\n                                                ");
#nullable restore
#line 54 "E:\FPT-Aptech\Project Sem4\FourN-final\FourN-final\FourN-20-7-2021\C#Project\Partner\Views\CandidateExamination\_Details.cshtml"
                                           Write(ans.Content);

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                                            </span>\n                                        </label>\n                                    </li>\n");
#nullable restore
#line 58 "E:\FPT-Aptech\Project Sem4\FourN-final\FourN-final\FourN-20-7-2021\C#Project\Partner\Views\CandidateExamination\_Details.cshtml"
                                    goto label1;
                                }

                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <li>\n                                <input type=\"radio\"");
            BeginWriteAttribute("id", " id=\"", 2864, "\"", 2892, 2);
            WriteAttributeValue("", 2869, "answer-id-", 2869, 10, true);
#nullable restore
#line 64 "E:\FPT-Aptech\Project Sem4\FourN-final\FourN-final\FourN-20-7-2021\C#Project\Partner\Views\CandidateExamination\_Details.cshtml"
WriteAttributeValue("", 2879, ans.AnswerId, 2879, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("name", " name=\"", 2893, "\"", 2914, 2);
            WriteAttributeValue("", 2900, "answer-id-", 2900, 10, true);
#nullable restore
#line 64 "E:\FPT-Aptech\Project Sem4\FourN-final\FourN-final\FourN-20-7-2021\C#Project\Partner\Views\CandidateExamination\_Details.cshtml"
WriteAttributeValue("", 2910, stt, 2910, 4, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("value", " value=\"", 2915, "\"", 2936, 1);
#nullable restore
#line 64 "E:\FPT-Aptech\Project Sem4\FourN-final\FourN-final\FourN-20-7-2021\C#Project\Partner\Views\CandidateExamination\_Details.cshtml"
WriteAttributeValue("", 2923, ans.AnswerId, 2923, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\n                                <label");
            BeginWriteAttribute("for", " for=\"", 2977, "\"", 3006, 2);
            WriteAttributeValue("", 2983, "answer-id-", 2983, 10, true);
#nullable restore
#line 65 "E:\FPT-Aptech\Project Sem4\FourN-final\FourN-final\FourN-20-7-2021\C#Project\Partner\Views\CandidateExamination\_Details.cshtml"
WriteAttributeValue("", 2993, ans.AnswerId, 2993, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\n                                    <span>\n                                        ");
#nullable restore
#line 67 "E:\FPT-Aptech\Project Sem4\FourN-final\FourN-final\FourN-20-7-2021\C#Project\Partner\Views\CandidateExamination\_Details.cshtml"
                                   Write(ans.Content);

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                                    </span>\n                                </label>\n                            </li>\n");
#nullable restore
#line 71 "E:\FPT-Aptech\Project Sem4\FourN-final\FourN-final\FourN-20-7-2021\C#Project\Partner\Views\CandidateExamination\_Details.cshtml"
                            label1:;

                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                    </ul>\n");
#nullable restore
#line 76 "E:\FPT-Aptech\Project Sem4\FourN-final\FourN-final\FourN-20-7-2021\C#Project\Partner\Views\CandidateExamination\_Details.cshtml"
                }
                else
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <p>Not anwser here, please contact admin.</p>\n");
#nullable restore
#line 80 "E:\FPT-Aptech\Project Sem4\FourN-final\FourN-final\FourN-20-7-2021\C#Project\Partner\Views\CandidateExamination\_Details.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </div>\n        </div>\n");
#nullable restore
#line 84 "E:\FPT-Aptech\Project Sem4\FourN-final\FourN-final\FourN-20-7-2021\C#Project\Partner\Views\CandidateExamination\_Details.cshtml"

    }

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"form-group\">\n        <button type=\"button\" class=\"btn btn-warning\" onclick=\"showAll()\">Back</button>\n    </div>\n");
#nullable restore
#line 90 "E:\FPT-Aptech\Project Sem4\FourN-final\FourN-final\FourN-20-7-2021\C#Project\Partner\Views\CandidateExamination\_Details.cshtml"

}

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\n\n\n\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ExaminationViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591