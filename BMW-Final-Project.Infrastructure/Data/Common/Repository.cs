namespace BMW_Final_Project.Infrastructure.Data.Common
{
    public class Repository : IRepository
    {
        public IQueryable<T> All<T>() where T : class
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> AllReadOnly<T>() where T : class
        {
            throw new NotImplementedException();
        }
    }
}
