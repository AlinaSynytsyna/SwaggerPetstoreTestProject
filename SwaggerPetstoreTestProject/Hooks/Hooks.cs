using SwaggerPetstoreTestProject.Constants;
using SwaggerPetstoreTestProject.Helpers;

namespace SwaggerPetstoreTestProject.Hooks
{
    [Binding]
    internal class Hooks
    {
        [BeforeTestRun]
        public static void BeforeTestRun(IObjectContainer objectContainer)
        {
            var httpRequestHelper = new HttpRequestHelper();

            objectContainer.RegisterInstanceAs(httpRequestHelper);
        }

        [BeforeScenario(Order = 0)]
        [AfterScenario(Order = 0)]
        public async Task CleanPetTestData(IObjectContainer objectContainer)
        {
            var httpRequestHelper = objectContainer.Resolve<HttpRequestHelper>();
            var url = string.Format(string.Concat(UrlConstants.BaseUrl, UrlConstants.FindOrDeletePetById), TestConstants.PetId);

            await httpRequestHelper.DeleteAsync(url);
        }

        [BeforeScenario(Order = 1)]
        [AfterScenario(Order = 1)]
        public async Task CleanOrderTestData(IObjectContainer objectContainer)
        {
            var httpRequestHelper = objectContainer.Resolve<HttpRequestHelper>();
            var url = string.Format(string.Concat(UrlConstants.BaseUrl, UrlConstants.FindOrDeleteOrderById), TestConstants.OrderId);

            await httpRequestHelper.DeleteAsync(url);
        }

        [BeforeScenario(Order = 2)]
        [AfterScenario(Order = 2)]
        public async Task CleanUserTestData(IObjectContainer objectContainer)
        {
            var httpRequestHelper = objectContainer.Resolve<HttpRequestHelper>();

            foreach (var username in TestConstants.Usernames)
            {
                var url = string.Format(string.Concat(UrlConstants.BaseUrl, UrlConstants.FindOrDeleteUserByUsername), username);

                await httpRequestHelper.DeleteAsync(url);
            }
        }
    }
}