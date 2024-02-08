using Npgsql;
using NpgsqlTypes;

namespace GymUnityApi.Domain.core;

public class PgCommand
{
    private readonly string _connectionString = "Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=postgres";
    
    public IEnumerable<PgConverter> ExecuteDataTable(string statement, params PgType[] parameters)
    {
        var conn = new NpgsqlConnection(_connectionString);
        conn.Open();
        var cmd = new NpgsqlCommand(statement, conn);
        foreach (var parameter in parameters)
        {
            cmd.Parameters.Add(new NpgsqlParameter(){Value = parameter.Value, NpgsqlDbType = parameter.Type});
        }

        var reader = cmd.ExecuteReader();
        var result = new object[][reader.Rows];
        for (int j = 0; j < Convert.ToInt32(reader.Rows); j++)
        {
            var rowResult = new object[reader.FieldCount];
            for (int i = 0; i < reader.FieldCount; i++)
            {
                rowResult[i] = reader.GetValue(i);
            }
        }

        conn.Close();
        return result.Select(row => new PgConverter(row));
    }

    public void ExecuteNonQuery(string statement, params PgType[] parameters)
    {
        var conn = new NpgsqlConnection(_connectionString);
        conn.Open();
        var cmd = new NpgsqlCommand(statement, conn);
        foreach (var parameter in parameters)
        {
            cmd.Parameters.Add(new NpgsqlParameter(){Value = parameter.Value, NpgsqlDbType = parameter.Type});
        }

        cmd.ExecuteNonQuery();
        conn.Close();
    }
}

public class PgType
{
    public object? Value { get; set; }
    public NpgsqlDbType Type { get; set; }

    public static PgType String(string value)
    {
        return new PgType {Value = value, Type = NpgsqlDbType.Text};
    }

    public static PgType Guid(Guid value) => new(){Value = value, Type = NpgsqlDbType.Uuid};
}

public class PgConverter
{
    private readonly object[] _result;

    public PgConverter(object[] result)
    {
        _result = result;
    }
    
    public Guid ToGuid(int index) => new Guid(_result[index].ToString() ?? throw new InvalidOperationException());
    public string ToString(int index) => _result[index].ToString() ?? string.Empty;
    public int ToInt(int index) => Convert.ToInt32(_result[index]);
}