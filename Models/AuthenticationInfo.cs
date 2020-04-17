namespace LESSION_WEB_API_DEMO.Models
{
    /// <summary>
    /// Contains the authentication info of user
    /// </summary>
    public class AuthenticationInfo
    {
        /// <summary>
        ///  The username of user
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        ///  The password of user
        /// </summary>
        public string PassWord { get; set; }
    }
}