using System.Buffers.Text;
using System.Text;

namespace UniqueIdGenerator.Models;

internal static class Base64UrlTextEncoder
{
    private static string Base64ToBase64URL(string base64Text)
        => base64Text.Replace('+', '-').Replace('/', '_');

    private static string Base64URLToBase64(string base64UrlText)
        => base64UrlText.Replace('-', '+').Replace('_', '/');

    public static string Encode(byte[] data)
    {
        byte[] buffer = new byte[16];
        Base64.EncodeToUtf8(data, buffer, out var bytesConsumed, out var bytesWritten);
        return Base64ToBase64URL(UTF8Encoding.UTF8.GetString(buffer));
    }

    public static byte[] Decode(string text)
    {
        var bytes = UTF8Encoding.UTF8.GetBytes(Base64URLToBase64(text));
        byte[] buffer = new byte[16];
        Base64.DecodeFromUtf8(bytes, buffer, out var bytesConsumed, out var bytesWritten);
        return buffer;
    }
}
