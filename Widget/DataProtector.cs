using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Widget
{
    internal class DataProtector
    {

        public static byte[] ProtectData(byte[] data)
        {
            return ProtectedData.Protect(data, optionalEntropy: null, scope: DataProtectionScope.CurrentUser);
        }

        public static byte[] UnprotectData(byte[] encryptedData)
        {
            return ProtectedData.Unprotect(encryptedData, optionalEntropy: null, scope: DataProtectionScope.CurrentUser);
        }
    }
}
