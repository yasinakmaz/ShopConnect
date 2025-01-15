using ShopConnect.Models;

namespace ShopConnect.Service
{
    public class DatabaseService
    {
        private readonly string connectionString = "Data Source=.;Initial Catalog=ARCTOS;User ID=sa;Password=123456a.A;Trust Server Certificate=True";

        public async Task<List<Cari>> SearchItemsAsync(string query)
        {
            var results = new List<Cari>();

            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                var sql = "SELECT FIRMAKODU, FIRMAADI, YETKILI, VERGIDAIRESI, ISKONTO, TELEFON1, KOD1 " +
                          "FROM TBLCARI WHERE FIRMAADI LIKE @Query";

                using (var command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Query", $"%{query}%");

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            results.Add(new Cari
                            {
                                FirmaKodu = reader.GetString(0),
                                FirmaAdi = reader.GetString(1),
                                Yetkili = reader.GetString(2),
                                VergiDairesi = reader.GetString(3),
                                Iskonto = reader.GetDecimal(4),
                                Telefon1 = reader.GetString(5),
                                Kod1 = reader.GetString(6)
                            });
                        }
                    }
                }
            }

            return results;
        }
    }
}
