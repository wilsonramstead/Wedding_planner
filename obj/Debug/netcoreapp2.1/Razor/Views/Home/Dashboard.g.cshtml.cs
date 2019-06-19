#pragma checksum "/Users/wilsonramstead/Desktop/CodingDojo/stacks/C#/ORMs/entity/wedding_planner/Views/Home/Dashboard.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a04fcec5fc2d3b38c8955e75c27ef324485c769a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Dashboard), @"mvc.1.0.view", @"/Views/Home/Dashboard.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Dashboard.cshtml", typeof(AspNetCore.Views_Home_Dashboard))]
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
#line 1 "/Users/wilsonramstead/Desktop/CodingDojo/stacks/C#/ORMs/entity/wedding_planner/Views/_ViewImports.cshtml"
using wedding_planner;

#line default
#line hidden
#line 2 "/Users/wilsonramstead/Desktop/CodingDojo/stacks/C#/ORMs/entity/wedding_planner/Views/_ViewImports.cshtml"
using wedding_planner.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a04fcec5fc2d3b38c8955e75c27ef324485c769a", @"/Views/Home/Dashboard.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e0aadd694686a14c367f0150bd67bec2e71f0b6a", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Dashboard : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Wedding>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 1, true);
            WriteLiteral("\n");
            EndContext();
            BeginContext(22, 304, true);
            WriteLiteral(@"
<div class=""header"">
    <h1>Welcome to the Wedding Planner</h1>
    <a href=""/logout"">Log Out</a>
</div>

<table class=""table"">
    <thead>
        <tr>
            <th>Wedding</th>
            <th>Date</th>
            <th>Guest</th>
            <th>Action</th>
        </tr>
    </thead>
    <tbody>
");
            EndContext();
#line 19 "/Users/wilsonramstead/Desktop/CodingDojo/stacks/C#/ORMs/entity/wedding_planner/Views/Home/Dashboard.cshtml"
      
        foreach(Wedding w in Model)
        {

#line default
#line hidden
            BeginContext(379, 31, true);
            WriteLiteral("        <tr>\n            <td><a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 410, "\"", 442, 2);
            WriteAttributeValue("", 417, "/showwedding/", 417, 13, true);
#line 23 "/Users/wilsonramstead/Desktop/CodingDojo/stacks/C#/ORMs/entity/wedding_planner/Views/Home/Dashboard.cshtml"
WriteAttributeValue("", 430, w.WeddingID, 430, 12, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(443, 2, true);
            WriteLiteral("> ");
            EndContext();
            BeginContext(446, 7, false);
#line 23 "/Users/wilsonramstead/Desktop/CodingDojo/stacks/C#/ORMs/entity/wedding_planner/Views/Home/Dashboard.cshtml"
                                                Write(w.Name1);

#line default
#line hidden
            EndContext();
            BeginContext(453, 3, true);
            WriteLiteral(" & ");
            EndContext();
            BeginContext(457, 7, false);
#line 23 "/Users/wilsonramstead/Desktop/CodingDojo/stacks/C#/ORMs/entity/wedding_planner/Views/Home/Dashboard.cshtml"
                                                           Write(w.Name2);

#line default
#line hidden
            EndContext();
            BeginContext(464, 26, true);
            WriteLiteral("</a></td>\n            <td>");
            EndContext();
            BeginContext(491, 31, false);
#line 24 "/Users/wilsonramstead/Desktop/CodingDojo/stacks/C#/ORMs/entity/wedding_planner/Views/Home/Dashboard.cshtml"
           Write(w.Date.ToString("MMMM dd yyyy"));

#line default
#line hidden
            EndContext();
            BeginContext(522, 22, true);
            WriteLiteral("</td>\n            <td>");
            EndContext();
            BeginContext(545, 16, false);
#line 25 "/Users/wilsonramstead/Desktop/CodingDojo/stacks/C#/ORMs/entity/wedding_planner/Views/Home/Dashboard.cshtml"
           Write(w.Weddings.Count);

#line default
#line hidden
            EndContext();
            BeginContext(561, 6, true);
            WriteLiteral("</td>\n");
            EndContext();
#line 26 "/Users/wilsonramstead/Desktop/CodingDojo/stacks/C#/ORMs/entity/wedding_planner/Views/Home/Dashboard.cshtml"
              
                if(ViewBag.ID == @w.CreatorID)
                {
                    

#line default
#line hidden
            BeginContext(668, 26, true);
            WriteLiteral("                    <td><a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 694, "\"", 721, 2);
            WriteAttributeValue("", 701, "/delete/", 701, 8, true);
#line 30 "/Users/wilsonramstead/Desktop/CodingDojo/stacks/C#/ORMs/entity/wedding_planner/Views/Home/Dashboard.cshtml"
WriteAttributeValue("", 709, w.WeddingID, 709, 12, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(722, 17, true);
            WriteLiteral(">Delete</a></td>\n");
            EndContext();
#line 31 "/Users/wilsonramstead/Desktop/CodingDojo/stacks/C#/ORMs/entity/wedding_planner/Views/Home/Dashboard.cshtml"
                }
                else
                {
                    bool attending = false;
                    foreach(Event e in w.Weddings)
                    {
                        if(e.UserID == ViewBag.ID)
                        {
                            attending = true;
                        }
                    }
                    if(attending)
                    {

#line default
#line hidden
            BeginContext(1140, 30, true);
            WriteLiteral("                        <td><a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1170, "\"", 1207, 2);
            WriteAttributeValue("", 1177, "/undoprocessevent/", 1177, 18, true);
#line 44 "/Users/wilsonramstead/Desktop/CodingDojo/stacks/C#/ORMs/entity/wedding_planner/Views/Home/Dashboard.cshtml"
WriteAttributeValue("", 1195, w.WeddingID, 1195, 12, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1208, 18, true);
            WriteLiteral(">Un-RSVP</a></td>\n");
            EndContext();
#line 45 "/Users/wilsonramstead/Desktop/CodingDojo/stacks/C#/ORMs/entity/wedding_planner/Views/Home/Dashboard.cshtml"
                    }
                    else
                    {

#line default
#line hidden
            BeginContext(1295, 30, true);
            WriteLiteral("                        <td><a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1325, "\"", 1358, 2);
            WriteAttributeValue("", 1332, "/processevent/", 1332, 14, true);
#line 48 "/Users/wilsonramstead/Desktop/CodingDojo/stacks/C#/ORMs/entity/wedding_planner/Views/Home/Dashboard.cshtml"
WriteAttributeValue("", 1346, w.WeddingID, 1346, 12, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1359, 15, true);
            WriteLiteral(">RSVP</a></td>\n");
            EndContext();
#line 49 "/Users/wilsonramstead/Desktop/CodingDojo/stacks/C#/ORMs/entity/wedding_planner/Views/Home/Dashboard.cshtml"
                    }
                }
            

#line default
#line hidden
            BeginContext(1428, 14, true);
            WriteLiteral("        </tr>\n");
            EndContext();
#line 53 "/Users/wilsonramstead/Desktop/CodingDojo/stacks/C#/ORMs/entity/wedding_planner/Views/Home/Dashboard.cshtml"
        }
    

#line default
#line hidden
            BeginContext(1458, 56, true);
            WriteLiteral("    </tbody>\n</table>\n<button class=\"btn btn-primary\"><a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1514, "\"", 1547, 2);
            WriteAttributeValue("", 1521, "/createwedding/", 1521, 15, true);
#line 57 "/Users/wilsonramstead/Desktop/CodingDojo/stacks/C#/ORMs/entity/wedding_planner/Views/Home/Dashboard.cshtml"
WriteAttributeValue("", 1536, ViewBag.ID, 1536, 11, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1548, 25, true);
            WriteLiteral(">New Wedding</a></button>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Wedding>> Html { get; private set; }
    }
}
#pragma warning restore 1591