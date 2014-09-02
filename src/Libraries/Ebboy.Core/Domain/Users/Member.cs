using Ebboy.Core.Domain.Common;
using System;
using System.Collections.Generic;

namespace Ebboy.Core.Domain.Users
{
    public partial class Member : BaseEntity
    {
        private string _avatar;
        public System.Guid UserGuid { get; set; }
        public int UserNo { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string RealName { get; set; }
        public string NickName { get; set; }

        public EnumSex Sex { get; set; }
        public string Avatar 
        { 
            get
            {
                if (string.IsNullOrWhiteSpace(_avatar))
                    _avatar = "/Content/img/avatars/male.png";

                return _avatar;
            }
            set { _avatar = value; }
        }
        public string Mobile { get; set; }
        public string QQ { get; set; }
        public string Weixin { get; set; }
        public string Password { get; set; }
        public string PasswordFormat { get; set; }
        public int PasswordFormatId { get; set; }
        public string PasswordSalt { get; set; }
        public string AdminComment { get; set; }
        public Nullable<Guid> AddressId { get; set; }
        public string Address { get; set; }
        public bool Active { get; set; }
        public bool Deleted { get; set; }
        public bool IsSystemAccount { get; set; }
        public string SystemName { get; set; }
        public string LastIpAddress { get; set; }
        public System.DateTime CreatedOnUtc { get; set; }
        public Nullable<System.DateTime> LastLoginDateUtc { get; set; }
        public Nullable<System.DateTime> LastActivityDateUtc { get; set; }

        public string Mood { get; set; }
    }
}
