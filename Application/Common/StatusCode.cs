using System.ComponentModel.DataAnnotations;

namespace Application.Common;

public enum StatusCode
{
    [Display(Name = "200")]
    Ok200,
    [Display(Name = "500")]
    InternalServerError500,
    [Display(Name = "501")]
    NotImplemented501,
    [Display(Name = "502")]
    BadGateway502,
    [Display(Name = "503")]
    ServiceUnavailable503,
    [Display(Name = "504")]
    GatewayTimeout504,
    [Display(Name = "400")]
    BadRequest400,
    [Display(Name = "401")]
    Unauthorized401,
    [Display(Name = "403")]
    Forbidden403,
    [Display(Name = "404")]
    NotFound404
}
