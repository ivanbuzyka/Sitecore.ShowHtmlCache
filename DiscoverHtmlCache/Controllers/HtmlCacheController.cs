using System.Collections.Generic;
using System.Web.Mvc;

namespace DiscoverHtmlCache.Controllers
{
  public class HtmlCacheController : Controller
  {
    // GET: HtmlCache
    [HttpGet]
    public ActionResult Index(string sitename = "website")
    {
      // default value            

      Dictionary<string, string> cacheContents = new Dictionary<string, string>();
      Sitecore.Sites.SiteContext siteContext = Sitecore.Sites.SiteContext.GetSite(sitename);

      if (siteContext == null)
      {
        return Json(new { result = string.Format("The site '{0}' does not exist", sitename) }, JsonRequestBehavior.AllowGet);
      }

      Sitecore.Caching.HtmlCache htmlCache = Sitecore.Caching.CacheManager.GetHtmlCache(siteContext);
      var cacheKeys = htmlCache.InnerCache.GetCacheKeys();

      foreach (var sKey in cacheKeys)
      {
        cacheContents.Add(sKey, htmlCache.GetHtml(sKey));
      }

      return Json(new { result = cacheContents }, JsonRequestBehavior.AllowGet);
    }
  }
}