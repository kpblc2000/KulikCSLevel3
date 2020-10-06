using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using WpfMailSender.Interfaces;

namespace WpfMailSender.Services
{
    public class Rfc2898Encryptor : IEncryptorService
    {

        private static readonly byte[] SALT = {
            0x26, 0xdc, 0xff, 0x00,
            0x4d, 0xde, 0x0a, 0x07,
            0xad, 0xfe, 0x7a, 0xee,
            0xc5, 0x09, 0x23, 0x3a };

        private static ICryptoTransform GetAlgorythm(string Password)
        {
            var pdb = new Rfc2898DeriveBytes(Password, SALT);
            var algo = Rijndael.Create();
            algo.Key = pdb.GetBytes(32);
            algo.IV = pdb.GetBytes(16);
            return algo.CreateEncryptor();
        }

        private static ICryptoTransform GetInverseAlgorythm(string Password)
        {
            var pdb = new Rfc2898DeriveBytes(Password, SALT);
            var algo = Rijndael.Create();
            algo.Key = pdb.GetBytes(32);
            algo.IV = pdb.GetBytes(16);
            return algo.CreateDecryptor();
        }

        public Encoding Encoding { get; set; } = Encoding.UTF8;

        public string Encrypt(string Str, string Password)
        {
            var encoding = Encoding ?? Encoding.UTF8;
            var bytes = encoding.GetBytes(Str);
            byte[] cr = Encrypt(bytes, Password);
            return Convert.ToBase64String(cr);
        }

        public byte[] Encrypt(byte[] data, string Password)
        {
            var algo = GetAlgorythm(Password);
            using (var stream = new MemoryStream())
            {
                using (var cr_str = new CryptoStream(stream, algo, CryptoStreamMode.Write))
                {
                    cr_str.Write(data, 0, data.Length);
                    cr_str.FlushFinalBlock();
                    return stream.ToArray();
                }
            }

        }

        public string Decrypt(string Str, string Password)
        {
            var encoding = Encoding ?? Encoding.UTF8;
            var bytes = Convert.FromBase64String(Str);
            byte[] cr = Decrypt(bytes, Password);
            return encoding.GetString(cr);
        }

        public byte[] Decrypt(byte[] data, string Password)
        {
            var algo = GetInverseAlgorythm(Password);
            using (var stream = new MemoryStream())
            {
                using (var cr_str = new CryptoStream(stream, algo, CryptoStreamMode.Write))
                {
                    cr_str.Write(data, 0, data.Length);
                    cr_str.FlushFinalBlock();
                    return stream.ToArray();
                }
            }
        }


    }
}
