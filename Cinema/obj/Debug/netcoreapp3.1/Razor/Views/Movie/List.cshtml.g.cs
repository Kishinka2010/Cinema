#pragma checksum "D:\Users\User\Source\Repos\Cinema212\Cinema\Views\Movie\List.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2b62893906ed4b31994871c2eb8af023c125f309"
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
#line 1 "D:\Users\User\Source\Repos\Cinema212\Cinema\Views\_ViewImports.cshtml"
using Cinema;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Users\User\Source\Repos\Cinema212\Cinema\Views\_ViewImports.cshtml"
using Cinema.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\Users\User\Source\Repos\Cinema212\Cinema\Views\_ViewImports.cshtml"
using Cinema.Dal.Dbo;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\Users\User\Source\Repos\Cinema212\Cinema\Views\_ViewImports.cshtml"
using Cinema.Dal.Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\Users\User\Source\Repos\Cinema212\Cinema\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2b62893906ed4b31994871c2eb8af023c125f309", @"/Views/Movie/List.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bc3807dae17343966a92c8db36c7ab81541fe944", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Movie_List : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<MovieListViewModel>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<a class=\"nav-link text-light\" />\r\n<h2>Все фильмы</h2>\r\n");
#nullable restore
#line 5 "D:\Users\User\Source\Repos\Cinema212\Cinema\Views\Movie\List.cshtml"
  
    foreach (var movie in Model.Movies)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div>\r\n            <h2>\r\n                Фильмы: ");
#nullable restore
#line 10 "D:\Users\User\Source\Repos\Cinema212\Cinema\Views\Movie\List.cshtml"
                   Write(movie.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </h2>\r\n            <h3>\r\n                в главных ролях: ");
#nullable restore
#line 13 "D:\Users\User\Source\Repos\Cinema212\Cinema\Views\Movie\List.cshtml"
                            Write(movie.Starring);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </h3>\r\n            <h4>\r\n                дата выхода :");
#nullable restore
#line 16 "D:\Users\User\Source\Repos\Cinema212\Cinema\Views\Movie\List.cshtml"
                        Write(movie.ReleaseDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </h4>\r\n        </div>\r\n");
#nullable restore
#line 19 "D:\Users\User\Source\Repos\Cinema212\Cinema\Views\Movie\List.cshtml"

    }


#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<MovieListViewModel> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
