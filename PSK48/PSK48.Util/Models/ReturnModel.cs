using System;
using System.Collections.Generic;
using System.Text;

namespace PSK48.Util.Models
{
    public class ReturnModel
    {
        public ReturnModelType type { get; set; }
        public string message { get; set; }
        public object data { get; set; }
        public LoadingModel loading { get; set; }

        public ReturnModel()
        {
            type = ReturnModelType.None;
            message = string.Empty;
            loading = new LoadingModel();
        }
    }

    public enum ReturnModelType
    {
        None = 0, Successs = 1, Error = -1
    }
}
