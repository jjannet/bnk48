using PSK48.IShareService.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PSK48.IShareService.TransactionModels
{
    public class ChangePasswordModel : User
    {
        public string newPassword { get; set; }
        public string confirmPassword { get; set; }
    }
}
