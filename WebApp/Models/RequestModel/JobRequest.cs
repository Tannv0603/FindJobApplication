namespace WebApp.Models.RequestModel
{
    public class JobRequest
    {
        public string JobName { get; set; }
        public string JobImage { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public decimal StartSalary { get; set; }
        public decimal EndSalary { get; set; }
        public string Tags { get; set; }
        public string JobType { get; set; }
        public string Skill { get; set; }
        public short SkillLevel { get; set; }
        public string City { get; set; }
    }
}
