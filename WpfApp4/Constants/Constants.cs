using WpfApp4.Models;

namespace WpfApp4.Constants
{
    public static class Constants
    {
        public static string PM => "±";
        public static readonly NumberWithError G = new(6.6743e-11, 1.5e-15);
    }
}
