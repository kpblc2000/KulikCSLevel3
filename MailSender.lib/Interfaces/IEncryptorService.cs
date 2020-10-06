namespace WpfMailSender.Interfaces
{
    public interface IEncryptorService
    {
        string Encrypt(string Str, string Password);

        string Decrypt(string Str, string Password);

        byte[] Encrypt(byte[] data, string Password);

        byte[] Decrypt(byte[] data, string Password);

    }
}
