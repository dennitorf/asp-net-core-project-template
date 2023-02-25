using CompanyName.ProjectName.Persistence.Contexts;
using CompanyName.ProjectName.Application.Common.Mappings;
using AutoMapper;

namespace  CompanyName.ProjectName.Application.UnitTests.Mocks.Persistence
{
    public static class  AutoMapperMock
    {
        public static IMapper mapper;

        static AutoMapperMock()
        {
            var mapperConfiguration = new MapperConfiguration(c => {
                c.AddProfile<AutoMapperProfile>();
            });

            mapper = mapperConfiguration.CreateMapper();
        }        
    }
}