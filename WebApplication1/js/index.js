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

$(".watch-now:not(.mdb)").click(function () {
    window.open("http://www.google.com.pk/search?btnG=1&pws=0&q=" + $(".title:not(.mdb)").text(), '_blank');
});

$(".mdb.watch-now").click(function () {
    window.open("http://www.google.com.pk/search?btnG=1&pws=0&q=" + $(".mdb.title").text(), '_blank');
});

$(".send-message").click(function () {
    SendUserMessage();
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

function InitRandomModal() {
    $(".random-film-modal").modal("show");
    console.log(this);
    $(".modal-body .mdb.img-responsive").attr('src', 'http://image.tmdb.org/t/p/w185/' + this.backdrop_path);
    $(".mdb.rating").text("Rating:" + this.popularity);
    $(".mdb.description").text(this.overview);
    $(".mdb.title").text(this.original_title);
    $(".mdb.cost span").text(this.release_date);
    $(".random-film-modal").modal("show");
}

function IntitRandomFilm() {
    if ($('.random-film-modal').is(':visible')) {
        $(".random-film-modal").modal("hide");
    }

    Loader.Show();

    $.ajax({
        type: "Post",
        url: getRandomFilmLink,
        success: function (data) {
            InitRandomModal.call(data);
        },
        error: function (data) {
            console.log("Error");
        },
        complete: function (data) {
            Loader.Hide();
        }
    });
};

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
        },
        error: function (data) {
            console.log("Error");
        },
        complete: function (data) {
            Loader.Hide();
        }
    });
};

function SendUserMessage() {
    Loader.Show();

    $.ajax({
        type: "Post",
        url: sendUserMessageLink,
        data: {
            userEmail: $(".user-email").val(),
            userName: $(".user-name").val(),
            userMessage: $(".user-message").val()
        },
        success: function (data) {
            console.log(data);
            $(".user-email").val("");
            $(".user-name").val("");
            $(".user-message").val("");
            alert("Message successfully sent!");
        },
        error: function (data) {
            alert("Something strange. Please try again later!");
        },
        complete: function (data) {
            Loader.Hide();
        }
    });
};