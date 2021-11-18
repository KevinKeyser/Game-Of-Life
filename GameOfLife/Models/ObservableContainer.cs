namespace GameOfLife.Models
{
    public class ObservableContainer<T> : Observable
    {
        private T? trackedObject;

        public T? TrackedObject
        {
            get => trackedObject;
            set => TrySetAndNotify(ref trackedObject, value);
        }

        public ObservableContainer() { }

        public ObservableContainer(T? trackedObject)
        {
            this.trackedObject = trackedObject;
        }

        public static implicit operator ObservableContainer<T> (T trackedObject)
        {
            return new ObservableContainer<T>(trackedObject);
        }
    }
}
