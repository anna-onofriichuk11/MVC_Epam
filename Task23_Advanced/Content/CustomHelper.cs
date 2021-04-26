using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Task23_Advanced.Content
{
    public static class CustomHelper
    {
        public static MvcHtmlString ConvertToList(this HtmlHelper helper, List<string> elements)
        {
            var div = new TagBuilder("div");
            string result = String.Empty;
            result += "<ul class=\"result-text\">";
            result += "<li>Name: " + elements[0] + "</li>";
            result += "<li>Surname: " + elements[1] + "</li>";
            result += "<li>Email: " + elements[2] + "</li>";
            result += "<li>Gender: " + elements[3] + "</li>";
            result += "<li>Agreement: " + elements[4] + "</li>";
            div.InnerHtml = result;
            var html = div.ToString(TagRenderMode.Normal);

            return MvcHtmlString.Create(html);
        }
    }
}