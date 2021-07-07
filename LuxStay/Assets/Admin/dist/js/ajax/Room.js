$('.textarea').summernote()
$(".select2").select2();
function playSound(url) {
    const audio = new Audio(url);
    audio.play();
}
$("#Room").submit(function (e) {
    e.preventDefault();
   
    console.log($(this).data("id"));
    var choose = $(this).data("id");
   
    if (choose == 0) {
        var formData = new FormData(this);
        $.ajax({
            type: "POST",
            enctype: 'multipart/form-data',
            url: "/Admin/Room/Add",
            data: formData,
            processData: false,
            contentType: false,
            cache: false,
            timeout: 600000,
            success: function (data) {
                if (data != "false") {
                    ClearValueForm();
                    $("#tableUser tbody tr").remove();
                    UpdateTable(data);
                    playSound("/Assets/Admin/dist/mp3/smallbox.mp3");
                    toastr.success("Thêm Thành Công", "Thành Công");
                } else {
                    playSound("/Assets/Admin/dist/mp3/error.mp3");
                    toastr.error("Không Được Để Trống Các Trường Có Dấu *", "Lỗi");
                }
            }
        });
    } else {
        var formData = new FormData(this);
        formData.append("id", choose);
        $.ajax({
            type: "POST",
            enctype: 'multipart/form-data',
            url: "/Admin/Room/Update",
            data: formData,
            processData: false,
            contentType: false,
            cache: false,
            timeout: 600000,
            success: function (data) {
                if (data != "false") {
                    $("#model-cancel").click();
                    ClearValueForm();
                    $("#tableUser tbody tr").remove();
                    UpdateTable(data);
                    setTimeout(function () {
                        playSound("/Assets/Admin/dist/mp3/smallbox.mp3");
                        toastr.success("Cập Nhật Thành Công", "Thành Công");
                    }, 1500)
                } else {
                    playSound("/Assets/Admin/dist/mp3/error.mp3");
                    toastr.error("Không Được Để Trống Các Trường Có Dấu *", "Lỗi");
                }
            }
        });
    }
    
    return false;
});
$(document).on("click", ".btn-delete", function () {
    var id = $(this).data("id");
    var btn = this;
    var result = confirm("Bạn Muốn Xóa Phòng Này Khỏi Hệ Thống ?");
    if (result) {
        $.ajax({
            url: "/Admin/Room/Delete",
            method: "POST",
            data: { id: id },
            dataType: "json",
            success: function (data) {
                if (data != "false") {
                    $("#tableUser tbody tr").remove();
                    UpdateTable(data);
                    setTimeout(function () {
                        playSound("/Assets/Admin/dist/mp3/smallbox.mp3");
                        toastr.success("Xóa Thành Công", "Thành Công");
                    }, 500)
                } else {
                    playSound("/Assets/Admin/dist/mp3/error.mp3");
                    toastr.error("Bạn Không Có Quyền Thực Hiện Thao Tác Này", "Lỗi");
                }
            }
        })
    }
});
$(document).on("click", ".btn-view", function () {
    var id = $(this).data("id");
    $("#staticBackdropLabel").text("Thông Tin Homstay")
    $("#btn-form").text("Cập Nhật")
    $.ajax({
        url: "/Admin/Room/View",
        method: "POST",
        data: { id: id },
        dataType: "json",
        success: function (data) {
            ClearValueForm();
            var formDataId = $("#Room").data("id", data.id);
            console.log(formDataId.data("id"));
            console.log(data);
            document.getElementsByName("roomName")[0].value = data.roomName;
            document.getElementsByName("price")[0].value = data.price;
            document.getElementsByName("locationID")[0].value = data.locationID;
            $("#locationID").trigger("change");
            document.getElementsByName("categoryID")[0].value = data.categoryID;
            $("#categoryID").trigger("change");
            document.getElementsByName("bedNumber")[0].value = data.bedNumber;
            document.getElementsByName("bathRoom")[0].value = data.bathRoom;
            document.getElementsByName("bedRoom")[0].value = data.bedRoom;
            document.getElementsByName("peopleMax")[0].value = data.peopleMax;
            document.getElementsByName("area")[0].value = data.area;
            document.getElementsByName("Address")[0].value = data.Address;
            for (var i = 0; i < data.utility.length; i++) {
                $("#" + data.utility[i]).prop("checked", true);
            }
            $(".textarea").summernote('code', data.content);
            $("#avatarRoom").attr("src", data.avatar);
            for (var i = 0; i < 8; i++) {
                $(".Slider")[i].src= data.sliderImages[i];
            }
        }
    })
});
$(document).on("click", "#btn-add", function () {
    $("#staticBackdropLabel").text("Thêm Phòng Mới")
    $("#btn-form").text("Thêm Mới")
    ClearValueForm();
    var formDataId = $("#Room").data("id", 0);

    console.log(formDataId.data("id"));
})
function UpdateTable(listObj) {
    for (var i = 0; i < listObj.length; i++) {
        var count = i;
        count++;
        markup =
            "<tr>" +
            "<td class='middle'>" + count + "</td>" +
            "<td class='middle'>" + listObj[i].roomName + "</td>" +
            "<td class='middle'>" + listObj[i].roomCategory + "</td>" +
            "<td class='middle'>" + listObj[i].roomLocation + "</td>" +
            "<td class='middle'>" + listObj[i].Address + "</td>" +
            "<td class='middle'>" + listObj[i].priceShow + "đ/đêm</td>";
        if (listObj[i].salePersent != 0) {
            markup += "<td class='middle'>" + listObj[i].salePersent + "%</td>";
        }
        else {
            markup += "<td class='middle'>Không Giảm Giá</td>";
        }
        markup += 
                "<td class='middle'>"+
                "<img src='" + listObj[i].avatar+"' class='img-fluid'  style='width:100px;' />"+
            "</td>"+
            "<td class='middle'>Đang Cho Thuê</td>"+
            "<td class='middle'>"+
               "<div class='d-flex d-flex justify-content-around'>"+
                    "<button class='btn btn-danger btn-delete' data-id='"+listObj[i].id+"'>"+
                        "<i class='fas fa-trash-alt'></i>"+
                    "</button>"+
                    "<button class='btn btn-secondary btn-view' data-id='" + listObj[i].id +"' data-toggle='modal' data-target='#staticBackdrop'>"+
                        "<i class='fas fa-eye'></i>"+
                    "</button>"+
                "</div>"+
            "</td>"+
        "</tr>";
        tableBody = $("#tableUser tbody");
        tableBody.append(markup);
    }
}
function ClearValueForm(){
    $(".clearVal").val("");
    $('.mycheck').prop('checked', false);
    $(".textarea").summernote('code',"");
    $(".target").attr("src", "https://cdn-app.kiotviet.vn/retailler/bundles/2021616941/default-product-img.jpg");
}