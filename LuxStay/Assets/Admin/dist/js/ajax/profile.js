$(document).ready(() => {
    Validator.plugin("numberonly", {
        install() {
            console.log('plugin installed');
        },
        validate(el, attribute) {
            return /^\d+$/.test(el.value);
        }
    });
    var validator = new Validator(document.querySelector("#information-user"), {
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
               
            }
        })
    })
});