using System;

namespace SuspensionManagerWebApp.Models
{
    public class SusElement
    {
        //properties
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string ModelYear { get; set; }
        public string Length { get; set; }
        public string Stroke { get; set; }
        public string SuspensionTyp { get; set; }
        public List<Setting> Settings { get; set; }

        
    }
}
