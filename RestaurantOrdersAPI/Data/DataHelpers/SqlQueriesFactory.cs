namespace RestaurantOrdersAPI.Data.DataHelpers
{
    public static class SqlQueriesFactory
    {
        public static string AddUser()
        {
            return "INSERT INTO Users (username, name, surname, role, isactive, passwordhash, passwordsalt) VALUES (@Username, @Name, @Surname, @Role, @IsActive, @PasswordHash, @PasswordSalt)";
        }

        public static string AddMeal()
        {
            return "INSERT INTO Meals(name, unitprice) OUTPUT INSERTED.* VALUES (@Name, @UnitPrice)";
        }

        public static string AddTable()
        {
            return "INSERT INTO Tables(name) OUTPUT INSERTED.* VALUES (@Name)";
        }

        public static string AddOrder()
        {
            return "INSERT INTO Orders(totalprice, status, tableid) VALUES (@TotalPrice, @Status, @Table.Id)";
        }

        public static string AddOrderItem()
        {
            return "INSERT INTO OrderItems(price, quantity, mealid, orderid) OUTPUT INSERTED.* VALUES (@Price, @Quantity, @MealId, @OrderId)";
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
            return "DELETE FROM Orders WHERE id = @Id DELETE FROM OrderItems WHERE orderid = @Id";
        }

        public static string DeleteOrderItem()
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
            return "SELECT * FROM Orders o INNER JOIN Tables t ON o.tableid = t.id INNER JOIN OrderItems i ON o.id = i.orderitemid INNER JOIN Meals m ON m.id = i.mealid";
        }

        public static string GetUser()
        {
            return "SELECT * FROM Users WHERE username = @Username";
        }

        public static string GetMeal()
        {
            return "SELECT * FROM Meals WHERE id = @Id";
        }

        public static string GetTable()
        {
            return "SELECT * FROM Tables WHERE id = @Id";
        }

        public static string GetOrder()
        {
            return "SELECT * FROM Orders WHERE id = @Id";
        }

        public static string GetOrderItem()
        {
            return "SELECT * FROM OrderItems WHERE id = @Id";
        }
    }
}