namespace GymUnityApi.Domain.core;

public class PgConverter
{
    private readonly object[] _result;

    public PgConverter(object[] result)
    {
        _result = result;
    }

    public Guid ToGuid(int index) => Guid.Parse(ToString(index));

    public string ToString(int index) => _result[index].ToString() ?? string.Empty;

    public int ToInt(int index) => Convert.ToInt32(_result[index]);
    
    public int? ToNullableInt(int index) => _result[index] is DBNull ? null : ToInt(index);
}