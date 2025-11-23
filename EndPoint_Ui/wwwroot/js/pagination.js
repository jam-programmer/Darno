$(document).ready(function () {

    var currentPage = $("#pagination-body").data("page-index");


    var totalPages = $("#pagination-body").data("total-pages");


    var baseUrl = $("#pagination-body").data("path");


    var search = $("#pagination-body").data("search");


    var queryParams = $("#pagination-body").data("query-params") || {};
    function paginate(totalPages, currentPage, baseUrl, filter = '', queryParams = {}) {
        var paginationHtml = '<nav aria-label="Page navigation"><ul class="pagination">';


        if (currentPage > 1) {
            paginationHtml += `  
                <li class="page-item prev">  
                    <a class="page-link" href="${baseUrl}?currentPage=${currentPage - 1}&
                    Keyword=${filter}${Object.keys(queryParams).length ? '&' + $.param(queryParams) : ''}">  
                      <<
                    </a>  
                </li>  
            `;
        } else {
            paginationHtml += '<li class="page-item prev disabled"><a class="page-link" href="javascript:void(0);"><<</a></li>';
        }

        var startPage = Math.max(1, currentPage - 2);
        var endPage = Math.min(totalPages, startPage + 4);

        if (endPage - startPage < 4) {
            startPage = Math.max(1, endPage - 4);
        }

        for (var i = startPage; i <= endPage; i++) {
            if (i === currentPage) {
                paginationHtml += `  
                    <li class="page-item active">  
                        <a class="page-link" href="javascript:void(0);">${i}</a>  
                    </li>  
                `;
            } else {
                paginationHtml += `  
                    <li class="page-item">  
                        <a class="page-link" href="${baseUrl}?currentPage=${i}&Keyword=${filter}${Object.keys(queryParams).length ? '&' + $.param(queryParams) : ''}">${i}</a>  
                    </li>  
                `;
            }
        }

        if (currentPage < totalPages) {
            paginationHtml += `  
                <li class="page-item next">  
                    <a class="page-link" href="${baseUrl}?currentPage=${currentPage + 1}&Keyword=${filter}${Object.keys(queryParams).length ? '&' + $.param(queryParams) : ''}">  
                    >>
                    </a>  
                </li>  
            `;
        } else {
            paginationHtml += '<li class="page-item next disabled"><a class="page-link" href="javascript:void(0);">>></a></li>';
        }

        paginationHtml += '</ul></nav>';

        $("#pagination-body").html(paginationHtml);
    }

    $("#search-input").on("input", function () {
        var searchValue = $(this).val();
        paginate(totalPages, 1, baseUrl, searchValue, queryParams);
    });

    paginate(totalPages, currentPage, baseUrl, search, queryParams);
});