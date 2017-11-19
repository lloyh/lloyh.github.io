---
title: Luis Loyh
layout: default
---

<div style="overflow: hidden; background-color: #333; color: white; width: 50px; padding: 0.5em; text-align: center" onclick="window.location='https://lloyh.github.io/home';">Home</div>


### Homework 5: ASP.NET MVC 5 Project with a Local Database

In this assignment we were tasked with creating an ASP.NET MVC 5 project with a simple one-table local database. The assignment instructions can be accessed [here.](http://www.wou.edu/~morses/classes/cs46x/assignments/HW5.html)

The MVC project code I wrote for this homework can be accessed under the following folder in my main portfolio repository for [this assignment: Homework 5]( https://github.com/lloyh/lloyh.github.io/tree/master/CS460/HW5)

I began this project by creating an initial git branch:

git checkout -b hmw5-initial_setup

This command tries to find branch name “hmw5-initial_setup” and when not found (it creates it given the command string “-b”) and checks it out.
When I was done with this branch I applied the following commands to merge the changes into the master branch:

git  checkout master
git merge hmw5-initial_setup

As I continued wiring the different pieces of code for this assignment I created appropriate branch names and these can be accessed via my repository as outlined above.


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