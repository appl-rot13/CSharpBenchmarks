## Summary

ソートアルゴリズムの学び直しのため、実装と整理を実施。

| アルゴリズム   | 安定性 | 最良計算量       | 平均計算量         | 最悪計算量       | 備考                         |
|:--------------:|:------:|:----------------:|:------------------:|:----------------:|:----------------------------:|
| バブルソート   | ◯     | O(n)             | O(n<sup>2</sup>)   | O(n<sup>2</sup>) |                              |
| 選択ソート     | ✕     | O(n<sup>2</sup>) | O(n<sup>2</sup>)   | O(n<sup>2</sup>) |                              |
| 挿入ソート     | ◯     | O(n)             | O(n<sup>2</sup>)   | O(n<sup>2</sup>) |                              |
| シェルソート   | ✕     | O(n log n)       | O(n<sup>1.5</sup>) | O(n<sup>2</sup>) | 性能がギャップの選び方に依存 |
| マージソート   | ◯     | O(n log n)       | O(n log n)         | O(n log n)       | 追加メモリが必要             |
| ヒープソート   | ✕     | O(n log n)       | O(n log n)         | O(n log n)       |                              |
| クイックソート | ✕     | O(n log n)       | O(n log n)         | O(n<sup>2</sup>) | 性能がピボットの選び方に依存 |

> [!NOTE]
> シェルソートの計算量は文献によって記載が異なるため、上記は誤りの可能性があります。

## Result

```
BenchmarkDotNet v0.15.6, Windows 11 (10.0.26200.7171)
Intel Core i7-10700 CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.0, 10.0.25.52411), X64 RyuJIT x86-64-v3
  DefaultJob : .NET 10.0.0 (10.0.0, 10.0.25.52411), X64 RyuJIT x86-64-v3
```

| Method        | N      | Source     | Mean                 | Error              | StdDev            | Gen0     | Gen1     | Gen2     | Allocated |
|-------------- |------- |----------- |---------------------:|-------------------:|------------------:|---------:|---------:|---------:|----------:|
| BubbleSort    | 10     | Shuffled   |            100.41 ns |           0.229 ns |          0.214 ns |   0.0076 |        - |        - |      64 B |
| SelectionSort | 10     | Shuffled   |             90.22 ns |           0.264 ns |          0.221 ns |   0.0076 |        - |        - |      64 B |
| InsertionSort | 10     | Shuffled   |             76.46 ns |           0.383 ns |          0.340 ns |   0.0076 |        - |        - |      64 B |
| ShellSort     | 10     | Shuffled   |             87.95 ns |           0.352 ns |          0.312 ns |   0.0076 |        - |        - |      64 B |
| MergeSort     | 10     | Shuffled   |            113.07 ns |           0.493 ns |          0.385 ns |   0.0153 |        - |        - |     128 B |
| HeapSort      | 10     | Shuffled   |            102.16 ns |           0.450 ns |          0.399 ns |   0.0076 |        - |        - |      64 B |
| QuickSort     | 10     | Shuffled   |             98.39 ns |           0.218 ns |          0.204 ns |   0.0076 |        - |        - |      64 B |
| BubbleSort    | 10     | Ascending  |             69.71 ns |           0.420 ns |          0.328 ns |   0.0076 |        - |        - |      64 B |
| SelectionSort | 10     | Ascending  |             86.54 ns |           0.235 ns |          0.219 ns |   0.0076 |        - |        - |      64 B |
| InsertionSort | 10     | Ascending  |             69.20 ns |           0.769 ns |          0.642 ns |   0.0076 |        - |        - |      64 B |
| ShellSort     | 10     | Ascending  |             89.97 ns |           0.231 ns |          0.205 ns |   0.0076 |        - |        - |      64 B |
| MergeSort     | 10     | Ascending  |            110.40 ns |           0.260 ns |          0.243 ns |   0.0153 |        - |        - |     128 B |
| HeapSort      | 10     | Ascending  |             98.26 ns |           0.243 ns |          0.215 ns |   0.0076 |        - |        - |      64 B |
| QuickSort     | 10     | Ascending  |             90.03 ns |           0.198 ns |          0.175 ns |   0.0076 |        - |        - |      64 B |
| BubbleSort    | 10     | Descending |            103.50 ns |           1.489 ns |          1.393 ns |   0.0076 |        - |        - |      64 B |
| SelectionSort | 10     | Descending |             92.57 ns |           0.270 ns |          0.239 ns |   0.0076 |        - |        - |      64 B |
| InsertionSort | 10     | Descending |             86.36 ns |           0.712 ns |          0.666 ns |   0.0076 |        - |        - |      64 B |
| ShellSort     | 10     | Descending |             93.32 ns |           0.213 ns |          0.199 ns |   0.0076 |        - |        - |      64 B |
| MergeSort     | 10     | Descending |            113.63 ns |           1.488 ns |          1.319 ns |   0.0153 |        - |        - |     128 B |
| HeapSort      | 10     | Descending |            103.03 ns |           1.715 ns |          1.521 ns |   0.0076 |        - |        - |      64 B |
| QuickSort     | 10     | Descending |             99.18 ns |           0.700 ns |          0.654 ns |   0.0076 |        - |        - |      64 B |
| BubbleSort    | 1000   | Shuffled   |        512,688.61 ns |       2,346.678 ns |      2,195.084 ns |        - |        - |        - |    4024 B |
| SelectionSort | 1000   | Shuffled   |        259,069.48 ns |         442.814 ns |        414.208 ns |        - |        - |        - |    4024 B |
| InsertionSort | 1000   | Shuffled   |        133,482.71 ns |         832.123 ns |        778.369 ns |   0.2441 |        - |        - |    4024 B |
| ShellSort     | 1000   | Shuffled   |         42,511.06 ns |         163.003 ns |        152.473 ns |   0.4272 |        - |        - |    4024 B |
| MergeSort     | 1000   | Shuffled   |         38,466.78 ns |         304.395 ns |        284.731 ns |   0.9155 |        - |        - |    8048 B |
| HeapSort      | 1000   | Shuffled   |         26,960.73 ns |          53.852 ns |         47.738 ns |   0.4578 |        - |        - |    4024 B |
| QuickSort     | 1000   | Shuffled   |         22,709.00 ns |          78.072 ns |         65.194 ns |   0.4578 |        - |        - |    4024 B |
| BubbleSort    | 1000   | Ascending  |            635.72 ns |           1.476 ns |          1.380 ns |   0.4787 |        - |        - |    4024 B |
| SelectionSort | 1000   | Ascending  |        215,449.42 ns |         343.542 ns |        286.874 ns |   0.2441 |        - |        - |    4024 B |
| InsertionSort | 1000   | Ascending  |            856.05 ns |           1.666 ns |          1.559 ns |   0.4787 |        - |        - |    4024 B |
| ShellSort     | 1000   | Ascending  |          6,979.77 ns |          14.115 ns |         11.787 ns |   0.4730 |        - |        - |    4024 B |
| MergeSort     | 1000   | Ascending  |         15,241.24 ns |          33.995 ns |         28.388 ns |   0.9460 |        - |        - |    8048 B |
| HeapSort      | 1000   | Ascending  |         24,174.50 ns |         303.393 ns |        283.794 ns |   0.4578 |        - |        - |    4024 B |
| QuickSort     | 1000   | Ascending  |          4,229.99 ns |           8.657 ns |          8.098 ns |   0.4730 |        - |        - |    4024 B |
| BubbleSort    | 1000   | Descending |        428,401.88 ns |         942.800 ns |        835.768 ns |        - |        - |        - |    4024 B |
| SelectionSort | 1000   | Descending |        238,360.27 ns |       1,803.269 ns |      1,598.551 ns |   0.2441 |        - |        - |    4024 B |
| InsertionSort | 1000   | Descending |        250,347.13 ns |         504.399 ns |        421.196 ns |        - |        - |        - |    4024 B |
| ShellSort     | 1000   | Descending |         10,856.50 ns |          84.949 ns |         79.461 ns |   0.4730 |        - |        - |    4024 B |
| MergeSort     | 1000   | Descending |         15,812.13 ns |         181.364 ns |        169.648 ns |   0.9460 |        - |        - |    8048 B |
| HeapSort      | 1000   | Descending |         24,937.16 ns |         204.937 ns |        191.698 ns |   0.4578 |        - |        - |    4024 B |
| QuickSort     | 1000   | Descending |          4,767.92 ns |          53.012 ns |         49.587 ns |   0.4730 |        - |        - |    4024 B |
| BubbleSort    | 100000 | Shuffled   | 11,733,177,546.67 ns | 103,343,862.574 ns | 96,667,913.215 ns |        - |        - |        - |  400024 B |
| SelectionSort | 100000 | Shuffled   |  2,817,127,235.71 ns |  11,208,252.474 ns |  9,935,823.881 ns |        - |        - |        - |  400024 B |
| InsertionSort | 100000 | Shuffled   |  1,408,630,486.67 ns |   7,800,214.987 ns |  7,296,325.941 ns |        - |        - |        - |  400024 B |
| ShellSort     | 100000 | Shuffled   |      9,091,378.96 ns |      34,441.525 ns |     32,216.624 ns |  93.7500 |  93.7500 |  93.7500 |  400053 B |
| MergeSort     | 100000 | Shuffled   |      6,652,570.10 ns |      10,435.418 ns |      9,761.297 ns | 195.3125 | 195.3125 | 195.3125 |  800107 B |
| HeapSort      | 100000 | Shuffled   |      6,486,577.97 ns |      13,871.073 ns |     12,975.010 ns | 101.5625 | 101.5625 | 101.5625 |  400056 B |
| QuickSort     | 100000 | Shuffled   |      5,211,663.18 ns |      13,490.331 ns |     12,618.864 ns | 101.5625 | 101.5625 | 101.5625 |  400056 B |
| BubbleSort    | 100000 | Ascending  |         68,690.96 ns |          47.170 ns |         44.122 ns | 110.9619 | 110.9619 | 110.9619 |  400059 B |
| SelectionSort | 100000 | Ascending  |  2,880,683,666.67 ns |  56,014,531.506 ns | 66,681,321.073 ns |        - |        - |        - |  400024 B |
| InsertionSort | 100000 | Ascending  |        107,160.09 ns |       2,064.965 ns |      2,209.489 ns | 110.9619 | 110.9619 | 110.9619 |  400059 B |
| ShellSort     | 100000 | Ascending  |      1,299,714.62 ns |       3,732.010 ns |      3,490.925 ns | 109.3750 | 109.3750 | 109.3750 |  400058 B |
| MergeSort     | 100000 | Ascending  |      2,195,264.10 ns |       2,783.792 ns |      2,173.402 ns | 203.1250 | 203.1250 | 203.1250 |  800110 B |
| HeapSort      | 100000 | Ascending  |      3,639,498.62 ns |       6,246.172 ns |      5,842.673 ns | 109.3750 | 109.3750 | 109.3750 |  400058 B |
| QuickSort     | 100000 | Ascending  |        655,385.94 ns |       1,523.330 ns |      1,424.924 ns | 110.3516 | 110.3516 | 110.3516 |  400058 B |
| BubbleSort    | 100000 | Descending |  5,253,884,641.67 ns |  10,661,696.713 ns |  8,323,951.499 ns |        - |        - |        - |  400024 B |
| SelectionSort | 100000 | Descending |  2,981,883,171.43 ns |   4,137,104.423 ns |  3,667,435.313 ns |        - |        - |        - |  400024 B |
| InsertionSort | 100000 | Descending |  2,806,337,884.62 ns |   4,556,208.968 ns |  3,804,640.841 ns |        - |        - |        - |  400024 B |
| ShellSort     | 100000 | Descending |      1,849,473.69 ns |       4,550.537 ns |      3,799.904 ns | 109.3750 | 109.3750 | 109.3750 |  400058 B |
| MergeSort     | 100000 | Descending |      2,232,037.81 ns |       3,811.557 ns |      3,565.333 ns | 199.2188 | 199.2188 | 199.2188 |  800108 B |
| HeapSort      | 100000 | Descending |      4,415,076.61 ns |      12,366.159 ns |     11,567.313 ns | 101.5625 | 101.5625 | 101.5625 |  400056 B |
| QuickSort     | 100000 | Descending |        745,519.29 ns |      10,970.829 ns |      9,725.354 ns | 110.3516 | 110.3516 | 110.3516 |  400058 B |
