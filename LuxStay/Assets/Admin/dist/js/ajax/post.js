//validator.plugin("numberonly", {
//    install() {
//        console.log('plugin installed');
//    },
//    validate(el, attribute) {
//        return /^\d+$/.test(el.value);
//    }
//});
//var validator = new validator(document.queryselector("#addpost"), {
//    autoscroll: true,
//    showvalid: true
//});
//var validator2 = new validator(document.queryselector("#editpost"), {
//    autoscroll: true,
//    showvalid: true
//});

$(document).ready(function () {
    $("#addPost").submit(function (e) {
        e.preventDefault();

        var formData = new FormData(this);
        $.ajax({
            url: "/Admin/Post/Add",
            method: "post",
            data: formData,
            processData: false,
            contentType: false,
            success: function(data){
                if(data) {
                    // đóng modal 
                    $(".btn-dismiss").click();
                    //UpdateTable(data)
                    $(".btn-reset").click();
                    $(".textarea").summernote("code","");
                    toastr.success("Thêm Thành Công", "Thành Công");
                    setTimeout(function () { $("#btn-refresh").click(); }, 250);
                }
                else {
                    toastr.error("Thêm Thất Bại . Vui Lòng Thao Tác Lại !", "Lỗi !");
                }
            }
        })
    });
    $(document).on("click", ".btn-delete", function () {
        var postid = $(this).data("id");
        var result = confirm("Bạn có chắc chắn muốn xóa bài viết này?");
        if (result) {
            $.ajax({
                url: "/Admin/Post/Delete/" + postid,
                method: "post",
                data: { id: postid },
                dataType: "json",
                success: function (data) {
                    if (data) {
                        toastr.success("Xoá Thành Công", "Thành Công");
                        setTimeout(function () { $("#btn-refresh").click(); }, 250);
                    }
                    else {
                        toastr.error("Xoá Thất Bại. Vui Lòng Thao Tác Lại", "Lỗi");
                    }
                }
            })
        }
    });
    $(document).on("click", ".btn-edit", function () {
        var postid = $(this).data("id");
        $.ajax({
            url: "/Admin/Post/Get/"+postid,
            method: "post",
            data: { id: postid },
            dataType: "json",
            success: function (data) {
                if (data != null) {
                    $("#postEditID").val(data.postID);
                    $("#postEditTitle").val(data.postTitle);
                    $("#postEditDesc").val(data.postDesc);
                    $(".editPic").attr("src",data.postAvatar);
                    $(".textarea2").summernote("code", data.postContent);
                }
                else {
                    toastr.error("Can't get data");
                }
            }
        })
    });

    $("#editPost").submit(function (e) {
        e.preventDefault();

        var formData = new FormData(this);
        $.ajax({
            url: "/Admin/Post/Edit",
            method: "post",
            data: formData,
            processData: false,
            contentType: false,
            success: function (data) {
                if (data) {
                    // đóng modal 
                    $(".btn-dismiss").click();
                    //UpdateTable(data)
                    $(".btn-reset").click();
                    $(".textarea").summernote("code", "");
                    toastr.success("Cập Nhật Thành Công", "Thành Công");
                    setTimeout(function () { $("#btn-refresh").click(); }, 250);
                }
                else {
                    toastr.error("Cập Nhật Thất Bại. Vui Lòng Thao Tác Lại", "Lỗi");
                }
            }
        })
    });
});

$(document).on("click", "#btn-refresh", function () {
    $("#listView").DataTable().ajax.reload();
});
