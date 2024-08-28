using System.Threading.Tasks;
using ProHardikV1.Models.TokenAuth;
using ProHardikV1.Web.Controllers;
using Shouldly;
using Xunit;

namespace ProHardikV1.Web.Tests.Controllers
{
    public class HomeController_Tests: ProHardikV1WebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}