using Newtonsoft.Json;

namespace Api.Application.Exceptions;
public class ExceptionModel:ErrorStatusCode
{
    public IEnumerable<string> Errors { get; set; }
    public override string ToString() => JsonConvert.SerializeObject(this);

}

public class ErrorStatusCode
{
    public int StatusCode { get; set; }
}
