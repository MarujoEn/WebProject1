using WebProject1.Models;

namespace WebProject1.Interfaces
{
    public interface IUserRepositorie
    {
        /*
         Interface funciona como um contrato,
        define oque uma classe deve fazer
        e quais metodos e propriedades terá,
        mas não diz como deve fazer.
         */

        LoginViewModel Validate(string email, string password);
    }
}
