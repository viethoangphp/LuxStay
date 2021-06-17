﻿Validator.plugin("numberonly", {
    install() {
        console.log('plugin installed');
    },
    validate(el, attribute) {
        return /^\d+$/.test(el.value);
    }
});
var validator = new Validator(document.querySelector("#addUser"), {
    autoScroll: true,
    showValid: true
});
$(document).ready(function () {
    $("#addUser").submit(function () {
        var fullname = $("#inputFullName").val();
        var email = $("#inputEmail").val();
        var phone = $("#inputPhone").val();
        var gender = $("#inputGender").val();
        var address = $("#inputAddress").val();
        console.log(fullname + email + password + phone + gender + address);
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
                    $("#model-cancel").click();
                    markup = " <tr>" +
                        "<td class='middle' > <b>"+ data +"</b></td >" +
                        "<td class='middle'>" + fullname + "</td>" +
                        "<td class='middle'>" + email + "</td>" +
                        "<td class='middle'>" + phone + "</td>" +
                        "<td class='middle'>Quản Trị Viên</td>" +
                        "<td class='middle'>Quản Trị Viên</td>" +
                        "<td class='middle'>" +
                        "<div class='d-flex d-flex justify-content-around'>" +
                        "<button class='btn btn-danger btn-delete' data-id='" + data + "'>" +
                        "<i class='fas fa-trash-alt'></i>" +
                        "</button>" +
                        "<button class='btn btn-secondary btn-view' data-id='" + data + "' data-toggle='modal' data-target='#viewUserInform'>" +
                        "<i class='fas fa-eye'></i>" +
                        "</button>" +
                        "</div>" +
                        "</td>" +
                        "</tr>";
                    tableBody = $("#tableUser tbody");
                    tableBody.append(markup);
                    toastr.success("Thêm Thành Công", "Thành Công");
                }
                else {
                    toastr.error("Thêm Thất Bại . Vui Lòng Thao Tác Lại !", "Lỗi !");
                }
            }
        });
        return false;
    })
});