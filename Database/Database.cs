using System;
using System.IO;
using Microsoft.Data.Sqlite;

namespace MyCalories
{
    public class Database
    {
        private readonly string _dbPath;

        public Database()
        {
            // Store the database inside the project folder
            var folder = Path.GetFullPath(
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\", "Database"));
            Directory.CreateDirectory(folder);

            _dbPath = Path.Combine(folder, "calories.db");

            // Create database if it doesn't exist
            if (!File.Exists(_dbPath))
                CreateDatabase();
        }

        private void CreateDatabase()
        {
            using var connection = new SqliteConnection($"Data Source={_dbPath}");
            connection.Open();

            // Create the Foods table
            var command = connection.CreateCommand();
            command.CommandText = @"
                CREATE TABLE IF NOT EXISTS Foods (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Name TEXT NOT NULL UNIQUE,
                    CaloriesPer100g REAL NOT NULL
                );
            ";
            command.ExecuteNonQuery();

            // Seed data
            using var insert = connection.CreateCommand();
            insert.CommandText = "INSERT INTO Foods (Name, CaloriesPer100g) VALUES (@n, @c)";
            insert.Parameters.AddWithValue("@n", "");
            insert.Parameters.AddWithValue("@c", 0.0);

            void Add(string name, double cals)
            {
                insert.Parameters["@n"].Value = name;
                insert.Parameters["@c"].Value = cals;
                insert.ExecuteNonQuery();
            }

            // ~200 foods with calories per 100 g
            Add("Apple", 52);
            Add("Banana", 89);
            Add("Orange", 47);
            Add("Strawberries", 32);
            Add("Blueberries", 57);
            Add("Raspberries", 52);
            Add("Grapes", 69);
            Add("Mango", 60);
            Add("Pineapple", 50);
            Add("Watermelon", 30);
            Add("Avocado", 160);
            Add("Kiwi", 41);
            Add("Pear", 57);
            Add("Peach", 39);
            Add("Plum", 46);
            Add("Cherry", 50);
            Add("Lemon", 29);
            Add("Tomato", 18);
            Add("Cucumber", 16);
            Add("Carrot", 41);
            Add("Broccoli", 34);
            Add("Cauliflower", 25);
            Add("Spinach", 23);
            Add("Lettuce", 15);
            Add("Potato", 77);
            Add("Sweet Potato", 86);
            Add("Corn", 96);
            Add("Green Peas", 81);
            Add("Onion", 40);
            Add("Garlic", 149);
            Add("Eggplant", 25);
            Add("Zucchini", 17);
            Add("Mushroom", 22);
            Add("Bell Pepper", 26);
            Add("Asparagus", 20);
            Add("Celery", 16);
            Add("Beetroot", 43);
            Add("Pumpkin", 26);
            Add("Okra", 33);
            Add("Chicken Breast", 165);
            Add("Chicken Thigh", 209);
            Add("Turkey", 189);
            Add("Beef (lean)", 250);
            Add("Pork", 242);
            Add("Bacon", 541);
            Add("Ham", 145);
            Add("Salmon", 208);
            Add("Tuna", 132);
            Add("Shrimp", 99);
            Add("Cod", 82);
            Add("Sardines", 208);
            Add("Egg (whole)", 155);
            Add("Egg White", 52);
            Add("Cheddar Cheese", 402);
            Add("Mozzarella", 280);
            Add("Yogurt", 59);
            Add("Milk (whole)", 61);
            Add("Milk (skim)", 35);
            Add("Butter", 717);
            Add("Olive Oil", 884);
            Add("Bread (white)", 265);
            Add("Bread (whole wheat)", 247);
            Add("Rice (cooked)", 130);
            Add("Rice (brown)", 123);
            Add("Pasta (cooked)", 131);
            Add("Oats", 389);
            Add("Cereal (cornflakes)", 357);
            Add("Lentils", 116);
            Add("Black Beans", 132);
            Add("Chickpeas", 164);
            Add("Tofu", 76);
            Add("Almonds", 579);
            Add("Walnuts", 654);
            Add("Peanuts", 567);
            Add("Cashews", 553);
            Add("Sunflower Seeds", 584);
            Add("Pumpkin Seeds", 559);
            Add("Chia Seeds", 486);
            Add("Flax Seeds", 534);
            Add("Honey", 304);
            Add("Sugar", 387);
            Add("Dark Chocolate", 546);
            Add("Milk Chocolate", 535);
            Add("Ice Cream", 207);
            Add("Pizza", 266);
            Add("Burger", 295);
            Add("French Fries", 312);
            Add("Hot Dog", 290);
            Add("Pancakes", 227);
            Add("Waffles", 291);
            Add("Bagel", 250);
            Add("Muffin", 377);
            Add("Croissant", 406);
            Add("Donut", 452);
            Add("Soup (chicken)", 50);
            Add("Soup (vegetable)", 35);
            Add("Coffee (black)", 2);
            Add("Tea (unsweetened)", 1);
            Add("Beer", 43);
            Add("Wine (red)", 85);
            Add("Soda", 41);
            Add("Juice (orange)", 45);
            Add("Steak", 271);
            Add("Pork Chop", 231);
            Add("Bologna", 299);
            Add("Granola Bar", 471);
            Add("Protein Bar", 371);
            Add("Trail Mix", 498);
            Add("Peanut Butter", 588);
            Add("Jam", 250);
            Add("Hazelnuts", 628);
            Add("Macadamia Nuts", 718);
            Add("Coconut (fresh)", 354);
            Add("Coconut Oil", 862);
            Add("Mayonnaise", 680);
            Add("Ketchup", 112);
            Add("Mustard", 66);
            Add("Soy Sauce", 53);
            Add("Vinegar", 20);
            Add("Pickles", 11);
            Add("Pasta Sauce", 80);
            Add("Tomato Paste", 82);
            Add("Hummus", 166);
            Add("Curry (chicken)", 189);
            Add("Stir Fry (vegetable)", 75);
            Add("Sushi (average roll)", 140);
            Add("Fried Rice", 163);
            Add("Taco (beef)", 226);
            Add("Burrito", 236);
            Add("Nachos", 318);
            Add("Quesadilla", 330);
            Add("Lasagna", 135);
            Add("Mac and Cheese", 164);
            Add("Chili (con carne)", 157);
            Add("Sandwich (ham)", 198);
            Add("Sandwich (turkey)", 189);
            Add("Wrap (chicken)", 220);
            Add("Salad (green)", 30);
            Add("Salad (pasta)", 190);
            Add("Salad (potato)", 143);
            Add("Coleslaw", 150);
            Add("Water", 0);

            Console.WriteLine("✅ Database created in project folder and seeded with foods.");
        }
    }
}
