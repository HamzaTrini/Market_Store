#pragma checksum "C:\Users\HamzaTrini\Desktop\visual_studio\MarketStore\MarketStore\Views\Home\BuyProduct.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1717d78a843493dfc9fdedc477593fcaf64c5382"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_BuyProduct), @"mvc.1.0.view", @"/Views/Home/BuyProduct.cshtml")]
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
#line 1 "C:\Users\HamzaTrini\Desktop\visual_studio\MarketStore\MarketStore\Views\_ViewImports.cshtml"
using MarketStore;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\HamzaTrini\Desktop\visual_studio\MarketStore\MarketStore\Views\_ViewImports.cshtml"
using MarketStore.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1717d78a843493dfc9fdedc477593fcaf64c5382", @"/Views/Home/BuyProduct.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b1820e61c2dee8ca409468eb17dcadd317f64a5b", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Home_BuyProduct : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Tuple<IEnumerable<MarketStore.Models.OrderFp>, IEnumerable<MarketStore.Models.ProductFp>, IEnumerable<MarketStore.Models.OrderProductFp>>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("height", new global::Microsoft.AspNetCore.Html.HtmlString("150px"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("border-radius:15px; position:relative;\r\n                           left:108px;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "BuyProduct", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Cart", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ImageTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\HamzaTrini\Desktop\visual_studio\MarketStore\MarketStore\Views\Home\BuyProduct.cshtml"
  
	Layout="~/Views/Shared/_Home.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<style>
.mar11 {
    margin: auto;
}

</style>
<!-- Title page -->
	<section class=""bg-img1 txt-center p-lr-15 p-tb-92"" style=""background-image: url('/Home/images/bg-01.jpg');"">
		<h2 class=""ltext-105 cl0 txt-center"">
			Buy Product
		</h2>
	</section>	

	<!-- Content page -->
	<section class=""bg0 p-t-104 p-b-116"">
		<div class=""container"">
			<div class=""flex-w flex-tr"">
				
");
#nullable restore
#line 24 "C:\Users\HamzaTrini\Desktop\visual_studio\MarketStore\MarketStore\Views\Home\BuyProduct.cshtml"
                 foreach(var item in Model.Item3){

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t<div class=\"size-210 bor10 p-lr-70 p-t-55 p-b-70 p-lr-15-lg w-full-md mar11\">\r\n\t\t\t\t\t");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1717d78a843493dfc9fdedc477593fcaf64c53826070", async() => {
                WriteLiteral("\r\n\t\t\t\t\t\t<h4 class=\"mtext-105 cl2 txt-center p-b-30\">\r\n\t\t\t\t\t\t\t");
#nullable restore
#line 28 "C:\Users\HamzaTrini\Desktop\visual_studio\MarketStore\MarketStore\Views\Home\BuyProduct.cshtml"
                       Write(item.Product.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n\t\t\t\t\t\t</h4>\r\n\t\t\t\t\t\t ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "1717d78a843493dfc9fdedc477593fcaf64c53826703", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ImageTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper);
                BeginWriteTagHelperAttribute();
#nullable restore
#line 30 "C:\Users\HamzaTrini\Desktop\visual_studio\MarketStore\MarketStore\Views\Home\BuyProduct.cshtml"
                      WriteLiteral(Url.Content("~/Home/images/" + item.Product.ImagePath));

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper.Src = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("src", __Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper.Src, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 30 "C:\Users\HamzaTrini\Desktop\visual_studio\MarketStore\MarketStore\Views\Home\BuyProduct.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper.AppendVersion = true;

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-append-version", __Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper.AppendVersion, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n\t\t\t\t\t\t <br/>\r\n\t\t\t\t\t\t\t\t<span class=\"ltext-101 cl2 respon2\">\r\n\t\t\t\t\t\t\t\t\tPrice\r\n\t\t\t\t\t\t\t\t</span>\r\n\t\t\t\t\t\t\t\r\n\t\t\t\t\t\t\t\t<h2 class=\"ltext-201 cl2 p-t-19 p-b-43 respon1\">\r\n\t\t\t\t\t\t\t\t$");
#nullable restore
#line 39 "C:\Users\HamzaTrini\Desktop\visual_studio\MarketStore\MarketStore\Views\Home\BuyProduct.cshtml"
                            Write(item.Product.Price);

#line default
#line hidden
#nullable disable
                WriteLiteral(@".00
								</h2>
							
						
						<div class=""bor8 m-b-20 how-pos4-parent"">
							<input class=""stext-111 cl2 plh3 size-116 p-l-62 p-r-30"" type=""number"" name=""TotalPrice"" placeholder=""Number Of Quantity "">
							
						</div>
						
						<button class=""flex-c-m stext-101 cl0 size-121 bg3 bor1 hov-btn3 p-lr-15 trans-04 pointer"">
							ADD TO CART
						</button>
					");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-Price", "Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 26 "C:\Users\HamzaTrini\Desktop\visual_studio\MarketStore\MarketStore\Views\Home\BuyProduct.cshtml"
                                                       WriteLiteral(item.Product.Price);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["Price"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-Price", __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["Price"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\t\t\t\t\t<br/>\r\n\t\t\t\t\t<br/>\r\n\t\t\t\t\t  ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1717d78a843493dfc9fdedc477593fcaf64c538212219", async() => {
                WriteLiteral("Go To Cart");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(" |\r\n");
            WriteLiteral("\t\t\t\t</div>\r\n");
#nullable restore
#line 57 "C:\Users\HamzaTrini\Desktop\visual_studio\MarketStore\MarketStore\Views\Home\BuyProduct.cshtml"
				}

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t</div>\r\n\t\t\t\t</div>\r\n\t\t\t\t</section>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Tuple<IEnumerable<MarketStore.Models.OrderFp>, IEnumerable<MarketStore.Models.ProductFp>, IEnumerable<MarketStore.Models.OrderProductFp>>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
