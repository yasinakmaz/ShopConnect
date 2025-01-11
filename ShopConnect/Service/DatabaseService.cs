using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopConnect.Service
{
    public class DatabaseService
    {
        private readonly string connectionString = "Data Source=.;Initial Catalog=VEGADB;User ID=sa;Password=123456a.A;Trust Server Certificate=True";

        public async Task<List<string>> SearchItemsAsync(string query)
        {
            var results = new List<string>();

            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                var command = new SqlCommand("SELECT FIRMAADI FROM F0103TBLCARI WHERE FIRMAADI LIKE @Query", connection);
                command.Parameters.AddWithValue("@Query", $"%{query}%");

                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        results.Add(reader.GetString(0));
                    }
                }
            }

            return results;
        }
    }
}
