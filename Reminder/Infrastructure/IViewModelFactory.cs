namespace Reminder.Infrastructure
{
    public interface IViewModelFactory
    {
        T Create<T>();
        void Release(object viewModel);
    }
}