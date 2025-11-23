
function Delete(id) {
    let body = {
        Id: id
    }
    Swal.fire({
        title: "آیا خدمت حذف شود؟",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        cancelButtonText: "انصراف",
        confirmButtonText: "بله حذف شود"
    }).then((result) => {
        if (result.isConfirmed) {
            rest.postAsync("?handler=Delete", null, body, function (isSuccess, response) {
                let user = document.getElementById("item_" + id);
                if (response.isSuccess) {
                    Swal.fire({
                        title: "خدمت با موفقیت حذف شد",
                        icon: "success",
                        confirmButtonText: "متوجه شدم"
                    });
                    user.remove();
                } else {
                    Swal.fire({
                        title: "حذف انجام نشد",
                        text: response.message,
                        icon: "warning",
                        confirmButtonText: "متوجه شدم"
                    });
                }
            });
        }
    });
}
