namespace BackEnd.DataService.DataContext
{
    public interface IDbContextFactory
    {
        DataContext GetNewInstance();
    }
}
