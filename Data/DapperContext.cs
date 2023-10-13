using System.Data;
using System.Data.SqlClient;
using Teste_TGS.Interfaces;

public class DapperContext : IDapperContext
{
    private readonly IConfiguration _iConfiguration;
    private readonly string _connString;
    public DapperContext(IConfiguration iConfiguration)
    {
        _iConfiguration = iConfiguration;
        _connString = _iConfiguration.GetConnectionString("connMSSQL");
    }
    public IDbConnection CreateConnection() => new SqlConnection(_connString);
}