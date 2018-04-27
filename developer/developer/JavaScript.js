


function addFav(id, dom) {
    $.ajax({
        url: "/Home/Fav",
        data: { "id": id },
        success: function (result) {
            if (result) {
                $(dom).css("color", "red");
                JavaScript: location.reload();

            } else {
                $(dom).css("color", "gray");
                JavaScript: location.reload();

            }
            
        },
        error: function (error) {
            console.log("Beğenme hatası", error);
        }
    });
}

function addRt(id, dom) {
    $.ajax({
        url: "/Home/Rt",
        data: { "id": id },
        success: function (result) {
            if (result) {
                $(dom).css("color", "green");
                JavaScript: location.reload();

            } else {
                $(dom).css("color", "gray");
                JavaScript: location.reload();

            }

        },
        error: function (error) {
            console.log("Retweet hatası", error);
        }
    });
}


function deletet(id, dom) {
    $.ajax({
        url: "/Home/Delete",
        data: { "id": id },
        success: function (result) {
            if (result) {
                $(dom).css("color", "red");
                JavaScript: location.reload();
            } else {
                $(dom).css("color", "gray");
                JavaScript: location.reload();
            }

        },
        error: function (error) {
            console.log("Delete hatası", error);
        }
    });
}


//function gundem_cek(g_id, dom) {
//    $.ajax({
//        url: "/Home/Gundem_yazdir",
//        data: { "id": g_id },
//        success: function (result) {
//            if (result) {
//                $(dom).css("color", "red");
//                //JavaScript: location.reload();

//            }


//            else {
//                $(dom).css("color", "gray");
//                //JavaScript: location.reload();

//            }

//        },
//        error: function (error) {
//            console.log("Gundem Cekme hatası", error);
//        }
//    });
//}


