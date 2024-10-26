namespace Assets.Source.Scripts.Utilities
{
    public class CountdownTimer
    {
        private float _time;

        public bool Over
        {
            get
            {
                return _time <= 0;
            }
        }
        public float Value => _time;

        public CountdownTimer(float duration)
        {
            Start(duration);
        }

        public void Start(float duration)
        {
            _time = duration;
        }

        public void Stop()
        {
            _time = 0;
        }

        public void Tick(float tick)
        {
            _time -= tick;
        }
    }
}
