namespace SuspensionManagerWebApp.Models
{
    public class AirShockSetting : Setting
    {
        public int Id { get; set; }
        public string AirPressure { get; set; }
        public string NPosToken { get; set; }
        public string NNegToken { get; set; }
    }
}
