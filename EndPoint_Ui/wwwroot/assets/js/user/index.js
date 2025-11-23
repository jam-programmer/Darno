async function SetPassword(id) {
    const { value: password } = await Swal.fire({
        title: "گذر واژه جدید را وارد کنید",
        input: "password",
        confirmButtonText: "ثبت گذر واژه جدید",
        inputLabel: "گذر واژه باید حداقل 6 کارکتر باشد",
        inputPlaceholder: "گذر واژه جدید را وارد کنید",
        inputAttributes: {
            maxlength: "10",
            autocapitalize: "off",
            autocorrect: "off"
        }
    });
    if (password) {
        let body = {
            Id: id,
            Password: password
        }
        rest.postAsync("?handler=SetPassword", null, body, function (isSuccess, response) {
            if (response.isSuccess) {
                Swal.fire({
                    title: "گذر واژه تنظیم شد",
                    icon: "success",
                    confirmButtonText: "متوجه شدم"
                });
         
            } else {
                Swal.fire({
                    title: "تغییر گذر واژه انجام نشد",
                    text: response.message,
                    icon: "warning",
                    confirmButtonText: "متوجه شدم"
                });
            }
        });
    } else {

    }
}


function Delete(id) {
    let body = {
        Id: id
    }
    Swal.fire({
        title: "آیا کاربر حذف شود؟",
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
                        title: "کاربر با موفقیت حذف شد",
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
