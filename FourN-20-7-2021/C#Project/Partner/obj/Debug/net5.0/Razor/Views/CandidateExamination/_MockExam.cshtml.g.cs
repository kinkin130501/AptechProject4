#pragma checksum "E:\FPT-Aptech\Project Sem4\FourN-final\FourN-final\FourN-20-7-2021\C#Project\Partner\Views\CandidateExamination\_MockExam.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a97ff0551e36bc6c59e09a80e34bff9b959ba06b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_CandidateExamination__MockExam), @"mvc.1.0.view", @"/Views/CandidateExamination/_MockExam.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a97ff0551e36bc6c59e09a80e34bff9b959ba06b", @"/Views/CandidateExamination/_MockExam.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"53a1f87bb51e19b0bda39ed97d9e7ff4998c32d9", @"/Views/_ViewImports.cshtml")]
    public class Views_CandidateExamination__MockExam : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ExaminationViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "E:\FPT-Aptech\Project Sem4\FourN-final\FourN-final\FourN-20-7-2021\C#Project\Partner\Views\CandidateExamination\_MockExam.cshtml"
   
                var stt = 0;
                var type = HelperViewData.GetEnumDisplayName((ExamTypes)Model.ExamType);
                var valuemax = Model.TotalTime * 60;
                var ran = new Random();
                var countEssay = 0;
                var examType = Model.ExamType; 
  

#line default
#line hidden
#nullable disable
            WriteLiteral("<div>\n    <h4>Examination: ");
#nullable restore
#line 11 "E:\FPT-Aptech\Project Sem4\FourN-final\FourN-final\FourN-20-7-2021\C#Project\Partner\Views\CandidateExamination\_MockExam.cshtml"
                Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </h4>\n    <h4>Type: ");
#nullable restore
#line 12 "E:\FPT-Aptech\Project Sem4\FourN-final\FourN-final\FourN-20-7-2021\C#Project\Partner\Views\CandidateExamination\_MockExam.cshtml"
         Write(type);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </h4>\n    <h4>Total question: ");
#nullable restore
#line 13 "E:\FPT-Aptech\Project Sem4\FourN-final\FourN-final\FourN-20-7-2021\C#Project\Partner\Views\CandidateExamination\_MockExam.cshtml"
                   Write(Model.TotalQuestion);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\n    <h4>Total mark: ");
#nullable restore
#line 14 "E:\FPT-Aptech\Project Sem4\FourN-final\FourN-final\FourN-20-7-2021\C#Project\Partner\Views\CandidateExamination\_MockExam.cshtml"
               Write(Model.MaxScore);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\n    <h4>Pass mark: ");
#nullable restore
#line 15 "E:\FPT-Aptech\Project Sem4\FourN-final\FourN-final\FourN-20-7-2021\C#Project\Partner\Views\CandidateExamination\_MockExam.cshtml"
              Write(Model.PassScore);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\n    <h4>\n        <b>Time: </b>");
#nullable restore
#line 17 "E:\FPT-Aptech\Project Sem4\FourN-final\FourN-final\FourN-20-7-2021\C#Project\Partner\Views\CandidateExamination\_MockExam.cshtml"
                Write(Model.TotalTime);

#line default
#line hidden
#nullable disable
            WriteLiteral(" minute\n    </h4>\n    <div class=\"progress\">\n        <div class=\"progress-bar progress-bar-success\" role=\"progressbar\"");
            BeginWriteAttribute("aria-valuenow", " aria-valuenow=\"", 698, "\"", 723, 1);
#nullable restore
#line 20 "E:\FPT-Aptech\Project Sem4\FourN-final\FourN-final\FourN-20-7-2021\C#Project\Partner\Views\CandidateExamination\_MockExam.cshtml"
WriteAttributeValue("", 714, valuemax, 714, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" aria-valuemin=\"0\"");
            BeginWriteAttribute("aria-valuemax", " aria-valuemax=\"", 742, "\"", 767, 1);
#nullable restore
#line 20 "E:\FPT-Aptech\Project Sem4\FourN-final\FourN-final\FourN-20-7-2021\C#Project\Partner\Views\CandidateExamination\_MockExam.cshtml"
WriteAttributeValue("", 758, valuemax, 758, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" style=\"width: 100%\">\n            <span class=\"sr-only\"></span>\n        </div>\n    </div>\n    <input type=\"hidden\" id=\"txtExamId\"");
            BeginWriteAttribute("value", " value=\"", 897, "\"", 918, 1);
#nullable restore
#line 24 "E:\FPT-Aptech\Project Sem4\FourN-final\FourN-final\FourN-20-7-2021\C#Project\Partner\Views\CandidateExamination\_MockExam.cshtml"
WriteAttributeValue("", 905, Model.ExamId, 905, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\n    <input type=\"hidden\" id=\"txtUserExamGuid\"");
            BeginWriteAttribute("value", " value=\"", 968, "\"", 997, 1);
#nullable restore
#line 25 "E:\FPT-Aptech\Project Sem4\FourN-final\FourN-final\FourN-20-7-2021\C#Project\Partner\Views\CandidateExamination\_MockExam.cshtml"
WriteAttributeValue("", 976, ViewBag.UserExamGuid, 976, 21, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\n</div>\n<hr />\n");
#nullable restore
#line 28 "E:\FPT-Aptech\Project Sem4\FourN-final\FourN-final\FourN-20-7-2021\C#Project\Partner\Views\CandidateExamination\_MockExam.cshtml"
 if (Model.ExaminationQuestionsActives.Any())
{

#line default
#line hidden
#nullable disable
#nullable restore
#line 30 "E:\FPT-Aptech\Project Sem4\FourN-final\FourN-final\FourN-20-7-2021\C#Project\Partner\Views\CandidateExamination\_MockExam.cshtml"
 foreach (var item in Model.ExaminationQuestionsActives.OrderBy(no => no.OrderNo))
{
    stt++;

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"form-group\">\n    <b>Question ");
#nullable restore
#line 34 "E:\FPT-Aptech\Project Sem4\FourN-final\FourN-final\FourN-20-7-2021\C#Project\Partner\Views\CandidateExamination\_MockExam.cshtml"
           Write(stt);

#line default
#line hidden
#nullable disable
            WriteLiteral(": </b>");
#nullable restore
#line 34 "E:\FPT-Aptech\Project Sem4\FourN-final\FourN-final\FourN-20-7-2021\C#Project\Partner\Views\CandidateExamination\_MockExam.cshtml"
                     Write(item.Content);

#line default
#line hidden
#nullable disable
            WriteLiteral("\n    <div class=\"b-double\" style=\"padding:7px; margin-bottom:6px\">\n");
#nullable restore
#line 36 "E:\FPT-Aptech\Project Sem4\FourN-final\FourN-final\FourN-20-7-2021\C#Project\Partner\Views\CandidateExamination\_MockExam.cshtml"
         if (item.AnswerActive.Any())
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("<ul style=\"list-style-type:none\">\n");
#nullable restore
#line 39 "E:\FPT-Aptech\Project Sem4\FourN-final\FourN-final\FourN-20-7-2021\C#Project\Partner\Views\CandidateExamination\_MockExam.cshtml"
     if (item.IsRandom)
    {

#line default
#line hidden
#nullable disable
#nullable restore
#line 41 "E:\FPT-Aptech\Project Sem4\FourN-final\FourN-final\FourN-20-7-2021\C#Project\Partner\Views\CandidateExamination\_MockExam.cshtml"
 foreach (var ans in item.AnswerActive.OrderBy(x => ran.Next()))
{

#line default
#line hidden
#nullable disable
            WriteLiteral("<li>\n    <input type=\"radio\"");
            BeginWriteAttribute("id", " id=\"", 1498, "\"", 1526, 2);
            WriteAttributeValue("", 1503, "answer-id-", 1503, 10, true);
#nullable restore
#line 44 "E:\FPT-Aptech\Project Sem4\FourN-final\FourN-final\FourN-20-7-2021\C#Project\Partner\Views\CandidateExamination\_MockExam.cshtml"
WriteAttributeValue("", 1513, ans.AnswerId, 1513, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("name", " name=\"", 1527, "\"", 1548, 2);
            WriteAttributeValue("", 1534, "answer-id-", 1534, 10, true);
#nullable restore
#line 44 "E:\FPT-Aptech\Project Sem4\FourN-final\FourN-final\FourN-20-7-2021\C#Project\Partner\Views\CandidateExamination\_MockExam.cshtml"
WriteAttributeValue("", 1544, stt, 1544, 4, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("value", " value=\"", 1549, "\"", 1570, 1);
#nullable restore
#line 44 "E:\FPT-Aptech\Project Sem4\FourN-final\FourN-final\FourN-20-7-2021\C#Project\Partner\Views\CandidateExamination\_MockExam.cshtml"
WriteAttributeValue("", 1557, ans.AnswerId, 1557, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\n    <label");
            BeginWriteAttribute("for", " for=\"", 1583, "\"", 1612, 2);
            WriteAttributeValue("", 1589, "answer-id-", 1589, 10, true);
#nullable restore
#line 45 "E:\FPT-Aptech\Project Sem4\FourN-final\FourN-final\FourN-20-7-2021\C#Project\Partner\Views\CandidateExamination\_MockExam.cshtml"
WriteAttributeValue("", 1599, ans.AnswerId, 1599, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\n        <span>\n            ");
#nullable restore
#line 47 "E:\FPT-Aptech\Project Sem4\FourN-final\FourN-final\FourN-20-7-2021\C#Project\Partner\Views\CandidateExamination\_MockExam.cshtml"
       Write(ans.Content);

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </span>\n    </label>\n</li>                            ");
#nullable restore
#line 50 "E:\FPT-Aptech\Project Sem4\FourN-final\FourN-final\FourN-20-7-2021\C#Project\Partner\Views\CandidateExamination\_MockExam.cshtml"
                                 }

#line default
#line hidden
#nullable disable
#nullable restore
#line 50 "E:\FPT-Aptech\Project Sem4\FourN-final\FourN-final\FourN-20-7-2021\C#Project\Partner\Views\CandidateExamination\_MockExam.cshtml"
                                   }
                        else
                        {

#line default
#line hidden
#nullable disable
#nullable restore
#line 53 "E:\FPT-Aptech\Project Sem4\FourN-final\FourN-final\FourN-20-7-2021\C#Project\Partner\Views\CandidateExamination\_MockExam.cshtml"
 foreach (var ans in item.AnswerActive)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("<li>\n    <input type=\"radio\"");
            BeginWriteAttribute("id", " id=\"", 1846, "\"", 1874, 2);
            WriteAttributeValue("", 1851, "answer-id-", 1851, 10, true);
#nullable restore
#line 56 "E:\FPT-Aptech\Project Sem4\FourN-final\FourN-final\FourN-20-7-2021\C#Project\Partner\Views\CandidateExamination\_MockExam.cshtml"
WriteAttributeValue("", 1861, ans.AnswerId, 1861, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("name", " name=\"", 1875, "\"", 1896, 2);
            WriteAttributeValue("", 1882, "answer-id-", 1882, 10, true);
#nullable restore
#line 56 "E:\FPT-Aptech\Project Sem4\FourN-final\FourN-final\FourN-20-7-2021\C#Project\Partner\Views\CandidateExamination\_MockExam.cshtml"
WriteAttributeValue("", 1892, stt, 1892, 4, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("value", " value=\"", 1897, "\"", 1918, 1);
#nullable restore
#line 56 "E:\FPT-Aptech\Project Sem4\FourN-final\FourN-final\FourN-20-7-2021\C#Project\Partner\Views\CandidateExamination\_MockExam.cshtml"
WriteAttributeValue("", 1905, ans.AnswerId, 1905, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\n    <label");
            BeginWriteAttribute("for", " for=\"", 1931, "\"", 1960, 2);
            WriteAttributeValue("", 1937, "answer-id-", 1937, 10, true);
#nullable restore
#line 57 "E:\FPT-Aptech\Project Sem4\FourN-final\FourN-final\FourN-20-7-2021\C#Project\Partner\Views\CandidateExamination\_MockExam.cshtml"
WriteAttributeValue("", 1947, ans.AnswerId, 1947, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\n        <span>\n            ");
#nullable restore
#line 59 "E:\FPT-Aptech\Project Sem4\FourN-final\FourN-final\FourN-20-7-2021\C#Project\Partner\Views\CandidateExamination\_MockExam.cshtml"
       Write(ans.Content);

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </span>\n    </label>\n</li>                            ");
#nullable restore
#line 62 "E:\FPT-Aptech\Project Sem4\FourN-final\FourN-final\FourN-20-7-2021\C#Project\Partner\Views\CandidateExamination\_MockExam.cshtml"
                                 }

#line default
#line hidden
#nullable disable
#nullable restore
#line 62 "E:\FPT-Aptech\Project Sem4\FourN-final\FourN-final\FourN-20-7-2021\C#Project\Partner\Views\CandidateExamination\_MockExam.cshtml"
                                                          }

#line default
#line hidden
#nullable disable
            WriteLiteral("</ul> ");
#nullable restore
#line 63 "E:\FPT-Aptech\Project Sem4\FourN-final\FourN-final\FourN-20-7-2021\C#Project\Partner\Views\CandidateExamination\_MockExam.cshtml"
      }
                    else
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("<p>Không có đáp án, bạn được trọn điểm, liên hệ Giảng viên để báo cáo</p>                    ");
#nullable restore
#line 66 "E:\FPT-Aptech\Project Sem4\FourN-final\FourN-final\FourN-20-7-2021\C#Project\Partner\Views\CandidateExamination\_MockExam.cshtml"
                                                                                             }

#line default
#line hidden
#nullable disable
            WriteLiteral("\n    </div>\n</div>");
#nullable restore
#line 69 "E:\FPT-Aptech\Project Sem4\FourN-final\FourN-final\FourN-20-7-2021\C#Project\Partner\Views\CandidateExamination\_MockExam.cshtml"
      }

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"form-group\">\n");
#nullable restore
#line 72 "E:\FPT-Aptech\Project Sem4\FourN-final\FourN-final\FourN-20-7-2021\C#Project\Partner\Views\CandidateExamination\_MockExam.cshtml"
                     if (Model.ExamType == (int)ExamTypes.TracNghiem)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <button type=\"button\" class=\"btn btn-primary\" id=\"btnSubmitExam\" onclick=\"submitExam()\">Submit</button> \n");
#nullable restore
#line 75 "E:\FPT-Aptech\Project Sem4\FourN-final\FourN-final\FourN-20-7-2021\C#Project\Partner\Views\CandidateExamination\_MockExam.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <button type=\"button\" class=\"btn btn-outline-warm\" onclick=\"backToList()\">Back</button>\n                </div> ");
#nullable restore
#line 77 "E:\FPT-Aptech\Project Sem4\FourN-final\FourN-final\FourN-20-7-2021\C#Project\Partner\Views\CandidateExamination\_MockExam.cshtml"
                       }
                            else
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                <div class=""form-group text-center"">
                    <h2 style=""color: aquamarine"">Not question in examination !</h2>
                    <h3>Add Question</h3>
                    <br />
                    <button type=""button"" class=""btn btn-outline-warm"" onclick=""backToList()"">Back</button>

                </div>");
#nullable restore
#line 86 "E:\FPT-Aptech\Project Sem4\FourN-final\FourN-final\FourN-20-7-2021\C#Project\Partner\Views\CandidateExamination\_MockExam.cshtml"
                      }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<script>
    var progressBar = document.querySelector('.progress-bar');
    var myVar = setInterval(myTimer, 1000);
    var max = progressBar.getAttribute('aria-valuemax');
    var temp = max - 100;
    if (temp < 0) {
        temp = 0;
    }

    function myTimer() {
        var now = progressBar.getAttribute('aria-valuenow');

        if (now == max && max > 100) {
                now = 100 + temp - 1;
        } else {
            now = now - 1;
        }

        if (parseInt(now / max * 100) <= 60) {
            if ($("".progress-bar"").hasClass('progress-bar-success')) {
                $("".progress-bar"").removeClass('progress-bar-success').addClass('progress-bar-warning');
            }
        }

        if (parseInt(now / max * 100) <= 20) {
            if ($("".progress-bar"").hasClass('progress-bar-warning')) {
                $("".progress-bar"").removeClass('progress-bar-warning').addClass('progress-bar-danger');

            }
        }
        progressBar.setAttribute('aria-valuenow', now);

        ");
            WriteLiteral("if (parseInt(now) == 0) {\n            submitExam();\n            clearInterval(myVar);\n        }\n        console.log(now);\n        console.log(now / max * 100);\n\n        $(\".progress-bar\").css(\'width\', now/max*100 + \'%\');\n    }\n\n    var passScore = \"");
#nullable restore
#line 130 "E:\FPT-Aptech\Project Sem4\FourN-final\FourN-final\FourN-20-7-2021\C#Project\Partner\Views\CandidateExamination\_MockExam.cshtml"
                Write(Model.PassScore);

#line default
#line hidden
#nullable disable
            WriteLiteral("\";\n    var maxScore = \"");
#nullable restore
#line 131 "E:\FPT-Aptech\Project Sem4\FourN-final\FourN-final\FourN-20-7-2021\C#Project\Partner\Views\CandidateExamination\_MockExam.cshtml"
               Write(Model.MaxScore);

#line default
#line hidden
#nullable disable
            WriteLiteral(@""";
    function submitExam() {
        var radio_arr = [];
        var txtExamId = parseInt($(""#txtExamId"").val());
        var txtUserExamGuid = $(""#txtUserExamGuid"").val();
        var txtTimeConsume = progressBar.getAttribute('aria-valuemax') - progressBar.getAttribute('aria-valuenow');
        $('ul').each(function () {
            radio_arr.push($(this).find('input[type=radio]:checked').length ? parseInt($(this).find('input[type=radio]:checked').val()) : null);
        });
        radio_arr = radio_arr.filter(Number);
        console.log(radio_arr)
        $.ajax({
            url: ""/CandidateExamination/SubmitExam"",
            type: ""post"",
            traditional: true,
            data: {
                answerArr: [radio_arr],
                txtExamId: txtExamId,
                txtUserExamGuid: txtUserExamGuid,
                txtTimeConsume: parseInt(txtTimeConsume)
            },
            success: function (res) {
                if (res < 0) {
                    toastr.error(""Processing has");
            WriteLiteral(" error. Please try again.\");\n                } else {\n                    var examType = ");
#nullable restore
#line 156 "E:\FPT-Aptech\Project Sem4\FourN-final\FourN-final\FourN-20-7-2021\C#Project\Partner\Views\CandidateExamination\_MockExam.cshtml"
                              Write(examType);

#line default
#line hidden
#nullable disable
            WriteLiteral(@";
                    if (examType == 1) {
                        if (res >= parseFloat(passScore)) {
                            toastr.success(""Configuration, you passed exam with mark: "" + res + ""/"" + maxScore);
                        } else {
                            toastr.error(""Sorry, you are failed."");
                        }
                    }

                }

                clearInterval(myVar);

                $(""#btnSubmitExam"").css('display', 'none').addClass('submited');
            },
            error: function () {
                alert(""Có lỗi xảy ra, vui lòng thử lại sau"");
            }
        });
    }

    function backToList() {
        var checkSubmited = $(""#btnSubmitExam"").hasClass('submited');
        if (checkSubmited == false) {
            var isOK = confirm(""Bạn có chắc kết thúc bài thi?"");

            if (isOK == true) {
                clearInterval(myVar);
                submitExam();
                showAll();
            }
        } else {
            clea");
            WriteLiteral("rInterval(myVar);\n            showAll();\n        }\n\n\n    }\n</script>\n");
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
