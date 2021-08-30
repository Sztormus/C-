namespace CommandPattern.Interfaces
{
    public interface ICommand
    {
        public void Execute();
        public bool CanExecute();
        public void Undo();
    }
}
