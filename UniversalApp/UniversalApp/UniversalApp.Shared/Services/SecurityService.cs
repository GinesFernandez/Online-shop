using System;
using System.Text;
using Windows.Security.Cryptography;
using Windows.Security.Cryptography.Core;
using Windows.Storage.Streams; 

namespace UniversalApp.Services
{
    public class SecurityService
    {
        private CryptographicKey _key;
        private IBuffer _vector;
        //private ICryptoTransform encryptor, decryptor;
        //private UTF8Encoding encoder;

        public SecurityService(string password = "a1swyvWdy5763io-kme78")
        {
            _vector = CreateInitializationVector(password);
            _key = CreateKey(password);
        }

        //public string Encrypt(string unencrypted)
        //{
        //    return Convert.ToBase64String(Encrypt(encoder.GetBytes(unencrypted)));
        //}

        /// <summary> 
        /// Encrypt a string 
        /// </summary> 
        /// <param name="input">String to encrypt</param> 
        /// <param name="password">Password to use for encryption</param> 
        /// <returns>Encrypted string</returns> 
        public string Encrypt(string input)
        {
            if (string.IsNullOrEmpty(input))
                throw new ArgumentException("input cannot be empty");

            var encryptedBuffer = CryptographicEngine.Encrypt(_key, CryptographicBuffer.ConvertStringToBinary(input, BinaryStringEncoding.Utf8), _vector);
            return CryptographicBuffer.EncodeToBase64String(encryptedBuffer);
        }

        /// <summary> 
        /// Decrypt a string previously ecnrypted with Encrypt method and the same password 
        /// </summary> 
        /// <param name="input">String to decrypt</param> 
        /// <param name="password">Password to use for decryption</param> 
        /// <returns>Decrypted string</returns> 
        public string Decrypt(string input)
        {
            if (string.IsNullOrEmpty(input))
                throw new ArgumentException("input cannot be empty");
           
            var decryptedBuffer = CryptographicEngine.Decrypt(_key, CryptographicBuffer.DecodeFromBase64String(input), _vector);
            return CryptographicBuffer.ConvertBinaryToString(
             BinaryStringEncoding.Utf8, decryptedBuffer);
        } 

        /// <summary> 
        /// Create initialization vector IV 
        /// </summary> 
        /// <param name="password">Password is used for random vector generation</param> 
        /// <returns>Vector</returns> 
        private static IBuffer CreateInitializationVector(string password)
        {
            var provider = SymmetricKeyAlgorithmProvider.OpenAlgorithm("AES_CBC_PKCS7");
            var newPassword = password;

            // make sure we satify minimum length requirements 
            while (newPassword.Length < provider.BlockLength)
            {
                newPassword = newPassword + password;
            }
            //create vecotr 
            var iv = CryptographicBuffer.CreateFromByteArray(UTF8Encoding.UTF8.GetBytes(newPassword));
            return iv;
        }
        /// <summary> 
        /// Create encryption key 
        /// </summary> 
        /// <param name="password">Password is used for random key generation</param> 
        /// <returns></returns> 
        private static CryptographicKey CreateKey(string password)
        {
            var provider = SymmetricKeyAlgorithmProvider.OpenAlgorithm("AES_CBC_PKCS7");
            var newPassword = password;

            // make sure we satify minimum length requirements 
            while (newPassword.Length < provider.BlockLength)
            {
                newPassword = newPassword + password;
            }

            var buffer = CryptographicBuffer.ConvertStringToBinary(newPassword, BinaryStringEncoding.Utf8);
            buffer.Length = provider.BlockLength;
            var key = provider.CreateSymmetricKey(buffer);
            return key;
        }
    }
}
