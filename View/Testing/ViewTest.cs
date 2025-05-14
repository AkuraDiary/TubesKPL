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
        Assert.IsTrue(Delegate.Equals(expected, actual), "MenuOptions[\"1\"] should point to UserService.ShowLoginForm");

        // You can also assert on the MethodInfo directly:
        Assert.AreEqual(expected.Method, actual.Method);
        Assert.IsNull(actual.Target);

        //Assert.ReferenceEquals(dict["1"], (Action)UserService.ShowLoginForm());

    }
}