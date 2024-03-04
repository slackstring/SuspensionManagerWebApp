using System.ComponentModel.DataAnnotations;

namespace SuspensionManagerWebApp.Models
{
    public class AirForkSetting : Setting
    {
        public string AirPressure { get; set; }
        public string NToken { get; set; }
    }
}
