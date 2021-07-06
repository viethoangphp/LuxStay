$('#check_in').daterangepicker({
    singleDatePicker: true,
    locale: {
        "format": "DD/MM/YYYY",
        "separator": " - ",
        "applyLabel": "Áp Dụng",
        "cancelLabel": "Hủy",
        "fromLabel": "From",
        "toLabel": "To",
        "customRangeLabel": "Custom",
        "weekLabel": "W",
        "daysOfWeek": [
            "CN",
            "Thứ 2",
            "Thứ 3",
            "Thứ 4",
            "Thứ 5",
            "Thứ 6",
            "Thứ 7"
        ],
        "monthNames": [
            "Tháng 1",
            "Tháng 2",
            "Tháng 3",
            "Tháng 4",
            "Tháng 5",
            "Tháng 6",
            "Tháng 7",
            "Tháng 8",
            "Tháng 9",
            "Tháng 10 ",
            "Tháng 11",
            "Tháng 12"
        ],

    }
   
})
$('#check_out').daterangepicker({
    singleDatePicker: true,
    locale: {
        "format": "DD/MM/YYYY",
        "separator": " - ",
        "applyLabel": "Áp Dụng",
        "cancelLabel": "Hủy",
        "fromLabel": "From",
        "toLabel": "To",
        "customRangeLabel": "Custom",
        "weekLabel": "W",
        "daysOfWeek": [
            "CN",
            "Thứ 2",
            "Thứ 3",
            "Thứ 4",
            "Thứ 5",
            "Thứ 6",
            "Thứ 7"
        ],
        "monthNames": [
            "Tháng 1",
            "Tháng 2",
            "Tháng 3",
            "Tháng 4",
            "Tháng 5",
            "Tháng 6",
            "Tháng 7",
            "Tháng 8",
            "Tháng 9",
            "Tháng 10 ",
            "Tháng 11",
            "Tháng 12"
        ],

    }

})
$("#Sale").submit(function () {
    var persent = $("#persent").val();
    var check_in = $("#check_in").val();
    var check_out = $("#check_out").val();
    var status = $("#status").val();
    var obj = {
        persent: persent,
        check_in: check_in,
        check_out: check_out,
        status : status
    };
    $.ajax({
        url: "/Admin/Sale/Add",
        method: "POST",
        data: obj,
        dataType: "json",
        success: function (data) {
            if (data != "false") {
                $("#btn-cancel").click();
                $("#tableUser tbody tr").remove();
                UpdateTable(data);
                $("#persent").val("");
                $("#check_in").val("");
                $("#check_out").val("");
                $("#status").val("1");
                playSound("/Assets/Admin/dist/mp3/smallbox.mp3");
                toastr.success("Thêm Thành Công", "Thành Công");
            }
            else {
                toastr.error("Thêm Thất Bại . Vui Lòng Thao Tác Lại", "Thất Bại");
                playSound("/Assets/Admin/dist/mp3/error.mp3");
            }
        }
    })
    return false;
})
$(document).on("click", ".btn-delete", function () {
    var id = $(this).data("id");
    console.log(id);
    var result = confirm("Bạn Muốn Xóa Chương Trình Ưu Đãi Này Khỏi Hệ Thống ?");
    if (result) {
        $.ajax({
            url: "/Admin/Sale/Delete",
            method: "POST",
            data: { id: id },
            dataType: "json",
            success: function (data) {
                if (data != "false") {
                    $("#tableUser tbody tr").remove();
                    UpdateTable(data);
                    playSound("/Assets/Admin/dist/mp3/smallbox.mp3");
                    toastr.success("Xóa Thành Công", "Thành Công");
                } else {
                    playSound("/Assets/Admin/dist/mp3/error.mp3");
                    toastr.error("Xóa Thất Bại", "Lỗi ");
                }
            }
        })
    }
})
$(document).on("click", ".btn-view", function () {
    var id = $(this).data("id");
    $.ajax({
        url: "/Admin/Sale/View",
        method: "POST",
        data: { id: id },
        dataType: "json",
        success: function (data) {
            if (data != "false") {
                $("#persent_view").val(data.persent);
                $('#check_out_view').daterangepicker({
                    singleDatePicker: true,
                    locale: {
                        "format": "DD/MM/YYYY",
                        "separator": " - ",
                        "applyLabel": "Áp Dụng",
                        "cancelLabel": "Hủy",
                        "fromLabel": "From",
                        "toLabel": "To",
                        "customRangeLabel": "Custom",
                        "weekLabel": "W",
                        "daysOfWeek": [
                            "CN",
                            "Thứ 2",
                            "Thứ 3",
                            "Thứ 4",
                            "Thứ 5",
                            "Thứ 6",
                            "Thứ 7"
                        ],
                        "monthNames": [
                            "Tháng 1",
                            "Tháng 2",
                            "Tháng 3",
                            "Tháng 4",
                            "Tháng 5",
                            "Tháng 6",
                            "Tháng 7",
                            "Tháng 8",
                            "Tháng 9",
                            "Tháng 10 ",
                            "Tháng 11",
                            "Tháng 12"
                        ],

                    },
                    startDate: data.check_out,

                });
                $('#check_in_view').daterangepicker({
                    singleDatePicker: true,
                    locale: {
                        "format": "DD/MM/YYYY",
                        "separator": " - ",
                        "applyLabel": "Áp Dụng",
                        "cancelLabel": "Hủy",
                        "fromLabel": "From",
                        "toLabel": "To",
                        "customRangeLabel": "Custom",
                        "weekLabel": "W",
                        "daysOfWeek": [
                            "CN",
                            "Thứ 2",
                            "Thứ 3",
                            "Thứ 4",
                            "Thứ 5",
                            "Thứ 6",
                            "Thứ 7"
                        ],
                        "monthNames": [
                            "Tháng 1",
                            "Tháng 2",
                            "Tháng 3",
                            "Tháng 4",
                            "Tháng 5",
                            "Tháng 6",
                            "Tháng 7",
                            "Tháng 8",
                            "Tháng 9",
                            "Tháng 10 ",
                            "Tháng 11",
                            "Tháng 12"
                        ],

                    },
                    startDate: data.check_in,
                });
                if (data.status == "1") {
                    $("#status_view").val("1");
                } else {
                    $("#status_view").val("2");
                }
                $("#Sale_View").data("id", data.id);
                var form_id = $("#Sale_View").data("id");
                console.log(form_id);
            } else {
                playSound("/Assets/Admin/dist/mp3/error.mp3");
                toastr.error("Xóa Thất Bại", "Lỗi ");
            }
        }
    })
});
$("#Sale_View").submit(function () {
    var id = $(this).data("id");
    var persent = $("#persent_view").val();
    var check_in = $("#check_in_view").val();
    var check_out = $("#check_out_view").val();
    var status = $("#status_view").val();
    var obj = {
        id: id,
        persent: persent,
        check_in: check_in,
        check_out: check_out,
        status: status
    };
    $.ajax({
        url: "/Admin/Sale/Update",
        method: "POST",
        data: obj,
        dataType: "json",
        success: function (data) {
            if (data != "false") {
                $("#btn-view-cancel").click();
                $("#tableUser tbody tr").remove();
                UpdateTable(data);
                playSound("/Assets/Admin/dist/mp3/smallbox.mp3");
                toastr.success("Cập Nhật Thành Công", "Thành Công");
            }
            else {
                playSound("/Assets/Admin/dist/mp3/error.mp3");
                toastr.error("Cập Nhật Thất Bại . Vui Lòng Thao Tác Lại", "Thất Bại");
            }
                
        }
    })
    return false;
})
function UpdateTable(listObj) {
    for (var i = 0; i < listObj.length; i++) {
        var count = i;
        count++;
        markup = " <tr> " +
            "<td class='middle' ><b>" + count + "</b></td >" +
            "<td class='middle'>" + listObj[i].persent + "%</td>" +
            "<td class='middle'>" + listObj[i].check_in + "</td>" +
            "<td class='middle'>" + listObj[i].check_out + "</td>" +
            "<td class='middle'>" + listObj[i].create_at + "</td>";
        if(listObj[i].status == 1) {
            markup += "<td class='middle'>Đang Áp Dụng</td>"
        }
        else {
            markup += "<td class='middle'>Đã Quá Hạn</td>"
        }
        markup +=  "<td class='middle'>" +
            "<div class='d-flex d-flex justify-content-around'>" +
            "<button class='btn btn-danger btn-delete' data-id='" + listObj[i].id + "'>" +
                    "<i class='fas fa-trash-alt'></i>"+
                "</button>"+
            "<button class='btn btn-secondary btn-view' data-id='" + listObj[i].id+"' data-toggle='modal' data-target='#viewUserInform'>"+
                    "<i class='fas fa-eye'></i>"+
                "</button>"+
            "</div>"+
        "</td>"+
                        "</tr>";
        tableBody = $("#tableUser tbody");
        tableBody.append(markup);
    }
}
function playSound(url) {
    const audio = new Audio(url);
    audio.play();
}