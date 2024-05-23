using KpopApi.Models.Entities;

namespace KpopApi.Repositories
{
    public class Repository<T> where T : class
    {
        public Repository(WebsitosAngularProjectContext context)
        {
            Context = context;
        }

        public WebsitosAngularProjectContext Context { get; }


        public virtual IEnumerable<T> GetAll()
        {
            return Context.Set<T>();
        }
        public virtual T? Get(object id)
        {
            return Context.Find<T>(id);
        }

        public virtual void Insert(T entity)
        {
            Context.Add(entity);
            Context.SaveChanges();
        }
        public virtual void Update(T entity)
        {
            Context.Update(entity);
            Context.SaveChanges();
        }
        public virtual void Delete(T entity)
        {
            Context.Remove(entity);
            Context.SaveChanges();
        }

        public virtual void Delete(object id) /*por si se elimina solo con id*/
        {
            var entity = Get(id);
            if (entity != null)
            {
                Delete(entity);
            }

        }
    }
}
