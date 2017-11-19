---
title: Luis Loyh
layout: default
---

<div style="overflow: hidden; background-color: #333; color: white" onclick="window.location='https://lloyh.githum.io/home';">Home</div>


### Step X: Creating the model

Here is where I created the model that would represent the data inside the database. *this is very important* **this is even more important** ***This is the most important thing ever!***


```csharp
@model Homework5.Models.AddressChange

@{
    ViewBag.Title = "New Request";
}

<h2>Submit a new Adress Change Request</h2>

@using (Html.BeginForm())
{
    @Html.AntiForgeryToken()
    <div class="row">
        <div class="col-sm-1 col-lg-2"></div>
        <div class="col-sm-10 col-lg-8">
            <div class="form-horizontal">
                <div class="form-group form-group-left">
                    @Html.LabelFor(model => model.ODL, htmlAttributes: new { @class = "control-label" })
                    @Html.EditorFor(model => model.ODL, new { htmlAttributes = new { @class = "form-control" } })
                    @Html.ValidationMessageFor(model => model.ODL, "", new { @class = "text-danger" })
                </div>
                <div class="form-group form-group-left">
                    @Html.LabelFor(model => model.DOB, htmlAttributes: new { @class = "control-label" })
                    @Html.EditorFor(model => model.DOB, new { htmlAttributes = new { @class = "form-control" } })
                    @Html.ValidationMessageFor(model => model.DOB, "", new { @class = "text-danger" })
                </div>

                <div class="form-group form-group-left form-group-full">
                    @Html.LabelFor(model => model.FullName, htmlAttributes: new { @class = "control-label" })
                    @Html.EditorFor(model => model.FullName, new { htmlAttributes = new { @class = "form-control" } })
                    @Html.ValidationMessageFor(model => model.FullName, "", new { @class = "text-danger" })
                </div>
                <div class="form-group form-group-left">
                    @Html.LabelFor(model => model.NewStreetAddress, htmlAttributes: new { @class = "control-label" })
                    @Html.EditorFor(model => model.NewStreetAddress, new { htmlAttributes = new { @class = "form-control" } })
                    @Html.ValidationMessageFor(model => model.NewStreetAddress, "", new { @class = "text-danger" })
                </div>
                <div class="form-group form-group-left">
                    @Html.LabelFor(model => model.NewCity, htmlAttributes: new { @class = "control-label" })
                    @Html.EditorFor(model => model.NewCity, new { htmlAttributes = new { @class = "form-control" } })
                    @Html.ValidationMessageFor(model => model.NewCity, "", new { @class = "text-danger" })
                </div>
                <div class="form-group form-group-left">
                    @Html.LabelFor(model => model.NewState, htmlAttributes: new { @class = "control-label" })
                    @Html.EditorFor(model => model.NewState, new { htmlAttributes = new { @class = "form-control" } })
                    @Html.ValidationMessageFor(model => model.NewState, "", new { @class = "text-danger" })
                </div>
                <div class="form-group form-group-left">
                    @Html.LabelFor(model => model.NewZipCode, htmlAttributes: new { @class = "control-label" })
                    @Html.EditorFor(model => model.NewZipCode, new { htmlAttributes = new { @class = "form-control" } })
                    @Html.ValidationMessageFor(model => model.NewZipCode, "", new { @class = "text-danger" })
                </div>
                <div class="form-group form-group-left">
                    @Html.LabelFor(model => model.NewCounty, htmlAttributes: new { @class = "control-label" })
                    @Html.EditorFor(model => model.NewCounty, new { htmlAttributes = new { @class = "form-control" } })
                    @Html.ValidationMessageFor(model => model.NewCounty, "", new { @class = "text-danger" })
                </div>
                <div class="form-group form-group-left">
                    @Html.LabelFor(model => model.DateSubmitted, htmlAttributes: new { @class = "control-label" })
                    @Html.EditorFor(model => model.DateSubmitted, new { htmlAttributes = new { @class = "form-control" } })
                    @Html.ValidationMessageFor(model => model.DateSubmitted, "", new { @class = "text-danger" })
                </div>
                <div class="form-group form-group-left">
                    <input class="btn btn-primary" type="submit" value="Submit" formmethod="post" />
                    <input class="btn btn-default" type="reset" value="Reset">
                </div>
            </div>
        </div>
        <div class="col-sm-1 col-lg-2"></div>
    </div>
}

```


### Video of Application
<iframe width="560" height="315" src="https://www.youtube.com/embed/yuS1zEkQh5I?rel=0&amp;controls=0&amp;showinfo=0&amp;autoplay=1&amp;loop=1&amp;playlist=yuS1zEkQh5I" frameborder="0" gesture="media" allowfullscreen></iframe>