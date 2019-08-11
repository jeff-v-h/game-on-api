using com.gameon.data.ThirdPartyApis.Models.Tennis;
using System;

namespace com.gameon.domain.ViewModels.Tennis
{
    public class ApiBaseVM
    {
        public DateTime? GeneratedAt { get; set; }
        public string Schema { get; set; }

        public ApiBaseVM(ApiBase a)
        {
            GeneratedAt = a.GeneratedAt;
            Schema = a.Schema;
        }

        public ApiBaseVM() { }
    }
}
