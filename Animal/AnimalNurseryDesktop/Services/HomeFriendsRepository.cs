using AnimalNursery.Models;
using AnimalNursery.Models.Animals;
using System.Data.SQLite;

namespace AnimalNursery.Services
{
    public class HomeFriendsRepository: IHomeFriendsRepository
    {
        private const string connectionString = "Data Source = Nursery.db; Version = 3; Pooling = true; Max Pool Size = 100;";

        public int Create(HomeFriend item)
        {
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            connection.Open();
            SQLiteCommand command = new SQLiteCommand(connection);
            command.CommandText = "INSERT INTO humanFriends(Name, Type, Command, Birthday) VALUES(@Name, @Type, @Command, @Birthday)";
            command.Parameters.AddWithValue("@Name", item.Name);
            command.Parameters.AddWithValue("@Type", item.Type);
            command.Parameters.AddWithValue("@Command", string.Join(", ", item.Commands));
            command.Parameters.AddWithValue("@Birthday", item.Birthday.Ticks);
            command.Prepare();
            int res = command.ExecuteNonQuery();
            connection.Close();
            return res;
        }

        public int Delete(int id)
        {
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            connection.Open();
            SQLiteCommand command = new SQLiteCommand(connection);
            command.CommandText = "DELETE FROM humanFriends WHERE Id=@Id";
            command.Parameters.AddWithValue("@Id", id);
            command.Prepare();
            int res = command.ExecuteNonQuery();
            connection.Close();
            return res;
        }

        public IList<HomeFriend> GetAll()
        {
            List<HomeFriend> list = new List<HomeFriend>();
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            connection.Open();
            SQLiteCommand command = new SQLiteCommand(connection);
            command.CommandText = "SELECT * FROM humanFriends";
            SQLiteDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
               
                HomeFriend homeFriend = CreateAnimal.create(reader.GetString(2));
                homeFriend.Id = reader.GetInt32(0);
                homeFriend.Name = reader.GetString(1);
                homeFriend.Commands = reader.GetString(3).Split(", ").ToList();
                homeFriend.Birthday = new DateTime(reader.GetInt64(4));

                list.Add(homeFriend);
            }

            connection.Close();
            return list;
        }

        public HomeFriend GetById(int id)
        {
            List<HomeFriend> list = new List<HomeFriend>();
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            connection.Open();
            SQLiteCommand command = new SQLiteCommand(connection);
            command.CommandText = "SELECT * FROM humanFriends WHERE Id = @Id";
            command.Parameters.AddWithValue("@Id", id);
            command.Prepare();
            SQLiteDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {

                HomeFriend homeFriend = CreateAnimal.create(reader.GetString(2));
                homeFriend.Id = reader.GetInt32(0);
                homeFriend.Name = reader.GetString(1);
                homeFriend.Commands = reader.GetString(3).Split(", ").ToList();
                homeFriend.Birthday = new DateTime(reader.GetInt64(4));

                connection.Close();
                return homeFriend;
            }
            else
            {
                connection.Close();
                return null;
            }
        }

        public int Update(HomeFriend item)
        {

            SQLiteConnection connection = new SQLiteConnection(connectionString);
            connection.Open();
            SQLiteCommand command = new SQLiteCommand(connection);
            command.CommandText = "UPDATE humanFriends SET Name = @Name, Type = @Type, Command = @Command, Birthday = @Birthday WHERE Id = @Id";
            command.Parameters.AddWithValue("@Id", item.Id);
            command.Parameters.AddWithValue("@Name", item.Name);
            command.Parameters.AddWithValue("@Type", item.Type);
            command.Parameters.AddWithValue("@Command", string.Join(", ", item.Commands));
            command.Parameters.AddWithValue("@Birthday", item.Birthday.Ticks);
            command.Prepare();
            int res = command.ExecuteNonQuery();
            connection.Close();
            return res;
        }
    } 
}