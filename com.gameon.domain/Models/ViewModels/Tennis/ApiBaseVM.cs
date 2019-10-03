using System;

namespace com.gameon.domain.Models.ViewModels.Tennis
{
    public class ApiBaseVM
    {
        public DateTime? GeneratedAt { get; set; }
        public string Schema { get; set; }

        public ApiBaseVM() { }
    }
}
