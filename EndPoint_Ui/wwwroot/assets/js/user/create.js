
$(document).ready(function () {
    $('#roles').select2({
        placeholder: 'چند گزینه انتخاب کنید',
        multiple: true,
        ajax: {
            url: '?handler=FetchRoles',
            dataType: 'json',
            delay: 1000, 
            data: function (params) {
                return {
                    search: params.term 
                };
            },
            processResults: function (data) {
              
                return {
                   
                    results: data.map(item => ({
                        id: item.id,     
                        text: item.name  
                    }))
                };
            },
            cache: true
        },
        minimumInputLength: 1
    });
});
