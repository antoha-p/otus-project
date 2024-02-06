using Domain.Entities.CoreService;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EntityFramework.CoreService;

public class CoreDBContext : DbContext
{
    public CoreDBContext(DbContextOptions<CoreDBContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Request> Requests { get; set; }
    public DbSet<ScorringResult> ScorringResults { get; set; }





    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //optionsBuilder.Co
        base.OnConfiguring(optionsBuilder);
    }
}

/*
// forDelete
public DbSet<ApplicationForm> ApplicationForms { get; set; }

// forDelete
public DbSet<EventLogEntity> EventLogs { get; set; }*/

/*
 * // forDelete
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    //а вот тут идёт инициализация бд начальными значаниями
    modelBuilder.Entity<ApplicationForm>().HasData(GetUserArrayHelper());
}
*/
/*
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
*/

