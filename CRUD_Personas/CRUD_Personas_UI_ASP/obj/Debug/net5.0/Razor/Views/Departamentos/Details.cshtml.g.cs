#pragma checksum "C:\Users\aruiz\Documents\GitHub\DEINT\CRUD_Personas\CRUD_Personas_UI_ASP\Views\Departamentos\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f73ba7b10df7b9ec7905ab6e24d7a4f057f300c9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Departamentos_Details), @"mvc.1.0.view", @"/Views/Departamentos/Details.cshtml")]
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
#line 1 "C:\Users\aruiz\Documents\GitHub\DEINT\CRUD_Personas\CRUD_Personas_UI_ASP\Views\_ViewImports.cshtml"
using CRUD_Personas_UI_ASP;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\aruiz\Documents\GitHub\DEINT\CRUD_Personas\CRUD_Personas_UI_ASP\Views\_ViewImports.cshtml"
using CRUD_Personas_UI_ASP.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f73ba7b10df7b9ec7905ab6e24d7a4f057f300c9", @"/Views/Departamentos/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b1483699679eae6eb7bfabaa9ec88fde8af1d8a0", @"/Views/_ViewImports.cshtml")]
    public class Views_Departamentos_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CRUD_Personas_UI_ASP.Models.ViewModels.ClsDepartamentoConPersonasSimplificadasVM>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\aruiz\Documents\GitHub\DEINT\CRUD_Personas\CRUD_Personas_UI_ASP\Views\Departamentos\Details.cshtml"
  
    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<!DOCTYPE html>\r\n\r\n<html>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f73ba7b10df7b9ec7905ab6e24d7a4f057f300c94126", async() => {
                WriteLiteral("\r\n    <meta name=\"viewport\" content=\"width=device-width\" />\r\n    <title>Details</title>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f73ba7b10df7b9ec7905ab6e24d7a4f057f300c95187", async() => {
                WriteLiteral("\r\n\r\n    <div>\r\n        <h1>Details Departamento</h1>\r\n        \r\n        <hr />\r\n        <dl class=\"row\">\r\n            <dt class=\"col-sm-2\">\r\n                <strong>");
#nullable restore
#line 22 "C:\Users\aruiz\Documents\GitHub\DEINT\CRUD_Personas\CRUD_Personas_UI_ASP\Views\Departamentos\Details.cshtml"
                   Write(Html.DisplayNameFor(model => model.Nombre));

#line default
#line hidden
#nullable disable
                WriteLiteral("</strong> ");
#nullable restore
#line 22 "C:\Users\aruiz\Documents\GitHub\DEINT\CRUD_Personas\CRUD_Personas_UI_ASP\Views\Departamentos\Details.cshtml"
                                                                        Write(Html.DisplayFor(model => model.Nombre));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n            </dt>\r\n            <strong>");
#nullable restore
#line 24 "C:\Users\aruiz\Documents\GitHub\DEINT\CRUD_Personas\CRUD_Personas_UI_ASP\Views\Departamentos\Details.cshtml"
               Write(Html.DisplayNameFor(model => model.ListaPersonas));

#line default
#line hidden
#nullable disable
                WriteLiteral("</strong>\r\n");
#nullable restore
#line 25 "C:\Users\aruiz\Documents\GitHub\DEINT\CRUD_Personas\CRUD_Personas_UI_ASP\Views\Departamentos\Details.cshtml"
              
                if (Model.ListaPersonas.Count > 0) //Si el departamento tiene asignado alguna persona
                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                    <ul>\r\n");
#nullable restore
#line 29 "C:\Users\aruiz\Documents\GitHub\DEINT\CRUD_Personas\CRUD_Personas_UI_ASP\Views\Departamentos\Details.cshtml"
                         foreach (ClsPersonaNombreApellidos persona in Model.ListaPersonas)
                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                            <li>");
#nullable restore
#line 31 "C:\Users\aruiz\Documents\GitHub\DEINT\CRUD_Personas\CRUD_Personas_UI_ASP\Views\Departamentos\Details.cshtml"
                           Write(persona.Nombre);

#line default
#line hidden
#nullable disable
                WriteLiteral("  ");
#nullable restore
#line 31 "C:\Users\aruiz\Documents\GitHub\DEINT\CRUD_Personas\CRUD_Personas_UI_ASP\Views\Departamentos\Details.cshtml"
                                            Write(persona.Apellidos);

#line default
#line hidden
#nullable disable
                WriteLiteral("</li>\r\n");
#nullable restore
#line 32 "C:\Users\aruiz\Documents\GitHub\DEINT\CRUD_Personas\CRUD_Personas_UI_ASP\Views\Departamentos\Details.cshtml"
                        }

#line default
#line hidden
#nullable disable
                WriteLiteral("                    </ul>\r\n");
#nullable restore
#line 34 "C:\Users\aruiz\Documents\GitHub\DEINT\CRUD_Personas\CRUD_Personas_UI_ASP\Views\Departamentos\Details.cshtml"
                }
                else
                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                    <p>No hay personas asignadas a este departamento</p>\r\n");
#nullable restore
#line 38 "C:\Users\aruiz\Documents\GitHub\DEINT\CRUD_Personas\CRUD_Personas_UI_ASP\Views\Departamentos\Details.cshtml"
                }
            

#line default
#line hidden
#nullable disable
                WriteLiteral("        </dl>\r\n    </div>\r\n    <div>\r\n        ");
#nullable restore
#line 43 "C:\Users\aruiz\Documents\GitHub\DEINT\CRUD_Personas\CRUD_Personas_UI_ASP\Views\Departamentos\Details.cshtml"
   Write(Html.ActionLink("Edit", "Edit", new { id = Model.ID }));

#line default
#line hidden
#nullable disable
                WriteLiteral(" |\r\n        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f73ba7b10df7b9ec7905ab6e24d7a4f057f300c99232", async() => {
                    WriteLiteral("Back to List");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    </div>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</html>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CRUD_Personas_UI_ASP.Models.ViewModels.ClsDepartamentoConPersonasSimplificadasVM> Html { get; private set; }
    }
}
#pragma warning restore 1591
