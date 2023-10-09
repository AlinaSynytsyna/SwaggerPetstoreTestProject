using SwaggerPetstoreTestProject.Constants;
using SwaggerPetstoreTestProject.Models;
using TechTalk.SpecFlow.Assist;

namespace SwaggerPetstoreTestProject.Steps
{
    [Binding]
    internal class StoreSteps : BaseSteps
    {
        internal StoreSteps(ScenarioContext scenarioContext, IObjectContainer objectContainer) : base(scenarioContext, objectContainer) { }

        [Given(@"the user sends request to add a new order with the following parameters")]
        internal async Task GivenTheUserSendsRequestToAddANewOrderWithTheFollowingParametersWithoutSavingTheResponse(Table table)
        {
            var order = table.CreateInstance<OrderModel>();

            var orderJson = JsonConvert.SerializeObject(order);

            var url = string.Concat(UrlConstants.BaseUrl, UrlConstants.AddNewOrder);

            await httpRequestHelper.PostAsync(url, orderJson);
        }

        [When(@"the user sends request to add a new order with the following parameters")]
        internal async Task WhenTheUserSendsRequestToAddANewOrderWithTheFollowingParameters(Table table)
        {
            var order = table.CreateInstance<OrderModel>();

            var orderJson = JsonConvert.SerializeObject(order);

            var url = string.Concat(UrlConstants.BaseUrl, UrlConstants.AddNewOrder);

            var response = await httpRequestHelper.PostAsync(url, orderJson);

            _scenarioContext.Add(ScenarioContextKeys.Response, response);
        }

        [When(@"the user sends request to get information about the order with ID (.*)")]
        internal async Task WhenTheUserSendsRequestToGetInformationAboutTheOrderWithId(int id)
        {
            var url = string.Format(string.Concat(UrlConstants.BaseUrl, UrlConstants.FindOrDeleteOrderById), id);

            var response = await httpRequestHelper.GetAsync(url);

            _scenarioContext.Add(ScenarioContextKeys.Response, response);
        }

        [When(@"the user sends request to delete information about the order with ID (.*)")]
        internal async Task WhenTheUserSendsRequestToDeleteInformationAboutTheOrderWithId(int id)
        {
            var url = string.Format(string.Concat(UrlConstants.BaseUrl, UrlConstants.FindOrDeleteOrderById), id);

            var response = await httpRequestHelper.DeleteAsync(url);

            _scenarioContext.Add(ScenarioContextKeys.Response, response);
        }

        [Then(@"the response contains the following information about the order")]
        internal async Task ThenTheResponseShouldContainTheFollowingInfomationAboutTheOrder(Table table)
        {
            var expectedOrder = table.CreateInstance<OrderModel>();

            var content = await _scenarioContext.Get<HttpResponseMessage>(ScenarioContextKeys.Response).Content.ReadAsStringAsync();

            var actualOrder = JsonConvert.DeserializeObject<OrderModel>(content);

            actualOrder.Should().NotBeNull();
            actualOrder.Should().BeEquivalentTo(expectedOrder);
        }
    }
}