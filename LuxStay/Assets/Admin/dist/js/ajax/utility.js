Validator.plugin("numberonly", {
    install() {
        console.log('plugin installed');
    },
    validate(el, attribute) {
        return /^\d+$/.test(el.value);
    }
});
var validator = new Validator(document.querySelector("#addUtility"), {
    autoScroll: true,
    showValid: true
});
$(document).ready(function () {
    $("#addUtility").submit(function (e) {
        e.preventDefault();

        var name = $("#name").val();
        var parentname = $("#parentName").val();
        var status = $("#status").val();
        var obj = {
            name: name,
            parentname: parentname,
            status: status
        }
        $.ajax({
            url: "/Admin/Service/Add",
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
    $(document).on("click",".delete-btn", function () {
        var cusID = $(this).data("id");
        var answer = confirm("Bạn Muốn Xóa Dịch Vụ Này Khỏi Hệ Thống ?")
        if (answer) {
            $.ajax({
                url: "/Admin/Service/Delete",
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
    $(document).on("click", ".edit-btn", function () {
        var utlID = $(this).data("id");
        $.ajax({
            url: "/Admin/Service/Get",
            method: "post",
            data: { id: utlID },
            dataType: "json",
            success: function (data) {
                if (!data) {
                    $("#btn-edit-dismiss").click();
                    toastr.error("Đã Có Lỗi Xảy Ra. Vui Lòng Thử Lại", "Lỗi");
                }
                else {
                    $("#name").attr("value", name);;
                    $("#parentName").attr("value", parentname);
                    $("#status").attr("value", status);
                }
            }
        })
    });
    //$("#editUtility").submit(function (e) {
    //    e.preventDefault();

    //    var fullname = $("#inputEditFullName").val();
    //    var email = $("#inputEditEmail").val();
    //    var phone = $("#inputEditPhone").val();
    //    var gender = $("#inputEditGender").val();
    //    var address = $("#inputEditAddress").val();
    //    var obj = {
    //        fullname: fullname,
    //        email: email,
    //        phone: phone,
    //        gender: gender,
    //        address: address
    //    }
    //    $.ajax({
    //        url: "/Admin/Customer/Edit",
    //        method: "POST",
    //        data: obj,
    //        dataType: "json",
    //        success: function (data) {
    //            if (data != "false") {
    //                // đóng modal 
    //                $("#btn-dismiss").click();
    //                //UpdateTable(data)
    //                $("#btn-reset").click();
    //                toastr.success("Cập Nhật Thành Công", "Thành Công");
    //                setTimeout(function () { $("#btn-refresh").click(); }, 250);
    //            }
    //            else {
    //                toastr.error("Cập Nhật Thất Bại . Vui Lòng Thao Tác Lại !", "Lỗi !");
    //            }
    //        }
    //    });
    //    return false;
    //})
});

$("#btn-refresh").click(function () {
    $("#listView").DataTable().ajax.reload();
});