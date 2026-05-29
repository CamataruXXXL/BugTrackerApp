using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace BugTrackerApp
{
    public static class DatabaseHelper
    {
        private static string connectionString = "Data Source=bugs.db;Version=3;";

        public static void InitializeDatabase()
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string createTableQuery = @"
                CREATE TABLE IF NOT EXISTS Bugs (
                    Id INTEGER PRIMARY KEY,
                    Title TEXT,
                    Description TEXT,
                    Severity TEXT,
                    Status TEXT,
                    CreatedAt TEXT
                )";

                SQLiteCommand command = new SQLiteCommand(createTableQuery, connection);
                command.ExecuteNonQuery();
            }
        }

        public static void AddBug(Bug bug)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string insertQuery = @"
                INSERT INTO Bugs (Id, Title, Description, Severity, Status, CreatedAt)
                VALUES (@Id, @Title, @Description, @Severity, @Status, @CreatedAt)";

                SQLiteCommand command = new SQLiteCommand(insertQuery, connection);

                command.Parameters.AddWithValue("@Id", bug.Id);
                command.Parameters.AddWithValue("@Title", bug.Title);
                command.Parameters.AddWithValue("@Description", bug.Description);
                command.Parameters.AddWithValue("@Severity", bug.Severity);
                command.Parameters.AddWithValue("@Status", bug.Status);
                command.Parameters.AddWithValue("@CreatedAt", bug.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss"));

                command.ExecuteNonQuery();
            }
        }


        public static List<Bug> LoadBugs()
        {
            List<Bug> bugs = new List<Bug>();

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string selectQuery = "SELECT * FROM Bugs";

                SQLiteCommand command = new SQLiteCommand(selectQuery, connection);
                SQLiteDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Bug bug = new Bug()
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Title = reader["Title"].ToString(),
                        Description = reader["Description"].ToString(),
                        Severity = reader["Severity"].ToString(),
                        Status = reader["Status"].ToString(),
                        CreatedAt = DateTime.Parse(reader["CreatedAt"].ToString())
                    };

                    bugs.Add(bug);
                }
            }

            return bugs;
        }

        public static void UpdateBugStatus(Bug bug)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string query = "UPDATE Bugs SET Status = @Status WHERE Id = @Id";

                SQLiteCommand command = new SQLiteCommand(query, connection);

                command.Parameters.AddWithValue("@Status", bug.Status);
                command.Parameters.AddWithValue("@Id", bug.Id);

                command.ExecuteNonQuery();
            }
        }
        public static void UpdateBug(Bug bug)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string query = @"
        UPDATE Bugs 
        SET Title = @Title,
            Description = @Description,
            Severity = @Severity,
            Status = @Status
        WHERE Id = @Id";

                SQLiteCommand command = new SQLiteCommand(query, connection);

                command.Parameters.AddWithValue("@Title", bug.Title);
                command.Parameters.AddWithValue("@Description", bug.Description);
                command.Parameters.AddWithValue("@Severity", bug.Severity);
                command.Parameters.AddWithValue("@Status", bug.Status);
                command.Parameters.AddWithValue("@Id", bug.Id);

                command.ExecuteNonQuery(); 
            }
        }
        public static void DeleteBug(int id)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string query = "DELETE FROM Bugs WHERE Id = @Id";

                SQLiteCommand command = new SQLiteCommand(query, connection);

                command.Parameters.AddWithValue("@Id", id);

                command.ExecuteNonQuery();
            }
        }
    }
}
    
