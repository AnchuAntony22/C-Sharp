namespace WebApplicationASS1test.Models
{
    public class Temperature
    {
        public static string CheckTemperature(float temperature)
        {
            if (temperature >= 37.5)
            {
                return "You have a fever.";
            }
            else if (temperature < 35)
            {
                return "You might be experiencing hypothermia.";
            }
            else
            {
                return "Your temperature is normal.";
            }
        }

    }
}
