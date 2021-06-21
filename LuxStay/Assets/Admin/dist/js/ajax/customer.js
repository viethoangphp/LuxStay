////Validator.plugin("numberonly", {
////    install() {
////        console.log('plugin installed');
////    },
////    validate(el, attribute) {
////        return /^\d+$/.test(el.value);
////    }
////});
////var validator = new Validator(document.querySelector("#addUser"), {
////    autoScroll: true,
////    showValid: true
////});
$(document).ready(function () {
    $("#addUser").submit(function (e) {
        e.preventDefault();

        var fullname = $("#inputFullName").val();
        var email = $("#inputEmail").val();
        var phone = $("#inputPhone").val();
        var gender = $("#inputGender").val();
        var address = $("#inputAddress").val();
        var obj = {
            fullname: fullname,
            email: email,
            phone: phone,
            gender: gender,
            address: address
        }
        $.ajax({
            url: "/Admin/Customer/Add",
            method: "POST",
            data: obj,
            dataType: "json",
            success: function (data) {
                if (data != "false") {
                    // đóng modal 
                    $("#btn-dismiss").click();
                    html = "<tr>" +
                        "<td>" + ($('#dataTable tbody tr').length + 1) + "</td>" +
                        "<td>" + fullname + "</td>" +
                        "<td>" + address + "</td>" +
                        "<td>" + email + "</td>" +
                        "<td>" + phone + "</td>";
                    if (gender == 1) { html += "<td>Nam</td>" } else { html += "<td>Nữ</td>"}
                    html += "<td style='text-align: center;'>" +
                        "<button class='btn btn-success' data-toggle='modal' data-target='#formEditModal'>" +
                        "<i class='fas fa-eye'></i>" +
                        "</button>" +
                        "<a href='/Admin/Customer/Delete?id=@item.CustomerID' class='btn btn-danger'>" +
                        "<i class='fas fa-trash-alt'></i>" +
                        "</a>" +
                        "</td>" +
                        "</tr>";
                    $('#example1 > tbody:last-child').append(html);
                    $("#btn-reset").click();
                    toastr.success("Thêm Thành Công", "Thành Công");
                }
                else {
                    toastr.error("Thêm Thất Bại . Vui Lòng Thao Tác Lại !", "Lỗi !");
                }
            }
        });
        return false;
    })
    $(".delete-btn").click(function () {

    })
});