using System;
using System.Collections.Generic;
using System.Text;

namespace PSK48.Util.Validator.Models
{
    public class ValidationRule<T>
    {
        public Func<T, bool> Prediction { get; set; }
        public int Sequence { get; set; }
        public string ErrorMessage { get; set; }
    }
}
