using Application.Mapping;
using AutoMapper;

namespace Tests.Unit.RecipeTests.Mapping;

public class RecipeMappingProfilePositiveTest
{
    private readonly IMapper _mapper;
    private readonly MapperConfiguration _configuration ;

    public RecipeMappingProfilePositiveTest()
    {
        var config = new MapperConfiguration(cfg =>
            cfg.AddProfile<RecipeMappingProfile>());
        _configuration = config;

        _mapper = config.CreateMapper();
    }
    
    [Fact]
    public void Recipe_MappingConfiguration_IsValid()
    {
        _configuration.AssertConfigurationIsValid();
    }
}