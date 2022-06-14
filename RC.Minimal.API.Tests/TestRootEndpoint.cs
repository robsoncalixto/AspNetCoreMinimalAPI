

namespace RC.Minimal.API.Tests
{
    public class TestRootEndpoint
    {
      
        [Test]
        public async Task RootEndpointTest()
        {
            await using var application = new WebApplicationFactory<Program>();
            using var client = application.CreateClient();

            var response = await client.GetStringAsync("/");
            Assert.That(response, Is.EqualTo("Welcome!"));            
        }
    }
}