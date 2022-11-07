using AcuSharp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcuSharp.Services
{
    internal class OutputState
    {
        public IWeatherOutput Output { get; private set; }
        private Queue<MetricMeasurement> _measurementQueue;
        public OutputState(IWeatherOutput output)
        {
            Output = output;
        }

        public async Task Emit(MetricMeasurement metricMeasurement)
        {
            if (! await AttemptResend())
            {
                _measurementQueue.Enqueue(metricMeasurement);
            }
            else
            {
                if (!DoSend(metricMeasurement))
                {
                    _measurementQueue.Enqueue(metricMeasurement);
                }
            }
        }

        private async Task<bool> AttemptResend()
        {
            while (_measurementQueue.Count > 0)
            {
                var m = _measurementQueue.Peek();
                if (DoSend(m))
                {
                    _measurementQueue.Dequeue();
                    await Task.Delay(Output.RetryDelayMs());
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

        private bool DoSend(MetricMeasurement metricMeasurement)
        {
            try
            {
                Output.Write(metricMeasurement);
            }
            catch
            {
                return false;
            }

            return true;
        }
    }

    public class OutputDirector
    {
        private IEnumerable<OutputState> _states;

        public OutputDirector(params IWeatherOutput[] weatherOutputs)
        {
            _states = weatherOutputs.Select(p => new OutputState(p));
        }

        public void Dispatch(MetricMeasurement metricMeasurement)
        {
            foreach (var o in _states)
            {
                o.Emit(metricMeasurement);
            }
        }
    }

    public interface IWeatherOutput : IDisposable
    {
        void Write(MetricMeasurement measurement);
        int RetryDelayMs();
    }
}
