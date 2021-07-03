Validator.plugin("numberonly", {
    install() {
        console.log('plugin installed');
    },
    validate(el, attribute) {
        return /^\d+$/.test(el.value);
    }
});
var validator = new Validator(document.querySelector("#addPost"), {
    autoScroll: true,
    showValid: true
});

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
                    $("#btn-reset").click();
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
        var result = confirm("Bạn có chắc chắn muốn xóa bài viết này");
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
});

$(document).on("click", "#btn-refresh", function () {
    $("#listView").DataTable().ajax.reload();
});
