using System.Text;
using System.Text.Json;

namespace NJUPT_AspNetCore_Exp1;

public readonly record struct Party(long Id, string Topic, string Location, DateTime DateTime)
{
    private const string path = "./parties.json";
    private const string initial = "[]";
    public static long NewId =>
        (
            (DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() - System.DateTime.UnixEpoch.Millisecond)
            << 12 + 5
        )
        | (1 << 12)
        | (0);

    public static Party[] Values =>
        JsonSerializer.Deserialize(EnsureAndRead(), AppJsonSerializerContext.Default.PartyArray)
        ?? [];

    public static void Write(Party[] parties) =>
        EnsureAndWrite(
            JsonSerializer.Serialize(parties, AppJsonSerializerContext.Default.PartyArray)
        );

    private static string EnsureAndRead()
    {
        if (File.Exists(path))
        {
            return File.ReadAllText(path);
        }
        using var stream = File.Create(path);
        stream.Write(Encoding.UTF8.GetBytes(initial));
        return initial;
    }

    private static void EnsureAndWrite(string content)
    {
        if (File.Exists(path))
        {
            File.WriteAllText(path, content);
        }
        using var stream = File.Create(path);
        stream.Write(Encoding.UTF8.GetBytes(content));
    }
}

public static class PartiesExtensions
{
    public static Party? Find(this Party[] parties, long id)
    {
        int index = Array.FindIndex(parties, party => party.Id == id);
        return index <= -1 ? null : parties[index];
    }
}
