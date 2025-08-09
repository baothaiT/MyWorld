using System;

namespace MyWorld.Application.Views;

public class BaseResponseView<T>
{
    public T Data { get; set; }
    public string Message { get; set; }
    public bool Success { get; set; }

    public BaseResponseView(T data, string message, bool success)
    {
        Data = data;
        Message = message;
        Success = success;
    }
    public BaseResponseView()
    {
        Data = default!;
        Message = string.Empty;
        Success = false;
    }
}
