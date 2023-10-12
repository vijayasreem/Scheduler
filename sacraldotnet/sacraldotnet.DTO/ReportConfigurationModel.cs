
namespace sacraldotnet
{
    public class ReportConfigurationModel
    {
        public int Id { get; set; }

        public string FileType { get; set; }

        public string Destination { get; set; }

        public string Frequency { get; set; }
    }

    public class VendorModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Sector { get; set; }
    }

    public class FileModel
    {
        public int Id { get; set; }

        public string FileName { get; set; }

        public string FileContent { get; set; }
    }

    public class ScheduleModel
    {
        public int Id { get; set; }

        public DateTime ScheduleDateTime { get; set; }
    }
}
