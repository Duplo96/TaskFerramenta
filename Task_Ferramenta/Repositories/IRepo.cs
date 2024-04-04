namespace Task_Ferramenta.Repositories
{
    public interface IRepo <T>
    {
         
        T? GetById(int id);
        List<T> GetAll();
        bool insert(T t);
        bool update(T t);
        bool delete(int id);
        


    }
}

