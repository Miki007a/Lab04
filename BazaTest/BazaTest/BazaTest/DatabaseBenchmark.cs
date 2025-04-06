namespace BazaTest
{
    using BazaTest.Client.Models;
    using BazaTest.Data;
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Running;
    using Dapper;
    using Microsoft.EntityFrameworkCore;
    using Oracle.ManagedDataAccess.Client;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Threading.Tasks;

    public class DatabaseBenchmark
    {


        private  ApplicationDbContext? _context;
        private  string? _connectionString;


        [GlobalSetup]
        public void Setup()
        {
            // Manually configure the context if you're not using DI
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
        .UseOracle("Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=79.125.194.228)(PORT=15007))(CONNECT_DATA=(SERVICE_NAME=demo)));User Id=edos_tr;Password=adminedosdb;") // Replace with actual values
        .Options;

            _context = new ApplicationDbContext(options);
            _connectionString = _context.Database.GetConnectionString();
        }
        // Benchmarking Entity Framework Core
        [Benchmark]
        public async Task<List<Dnevnik_Term>> FetchWithEntityFrameworkAsync()
        {
            try
            {
                if (_context != null)
                {
                    return await _context.Database
                                          .SqlQuery<Dnevnik_Term>($"SELECT * FROM DNEVNIK_TERM")
                                          .ToListAsync();
                }
                else
                {
                    // Handle the null case (maybe return an error or empty list)
                    return new List<Dnevnik_Term>();
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Benchmarking Dapper
        [Benchmark]
        public async Task<List<Dnevnik_Term>> FetchWithDapperAsync()
        {
            try
            {
                using IDbConnection dbConnection = new OracleConnection(_connectionString);
                dbConnection.Open();

                var results = await dbConnection.QueryAsync<Dnevnik_Term>("SELECT * FROM DNEVNIK_TERM");
                return results.ToList();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Benchmarking Oracle Managed Client
        [Benchmark]
        public async Task<List<Dnevnik_Term>> FetchWithOracleClientAsync()
        {
            try
            {
                var results = new List<Dnevnik_Term>();

                using (OracleConnection connection = new OracleConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    using (OracleCommand command = new OracleCommand("SELECT * FROM DNEVNIK_TERM", connection))
                    {
                        using (OracleDataReader reader = (OracleDataReader)await command.ExecuteReaderAsync())
                        {

                            //var dnevnikTerm = new Dnevnik_Term
                            while (await reader.ReadAsync())
                            {
                                var dnevnikTerm = new Dnevnik_Term
                                {
                                    Id = reader.IsDBNull(reader.GetOrdinal("DT_ID")) ? 0 : reader.GetInt32(reader.GetOrdinal("DT_ID")),
                                    DtDate = reader.IsDBNull(reader.GetOrdinal("DT_DATE")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("DT_DATE")),
                                    DtVFirmaId = reader.IsDBNull(reader.GetOrdinal("DT_V_FIRMA_ID")) ? (string?)null : reader.GetString(reader.GetOrdinal("DT_V_FIRMA_ID")),
                                    DtVCardId = reader.IsDBNull(reader.GetOrdinal("DT_V_CARD_ID")) ? null : reader.GetString(reader.GetOrdinal("DT_V_CARD_ID")),
                                    DtTId = reader.IsDBNull(reader.GetOrdinal("DT_T_ID")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("DT_T_ID")),
                                    DtTTypeId = reader.IsDBNull(reader.GetOrdinal("DT_T_TYPE_ID")) ? (byte?)null : reader.GetByte(reader.GetOrdinal("DT_T_TYPE_ID")),
                                    DtInOut = reader.IsDBNull(reader.GetOrdinal("DT_IN_OUT")) ? null : reader.GetString(reader.GetOrdinal("DT_IN_OUT")),
                                    DtNastanId = reader.IsDBNull(reader.GetOrdinal("DT_NASTAN_ID")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("DT_NASTAN_ID")),
                                    DtNastanIme = reader.IsDBNull(reader.GetOrdinal("DT_NASTAN_IME")) ? null : reader.GetString(reader.GetOrdinal("DT_NASTAN_IME")),
                                    DtFId = reader.IsDBNull(reader.GetOrdinal("DT_F_ID")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("DT_F_ID")),
                                    DtStatus = reader.IsDBNull(reader.GetOrdinal("DT_STATUS")) ? (byte?)null : reader.GetByte(reader.GetOrdinal("DT_STATUS")),
                                    DtStatusDesc = reader.IsDBNull(reader.GetOrdinal("DT_STATUS_DESC")) ? null : reader.GetString(reader.GetOrdinal("DT_STATUS_DESC")),
                                    DtDateRead = reader.IsDBNull(reader.GetOrdinal("DT_DATE_READ")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("DT_DATE_READ")),
                                    DtType = reader.IsDBNull(reader.GetOrdinal("DT_TYPE")) ? null : reader.GetString(reader.GetOrdinal("DT_TYPE")),
                                    DtUserName = reader.IsDBNull(reader.GetOrdinal("DT_USER_NAME")) ? null : reader.GetString(reader.GetOrdinal("DT_USER_NAME")),
                                    DtVId = reader.IsDBNull(reader.GetOrdinal("DT_V_ID")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("DT_V_ID")),
                                    DtVRabVremeId = reader.IsDBNull(reader.GetOrdinal("DT_V_RAB_VREME_ID")) ? (short?)null : reader.GetInt16(reader.GetOrdinal("DT_V_RAB_VREME_ID")),
                                    DtTIp = reader.IsDBNull(reader.GetOrdinal("DT_T_IP")) ? null : reader.GetString(reader.GetOrdinal("DT_T_IP")),
                                    DtVRabVremeTipId = reader.IsDBNull(reader.GetOrdinal("DT_V_RAB_VREME_TIP_ID")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("DT_V_RAB_VREME_TIP_ID")),
                                    DtVRabVremeSameDay = reader.IsDBNull(reader.GetOrdinal("DT_V_RAB_VREME_SAME_DAY")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("DT_V_RAB_VREME_SAME_DAY")),
                                    DtUserId = reader.IsDBNull(reader.GetOrdinal("DT_USER_ID")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("DT_USER_ID")),
                                    DtUserDate = reader.IsDBNull(reader.GetOrdinal("DT_USER_DATE")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("DT_USER_DATE")),
                                    DtUserApp = reader.IsDBNull(reader.GetOrdinal("DT_USER_APP")) ? null : reader.GetString(reader.GetOrdinal("DT_USER_APP")),
                                    DtUserIp = reader.IsDBNull(reader.GetOrdinal("DT_USER_IP")) ? null : reader.GetString(reader.GetOrdinal("DT_USER_IP")),
                                    DtUserStation = reader.IsDBNull(reader.GetOrdinal("DT_USER_STATION")) ? null : reader.GetString(reader.GetOrdinal("DT_USER_STATION")),
                                    DtUserAction = reader.IsDBNull(reader.GetOrdinal("DT_USER_ACTION")) ? null : reader.GetString(reader.GetOrdinal("DT_USER_ACTION")),
                                    DtFIdSystem = reader.IsDBNull(reader.GetOrdinal("DT_F_ID_SYSTEM")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("DT_F_ID_SYSTEM")),
                                    DtDoorId = reader.IsDBNull(reader.GetOrdinal("DT_DOOR_ID")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("DT_DOOR_ID"))
                                };

                                results.Add(dnevnikTerm);
                            }
                        }
                    }
                }

                return results;
            }
            catch (Exception ex)
            {
               throw new Exception(ex.Message, ex);
            }
        }

    }
}