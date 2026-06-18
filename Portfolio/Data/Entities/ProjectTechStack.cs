namespace Portfolio.Data.Entities
{
    public class ProjectTechStack
    {
        public int Id { get; set; }
        //EF Core kendi id olusturdugu icin ayrı olarak id tanımlamamıza gerek yok.
        public int ProjectId { get; set; }
        //navigation property
        public Project Project { get; set; }
        public int TechStackId { get; set; }
        public TechStack TechStack { get; set; }
    }
}
