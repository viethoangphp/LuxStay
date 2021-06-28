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
var validator1 = new Validator(document.querySelector("#InfomationUser"), {
    autoScroll: true,
    showValid: true
});
$(document).ready(function () {
    $("#addUser").submit(function () {
        var fullname = $("#fullname_add").val();
        var email = $("#email_add").val();
        var password = $("#password_add").val();
        var phone = $("#phone_add").val();
        console.log(fullname + email + password + phone);
        var obj = {
            fullname: fullname,
            email: email,
            password: password,
            phone: phone
        }
        var rowCount = $('#tableUser tbody tr').length + 1;
        $.ajax({
            url: "/Admin/User/Add",
            method: "POST",
            data: obj,
            dataType: "json",
            success: function (data) {
                if (data != "false") {
                    // đóng modal 
                    $("#model-cancel").click();
                    var obj = data;
                    $("#tableUser tbody tr").remove(); 
                    UpdateTable(data);
                    playSound("/Assets/Admin/dist/mp3/smallbox.mp3");
                    toastr.success("Thêm Thành Công !", "Thành Công !");
                }
                else {
                    playSound("/Assets/Admin/dist/mp3/error.mp3");
                    toastr.error("Thêm Thất Bại . Vui Lòng Thao Tác Lại !", "Lỗi !");
                }
            }
        });
        return false;
    })
    $(document).on("click",".btn-view", function () {
        var id = $(this).data("id");
        console.log(id);
        $.ajax({
            url: "/Admin/User/View",
            method: "POST",
            data: { id: id },
            dataType: "json",
            success: function (data) {
                $("#fullname_view").val(data.fullname);
                $("#email_view").val(data.email);
                $("#phone_view").val(data.phone);
                $("#InfomationUser").data("id",data.id);
                if (data.avatar != null) {
                    $("#avatar").attr("src", data.avatar);
                } else {
                    $("#avatar").attr("src", "/Assets/Admin/dist/img/user1-128x128.jpg");
                }
              
            }
        })
    })
    $(document).on("click",".btn-delete", function () {
        var userID = $(this).data("id");
        console.log(userID);
        var btn = this;
        var result = confirm("Bạn Muốn Xóa User Này Khỏi Hệ Thống ?");
        if (result) {
            $.ajax({
                url: "/Admin/User/Delete",
                method: "POST",
                data: { userID: userID },
                dataType: "json",
                success: function (data) {
                    if (data != "duplicate" && data != "false") {
                        $("#tableUser tbody tr").remove();
                        UpdateTable(data);
                        playSound("/Assets/Admin/dist/mp3/smallbox.mp3");
                        toastr.success("Xóa Thành Công", "Thành Công");
                    } else if (data == "duplicate") {
                        playSound("/Assets/Admin/dist/mp3/error.mp3");
                        toastr.warning("User đang online. Vui Lòng Thao Tác Lại", "Cảnh Báo");
                    } else {
                        playSound("/Assets/Admin/dist/mp3/error.mp3");
                        toastr.error("Bạn Không Có Quyền Thực Hiện Thao Tác Này", "Lỗi");
                    }
                }
            })
        }
    })
    $("#InfomationUser").submit(function () {
        var id = $(this).data("id")
        var fullname = $("#fullname_view").val();
        var phone = $("#phone_view").val();
        var email = $("#email_view").val();
        var obj = {
            id: id,
            fullname: fullname,
            phone: phone,
            email: email
        };
        $.ajax({
            url: "/Admin/User/Update",
            method: "POST",
            data: obj,
            dataType: "json",
            success: function (data) {
                if (data == "true") {
                    var td = "#" + id;
                    console.log(td);
                    $(td+" .user_fullname").text(fullname);
                    $(td + " .user_phone").text(phone);
                    playSound("/Assets/Admin/dist/mp3/smallbox.mp3");
                    toastr.success("Cập Nhật Thành Công", "Thành Công")

                } else {
                    playSound("/Assets/Admin/dist/mp3/error.mp3");
                    toastr.error("Cập Nhật Thất Bại", "Lỗi")
                }
            }
        })
        return false;
    })
});
function deleteRow(btn) {
    var row = btn.parentNode.parentNode.parentNode;
    row.parentNode.removeChild(row);
}

function UpdateTable(listObj) {
    for (var i = 0; i < listObj.length; i++) {
        var count = i;
        count++;
        markup = " <tr id='" + listObj[i].id + "'>" +
            "<td class='middle' > <b>" + count + "</b></td >" +
            "<td class='middle user_fullname'>" + listObj[i].fullname + "</td>" +
            "<td class='middle'>" + listObj[i].email + "</td>" +
            "<td class='middle user_phone'>" + listObj[i].phone + "</td>" +
            "<td class='middle'>Quản Trị Viên</td>" +
            "<td class='middle'>Quản Trị Viên</td>" + " <td class='middle'>Offline</td>" +
            "<td class='middle'>" +
            "<div class='d-flex d-flex justify-content-around'>" +
            "<button class='btn btn-danger btn-delete' data-id='" + listObj[i].id + "'>" +
            "<i class='fas fa-trash-alt'></i>" +
            "</button>" +
            "<button class='btn btn-secondary btn-view' data-id='" + listObj[i].id + "' data-toggle='modal' data-target='#viewUserInform'>" +
            "<i class='fas fa-eye'></i>" +
            "</button>" +
            "</div>" +
            "</td>" +
            "</tr>";
        tableBody = $("#tableUser tbody");
        tableBody.append(markup);
    }
}
function playSound(url) {
    const audio = new Audio(url);
    audio.play();
}