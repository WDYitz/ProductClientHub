using ProductClientHubAPI.ExceptionsBase;
using ProductClientHubAPI.Http.Requests;
using ProductClientHubAPI.Http.Responses;

namespace ProductClientHubAPI.UseCases.Clients.Register;

public class RegisterClientUseCase
{
  public ResponseClientJson Execute(RequestClientJson request)
  {
    var validator = new RegisterClientValidator();
    var result = validator.Validate(request);

    if (!result.IsValid)
    {
      var errors = result.Errors.Select(e => e.ErrorMessage).ToList();
      throw new ErrorOnValidationException(errors);
    }

    return new ResponseClientJson();
  }
}
