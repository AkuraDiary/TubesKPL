using AKMJ_TubesKPL;
using AKMJ_TubesKPL.Data;
using AKMJ_TubesKPL.Data.Models;
using AKMJ_TubesKPL.Repo;
using AKMJ_TubesKPL.View.AuthView;
using AKMJ_TubesKPL.View.Menu;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;

[TestClass]
public class MenuViewTest
{
    [TestMethod]
    public void showMenuOptions()
    {
        // Arrange
        var datasource = new TodoDataSource();
        var appConfig = new AppConfig();
        var todoRepo = new TodoRepository(datasource);
        var authRepo = new AuthRepository(appConfig);
     
        var menu = new MenuView(todoRepo, authRepo);

        string result = menu.getDashboardMenu();

                Assert.IsTrue(result.Contains("1. Lihat To Do"));
                Assert.IsTrue(result.Contains("2. Tambah To Do"));
                Assert.IsTrue(result.Contains("3. Update To Do"));
                Assert.IsTrue(result.Contains("4. Delete To Do"));
                Assert.IsTrue(result.Contains("5. Logout"));

    }
    [TestMethod]
    public void menuOptionsList()
    {
        // Arrange
        var datasource = new TodoDataSource();
        var appConfig = new AppConfig();
        var todoRepo = new TodoRepository(datasource);
        var authRepo = new AuthRepository(appConfig);

        var menu = new MenuView(todoRepo, authRepo);

        var dict = menu.crudMenu;
        CollectionAssert.AreEquivalent(new[] { "1", "2", "3", "4", "5" }, dict.Keys.ToList());

    }

    [TestMethod]
    public void authMenuOptions()
    {
        //var userService = new UserService();
        var dict = UserService.MenuOptions;

        
        CollectionAssert.AreEquivalent(new[] { "1", "2", "x" }, dict.Keys.ToList());
    }

    [TestMethod]
    public void authMenuOptions1()
    {
        var userService = new UserService();
        //var dict = userService.MenuOptions;

        // Arrange
        var dict = UserService.MenuOptions;

        // Create a delegate that points to exactly the same method
        Action expected = UserService.ShowLoginForm;

        // Act
        Action actual = dict["1"];

        // Assert: delegate equality
        //  – for static methods, Delegate.Equals checks the Method and the Target (null)  
        Assert.IsTrue(Delegate.Equals(expected, actual), "MenuOptions[\"1\"] should point to UserService.ShowLoginForm");

        // You can also assert on the MethodInfo directly:
        Assert.AreEqual(expected.Method, actual.Method);
        Assert.IsNull(actual.Target);

        //Assert.ReferenceEquals(dict["1"], (Action)UserService.ShowLoginForm());

    }

    [TestMethod]

    public void authMenuOptions2()
    {
        var userService = new UserService();
        //var dict = userService.MenuOptions;

        // Arrange
        var dict = UserService.MenuOptions;

        // Create a delegate that points to exactly the same method
        Action expected = UserService.ShowRegisterLink;

        // Act
        Action actual = dict["2"];

        // Assert: delegate equality
        //  – for static methods, Delegate.Equals checks the Method and the Target (null)  
        Assert.IsTrue(Delegate.Equals(expected, actual), "MenuOptions[\"2\"] should point to UserService.ShowRegisterLink");

        // You can also assert on the MethodInfo directly:
        Assert.AreEqual(expected.Method, actual.Method);
        Assert.IsNull(actual.Target);

        //Assert.ReferenceEquals(dict["1"], (Action)UserService.ShowLoginForm());

    }

    [TestMethod]

    public void authMenuOptions3()
    {
        var userService = new UserService();
        //var dict = userService.MenuOptions;

        // Arrange
        var dict = UserService.MenuOptions;

        // Create a delegate that points to exactly the same method
        Action expected = UserService.ExitApplication;

        // Act
        Action actual = dict["x"];

        // Assert: delegate equality
        //  – for static methods, Delegate.Equals checks the Method and the Target (null)  
        Assert.IsTrue(Delegate.Equals(expected, actual), "MenuOptions[\"x\"] should point to UserService.ExitApplication");

        // You can also assert on the MethodInfo directly:
        Assert.AreEqual(expected.Method, actual.Method);
        Assert.IsNull(actual.Target);

        //Assert.ReferenceEquals(dict["1"], (Action)UserService.ShowLoginForm());

    }

    [TestMethod]
    public void DashboardMenuOptions()
    {

        // Arrange
        var datasource = new TodoDataSource();
        var appConfig = new AppConfig();
        var todoRepo = new TodoRepository(datasource);
        var authRepo = new AuthRepository(appConfig);

        var menu = new MenuView(todoRepo, authRepo);
        //var dashboardmenu = new MenuView();

        //Arrange
        var dict = menu.crudMenu;

        //Act
        Action actual = dict["1"];
        Action expected = menu.ShowToDos;

        Assert.IsTrue(Delegate.Equals(expected, actual), "crudMenu[\"1\"] should point to MenuView.ShowToDos");

        // You can also assert on the MethodInfo directly:
        Assert.AreEqual(expected.Method, actual.Method);
        //Assert.IsNull(actual.Target);
    }

    [TestMethod]
    public void DashboardMenuOptions2()
    {

        // Arrange
        var datasource = new TodoDataSource();
        var appConfig = new AppConfig();
        var todoRepo = new TodoRepository(datasource);
        var authRepo = new AuthRepository(appConfig);

        var menu = new MenuView(todoRepo, authRepo);
        //var dashboardmenu = new MenuView();

        //Arrange
        var dict = menu.crudMenu;

        //Act
        Action actual = dict["2"];
        Action expected = menu.CreateToDo;

        Assert.IsTrue(Delegate.Equals(expected, actual), "crudMenu[\"2\"] should point to MenuView.CreateToDo");

        // You can also assert on the MethodInfo directly:
        Assert.AreEqual(expected.Method, actual.Method);
        //Assert.IsNull(actual.Target);
    }

    [TestMethod]
    public void DashboardMenuOptions3()
    {

        // Arrange
        var datasource = new TodoDataSource();
        var appConfig = new AppConfig();
        var todoRepo = new TodoRepository(datasource);
        var authRepo = new AuthRepository(appConfig);

        var menu = new MenuView(todoRepo, authRepo);
        //var dashboardmenu = new MenuView();

        //Arrange
        var dict = menu.crudMenu;

        //Act
        Action actual = dict["3"];
        Action expected = menu.UpdateToDo;

        Assert.IsTrue(Delegate.Equals(expected, actual), "crudMenu[\"3\"] should point to MenuView.UpdateToDo");

        // You can also assert on the MethodInfo directly:
        Assert.AreEqual(expected.Method, actual.Method);
        //Assert.IsNull(actual.Target);
    }


    [TestMethod]
    public void DashboardMenuOptions4()
    {

        // Arrange
        var datasource = new TodoDataSource();
        var appConfig = new AppConfig();
        var todoRepo = new TodoRepository(datasource);
        var authRepo = new AuthRepository(appConfig);

        var menu = new MenuView(todoRepo, authRepo);
        //var dashboardmenu = new MenuView();

        //Arrange
        var dict = menu.crudMenu;

        //Act
        Action actual = dict["4"];
        Action expected = menu.DeleteToDo;

        Assert.IsTrue(Delegate.Equals(expected, actual), "crudMenu[\"4\"] should point to MenuView.DeleteToDo");

        // You can also assert on the MethodInfo directly:
        Assert.AreEqual(expected.Method, actual.Method);
        //Assert.IsNull(actual.Target);
    }

    [TestMethod]
    public void DashboardMenuOptions5()
    {

        // Arrange
        var datasource = new TodoDataSource();
        var appConfig = new AppConfig();
        var todoRepo = new TodoRepository(datasource);
        var authRepo = new AuthRepository(appConfig);

        var menu = new MenuView(todoRepo, authRepo);
        //var dashboardmenu = new MenuView();

        //Arrange
        var dict = menu.crudMenu;

        //Act
        Action actual = dict["5"];
        Action expected = menu.Logout;

        Assert.IsTrue(Delegate.Equals(expected, actual), "crudMenu[\"5\"] should point to MenuView.Logout");

        // You can also assert on the MethodInfo directly:
        Assert.AreEqual(expected.Method, actual.Method);
        //Assert.IsNull(actual.Target);
    }
}