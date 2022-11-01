using Bogus;
using SpecFlowGoRestAPITest.Support;

namespace SpecFlowGoRestAPITest.StepDefinitions
{
    [Binding]
    public class BogusSteps
    {
        [Given(@"I want to create new user request body")]
        public void GivenIWantToCreateNewUserRequestBody()
        {
            var fakerUser = new Faker<User>()
                .RuleFor(x => x.Gender, f => f.PickRandom<Bogus.DataSets.Name.Gender>())
                .RuleFor(x => x.FirstName, (f,x) => f.Name.FirstName(x.Gender))
                .RuleFor(x => x.LastName, (f,x) => f.Name.LastName(x.Gender))
                .RuleFor(x => x.Email, (f, x) => f.Internet.Email(x.FirstName,x.LastName))
                .RuleFor(x => x.Status, f => f.PickRandom<Status>().ToString());

            var requestBody = fakerUser.Generate();
        }
        enum Status
        {
            Active,
            Inactive
        }

    }
}
