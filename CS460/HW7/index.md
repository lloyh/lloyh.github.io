---
title: Luis Loyh
layout: default
---

## Homework 7

This assignment is a single-page responsive application. The page loads from the server and presents an interface to load Gif images that the server pulls from Giphy.com via an API.

### Requirement 1

Has a single page Javascript application; all functionality is driven by AJAX calls Javascript is in a separate file in the Scripts folder and is included via "@section". Uses jQuery.

```js
$("#searchButton").click(function () {
    size = $("#imageSize").val();
    $.ajax({
        type: "GET",
        dataType: "json",
        url: "/GetGifs?search=" + $("#searchBox").val() + "&limit=" + $("#limit").val(),
        success: displayData,
        error: function () { alert("Error: Unable to get search results!"); }
        });
});
```

```csharp
[HttpGet]
public JsonResult SearchGiphy()
{
	List<SearchResult> searchResult = new List<SearchResult>();
	int limit;
	try
	{
		limit = Convert.ToInt32(Request.QueryString[name: "limit"]);
		limit = (limit > 20) ? 20 : limit;
	}
	catch(Exception e)
	{
		SearchResult result = new SearchResult();
		result.msg = "error-result";
		searchResult.Add(result);
		return Json(searchResult, JsonRequestBehavior.AllowGet);
	}
	//check if client sent an empty search string or corrupted limit data
	if (Request.QueryString["search"] == "" || Request.QueryString["search"] == null || limit < 1)
	{
		SearchResult result = new SearchResult();
		result.msg = "error-result";
		searchResult.Add(result);
		return Json(searchResult, JsonRequestBehavior.AllowGet);
	}

	string url = "https://api.giphy.com/v1/gifs/search?api_key="
			   + System.Web.Configuration.WebConfigurationManager.AppSettings["APIKey"]
			   + "&q="
			   + Request.QueryString["search"]
			   + "&limit="
			   + limit.ToString();


	WebRequest webRequest = WebRequest.Create(url);
	Stream theStream = webRequest.GetResponse().GetResponseStream();
	StreamReader reader = new StreamReader(theStream);

	RootObject jsonResult = new System.Web.Script.Serialization.JavaScriptSerializer()
						  .Deserialize<RootObject>(reader.ReadToEnd());

	for (int i = 0; i < limit; i++)
	{
		SearchResult result = new SearchResult();
		result.image = jsonResult.data[i].images.downsized_medium.url;
		searchResult.Add(result);
	}

	var record = MyDB.Searches.Create();
	record.QUERY = Request.QueryString["search"];
	record.IP_ADDRESS = Request.UserHostAddress;
	record.USERAGENT = Request.UserAgent;
	record.SEARCH_DATE = DateTime.Now;

	MyDB.Searches.Add(record);
	MyDB.SaveChanges();

	return Json(searchResult, JsonRequestBehavior.AllowGet);
}
```

### Requirement 2
Uses at least one custom routing rule in RouteConfig.cs that makes sense and routes to a new controller that isn’t Home. Routes to the GiphyController using ```/GetGifs?search=term&limit=xx```.

```csharp
routes.MapRoute(
	name: "GetGifs",
	url: "GetGifs",
	defaults: new { controller = "Giphy", action = "SearchGiphy" }
 );

```

### Requirement 3
Has custom CSS in Contents; page looks nice Has a database for Logging; successfully logs every request; uses a script to create this database The page works, searches Giphy and shows results in a grid; is responsive. 
```css
.pictureFrame{
    float: left;
    margin: 5px;
}

.frame-sm {
    width: 250px;
    width: 250px;
}

.frame-md {
    width: 350px;
    width: 350px;
}

.frame-lg {
    width: 450px;
    width: 450px;
}
```

### Requirement 4
Uses JSON for AJAX calls; JSON object is used client-side to modify the DOM and build the search results.

```js
function displayData(data) {
    $("#outputBox").empty();
    $.each(data, function (i, image) {
        if (image["msg"] == "error-result") {
            alert("Invalid Data Entered!");
        }
        else {
            $("#outputBox").append(
                "<div class='pictureFrame'><img class='img-responsive' src='"
                + image["image"]
                + "' />"
                + "</div>"
                );
        }
    });
    changeSize();
}
```

### Requirement 5
Has additional client side options/functionality, beyond simple search by topic. This site allows the user to choose the image size which is processed locally on the client using JavaScript.

```js
$("#imageSize").change(function(){ changeSize();});

function changeSize() {
    size = $("#imageSize").val();
    if (size == 0) {
        $(".pictureFrame").addClass("frame-sm");
        $(".pictureFrame").removeClass("frame-md");
        $(".pictureFrame").removeClass("frame-lg");
    }
    else if (size == 1) {
        $(".pictureFrame").removeClass("frame-sm");
        $(".pictureFrame").addClass("frame-md");
        $(".pictureFrame").removeClass("frame-lg");
    }
    else {
        $(".pictureFrame").removeClass("frame-sm");
        $(".pictureFrame").removeClass("frame-md");
        $(".pictureFrame").addClass("frame-lg");
    }
}
```

### Requirement 6
Has additional server side processing (beyond topic search). This site allows the user to choose number of images returned during their search and is processed by the server.

```csharp
int limit;
try
{
	limit = Convert.ToInt32(Request.QueryString[name: "limit"]);
	limit = (limit > 20) ? 20 : limit;
}
catch(Exception e)
{
	SearchResult result = new SearchResult();
	result.msg = "error-result";
	searchResult.Add(result);
 }

for (int i = 0; i < limit; i++)
{
	SearchResult result = new SearchResult();
	result.image = jsonResult.data[i].images.downsized_medium.url;
	searchResult.Add(result);
}
```

### Requirement 7
Code and screenshots are nicely arranged into the Portfolio; Portfolio is organized and easy to read.

### Video of the Application

<iframe width="560" height="315" src="https://www.youtube.com/embed/2-zd_4pNnMY?rel=0&amp;controls=0&amp;showinfo=0&amp;autoplay=1&amp;loop=1&amp;playlist=yuS1zEkQh5I" frameborder="0" gesture="media" allowfullscreen></iframe>