$(document).ready(function () {
   
});

$(".open-search-modal").click(function () {
    openSearchModal()
});

$(".get-film-by-name").click(function () {
    GetFilmByName();
});

$(".intit-random-film").click(function () {
    IntitRandomFilm();
});

$(".watch-now").click(function () {
    window.open("http://www.google.com.pk/search?btnG=1&pws=0&q=" + $(".title").text(), '_blank');
}); 

function Loader() {
    this.Show = function () {
        $(".main-loader").css("visibility", "visible");
    };

    this.Hide = function () {
        $(".main-loader").css("visibility", "hidden");
    };
}

var Loader = new Loader();
function openSearchModal() {
    var searchModal = $(".fims-search-modal");
    searchModal.modal("show");
}

function IntitRandomFilm() {
    Loader.Show();

    $.ajax({
        type: "Post",
        url: getRandomFilmLink,
        success: function (data) {
            $(".img-responsive").attr('src', data.Poster);
            console.log(data.Poster);
            console.log(data);

        },
        error: function (data) {
            console.log("Error");
        },
        complete: function (data) {
            Loader.Hide();
        }
    });
}

function GetFilmByName() {
    Loader.Show();

    $.ajax({
        type: "Post",
        url: getFilmByNameLink,
        data: {
            filmName: $(".film-name").val(),
        },
        success: function (data) {
            $(".modal-body .img-responsive").attr('src', data.Poster);
            $(".rating").text("Rating:" + data.imdbRating);
            $(".description").text(data.Plot);
            $(".title").text(data.Title);
            $(".awards span").text(data.Awards);
            $(".cost span").text(data.Released);
            console.log(data.Poster);
            console.log(data);
        },
        error: function (data) {
            console.log("Error");
        },
        complete: function (data) {
            Loader.Hide();
        }
    });
}