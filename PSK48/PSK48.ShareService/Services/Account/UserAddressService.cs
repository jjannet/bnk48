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
    public class UserAddressService : IUserAddressService
    {
        #region Constructor

        private IRepository<User> _user;
        private IRepository<UserAddress> _address;

        public UserAddressService(IRepository<User> user, IRepository<UserAddress> address)
        {
            this._user = user;
            this._address = address;
        }

        #endregion


        public void delete(UserAddress data)
        {
            _validaetDelete(data);

            this._address.Delete(this._address.Find(data.id));
            this._address.SaveChanges();
        }

        public UserAddress save(UserAddress data)
        {

        }


        private void _validaetDelete(UserAddress data)
        {
            var validate = new ValidationUtility<UserAddress>(data);
            validate.AddRule(m => string.IsNullOrEmpty(m.username), "กรุณากรอก username", 1);
            validate.AddCustomAction(_userNotExist, "ไม่พบข้อมูลผู้ใช้นี้", 2);
            validate.AddCustomAction(_addressNotExist, "ไม่พบข้อมูลที่อยู่นี้ในระบบ", 3);

            var validateResult = validate.Validate();
            if (validateResult.Any())
                throw new ValidateException(string.Join(",", validateResult));
        }
        private void _validateSave(UserAddress data)
        {
            var validate = new ValidationUtility<UserAddress>(data);
            validate.AddRule(m => string.IsNullOrEmpty(m.username), "กรุณากรอก username", 1);
            validate.AddCustomAction(_userNotExist, "ไม่พบข้อมูลผู้ใช้นี้", 2);

            validate.AddRule(m => string.IsNullOrEmpty(m.address1), "กรุณากรอกที่อยู่ 1", 4);
            validate.AddRule(m => string.IsNullOrEmpty(m.subDistrict), "กรุณากรอก ตำบล/แขวง", 4);
            validate.AddRule(m => string.IsNullOrEmpty(m.district), "กรุณากรอก อำเภอ/เขต", 4);
            validate.AddRule(m => m.province == "-1", "กรุณาเลือก จังหวัด", 4);
            validate.AddRule(m => string.IsNullOrEmpty(m.postcode), "กรุณากรอก หมายเลขไปรษณีย์", 4);
            validate.AddRule(m => string.IsNullOrEmpty(m.phone), "กรุณากรอก เบอร์โทร", 4);

            var validateResult = validate.Validate();
            if (validateResult.Any())
                throw new ValidateException(string.Join(",", validateResult));
        }

        private bool _addressNotExist(UserAddress data)
        {
            return !this._address.GetAll().Any(m => m.id == data.id);
        }
        private bool _userNotExist(UserAddress data)
        {
            return !this._user.GetAll().Any(m => m.username == data.username);
        }
    }
}
