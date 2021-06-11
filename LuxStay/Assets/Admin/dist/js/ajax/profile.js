$(document).ready(() => {
    Validator.plugin("numberonly", {
        install() {
            console.log('plugin installed');
        },
        validate(el, attribute) {
            return /^\d+$/.test(el.value);
        }
    });
    var validator1 = new Validator(document.querySelector("#information-user"), {
        autoScroll: true,
        showValid: true
    });
    var validator2 = new Validator(document.querySelector("#change-password"), {
        autoScroll: true,
        showValid: true
    });
    $("#btn-save").off("click").on("click", () => {
        var phone = $("#phone").val()
        var fullname = $("#fullname").val();
        console.log("click-save");
        $.ajax({
            url: "/Admin/Profile/Change",
            method: "POST",
            data: { phone: phone, fullname: fullname },
            dataType: "json",
            success: function (data) {
                if (data == "true") {
                    toastr.success("Cập Nhật Thành Công", "Thành Công");
                } else {
                    toastr.error("Cập Nhật Không Thành Công", "Thất Bại");
                }
            }
        })
    })
    $("#btn-change-password").off("click").on("click", () => {
        var inputOldPassword = $("#inputOldPassword").val()
        var inputNewPassword = $("#inputNewPassword").val()
        var inputPreNewPassword = $("#inputPreNewPassword").val()
        console.log("click-save");
        if (inputOldPassword.length > 6 && inputNewPassword.length > 6 && inputPreNewPassword.length > 6) {
            $.ajax({
                url: "/Admin/Profile/PasswordChange",
                method: "POST",
                data: { passwordOld: inputOldPassword, passwordNew: inputNewPassword, confirmPassword: inputPreNewPassword },
                dataType: "json",
                success: function (data) {
                    if (data == "true") {
                        toastr.success("Cập Nhật Thành Công", "Thành Công");
                        $("#inputOldPassword").val("");
                        $("#inputNewPassword").val("");
                        $("#inputPreNewPassword").val("");
                    } else if (data == "false-pass") {
                        toastr.error("Mật Khẩu Cũ Không Trùng Khớp", "Thất Bại");
                        $("#inputOldPassword").val("");
                        $("#inputNewPassword").val("");
                        $("#inputPreNewPassword").val("");
                    } else {
                        toastr.error("Mật Khẩu Mới Không Trùng Khớp", "Thất Bại");
                        $("#inputOldPassword").val("");
                        $("#inputNewPassword").val("");
                        $("#inputPreNewPassword").val("");
                    }
                }
            })
        }
    })
    document.getElementById('uploader').onsubmit = function () {
        var formdata = new FormData(); //FormData object
        var fileInput = document.getElementById('fileInput');
        //Iterating through each files selected in fileInput
        for (i = 0; i < fileInput.files.length; i++) {
            //Appending each file to FormData object
            formdata.append(fileInput.files[i].name, fileInput.files[i]);
        }
        var xhr = new XMLHttpRequest();
        xhr.open('POST', '/Profile/Upload');
        xhr.send(formdata);
        xhr.onreadystatechange = function () {
            if (xhr.readyState == 4 && xhr.status == 200) {
                alert(xhr.responseText);
            }
        }
        return false;
    }   
});