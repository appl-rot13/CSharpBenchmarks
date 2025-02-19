## Result

- 対象の文字列が長い場合、`ReadOnlySpan` の `ContainsAny()` を利用した方が速い
- 対象の文字列が短い場合、LINQで十分

```
BenchmarkDotNet v0.14.0, Windows 11 (10.0.26100.3194)
Intel Core i7-10700 CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 9.0.200
  [Host]     : .NET 9.0.2 (9.0.225.6610), X64 RyuJIT AVX2
  DefaultJob : .NET 9.0.2 (9.0.225.6610), X64 RyuJIT AVX2
```

| Method   | N      | Case  | Mean         | Error      | StdDev     | Gen0   | Gen1   | Allocated |
|--------- |------- |------ |-------------:|-----------:|-----------:|-------:|-------:|----------:|
| WithLinq | 4      | False |     34.39 ns |   0.157 ns |   0.147 ns | 0.0114 |      - |      96 B |
| WithSpan | 4      | False |    418.47 ns |   8.366 ns |  13.977 ns | 0.1884 | 0.0010 |    1576 B |
| WithLinq | 4      | True  |     20.27 ns |   0.199 ns |   0.177 ns | 0.0115 |      - |      96 B |
| WithSpan | 4      | True  |    417.14 ns |   3.220 ns |   2.854 ns | 0.1884 | 0.0010 |    1576 B |
| WithLinq | 64     | False |     43.51 ns |   0.282 ns |   0.263 ns | 0.0114 |      - |      96 B |
| WithSpan | 64     | False |    417.32 ns |   3.532 ns |   3.304 ns | 0.1884 | 0.0010 |    1576 B |
| WithLinq | 64     | True  |     19.97 ns |   0.072 ns |   0.064 ns | 0.0115 |      - |      96 B |
| WithSpan | 64     | True  |    419.22 ns |   3.552 ns |   3.149 ns | 0.1884 | 0.0010 |    1576 B |
| WithLinq | 1024   | False |    202.54 ns |   0.212 ns |   0.188 ns | 0.0114 |      - |      96 B |
| WithSpan | 1024   | False |    508.11 ns |   2.170 ns |   2.030 ns | 0.1879 | 0.0010 |    1576 B |
| WithLinq | 1024   | True  |     21.83 ns |   0.122 ns |   0.114 ns | 0.0115 |      - |      96 B |
| WithSpan | 1024   | True  |    429.47 ns |   7.449 ns |  12.028 ns | 0.1884 | 0.0010 |    1576 B |
| WithLinq | 16384  | False |  2,474.43 ns |  10.529 ns |   9.334 ns | 0.0114 |      - |      96 B |
| WithSpan | 16384  | False |  1,964.41 ns |   2.048 ns |   1.815 ns | 0.1869 |      - |    1576 B |
| WithLinq | 16384  | True  |     20.15 ns |   0.255 ns |   0.238 ns | 0.0115 |      - |      96 B |
| WithSpan | 16384  | True  |    425.95 ns |   2.910 ns |   2.430 ns | 0.1884 | 0.0010 |    1576 B |
| WithLinq | 262144 | False | 48,413.49 ns | 202.083 ns | 189.028 ns |      - |      - |      96 B |
| WithSpan | 262144 | False | 26,341.89 ns |  64.342 ns |  60.185 ns | 0.1831 |      - |    1576 B |
| WithLinq | 262144 | True  |     20.83 ns |   0.412 ns |   0.763 ns | 0.0115 |      - |      96 B |
| WithSpan | 262144 | True  |    429.84 ns |   4.851 ns |   4.537 ns | 0.1884 | 0.0010 |    1576 B |

![Graph](img/Graph.png)
