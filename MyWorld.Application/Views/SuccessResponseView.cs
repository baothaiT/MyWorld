using System;

namespace MyWorld.Application.Views;

public class SuccessResponseView<T> : BaseResponseView<T>
{
    public SuccessResponseView(T data, string message = "Operation successful")
        : base(data, message, true)
    {
    }

    public SuccessResponseView()
        : base(default!, "Operation successful", true)
    {
    }
}
