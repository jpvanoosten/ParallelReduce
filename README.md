# Parallel Reduce

- [Parallel Reduce](#parallel-reduce)
  - [Installation](#installation)
  - [Dependencies](#dependencies)
  - [Test Dependencies](#test-dependencies)
  - [Known Issues](#known-issues)

This repo demonstrates how to use the ParallelReduce job to reduce an array of values to a single element.

Some examples of a parallel reduce are:

1. Finding the min and max points in mesh to compute the bounding box of the mesh
2. Summing a set of values
3. Comupting the sum of the products of a set of values

## Installation

To use this project, just copy-paste the contents of the [ParallelReduce.cs](Assets/Scripts/ParallelReduce.cs) file into your project.

## Dependencies

The ParallelReduce.cs script depends on the following packages:

| Package     | Version           | URI                                                                                                    |
| ----------- | ----------------- | ------------------------------------------------------------------------------------------------------ |
| Burst       | 1.7.0             | [com.unity.burst](https://docs.unity3d.com/Packages/com.unity.burst@1.7/manual/index.html)             |
| Jobs        | 0.50.0-preview.8† | [com.unity.jobs](https://docs.unity3d.com/Packages/com.unity.jobs@0.50/manual/index.html)              |
| Mathematics | 1.2.5             | [com.unity.mathematics](https://docs.unity3d.com/Packages/com.unity.mathematics@1.2/manual/index.html) |

† See [Known Issues](#known-issues)

## Test Dependencies

If you also want to run the performance tests, you will need the additional packages:

| Package                 | Version       | URI                                                                                                                                  |
| ----------------------- | ------------- | ------------------------------------------------------------------------------------------------------------------------------------ |
| Performance testing API | 2.8.0-preview | [com.unity.test-framework.performance](https://docs.unity3d.com/Packages/com.unity.test-framework.performance@2.8/manual/index.html) |

## Known Issues

There is currently an issue with the Jobs (0.50.0-preview.8) package which results in the following error when using `IJobParallelForBatch`:

```txt
System.InvalidOperationException : Reflection data was not set up by an Initialize() call
```

The current work-around is to use Jobs version **0.11.0-preview.6**.
