
function Delete(id) {
    let body = {
        Id: id
    }
    //let token = document.querySelector('input[name="__RequestVerificationToken"]').value;
    Swal.fire({
        title: "آیا عضو حذف شود؟",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        cancelButtonText: "انصراف",
        confirmButtonText: "بله حذف شود"
    }).then((result) => {
        if (result.isConfirmed) {
            rest.postAsync("?handler=Delete", null, body, function (isSuccess, response) {
                let role = document.getElementById("item_" + id);
                if (response.isSuccess) {
                    Swal.fire({
                        title: "عضو با موفقیت حذف شد",
                        icon: "success",
                        confirmButtonText: "متوجه شدم"
                    });
                    role.remove();
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

