using System;

namespace Contracts
{
    public interface IWetterService
    {
        string GetWeather(DateTime date);

        int GetTemperature(DateTime date);

    }
}
