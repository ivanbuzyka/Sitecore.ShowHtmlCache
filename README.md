# Sitecore.ShowHtmlCache tool
The tool shows HTML cache (component cache) contents for a specific site

## Get started

1. Build solution (make sure Sitecore DLLs from the right Sitecore version are referenced, Sitecore Nuget is used here)
2. Copy DLL to the ```bin``` folder of your CD instance
3. Request website on the CD instance, surf through the pages where you have cached components (in order to fill up HTML cache)
4. Call the controller action: ```https://your-cd-host-name/api/mysuperapi/HtmlCache/supermethod?sitename=your-website-name```.

**Note:** pay attention to the customized routing path when calling controller action. You can change it to the one you need/like

**Note:** add the name of your Sitecore Website which component cache you would like to see

Example of the returned value:

```json

{
  "result": {
    "/xsl/sample rendering.xslt_#lang:EN": "<div><h1 class=\"contentTitle\">Sitecore Experience Platform</h1><div class=\"contentDescription\"><p style=\"line-height: 22px;\">From a single connected platform that also integrates with other customer-facing platforms, to a single view of the customer in a big data marketing repository, to completely eliminating much of the complexity that has previously held marketers back, the latest version of Sitecore makes customer experience highly achievable. Learn how the latest version of Sitecore gives marketers the complete data, integrated tools, and automation capabilities to engage customers throughout an iterative lifecycle – the technology foundation absolutely necessary to win customers for life.</p>\r\n<p>For further information, please go to the <a href=\"https://doc.sitecore.net/\" target=\"_blank\" title=\"Sitecore Documentation site\">Sitecore Documentation site</a></p>\r\n</div></div>",
    "/xsl/sample rendering.xslt_#lang:EN_#data:sitecore://web/{3BDC543F-9B8C-4779-813C-6BA6D8785BD3}?lang=en&ver=1": "<div><h1 class=\"contentTitle\">headlesshome</h1><div class=\"contentDescription\"></div></div>"
  }
}

```
