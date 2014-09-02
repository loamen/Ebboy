using Ebboy.Core.Domain;
using Ebboy.Core.Domain.Users;
using System;
using System.Linq;

namespace Ebboy.Services.Users
{
    public partial interface IMemberService
    {
        /// <summary>
        /// 最大用户编号
        /// </summary>
        int MaxUserNo { get; }

        /// <summary>
        /// 插入新用户
        /// </summary>
        /// <param name="user"></param>
        void Insert(Member user);

        /// <summary>
        /// 根据主键获取用户实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Member GetById(int id);

        /// <summary>
        /// 获取所有用户列表
        /// </summary>
        /// <returns></returns>
        IQueryable<Member> GetAllList();

        /// <summary>
        /// 根据用户GUID，获取用户实体
        /// </summary>
        /// <param name="userGuid"></param>
        /// <returns></returns>
        Member GetUserByGuid(Guid userGuid);

        /// <summary>
        /// 根据用户名，获取用户实体
        /// </summary>
        /// <param name="userGuid"></param>
        /// <returns></returns>
        Member GetUserByUserName(string userName);

        /// <summary>
        /// 用户注册
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        OperationResult Register(Member user);

        /// <summary>
        /// 根据邮箱或用户名获取用户信息
        /// </summary>
        /// <param name="emailOrUserName"></param>
        /// <returns></returns>
        Member GetUserByEmailOrUserName(string emailOrUserName);

        /// <summary>
        /// 用户登陆
        /// </summary>
        /// <param name="userName">邮箱/用户名/手机</param>
        /// <param name="password"></param>
        /// <returns></returns>
        OperationResult Login(string userName, string password);
        /// <summary>
        /// 修改用户资料
        /// </summary>
        /// <param name="user"></param>
        void Update(Member user);

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="user"></param>
        void UpdatePWD(Member user);

         /// <summary>
        /// 修改用户名
        /// </summary>
        /// <param name="userGuid"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        OperationResult EditUserName(Guid userGuid, string userName);
    }
}
