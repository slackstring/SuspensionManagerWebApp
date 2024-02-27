using System.Diagnostics.Eventing.Reader;

namespace SuspensionManagerWebApp.Models
{
	public class Setting
	{
		public int Id { get; set; }
		public string Date { get; set; }
		public string Note { get; set; }
		public string LSC { get; set; }
		public string HSC { get; set; }
		public string LSR { get; set; }
		public string HSR { get; set; }

	}
}
