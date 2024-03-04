using System.ComponentModel.DataAnnotations;

namespace SuspensionManagerWebApp.Models
{
    public interface ISetting
    {
        [Key] // nur benötigt wenn der key name nicht Id oder ID ist!
        int Id { get; set; }
        string Date { get; set; }
        string Note { get; set; }
        string LSC { get; set; }
        string HSC { get; set; }
        string LSR { get; set; }
        string HSR { get; set; }
    }
}
