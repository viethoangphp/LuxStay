$(document).ready(function () {
    
    $(document).on("click", ".btn-confirm", function () {
        var id = $(this).data("id");
        $.ajax({
            url: "/Admin/Bill/ConfirmBill",
            method: "post",
            data: { billid: id },
            dataType: "json",
            success: function (data) {
                if (data) {
                    $("#btn-refresh").click();
                    toastr.success("Đã xác nhận đơn đặt phòng thành công!", "Thành công");
                } else {
                    toastr.error("Đã có lỗi trong quá trình xác nhận đơn đặt phòng! Vui lòng thử lại", "Lỗi");
                }
            }
        })
    })
})

$(document).on("click", "#btn-refresh", function () {
    $("#listView").DataTable().ajax.reload();
});