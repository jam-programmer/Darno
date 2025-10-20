
function SendMessage() {



    let fullname        = document.getElementById("fullname").value;
    let phoneNumber         = document.getElementById("phoneNumber").value;
    let companyName             = document.getElementById("companyName").value;
    let position            = document.getElementById("position").value;
    let message         = document.getElementById("message").value;
    if (!fullname) {
        Swal.fire({
            title: "خطای تکیمل اطلاعات",
            text: "نام و نام خانوادگی الزامی است",
            icon: "warning",
            confirmButtonText: "متوجه شدم", showConfirmButton: false
        });
        return;
    }

    if (!phoneNumber) {
        Swal.fire({
            title: "خطای تکیمل اطلاعات",
            text: "شماره تماس الزامی است",
            icon: "warning",
            confirmButtonText: "متوجه شدم", showConfirmButton: false
        });
        return;
    }

    if (!message) {
        Swal.fire({
            title: "خطای تکیمل اطلاعات",
            text: "پیام الزامی است",
            icon: "warning",
            confirmButtonText: "متوجه شدم",
            showConfirmButton: false
        });
        return;
    }


    let body = {
        fullname: fullname,
        phoneNumber: phoneNumber,
        companyName: companyName,
        position: position,
        message: message
    }
    Swal.fire({
        title: "آیا پیام ارسال شود؟",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        cancelButtonText: "انصراف",
        confirmButtonText: "بله ارسال شود"
    }).then((result) => {
        if (result.isConfirmed) {
            rest.postAsync("?handler=SendMessage", null, body, function (isSuccess, response) {
                if (response.isSuccess) {
                    Swal.fire({
                        title: "پیام با موفقیت ارسال شد",
                        text: "کارشناسان ما به زودی با شما ارتباط برقرار میکنند",
                        icon: "success",
                        confirmButtonText: "متوجه شدم"
                    });
                    fullname = "";
                    phoneNumber = "";
                    companyName = "";
                    position = "";
                    message = "";
                } else {
                    Swal.fire({
                        title: "پیام ارسال نشد",
                        text: response.message,
                        icon: "warning",
                        confirmButtonText: "متوجه شدم"
                    });
                }
            });
        }
    });
}
