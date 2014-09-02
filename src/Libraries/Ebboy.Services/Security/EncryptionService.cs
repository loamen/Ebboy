using Ebboy.Core.Domain.Security;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Ebboy.Services.Security
{
    /// <summary>
    /// 数据加密服务
    /// </summary>
    /// 创 建 者：Loamen.com
    
    public class EncryptionService : IEncryptionService
    {
        #region Fields
        private readonly SecuritySettings _securitySettings;
        #endregion

        #region Ctor
        public EncryptionService()
        {
            this._securitySettings = new SecuritySettings();
        }

        public EncryptionService(SecuritySettings securitySettings)
        {
            this._securitySettings = securitySettings;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Create salt key
        /// </summary>
        /// <param name="size">Key size</param>
        /// <returns>Salt key</returns>
        public virtual string CreateSaltKey(int size)
        {
            // Generate a cryptographic random number
            var rng = new RNGCryptoServiceProvider();
            var buff = new byte[size];
            rng.GetBytes(buff);

            // Return a Base64 string representation of the random number
            return Convert.ToBase64String(buff);
        }

        /// <summary>
        /// Create a password hash
        /// </summary>
        /// <param name="password">{assword</param>
        /// <param name="saltkey">Salk key</param>
        /// <param name="passwordFormat">Password format (hash algorithm)</param>
        /// <returns>Password hash</returns>
        public virtual string CreatePasswordHash(string password, string saltkey, string passwordFormat = "SHA1")
        {
            if (String.IsNullOrEmpty(passwordFormat))
                passwordFormat = "SHA1";
            string saltAndPassword = String.Concat(password, saltkey);

            //return FormsAuthentication.HashPasswordForStoringInConfigFile(saltAndPassword, passwordFormat);
            var algorithm = HashAlgorithm.Create(passwordFormat);
            if (algorithm == null)
                throw new ArgumentException("Unrecognized hash name", "hashName");

            var hashByteArray = algorithm.ComputeHash(Encoding.UTF8.GetBytes(saltAndPassword));
            return BitConverter.ToString(hashByteArray).Replace("-", "");
        }

        /// <summary>
        /// SHA1加密
        /// </summary>
        /// <param name="plainText">明文</param>
        /// <returns></returns>
        /// 创 建 者：Loamen.com
        public virtual string SHA1(string plainText)
        {
            var passwordFormat = "SHA1";

            //return FormsAuthentication.HashPasswordForStoringInConfigFile(saltAndPassword, passwordFormat);
            var algorithm = HashAlgorithm.Create(passwordFormat);
            if (algorithm == null)
                throw new ArgumentException("Unrecognized hash name", "hashName");

            var hashByteArray = algorithm.ComputeHash(Encoding.UTF8.GetBytes(plainText));
            return BitConverter.ToString(hashByteArray).Replace("-", "");
        }

        /// <summary>
        /// Encrypt text
        /// </summary>
        /// <param name="plainText">Text to encrypt</param>
        /// <param name="encryptionPrivateKey">Encryption private key</param>
        /// <returns>Encrypted text</returns>
        public virtual string EncryptText(string plainText, string encryptionPrivateKey = "")
        {
            if (string.IsNullOrEmpty(plainText))
                return plainText;

            if (String.IsNullOrEmpty(encryptionPrivateKey))
                encryptionPrivateKey = _securitySettings.EncryptionKey;

            var tDESalg = new TripleDESCryptoServiceProvider();
            tDESalg.Key = new ASCIIEncoding().GetBytes(encryptionPrivateKey.Substring(0, 16));
            tDESalg.IV = new ASCIIEncoding().GetBytes(encryptionPrivateKey.Substring(8, 8));

            byte[] encryptedBinary = EncryptTextToMemory(plainText, tDESalg.Key, tDESalg.IV);
            return Convert.ToBase64String(encryptedBinary);
        }

        /// <summary>
        /// Decrypt text
        /// </summary>
        /// <param name="cipherText">Text to decrypt</param>
        /// <param name="encryptionPrivateKey">Encryption private key</param>
        /// <returns>Decrypted text</returns>
        public virtual string DecryptText(string cipherText, string encryptionPrivateKey = "")
        {
            if (String.IsNullOrEmpty(cipherText))
                return cipherText;

            if (String.IsNullOrEmpty(encryptionPrivateKey))
                encryptionPrivateKey = _securitySettings.EncryptionKey;

            var tDESalg = new TripleDESCryptoServiceProvider();
            tDESalg.Key = new ASCIIEncoding().GetBytes(encryptionPrivateKey.Substring(0, 16));
            tDESalg.IV = new ASCIIEncoding().GetBytes(encryptionPrivateKey.Substring(8, 8));

            byte[] buffer = Convert.FromBase64String(cipherText);
            return DecryptTextFromMemory(buffer, tDESalg.Key, tDESalg.IV);
        }

        /// <summary>
        /// MD5加密，编码为UTF-8
        /// </summary>
        /// <param name="cipherText"></param>
        /// <returns></returns>
        public virtual string MD5Hash(string cipherText)
        {
            return MD5Hash(cipherText, Encoding.GetEncoding("UTF-8"));
        }

        /// <summary>
        /// MD5加密，编码为UTF-8
        /// </summary>
        /// <param name="cipherText">要加密的字符串</param>
        /// <param name="saltkey">密文</param>
        /// <returns></returns>
        public virtual string MD5Hash(string cipherText, string saltkey)
        {
            cipherText = string.Concat(cipherText, saltkey);
            return MD5Hash(cipherText, Encoding.GetEncoding("UTF-8"));
        }

        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="cipherText"></param>
        /// <param name="encode"></param>
        /// <returns></returns>
        public virtual string MD5Hash(string cipherText, Encoding encode)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] res = md5.ComputeHash(encode.GetBytes(cipherText), 0, cipherText.Length);
            char[] temp = new char[res.Length];
            Array.Copy(res, temp, res.Length);
            return new string(temp).ToLower();
        }

        #region "RsaEncrypt --- 使用 RSA 公钥加密"

        /// <summary>
        /// 使用 RSA 公钥加密
        /// </summary>
        /// <param name="message"></param>
        /// <param name="publicXml"></param>
        /// <returns></returns>
        public virtual string RsaEncrypt(string message, string publicXml = null)
        {
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                if (string.IsNullOrEmpty(publicXml))
                {
                    publicXml = "<RSAKeyValue><Modulus>tyKYdwjrUyGMXjxS6aQ3eTI8RuikMlsLuQlycvcZrhVGWKiMrtI3E0kzOtbIvYbebw5mWESP30phhCm/cKMCW4ERL2oZM1MD4+jpYb1WOYb7leTPoA+Vzac1qp9wRSNvkdcnD6hUYvhmZG+4EiovlNZHoJUtNFWEfw5aMqZR+Ok=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";
                }

                rsa.FromXmlString(publicXml);

                byte[] messageBytes = Encoding.UTF8.GetBytes(message);
                byte[] resultBytes = rsa.Encrypt(messageBytes, false);

                return Convert.ToBase64String(resultBytes);
            }
        }

        #endregion

        #region "RsaDecrypt --- 使用 RSA 私钥解密"

        /// <summary>
        /// 使用 RSA 私钥解密
        /// </summary>
        /// <param name="message"></param>
        /// <param name="privateXml"></param>
        /// <returns></returns>
        public virtual string RsaDecrypt(string message, string privateXml = null)
        {
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                if (string.IsNullOrEmpty(privateXml))
                {
                    privateXml = "<RSAKeyValue><Modulus>tyKYdwjrUyGMXjxS6aQ3eTI8RuikMlsLuQlycvcZrhVGWKiMrtI3E0kzOtbIvYbebw5mWESP30phhCm/cKMCW4ERL2oZM1MD4+jpYb1WOYb7leTPoA+Vzac1qp9wRSNvkdcnD6hUYvhmZG+4EiovlNZHoJUtNFWEfw5aMqZR+Ok=</Modulus><Exponent>AQAB</Exponent><P>29AepSPo0LxbRbKIWZ5SP3fLHIjehOnMoscvHXHtbAr1KZsphiAUXMaohdGBGewy5exa/Me3Ir69DshLUHfYTQ==</P><Q>1Ui2L9AAc5DQ0TziHDH6CmQf5kYy5h59nDr5x4aYgvyVNFCqbpjhBqTstS0+bEur8aErUNppTH+YjB4QccpxDQ==</Q><DP>hQHiCTs5XVUcRYhKSTArxIvQM2v+eZ6fXL/6Gm8dowreXlatQaOXrqvmvVKQNAdgpQ/n3p1ai4OvEorQR9i84Q==</DP><DQ>L3FXJVeNYieKa6CxYzgyuHEBL4XZ+Jo7sq7jtOBZuHla7yIqZyOWmpXBGaQQyKIkg0Eok3miBqQzWKevXMB9WQ==</DQ><InverseQ>yqM8j5FVsCLfFvXicyLqHfsqmQYgRbmMLlwIqiQE7L/WchE+V89bNpJ4RYFsSZBcNTAhhzBcxHV4cSI3Ve4CPw==</InverseQ><D>rfBX60c3a5/DmIWnIm5smdoS0i6INaOwALFuWK9FXsiqJe8An9LdqJ2v4MS7qPd+MPD2WAPWungFIugcAjlxNCiJdE+QOUS8Wt8+kZUHKQsTFtTNPq4gEp1XvnGC5sI5xE9q6QtwJqaHiWJEWq+NyPgFfoxRFjdykFAtx/6Yv2E=</D></RSAKeyValue>";
                }

                rsa.FromXmlString(privateXml);

                byte[] messageBytes = Convert.FromBase64String(message);
                byte[] resultBytes = rsa.Decrypt(messageBytes, false);

                return Encoding.UTF8.GetString(resultBytes);
            }
        }

        #endregion

        #endregion

        #region Utilities

        private byte[] EncryptTextToMemory(string data, byte[] key, byte[] iv)
        {
            using (var ms = new MemoryStream())
            {
                using (var cs = new CryptoStream(ms, new TripleDESCryptoServiceProvider().CreateEncryptor(key, iv), CryptoStreamMode.Write))
                {
                    byte[] toEncrypt = new UnicodeEncoding().GetBytes(data);
                    cs.Write(toEncrypt, 0, toEncrypt.Length);
                    cs.FlushFinalBlock();
                }

                return ms.ToArray();
            }
        }

        private string DecryptTextFromMemory(byte[] data, byte[] key, byte[] iv)
        {
            using (var ms = new MemoryStream(data))
            {
                using (var cs = new CryptoStream(ms, new TripleDESCryptoServiceProvider().CreateDecryptor(key, iv), CryptoStreamMode.Read))
                {
                    var sr = new StreamReader(cs, new UnicodeEncoding());
                    return sr.ReadLine();
                }
            }
        }

        #endregion
    }
}
