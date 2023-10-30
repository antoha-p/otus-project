using Domain.Entities.CoreService;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.EntityFramework.CoreService;

public class CoreServiceDBContext : DbContext
{
    public DbSet<ApplicationForm> ApplicationForms { get; set; }
    public DbSet<EventLogEntity> EventLogs { get; set; }
    public CoreServiceDBContext(DbContextOptions<CoreServiceDBContext> options) : base(options)
    {
        //Database.EnsureDeleted();
        //Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //а вот тут идёт инициализация бд начальными значаниями
        modelBuilder.Entity<ApplicationForm>().HasData(GetUserArrayHelper());
    }

    #region db initialize helpers
    private ApplicationForm[] GetUserArrayHelper()
    {
        var users = new ApplicationForm[]
        {
            new ApplicationForm { Id=1, FirstName="Иван", SecondName="Иванович",
                                  LastName="Иванов",FullName="Иванов Иван Иванович",
                                  Inn="1234566789"},
        };

        return users;
    }


    #endregion
}
