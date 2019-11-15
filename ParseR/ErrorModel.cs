
namespace ParseR
{
    class ErrorModel
    {
        public string date { get; set; } 
        public string error { get; set; }
        public string sourceError { get; set; }
        public string stackTrace { get; set; }
        public ErrorModel()
        {
        }
    }
}
