using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Evernote
{
    public class User
    {
        /// <summary>
        /// The unique numeric identifier for the account, which will not change for the lifetime of the account.
        /// </summary>
        public int id;

        /// <summary>
        /// The name that uniquely identifies a single user account. This name may be presented by the user, along with their password, to log into their account. May only contain a-z, 0-9, or '-', and may not start or end with the '-' 
        /// Length: EDAM_USER_USERNAME_LEN_MIN - EDAM_USER_USERNAME_LEN_MAX 
        /// Regex: EDAM_USER_USERNAME_REGEX
        /// </summary>
        public string username;

        /// <summary>
        /// The email address registered for the user. Must comply with RFC 2821 and RFC 2822.
        /// Third party applications that authenticate using OAuth do not have access to this field. 
        /// Length: EDAM_EMAIL_LEN_MIN - EDAM_EMAIL_LEN_MAX 
        /// Regex: EDAM_EMAIL_REGEX
        /// </summary>
        public string email;

        /// <summary>
        /// The printable name of the user, which may be a combination of given and family names. This is used instead of separate "first" and "last" names due to variations in international name format/order. May not start or end with a whitespace character. May contain any character but carriage return or newline (Unicode classes Zl and Zp). 
        /// Length: EDAM_USER_NAME_LEN_MIN - EDAM_USER_NAME_LEN_MAX 
        /// Regex: EDAM_USER_NAME_REGEX
        /// </summary>
        public string name;

        /// <summary>
        /// The zone ID for the user's default location. If present, this may be used to localize the display of any timestamp for which no other timezone is available. The format must be encoded as a standard zone ID such as "America/Los_Angeles" or "GMT+08:00" 
        /// Length: EDAM_TIMEZONE_LEN_MIN - EDAM_TIMEZONE_LEN_MAX 
        /// Regex: EDAM_TIMEZONE_REGEX
        /// </summary>
        public string timezone;

        /// <summary>
        /// The level of access permitted for the user.
        /// </summary>
        public PrivilegeLevel privilege;

        /// <summary>
        /// The date and time when this user account was created in the service.
        /// </summary>
        public DateTime created;

        /// <summary>
        /// The date and time when this user account was last modified in the service.
        /// </summary>
        public DateTime updated;

        /// <summary>
        /// If the account has been deleted from the system (e.g. as the result of a legal request by the user), the date and time of the deletion will be represented here. If not, this value will not be set.
        /// </summary>
        public DateTime deleted;

        /// <summary>
        /// If the user account is available for login and synchronization, this flag will be set to true.
        /// </summary>
        public bool active;

        /// <summary>
        /// DEPRECATED - Client applications should have no need to use this field.
        /// </summary>
        [System.Obsolete("DEPRECATED - Client applications should have no need to use this field.")]
        public string shardId;

        /// <summary>
        /// If present, this will contain a list of the attributes for this user account.
        /// </summary>
        public UserAttributes attributes;

        /// <summary>
        /// Bookkeeping information for the user's subscription.
        /// </summary>
        public Accounting accounting;

        /// <summary>
        /// If present, this will contain a set of commerce information relating to the user's premium service level.
        /// </summary>
        public PremiumInfo premiumInfo;

        /// <summary>
        /// If present, this will contain a set of business information relating to the user's business membership. If not present, the user is not currently part of a business.
        /// </summary>
        public BusinessUserInfo businessUserInfo;
    }

    /// <summary>
    /// This enumeration defines the possible permission levels for a user. Free accounts will have a level of NORMAL and paid Premium accounts will have a level of PREMIUM.
    /// </summary>
    public enum PrivilegeLevel
    {
        NORMAL = 1,
        PREMIUM = 3,
        VIP = 5,
        MANAGER = 7,
        SUPPORT = 8,
        ADMIN = 9,
    }
}
