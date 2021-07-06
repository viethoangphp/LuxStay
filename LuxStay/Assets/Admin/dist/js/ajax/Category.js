$(document).on("click", ".btn-delete", function () {
    var id = $(this).data("id");
    console.log(id);
    var btn = this;
    var result = confirm("Bạn Muốn Xóa Loại Phòng Này Khỏi Hệ Thống ?");
    if (result) {
        $.ajax({
            url: "/Admin/Category/Delete",
            method: "POST",
            data: { id: id },
            dataType: "json",
            success: function (data) {
                if (data == "true") {
                    toastr.success("Xóa Thành Công !", "Thành Công");
                    setTimeout(function () {
                        window.location = "/Admin/Category";
                    }, 1000)
                }
                else toastr.error("Xóa Thất Bại . Vui Lòng Thao Tác Lại", "Thất Bại");
               
            }
        })
    }
})
$("#Category").submit(function () {
    console.log("submit");
    var Category_add = $("#Category_add").val();
    var rowCount = $('#tableUser tbody tr').length + 1;
    $.ajax({
        url: "/Admin/Category/Add",
        method: "POST",
        data: { Category_add: Category_add },
        dataType: "json",
        success: function (data) {
            if (data != "false") {
                $("#model-cancel").click();
                playSound("/Assets/Admin/dist/mp3/smallbox.mp3");
                toastr.success("Thêm Thành Công !", "Thành Công !");
                setTimeout(function () {
                    window.location = "/Admin/Category";
                }, 1000)
            }
            else {
                playSound("/Assets/Admin/dist/mp3/error.mp3");
                toastr.error("Thêm Thất Bại . Vui Lòng Thao Tác Lại !", "Lỗi !");
            }
        }
    });
    return false;
});
$(document).on("click", ".btn-view", function () {
    var id = $(this).data("id");
    console.log(id);
    $.ajax({
        url: "/Admin/Category/View",
        method: "POST",
        data: { id: id },
        dataType: "json",
        success: function (data) {
            $("#update_category").data("id", data.id);
            $("#Category_view").val(data.categoryName);
            if (data.status == "1") {
                $("#status_view").val("1");
            } else {
                $("#status_view").val("2");
            }
        }
    })
})
$("#update_category").submit(function () {
    var id = $(this).data("id");
    var CatName = $("#Category_view").val();
    var Status = $("#status_view").val();
    var obj = {
        CatID: id,
        CatName: CatName,
        Status: Status
    };
    $.ajax({
        url: "/Admin/Category/Update",
        method: "POST",
        data: obj,
        dataType: "json",
        success: function (data) {
            if (data == "true") {
                $("#model-cancel-view").click();
                playSound("/Assets/Admin/dist/mp3/smallbox.mp3");
                toastr.success("Cập Nhật Thành Công", "Success !");
                setTimeout(function () {
                    window.location = "/Admin/Category"
                }, 1000)
            } else {
                playSound("/Assets/Admin/dist/mp3/error.mp3");
                toastr.error("Không Được Để Trống Tên Loại Phòng","Error")
            }
        }
    })
    return false;
})
function playSound(url) {
    const audio = new Audio(url);
    audio.play();
}