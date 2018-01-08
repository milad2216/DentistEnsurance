$(function () {
    
    $("#loginBtn").click(function () {
        $.post("Home/Index", {})
        $(".lbl-error").html("");
        $(".input-group").removeClass("inputError");
        var user = $("#txt-user-name").val();
        var pass = $("#txt-password").val();
        var status = false;
        if (user === "") {
            $("#txt-user-name").attr("placeholder", " نام کاربری الزامیست!");
            $("#txt-user-name").addClass("inputError");
            status = true;
        }
        if (pass === "") {
            $("#txt-password").attr("placeholder", " کلمه عبور الزامیست!");
            $("#txt-password").addClass("inputError");
            status = true;
        }
        if (status) {
            return;
        }
        $("#loader").fadeIn();
        $.post("/api/Security/UserLogin", { UserName: user, Password: pass, Reminder: $("#ck_reminder").is(":checked") }).done(function (data) {
            if (data.Code == 0) {
                window.location.href = "/";
            }
            else {
                $("#loader").fadeOut();
                $(".lbl-error").html(data.Message);
            }
        }).fail(function () {
            $("#loader").fadeOut();
            window.location.reload();
        });

    });

    $("#txt-user-name").add("#txt-password").keyup(function () {
        $("#txt-password").removeClass("inputError");
        $("#txt-user-name").removeClass("inputError");
    });

    $("#ck_reminder").change(function () {
        if ($(this).is(":checked")) {
            $("#img_reminder").prop("src", "/Content/images/checked.png");
        } else {
            $("#img_reminder").prop("src", "/Content/images/unchecked.png")
        }
    });

    $(window).keypress(function (e) {
        if (e.keyCode === 13) {
            $("#loginBtn").click();
        }
    });

})
