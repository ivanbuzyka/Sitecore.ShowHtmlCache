using System.Collections.Generic;
using System.Web.Http;

namespace DiscoverHtmlCache.Controllers
{
  [RoutePrefix("api/mysuperapi/HtmlCache")]
  public class HtmlCacheController : ApiController
  {
    // GET: HtmlCache
    [HttpGet]
    //this is just an example of the routing customization
    // the route to call this method will be <hostname>/api/mysuperapi/HtmlCache/supermethod
    [Route("supermethod")] 
    public IHttpActionResult Index([FromUri] string sitename = "website")
    {
      // default value            

      Dictionary<string, string> cacheContents = new Dictionary<string, string>();
      Sitecore.Sites.SiteContext siteContext = Sitecore.Sites.SiteContext.GetSite(sitename);

      if (siteContext == null)
      {
        return Json(new { result = string.Format("The site '{0}' does not exist", sitename) });
      }

      Sitecore.Caching.HtmlCache htmlCache = Sitecore.Caching.CacheManager.GetHtmlCache(siteContext);
      var cacheKeys = htmlCache.InnerCache.GetCacheKeys();

      foreach (var sKey in cacheKeys)
      {
        cacheContents.Add(sKey, htmlCache.GetHtml(sKey));
      }

      return Json(new { result = cacheContents });
    }
  }
}