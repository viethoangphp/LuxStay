$(document).ready(function () {
    $(document).on("click", ".btn-view", function () {
        var id = $(this).data("id");
        $.ajax({
            url: "/Admin/Bill/Get",
            method: "post",
            data: { billid: id },
            dataType: "json",
            success: function (data) {
                resetInfo();
                $("#billID").html("Mã đơn đặt phòng: " + data.billId);
                $("#customerName").html("Tên khách hàng: " + data.customername);
                $("#roomName").html("Tên phòng: " + data.roomname);
                $("#numAdult").html("Số lượng người lớn: " + data.adult);
                $("#numKid").html("Số lượng trẻ em: " + data.kid);
                $("#numBaby").html("Số lượng em bé: " + data.baby);
                $("#checkIn").html("Ngày nhận phòng: " + data.check_in);
                $("#checkOut").html("Ngày trả phòng: " + data.check_out);
                $("#createAt").html("Ngày tạo đơn: " + data.create_at);
                $("#totalMoney").html("Tổng tiền: " + data.total);
                if (data.status == 1) {
                    $("#status").html("Trạng thái: Đã thanh toán");
                } else if (data.status == -1) {
                    $("#status").html("Trạng thái: Đã hủy bỏ");
                } else {
                    $("#status").html("Trạng thái: Chờ xác nhận");
                }
            }
        })
    })
})

function resetInfo() {
    $("#billID").html("");
    $("#customerName").html("");
    $("#roomName").html("");
    $("#numAdult").html("");
    $("#numKid").html("");
    $("#numBaby").html("");
    $("#checkIn").html("");
    $("#checkOut").html("");
    $("#createAt").html("");
    $("#totalMoney").html("");
    $("#status").html("");
}