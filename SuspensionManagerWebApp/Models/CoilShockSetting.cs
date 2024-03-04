using System.ComponentModel.DataAnnotations;

namespace SuspensionManagerWebApp.Models
{
    public class CoilShockSetting : Setting
    {

        public string SpringRate { get; set; }
        public string PreloadTurns { get; set; }
    }
}
