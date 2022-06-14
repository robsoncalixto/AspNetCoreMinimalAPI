using Dapper;
using Oracle.ManagedDataAccess.Client;
using RC.Minimal.API.Oracle;
using System.Data;

namespace RC.Minimal.API.Repositories;
public class UserRepository : IUserRepository
{
    private IConfiguration configuration;

    public UserRepository(IConfiguration _configuration)
    {
        this.configuration = _configuration;
    }

    public object GetUser(string username)
    {
        object result = null;
        try
        {            
            var parameters = new OracleDynamicParameters();
            parameters.Add("p_username", OracleDbType.NVarchar2, ParameterDirection.Input, username);
            parameters.Add("p_user_cursor", OracleDbType.RefCursor, ParameterDirection.Output);

            var conn = this.GetConnection();            
            if (conn.State == ConnectionState.Closed) {
                conn.Open();
            }

            if(conn.State == ConnectionState.Open){

                var procedure = "getuser";

                result = SqlMapper.Query(conn, procedure, param: parameters, commandType: CommandType.StoredProcedure );
            }
        }
        catch (Exception) 
        {
            throw;
        }
        return result;
    }

    public object GetUsers()
    {
        object result = null;
        try{
            var parameters = new OracleDynamicParameters();
            parameters.Add("p_user_cursor", OracleDbType.RefCursor, ParameterDirection.ReturnValue);

            var conn = this.GetConnection();
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }

            if (conn.State == ConnectionState.Open)
            {
                var procedure = "getusers";
                result = SqlMapper.Query(conn, procedure, param: parameters, commandType: CommandType.StoredProcedure);
            }
        }
        catch (Exception) {
            throw;
        }

        return result;
    }

    public int CounterUsers() {

        int result = 0;
        try
        {
            var conn = this.GetConnection();
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }

            if (conn.State == ConnectionState.Open)
            {
                var sql = "SELECT count(1) FROM usuario u WHERE rownum <=10";
                result = conn.Query<int>(sql).Single();                 
            }
            return result;
        }
        catch (Exception)
        {
            throw;
        }

        return result;
    }

    public IDbConnection GetConnection() {
        var connectionString = configuration.GetSection("ConnectionStrings").GetSection("connectionTest").Value;
        var conn = new OracleConnection(connectionString);
        return conn;
    }
}

