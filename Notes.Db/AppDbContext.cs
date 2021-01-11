using Microsoft.EntityFrameworkCore;


namespace Notes.Db
{
    public class AppDbContext:DbContext
    {
        public DbSet<Note> Notes { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\mssqllocaldb;Database=NotesDb;Integrated Security=True");
        }
    }
}
