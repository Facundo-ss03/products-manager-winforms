
namespace AppController
{
    public class InputsAlfabeticos
    {
        public static bool esCaracterAlfabetico(char caracter)
        {
            if (!char.IsControl(caracter) && !char.IsLetter(caracter) && !char.IsWhiteSpace(caracter))
                return true;
            else return false;
        }
    }
}
