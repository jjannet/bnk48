using PSK48.Infrastructure.Repository;
using PSK48.IShareService.Models;
using PSK48.IShareService.Services.Account;
using PSK48.Util.Exceptions;
using PSK48.Util.Validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PSK48.ShareService.Services.Account
{
    public class RegisterService : IRegisterService
    {
        private IRepository<User> _user;

        public RegisterService(IRepository<User> userRes)
        {
            this._user = userRes;
        }

        public User register(User data)
        {
            validate(data);

            data.actived = true;

            _user.Insert(data);
            _user.SaveChanges();

            return data;
        }

        private void validate(User data)
        {
            var validate = new ValidationUtility<User>(data);
            validate.AddRule(o => string.IsNullOrEmpty(o.username), "กรุณากรอก username", 1);
            validate.AddRule(o => string.IsNullOrEmpty(o.password), "กรุณากรอก password", 1);
            validate.AddRule(o => string.IsNullOrEmpty(o.email), "กรุณากรอก email", 2);
            validate.AddRule(o => string.IsNullOrEmpty(o.displayName), "กรุณากรอกชื่อที่ใช้แสดงในระบบ", 2);
            validate.AddCustomAction(CheckDuplicateUsername, "ชื่อผู้ใช้งานนี้ถูกใช้งานแล้ว", 3);
            validate.AddCustomAction(CheckDuplicateDisplayName, "ชื่อที่ใช้แสดงในระบบนี้ถูกใช้งานแล้ว", 3);

            var validateResult = validate.Validate();
            if (validateResult.Any())
                throw new ValidateException(string.Join(",", validateResult));
        }

        private bool CheckDuplicateUsername(User model)
        {
            return _user.GetAll().Any(o => o.username == model.username);
        }
        private bool CheckDuplicateDisplayName(User model)
        {
            return _user.GetAll().Any(o => o.displayName == model.displayName);
        }
    }
}
