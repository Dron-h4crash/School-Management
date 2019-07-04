namespace task2.Util
{
    using AutoMapper;
    using task2.BLL.DTO;
    using task2.Models;

    public static class MapperUtils
    {
        public static IMapper mapper = new MapperConfiguration(cfg => cfg.CreateMap<PeopleDTO, PeopleViewModel>()).CreateMapper();
    }
}
