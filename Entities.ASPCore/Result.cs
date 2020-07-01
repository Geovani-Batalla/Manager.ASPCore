using static Entities.ASPCore.Enums;

namespace Entities.ASPCore
{
    public class Result
    {
        public bool IsValid { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public ResultType ResultType { get; set; }
    }
}
