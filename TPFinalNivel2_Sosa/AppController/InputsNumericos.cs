
namespace AppController
{
    public class InputsNumericos
    {

        public static bool esCaracterNumerico(char caracter)
        {
            if (!char.IsControl(caracter) && !char.IsNumber(caracter))
                return true;
            else return false;
        }

    }
}
