using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mind.Domain.ViewModels;

public class ResponseViewModel
{
    public int StatusCode { get; set; }
    public string? Message { get; set; } = string.Empty;

    public ResponseViewModel() { }

    public ResponseViewModel(int statusCode)
    {
        StatusCode = statusCode;
        Message = string.Empty;
    }

    public ResponseViewModel(int statusCode, string? message)
    {
        StatusCode = statusCode;
        Message = message;
    }
}