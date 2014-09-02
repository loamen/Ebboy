using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebboy.Services.Security
{
    public interface IEncryptionService
    {
        /// <summary>
        /// Create salt key
        /// </summary>
        /// <param name="size">Key size</param>
        /// <returns>Salt key</returns>
        string CreateSaltKey(int size);

        /// <summary>
        /// Create a password hash
        /// </summary>
        /// <param name="password">{assword</param>
        /// <param name="saltkey">Salk key</param>
        /// <param name="passwordFormat">Password format (hash algorithm)</param>
        /// <returns>Password hash</returns>
        string CreatePasswordHash(string password, string saltkey, string passwordFormat = "SHA1");

        /// <summary>
        /// SHA1加密
        /// </summary>
        /// <param name="plainText">明文</param>
        /// <returns></returns>
        string SHA1(string plainText);

        /// <summary>
        /// Encrypt text
        /// </summary>
        /// <param name="plainText">Text to encrypt</param>
        /// <param name="encryptionPrivateKey">Encryption private key</param>
        /// <returns>Encrypted text</returns>
        string EncryptText(string plainText, string encryptionPrivateKey = "");

        /// <summary>
        /// Decrypt text
        /// </summary>
        /// <param name="cipherText">Text to decrypt</param>
        /// <param name="encryptionPrivateKey">Encryption private key</param>
        /// <returns>Decrypted text</returns>
        string DecryptText(string cipherText, string encryptionPrivateKey = "");

        /// <summary>
        /// MD5加密，编码为UTF-8
        /// </summary>
        /// <param name="cipherText"></param>
        /// <returns></returns>
        string MD5Hash(string cipherText);

        /// <summary>
        /// MD5加密，编码为UTF-8
        /// </summary>
        /// <param name="cipherText">要加密的字符串</param>
        /// <param name="saltkey">密文</param>
        /// <returns></returns>
        string MD5Hash(string cipherText, string saltkey);

        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="cipherText"></param>
        /// <param name="encode"></param>
        /// <returns></returns>
        string MD5Hash(string cipherText, Encoding encode);

        /// <summary>
        /// RSA解密
        /// </summary>
        /// <param name="message"></param>
        /// <param name="privateXml"></param>
        /// <returns></returns>
        string RsaDecrypt(string message, string privateXml = null);

        /// <summary>
        /// RSA加密
        /// </summary>
        /// <param name="message"></param>
        /// <param name="publicXml"></param>
        /// <returns></returns>
        string RsaEncrypt(string message, string publicXml = null);


    }
}
