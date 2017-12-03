var size;

$("#searchButton").click(function () {
    size = $("#imageSize").val();
    $.ajax({
        type: "GET",
        dataType: "json",
        url: "/Giphy/SearchGiphy?search=" + $("#searchBox").val() + "&limit=" + $("#limit").val(),
        success: displayData,
        error: function () { alert("Error: Unable to get search results!"); }
        });
});

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

function displayData(data) {
    $("#outputBox").empty();
    $.each(data, function (i, image) {
        if (image["msg"] == "error-result") {
            alert("Invalid number of images specified.");
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