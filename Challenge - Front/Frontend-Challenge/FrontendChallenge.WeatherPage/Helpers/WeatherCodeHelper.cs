namespace FrontendChallenge.WeatherPage.Helpers
{
    public static class WeatherCodeHelper
    {
        public static string ObtenerDescripcion(int codigo)
        {
            return codigo switch
            {
                0 => "Cielo despejado",
                1 => "Cielo principalmente despejado",
                2 => "Cielo algo nublado",
                3 => "Cielo cubierto",
                45 => "Niebla",
                48 => "Niebla con escarcha",
                51 => "Llovizna ligera",
                53 => "Llovizna moderada",
                55 => "Llovizna intensa",
                56 => "Llovizna helada ligera",
                57 => "Llovizna helada intensa",
                61 => "Lluvia leve",
                63 => "Lluvia moderada",
                65 => "Lluvia fuerte",
                66 => "Lluvia helada leve",
                67 => "Lluvia helada fuerte",
                71 => "Nieve leve",
                73 => "Nieve moderada",
                75 => "Nieve fuerte",
                77 => "Granos de nieve",
                80 => "Chubascos leves",
                81 => "Chubascos moderados",
                82 => "Chubascos violentos",
                85 => "Nevadas leves",
                86 => "Nevadas fuertes",
                95 => "Tormenta: leve o moderada",
                96 => "Tormenta con granizo leve",
                99 => "Tormenta con granizo fuerte",
                _ => "Desconocido"
            };
        }
    }
}
