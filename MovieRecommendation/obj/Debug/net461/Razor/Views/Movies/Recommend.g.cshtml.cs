#pragma checksum "D:\Learn\asp.net project\MovieRecommendation\MovieRecommendation\Views\Movies\Recommend.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "545e13c8ecd966a8ca6ff87cd2f6e26404c61475"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Movies_Recommend), @"mvc.1.0.view", @"/Views/Movies/Recommend.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Movies/Recommend.cshtml", typeof(AspNetCore.Views_Movies_Recommend))]
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
#line 1 "D:\Learn\asp.net project\MovieRecommendation\MovieRecommendation\Views\_ViewImports.cshtml"
using movierecommender;

#line default
#line hidden
#line 1 "D:\Learn\asp.net project\MovieRecommendation\MovieRecommendation\Views\Movies\Recommend.cshtml"
using movierecommender.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"545e13c8ecd966a8ca6ff87cd2f6e26404c61475", @"/Views/Movies/Recommend.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8ada0004da76f008fd2c0a73c24d6e1b21f3ed60", @"/Views/_ViewImports.cshtml")]
    public class Views_Movies_Recommend : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Movie>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 3 "D:\Learn\asp.net project\MovieRecommendation\MovieRecommendation\Views\Movies\Recommend.cshtml"
  
    ViewBag.Title = "Recommend";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(142, 53, true);
            WriteLiteral("<br/>\n<h3>Recommended Movies</h3>\n\n<div class=\"row\">\n");
            EndContext();
#line 11 "D:\Learn\asp.net project\MovieRecommendation\MovieRecommendation\Views\Movies\Recommend.cshtml"
     if (Model != null)
    {
        foreach (var movie in Model)
        {

#line default
#line hidden
            BeginContext(272, 162, true);
            WriteLiteral("            <div class=\"col-sm-6\">\n                <div class=\"card\">\n                    <div class=\"card-block\">\n                        <h4 class=\"card-title\">");
            EndContext();
            BeginContext(435, 15, false);
#line 18 "D:\Learn\asp.net project\MovieRecommendation\MovieRecommendation\Views\Movies\Recommend.cshtml"
                                          Write(movie.MovieName);

#line default
#line hidden
            EndContext();
            BeginContext(450, 32, true);
            WriteLiteral("</h4>\n                        <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 482, "\"", 519, 1);
#line 19 "D:\Learn\asp.net project\MovieRecommendation\MovieRecommendation\Views\Movies\Recommend.cshtml"
WriteAttributeValue("", 489, Url.Action("Watch", "Movies"), 489, 30, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(520, 120, true);
            WriteLiteral(" class=\"btn btn-default btn-square\">Play Movie</a>\n                    </div>\n                </div>\n            </div>\n");
            EndContext();
#line 23 "D:\Learn\asp.net project\MovieRecommendation\MovieRecommendation\Views\Movies\Recommend.cshtml"
        }
    }
    else
    {

#line default
#line hidden
            BeginContext(671, 67, true);
            WriteLiteral("        <h2>Something went wrong! please check the error log.</h2>\n");
            EndContext();
#line 28 "D:\Learn\asp.net project\MovieRecommendation\MovieRecommendation\Views\Movies\Recommend.cshtml"
    }

#line default
#line hidden
            BeginContext(744, 39, true);
            WriteLiteral("    </div>\n<hr />\n<button type=\"button\"");
            EndContext();
            BeginWriteAttribute("OnClick", " OnClick=\"", 783, "\"", 840, 3);
            WriteAttributeValue("", 793, "location.href=\'", 793, 15, true);
#line 31 "D:\Learn\asp.net project\MovieRecommendation\MovieRecommendation\Views\Movies\Recommend.cshtml"
WriteAttributeValue("", 808, Url.Action("Choose", "Movies"), 808, 31, false);

#line default
#line hidden
            WriteAttributeValue("", 839, "\'", 839, 1, true);
            EndWriteAttribute();
            BeginContext(841, 81, true);
            WriteLiteral(" class=\"btn btn-lg breadcrumb btn-link\">This is fun, Let Me Try Again!</button>\n\n");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Movie>> Html { get; private set; }
    }
}
#pragma warning restore 1591