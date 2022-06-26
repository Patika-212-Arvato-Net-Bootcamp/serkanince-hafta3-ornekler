namespace ArvatoBootcampAPI.Data
{
    public class ApiData : IApiData
    {
        public List<BootcampDto> BootcampList { get; set; }
        public List<StudentDto> StudenList { get; set; }

        public Dictionary<Type, int> Types = new Dictionary<Type, int>
        {
            { typeof(List<BootcampDto>),1},
            { typeof(List<StudentDto>),2}
        };

        public ApiData()
        {
            BootcampList = new List<BootcampDto>();
            StudenList = new List<StudentDto>();

            BootcampList.Add(new BootcampDto()
            {
                Id = 1,
                Title = "Arvato Bootcamp",
                Description = "Mükemmel bir bootcamp",
                ImageUrl = "blabla"
            });
            BootcampList.Add(new BootcampDto()
            {
                Id = 2,
                Title = "Zirve Bootcamp",
                Description = "Mükemmel bir bootcamp",
                ImageUrl = "blabla"
            });

            StudenList.Add(new StudentDto()
            {
                Id = 1,
                Age = 21,
                Name = "Hasan",
                Surname = "Hüseyin"
            });
        }

        public List<BootcampDto> GetBootcampList()
        {
            return BootcampList;
        }

        public bool Add<T>(List<T> list)
        {
            switch (Types[list.GetType()])
            {
                case 1:
                    BootcampList.AddRange(list as List<BootcampDto>);
                    break;
                case 2:
                    StudenList.AddRange(list as List<StudentDto>);
                    break;
                default:
                    break;
            }
            return true;
        }
    }
}
