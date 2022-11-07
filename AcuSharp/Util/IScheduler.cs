using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AcuSharp.Util
{
    public abstract class ScheduledTask
    {

    }

    public interface IScheduler
    {
        void ScheduleDelayedTask(ScheduledTask task, int delay);
    }

    public class InMemoryScheduler : IScheduler
    {

        private SortedList<DateTime, ScheduledTask> _schedule = new SortedList<DateTime, ScheduledTask>();

        private CancellationTokenSource _cancellationTokenSource;
        private Task _timeoutTask;
        private DateTime _nextTimout;

        public void ScheduleDelayedTask(ScheduledTask task, int delay)
        {
            var timeout = DateTime.Now.AddMilliseconds(delay);

            if (timeout < _nextTimout)
            {
                _cancellationTokenSource.Cancel();
            }
        }

        private void ScheduleNextTask()
        {

        }

        private void RunTask()
        {
            //_schedule.
        }
    }

    //public class TaskWithTimeoutWrapper
    //{
    //    protected volatile bool taskFinished = false;

    //    public async Task<T> RunWithCustomTimeoutAsync<T>(int millisecondsToTimeout, Func<Task<T>> taskFunc, CancellationTokenSource cancellationTokenSource = null)
    //    {
    //        this.taskFinished = false;

    //        var results = await Task.WhenAll<T>(new List<Task<T>>
    //    {
    //        this.RunTaskFuncWrappedAsync<T>(taskFunc),
    //        this.DelayToTimeoutAsync<T>(millisecondsToTimeout, cancellationTokenSource)
    //    });

    //        return results[0];
    //    }

    //    public async Task RunWithCustomTimeoutAsync(int millisecondsToTimeout, Func<Task> taskFunc, CancellationTokenSource cancellationTokenSource = null)
    //    {
    //        this.taskFinished = false;

    //        await Task.WhenAll(new List<Task>
    //    {
    //        this.RunTaskFuncWrappedAsync(taskFunc),
    //        this.DelayToTimeoutAsync(millisecondsToTimeout, cancellationTokenSource)
    //    });
    //    }

    //    protected async Task DelayToTimeoutAsync(int millisecondsToTimeout, CancellationTokenSource cancellationTokenSource)
    //    {
    //        await Task.Delay(millisecondsToTimeout);

    //        this.ActionOnTimeout(cancellationTokenSource);
    //    }

    //    protected async Task<T> DelayToTimeoutAsync<T>(int millisecondsToTimeout, CancellationTokenSource cancellationTokenSource)
    //    {
    //        await this.DelayToTimeoutAsync(millisecondsToTimeout, cancellationTokenSource);

    //        return default(T);
    //    }

    //    protected virtual void ActionOnTimeout(CancellationTokenSource cancellationTokenSource)
    //    {
    //        if (!this.taskFinished)
    //        {
    //            cancellationTokenSource?.Cancel();
    //            throw new NoInternetException();
    //        }
    //    }

    //    protected async Task RunTaskFuncWrappedAsync(Func<Task> taskFunc)
    //    {
    //        await taskFunc.Invoke();

    //        this.taskFinished = true;
    //    }

    //    protected async Task<T> RunTaskFuncWrappedAsync<T>(Func<Task<T>> taskFunc)
    //    {
    //        var result = await taskFunc.Invoke();

    //        this.taskFinished = true;

    //        return result;
    //    }
    //}
}
