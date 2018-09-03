using PSK48.IShareService.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PSK48.IShareService.Services.Account
{
    public interface IRegisterService
    {
        User register(User data);
    }
}
