namespace App.Application
{
    public interface ITransaction
    {
        void begin();

        void rollback();

        void commit();
    }
}
