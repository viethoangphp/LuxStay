$('.textarea').summernote()
$(".select2").select2();
function playSound(url) {
    const audio = new Audio(url);
    audio.play();
}
$("#Room").submit(function (e) {
    e.preventDefault();
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
})
function UpdateTable(listObj) {
    for (var i = 0; i < listObj.length; i++) {
        var count = i;
        count++;
        markup =
            "<tr>" +
            "<td class='middle'>" + count + "</td>" +
            "<td class='middle'>"+listObj[i].roomName+"</td>" +
            "<td class='middle'>" + listObj[i].roomCategory +"</td>" +
            "<td class='middle'>" + listObj[i].roomLocation +"</td>" +
            "<td class='middle'>" + listObj[i].Address +"</td>" +
            "<td class='middle'>" + listObj[i].priceShow +"</td>" +
            "<td class='middle'>"+
                "<img src='" + listObj[i].avatar+"' class='img-fluid'  style='width:100px;' />"+
            "</td>"+
            "<td class='middle'>Đang Cho Thuê</td>"+
            "<td class='middle'>"+
               "<div class='d-flex d-flex justify-content-around'>"+
                    "<button class='btn btn-danger btn-delete' data-id='"+listObj[i].id+"'>"+
                        "<i class='fas fa-trash-alt'></i>"+
                    "</button>"+
                         "<button class='btn btn-secondary btn-view' data-id='" + listObj[i].id +"' data-toggle='modal' data-target='#viewUserInform'>"+
                        "<i class='fas fa-eye'></i>"+
                    "</button>"+
                "</div>"+
            "</td>"+
        "</tr>";
        tableBody = $("#tableUser tbody");
        tableBody.append(markup);
    }
}