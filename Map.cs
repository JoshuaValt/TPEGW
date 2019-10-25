using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Collections.ObjectModel;
using System.Text;

namespace TPEGW
{
    class Map
    {


        private string id;
        private string name;
        private int width;
        private bool loadedFromDatabase;
        private int height;

        public string Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public int Width { get => width; set => width = value; }
        public int Height { get => height; set => height = value; }


        public Map()
        {

            Id = Guid.NewGuid().ToString();
            Name = "";
            Width = 0;
            Height = 0;
            loadedFromDatabase = false;

        }

        public void Save()
        {


            string sqlStatement = "";

            if (loadedFromDatabase == true)
            {
                sqlStatement = $"Update map set name = {name}, width = {width},height = '{height}' where id = '{Id}'";

            }
            else
            {

                sqlStatement = $"insert into map (id,name,width,height) Values ('{Id}','{name}', {width}, {height})";

            }

            SQLiteConnection connection = new SQLiteConnection(@"Data Source=C:\databases\tpegw-game.db; Version=3;");
            connection.Open();

            SQLiteCommand command = new SQLiteCommand(sqlStatement, connection);

            command.ExecuteNonQuery();

            connection.Close();
            command.Dispose();
            connection.Dispose();
        }


        public void Load(string idToLoad)
        {
            loadedFromDatabase = true;
            SQLiteConnection connection = new SQLiteConnection(@"Data Source=C:\databases\tpegw-game.db; Version=3;");
            connection.Open();

            SQLiteCommand command = new SQLiteCommand($"select * from map where id = '{idToLoad}'", connection);


            SQLiteDataReader dataReader = command.ExecuteReader();
            dataReader.Read();
            Id = dataReader["id"].ToString();
            name = dataReader["name"].ToString();
            width = int.Parse(dataReader["width"].ToString());
            height = int.Parse(dataReader["height"].ToString());
           


            dataReader.Close();
            connection.Close();
            command.Dispose();
            connection.Dispose();
        }



    }
}
