using System.ComponentModel.DataAnnotations;

namespace SuspensionManagerWebApp.Models
{
	public class CoilForkSetting : Setting
	{
		public string SpringRate { get; set; }
		public string PreloadTurns { get; set; }

    }
}
