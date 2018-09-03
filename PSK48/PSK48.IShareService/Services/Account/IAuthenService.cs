using PSK48.IShareService.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PSK48.IShareService.Services.Account
{
    public interface IAuthenService
    {
        User login(string username, string password);
    }
}
