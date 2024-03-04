using System.ComponentModel.DataAnnotations;

namespace SuspensionManagerWebApp.Models
{
    public class AirShockSetting : Setting
    { 
        public string AirPressure { get; set; }
        public string NPosToken { get; set; }
        public string NNegToken { get; set; }
    }
}
