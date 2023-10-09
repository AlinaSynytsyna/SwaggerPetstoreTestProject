using SwaggerPetstoreTestProject.Constants;
using SwaggerPetstoreTestProject.Models;
using System.Net;
using TechTalk.SpecFlow.Assist;

namespace SwaggerPetstoreTestProject.Steps
{
    [Binding]
    internal class CommonSteps : BaseSteps
    {
        internal CommonSteps(ScenarioContext scenarioContext, IObjectContainer objectContainer) : base(scenarioContext, objectContainer) { }

        [Then(@"the response with '(.*)' status code is returned")]
        internal void ThenTheResponseWithStatusCodeIsReturned(HttpStatusCode statusCode)
        {
            var response = _scenarioContext.Get<HttpResponseMessage>(ScenarioContextKeys.Response);

            response.StatusCode.Should().Be(statusCode);
        }

        [Then(@"the message contains the following information")]
        internal async Task ThenTheMessageContainsTheFollowingInformation(Table table)
        {
            var expectedMessage = table.CreateInstance<MessageModel>();

            var content = await _scenarioContext.Get<HttpResponseMessage>(ScenarioContextKeys.Response).Content.ReadAsStringAsync();
            var actualMessage = JsonConvert.DeserializeObject<MessageModel>(content);

            actualMessage.Should().NotBeNull();
            actualMessage.Should().BeEquivalentTo(expectedMessage);
        }
    }
}