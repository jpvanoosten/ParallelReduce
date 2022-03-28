using System;
using System.Collections.Generic;
using NUnit.Framework;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.PerformanceTesting;
using UnityEditor;
using UnityEngine;
using static Unity.Mathematics.math;

public class ParallelReduceTest
{
    struct SumInt : IBinaryOperator<int>
    {
        public int Operator(int a, int b)
        {
            return a + b;
        }
    }

    [Test, Performance]
    public void Test()
    {
        const int NUM_VALUES = 1000000;

        var a = new NativeArray<int>(NUM_VALUES, Allocator.TempJob, NativeArrayOptions.UninitializedMemory);
        for (int i = 0; i < NUM_VALUES; ++i)
        {
            a[i] = i;
        }

        int sum0 = 0;
        Measure.Method(() =>
        {
            sum0 = 0;
            for (int i = 0; i < NUM_VALUES; ++i)
            {
                sum0 += a[i];
            }
        }).SampleGroup($"Serial ({NUM_VALUES})").Run();

        int sum1 = 0;
        Measure.Method(() =>
        {
            sum1 = ParallelReduce.Reduce(a, new SumInt());
        }).SampleGroup($"Parallel ({NUM_VALUES})").Run();

        Assert.AreEqual(sum0, sum1);

        a.Dispose();
    }
}