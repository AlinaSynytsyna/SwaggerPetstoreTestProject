using SwaggerPetstoreTestProject.Helpers;

namespace SwaggerPetstoreTestProject.Steps
{
    [Binding]
    internal class BaseSteps
    {
        internal HttpRequestHelper httpRequestHelper;
        internal ScenarioContext _scenarioContext;

        internal BaseSteps(ScenarioContext scenarioContext, IObjectContainer objectContainer)
        {
            httpRequestHelper = objectContainer.Resolve<HttpRequestHelper>();
            _scenarioContext = scenarioContext;
        }
    }
}