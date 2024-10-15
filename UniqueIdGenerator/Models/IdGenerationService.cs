using UUIDNext;

namespace UniqueIdGenerator.Models;

public sealed class IdGenerationService
{
    public static Guid GenerateId() => Uuid.NewDatabaseFriendly(Database.PostgreSql);

    public static string ToControllerId(Guid id) => Base64UrlTextEncoder.Encode(id.ToByteArray(true));

    public static Guid FromControllerId(string id) => new Guid(Base64UrlTextEncoder.Decode(id), true);
}
