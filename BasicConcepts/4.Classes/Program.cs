using System;
using static System.Console;
using System.Threading;

public class StopWatch
{
    private DateTime _startTime;
    private TimeSpan _elapsedTime;
    private bool _isRunning;

    // All the cimbinations for constructor
    public StopWatch()
    {
        this._isRunning = false; this._startTime = default; this._elapsedTime = TimeSpan.Zero;
    }

    public void Start()
    {
        if (this._isRunning)
        {
            WriteLine("The watch's already running.");
        }
        else
        {
            this._isRunning = true;
            this._startTime = DateTime.Now;
        }
    }
    public void Stop()
    {
        if (!this._isRunning)
        {
            WriteLine("The watch isn't running.");
        }
        else
        {
            this._isRunning = false;
            this._elapsedTime += DateTime.Now - this._startTime;
        }
    }

    public void Reset()
    {
        _elapsedTime = TimeSpan.Zero;
        _isRunning = false;
    }

    public TimeSpan ElapsedTime
    {
        get
        {
            return this._isRunning ? this._elapsedTime + (DateTime.Now - this._startTime) : this._elapsedTime;
        }
    }
}



class TestProgram
{
    static void Main()
    {
        var stopwatch = new StopWatch();

        // Runs for 1.5 consecituve seconds.
        WriteLine("Test 1:");
        stopwatch.Start();
        Thread.Sleep(1500); // Wait for 1.5 seconds
        stopwatch.Stop();
        WriteLine($"Elapsed Time: {stopwatch.ElapsedTime}");
        WriteLine();

        // runs for 1 second, waits for 2 and then runs for another 1 second.
        WriteLine("Test 2:");
        stopwatch.Reset();
        stopwatch.Start();
        Thread.Sleep(1000);
        stopwatch.Stop();

        Thread.Sleep(2000);

        stopwatch.Start();
        Thread.Sleep(1000);
        stopwatch.Stop();
        WriteLine($"{stopwatch.ElapsedTime}");
        WriteLine();
    }
}
