function SendMessage() {
    // دریافت مقادیر
    let fullname = document.getElementById("fullname").value;
    let phoneNumber = document.getElementById("phoneNumber").value;
    let companyName = document.getElementById("companyName").value;
    let position = document.getElementById("position").value;
    let message = document.getElementById("message").value;

    // اعتبارسنجی
    if (!fullname) {
        Swal.fire({
            title: "خطای تکمیل اطلاعات",
            text: "نام و نام خانوادگی الزامی است",
            icon: "warning",
            confirmButtonText: "متوجه شدم",
            timer: 3000,
            customClass: {
                confirmButton: 'custom-info-btn',
                
            }
        });
        return;
    }

    if (!phoneNumber) {
        Swal.fire({
            title: "خطای تکمیل اطلاعات",
            text: "شماره تماس الزامی است",
            icon: "warning",
            confirmButtonText: "متوجه شدم",
            timer: 3000,
            customClass: {
                confirmButton: 'custom-info-btn',
            }
        });
        return;
    }

    if (!message) {
        Swal.fire({
            title: "خطای تکمیل اطلاعات",
            text: "پیام الزامی است",
            icon: "warning",
            confirmButtonText: "متوجه شدم",
            timer: 3000,
            customClass: {
                confirmButton: 'custom-info-btn',
            }
        });
        return;
    }

    // ساخت بدنه درخواست
    let body = {
        Fullname: fullname,
        PhoneNumber: phoneNumber,
        CompanyName: companyName,
        Position: position,
        Message: message
    };

    Swal.fire({
        title: "آیا پیام ارسال شود؟",
        icon: "question",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        cancelButtonText: "انصراف",
        confirmButtonText: "بله ارسال شود",
        customClass: {
            confirmButton: 'custom-confirm-btn',
            cancelButton: 'custom-cancel-btn'
        }
    }).then((result) => {
        if (result.isConfirmed) {
            // نمایش loading
            Swal.fire({
                title: 'در حال ارسال...',
                allowOutsideClick: false,
                didOpen: () => { Swal.showLoading(); }
            });

            // استفاده از rest.js - پارامتر دوم null است چون توکن خودکار اضافه می‌شود
            rest.postAsync("?handler=SendMessage", null, body, function (isSuccess, response) {
                // بستن loading
                Swal.close();

                if (isSuccess && response.isSuccess) {
                    Swal.fire({
                        title: "پیام با موفقیت ارسال شد",
                        text: "کارشناسان ما به زودی با شما ارتباط برقرار میکنند",
                        icon: "success",
                        confirmButtonText: "متوجه شدم",
            customClass: {
                            confirmButton: 'custom-info-btn',
                        }
                    });

                    // پاک کردن فرم
                    document.getElementById("fullname").value = "";
                    document.getElementById("phoneNumber").value = "";
                    document.getElementById("companyName").value = "";
                    document.getElementById("position").value = "";
                    document.getElementById("message").value = "";
                } else {
                    Swal.fire({
                        title: "پیام ارسال نشد",
                        text: response?.message || "خطای ناشناخته رخ داد",
                        icon: "error",
                        confirmButtonText: "متوجه شدم",
                        customClass: {
                            confirmButton: 'custom-info-btn',
                        }
                    });
                }
            });
        }
    });
}