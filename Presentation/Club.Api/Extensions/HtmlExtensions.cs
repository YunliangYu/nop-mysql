using System;
using System.Text;
using System.Web.Mvc;
using Club.Core;
using Club.Core.Infrastructure;
using Club.Web.Framework.UI.Paging;

namespace Club.Web.Extensions
{
    public static class HtmlExtensions
    {
        /// <summary>
        /// BBCode editor
        /// </summary>
        /// <typeparam name="TModel">Model</typeparam>
        /// <param name="html">HTML Helper</param>
        /// <param name="name">Name</param>
        /// <returns>Editor</returns>
        public static MvcHtmlString BBCodeEditor<TModel>(this HtmlHelper<TModel> html, string name)
        {
            var sb = new StringBuilder();

            var storeLocation = EngineContext.Current.Resolve<IWebHelper>().GetStoreLocation();
            string bbEditorWebRoot = String.Format("{0}Content/", storeLocation);

            sb.AppendFormat("<script src=\"{0}Content/BBEditor/ed.js\" type=\"{1}\"></script>", storeLocation, MimeTypes.TextJavascript);
            sb.AppendLine();
            sb.AppendFormat("<script language=\"javascript\" type=\"{0}\">", MimeTypes.TextJavascript);
            sb.AppendLine();
            sb.AppendFormat("edToolbar('{0}','{1}');", name, bbEditorWebRoot);
            sb.AppendLine();
            sb.Append("</script>");
            sb.AppendLine();

            return MvcHtmlString.Create(sb.ToString());
        }
  
         public static Pager Pager(this HtmlHelper helper, IPageableModel pagination)
        {
            return new Pager(pagination, helper.ViewContext);
        }
    }
}

