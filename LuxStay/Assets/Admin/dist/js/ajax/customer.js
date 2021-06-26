Validator.plugin("numberonly", {
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
var validator2 = new Validator(document.querySelector("#editUser"), {
    autoScroll: true,
    showValid: true
});
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
                    //UpdateTable(data)
                    $("#btn-reset").click();
                    toastr.success("Thêm Thành Công", "Thành Công");
                    setTimeout(function () { $("#btn-refresh").click(); }, 250);
                }
                else {
                    toastr.error("Thêm Thất Bại . Vui Lòng Thao Tác Lại !", "Lỗi !");
                }
            }
        });
        return false;
    })
    // Delete User
    $(document).on("click",".delete-btn", function () {
        var cusID = $(this).data("id");
        var answer = confirm("Bạn Muốn Xóa Khách Hàng Này Khỏi Hệ Thống ?")
        if (answer) {
            $.ajax({
                url: "/Admin/Customer/Delete",
                method: "post",
                data: { id: cusID },
                dataType: "json",
                success: function (result) {
                    if (result != false) {
                        toastr.success("Xóa Thành Công", "Thành Công");
                        setTimeout(function () { $("#btn-refresh").click(); }, 250);
                    }
                    else {
                        toastr.error("Đã Có Lỗi Xảy Ra. Vui Lòng Thử Lại", "Lỗi");
                    }
                }
            })
        }
    })
    // Edit User
    $(document).on("click", ".edit-btn", function () {
        var cusID = $(this).data("id");
        $.ajax({
            url: "/Admin/Customer/Get",
            method: "post",
            data: { id: cusID },
            dataType: "json",
            success: function (data) {
                if (!data) {
                    $("#btn-edit-dismiss").click();
                    toastr.error("Đã Có Lỗi Xảy Ra. Vui Lòng Thử Lại", "Lỗi");
                }
                else {
                    $("#inputEditID").val(data.id);
                    $("#inputEditFullName").val(data.fullname);
                    $("#inputEditEmail").val(data.email);
                    $("#inputEditPhone").val(data.phone);
                    $("#inputEditGender").val(data.gender);
                    $("#inputEditAddress").val(data.address);
                }
            }
        })
    });
    $("#editUser").submit(function (e) {
        e.preventDefault();

        var id = $("#inputEditID").val();
        var fullname = $("#inputEditFullName").val();
        var email = $("#inputEditEmail").val();
        var phone = $("#inputEditPhone").val();
        var gender = $("#inputEditGender").val();
        var address = $("#inputEditAddress").val();
        var obj = {
            id: id,
            fullname: fullname,
            email: email,
            phone: phone,
            gender: gender,
            address: address
        }
        $.ajax({
            url: "/Admin/Customer/Edit",
            method: "POST",
            data: obj,
            dataType: "json",
            success: function (data) {
                if (data != false) {
                    // đóng modal 
                    $("#btn-edit-dismiss").click();
                    //UpdateTable(data)
                    $("#btn-edit-reset").click();
                    toastr.success("Cập Nhật Thành Công", "Thành Công");
                    setTimeout(function () { $("#btn-refresh").click(); }, 250);
                }
                else {
                    toastr.error("Cập Nhật Thất Bại . Vui Lòng Thao Tác Lại !", "Lỗi !");
                }
            }
        });
        return false;
    })
});

$("#btn-refresh").click(function () {
    $("#listView").DataTable().ajax.reload();
});