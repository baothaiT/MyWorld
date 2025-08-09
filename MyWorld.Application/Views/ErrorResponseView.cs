using System;

namespace MyWorld.Application.Views;

public class ErrorResponseView<T> : BaseResponseView<T>
{
    public ErrorResponseView(T data, string message = "An error occurred")
        : base(data, message, false)
    {
    }

    public ErrorResponseView()
        : base(default!, "An error occurred", false)
    {
    }
}
