#pragma checksum "C:\Users\Admin\Desktop\DentistBackend\Dentist\Dentist\Views\Blog\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1b646f5f5ed24c9e3a7ed2e8fd5f84cbdcd6c9d7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Blog_Index), @"mvc.1.0.view", @"/Views/Blog/Index.cshtml")]
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
#line 1 "C:\Users\Admin\Desktop\DentistBackend\Dentist\Dentist\Views\_ViewImports.cshtml"
using Dentist;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Admin\Desktop\DentistBackend\Dentist\Dentist\Views\_ViewImports.cshtml"
using Dentist.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Admin\Desktop\DentistBackend\Dentist\Dentist\Views\_ViewImports.cshtml"
using Dentist.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1b646f5f5ed24c9e3a7ed2e8fd5f84cbdcd6c9d7", @"/Views/Blog/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ce10a58e72b6683d8c0ccecdd337a0e65bb2f6ff", @"/Views/_ViewImports.cshtml")]
    public class Views_Blog_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Blog>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Blog", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Detail", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Admin\Desktop\DentistBackend\Dentist\Dentist\Views\Blog\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<section class=""hero-wrap hero-wrap-2"" style=""background-image: url(../images/bg_1.jpg);"" data-stellar-background-ratio=""0.5"">
    <div class=""overlay""></div>
    <div class=""container"">
        <div class=""row no-gutters slider-text align-items-center justify-content-center"">
            <div class=""col-md-9 ftco-animate text-center"">
                <h1 class=""mb-2 bread"">Blog</h1>
                <p class=""breadcrumbs""><span class=""mr-2"">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1b646f5f5ed24c9e3a7ed2e8fd5f84cbdcd6c9d75480", async() => {
                WriteLiteral("Home <i class=\"ion-ios-arrow-forward\"></i>");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</span> <span>Blog <i class=\"ion-ios-arrow-forward\"></i></span></p>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</section>\r\n<section class=\"ftco-section bg-light\">\r\n    <div class=\"container\">\r\n        <div class=\"row\">\r\n");
#nullable restore
#line 20 "C:\Users\Admin\Desktop\DentistBackend\Dentist\Dentist\Views\Blog\Index.cshtml"
             foreach (Blog blog in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"col-md-4 ftco-animate\">\r\n                    <div class=\"blog-entry\">\r\n                        <a");
            BeginWriteAttribute("href", " href=\"", 1019, "\"", 1076, 1);
#nullable restore
#line 24 "C:\Users\Admin\Desktop\DentistBackend\Dentist\Dentist\Views\Blog\Index.cshtml"
WriteAttributeValue("", 1026, Url.Action("Detail","Blog",new { slug=blog.Slug}), 1026, 50, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"block-20 d-flex align-items-end justify-content-end\"");
            BeginWriteAttribute("style", " style=\"", 1137, "\"", 1190, 4);
            WriteAttributeValue("", 1145, "background-image:", 1145, 17, true);
            WriteAttributeValue(" ", 1162, "url(../images/", 1163, 15, true);
#nullable restore
#line 24 "C:\Users\Admin\Desktop\DentistBackend\Dentist\Dentist\Views\Blog\Index.cshtml"
WriteAttributeValue("", 1177, blog.Image, 1177, 11, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1188, ");", 1188, 2, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n                            <div class=\"meta-date text-center p-2\">\r\n                                <span class=\"day\">");
#nullable restore
#line 26 "C:\Users\Admin\Desktop\DentistBackend\Dentist\Dentist\Views\Blog\Index.cshtml"
                                             Write(blog.Date.Day);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                                <span class=\"mos\">");
#nullable restore
#line 27 "C:\Users\Admin\Desktop\DentistBackend\Dentist\Dentist\Views\Blog\Index.cshtml"
                                             Write(blog.Date.ToString("MMMM", new System.Globalization.CultureInfo("ru")));

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                                <span class=\"yr\">");
#nullable restore
#line 28 "C:\Users\Admin\Desktop\DentistBackend\Dentist\Dentist\Views\Blog\Index.cshtml"
                                            Write(blog.Date.Year);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                            </div>\r\n                        </a>\r\n                        <div class=\"text bg-white p-4\">\r\n                            <h3 class=\"heading\"><a");
            BeginWriteAttribute("href", " href=\"", 1712, "\"", 1770, 1);
#nullable restore
#line 32 "C:\Users\Admin\Desktop\DentistBackend\Dentist\Dentist\Views\Blog\Index.cshtml"
WriteAttributeValue("", 1719, Url.Action("Details","Blog",new { slug=blog.Slug}), 1719, 51, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 32 "C:\Users\Admin\Desktop\DentistBackend\Dentist\Dentist\Views\Blog\Index.cshtml"
                                                                                                         Write(blog.BlogName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></h3>\r\n                            <p>\r\n");
#nullable restore
#line 34 "C:\Users\Admin\Desktop\DentistBackend\Dentist\Dentist\Views\Blog\Index.cshtml"
                                 if (blog.Description.Length > 95)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <span>");
#nullable restore
#line 36 "C:\Users\Admin\Desktop\DentistBackend\Dentist\Dentist\Views\Blog\Index.cshtml"
                                     Write(Html.Raw(blog.Description.Substring(0, 95)));

#line default
#line hidden
#nullable disable
            WriteLiteral("</span> <span>...</span>\r\n");
#nullable restore
#line 37 "C:\Users\Admin\Desktop\DentistBackend\Dentist\Dentist\Views\Blog\Index.cshtml"
                                }
                                else
                                {
                                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 40 "C:\Users\Admin\Desktop\DentistBackend\Dentist\Dentist\Views\Blog\Index.cshtml"
                               Write(Html.Raw(blog.Description));

#line default
#line hidden
#nullable disable
#nullable restore
#line 40 "C:\Users\Admin\Desktop\DentistBackend\Dentist\Dentist\Views\Blog\Index.cshtml"
                                                               ;
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            </p>\r\n                            <div class=\"d-flex align-items-center mt-4\">\r\n                                <p class=\"mb-0\">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1b646f5f5ed24c9e3a7ed2e8fd5f84cbdcd6c9d712230", async() => {
                WriteLiteral("Read More <span class=\"ion-ios-arrow-round-forward\"></span>");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-slug", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 44 "C:\Users\Admin\Desktop\DentistBackend\Dentist\Dentist\Views\Blog\Index.cshtml"
                                                                                                 WriteLiteral(blog.Slug);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["slug"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-slug", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["slug"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</p>\r\n                                <p class=\"ml-auto mb-0\">\r\n                                    <a href=\"#\" class=\"mr-2\">");
#nullable restore
#line 46 "C:\Users\Admin\Desktop\DentistBackend\Dentist\Dentist\Views\Blog\Index.cshtml"
                                                        Write(blog.Author);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n                                </p>\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n");
#nullable restore
#line 52 "C:\Users\Admin\Desktop\DentistBackend\Dentist\Dentist\Views\Blog\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n        <div class=\"row no-gutters my-5\">\r\n            <div class=\"col text-center\">\r\n                <div class=\"block-27\">\r\n                    <ul>\r\n");
#nullable restore
#line 59 "C:\Users\Admin\Desktop\DentistBackend\Dentist\Dentist\Views\Blog\Index.cshtml"
                         for (int i = 1; i <= ViewBag.PageCount; i++)
                        {
                            if (ViewBag.Page == null)
                            {
                                if (i == 1)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <li class=\"active\"><span><a class=\"disabled\"");
            BeginWriteAttribute("href", " href=\"", 3400, "\"", 3426, 2);
            WriteAttributeValue("", 3407, "/Blog/Index?page=", 3407, 17, true);
#nullable restore
#line 65 "C:\Users\Admin\Desktop\DentistBackend\Dentist\Dentist\Views\Blog\Index.cshtml"
WriteAttributeValue("", 3424, i, 3424, 2, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 65 "C:\Users\Admin\Desktop\DentistBackend\Dentist\Dentist\Views\Blog\Index.cshtml"
                                                                                                       Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a> </span></li>\r\n");
#nullable restore
#line 66 "C:\Users\Admin\Desktop\DentistBackend\Dentist\Dentist\Views\Blog\Index.cshtml"
                                }
                                else
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <li class=\"active\"><span><a");
            BeginWriteAttribute("href", " href=\"", 3620, "\"", 3646, 2);
            WriteAttributeValue("", 3627, "/Blog/Index?page=", 3627, 17, true);
#nullable restore
#line 69 "C:\Users\Admin\Desktop\DentistBackend\Dentist\Dentist\Views\Blog\Index.cshtml"
WriteAttributeValue("", 3644, i, 3644, 2, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 69 "C:\Users\Admin\Desktop\DentistBackend\Dentist\Dentist\Views\Blog\Index.cshtml"
                                                                                      Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></span></li>\r\n");
#nullable restore
#line 70 "C:\Users\Admin\Desktop\DentistBackend\Dentist\Dentist\Views\Blog\Index.cshtml"
                                }
                            }
                            else
                            {
                                if (i == ViewBag.Page)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <li class=\"active\"><span><a class=\"disabled\"");
            BeginWriteAttribute("href", " href=\"", 3970, "\"", 3996, 2);
            WriteAttributeValue("", 3977, "/Blog/Index?page=", 3977, 17, true);
#nullable restore
#line 76 "C:\Users\Admin\Desktop\DentistBackend\Dentist\Dentist\Views\Blog\Index.cshtml"
WriteAttributeValue("", 3994, i, 3994, 2, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 76 "C:\Users\Admin\Desktop\DentistBackend\Dentist\Dentist\Views\Blog\Index.cshtml"
                                                                                                       Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a> </span></li>\r\n");
#nullable restore
#line 77 "C:\Users\Admin\Desktop\DentistBackend\Dentist\Dentist\Views\Blog\Index.cshtml"
                                }
                                else
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <li class=\"active\"><span><a");
            BeginWriteAttribute("href", " href=\"", 4190, "\"", 4216, 2);
            WriteAttributeValue("", 4197, "/Blog/Index?page=", 4197, 17, true);
#nullable restore
#line 80 "C:\Users\Admin\Desktop\DentistBackend\Dentist\Dentist\Views\Blog\Index.cshtml"
WriteAttributeValue("", 4214, i, 4214, 2, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 80 "C:\Users\Admin\Desktop\DentistBackend\Dentist\Dentist\Views\Blog\Index.cshtml"
                                                                                      Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a> </span></li>\r\n");
#nullable restore
#line 81 "C:\Users\Admin\Desktop\DentistBackend\Dentist\Dentist\Views\Blog\Index.cshtml"
                                }
                            }
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </ul>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</section>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Blog>> Html { get; private set; }
    }
}
#pragma warning restore 1591
