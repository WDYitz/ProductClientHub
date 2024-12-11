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
      throw new ArgumentException("Erro de validação");
    }

    return new ResponseClientJson();
  }
}
