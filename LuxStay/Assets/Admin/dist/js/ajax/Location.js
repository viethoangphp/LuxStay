$(document).ready(function () {
    $("#Location").submit(function () {
        console.log("submit");
        var formdata = new FormData(); //FormData object
        var fileInput = document.getElementById('avatar_add');
        //Iterating through each files selected in fileInput
        for (i = 0; i < fileInput.files.length; i++) {
            //Appending each file to FormData object
            formdata.append(fileInput.files[i].name, fileInput.files[i]);
        }
        formdata.append("LocationName", $("#LocationName_add").val());
        //Creating an XMLHttpRequest and sending
        var xhr = new XMLHttpRequest();
        xhr.open('POST', '/Admin/Location/Add');
        xhr.send(formdata);
        xhr.onreadystatechange = function () {
            if (xhr.readyState == 4 && xhr.status == 200) {
                console.log(xhr.responseText);
                if (xhr.responseText == "true") {
                    toastr.success("Thêm Thành Công", "Thành Công");
                    setTimeout(function () {
                        window.location = "/Admin/Location";
                    }, 1000);
                } else {
                    toastr.error("Thêm Thất Bại Vui Lòng Thao Tác Lại", "Thất Bại");
                }
            }
        }
        return false;
    });
    $(document).on("click", ".btn-delete", function () {
        var id = $(this).data("id");
        console.log(id);
        var btn = this;
        var result = confirm("Bạn Muốn Xóa User Này Khỏi Hệ Thống ?");
        if (result) {
            $.ajax({
                url: "/Admin/Location/Delete",
                method: "POST",
                data: { id: id },
                dataType: "json",
                success: function (data) {
                    if (data == "true")
                    {
                        toastr.success("Xóa Thành Công !", "Thành Công");
                        setTimeout(function () {
                            window.location = "/Admin/Category";
                        }, 1000);
                    }
                    else toastr.error("Xóa Thất Bại . Vui Lòng Thao Tác Lại", "Thất Bại");
                }
            })
        }
    })
})
