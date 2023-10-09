using SwaggerPetstoreTestProject.Constants;
using SwaggerPetstoreTestProject.Models;
using TechTalk.SpecFlow.Assist;

namespace SwaggerPetstoreTestProject.Steps
{
    [Binding]
    internal class UserSteps : BaseSteps
    {
        internal UserSteps(ScenarioContext scenarioContext, IObjectContainer objectContainer) : base(scenarioContext, objectContainer) { }

        [Given(@"the user sends request to add users with the following parameters")]
        internal async Task GivenTheUserSendsRequestToAddUsersWithTheFollowingParametersWithoutSavingTheResponse(Table table)
        {
            var users = table.CreateSet<UserModel>();

            var usersJson = JsonConvert.SerializeObject(users);

            var url = string.Concat(UrlConstants.BaseUrl, UrlConstants.AddNewUsersWithList);

            await httpRequestHelper.PostAsync(url, usersJson);
        }

        [When(@"the user sends request to add users with the following parameters")]
        internal async Task WhenTheUserSendsRequestToAddUsersWithTheFollowingParameters(Table table)
        {
            var users = table.CreateSet<UserModel>();

            var usersJson = JsonConvert.SerializeObject(users);

            var url = string.Concat(UrlConstants.BaseUrl, UrlConstants.AddNewUsersWithList);

            var response = await httpRequestHelper.PostAsync(url, usersJson);

            _scenarioContext.Add(ScenarioContextKeys.Response, response);
        }

        [When(@"the user sends request to get information about the user with username '(.*)'")]
        internal async Task WhenTheUserSendsRequestToGetInformationAboutTheUserWithUsername(string username)
        {
            var url = string.Format(string.Concat(UrlConstants.BaseUrl, UrlConstants.FindOrDeleteUserByUsername), username);

            var response = await httpRequestHelper.GetAsync(url);

            _scenarioContext.Add(ScenarioContextKeys.Response, response);
        }

        [When(@"the user sends request to delete information about the user with username '(.*)'")]
        internal async Task WhenTheUserSendsRequestToDeleteInformationAboutTheOrderWithId(string username)
        {
            var url = string.Format(string.Concat(UrlConstants.BaseUrl, UrlConstants.FindOrDeleteUserByUsername), username);

            var response = await httpRequestHelper.DeleteAsync(url);

            _scenarioContext.Add(ScenarioContextKeys.Response, response);
        }

        [Then(@"the response contains the following information about the user")]
        internal async Task ThenTheResponseShouldContainTheFollowingInformationAboutTheUser(Table table)
        {
            var expectedUser = table.CreateInstance<UserModel>();

            var content = await _scenarioContext.Get<HttpResponseMessage>(ScenarioContextKeys.Response).Content.ReadAsStringAsync();

            var actualUser = JsonConvert.DeserializeObject<UserModel>(content);

            actualUser.Should().NotBeNull();
            actualUser.Should().BeEquivalentTo(expectedUser);
        }
    }
}