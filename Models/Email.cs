namespace FiltroApi.Models
{
    public class Email
    {
        public From? from { get; set; }
        public To[]? to { get; set; }
        public string? subject { get; set; }
        public string? text { get; set; }
        
        // public string? html { get; set; }
    }

    public class From
    {
        public string? email { get; set; }
    }

    public class To
    {
        public string? email { get; set; }
    }
}