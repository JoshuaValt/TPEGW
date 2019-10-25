using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Collections.ObjectModel;
using System.Windows.Media.Imaging;
using System.Data.SQLite;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace TPEGW
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string mapLoadTest;
        int currentRow = 0;
        int currentColum = 0;
        public string mapId;
        string[] map;
        string databaseConnectionString = @"Data Source=C:\databases\tpegw-game.db; Version=3;";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {


            LifeForm hero1 = new LifeForm();
            hero1.EquipedOffensiveItems.Add(CreateFlamingAxe());
            hero1.EquipedDefensiveItems.Add(CreateEnduringLeatherArmor());
            hero1.EquipedItems.Add(CreateRing());
            Debug.WriteLine(hero1.Endurance);

            LifeForm hero2 = new LifeForm();
            hero2.EquipedOffensiveItems.Add(CreateFlamingAxe());
            hero2.BaseSpeed = 40;

            Debug.WriteLine(Dice.Roller.Roll("1d20+10").Value);

            // Fight(hero1, hero2);


            //imgImage1.Source = new BitmapImage(new Uri(, UriKind.Absolute));


            //Canvas.SetLeft(imgImage1, 0);
            //Canvas.SetTop(imgImage1, 0);




            //DrawMapOnScreen(map, currentRow, currentColum);


        }

        private Image[,] CreateMapGrid()
        {

            double rows = canvas1.ActualHeight / 64;
            double columns = canvas1.ActualWidth / 64;
            Image[,] images = new Image[(int)rows,(int) columns];

            for (int row = 0; row < rows; row++)
            {
                for (int column = 0; column < columns; column++)
                {
                    Image image = new Image();
                    image.Source = new BitmapImage(new Uri(@"C:\repos\TPEGW\assets\dungeon\floor\black_cobalt_4.png", UriKind.Absolute));
                    image.Width = 64;
                    image.Height = 64;
                    canvas1.Children.Add(image);
                    Canvas.SetTop(image, 64 * row);
                    Canvas.SetLeft(image, 64 * column);

                    Canvas.SetZIndex(image, -1);
                    images[row, column] = image;
                }

            }
            return images;
        }

        public void DrawMapOnScreen(string[] map, int currentRow, int currentColumn)
        {


            //imgImage00.Source = new BitmapImage(new Uri(GetImagePath(map[currentRow][currentColumn].ToString()), UriKind.Absolute));
            //imgImage01.Source = new BitmapImage(new Uri(GetImagePath(map[currentRow][currentColumn + 1].ToString()), UriKind.Absolute));
            //imgImage02.Source = new BitmapImage(new Uri(GetImagePath(map[currentRow][currentColumn + 2].ToString()), UriKind.Absolute));
            //imgImage03.Source = new BitmapImage(new Uri(GetImagePath(map[currentRow][currentColumn + 3].ToString()), UriKind.Absolute));
            //imgImage04.Source = new BitmapImage(new Uri(GetImagePath(map[currentRow][currentColumn + 4].ToString()), UriKind.Absolute));
            //imgImage05.Source = new BitmapImage(new Uri(GetImagePath(map[currentRow][currentColumn + 5].ToString()), UriKind.Absolute));
            //imgImage06.Source = new BitmapImage(new Uri(GetImagePath(map[currentRow][currentColumn + 6].ToString()), UriKind.Absolute));
            //imgImage10.Source = new BitmapImage(new Uri(GetImagePath(map[currentRow + 1][currentColumn].ToString()), UriKind.Absolute));
            //imgImage11.Source = new BitmapImage(new Uri(GetImagePath(map[currentRow + 1][currentColumn + 1].ToString()), UriKind.Absolute));
            //imgImage12.Source = new BitmapImage(new Uri(GetImagePath(map[currentRow + 1][currentColumn + 2].ToString()), UriKind.Absolute));
            //imgImage13.Source = new BitmapImage(new Uri(GetImagePath(map[currentRow + 1][currentColumn + 3].ToString()), UriKind.Absolute));
            //imgImage14.Source = new BitmapImage(new Uri(GetImagePath(map[currentRow + 1][currentColumn + 4].ToString()), UriKind.Absolute));
            //imgImage15.Source = new BitmapImage(new Uri(GetImagePath(map[currentRow + 1][currentColumn + 5].ToString()), UriKind.Absolute));
            //imgImage16.Source = new BitmapImage(new Uri(GetImagePath(map[currentRow + 1][currentColumn + 6].ToString()), UriKind.Absolute));
            //imgImage20.Source = new BitmapImage(new Uri(GetImagePath(map[currentRow + 2][currentColumn + 0].ToString()), UriKind.Absolute));
            //imgImage21.Source = new BitmapImage(new Uri(GetImagePath(map[currentRow + 2][currentColumn + 1].ToString()), UriKind.Absolute));
            //imgImage22.Source = new BitmapImage(new Uri(GetImagePath(map[currentRow + 2][currentColumn + 2].ToString()), UriKind.Absolute));
            //imgImage23.Source = new BitmapImage(new Uri(GetImagePath(map[currentRow + 2][currentColumn + 3].ToString()), UriKind.Absolute));
            //imgImage24.Source = new BitmapImage(new Uri(GetImagePath(map[currentRow + 2][currentColumn + 4].ToString()), UriKind.Absolute));
            //imgImage25.Source = new BitmapImage(new Uri(GetImagePath(map[currentRow + 2][currentColumn + 5].ToString()), UriKind.Absolute));
            //imgImage26.Source = new BitmapImage(new Uri(GetImagePath(map[currentRow + 2][currentColumn + 6].ToString()), UriKind.Absolute));
            //imgImage30.Source = new BitmapImage(new Uri(GetImagePath(map[currentRow + 3][currentColumn + 0].ToString()), UriKind.Absolute));
            //imgImage31.Source = new BitmapImage(new Uri(GetImagePath(map[currentRow + 3][currentColumn + 1].ToString()), UriKind.Absolute));
            //imgImage32.Source = new BitmapImage(new Uri(GetImagePath(map[currentRow + 3][currentColumn + 2].ToString()), UriKind.Absolute));
            //imgImage33.Source = new BitmapImage(new Uri(GetImagePath(map[currentRow + 3][currentColumn + 3].ToString()), UriKind.Absolute));
            //imgImage34.Source = new BitmapImage(new Uri(GetImagePath(map[currentRow + 3][currentColumn + 4].ToString()), UriKind.Absolute));
            //imgImage35.Source = new BitmapImage(new Uri(GetImagePath(map[currentRow + 3][currentColumn + 5].ToString()), UriKind.Absolute));
            //imgImage36.Source = new BitmapImage(new Uri(GetImagePath(map[currentRow + 3][currentColumn + 6].ToString()), UriKind.Absolute));
            //imgImage40.Source = new BitmapImage(new Uri(GetImagePath(map[currentRow + 4][currentColumn + 0].ToString()), UriKind.Absolute));
            //imgImage41.Source = new BitmapImage(new Uri(GetImagePath(map[currentRow + 4][currentColumn + 1].ToString()), UriKind.Absolute));
            //imgImage42.Source = new BitmapImage(new Uri(GetImagePath(map[currentRow + 4][currentColumn + 2].ToString()), UriKind.Absolute));
            //imgImage43.Source = new BitmapImage(new Uri(GetImagePath(map[currentRow + 4][currentColumn + 3].ToString()), UriKind.Absolute));
            //imgImage44.Source = new BitmapImage(new Uri(GetImagePath(map[currentRow + 4][currentColumn + 4].ToString()), UriKind.Absolute));
            //imgImage45.Source = new BitmapImage(new Uri(GetImagePath(map[currentRow + 4][currentColumn + 5].ToString()), UriKind.Absolute));
            //imgImage46.Source = new BitmapImage(new Uri(GetImagePath(map[currentRow + 4][currentColumn + 6].ToString()), UriKind.Absolute));
            //imgImage50.Source = new BitmapImage(new Uri(GetImagePath(map[currentRow + 5][currentColumn + 0].ToString()), UriKind.Absolute));
            //imgImage51.Source = new BitmapImage(new Uri(GetImagePath(map[currentRow + 5][currentColumn + 1].ToString()), UriKind.Absolute));
            //imgImage52.Source = new BitmapImage(new Uri(GetImagePath(map[currentRow + 5][currentColumn + 2].ToString()), UriKind.Absolute));
            //imgImage53.Source = new BitmapImage(new Uri(GetImagePath(map[currentRow + 5][currentColumn + 3].ToString()), UriKind.Absolute));
            //imgImage54.Source = new BitmapImage(new Uri(GetImagePath(map[currentRow + 5][currentColumn + 4].ToString()), UriKind.Absolute));
            //imgImage55.Source = new BitmapImage(new Uri(GetImagePath(map[currentRow + 5][currentColumn + 5].ToString()), UriKind.Absolute));
            //imgImage56.Source = new BitmapImage(new Uri(GetImagePath(map[currentRow + 5][currentColumn + 6].ToString()), UriKind.Absolute));



            //foreach (string file in Directory.EnumerateFiles(""))
            // {
            //    string fileContents = File.ReadAllText(file);
            //}

        }


        private MapCell[,] LoadMapLevel(string levelName)
        {


            // query the map tabel by level name

            // create a multiu dimensional array of map cell with teh dimensions of the rows and columns

            // get the id and query the map cell table by the map_id

            // loop through the results and create a map cell object for each and put it into cells array

            SQLiteConnection connection = new SQLiteConnection(databaseConnectionString);
            connection.Open();

            SQLiteCommand command = new SQLiteCommand($"select * from map where name = '{levelName}'", connection);

            SQLiteDataReader dataReader = command.ExecuteReader();


            dataReader.Read();

            string id = dataReader["id"].ToString();
            int rows = int.Parse(dataReader["rows"].ToString());
            int columns = int.Parse(dataReader["columns"].ToString());
            string name = dataReader["name"].ToString();

            command.Dispose();
            dataReader.Close();

            MapCell[,] mapCells = new MapCell[rows, columns];

            command = new SQLiteCommand($"select * from map_cell where map_id = '{id}'", connection);

            dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                
               
                
                MapCell mapCell = new MapCell();
                mapCell.Id = dataReader["id"].ToString();
                mapCell.Row = int.Parse(dataReader["row"].ToString());
                mapCell.Column = int.Parse(dataReader["column"].ToString());
                mapCell.CellType = dataReader["cell_type"].ToString();
                mapCell.CellValue = dataReader["cell_value"].ToString();
                mapCell.Extended = dataReader["extended"].ToString();

                mapCells[mapCell.Row, mapCell.Column] = mapCell;

            }
            

            return mapCells;
        }






        public void Fight(LifeForm hero1, LifeForm hero2)
        {
            Collection<LifeForm> heros = new Collection<LifeForm>();
            heros.Add(hero1);
            heros.Add(hero2);
            bool hasWinner = false;
            long tick = 0;

            while (hasWinner == false)
            {
                foreach (var hero in heros)
                {
                    if (hero.nextActionTime <= tick)
                    {
                        //Do attack

                        if (hero1 == hero)
                        {
                            ResolveAttack(hero, hero2);
                        }
                        else
                        {
                            ResolveAttack(hero, hero1);
                        }

                        if (hero1.currentHealth <= 0)
                        {
                            hasWinner = true;
                        }

                        if (hero2.currentHealth <= 0)
                        {
                            hasWinner = true;
                        }


                        hero.nextActionTime = tick + Convert.ToInt64(hero.Speed);

                    }



                }

                tick++;

            }

        }

        private void ResolveAttack(LifeForm attacker, LifeForm defender)
        {



            float hitChance = attacker.Agility - defender.Agility + 50;
            if (Convert.ToSingle(Dice.Roller.Roll("1d100").Value) < hitChance)
            {
                float damage = 0;

                foreach (var offensiveItem in attacker.EquipedOffensiveItems)
                {
                    damage += Convert.ToSingle(Dice.Roller.Roll(offensiveItem.Damage).Value);
                }

                foreach (var defensiveItem in defender.EquipedDefensiveItems)
                {
                    damage -= Convert.ToSingle(Dice.Roller.Roll(defensiveItem.Protection).Value);
                }
                if (damage > 0)
                {
                    defender.currentHealth -= damage;


                }

            }





        }



        public OffensiveItem CreateFlamingAxe()
        {
            OffensiveItemModifier endure = new OffensiveItemModifier();
            endure.Endurance = 10;
            endure.Name = "Endureing";


            OffensiveItemModifier flaming = new OffensiveItemModifier();
            flaming.BonusDamage = "1D4";
            flaming.Name = "Fire";

            OffensiveItem axe = new OffensiveItem();
            axe.Accuracy = 10;
            axe.Damage = "2d6";
            axe.Durability = 100;
            axe.Level = 1;
            axe.Name = "Long Wood Axe";
            axe.Range = 2;
            axe.Speed = -20;
            axe.Weight = 10;
            axe.Modifiers.Add(flaming);
            axe.Modifiers.Add(endure);


            return axe;
        }

        public DefensiveItem CreateEnduringLeatherArmor()
        {

            DefensiveItem armor = new DefensiveItem();
            armor.Protection = "1d6-1";
            DefinsiveItemModifier endure = new DefinsiveItemModifier();
            endure.Endurance = 10;
            endure.Name = "Endureing";

            armor.Modifiers.Add(endure);




            return armor;
        }

        public Item CreateRing()
        {
            Item Ring = new Item();

            ItemModifier endure = new ItemModifier();
            endure.Endurance = 10;
            endure.Name = "Ring of Endureing";

            Ring.Modifiers.Add(endure);



            return Ring;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Canvas.SetLeft(imgImage1, Canvas.GetLeft(imgImage1) + 64 );
            //Canvas.SetTop(imgImage1, 0);
            if (currentColum < map[0].Length - 6)
            {
                currentColum++;
                DrawMapOnScreen(map, currentRow, currentColum);
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //Map mapCell = new Map();
            //mapCell.Load("");


            Image image1 = new Image();
            canvas1.Children.Add(image1);
            Canvas.SetTop(image1, 145);
            Canvas.SetLeft(image1, 205);
            image1.Source = new BitmapImage(new Uri(@"C:\Users\user\Downloads\Dungeon Crawl Stone Soup Full\Dungeon Crawl Stone Soup Full\dungeon\floor\dirt_southwest_new.png", UriKind.Absolute));
            image1.Width = 32;
            image1.Height = 32;

            double x = Canvas.GetLeft(image1);
            double y = Canvas.GetTop(image1);

            currentRow++;
            DrawMapOnScreen(map, currentRow, currentColum);

        }

        private void GetXAndY()
        {



        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (currentColum > 0)
            {
                currentColum--;
                DrawMapOnScreen(map, currentRow, currentColum);
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (currentRow > 0)
            {
                currentRow--;
                DrawMapOnScreen(map, currentRow, currentColum);
            }
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            LoadMapLevel("level one");

            CreateMap("level two", 10, 10);



        }

        private void CreateMap(string name, int rows, int columns)
        {

            Map map = new Map();

            map.Name = name;
            map.Width = rows;
            map.Height = columns;
            map.Save();

            for (int mapRow = 0; mapRow < rows; mapRow++)
            {
                for (int mapColumn = 0; mapColumn < columns; mapColumn++)
                {
                    MapCell mapCell = new MapCell();

                    mapCell.Row = mapRow;
                    mapCell.Column = mapColumn;
                    mapCell.CellValue = "0";
                    mapCell.MapId = map.Id;
                    mapCell.CellType = "0";

                    mapCell.Save();









                }
            }


        }



        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            CreateMapGrid();
           // string[] allfiles = Directory.GetFiles(@"C:\Users\user\Downloads\Dungeon Crawl Stone Soup Full\Dungeon Crawl Stone Soup Full", "*.png", SearchOption.AllDirectories);



        }


    }
}
