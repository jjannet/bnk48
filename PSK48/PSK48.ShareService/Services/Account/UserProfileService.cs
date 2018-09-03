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
    public class UserProfileService : IUserProfileService
    {
        private IRepository<User> _user;
        private IRepository<UserProfile> _profile;

        public UserProfileService(IRepository<User> user, IRepository<UserProfile> profile)
        {
            this._user = user;
            this._profile = profile;
        }

        public UserProfile save(UserProfile data)
        {
            validateUser(data);
            validateUserProfile(data);

            if (_isThereThisProfile(data)) return insert(data);
            else return update(data);
        }

        private UserProfile insert(UserProfile data)
        {
            this._profile.Insert(data);
            this._profile.SaveChanges();

            return data;
        }

        private UserProfile update(UserProfile data)
        {
            this._profile.Update(data);
            this._profile.SaveChanges();

            return data;
        }

        private void validateUser(UserProfile data)
        {
            var validate = new ValidationUtility<UserProfile>(data);
            validate.AddRule(o => string.IsNullOrEmpty(o.username), "กรุณากรอก username", 1);
            validate.AddCustomAction(_userNotExist, "ไม่มี user นี้ในระบบ", 2);

            var validateResult = validate.Validate();
            if (validateResult.Any())
                throw new ValidateException(string.Join(",", validateResult));
        }

        private void validateUserProfile(UserProfile data)
        {
            var validate = new ValidationUtility<UserProfile>(data);

            validate.AddRule(o => o == null, "ไม่พบข้อมูล", 1);
            validate.AddRule(o => string.IsNullOrEmpty(o.firstName), "กรุณากรอก ชื่อ", 2);
            validate.AddRule(o => string.IsNullOrEmpty(o.lastName), "กรุณากรอก นามสกุล", 2);
            validate.AddRule(o => string.IsNullOrEmpty(o.nickName), "กรุณากรอก ชื่อเล่น", 2);


            var validateResult = validate.Validate();
            if (validateResult.Any())
                throw new ValidateException(string.Join(",", validateResult));
        }

        private bool _userNotExist(UserProfile data)
        {
            return !this._user.GetAll().Any(m => m.username == data.username);
        }

        private bool _isThereThisProfile(UserProfile data)
        {
            return this._profile.GetAll().Any(m => m.username == data.username);
        }
    }
}
