#pragma checksum "/home/codio/workspace/cta-web/Views/RidershipByDay.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2e9de1205cef21ff60bc82a1a526809ce5e4fef5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(program.Pages.Views_RidershipByDay), @"mvc.1.0.razor-page", @"/Views/RidershipByDay.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure.RazorPageAttribute(@"/Views/RidershipByDay.cshtml", typeof(program.Pages.Views_RidershipByDay), null)]
namespace program.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "/home/codio/workspace/cta-web/Views/_ViewImports.cshtml"
using program;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2e9de1205cef21ff60bc82a1a526809ce5e4fef5", @"/Views/RidershipByDay.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e911b8447e269fac6d3a65c717afe71141f66421", @"/Views/_ViewImports.cshtml")]
    public class Views_RidershipByDay : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 3 "/home/codio/workspace/cta-web/Views/RidershipByDay.cshtml"
    
  var Labels = Newtonsoft.Json.JsonConvert.SerializeObject(Model.Days);
  var Totals = Newtonsoft.Json.JsonConvert.SerializeObject(Model.NumRiders);

  ViewData["Title"] = "Total Ridership by Day";

#line default
#line hidden
            BeginContext(240, 54, true);
            WriteLiteral("\n<h2>Total Ridership per Day</h2>  \n\n<br />\nRaw data: ");
            EndContext();
            BeginContext(295, 16, false);
#line 13 "/home/codio/workspace/cta-web/Views/RidershipByDay.cshtml"
     Write(Html.Raw(Totals));

#line default
#line hidden
            EndContext();
            BeginContext(311, 16, true);
            WriteLiteral("\n<br />\n<br />\n\n");
            EndContext();
#line 17 "/home/codio/workspace/cta-web/Views/RidershipByDay.cshtml"
  
   if (@Model.EX != null)
	 {

#line default
#line hidden
            BeginContext(360, 37, true);
            WriteLiteral("\t   <br />\n\t\t <br />\n\t\t <h3>**ERROR: ");
            EndContext();
            BeginContext(398, 16, false);
#line 22 "/home/codio/workspace/cta-web/Views/RidershipByDay.cshtml"
                 Write(Model.EX.Message);

#line default
#line hidden
            EndContext();
            BeginContext(414, 46, true);
            WriteLiteral("</h3>\n\t\t <br />\n\t\t <hr />\n\t\t <br />\n\t\t <br />\n");
            EndContext();
#line 27 "/home/codio/workspace/cta-web/Views/RidershipByDay.cshtml"
	 }

#line default
#line hidden
            BeginContext(466, 350, true);
            WriteLiteral(@"
<div class=""box-body"">  
  <div class=""chart-container"">  
     <canvas id=""myChart""></canvas>  
  </div>  
</div>  

<script src=""https://cdnjs.cloudflare.com/ajax/libs/Chart.js/2.7.3/Chart.bundle.min.js""></script>

<script>
var ctx = document.getElementById(""myChart"");
var myChart = new Chart(ctx, {
    type: 'line',
    data: {
        labels: ");
            EndContext();
            BeginContext(817, 16, false);
#line 43 "/home/codio/workspace/cta-web/Views/RidershipByDay.cshtml"
           Write(Html.Raw(Labels));

#line default
#line hidden
            EndContext();
            BeginContext(833, 77, true);
            WriteLiteral(",\n        datasets: [{\n            label: \"# of riders\",  \n            data: ");
            EndContext();
            BeginContext(911, 16, false);
#line 46 "/home/codio/workspace/cta-web/Views/RidershipByDay.cshtml"
             Write(Html.Raw(Totals));

#line default
#line hidden
            EndContext();
            BeginContext(927, 342, true);
            WriteLiteral(@",
            borderColor: ""blue"",
            pointBackgroundColor: ""black"",
            backgroundColor: ""yellow"",
            borderWidth: 1
        }]
    },
    options: {
        scales: {
            yAxes: [{
                ticks: {
                    beginAtZero:true
                }
            }]
        }
    }
});
</script>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<RidershipByDayModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<RidershipByDayModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<RidershipByDayModel>)PageContext?.ViewData;
        public RidershipByDayModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
