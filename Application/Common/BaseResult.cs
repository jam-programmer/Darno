namespace Application.Common;
public class BaseResult<TData> : BaseResult
{
    public TData? Data { get; set; }
    public static BaseResult<TData> Success
        (TData? data,
        string? Message = null)
    {
        return new BaseResult<TData>()
        {
            StatusCode = StatusCode.Ok200,
            Data = data,
            Message = Message,
            IsSuccess = true
        };
    }
    public static BaseResult<TData> Fail
    (
    string? Message = null,
    StatusCode StatusCode = StatusCode.BadRequest400)
    {
        return new BaseResult<TData>()
        {
            StatusCode = StatusCode,
            Message = Message,
            IsSuccess = false

        };
    }


    public static BaseResult<TData> Fail
       (StatusCode StatusCode = StatusCode.BadRequest400)
    {
        return new BaseResult<TData>()
        {
            StatusCode = StatusCode,
            Message = string.Empty,
            IsSuccess = false

        };
    }
}
public class BaseResult
{

    public StatusCode StatusCode { get; set; }
    public bool IsSuccess { get; set; }
    public string? Message { get; set; }
    public static BaseResult Success(string? Message = null)
    {
        return new BaseResult()
        {
            StatusCode = StatusCode.Ok200,
            Message = Message,
            IsSuccess = true
        };
    }
    public static BaseResult Fail(string? Message = null,
        StatusCode StatusCode = StatusCode.BadRequest400)
    {
        return new BaseResult()
        {
            StatusCode = StatusCode,
            Message = Message,
            IsSuccess = false

        };
    }





}