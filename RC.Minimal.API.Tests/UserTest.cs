


public class UserTest
{
    [Test]
    public async Task GetUsersByUsername()
    {
        await using var application = new WebApplicationFactory<Program>();
        var client = application.CreateClient();
        var response = await client.GetAsync("/user/ADMIN");

        Assert.IsNotNull(response);
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));   
    }

    [Test]
    public async Task GetUsersByUsernameWrongTest()
    {
        await using var application = new WebApplicationFactory<Program>();
        var client = application.CreateClient();
        var response = await client.GetAsync("/user/A");

        Assert.IsNotNull(response);
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
    }

    [Test]
    public async Task GetUsersWithoutUsernameTest()
    {
        await using var application = new WebApplicationFactory<Program>();
        var client = application.CreateClient();
        var response = await client.GetAsync("/user/");

        Assert.IsNotNull(response);
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));        
    }
    [Test]
    public async Task GetTenUsersTest()
    {
        await using var application = new WebApplicationFactory<Program>();
        var client = application.CreateClient();
        var response = await client.GetAsync("/user/");

        Assert.IsNotNull(response);
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
    }
}
