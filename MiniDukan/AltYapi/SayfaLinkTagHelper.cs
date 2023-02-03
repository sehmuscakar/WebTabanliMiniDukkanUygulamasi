using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using MiniDukan.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniDukan.AltYapi
{
    [HtmlTargetElement("div",Attributes="sayfa-model")]
    public class SayfaLinkTagHelper:TagHelper
    {
        private IUrlHelperFactory urlHelperFactory;

        public SayfaLinkTagHelper(IUrlHelperFactory HelperFactory)
        {
            urlHelperFactory = HelperFactory;
        }

        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; }

        public SayfalamaBilgi SayfaModel { get; set; }

        public string SayfaAction { get; set; }


        public bool PageClassEnabled { get; set; } = false;

        public string PageClass { get; set; }

        public string PageClassNormal { get; set; }

        public string PageClassSelected { get; set; }

 public override void Process(TagHelperContext context,TagHelperOutput output)
        {
            IUrlHelper urlHelper = urlHelperFactory.GetUrlHelper(ViewContext);

            TagBuilder sonuc = new TagBuilder("div");
            for(int i = 1; i <= SayfaModel.ToplamSayfalar; i++)
            {
                TagBuilder tag = new TagBuilder("a");
                tag.Attributes["href"] = urlHelper.Action(SayfaAction, new { urunsayfa = i });
                tag.InnerHtml.Append(i.ToString());
                sonuc.InnerHtml.AppendHtml(tag);

                if(PageClassEnabled)
                {
                    tag.AddCssClass(PageClass);
                    tag.AddCssClass(i == SayfaModel.GuncelSayfa ? PageClassSelected : PageClassNormal);
                }

            }

            output.Content.AppendHtml(sonuc.InnerHtml);
        }
    }
}
