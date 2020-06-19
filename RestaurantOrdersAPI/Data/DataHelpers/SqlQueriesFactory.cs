namespace RestaurantOrdersAPI.Data.DataHelpers
{
    public static class SqlQueriesFactory
    {
        public static string AddUser()
        {
            return "INSERT INTO Users (username, name, surname, is_active, password_hash, password_salt) VALUES (@Username, @Name, @Surname, @IsActive, @PasswordHash, @PasswordSalt)";
        }

        public static string AddMeal()
        {
            return "INSERT INTO Meals(name, unitprice) VALUES (@Name, @UnitPrice)";
        }

        public static string AddTable()
        {
            return "INSERT INTO Tables(name) VALUES (@Name)";
        }

        public static string AddOrder()
        {
            return "INSERT INTO Tables(name) VALUES (@Name)";
        }

        public static string AddOrderItems()
        {
            return "INSERT INTO OrderItems(price, quantity, mealid, orderid) VALUES (@Price, @Quantity, @MealId, @OrderId)";
        }

        public static string DeleteUser()
        {
            return "DELETE FROM Users WHERE id = @Id";
        }

        public static string DeleteMeal()
        {
            return "DELETE FROM Meals WHERE id = @Id";
        }

        public static string DeleteTable()
        {
            return "DELETE FROM Tables WHERE id = @Id";
        }

        public static string DeleteOrder()
        {
            return "DELETE FROM Orders WHERE id = @Id";
        }

        public static string DeleteOrderItems()
        {
            return "DELETE FROM OrderItems WHERE id = @Id";
        }

        public static string GetAllUsers()
        {
            return "SELECT * FROM Users";
        }

        public static string GetAllMeals()
        {
            return "SELECT * FROM Meals";
        }

        public static string GetAllTables()
        {
            return "SELECT * FROM Tables";
        }

        public static string GetAllOrders()
        {
            return "SELECT * FROM Orders";
        }
    }
}