
function InsertOrder() {


    let FullName = document.getElementById("FullName").value;
    let PhoneNumber = document.getElementById("PhoneNumber").value;
    let Email = document.getElementById("Email").value;
    let Title = document.getElementById("Title").value;
    let ProjectType = document.getElementById("ProjectType").value;
    let PlatformType = document.getElementById("PlatformType").value;
    let IsOnlinePaymentGateway = document.getElementById("IsOnlinePaymentGateway").value;
    let IsMultilingual = document.getElementById("IsMultilingual").value;
    let IsSms = document.getElementById("IsSms").value;
    let IsOnlineChat = document.getElementById("IsOnlineChat").value;
    let IsReport = document.getElementById("IsReport").value;
    let IsPwa = document.getElementById("IsPwa").value;
    let Url = document.getElementById("Url").value;
    let HaveHost = document.getElementById("HaveHost").value;
    let HaveDomain = document.getElementById("HaveDomain").value;
    let File = document.getElementById("File").files[0];
    let Description = document.getElementById("Description").value;


    if (!FullName.trim()) {

        Swal.fire({
            title: "خطای تکمیل اطلاعات",
            text: "نام و نام خانوادگی الزامی است",
            icon: "warning",
            confirmButtonText: "متوجه شدم",
            customClass: {
                confirmButton: 'custom-info-btn',
            }
        });
        return;
    }

    if (!PhoneNumber.trim()) {

        Swal.fire({
            title: "خطای تکمیل اطلاعات",
            text: "شماره تماس الزامی است",
            icon: "warning",
            confirmButtonText: "متوجه شدم",
            customClass: {
                confirmButton: 'custom-info-btn',
            }
        });
        return;
    }

    if (!Title.trim()) {

        Swal.fire({
            title: "خطای تکمیل اطلاعات",
            text: "عنوان پروژه الزامی است",
            icon: "warning",
            confirmButtonText: "متوجه شدم",
            customClass: {
                confirmButton: 'custom-info-btn',
            }
        });
        return;
    }

    if (!Description.trim()) {
        Swal.fire({
            title: "خطای تکمیل اطلاعات",
            text: "توضیح پروژه الزامی است",
            icon: "warning",
            confirmButtonText: "متوجه شدم",
            customClass: {
                confirmButton: 'custom-info-btn',
            }
        });

        return;
    }

    // ایجاد شیء داده برای ارسال
    let formData = new FormData();
    formData.append('FullName', FullName);
    formData.append('PhoneNumber', PhoneNumber);
    formData.append('Url', Url);
    formData.append('Email', Email);
    formData.append('Title', Title);
    formData.append('ProjectType', ProjectType);
    formData.append('PlatformType', PlatformType);
    formData.append('IsOnlinePaymentGateway', IsOnlinePaymentGateway);
    formData.append('IsMultilingual', IsMultilingual);
    formData.append('IsSms', IsSms);
    formData.append('IsOnlineChat', IsOnlineChat);
    formData.append('IsReport', IsReport);
    formData.append('IsPwa', IsPwa);
    formData.append('HaveHost', HaveHost);
    formData.append('HaveDomain', HaveDomain);
    formData.append('Description', Description);

    if (File) {
        formData.append('File', File);
    }


    sendToServer(formData);
}

function sendToServer(formData) {
    rest.postForm('?handler=SendOrder', formData, (success, result) => {
        if (success) {
            Swal.fire({
                title: "موفق",
                text: "درخواست با موفقیت ثبت شد",
                icon: "success",
                confirmButtonText: "متوجه شدم",
                customClass: {
                    confirmButton: 'custom-success-btn',
                }
            });



            document.getElementById("FullName").value="";
            document.getElementById("PhoneNumber").value = "";
            document.getElementById("Email").value = "";
            document.getElementById("Title").value = "";
            document.getElementById("ProjectType").value = "";
            document.getElementById("PlatformType").value = "";
            document.getElementById("IsOnlinePaymentGateway").value = "";
            document.getElementById("IsMultilingual").value = "";
            document.getElementById("IsSms").value = "";
            document.getElementById("IsOnlineChat").value = "";
            document.getElementById("IsReport").value = "";
            document.getElementById("IsPwa").value = "";
            document.getElementById("Url").value = "";
            document.getElementById("HaveHost").value = "";
            document.getElementById("HaveDomain").value = "";
            document.getElementById("File").value = "";

            document.getElementById("Description").value = "";







        } else {
            console.error('Error:', result);
            Swal.fire({
                title: "خطا",
                text: result.message || "خطا در ثبت درخواست",
                icon: "error",
                confirmButtonText: "متوجه شدم",
                customClass: {
                    confirmButton: 'custom-error-btn',
                }
            });
        }
    });
}