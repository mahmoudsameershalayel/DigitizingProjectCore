// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
showInPopup = (url, title) => {
    $.ajax({
        type: "GET",
        url: url,
        success: function (res) {
            $("#createCategoryProductModal .modal-body").html(res);
            $("#createCategoryProductModal .modal-title").html(title);
            $("#createCategoryProductModal").modal("show");
        }
    })
}

jQueryAjaxPost = form => {
    try {
        $.ajax({
            type: 'POST',
            url: form.action,
            data: new FormData(form),
            contentType: "application/json; charset=utf-8",
            dataType: "json", 
            success: function () {
                location.reload();
                $("#createCategoryProductModal .modal-body").html("");
                $("#createCategoryProductModal .modal-title").html("");
                $("#createCategoryProductModal").modal("hide");
            },
            error: function (err) {
                console.log(err)
            }
        })
        //to prevent default form submit event
        return false;
    } catch (ex) {
        console.log(ex)
    }
}