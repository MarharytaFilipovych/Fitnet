namespace EvolutionaryArchitecture.Fitnet.UnitTests.Contracts.PrepareContract.BusinessRules;

using Common.BusinessRulesEngine;
using EvolutionaryArchitecture.Fitnet.Contracts.PrepareContract.BusinessRules;

public sealed class ContractCanBePreparedOnlyForAdultRuleTests
{
    [Fact]
    internal void Given_customer_age_which_is_less_than_18_Then_validation_should_throw()
    {
        // Arrange

        // Act & Assert
        var exception = Should.Throw<BusinessRuleValidationException>(() => BusinessRuleValidator.Validate(new ContractCanBePreparedOnlyForAdultRule(17)));
        exception.Message.ShouldBe("Contract can not be prepared for a person who is not adult");
    }

    [Fact]
    internal void Given_customer_age_which_is_equal_to_18_Then_validation_should_pass() =>
        Should.NotThrow(() => BusinessRuleValidator.Validate(new ContractCanBePreparedOnlyForAdultRule(18)));

    [Fact]
    internal void Given_customer_age_which_is_greater_than_18_Then_validation_should_pass() =>
        Should.NotThrow(() => BusinessRuleValidator.Validate(new ContractCanBePreparedOnlyForAdultRule(19)));
}
