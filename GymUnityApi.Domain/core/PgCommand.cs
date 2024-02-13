using Npgsql;

namespace GymUnityApi.Domain.core;

public class PgCommand
{
    private readonly string _connectionString =
        "Host=gymunity-postgres;Port=5432;Database=postgres;Username=postgres;Password=postgres";

    public IEnumerable<PgConverter> ExecuteDataTable(string statement, params PgType[] parameters)
    {
        var conn = new NpgsqlConnection(_connectionString);
        conn.Open();
        var cmd = new NpgsqlCommand(statement, conn);
        foreach (var parameter in parameters)
        {
            cmd.Parameters.Add(new NpgsqlParameter() { Value = parameter.Value, NpgsqlDbType = parameter.Type });
        }

        var reader = cmd.ExecuteReader();
        return ExtractReader(reader);
    }

    private static IEnumerable<PgConverter> ExtractReader(NpgsqlDataReader reader)
    {
        var result = new List<PgConverter>();
        while (reader.Read())
        {
            var rowResult = new object[reader.FieldCount];
            for (int i = 0; i < reader.FieldCount; i++)
            {
                rowResult[i] = reader[i];
            }

            result.Add(new PgConverter(rowResult));
        }

        reader.Close();
        return result;
    }

    public void ExecuteNonQuery(string statement, params PgType[] parameters)
    {
        var conn = new NpgsqlConnection(_connectionString);
        conn.Open();
        var cmd = new NpgsqlCommand(statement, conn);
        foreach (var parameter in parameters)
        {
            cmd.Parameters.Add(new NpgsqlParameter() { Value = parameter.Value, NpgsqlDbType = parameter.Type });
        }

        cmd.ExecuteNonQuery();
        conn.Close();
    }
}