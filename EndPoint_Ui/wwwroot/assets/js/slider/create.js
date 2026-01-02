$(document).ready(function () {
    flatpickr("#start", {
        locale: "fa",
        hijri: true,
        dateFormat: "Y/m/d",
        disableMobile: true
    });


    flatpickr("#end", {
        locale: "fa",
        hijri: true,
        dateFormat: "Y/m/d",
        disableMobile: true 
    });
});

