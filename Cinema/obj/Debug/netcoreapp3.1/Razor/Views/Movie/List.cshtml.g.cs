#pragma checksum "C:\Users\User\source\NIKITA\Cinema\Cinema\Views\Movie\List.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ddba57a3ea24273f62c499ac9f7d3b40e41abc26"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Movie_List), @"mvc.1.0.view", @"/Views/Movie/List.cshtml")]
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
#line 1 "C:\Users\User\source\NIKITA\Cinema\Cinema\Views\_ViewImports.cshtml"
using Cinema;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\User\source\NIKITA\Cinema\Cinema\Views\_ViewImports.cshtml"
using Cinema.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\User\source\NIKITA\Cinema\Cinema\Views\_ViewImports.cshtml"
using Cinema.Dal.Dbo;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\User\source\NIKITA\Cinema\Cinema\Views\_ViewImports.cshtml"
using Cinema.Dal.Data;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ddba57a3ea24273f62c499ac9f7d3b40e41abc26", @"/Views/Movie/List.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b65441d4b8c30076fd71d4cfa7d8dbcca91ba3fd", @"/Views/_ViewImports.cshtml")]
    public class Views_Movie_List : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<MovieListViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<h2>Все фильмы</h2>\r\n");
#nullable restore
#line 4 "C:\Users\User\source\NIKITA\Cinema\Cinema\Views\Movie\List.cshtml"
  
    foreach (var movie in Model.Movies)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div>\r\n            <h2>\r\n                Фильмы: ");
#nullable restore
#line 9 "C:\Users\User\source\NIKITA\Cinema\Cinema\Views\Movie\List.cshtml"
                   Write(movie.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </h2>\r\n            <h3>\r\n                в главных ролях: ");
#nullable restore
#line 12 "C:\Users\User\source\NIKITA\Cinema\Cinema\Views\Movie\List.cshtml"
                            Write(movie.Starring);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </h3>\r\n            <h4>\r\n                дата выхода :");
#nullable restore
#line 15 "C:\Users\User\source\NIKITA\Cinema\Cinema\Views\Movie\List.cshtml"
                        Write(movie.ReleaseDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </h4>\r\n        </div>\r\n");
#nullable restore
#line 18 "C:\Users\User\source\NIKITA\Cinema\Cinema\Views\Movie\List.cshtml"

    }


#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<MovieListViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
