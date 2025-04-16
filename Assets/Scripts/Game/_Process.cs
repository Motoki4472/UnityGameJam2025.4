namespace App.Game.ProcessSystem
{
    public class Process
    {
        public enum ProcessState
        {
            animation_distributing,
            playing,
            animation_matched,
            animation_collecting,
            animation_gotoresult,
            paused,
        }

        public ProcessState state = ProcessState.animation_distributing;
    }
}