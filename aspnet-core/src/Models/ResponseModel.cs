namespace UnitTesting.Api.Models;

public class ResponseModel<T>
{
    public bool Success { get; set; }
    public T Data { get; set; }
    public string[] Errors { get; set; }

    public ResponseModel()
    {
    }
    public ResponseModel(bool success, T data)
    {
        Success = success;
        Data = data;
    }

    public ResponseModel(bool success, T data, string[] errors) : this(success, data)
    {
        Errors = errors;
    }

    public ResponseModel(T data)
    {
        Success = true;
        Data = data;
    }

    public ResponseModel(string error)
    {
        Success = false;
        Errors = new string[] { error };
    }

    public ResponseModel(string[] errors)
    {
        Success = false;
        Errors = errors;
    }
}
