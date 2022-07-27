using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SchoolProject.Models
{
    public class Context: IdentityDbContext<ApplicationUser>
    {
        //@"Data source=.\sqlExpress;Initial catalog= Intake42;Integrated security = true"
        public Context() : base()
        {

        }
       
        public Context(DbContextOptions Options) : base(Options)
        { }
        public DbSet<Bus> Buss { get; set; }
        //public DbSet<ApplicationUser> Users { get; set; }
        public DbSet<BusAdmin> BusAdmins { get; set; }
        public DbSet<BusLine> BusLines { get; set; }
        public DbSet<BusRegon> BusRegons { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseSchedule> courseSchedules { get; set; }
        public DbSet<CourseScheduleDetails> courseScheduleDetails { get; set; }
        // public DbSet<CourseTable> courseTables { get; set; }
      
        public DbSet<HeadManager> HeadManager { get; set; }
        public DbSet<HistoryOfStudend> historyOfStudends { get; set; }
        public DbSet<Level>Levels { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Parent> Parents { get; set; }
        public DbSet<Receptionist> Receptionists { get; set; }
       // public DbSet<School> Schools { get; set; }
        public DbSet<StaffAttentance> StaffAttentances { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentAttentance> StudentAttentances { get; set; }
        public DbSet<StudyYear> StudyYears { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Visitior> Visitiors { get; set; }
        public DbSet<VistorHitory> vistorHitories { get; set; }

        public DbSet<Quiz> ExamTables { get; set; }
        public DbSet<ExamSchedule> examSchedules { get; set; }
        public DbSet<ExamScheduleDetails> examScheduleDetails { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

           // optionsBuilder.UseSqlServer(@"Data source=.\sqlExpress;Initial catalog= Intake42;Integrated security = true");
            //to enable lazy loading  in project
           // optionsBuilder.UseLazyLoadingProxies(true);
            base.OnConfiguring(optionsBuilder);
        }
    }
}
