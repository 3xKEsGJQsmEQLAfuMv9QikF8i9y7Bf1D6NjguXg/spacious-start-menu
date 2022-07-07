using System;
using System.DirectoryServices;
using System.Threading.Tasks;

namespace SpaciousStartMenu.Env
{
    internal class UserInfo
    {
        private string? _displayName;
        private readonly string _initialDisplayName;

        public UserInfo(string initialDisplayName)
        {
            _initialDisplayName = initialDisplayName;
        }

        public string GetUserName()
        {
            return Environment.UserName;
        }

        public string GetDisplayName()
        {
            if (_displayName is not null)
            {
                return _displayName;
            }

            string path = $"WinNT://{Environment.UserDomainName}/{Environment.UserName}";

            using var de = new DirectoryEntry(path);

            string result = de.Properties["FullName"]?.Value?.ToString() ?? "";
            if (string.IsNullOrEmpty(result))
            {
                return _initialDisplayName;
            }
            else
            {
                _displayName = result;
                return _displayName;
            }
        }
    }
}
