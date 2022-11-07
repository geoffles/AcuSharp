using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace AcuSharp.Tests
{
    public class TaskTests
    {
        [Fact]
        public void HowDoTasksWork()
        {
            CancellationTokenSource c = new CancellationTokenSource();
            bool b = false;
            bool b2 = false;

            bool dCalled = false;

            var delayedTask = Task.Delay(3000, c.Token)
                .ContinueWith((t) =>
                {
                    if (t.IsCanceled)
                    {
                        b = true;
                    };
                    throw new Exception("lol brah");
                });


            c.Cancel();
            delayedTask.Wait();
            Assert.True(b);

            CancellationTokenSource c2 = new CancellationTokenSource();
            var delayedTask2 = Task.Delay(3000, c2.Token).ContinueWith((t) => { if (t.IsCanceled) { b2 = true; } });
            delayedTask2.Wait();
            Assert.False(b2);
            
        }
    }
}
