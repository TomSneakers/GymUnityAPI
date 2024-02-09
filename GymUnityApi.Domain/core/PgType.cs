using NpgsqlTypes;

namespace GymUnityApi.Domain.core;

public class PgType
{
    public object? Value { get; set; }
    public NpgsqlDbType Type { get; set; }

    public static PgType ToString(string value) => new() { Value = value, Type = NpgsqlDbType.Text };
    public static PgType ToGuid(Guid value) => new() { Value = value, Type = NpgsqlDbType.Uuid };
    public static PgType ToGuid(string value) => new() { Value = Guid.Parse(value), Type = NpgsqlDbType.Uuid };
    public static PgType ToInt(int value) => new(){Value = value, Type = NpgsqlDbType.Integer};
}