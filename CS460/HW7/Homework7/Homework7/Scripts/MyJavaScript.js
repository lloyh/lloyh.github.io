$("#searchButton").click(function () {
    $.ajax({
        type: "GET",
        dataType: "json",
        url: "/Giphy/SearchGiphy?search=" + $("#searchBox").val(),
        success: displayData,
        error: function () { alert("Error happened!"); }
    });
});

function displayData(data) {
    $("#outputBox").empty();
    $.each(data, function (i, image) {
        $("#outputBox").append(
            "<div class='pictureFrame'><img class='img-responsive' src='"
            + image["image"]
            + "' />"
            + "</div>"
        );
    });
}