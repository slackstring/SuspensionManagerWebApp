namespace SuspensionManagerWebApp.Models
{
    public class CoilShockSetting : Setting
    {
        public int Id { get; set; }
        public string SpringRate { get; set; }
        public string PreloadTurns { get; set; } 
    }
}
