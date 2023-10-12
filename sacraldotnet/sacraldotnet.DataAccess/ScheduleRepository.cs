using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace sacraldotnet
{
    public class ReportConfigurationRepository : IReportConfigurationRepository
    {
        private readonly string connectionString;
        
        public ReportConfigurationRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public async Task<int> CreateAsync(ReportConfigurationModel reportConfig)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                await connection.OpenAsync();

                var query = "INSERT INTO ReportConfiguration (FileType, Destination, Frequency) " +
                            "VALUES (@FileType, @Destination, @Frequency) " +
                            "RETURNING Id";

                using (var command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FileType", reportConfig.FileType);
                    command.Parameters.AddWithValue("@Destination", reportConfig.Destination);
                    command.Parameters.AddWithValue("@Frequency", reportConfig.Frequency);

                    return (int) await command.ExecuteScalarAsync();
                }
            }
        }

        public async Task<ReportConfigurationModel> GetByIdAsync(int id)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                await connection.OpenAsync();

                var query = "SELECT Id, FileType, Destination, Frequency " +
                            "FROM ReportConfiguration " +
                            "WHERE Id = @Id";

                using (var command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            return new ReportConfigurationModel
                            {
                                Id = (int) reader["Id"],
                                FileType = (string) reader["FileType"],
                                Destination = (string) reader["Destination"],
                                Frequency = (string) reader["Frequency"]
                            };
                        }
                    }
                }
            }

            return null;
        }

        public async Task UpdateAsync(ReportConfigurationModel reportConfig)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                await connection.OpenAsync();

                var query = "UPDATE ReportConfiguration " +
                            "SET FileType = @FileType, Destination = @Destination, Frequency = @Frequency " +
                            "WHERE Id = @Id";

                using (var command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FileType", reportConfig.FileType);
                    command.Parameters.AddWithValue("@Destination", reportConfig.Destination);
                    command.Parameters.AddWithValue("@Frequency", reportConfig.Frequency);
                    command.Parameters.AddWithValue("@Id", reportConfig.Id);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task DeleteAsync(int id)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                await connection.OpenAsync();

                var query = "DELETE FROM ReportConfiguration " +
                            "WHERE Id = @Id";

                using (var command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }
    }

    public class VendorRepository
    {
        private readonly string connectionString;
        
        public VendorRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public async Task<VendorModel> GetByIdAsync(int id)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                await connection.OpenAsync();

                var query = "SELECT Id, Name, Sector " +
                            "FROM Vendor " +
                            "WHERE Id = @Id";

                using (var command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            return new VendorModel
                            {
                                Id = (int) reader["Id"],
                                Name = (string) reader["Name"],
                                Sector = (string) reader["Sector"]
                            };
                        }
                    }
                }
            }

            return null;
        }
    }

    public class FileRepository
    {
        private readonly string connectionString;
        
        public FileRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public async Task<int> CreateAsync(FileModel file)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                await connection.OpenAsync();

                var query = "INSERT INTO File (FileName, FileContent) " +
                            "VALUES (@FileName, @FileContent) " +
                            "RETURNING Id";

                using (var command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FileName", file.FileName);
                    command.Parameters.AddWithValue("@FileContent", file.FileContent);

                    return (int) await command.ExecuteScalarAsync();
                }
            }
        }

        public async Task<FileModel> GetByIdAsync(int id)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                await connection.OpenAsync();

                var query = "SELECT Id, FileName, FileContent " +
                            "FROM File " +
                            "WHERE Id = @Id";

                using (var command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            return new FileModel
                            {
                                Id = (int) reader["Id"],
                                FileName = (string) reader["FileName"],
                                FileContent = (string) reader["FileContent"]
                            };
                        }
                    }
                }
            }

            return null;
        }

        public async Task UpdateAsync(FileModel file)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                await connection.OpenAsync();

                var query = "UPDATE File " +
                            "SET FileName = @FileName, FileContent = @FileContent " +
                            "WHERE Id = @Id";

                using (var command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FileName", file.FileName);
                    command.Parameters.AddWithValue("@FileContent", file.FileContent);
                    command.Parameters.AddWithValue("@Id", file.Id);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task DeleteAsync(int id)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                await connection.OpenAsync();

                var query = "DELETE FROM File " +
                            "WHERE Id = @Id";

                using (var command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }
    }

    public class ScheduleRepository
    {
        private readonly string connectionString;
        
        public ScheduleRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public async Task<int> CreateAsync(ScheduleModel schedule)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                await connection.OpenAsync();

                var query = "INSERT INTO Schedule (ScheduleDateTime) " +
                            "VALUES (@ScheduleDateTime) " +
                            "RETURNING Id";

                using (var command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ScheduleDateTime", schedule.ScheduleDateTime);

                    return (int) await command.ExecuteScalarAsync();
                }
            }
        }

        public async Task<ScheduleModel> GetByIdAsync(int id)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                await connection.OpenAsync();

                var query = "SELECT Id, ScheduleDateTime " +
                            "FROM Schedule " +
                            "WHERE Id = @Id";

                using (var command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            return new ScheduleModel
                            {
                                Id = (int) reader["Id"],
                                ScheduleDateTime = (DateTime) reader["ScheduleDateTime"]
                            };
                        }
                    }
                }
            }

            return null;
        }

        public async Task UpdateAsync(ScheduleModel schedule)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                await connection.OpenAsync();

                var query = "UPDATE Schedule " +
                            "SET ScheduleDateTime = @ScheduleDateTime " +
                            "WHERE Id = @Id";

                using (var command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ScheduleDateTime", schedule.ScheduleDateTime);
                    command.Parameters.AddWithValue("@Id", schedule.Id);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task DeleteAsync(int id)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                await connection.OpenAsync();

                var query = "DELETE FROM Schedule " +
                            "WHERE Id = @Id";

                using (var command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }
    }
}