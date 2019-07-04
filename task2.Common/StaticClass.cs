namespace task2.Common
{
    using AutoMapper;
    using task2.BLL.DTO;
    using task2.Models;

    public static class StaticClass
    {
        public static IMapper mapper = new MapperConfiguration(cfg => cfg.CreateMap<PeopleDTO, PeopleViewModel>()).CreateMapper();
    }
}
