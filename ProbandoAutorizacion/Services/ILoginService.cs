using ProbandoAutorizacion.Models;

namespace ProbandoAutorizacion.Services
{
    public interface ILoginService
    {
        User? Authenticate(UserLogin user);
        string Generate(User user);
    }
}