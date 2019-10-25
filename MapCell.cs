using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SQLite;
using System.Text;

namespace TPEGW
{
    public class MapCell
    {
        private string id;
        private int row;
        private int column;
        private string mapId;
        private string cellType;
        private string cellValue;
        private string extended;
        private bool loadedFromDatabase;

        public string Id { get => id; set => id = value; }
        public int Row { get => row; set => row = value; }
        public int Column { get => column; set => column = value; }
        public string MapId { get => mapId; set => mapId = value; }
        public string CellType { get => cellType; set => cellType = value; }
        public string CellValue { get => cellValue; set => cellValue = value; }
        public string Extended { get => extended; set => extended = value; }

        public MapCell()
        {
            Id = Guid.NewGuid().ToString();
            row = 0;
            column = 0;
            MapId = "";
            CellType = "";
            CellValue = "";
            Extended = "";
            loadedFromDatabase = false;

        }

        public void Save()
        {


            string sqlStatement = "";

            if (loadedFromDatabase == true)
            {
                sqlStatement = $"Update map_cell set row = {Row}, column = {Column},map_id = '{MapId}', cell_type = '{CellType}', cell_value = '{CellValue}', extended = '{Extended}' where id = '{Id}'";

            }
            else
            {

                sqlStatement = $"insert into map_cell (id,row,column,map_id,cell_type, cell_value,extended) Values ('{Id}',{Row}, {Column}, '{MapId}', '{CellType}', '{CellValue}', '{Extended}')";

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

            SQLiteCommand command = new SQLiteCommand($"select * from map_cell where id = '{idToLoad}'", connection);


            SQLiteDataReader dataReader = command.ExecuteReader();
            dataReader.Read();
            Id = dataReader["id"].ToString();
            Row = int.Parse(dataReader["row"].ToString());
            Column = int.Parse(dataReader["column"].ToString());
            MapId = dataReader["map_id"].ToString();
            CellType = dataReader["cell_type"].ToString();
            CellValue = dataReader["cell_value"].ToString();
            Extended = dataReader["extended"].ToString();


            dataReader.Close();
            connection.Close();
            command.Dispose();
            connection.Dispose();
        }



    }


}
