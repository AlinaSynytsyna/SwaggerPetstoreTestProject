using SwaggerPetstoreTestProject.Constants;
using SwaggerPetstoreTestProject.Models;
using SwaggerPetstoreTestProject.Steps;

namespace SwaggerPetstoreTestProject.StepDefinitions
{
    [Binding]
    internal sealed class PetSteps : BaseSteps
    {
        internal PetSteps(ScenarioContext scenarioContext, IObjectContainer objectContainer) : base(scenarioContext, objectContainer) { }

        [Given(@"the user sends request to add a new pet with the following parameters")]
        internal async Task GivenTheUserSendsRequestToAddNewPetWithTheFollowingParametersWithoutSavingTheResponse(Table table)
        {
            var pet = new PetModel
            {
                Id = Convert.ToInt32(table.Rows[0][0]),
                Category = new Category
                {
                    Id = Convert.ToInt32(table.Rows[0][1]),
                    Name = table.Rows[0][2],
                },
                Name = table.Rows[0][3],
                PhotoUrls = new List<string>()
                {
                    table.Rows[0][4],
                },
                Tags = new List<Tag>
                {
                    new Tag
                    {
                        Id = Convert.ToInt32(table.Rows[0][5]),
                        Name = table.Rows[0][6]
                    }
                },
                Status = table.Rows[0][7]
            };

            var petJson = JsonConvert.SerializeObject(pet);

            var url = string.Concat(UrlConstants.BaseUrl, UrlConstants.AddNewPet);

            await httpRequestHelper.PostAsync(url, petJson);
        }

        [When(@"the user sends request to add a new pet with the following parameters")]
        internal async Task WhenTheUserSendsRequestToAddANewPetWithTheFollowingParameters(Table table)
        {
            var pet = new PetModel
            {
                Id = Convert.ToInt32(table.Rows[0][0]),
                Category = new Category
                {
                    Id = Convert.ToInt32(table.Rows[0][1]),
                    Name = table.Rows[0][2],
                },
                Name = table.Rows[0][3],
                PhotoUrls = new List<string>()
                {
                    table.Rows[0][4],
                },
                Tags = new List<Tag>
                {
                    new Tag
                    {
                        Id = Convert.ToInt32(table.Rows[0][5]),
                        Name = table.Rows[0][6]
                    }
                },
                Status = table.Rows[0][7]
            };

            var petJson = JsonConvert.SerializeObject(pet);

            var url = string.Concat(UrlConstants.BaseUrl, UrlConstants.AddNewPet);

            var response = await httpRequestHelper.PostAsync(url, petJson);

            _scenarioContext.Add(ScenarioContextKeys.Response, response);
        }

        [When(@"the user sends request to get information about the pet with ID (.*)")]
        internal async Task WhenTheUserSendsRequestToGetInformationAboutThePetWithId(int id)
        {
            var url = string.Format(string.Concat(UrlConstants.BaseUrl, UrlConstants.FindOrDeletePetById), id);

            var response = await httpRequestHelper.GetAsync(url);

            _scenarioContext.Add(ScenarioContextKeys.Response, response);
        }

        [When(@"the user sends request to delete information about the pet with ID (.*)")]
        internal async Task WhenTheUserSendsRequestToDeleteInformationAboutThePetWithId(int id)
        {
            var url = string.Format(string.Concat(UrlConstants.BaseUrl, UrlConstants.FindOrDeletePetById), id);

            var response = await httpRequestHelper.DeleteAsync(url);

            _scenarioContext.Add(ScenarioContextKeys.Response, response);
        }

        [Then(@"the response contains the following information about the pet")]
        internal async Task ThenTheResponseShouldContainTheFollowingInfomationAboutThePet(Table table)
        {
            var expectedPet = new PetModel
            {
                Id = Convert.ToInt32(table.Rows[0][0]),
                Category = new Category
                {
                    Id = Convert.ToInt32(table.Rows[0][1]),
                    Name = table.Rows[0][2],
                },
                Name = table.Rows[0][3],
                PhotoUrls = new List<string>()
                {
                    table.Rows[0][4],
                },
                Tags = new List<Tag>
                {
                    new Tag
                    {
                        Id = Convert.ToInt32(table.Rows[0][5]),
                        Name = table.Rows[0][6]
                    }
                },
                Status = table.Rows[0][7]
            };

            var content = await _scenarioContext.Get<HttpResponseMessage>(ScenarioContextKeys.Response).Content.ReadAsStringAsync();

            var actualPet = JsonConvert.DeserializeObject<PetModel>(content);

            actualPet.Should().NotBeNull();
            actualPet.Should().BeEquivalentTo(expectedPet);
        }
    }
}