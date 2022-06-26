namespace ArvatoBootcampAPI.Data
{
    public interface IApiData
    {
        List<BootcampDto> BootcampList { get; set; }
        List<StudentDto> StudenList { get; set; }

        List<BootcampDto> GetBootcampList();

        bool Add<T>(List<T> dto);
    }
}
