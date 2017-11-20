---
title: Luis Loyh
layout: default
---

<div style="overflow: hidden; background-color: #333; color: white; width: 50px; padding: 0.5em; text-align: center" onclick="window.location='https://lloyh.github.io/home';">Home</div>

# **********UNDER CONSTRUCTION****************
# Homework 5: ASP.NET MVC 5 Project with a Local Database

In this assignment we were tasked with creating an ASP.NET MVC 5 project with a simple one-table local database. The assignment instructions can be accessed [here.](http://www.wou.edu/~morses/classes/cs46x/assignments/HW5.html) The assignment consists of creating a DMV address change request in which a simple form is presented for someone moving to fill out. The form is submitted and entered into a local database. Another page simply displays the database table with all its records.

The MVC project code I wrote for this homework can be accessed under the following folder in my main portfolio repository for this assignment: [Homework 5]( https://github.com/lloyh/lloyh.github.io/tree/master/CS460/HW5)

### Initial Git Setup

I began this project by creating an initial git branch:

```bash
git checkout -b hmw5-initial_setup
```

This command tries to find branch name “hmw5-initial_setup” and when not found (it creates it given the command string “-b”) and checks it out.
When I was done with this branch I applied the following commands to merge the changes into the master branch:

```bash
git  checkout master
git merge hmw5-initial_setup
```

As I continued wiring the different pieces of code for this assignment I created appropriate branch names and these can be accessed via my repository as outlined above.

I then created a new empty MVC project. The assignment instructions indicate to have a proper .gitignore file so that no temporary, binary and database files will be uploaded to the repository, but I had already placed a robust .gitignore file in the root folder of my repository for the previous MVC project assignment. The file can be accessed [here]( https://github.com/lloyh/lloyh.github.io/blob/master/.gitignore).

### Creating the Data Model

Under the App_Data folder, I added two SQL scripts, the up.sql and down.sql scripts. The up.sql script creates a table in the database and inserts some test values and the down.sql script deletes the table altogether. I used the Visual Studio built-in database LocalDB and added the following connection string to my Web.config file:

```xml
<connectionStrings>
    <add name ="theDBContext" 
         connectionString="Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Luis Loyh\Dropbox\School\Fall 2017\CS 460\Portfolio\CS460\HW5\Homework5\Homework5\App_Data\ChangeDatabase.mdf;Integrated Security=True"
         providerName="System.Data.SqlClient"/>
</connectionStrings>

```

This is the up.sql script
```sql
-- AddressChanges table
CREATE TABLE AddressChanges
(
	ID					INT IDENTITY (1,1) NOT NULL,
	ODL					INT NOT NULL,
	DOB					DATE NOT NULL,		
	FullName			NVARCHAR(100) NOT NULL,
	NewStreetAddress	NVARCHAR(100) NOT NULL,
	NewCity				NVARCHAR(100) NOT NULL,
	NewState			NVARCHAR(100) NOT NULL,
	NewZipCode			INT NOT NULL,
	NewCounty			NVARCHAR(100) NOT NULL,
	DateSubmitted		DATE NOT NULL
	CONSTRAINT [PK_dbo.AddressChanges] PRIMARY KEY CLUSTERED (ID ASC)
);
	

INSERT INTO AddressChanges (ODL, DOB, FullName, NewStreetAddress, NewCity, NewState, NewZipCode, NewCounty, DateSubmitted) VALUES
	(12332132,'1984-11-05','James Tiberius Kirk','4550 Madrona Avenue','Salem','Oregon',97306,'Marion','2017-05-11');
INSERT INTO AddressChanges (ODL, DOB, FullName, NewStreetAddress, NewCity, NewState, NewZipCode, NewCounty, DateSubmitted) VALUES
	(45665465,'1974-07-01','Jean-Luc Picard','5370 Commercial Street','Salem','Oregon',97303,'Marion','2017-04-20');
INSERT INTO AddressChanges (ODL, DOB, FullName, NewStreetAddress, NewCity, NewState, NewZipCode, NewCounty, DateSubmitted) VALUES
	(78998798,'1970-05-07','Benjamin Sisko','309 SW 6th Avenue','Portland','Oregon',97204,'Multnomah','2016-01-01');
INSERT INTO AddressChanges (ODL, DOB, FullName, NewStreetAddress, NewCity, NewState, NewZipCode, NewCounty, DateSubmitted) VALUES
	(15995195,'1980-04-25','Kathryn Janeway','135 Oakway Road','Eugene','Oregon',97401,'Lane','2017-02-15');
INSERT INTO AddressChanges (ODL, DOB, FullName, NewStreetAddress, NewCity, NewState, NewZipCode, NewCounty, DateSubmitted) VALUES
	(75335735,'1980-04-25','Jonathan Archer','1001 North Arney Road','Woodburn','Oregon',97071,'Marion','2017-10-15');
```

This the down.sql script
```sql
-- Delete the table from the database
DROP TABLE AddressChanges;
```

### Creating the model class and the database context class

I wrote the model class (AddressChange.cs) and placed it inside the Model folder and wrote the context class (AddressChangeContext.cs) and placed it inside a new folder named “DAL” (Data Access Layer) as outlined in the assignment requirements. This is so that the data layer is separated from the data processing layer.

The model class code:
```csharp
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Homework5.Models
{
    public class AddressChange
    {
        [Required]
        [Display(Name = "Change ID")]
        public int ID { get; set; }

        [Required]
        [Display(Name = "ODL")]
        public int ODL { get; set; }


        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date of Birth")]
        public DateTime DOB { get; set; }


        [Required]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Required]
        [Display(Name = "New Street Address")]
        public string NewStreetAddress { get; set; }

        [Required]
        [Display(Name = "City")]
        public string NewCity { get; set; }

        [Required]
        [Display(Name = "State")]
        public string NewState { get; set; }

        [Required]
        [Display(Name = "Zip Code")]
        public int NewZipCode { get; set; }

        [Required]
        [Display(Name = "County")]
        public string NewCounty { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date Submitted")]
        public DateTime DateSubmitted { get; set; }
    }
}
```

The data context class code:
```csharp
using Homework5.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Homework5.DAL
{
    public class AddressChangeContext : DbContext
    {
            /// <summary>
            /// Context constructor
            /// </summary>
            public AddressChangeContext() : base("name=theDBContext") { }

            /// <summary>
            /// Method that gets and sets each record in the table
            /// </summary>
            public virtual DbSet<AddressChange> AddressChanges { get; set; }

    }
}
```


















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