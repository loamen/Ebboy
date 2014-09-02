using Ebboy.Core.Data;
using Ebboy.Core.Domain;
using Ebboy.Core.Domain.Security;
using Ebboy.Core.Domain.Users;
using Ebboy.Core.Helpers;
using Ebboy.Services.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Ebboy.Services.Users
{
    public partial class MemberService : IMemberService
    {
        #region 变量
        /// <summary>
        /// 用户仓储
        /// </summary>
        private readonly IRepository<Member> _userRepository;
        /// <summary>
        /// 加密服务
        /// </summary>
        private readonly IEncryptionService _encryptionService;
        #endregion

        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="userRepository"></param>
        public MemberService(
            IEncryptionService encryptionService,
           
            IRepository<Member> userRepository)
        {
            _encryptionService = encryptionService;
            _userRepository = userRepository;
        }
        #endregion

        #region 属性

        /// <summary>
        /// 获取用户编号
        /// </summary>
        /// <returns></returns>
        /// 创 建 者：Loamen.com
        public virtual int MaxUserNo
        {
            get
            {
                if (_userRepository.Table.Count() == 0)
                {
                    return 10001;
                }
                var maxNo = _userRepository.Table.Max(u => u.UserNo);
                return maxNo + 1;
            }
        }
        #endregion

        #region 方法
        /// <summary>
        /// 插入一条用户数据
        /// </summary>
        /// <param name="user"></param>
        /// 创 建 者：Loamen.com
        public virtual void Insert(Member user)
        {
            _userRepository.Insert(user);
        }

        /// <summary>
        /// 根据GUID获取用户信息
        /// </summary>
        /// <param name="userGuid"></param>
        /// <returns></returns>
        /// 创 建 者：Loamen.com
        public virtual Member GetById(int id)
        {
            return _userRepository.GetById(id);
        }

        /// <summary>
        /// 获取所有用户列表
        /// </summary>
        /// <returns></returns>
        /// 创 建 者：Loamen.com
        public virtual IQueryable<Member> GetAllList()
        {
            return _userRepository.Table;
        }

        /// <summary>
        /// 根据GUID获取用户信息
        /// </summary>
        /// <param name="userGuid"></param>
        /// <returns></returns>
        /// 创 建 者：Loamen.com
        public virtual Member GetUserByGuid(Guid userGuid)
        {
            if (null == userGuid)
                return null;

            var query = from u in _userRepository.Table
                        orderby u.Id
                        where u.UserGuid == userGuid
                        select u;
            var user = query.FirstOrDefault();
            return user;
        }

        /// <summary>
        /// 根据用户名，获取用户实体
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        /// 创 建 者：Loamen.com
        public virtual Member GetUserByUserName(string userName)
        {
            if (string.IsNullOrEmpty(userName))
                return null;

            var query = from u in _userRepository.Table
                        orderby u.Id
                        where u.Username == userName
                        select u;
            var user = query.FirstOrDefault();
            return user;
        }

        /// <summary>
        /// 根据邮箱/用户名/手机号获取用户信息
        /// </summary>
        /// <param name="emailOrUserName"></param>
        /// <returns></returns>
        /// 创 建 者：Loamen.com
        public virtual Member GetUserByEmailOrUserName(string emailOrUserName)
        {
            if (string.IsNullOrWhiteSpace(emailOrUserName))
                return null;

            var query = from u in _userRepository.Table
                        orderby u.Id
                        where u.Email == emailOrUserName || u.Username == emailOrUserName || u.Mobile == emailOrUserName
                        select u;
            var user = query.FirstOrDefault();
            return user;
        }

        /// <summary>
        /// 用户注册
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        /// 创 建 者：Loamen.com
        public virtual OperationResult Register(Member user)
        {
            var result = new OperationResult();

            if (user == null)
            {
                result.Errors.Add("用户信息不正确！");
                return result;
            }

            if(string.IsNullOrWhiteSpace(user.Email))
            {
                result.Errors.Add("邮箱不能为空！");
                return result;
            }

            var userExist = GetUserByEmailOrUserName(user.Email);
            if (userExist != null)
            {
                result.Errors.Add("用户已经存在！");
                return result;
            }

            Random random = new Random();
            List<string> values = EnumHelper.GetValueList(typeof(EnumPasswordFormat));
            values.Remove(((int)EnumPasswordFormat.Clear).ToString()); //TODO 禁止明文

            user.PasswordFormatId = Convert.ToInt32(values.OrderBy(m => random.Next(values.Count())).Take(1).First());
            user.Password = user.Password.Trim(); //去除空格
            user.PasswordFormat = _encryptionService.SHA1(user.Password).ToLower(); //OpenFire SHA1加密

            switch ((EnumPasswordFormat)user.PasswordFormatId)
            {
                case EnumPasswordFormat.Clear:
                    {
                        user.Password = user.Password;
                    }
                    break;
                case EnumPasswordFormat.Encrypted:
                    {
                        user.Password = _encryptionService.EncryptText(user.Password);
                    }
                    break;
                case EnumPasswordFormat.Hashed:
                    {
                        string saltKey = _encryptionService.CreateSaltKey(5);
                        user.PasswordSalt = saltKey;
                        user.Password = _encryptionService.CreatePasswordHash(user.Password, saltKey);
                    }
                    break;
                case EnumPasswordFormat.MD5:
                    {
                        string saltKey = _encryptionService.CreateSaltKey(5);
                        user.PasswordSalt = saltKey;
                        user.Password = _encryptionService.MD5Hash(user.Password, saltKey);
                    }
                    break;
                default:
                    break;
            }
            user.Email = user.Email.Trim().ToLower();
            user.Active = true; //TODO 注册并激活
            user.UserGuid = Guid.NewGuid();
            user.UserNo = MaxUserNo;
            user.IsSystemAccount = false;
            user.LastActivityDateUtc = DateTime.UtcNow;
            user.CreatedOnUtc = DateTime.UtcNow;
            user.Username = user.Email;

            _userRepository.Insert(user);
            result.Message = "注册成功";

            return result;
        }

        /// <summary>
        /// 用户登陆
        /// </summary>
        /// <param name="userName">邮箱/用户名/手机</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        /// 创 建 者：Loamen.com
        public virtual OperationResult Login(string userName, string password)
        {
            var result = new OperationResult();
            Member user = GetUserByEmailOrUserName(userName);

            if (user == null)
            {
                result.AddError("用户不存在！");
                return result;
            }
            if (user.Deleted)
            {
                result.AddError("用户已经被删除！");
            }
            if (!user.Active)
            {
                result.AddError("用户还未激活！");
            }

            if (!result.Success) { return result; }

            string pwd = "";
            switch ((EnumPasswordFormat)user.PasswordFormatId)
            {
                case EnumPasswordFormat.Encrypted:
                    pwd = _encryptionService.EncryptText(password);
                    break;
                case EnumPasswordFormat.Hashed:
                    pwd = _encryptionService.CreatePasswordHash(password, user.PasswordSalt);
                    break;
                case EnumPasswordFormat.MD5:
                    pwd = _encryptionService.MD5Hash(password, user.PasswordSalt);
                    break;
                default:
                    pwd = password;
                    break;
            }

            bool isValid = pwd == user.Password;

            //save last login date
            if (isValid)
            {
                user.LastLoginDateUtc = DateTime.UtcNow;
                _userRepository.Update(user);
                result.Data = user;
                result.Message = "登陆成功！";
            }
            else
            {
                result.AddError("用户密码错误！");
            }

            return result;
        }

        /// <summary>
        /// 修改用户资料
        /// </summary>
        /// <param name="user"></param>
        /// 创 建 者：Loamen.com
        public virtual void Update(Member user) {
            _userRepository.Update(user);
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="user"></param>
        /// 创 建 者：Loamen.com
        public virtual void UpdatePWD(Member user) {
            Random random = new Random();
            List<string> values = EnumHelper.GetValueList(typeof(EnumPasswordFormat));
            values.Remove(((int)EnumPasswordFormat.Clear).ToString()); //TODO 禁止明文

            user.PasswordFormatId = Convert.ToInt32(values.OrderBy(m => random.Next(values.Count())).Take(1).First());
            user.Password = user.Password.Trim(); //去除空格
            user.PasswordFormat = _encryptionService.SHA1(user.Password).ToLower(); //OpenFire SHA1加密

            switch ((EnumPasswordFormat)user.PasswordFormatId)
            {
                case EnumPasswordFormat.Clear:
                    {
                        user.Password = user.Password;
                    }
                    break;
                case EnumPasswordFormat.Encrypted:
                    {
                        user.Password = _encryptionService.EncryptText(user.Password);
                    }
                    break;
                case EnumPasswordFormat.Hashed:
                    {
                        string saltKey = _encryptionService.CreateSaltKey(5);
                        user.PasswordSalt = saltKey;
                        user.Password = _encryptionService.CreatePasswordHash(user.Password, saltKey);
                    }
                    break;
                case EnumPasswordFormat.MD5:
                    {
                        string saltKey = _encryptionService.CreateSaltKey(5);
                        user.PasswordSalt = saltKey;
                        user.Password = _encryptionService.MD5Hash(user.Password, saltKey);
                    }
                    break;
                default:
                    break;
            }

            _userRepository.Update(user);
        }

        /// <summary>
        /// 修改用户名
        /// </summary>
        /// <param name="userGuid"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        /// 创 建 者：Loamen.com
        public virtual OperationResult EditUserName(Guid userGuid, string userName)
        {
            var result = new OperationResult();
            var user = GetUserByGuid(userGuid);

            if (string.IsNullOrEmpty(userName))
            {
                result.AddError("用户名不能为空！");
                return result;
            }

            var reg = new Regex("^/w+$");
            if (!reg.IsMatch(userName))
            {
                result.AddError("用户名只能为字母、数字和下划线！");
                return result;
            }

            if (user == null)
            {
                result.Errors.Add("用户不存在！");
                return result;
            }

            if (user.Email != user.Username)
            {
                result.Errors.Add("你已经修改过Ebboy号，不能再次修改！");
                return result;
            }

            var existUser = GetUserByUserName(userName);
            if (existUser != null)
            {
                result.Errors.Add("用户名已经被占用！");
                return result;
            }

            user.Username = userName.ToLower();
            Update(user);

            result.Message = "修改成功！";
            return result;
        }

        #endregion
    }
}
