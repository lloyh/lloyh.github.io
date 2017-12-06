function retrieveGenre(id) {
    $.ajax({
        type: "GET",
        url: "/Home/Genre/" + id,
        dataType: "json",
        success: function (data) { display(data); },
        error: function (data) { alert("Error getting JSon result! Try submitting data again"); }
    });
}

function display(data) {
    $("#artworkOutput").empty();
    var string = "<table class='table table-striped table-hover'>"
        + "<thead><th class='text-center'>Artwork"
        + "</th><th class='text-center'>Artist</th></thead>"
        + "<tbody>";
    $.each(data, function (i, item) {
        string = string
            + "<tr><td>"
            + item["Artwork"]
            + "</td><td>"
            + item["Artist"]
            + "</td></tr>";
    });
    string += "</tbody></table>"
    $("#artworkOutput").append(string);
}